namespace GatewayLib.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    public class DataFiller<T>
    {
        public List<T> FromDataTableToList(DataTable dataTable)
        {
            List<T> list = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();
            foreach (DataRow row in dataTable.Rows)
            {
                object obj2 = Activator.CreateInstance(type);
                foreach (PropertyInfo info in properties)
                {
                    try
                    {
                        object obj3 = row[info.Name];
                        if (obj3 != DBNull.Value)
                        {
                            info.SetValue(obj2, obj3, null);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(info.Name + ": " + exception.ToString());
                        return null;
                    }
                }
                T item = (T) obj2;
                list.Add(item);
            }
            return list;
        }
    }
}

