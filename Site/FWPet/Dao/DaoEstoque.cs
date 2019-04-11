using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoEstoque
    {
        
        internal static void Salvar(Estoque item)
        {
            if (item == null) throw new Exception("Atenção! O objeto ESTOQUE não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }
        /*
estoque_entradas_saidas
  id
, id_usuario
, nota_fiscal
, entrada_saida
, valor_total
, data_movimentacao
, data_cadastro
, data_ultalt
, status
, observacao
, id_estoque_tipo_movimentacao
, finalizado




             */
        private static void Inserir(Estoque item)
        {
            throw new NotImplementedException();
        }

        private static void Alterar(Estoque item)
        {
            throw new NotImplementedException();
        }

        internal static void Excluir(Estoque item)
        {
            throw new NotImplementedException();
        }

        internal static List<Estoque> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      id");
            sql.AppendLine("    , id_usuario");
            sql.AppendLine("    , nota_fiscal");
            sql.AppendLine("    , entrada_saida");
            sql.AppendLine("    , valor_total");
            sql.AppendLine("    , data_movimentacao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , observacao");
            sql.AppendLine("    , id_estoque_tipo_movimentacao");
            sql.AppendLine("    , finalizado");
            sql.AppendLine("FROM estoque_entradas_saidas");
            sql.AppendLine("WHERE 1=1");
            
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<Estoque> Lst = new List<Estoque>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Estoque>();
                    Estoque item = null;
                    while (scom.Read())
                    {
                        item = new Estoque()
                        {
                            Id = scom.GetValue<long>("id"),
                            UsuarioCadastrou = new Usuario(scom.GetValue<long>("id_usuario")),
                            SNotaFiscal = scom.GetValue<string>("nota_fiscal"),
                            DValorTotal = scom.GetValue<decimal>("valor_total"),
                            DtmMovimentacao = scom.GetValue<DateTime>("data_movimentacao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmEmissaoNF = scom.GetValue<DateTime?>("data_emissao_nf"),
                            Finalizado = scom.GetValue<bool>("finalizado"),
                            Status = scom.GetValue<bool>("status"),
                            SEstoqueTipoMovimentacao = scom.GetValue<string>("id_estoque_tipo_movimentacao"),
                            SObservacao = scom.GetValue<string>("observacao"),
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