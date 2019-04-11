using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoProdutoBarras
    {
        internal static List<ProdutoBarras> Pesquisar(long _Produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_produto");
            sql.AppendLine("    , id_unidade");
            sql.AppendLine("    , ean");
            sql.AppendLine("    , quantidade");
            sql.AppendLine("    , compra");
            sql.AppendLine("    , venda");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM produto_barras");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("AND id_produto = @produto");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@produto", _Produto);

            List<ProdutoBarras> Lst = new List<ProdutoBarras>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ProdutoBarras>();
                    ProdutoBarras item = null;
                    while (scom.Read())
                    {
                        item = new ProdutoBarras()
                        {
                            Id = scom.GetValue<long>("id"),
                            IdProduto = scom.GetValue<long>("id_produto"),
                            Undidade = new ProdutoUnidade() { Id = scom.GetValue<int>("id_unidade") },
                            SEAN = scom.GetValue<string>("ean"),
                            DQuantidade = scom.GetValue<decimal>("quantidade"),
                            Compra = scom.GetValue<bool>("compra"),
                            Venda = scom.GetValue<bool>("venda"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static ProdutoBarras Obter(long _Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_produto");
            sql.AppendLine("    , id_unidade");
            sql.AppendLine("    , ean");
            sql.AppendLine("    , quantidade");
            sql.AppendLine("    , compra");
            sql.AppendLine("    , venda");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM produto_barras");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("AND id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Id);

            ProdutoBarras item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ProdutoBarras()
                        {
                            Id = scom.GetValue<long>("id"),
                            IdProduto = scom.GetValue<long>("id_produto"),
                            Undidade = new ProdutoUnidade() { Id = scom.GetValue<int>("id_unidade") },
                            SEAN = scom.GetValue<string>("ean"),
                            DQuantidade = scom.GetValue<decimal>("quantidade"),
                            Compra = scom.GetValue<bool>("compra"),
                            Venda = scom.GetValue<bool>("venda"),
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

        internal static ProdutoBarras Obter(string _EAN)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_produto");
            sql.AppendLine("    , id_unidade");
            sql.AppendLine("    , ean");
            sql.AppendLine("    , quantidade");
            sql.AppendLine("    , compra");
            sql.AppendLine("    , venda");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM produto_barras");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("AND ean = @ean");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@ean", _EAN);

            ProdutoBarras item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ProdutoBarras()
                        {
                            Id = scom.GetValue<long>("id"),
                            IdProduto = scom.GetValue<long>("id_produto"),
                            Undidade = new ProdutoUnidade() { Id = scom.GetValue<int>("id_unidade") },
                            SEAN = scom.GetValue<string>("ean"),
                            DQuantidade = scom.GetValue<decimal>("quantidade"),
                            Compra = scom.GetValue<bool>("compra"),
                            Venda = scom.GetValue<bool>("venda"),
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
    }
}
