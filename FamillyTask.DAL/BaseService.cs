using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FamillyTask.DAL
{
    public abstract class BaseService<T, TKey>
    {
        protected IDbConnection connection;

        public BaseService( string ConnectionString)
        {
            connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        }

        public abstract IEnumerable<T> Get();
        public abstract T GetOne(TKey id);
        public abstract bool Add(T id);
        public abstract bool Update(T obj);
        public abstract bool Delete(T id);
    }
}
