using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPedidoCompra
    {
        /*
         sql.AppendLine("INSERT INTO lista_compras (");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_usuario");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , finalizado");
            sql.AppendLine("    , data_previsao");
            sql.AppendLine("    , data_realizacao_compra");
            sql.AppendLine(")VALUES(");
            sql.AppendLine("      @id");
            sql.AppendLine("    , @id_usuario");
            sql.AppendLine("    , @descricao");
            sql.AppendLine("    , @data_cadastro");
            sql.AppendLine("    , @data_ultalt");
            sql.AppendLine("    , @status");
            sql.AppendLine("    , @finalizado");
            sql.AppendLine("    , @data_previsao");
            sql.AppendLine("    , @data_realizacao_compra)");
             */
        internal static PedidoCompra Novo(long _Usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO lista_compras (");
            sql.AppendLine("      id_usuario");
            sql.AppendLine("    , descricao");
            sql.AppendLine(")VALUES(");
            sql.AppendLine("      @id_usuario");
            sql.AppendLine("    , @descricao);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_usuario", _Usuario);
            scom.AddWithValue("@descricao", "LISTA DE FALTA DE PRODUTOS - " + DateTime.Now.ToString("dd/MM/yyyy"));

            PedidoCompra item = null;
            try
            {
                scom.ExecuteReader();
                if(scom.HasRows && scom.Read())
                {
                    long l;
                    if (long.TryParse(scom.GetValue<object>(0).ToString(), out l)) item = new PedidoCompra() { Id = l };
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static PedidoCompra ObterAberto()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_usuario");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , finalizado");
            sql.AppendLine("    , data_previsao");
            sql.AppendLine("    , data_realizacao_compra");
            sql.AppendLine("FROM lista_compras ");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("    AND finalizado = 0");
            sql.AppendLine("ORDER BY IFNULL(data_previsao, data_cadastro) DESC;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            PedidoCompra item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new PedidoCompra()
                        {
                            Id = scom.GetValue<long>("id"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmCompra = scom.GetValue<DateTime?>("data_realizacao_compra"),
                            DtmPrevisaoCompra = scom.GetValue<DateTime?>("data_previsao"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            Status = scom.GetValue<bool>("status"),
                            Finalizado = scom.GetValue<bool>("finalizado"),
                            LstProdutos = DaoPedidoCompraItens.ItensDoPedido(scom.GetValue<long>("id")),
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
