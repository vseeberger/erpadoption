using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoOrigemCustos
    {
        internal static List<OrigemCustos> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , entrada_saida");
            sql.AppendLine("    , id_origem_de_custos_lucro");
            sql.AppendLine("    , classificacao");
            sql.AppendLine("FROM origem_de_custos_lucro");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("ORDER BY descricao");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<OrigemCustos> Lst = new List<OrigemCustos>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<OrigemCustos>();
                    OrigemCustos item = null;
                    while (scom.Read())
                    {
                        item = new OrigemCustos()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            SEntradaSaida = scom.GetValue<string>("entrada_saida"),
                            IdPai = scom.GetValue<int?>("id_origem_de_custos_lucro"),
                            SClassificacao = scom.GetValue<string>("classificacao")
                        };
                        
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static OrigemCustos Obter(int _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , entrada_saida");
            sql.AppendLine("    , id_origem_de_custos_lucro");
            sql.AppendLine("    , classificacao");
            sql.AppendLine("FROM origem_de_custos_lucro");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);
            OrigemCustos item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new OrigemCustos()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            SEntradaSaida = scom.GetValue<string>("entrada_saida"),
                            IdPai = scom.GetValue<int?>("id_origem_de_custos_lucro"),
                            SClassificacao = scom.GetValue<string>("classificacao")
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
