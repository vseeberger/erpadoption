using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoBeneficioDesconto
    {
        internal static List<BeneficioDesconto> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , valor_maximo");
            sql.AppendLine("    , percentual_salario");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM beneficio_desconto");
            sql.AppendLine("WHERE status = 1");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<BeneficioDesconto> Lst = new List<BeneficioDesconto>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<BeneficioDesconto>();
                    BeneficioDesconto item = null;
                    while (scom.Read())
                    {
                        item = new BeneficioDesconto()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DPercentualDesconto = scom.GetValue<decimal>("percentual_salario"),
                            DValorMaximo = scom.GetValue<decimal>("valor_maximo"),
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
        
        internal static BeneficioDesconto Obter(int id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , descricao");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , valor_maximo");
            sql.AppendLine("    , percentual_salario");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM beneficio_desconto");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", id);

            BeneficioDesconto item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new BeneficioDesconto()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DPercentualDesconto = scom.GetValue<decimal>("percentual_salario"),
                            DValorMaximo = scom.GetValue<decimal>("valor_maximo"),
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

        internal static void Salvar(BeneficioDesconto item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto BENEFICIODESCONTO não foi instanciado para salvar.");
        }

        private static void Inserir(BeneficioDesconto item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO beneficio_desconto (descricao, valor_maximo, percentual_salario, status)");
            sql.AppendLine("VALUES (@descricao, @valor_maximo, @percentual_salario, @status);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@valor_maximo", item.DValorMaximo);
            scom.AddWithValue("@percentual_salario", item.DPercentualDesconto);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(BeneficioDesconto item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE beneficio_desconto SET");
            sql.AppendLine("      descricao         = @descricao");
            sql.AppendLine("    , data_ultalt       = NOW()");
            sql.AppendLine("    , valor_maximo      = @valor_maximo");
            sql.AppendLine("    , percentual_salario= @percentual_salario");
            sql.AppendLine("    , status            = @status");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@valor_maximo", item.DValorMaximo);
            scom.AddWithValue("@percentual_salario", item.DPercentualDesconto);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(BeneficioDesconto item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE beneficio_desconto SET");
            sql.AppendLine("      data_ultalt       = NOW()");
            sql.AppendLine("    , status            = 0");
            sql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void VincularComPessoa(ColaboradorBeneficioDesconto item)
        {
            if (item != null)
            {
                if (item.Alterou)
                {
                    if (item.Id > 0) AlterarVinculo(item);
                    else InserirVinculo(item);
                }
            }
            else throw new Exception("Atenção! O objeto BENEFICIODESCONTO não foi instanciado para salvar o vínculo.");
        }

        private static void InserirVinculo(ColaboradorBeneficioDesconto item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO beneficio_desconto_pessoa (id_beneficio_desconto, id_colaborador, tipo, valor_desconto)");
            sql.AppendLine("VALUES (@id_beneficio_desconto, @id_colaborador, @tipo, @valor_desconto);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_beneficio_desconto", item.Beneficio.Id);
            scom.AddWithValue("@id_colaborador", item.Colaborador.Id);
            scom.AddWithValue("@tipo", item.STipo);
            scom.AddWithValue("@valor_desconto", item.DValor);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long l;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out l);
                    item.Id = l;
                    item.Sequencia = l;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void AlterarVinculo(ColaboradorBeneficioDesconto item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE beneficio_desconto_pessoa SET");
            sql.AppendLine("      id_beneficio_desconto = @id_beneficio_desconto");
            sql.AppendLine("    , tipo = @tipo");
            sql.AppendLine("    , valor_desconto = @valor_desconto");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id = @id");
            sql.AppendLine("AND id_colaborador = @id_colaborador");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_colaborador", item.Colaborador.Id);
            scom.AddWithValue("@id_beneficio_desconto", item.Beneficio.Id);
            scom.AddWithValue("@tipo", item.STipo);
            scom.AddWithValue("@valor_desconto", item.DValor);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}