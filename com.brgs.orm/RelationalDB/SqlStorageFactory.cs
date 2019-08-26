using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace com.brgs.orm.RelationalDB
{
    public class SQLStorageFactory : IStorageFactory
    {
        private readonly IDbFactory _connection;

        public SQLStorageFactory(IDbFactory factory)
        {
            _connection = factory;
        }
        public async Task<T> GetAsync<T>(string val){ throw new NotImplementedException("coming soon");}

        public T Get<T>()
        {
            var outVal = (T)Activator.CreateInstance(typeof(T));
            // var properties = outVal.GetType().GetProperties();
            // var assembly = typeof(T).Assembly;
            // var types = assembly.GetTypes();
            // var methods = from type in assembly.GetTypes()
            //                 where type.IsSealed && !type.IsGenericType
            //                                     && !type.IsNested
            //                 from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            //                 where method.IsDefined(typeof(ExtensionAttribute), false)
            //                 where method.GetParameters()[0].ParameterType == typeof(T)
            //                 select method;
            using (var conn = _connection.CreateConnection())
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var f = 0; f < reader.FieldCount; f++)
                        {
                            var resultName = reader.GetName(f);
                            //This makes the assumption that the column name is 1:1 match with the 
                            // var property = properties.FirstOrDefault(p => p.Name.ToLower().Contains(resultName.ToLower()));
                            // var resultValue = reader.GetValue(f);
                            // if (property != null)
                            // {
                            //     outVal.GetType().GetProperty(property.Name)
                            //             .SetValue(outVal, resultValue.ToString(), null);
                            // }
                        }
                    }
                }
            }
            return outVal;
        }

        public Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }        
        public Task<int> PostAsync<T>(T record) {throw new NotImplementedException("coming soon");}
        public T Put<T>(T record)
        {
            throw new NotImplementedException("coming soon");
        }
        public Task DeleteAsync<T>(T record)
        {
            throw new NotImplementedException("coming soon");
        }


    }
}
