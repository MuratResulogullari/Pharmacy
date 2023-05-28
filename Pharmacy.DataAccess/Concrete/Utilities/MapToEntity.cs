using System.Data;
using System.Reflection;

namespace Pharmacy.DataAccess.Concrete.Utilities
{
    public static class MapToEntity
    {
        public static List<T> DataReaderMapToList<T>(IDataReader dataReader ,string[] discardProperties)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dataReader.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!discardProperties.Contains(prop.Name) && !object.Equals(dataReader[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dataReader[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        public static List<T> DataReaderMapToListWithCaseMap<T>(IDataReader dataReader)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dataReader.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dataReader[CaseMap.ConvertPascalCaseToSnakeCase(prop.Name)], DBNull.Value))
                    {
                        prop.SetValue(obj, dataReader[CaseMap.ConvertPascalCaseToSnakeCase(prop.Name)], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}