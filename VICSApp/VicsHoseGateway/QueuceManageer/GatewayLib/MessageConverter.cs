namespace GatewayLib
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Messaging;
    using System.Reflection;
    using System.Text;

    public class MessageConverter
    {
        private static List<MessageTypeMapping> mappingList = null;
        private static List<MessageFieldDescription> messageFieldDescriptionList = null;

        public static object[] ConvertMessage(Message[] messages)
        {
            object[] objArray = new object[messages.Length];
            byte[] buffer = null;
            char[] chars = null;
            for (int i = 0; i < objArray.Length; i++)
            {
                buffer = new byte[messages[i].BodyStream.Length];
                messages[i].BodyStream.Seek(0L, SeekOrigin.Begin);
                messages[i].BodyStream.Read(buffer, 0, buffer.Length);
                chars = Encoding.Unicode.GetChars(buffer);
                objArray[i] = Encoding.ASCII.GetBytes(chars);
            }
            return objArray;
        }

        public static byte[] ConvertMessageToRawFormat(object message)
        {
            object obj2 = new object();
            Type type = message.GetType();
            PropertyInfo[] properties = type.GetProperties();
            string name = string.Empty;
            string str2 = string.Empty;
            string dataType = "";
            short size = 0;
            StringBuilder builder = new StringBuilder();
            List<MessageFieldDescription> messageFields = GetMessageFields(type.GetProperty("MESSAGE_TYPE").GetValue(message, null).ToString());
            foreach (MessageFieldDescription description in messageFields)
            {
                PropertyInfo property = type.GetProperty(description.FieldName);
                name = property.Name;
                dataType = description.DataType;
                size = description.Size;
                if (property.GetValue(message, null) != null)
                {
                    str2 = property.GetValue(message, null).ToString();
                }
                else if (dataType == "Mod-96")
                {
                    str2 = " ";
                }
                else if (dataType == "Numeric String")
                {
                    str2 = "0";
                }
                else if ((dataType == "Alpha String") || (dataType == "Alphanumeric String"))
                {
                    str2 = " ";
                }
                switch (dataType)
                {
                    case "Numeric String":
                        while (str2.Length < size)
                        {
                            str2 = "0" + str2;
                        }
                        break;

                    case "Alpha String":
                    case "Alphanumeric String":
                        while (str2.Length < size)
                        {
                            str2 = str2 + " ";
                        }
                        break;

                    case "Mod-96":
                        str2 = ConvertToMod96(Convert.ToInt32(str2));
                        while (str2.Length < size)
                        {
                            str2 = " " + str2;
                        }
                        break;
                }
                builder.Append(str2);
            }
            char[] chars = builder.ToString().ToCharArray();
            return Encoding.ASCII.GetBytes(chars);
        }

        public static int ConvertMod96ToInt(string mod96)
        {
            char[] chArray = mod96.ToCharArray();
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < chArray.Length; i++)
            {
                num2 = chArray[i] - ' ';
                for (int j = 0; j < ((chArray.Length - 1) - i); j++)
                {
                    num2 *= 0x60;
                }
                num += num2;
            }
            return num;
        }

        public static object ConvertMSMQMessageToHOSEMessage(Message message)
        {
            byte[] bytes = GetBytes(message);
            if (bytes != null)
            {
                return ConvertRawFormatToMessage(bytes);
            }
            return null;
        }

        public static object ConvertRawFormatToMessage(byte[] bytes)
        {
            if (bytes.Length < 2)
            {
                return null;
            }
            object obj2 = null;
            string messageType = Encoding.ASCII.GetString(bytes, 0, 2);
            string className = GetClassName(messageType);
            if ((className != null) && !className.Equals(string.Empty))
            {
                string fieldmessage = string.Empty;
                try
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    AssemblyName name = executingAssembly.GetName();
                    Type type = executingAssembly.GetType(name.Name + "." + className);
                    obj2 = Activator.CreateInstance(type);
                    string str3 = string.Empty;
                    string str4 = string.Empty;
                    string str5 = string.Empty;
                    string str6 = string.Empty;
                    string dataType = "";
                    int index = 0;
                    int count = 0;
                    List<MessageFieldDescription> messageFields = GetMessageFields(messageType);
                    foreach (MessageFieldDescription description in messageFields)
                    {
                        PropertyInfo property = type.GetProperty(description.FieldName);
                        str3 = property.Name;
                        str5 = property.PropertyType.Name;
                        str6 = property.PropertyType.ToString();
                        dataType = description.DataType;
                        count = description.Size;
                        if ((index + count) > bytes.Length)
                        {
                            count = bytes.Length - index;
                        }
                        str4 = Encoding.ASCII.GetString(bytes, index, count);
                        fieldmessage = string.Format("{0}-{1}-{2}:{3}", str3, str5, dataType, str4);
                        switch (dataType)
                        {
                            case "Mod-96":
                                str4 = ConvertMod96ToInt(str4).ToString();
                                property.SetValue(obj2, Convert.ToDecimal(str4), null);
                                break;

                            case "Numeric String":
                                if (str4.Trim() == "")
                                {
                                    str4 = "0";
                                }
                                property.SetValue(obj2, Convert.ToDecimal(str4), null);
                                break;

                            case "Alpha String":
                            case "Alphanumeric String":
                                if (count == 1)
                                {
                                    property.SetValue(obj2, Convert.ToChar(str4), null);
                                }
                                else
                                {
                                    property.SetValue(obj2, str4, null);
                                }
                                break;
                        }
                        index += count;
                        fieldmessage = string.Empty;
                    }
                }
                catch (Exception exception)
                {
                    GatewayLogManager.Error("Error while converting raw format to message, MessageType=" + messageType + ",Detail:" + exception.Message + "field:" + fieldmessage);
                    return null;
                }
            }
            return obj2;
        }

        public static string ConvertToMod96(int value)
        {
            List<char> list = new List<char>();
            int num = value / 0x60;
            int num2 = value % 0x60;
            if (num < 0x60)
            {
                if (num > 0)
                {
                    return (Convert.ToChar((int)(num + 0x20)).ToString() + Convert.ToChar((int)(num2 + 0x20)).ToString());
                }
                return Convert.ToChar((int)(num2 + 0x20)).ToString();
            }
            return (ConvertToMod96(num) + Convert.ToChar((int)(num2 + 0x20)).ToString());
        }

        public static byte[] GetBytes(Message message)
        {
            byte[] buffer = new byte[message.BodyStream.Length];
            message.BodyStream.Seek(0L, SeekOrigin.Begin);
            message.BodyStream.Read(buffer, 0, buffer.Length);
            char[] chars = Encoding.Unicode.GetChars(buffer);
            return Encoding.ASCII.GetBytes(chars);
        }

        public static string GetClassName(string messageType)
        {
            if (mappingList == null)
            {
                LoadMessageTypeMappingFromFile("Mapping.txt");
            }
            if (mappingList != null)
            {
                for (int i = 0; i < mappingList.Count; i++)
                {
                    if (mappingList[i].MessageType.Equals(messageType, StringComparison.OrdinalIgnoreCase))
                    {
                        return mappingList[i].ClassName;
                    }
                }
            }
            return null;
        }

        public static MessageFieldDescription GetMessageFieldDescription(string messageType, string fieldName)
        {
            if (messageFieldDescriptionList == null)
            {
                LoadMessageFieldDescriptionFromFile("MessageFieldDescription.txt");
            }
            if (messageFieldDescriptionList != null)
            {
                for (int i = 0; i < messageFieldDescriptionList.Count; i++)
                {
                    if (messageFieldDescriptionList[i].FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (messageFieldDescriptionList[i].MessageType.Equals("ALL", StringComparison.OrdinalIgnoreCase))
                        {
                            return messageFieldDescriptionList[i];
                        }
                        if (messageFieldDescriptionList[i].MessageType.Equals(messageType, StringComparison.OrdinalIgnoreCase))
                        {
                            return messageFieldDescriptionList[i];
                        }
                    }
                }
            }
            return null;
        }

        public static List<MessageFieldDescription> GetMessageFields(string messageType)
        {
            List<MessageFieldDescription> list = new List<MessageFieldDescription>();
            if (messageFieldDescriptionList == null)
            {
                LoadMessageFieldDescriptionFromFile("MessageFieldDescription.txt");
            }
            if (messageFieldDescriptionList != null)
            {
                for (int i = 0; i < messageFieldDescriptionList.Count; i++)
                {
                    if (messageFieldDescriptionList[i].MessageType.Equals(messageType, StringComparison.OrdinalIgnoreCase))
                    {
                        list.Add(messageFieldDescriptionList[i]);
                    }
                }
            }
            IOrderedEnumerable<MessageFieldDescription> enumerable = Enumerable.OrderBy<MessageFieldDescription, short>(list, delegate(MessageFieldDescription item)
            {
                return item.Index;
            });
            List<MessageFieldDescription> list2 = new List<MessageFieldDescription>();
            foreach (MessageFieldDescription description in enumerable)
            {
                list2.Add(description);
            }
            return list2;
        }

        private static string GetMessageType(string className)
        {
            if (mappingList == null)
            {
                LoadMessageTypeMappingFromFile("Mapping.txt");
            }
            if (mappingList != null)
            {
                for (int i = 0; i < mappingList.Count; i++)
                {
                    if (mappingList[i].ClassName.Equals(className, StringComparison.OrdinalIgnoreCase))
                    {
                        return mappingList[i].MessageType;
                    }
                }
            }
            return null;
        }

        public static void LoadMessageFieldDescriptionFromFile(string textFile)
        {
            messageFieldDescriptionList = new List<MessageFieldDescription>();
            StreamReader reader = File.OpenText(textFile);
            string str = null;
            string str2 = null;
            string str3 = null;
            string str4 = null;
            short num = 0;
            char[] separator = new char[] { '#' };
            char[] chArray2 = new char[] { ':' };
            MessageFieldDescription item = null;
            string[] strArray = null;
            string[] strArray2 = null;
            while ((str = reader.ReadLine()) != null)
            {
                strArray = str.Split(separator);
                str2 = strArray[0];
                for (int i = 1; i < strArray.Length; i++)
                {
                    strArray2 = strArray[i].Split(chArray2);
                    str3 = strArray2[0];
                    str4 = strArray2[1];
                    num = Convert.ToInt16(strArray2[2]);
                    item = new MessageFieldDescription();
                    item.MessageType = str2;
                    item.FieldName = str3;
                    item.DataType = str4;
                    item.Size = num;
                    item.Index = (short)i;
                    messageFieldDescriptionList.Add(item);
                }
            }
            reader.Close();
        }

        public static void LoadMessageTypeMappingFromFile(string mappingFile)
        {
            EventLog.WriteEntry("BrokerageGateway", "Mapping File:" + mappingFile);
            mappingList = new List<MessageTypeMapping>();
            StreamReader reader = File.OpenText(mappingFile);
            string str = null;
            MessageTypeMapping item = null;
            char[] separator = new char[] { '#' };
            string[] strArray = null;
            while ((str = reader.ReadLine()) != null)
            {
                strArray = str.Split(separator);
                item = new MessageTypeMapping();
                item.MessageType = strArray[0];
                item.ClassName = strArray[1];
                mappingList.Add(item);
            }
            reader.Close();
        }
    }
}

