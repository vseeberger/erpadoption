using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPedidoCompraItens
    {
        /*
        sql.AppendLine("    lista_compras_produtos");
        sql.AppendLine("    , id");
        sql.AppendLine("    , id_lista");
        sql.AppendLine("    , id_produto");
        sql.AppendLine("    , quantidade");
        sql.AppendLine("    , id_usuario_pediu");
        sql.AppendLine("    , data_cadastro");
        sql.AppendLine("    , data_ultalt");
        sql.AppendLine("    , status);"); 
        */
        internal static void Inserir(PedidoCompraItens item)
        {
            if (item.IdPedido <= 0)
            {
                PedidoCompra _Compra = PedidoCompra.Novo(item.UsuarioSolicitante != null ? item.UsuarioSolicitante.Id : 0);
                item.IdPedido = _Compra.Id;
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO lista_compras_produtos (");
            sql.AppendLine("      id_lista");
            sql.AppendLine("    , id_produto");
            sql.AppendLine("    , quantidade");
            sql.AppendLine("    , id_usuario_pediu");
            sql.AppendLine(")VALUES(");
            sql.AppendLine("      @id_lista");
            sql.AppendLine("    , @id_produto");
            sql.AppendLine("    , @quantidade");
            sql.AppendLine("    , @id_usuario_pediu");
            sql.AppendLine(");SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_lista", item.IdPedido);
            scom.AddWithValue("@id_produto", item.Produto.Id);
            scom.AddWithValue("@quantidade", item.IQuantidade);
            scom.AddWithValue("@id_usuario_pediu", item.UsuarioSolicitante.Id);
            try
            {
                scom.ExecuteReader();
                if(scom.HasRows && scom.Read())
                {
                    long l;
                    item.Id = long.TryParse(scom.GetValue<object>(0).ToString(), out l) ? l : 0;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        /// <summary>
        /// Utilizado apenas para exibir na tela inicial e impressão da lista de compras
        /// </summary>
        /// <param name="_Id"></param>
        /// <returns></returns>
        internal static List<PedidoCompraItens> ItensDoPedido(long _Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      lista_compras_produtos.id_lista");
            sql.AppendLine("    , lista_compras_produtos.id_produto");
            sql.AppendLine("    , SUM(lista_compras_produtos.quantidade) AS quantidade");
            sql.AppendLine("    , lista_compras_produtos.status");

            sql.AppendLine("   , produto.id AS ProdutoID");
            sql.AppendLine("   , produto.tipo_produto AS ProdutoTIPO");
            sql.AppendLine("   , produto.referencia AS ProdutoREF");
            sql.AppendLine("   , produto.nome AS ProdutoNOME");
            sql.AppendLine("   , produto.nome_comercial AS ProdutoNOMECOMERCIAL");
            sql.AppendLine("   , produto.eh_medicamento AS ProdutoEHMEDICAMENTO");
            sql.AppendLine("   , produto.eh_vacina AS ProdutoEHVACINA");
            sql.AppendLine("   , produto.data_cadastro AS ProdutoCadastro");
            sql.AppendLine("   , produto.data_ultalt AS ProdutoUltAlt");
            sql.AppendLine("   , produto.status AS ProdutoStatus");
            sql.AppendLine("   , produto.foto_capa AS ProdutoCAPA");

            sql.AppendLine("FROM lista_compras_produtos");
            sql.AppendLine("INNER JOIN produto ON produto.id = lista_compras_produtos.id_produto");
            sql.AppendLine("WHERE lista_compras_produtos.id_lista = @id_lista");
            sql.AppendLine("    AND lista_compras_produtos.status = 1");
            sql.AppendLine("GROUP BY ");
            sql.AppendLine("      lista_compras_produtos.id_lista");
            sql.AppendLine("    , lista_compras_produtos.id_produto");
            sql.AppendLine("    , lista_compras_produtos.status");
            sql.AppendLine("   , produto.id");
            sql.AppendLine("   , produto.tipo_produto");
            sql.AppendLine("   , produto.referencia");
            sql.AppendLine("   , produto.nome");
            sql.AppendLine("   , produto.nome_comercial");
            sql.AppendLine("   , produto.eh_medicamento");
            sql.AppendLine("   , produto.eh_vacina");
            sql.AppendLine("   , produto.data_cadastro");
            sql.AppendLine("   , produto.data_ultalt");
            sql.AppendLine("   , produto.status");
            sql.AppendLine("   , produto.foto_capa");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_lista", _Id);

            List<PedidoCompraItens> Lst = new List<PedidoCompraItens>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<PedidoCompraItens>();
                    PedidoCompraItens item = null;
                    while (scom.Read())
                    {
                        item = new PedidoCompraItens()
                        {
                            IdPedido = scom.GetValue<long>("id_lista"),
                            IQuantidade = int.Parse(scom.GetValue<decimal>("quantidade").ToString("0")),
                            Status = scom.GetValue<bool>("status"),
                        };

                        item.Produto = new Produto()
                        {
                            Id = scom.GetValue<long>("ProdutoID"),
                            SNome = scom.GetValue<string>("ProdutoNOME"),
                            SNomeComercial = scom.GetValue<string>("ProdutoNOMECOMERCIAL"),
                            SReferencia = scom.GetValue<string>("ProdutoREF"),
                            STipoProduto = scom.GetValue<string>("ProdutoTIPO"),
                            EhMedicamento = scom.GetValue<bool>("ProdutoEHMEDICAMENTO"),
                            EhVacina = scom.GetValue<bool>("ProdutoEHVACINA"),
                            DtmCadastro = scom.GetValue<DateTime>("ProdutoCadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("ProdutoUltAlt"),
                            Status = scom.GetValue<bool>("ProdutoStatus"),
                            SPathFotoCapa = scom.GetValue<string>("ProdutoCAPA")
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
