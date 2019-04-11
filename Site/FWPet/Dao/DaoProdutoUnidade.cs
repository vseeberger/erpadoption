using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoProdutoUnidade
    {
        internal static ProdutoUnidade Obter(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , sigla");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM produto_unidades");
            sql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", id);

            ProdutoUnidade item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ProdutoUnidade()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SSigla = scom.GetValue<string>("sigla"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static List<ProdutoUnidade> Pesquisa()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , sigla");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM produto_unidades");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<ProdutoUnidade> Lst = new List<ProdutoUnidade>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    ProdutoUnidade item = null;
                    Lst = new List<ProdutoUnidade>();
                    while (scom.Read())
                    {
                        item = new ProdutoUnidade()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SSigla = scom.GetValue<string>("sigla"),
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
