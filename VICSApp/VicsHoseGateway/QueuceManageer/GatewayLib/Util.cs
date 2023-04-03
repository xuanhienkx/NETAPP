namespace GatewayLib
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Messaging;
    using System.Reflection;
    using System.Text;

    public class Util
    {
        private static List<FieldConversion> conversionTable = null;

        public static object ConvertToBrokerValue(string messageType, string fieldName, object hoseValue)
        {
            if (isNumeric(hoseValue.ToString(), NumberStyles.Number))
            {
                if ((conversionTable == null) || (conversionTable.Count == 0))
                {
                    LoadConversionTable("UnitConversion.txt");
                }
                foreach (FieldConversion conversion in conversionTable)
                {
                    if ((conversion.MessageType == messageType) && (conversion.FieldName == fieldName))
                    {
                        char @operator = conversion.Operator;
                        int operand = conversion.Operand;
                        if (@operator == '*')
                        {
                            return (Convert.ToDecimal(hoseValue) / operand);
                        }
                        return (Convert.ToDecimal(hoseValue) * operand);
                    }
                }
            }
            return null;
        }

        public static object ConvertToHOSEValue(string messageType, string fieldName, object brokerValue)
        {
            if (isNumeric(brokerValue.ToString(), NumberStyles.Number))
            {
                if ((conversionTable == null) || (conversionTable.Count == 0))
                {
                    LoadConversionTable("UnitConversion.txt");
                }
                foreach (FieldConversion conversion in conversionTable)
                {
                    if ((conversion.MessageType == messageType) && (conversion.FieldName == fieldName))
                    {
                        char @operator = conversion.Operator;
                        int operand = conversion.Operand;
                        if (@operator == '*')
                        {
                            return (Convert.ToDecimal(brokerValue) * operand);
                        }
                        return (Convert.ToDecimal(brokerValue) / operand);
                    }
                }
            }
            return null;
        }

        public static Type GetMessageClassType(string className)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName name = executingAssembly.GetName();
            return executingAssembly.GetType(name.Name + "." + className);
        }

        public static object GetMessageInstance(string messageType, List<MessageField> msgFields)
        {
            string className = MessageConverter.GetClassName(messageType);
            if ((className != null) && !className.Equals(string.Empty))
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyName name = executingAssembly.GetName();
                Type type = executingAssembly.GetType(name.Name + "." + className);
                object obj2 = Activator.CreateInstance(type);
                PropertyInfo[] properties = type.GetProperties();
                List<string> list = new List<string>();
                int index = 0;
                for (index = 0; index < properties.Length; index++)
                {
                    foreach (MessageField field in msgFields)
                    {
                        if (field.FieldName == properties[index].Name)
                        {
                            properties[index].SetValue(obj2, field.FieldValue, null);
                        }
                    }
                }
                return obj2;
            }
            return null;
        }

        public static string GetMessageType(Message message)
        {
            return GetMessageType(MessageConverter.GetBytes(message));
        }

        public static string GetMessageType(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes, 0, 2);
        }

        public static string GetMessageType(object standardMessage)
        {
            PropertyInfo property = standardMessage.GetType().GetProperty("MESSAGE_TYPE");
            if (property != null)
            {
                return property.GetValue(standardMessage, null).ToString();
            }
            return null;
        }

        public static string[] GetProperties(string messageType)
        {
            string className = MessageConverter.GetClassName(messageType);
            if ((className != null) && !className.Equals(string.Empty))
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                AssemblyName name = executingAssembly.GetName();
                PropertyInfo[] properties = executingAssembly.GetType(name.Name + "." + className).GetProperties();
                List<string> list = new List<string>();
                int index = 0;
                for (index = 0; index < properties.Length; index++)
                {
                    if (MessageConverter.GetMessageFieldDescription(messageType, properties[index].Name) != null)
                    {
                        list.Add(properties[index].Name);
                    }
                }
                return list.ToArray();
            }
            return null;
        }

        public static bool isNumeric(string val, NumberStyles NumberStyle)
        {
            double num;
            return double.TryParse(val, NumberStyle, CultureInfo.CurrentCulture, out num);
        }

        private static void LoadConversionTable(string conversionFile)
        {
            conversionTable = new List<FieldConversion>();
            FieldConversion item = null;
            StreamReader reader = File.OpenText(conversionFile);
            char[] separator = new char[] { ':' };
            string str = null;
            while ((str = reader.ReadLine()) != null)
            {
                if (str.IndexOf('#') < 0)
                {
                    string[] strArray = str.Split(separator);
                    string str2 = strArray[0];
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        int index = strArray[i].IndexOf('*');
                        char ch = '*';
                        if (index < 0)
                        {
                            index = strArray[i].IndexOf('/');
                            ch = '/';
                        }
                        item = new FieldConversion();
                        item.MessageType = str2;
                        item.FieldName = strArray[i].Substring(0, index);
                        item.Operator = ch;
                        item.Operand = Convert.ToInt32(strArray[i].Substring(index + 1));
                        conversionTable.Add(item);
                    }
                }
            }
            reader.Close();
        }

        public static bool NeedToConvert(string messageType, string fieldName)
        {
            if ((conversionTable == null) || (conversionTable.Count == 0))
            {
                LoadConversionTable("UnitConversion.txt");
            }
            foreach (FieldConversion conversion in conversionTable)
            {
                if ((conversion.MessageType == messageType) && (conversion.FieldName == fieldName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

