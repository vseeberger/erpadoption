using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoEstoqueItem
    {
        /*
CREATE TABLE IF NOT EXISTS `estoque_item` (
`id_estoque` bigint(20) NOT NULL,
`item` int(11) NOT NULL,
`id_produto` bigint(20) DEFAULT NULL,
`id_lote_produto` bigint(20) DEFAULT NULL,
`id_usuario` bigint(20) DEFAULT '0',
`quantidade` decimal(18,3) DEFAULT '0.000',
`data_movimento` datetime DEFAULT NULL,
`valor_un` decimal(18,3) DEFAULT NULL,
`data_cadastro` datetime DEFAULT CURRENT_TIMESTAMP,
`data_ultalt` datetime DEFAULT CURRENT_TIMESTAMP,
`nota_fiscal` varchar(255) DEFAULT NULL,
`status` int(11) DEFAULT '1',
`integrado` int(11) DEFAULT '1',
PRIMARY KEY (`id_estoque`,`item`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
 */
        internal static void Salvar(EstoqueItem item)
        {
            if (item == null) throw new Exception("Atenção! O objeto ESTOQUEITEM não foi instanciado para salvar.");
            else
            {
                if (item.IdSequencia > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(EstoqueItem item)
        {
            throw new NotImplementedException();
        }

        private static void Alterar(EstoqueItem item)
        {
            throw new NotImplementedException();
        }

        internal static void Excluir(EstoqueItem item)
        {
            throw new NotImplementedException();
        }

        internal static List<EstoqueItem> BuscarEstoque(string _Tipo, bool? _Medicamento, bool? _Vacina, bool? _PesquisarOU, bool? _Status, int iQuantidade)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("     produto.id");
            sql.AppendLine("   , produto.tipo_produto");
            sql.AppendLine("   , produto.referencia");
            sql.AppendLine("   , produto.nome");
            sql.AppendLine("   , produto.nome_comercial");
            sql.AppendLine("   , produto.trabalha_com_lote");
            sql.AppendLine("   , produto.possui_grade");
            sql.AppendLine("   , produto.importado");
            sql.AppendLine("   , produto.eh_medicamento");
            sql.AppendLine("   , produto.eh_vacina");
            sql.AppendLine("   , produto.peso_bruto");
            sql.AppendLine("   , produto.peso_liquido");
            sql.AppendLine("   , produto.quantidade_compra");
            sql.AppendLine("   , produto.estoque_minimo");
            sql.AppendLine("   , produto.estoque_maximo");
            sql.AppendLine("   , produto.quantidade_etiquetas");
            sql.AppendLine("   , produto.tem_conversao");
            sql.AppendLine("   , produto.observacoes");
            sql.AppendLine("   , produto.id_medicamento_generico");
            sql.AppendLine("   , produto.id_medicamento_principioativo");
            sql.AppendLine("   , produto.id_medicamento_grupo");
            sql.AppendLine("   , produto.id_especie_vacina");
            sql.AppendLine("   , produto.quantidade_dias_validade");
            sql.AppendLine("   , produto.quantidade_doses");
            sql.AppendLine("   , produto.quantidade_dias_entre_doses");
            sql.AppendLine("   , produto.data_cadastro");
            sql.AppendLine("   , produto.data_ultalt");
            sql.AppendLine("   , produto.status");
            sql.AppendLine("   , produto.foto_capa");
            sql.AppendLine("   , produto.id_marca");
            sql.AppendLine("   , SUM(IFNULL(estoque_item.quantidade, 0)) as QtdEstoque");
            sql.AppendLine("FROM produto");
            sql.AppendLine("   LEFT JOIN estoque_item ON estoque_item.id_produto = produto.id");
            sql.AppendLine("					        AND estoque_item.status = 1");
            sql.AppendLine("   LEFT JOIN estoque_entradas_saidas ON estoque_entradas_saidas.id = estoque_item.id_estoque");
            sql.AppendLine("									        AND estoque_entradas_saidas.status = 1");
            sql.AppendLine("WHERE 1=1");
            if (_Status != null) sql.AppendLine("    AND produto.status = @status");
            if (_PesquisarOU == null || _PesquisarOU.Value == false)
            {
                if (_Medicamento != null) sql.AppendLine("AND produto.eh_medicamento = @eh_medicamento");
                if (_Vacina != null) sql.AppendLine("AND produto.eh_vacina = @eh_vacina");
            }
            else
            {
                if (_Medicamento != null && _Medicamento.Value) sql.AppendLine("AND (produto.eh_vacina = 0 AND produto.eh_medicamento IN (1,0))");
                if (_Vacina != null && _Vacina.Value) sql.AppendLine("AND (produto.eh_medicamento = 0 AND produto.eh_vacina IN (1,0))");
            }
            if (!String.IsNullOrEmpty(_Tipo)) sql.AppendLine(" AND produto.tipo_produto = @tipo");

            sql.AppendLine("GROUP BY produto.id");
            
            if (iQuantidade > 0) sql.AppendLine("LIMIT " + iQuantidade);
            
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@tipo", _Tipo);
            scom.AddWithValue("@eh_medicamento", _Medicamento == null ? 0 : _Medicamento.Value ? 1 : 0);
            scom.AddWithValue("@eh_vacina", _Vacina == null ? 0 : _Vacina.Value ? 1 : 0);
            scom.AddWithValue("@status", _Status != null && _Status.Value ? 1 : 0);

            List<EstoqueItem> Lst = new List<EstoqueItem>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<EstoqueItem>();
                    EstoqueItem item = null;
                    while (scom.Read())
                    {
                        item = new EstoqueItem()
                        {
                            Produto = new Produto()
                            {
                                Id = scom.GetValue<long>("id"),
                                SNome = scom.GetValue<string>("nome"),
                                SNomeComercial = scom.GetValue<string>("nome_comercial"),
                                SObservacoes = scom.GetValue<string>("observacoes"),
                                SReferencia = scom.GetValue<string>("referencia"),

                                STipoProduto = scom.GetValue<string>("tipo_produto"),
                                TrabalhaComLote = scom.GetValue<bool>("trabalha_com_lote"),
                                PossuiGrade = scom.GetValue<bool>("possui_grade"),
                                Importado = scom.GetValue<bool>("importado"),
                                EhMedicamento = scom.GetValue<bool>("eh_medicamento"),
                                EhVacina = scom.GetValue<bool>("eh_vacina"),

                                DPesoBruto = scom.GetValue<decimal>("peso_bruto"),
                                DPesoLiquido = scom.GetValue<decimal>("peso_liquido"),
                                DEstoqueMinimo = scom.GetValue<decimal>("estoque_minimo"),
                                DEstoqueMaximo = scom.GetValue<decimal>("estoque_maximo"),
                                DQuantidadeCompra = scom.GetValue<decimal>("quantidade_compra"),

                                TemConversao = scom.GetValue<bool>("tem_conversao"),
                                IQuantidadeDiasEntreDoses = scom.GetValue<int>("quantidade_dias_entre_doses"),
                                IQuantidadeDiasValidade = scom.GetValue<int>("quantidade_dias_validade"),
                                IQuantidadeDoses = scom.GetValue<int>("quantidade_doses"),
                                IQuantidadeEtiquetas = scom.GetValue<int>("quantidade_etiquetas"),

                                DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                                Status = scom.GetValue<bool>("status"),
                                SPathFotoCapa = scom.GetValue<string>("foto_capa")
                            },
                            DQuantidade = scom.GetValue<decimal>("QtdEstoque"),
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }
    }
}
