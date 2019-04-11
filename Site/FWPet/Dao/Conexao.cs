using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FWPet.Dao
{
    public class Conexao
    {
        private static String strConexao = String.Format("Database={0};Data Source={1};User Id={2};Password={3};Use Procedure Bodies=true"
                                                , ConfigurationSettings.AppSettings["DBBanco"]
                                                , ConfigurationSettings.AppSettings["DBServer"]
                                                , ConfigurationSettings.AppSettings["DBLogin"]
                                                , (Convert.ToBoolean(ConfigurationSettings.AppSettings["DBCrypt"].ToString()) ? Crypt.Decriptografa(ConfigurationSettings.AppSettings["DBSenha"], ConfigurationSettings.AppSettings["DBLogin"]) : ConfigurationSettings.AppSettings["DBSenha"]));
        //, Crypt.Decriptografa(ConfigurationManager.GetSection("DBSenha").ToString(), ConfigurationManager.GetSection("MySQLDbUser").ToString()));

        private Conexao()
        {
        }

        public static MySqlConnection obter() { return new MySqlConnection(strConexao); }

        public static void limpaConexao(MySqlCommand myComm)
        {
            myComm.Dispose();
            MySqlConnection conexao = myComm.Connection;
            conexao.Close();
            conexao.Dispose();
            MySqlConnection.ClearPool(conexao);
            MySqlConnection.ClearAllPools();
        }

        internal static void excluir(Guid id, String strProcedure)
        {
            MySqlConnection myCon = Conexao.obter();
            MySqlCommand myComm = new MySqlCommand(strProcedure, myCon);
            myComm.CommandType = System.Data.CommandType.StoredProcedure;

            myComm.Parameters.AddWithValue("pId", id);
            myCon.Open();
            try { myComm.ExecuteNonQuery(); }
            finally { Conexao.limpaConexao(myComm); }
        }

        /// <summary>
        /// Checa qualquer tipo de existencia
        /// basta passar a string de consulta e caso retorne algum resultado significa que existe.
        /// </summary>
        /// <param name="busca">valor em string que deve ser buscado (NA CONSULTA DEVE EXISTIR O PARÂMETRO <b>@PARAMETRO</b> para pesquisa)</param>
        /// <param name="sql">string da consulta</param>
        /// <returns>retorna 1 / null</returns>
        internal static int? VerificaExistencia(String busca, String sql)
        {
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@PARAMETRO", busca);
            int? total = null;
            try { scom.ExecuteReader(); if (scom.HasRows) total = 1; }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return total;
        }

        public static System.Data.DataTable ExecutaRetorno(String _Executar)
        {
            System.Data.DataTable dtE = null;
            MySqlDataAdapter daE = null;
            MySqlConnection myCon = Conexao.obter();
            try
            {
                dtE = new System.Data.DataTable();
                myCon.Open();
                daE = new MySqlDataAdapter(_Executar, myCon);
                daE.Fill(dtE);
            }
            catch
            {
                dtE = new System.Data.DataTable();
                dtE.Clear();
            }
            finally
            {
                daE.Dispose();
                myCon.Close();
                myCon.Dispose();
                GC.Collect();
            }
            return dtE;
        }

        public static void Executar(String _Executar)
        {
            MySqlConnection myCon = Conexao.obter();
            MySqlCommand myComm = new MySqlCommand(_Executar, myCon);
            myComm.CommandType = System.Data.CommandType.Text;
            myCon.Open();
            try { myComm.ExecuteNonQuery(); }
            finally { Conexao.limpaConexao(myComm); }
        }

        public static string BuscaGenerica(string vSql, string vCampoRet, bool bReconectar = false)
        {
            cMySqlCommand scom = new cMySqlCommand(vSql, System.Data.CommandType.Text);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                    return scom.GetValue<object>(vCampoRet).ToString().Trim();
                else
                    return "";
            }
            catch { return "ERRO"; }
            finally { scom.Close(); }
        }

        /// <summary>
        /// 1 - INSERIR - INSERIU
        /// || 2 - ALTERAR - ALTEROU
        /// || 3 - EXCLUIR - EXCLUIU
        /// || 4 - ACESSAR - ACESSOU
        /// || 5 - ESPECIAL- PERMISSÃO ESPECIAL
        /// </summary>
        public static void GravarLogFW(string _Texto, Type _TipoObjeto)
        {
            Model.Logs.Salvar(new Model.Logs(_Texto, 0, 0, 0, null, null, _TipoObjeto));
        }

    }
}
