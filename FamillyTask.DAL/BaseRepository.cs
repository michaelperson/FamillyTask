using FamillyTask.DAL.Extensions;
using FamillyTask.DAL.Helpers; 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace FamillyTask.DAL
{
    public abstract class BaseRepository<T,TKey>
        where T : class, new()
    {
        readonly IDbConnection connection;

        public BaseRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        protected IEnumerable<T> ExecuteReader(string CommandText, CommandType commandType = CommandType.Text)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = CommandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 90;
            if (connection.State == ConnectionState.Closed) connection.Open();
            using (IDataReader odr = cmd.ExecuteReader())
            {
                while (odr.Read())
                {
                    yield return odr.ConvertTo<T>();
                }
            }
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        protected IEnumerable<T> ExecuteReaderWithParameters(string CommandText, CommandType commandType, T toAdd)
        {
            IDbCommand cmd = connection.CreateCommand();
            cmd.CommandText = CommandText;
            cmd.CommandType = commandType;
            AddParameters(cmd, toAdd, commandType == CommandType.StoredProcedure);
            connection.Open();
            using (IDataReader odr = cmd.ExecuteReader())
            {
                while (odr.Read())
                {
                    yield return odr.ConvertTo<T>();
                }
            }
            connection.Close();
        }

        protected void ExecuteNonQuery(string query)
        {
            try
            {
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;



                connection.Open();

                int rep = cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {               
                if (connection.State != ConnectionState.Closed) connection.Close();

            }
        }

        protected bool InsertOrUpdateData(string CommandText, T toAdd, CommandType commandType = CommandType.Text)
        {

            try
            {
                IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = CommandText;
                cmd.CommandType = commandType;

                AddParameters(cmd, toAdd);


                connection.Open();

                int rep = cmd.ExecuteNonQuery();

                connection.Close();
                return true;
            }
            catch (Exception ex)
            {

                
                if (connection.State != ConnectionState.Closed) connection.Close();
                return false;
            }
        }

        private void AddParameters(IDbCommand cmd, T toAdd, bool IsStoredProc = false)
        {
            IEnumerable<PropertyInfo> infos = null;
            if (!IsStoredProc)
            {
                infos = typeof(T).GetProperties().Where(m => m.GetCustomAttribute(typeof(DatabaseGeneratedAttribute)) is null);
            }
            else
            {
                infos = typeof(T).GetProperties().Where(m => m.GetCustomAttribute(typeof(FilterSpAttribute)) != null);
            }
            foreach (PropertyInfo item in infos)
            {
                IDataParameter data = cmd.CreateParameter();
                data.ParameterName = item.Name;
                data.DbType = TypeConvertor.ToDbType(item.PropertyType);
                data.Value = item.GetValue(toAdd) is null ? DBNull.Value : item.GetValue(toAdd);

                cmd.Parameters.Add(data);

            }
        }

        public abstract IEnumerable<T> Get();
        public abstract T GetOne (TKey id);
        public abstract bool Add(T obj);
        public abstract bool Update(T obj);
        public abstract bool Delete(T id);

    }
}
