using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoLogAcao
    {
        internal static LogAcao Obter(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    id");
            sql.AppendLine("  , descricao");
            sql.AppendLine("  , texto");
            sql.AppendLine("  , data_cadastro");
            sql.AppendLine("  , data_ultalt");
            sql.AppendLine("  , status");
            sql.AppendLine("FROM log_acao");
            sql.AppendLine("WHERE 1=1");
            sql.AppendLine("    AND id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", id);

            LogAcao item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    item = new LogAcao()
                    {
                        Id = scom.GetValue<int>("id"),
                        SDescricao = scom.GetValue<string>("descricao"),
                        STexto = scom.GetValue<string>("texto"),
                        DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                        DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                        Status = scom.GetValue<bool>("status")
                    };
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static LogAcao Obter(string _Descricao)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    id");
            sql.AppendLine("  , descricao");
            sql.AppendLine("  , texto");
            sql.AppendLine("  , data_cadastro");
            sql.AppendLine("  , data_ultalt");
            sql.AppendLine("  , status");
            sql.AppendLine("FROM log_acao");
            sql.AppendLine("WHERE 1=1");
            sql.AppendLine("    AND descricao = @descricao;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", _Descricao);

            LogAcao item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    item = new LogAcao()
                    {
                        Id = scom.GetValue<int>("id"),
                        SDescricao = scom.GetValue<string>("descricao"),
                        STexto = scom.GetValue<string>("texto"),
                        DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                        DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                        Status = scom.GetValue<bool>("status")
                    };
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static List<LogAcao> Listar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    id");
            sql.AppendLine("  , descricao");
            sql.AppendLine("  , texto");
            sql.AppendLine("  , data_cadastro");
            sql.AppendLine("  , data_ultalt");
            sql.AppendLine("  , status");
            sql.AppendLine("FROM log_acao");
            sql.AppendLine("WHERE status=1");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<LogAcao> Lst = new List<LogAcao>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<LogAcao>();
                    LogAcao item = null;
                    while (scom.Read())
                    {
                        item = new LogAcao()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            STexto = scom.GetValue<string>("texto"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }
    }
}