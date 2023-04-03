using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SMS.Common
{
    public class Helpers
    {

        public static dynamic GetExpandoFromXml(String file, XElement node = null)
        {
            if (String.IsNullOrWhiteSpace(file) && node == null) return null;

            // If a file is not empty then load the xml and overwrite node with the
            // root element of the loaded document
            node = !String.IsNullOrWhiteSpace(file) ? XDocument.Parse(file).Root : node;

            IDictionary<String, dynamic> result = new ExpandoObject();

            // implement fix as suggested by [ndinges]
            var pluralizationService =
                PluralizationService.CreateService(CultureInfo.CreateSpecificCulture("en-us"));

            // use parallel as we dont really care of the order of our properties
            node.Elements().AsParallel().ForAll(gn =>
            {
                // Determine if node is a collection container
                var isCollection = gn.HasElements &&
                    (
                    // if multiple child elements and all the node names are the same
                        gn.Elements().Count() > 1 &&
                        gn.Elements().All(
                            e => e.Name.LocalName.ToLower() == gn.Elements().First().Name.LocalName) ||

                        // if there's only one child element then determine using the PluralizationService if
                    // the pluralization of the child elements name matches the parent node. 
                        gn.Name.LocalName.ToLower() == pluralizationService.Pluralize(
                            gn.Elements().First().Name.LocalName).ToLower()
                    );

                // If the current node is a container node then we want to skip adding
                // the container node itself, but instead we load the children elements
                // of the current node. If the current node has child elements then load
                // those child elements recursively
                var items = isCollection ? gn.Elements().ToList() : new List<XElement>() { gn };

                var values = new List<dynamic>();

                // use parallel as we dont really care of the order of our properties
                // and it will help processing larger XMLs
                items.AsParallel().ForAll(i => values.Add((i.HasElements) ?
                   GetExpandoFromXml(null, i) : i.Value.Trim()));

                // Add the object name + value or value collection to the dictionary
                result[gn.Name.LocalName] = isCollection ? values : values.FirstOrDefault();
            });
            return result;
        }

        public static T Xml2Obj<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException iox)
                    {
                        throw new Exception(iox.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnedXmlClass;
        }

        public static DateTime StringConvert(string dateTimeString)
        {

            dateTimeString = Regex.Replace(dateTimeString, @"[^\u0000-\u007F]", string.Empty);

            string inputFormat = "dd/MM/yyyy hh:mm:ss";
            string outputFormat = "yyyy-MM-dd HH:mm:ss";
            var dateTime = DateTime.ParseExact(dateTimeString, inputFormat, CultureInfo.InvariantCulture);
            //  string output = dateTime.ToString(outputFormat);
            return dateTime;

        }

        public static List<string> DesignMessage(string message, string sub = "")
        {
            try
            {
                if (string.IsNullOrEmpty(sub)) sub = ";";
                var listMessage = new List<string>();
                while (message.Length > 160)
                {
                    string temp = message.Substring(0, 160);
                    int startIndex = !temp.Trim().EndsWith(sub) ? temp.LastIndexOf(sub, System.StringComparison.Ordinal) + 1 : temp.Length;
                    listMessage.Add(message.Substring(0, startIndex));
                    message = message.Remove(0, startIndex);
                }
                if (message.Length <= 160)
                {
                    listMessage.Add(message);
                }
                return listMessage;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
    public class KeyGenerator
    {
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string GetResultCode()
        {
            var list = new List<string> { "100", "101", "102" };
            int l = list.Count;
            Random r = new Random();
            int num = r.Next(l);
            return list[num];
        }
    }
}