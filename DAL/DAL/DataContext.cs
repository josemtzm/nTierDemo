using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JAMM.Data
{
    public class DataContext
    {
        public DataContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        /// <summary>
        /// The connection string to a database
        /// </summary>
        private string ConnectionString;

        /// <summary>
        /// 
        /// </summary>
        private int defaultTimeout;

        public int DefaultTimeout
        {
            get { return defaultTimeout; }
            set { defaultTimeout = value; }
        }

        protected DataTable ExecuteDataTable(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null)
        {
            DataTable DT = new DataTable();
            SqlDataReader Reader = ExecuteReader(storeProcedure, parameters, commandType, prepare, timeout);
            DT.Load(Reader);
            return DT;
        }

        protected void ExecuteNonQuery(string StoreProcedure, IEnumerable<SqlParameter> Parameters = null, CommandType CommandType = CommandType.StoredProcedure, bool Prepare = false, int? Timeout = null)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command = Connection.CreateCommand();
            try
            {
                Command.CommandType = CommandType;
                Command.CommandText = StoreProcedure;
                if (Timeout != null)
                {
                    Command.CommandTimeout = (int)Timeout;
                }

                if (Parameters != null)
                    foreach (SqlParameter param in Parameters)
                    {
                        Command.Parameters.Add(param);
                    }


                Connection.Open();
                Command.Prepare();
                Command.ExecuteNonQuery();
            }
            catch
            {
                // Log
            }
            finally
            {
                Connection.Dispose();
                Connection.Close();
            }
        }
        protected SqlDataReader ExecuteReader(string StoreProcedure, IEnumerable<SqlParameter> Parameters = null, CommandType CommandType = CommandType.StoredProcedure, bool Prepare = false, int? Timeout = null)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            SqlCommand Command = new SqlCommand();
            SqlDataReader DataReader = null;
            try
            {
                Command.CommandText = StoreProcedure;
                Command.CommandType = CommandType;
                if (Timeout != null)
                {
                    Command.CommandTimeout = (int)Timeout;
                }
                if (Parameters != null)
                    foreach (SqlParameter param in Parameters)
                    {
                        Command.Parameters.Add(param);
                    }

                Command.Connection = Connection;

                Connection.Open();
                Command.Prepare();
                DataReader = Command.ExecuteReader(CommandBehavior.CloseConnection);
                return DataReader;
            }
            catch
            {
                Connection.Dispose();
                Connection.Close();
                return null;
            }
        }

    }
}