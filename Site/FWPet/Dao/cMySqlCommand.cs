using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Dao
{
    public class cMySqlCommand
    {
        private MySqlCommand sqlCommand;
        private MySqlDataReader sqlReader;
        private bool UsaTransaction = false;

        public String CommandText
        {
            get { return sqlCommand != null ? sqlCommand.CommandText : null; }
            set { if (sqlCommand != null) { sqlCommand.CommandText = value; } }
        }
        public cMySqlCommand(MySqlCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
            this.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }
        public cMySqlCommand(MySqlCommand sqlCommand, System.Data.CommandType scom)
        {
            this.sqlCommand = sqlCommand;
            this.sqlCommand.CommandType = scom;
        }

        /// <summary>
        /// </summary>
        /// <param name="_Sql"></param>
        /// <param name="scom"></param>
        /// <param name="beginTran">Funciona apenas para EXECUTE NON QUERY</param>
        public cMySqlCommand(String _Sql, System.Data.CommandType scom, bool beginTran = false)
        {
            UsaTransaction = beginTran;
            //this.sqlCommand = new MySqlCommand(_Sql, Conexao.obter());
            //this.sqlCommand.CommandType = scom;
            if (!beginTran)
            {
                this.sqlCommand = new MySqlCommand(_Sql, Conexao.obter());
                this.sqlCommand.CommandType = scom;
            }
            else
            {
                MySqlConnection con = Conexao.obter();
                con.Open();
                MySqlTransaction trans;
                trans = con.BeginTransaction();

                this.sqlCommand = new MySqlCommand(_Sql, con);
                this.sqlCommand.CommandType = scom;

            }
        }

        /// <summary>
        /// </summary>
        /// <param name="_Sql"></param>
        /// <param name="scom"></param>
        /// <param name="beginTran">Funciona apenas para EXECUTE NON QUERY</param>
        public cMySqlCommand(StringBuilder _Sql, System.Data.CommandType scom, bool beginTran = false)
        {
            UsaTransaction = beginTran;
            //this.sqlCommand = new MySqlCommand(_Sql, Conexao.obter());
            //this.sqlCommand.CommandType = scom;
            if (!beginTran)
            {
                this.sqlCommand = new MySqlCommand(_Sql.ToString(), Conexao.obter());
                this.sqlCommand.CommandType = scom;
            }
            else
            {
                MySqlConnection con = Conexao.obter();
                con.Open();
                MySqlTransaction trans;
                trans = con.BeginTransaction();

                this.sqlCommand = new MySqlCommand(_Sql.ToString(), con);
                this.sqlCommand.CommandType = scom;

            }
        }

        public void AddWithValue(string paramenterName, object value)
        {
            if (value != null)
            {
                //adiciona tipos primitivos
                if (!(value is DateTime ||
                    value is char ||
                    value is bool ||
                    value is double || value is float || value is decimal ||
                    value is int || value is Int16 || value is Int32 || value is Int64 ||
                    value is string || value is String ||
                    value is Guid ||
                    value is Nullable ||
                    value is byte[]) ||
                    value is Type)
                {
                    System.Reflection.PropertyInfo p = value.GetType().GetProperty("Id");
                    if (p != null && p.CanRead)
                        value = p.GetValue(value, null);
                    else
                        throw new Exception("Essa Classe " + value.GetType().FullName + " não é premitida no cMySqlCommand altere no código para pode ser Permitida");
                }

                if (!sqlCommand.Parameters.Contains(paramenterName))
                {
                    MySqlParameter p = new MySqlParameter(paramenterName, value);
                    sqlCommand.Parameters.Add(p);
                }
                else
                {
                    sqlCommand.Parameters[paramenterName].Value = value;
                }
            }
            else
            {
                if (!sqlCommand.Parameters.Contains(paramenterName))
                {
                    MySqlParameter p = new MySqlParameter(paramenterName, DBNull.Value);
                    sqlCommand.Parameters.Add(p);
                }
                else
                {
                    sqlCommand.Parameters[paramenterName].Value = DBNull.Value;
                }
            }
        }

        public void removeParameter(string paramenterName)
        {
            if (sqlCommand.Parameters.Contains(paramenterName))
                sqlCommand.Parameters.RemoveAt(paramenterName);
        }

        public void ExecuteNonQuery()
        {
            connectar();
            sqlCommand.ExecuteNonQuery();
        }

        public void ExecuteReader()
        {
            connectar();
            sqlReader = sqlCommand.ExecuteReader();
        }

        public bool Read()
        {
            return sqlReader != null && !sqlReader.IsClosed && sqlReader.Read();
        }

        public bool NextResult()
        {
            return sqlReader != null && !sqlReader.IsClosed && sqlReader.NextResult();
        }

        public bool HasRows
        {
            get
            {
                return sqlReader != null && !sqlReader.IsClosed && sqlReader.HasRows;
            }
        }

        public T ExecuteScalar<T>()
        {
            connectar();
            object value = sqlCommand.ExecuteScalar();
            Close();
            return value is DBNull ? default(T) : (T)value;
        }

        public T GetValue<T>(int index)
        {
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                object value = sqlReader[index];
                if (value == DBNull.Value)
                    return default(T);
                if (value is T)
                {
                    return (T)value;
                }
                else
                {
                    throw new Exception("Verifique o tipo de dado " + typeof(T).FullName);
                }
            }
            return default(T);
        }

        public T GetValue<T>(String coluna)
        {
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                object value = sqlReader[coluna];
                if (value == DBNull.Value)
                    return default(T);
                if (value is T)
                {
                    return (T)value;
                }
                else if ((typeof(T).Equals(typeof(char)) || typeof(T).Equals(typeof(char?))) && value is String)
                {
                    return (T)((value as String)[0] as object);
                }
                else if (typeof(T).Equals(typeof(float?)) && value is double)
                {
                    value = Convert.ToSingle(value);
                    return (T)value;
                }
                else if (typeof(T).Equals(typeof(Guid)) && value is Guid)
                {
                    value = Guid.Parse(value.ToString());
                    return (T)value;
                }
                else if ((typeof(T).Equals(typeof(bool?)) || typeof(T).Equals(typeof(bool))))
                {
                    return (T)((value.ToString() == "1" || value.ToString().ToLower() == "true" || value.ToString().ToLower() == "sim") as object);
                }
                else if ((typeof(T).Equals(typeof(byte[])) || typeof(T).Equals(typeof(byte[]))))
                {
                    return (T)value;
                }
                else if ((typeof(T).Equals(typeof(Type))))
                {
                    return (T)value;
                }
                else
                {
                    throw new Exception("Verifique o tipo de dado " + typeof(T).FullName);
                }
            }
            return default(T);
        }

        public void Commit()
        {
            if (sqlCommand.Transaction != null)
            {
                sqlCommand.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (sqlCommand.Transaction != null)
            {
                sqlCommand.Transaction.Rollback();
            }
        }

        public void Close()
        {
            MySqlConnection sqlConexao = sqlCommand.Connection;
            sqlCommand.Dispose();

            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
                sqlReader.Dispose();
            }

            //if (sqlConexao != null && sqlConexao.State != System.Data.ConnectionState.Closed)
            //{
            //    sqlConexao.Close();
            //    sqlConexao.Dispose();
            //}
            sqlConexao.Close();
            sqlConexao.Dispose();
            GC.Collect();
        }

        private void connectar()
        {
            MySqlConnection sqlConexao = sqlCommand.Connection;
            if (sqlConexao == null || String.IsNullOrEmpty(sqlConexao.ConnectionString))
            {
                sqlCommand.Connection = sqlConexao = Conexao.obter();
            }

            if (sqlConexao.State == System.Data.ConnectionState.Closed)
            {
                sqlConexao.Open();
                if (this.UsaTransaction) sqlConexao.BeginTransaction();
            }
        }

        internal void CloseReader()
        {
            if (sqlReader != null && !sqlReader.IsClosed)
            {
                sqlReader.Close();
                sqlReader.Dispose();
            }
            sqlReader = null;
        }

        /// <summary>
        /// Limpa os parametros do comando
        /// </summary>
        public void Clear()
        {
            if (sqlCommand != null)
                sqlCommand.Parameters.Clear();
        }
    }
}
