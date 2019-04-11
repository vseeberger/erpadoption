using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoFormaPagamentoRecebimento
    {
        internal static List<FormaPagamentoRecebimento> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM formas_pagamento_recebimento");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("ORDER BY descricao");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<FormaPagamentoRecebimento> Lst = new List<FormaPagamentoRecebimento>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<FormaPagamentoRecebimento>();
                    FormaPagamentoRecebimento item = null;
                    while (scom.Read())
                    {
                        item = new FormaPagamentoRecebimento()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static FormaPagamentoRecebimento Obter(int _Forma)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM formas_pagamento_recebimento");
            sql.AppendLine("WHERE status = 1");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            FormaPagamentoRecebimento item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new FormaPagamentoRecebimento()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}
