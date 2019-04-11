using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoContaBancaria
    {
        internal static List<ContaBancaria> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      conta_bancaria.id");
            sql.AppendLine("    , conta_bancaria.id_tipo_conta");
            sql.AppendLine("    , conta_bancaria.descricao");
            sql.AppendLine("    , conta_bancaria.agencia");
            sql.AppendLine("    , conta_bancaria.conta");
            sql.AppendLine("    , conta_bancaria.titular_nome");
            sql.AppendLine("    , conta_bancaria.titular_documento");
            sql.AppendLine("    , conta_bancaria.data_cadastro");
            sql.AppendLine("    , conta_bancaria.data_ultalt");
            sql.AppendLine("    , conta_bancaria.status");
            sql.AppendLine("    , conta_bancaria.principal");
            sql.AppendLine("    , conta_bancaria_tipo.descricao AS TipoDesc");
            sql.AppendLine("    , conta_bancaria.saldo_inicial");
            sql.AppendLine("FROM conta_bancaria");
            sql.AppendLine("INNER JOIN conta_bancaria_tipo ON conta_bancaria_tipo.id = conta_bancaria.id_tipo_conta");
            sql.AppendLine("WHERE conta_bancaria.status = 1");
            sql.AppendLine("ORDER BY descricao");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<ContaBancaria> Lst = new List<ContaBancaria>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ContaBancaria>();
                    ContaBancaria item = null;
                    while (scom.Read())
                    {
                        item = new ContaBancaria()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAgencia = scom.GetValue<string>("agencia"),
                            SConta = scom.GetValue<string>("conta"),
                            STitularNome = scom.GetValue<string>("titular_nome"),
                            STitularDocumento = scom.GetValue<string>("titular_documento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Principal = scom.GetValue<bool>("principal"),
                            Status = scom.GetValue<bool>("status"),
                            DSaldoInicial = scom.GetValue<decimal>("saldo_inicial")
                        };

                        if (scom.GetValue<int?>("id_tipo_conta") != null && scom.GetValue<int?>("id_tipo_conta") > 0)
                            item.Tipo = new ContaBancariaTipo(scom.GetValue<int>("id_tipo_conta"), scom.GetValue<string>("TipoDesc"));

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(ContaBancaria item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE conta_bancaria SET");
            sql.AppendLine("      status = 0");
            sql.AppendLine("    , data_ultalt = NOW() ");
            sql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static ContaBancaria Obter(int _Conta)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      conta_bancaria.id");
            sql.AppendLine("    , conta_bancaria.id_tipo_conta");
            sql.AppendLine("    , conta_bancaria.descricao");
            sql.AppendLine("    , conta_bancaria.agencia");
            sql.AppendLine("    , conta_bancaria.conta");
            sql.AppendLine("    , conta_bancaria.titular_nome");
            sql.AppendLine("    , conta_bancaria.titular_documento");
            sql.AppendLine("    , conta_bancaria.data_cadastro");
            sql.AppendLine("    , conta_bancaria.data_ultalt");
            sql.AppendLine("    , conta_bancaria.status");
            sql.AppendLine("    , conta_bancaria.principal");
            sql.AppendLine("    , conta_bancaria_tipo.descricao AS TipoDesc");
            sql.AppendLine("    , conta_bancaria.saldo_inicial");
            sql.AppendLine("FROM conta_bancaria");
            sql.AppendLine("INNER JOIN conta_bancaria_tipo ON conta_bancaria_tipo.id = conta_bancaria.id_tipo_conta");
            sql.AppendLine("WHERE conta_bancaria.id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Conta);
            ContaBancaria item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ContaBancaria()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAgencia = scom.GetValue<string>("agencia"),
                            SConta = scom.GetValue<string>("conta"),
                            STitularNome = scom.GetValue<string>("titular_nome"),
                            STitularDocumento = scom.GetValue<string>("titular_documento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Principal = scom.GetValue<bool>("principal"),
                            Status = scom.GetValue<bool>("status"),
                            DSaldoInicial = scom.GetValue<decimal>("saldo_inicial")
                        };

                        if (scom.GetValue<int?>("id_tipo_conta") != null && scom.GetValue<int?>("id_tipo_conta") > 0)
                            item.Tipo = new ContaBancariaTipo(scom.GetValue<int>("id_tipo_conta"), scom.GetValue<string>("TipoDesc"));
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(ContaBancaria item)
        {
            if (item == null) throw new Exception("Atenção! O objeto CONTA BANCARIA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(ContaBancaria item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO conta_bancaria (id_tipo_conta, descricao, agencia, conta, titular_nome, titular_documento, principal, saldo_inicial)");
            sql.AppendLine("VALUES (@id_tipo_conta, @descricao, @agencia, @conta, @titular_nome, @titular_documento, @principal, @saldo_inicial);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_tipo_conta", item.Tipo);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@agencia", item.SAgencia + "");
            scom.AddWithValue("@conta", item.SConta + "");
            scom.AddWithValue("@titular_nome", item.STitularNome + "");
            scom.AddWithValue("@titular_documento", item.STitularDocumento + "");
            scom.AddWithValue("@principal", item.Principal ? 1 : 0);
            scom.AddWithValue("@saldo_inicial", item.DSaldoInicial);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read()) item.Id = Convert.ToInt32(scom.GetValue<object>(0).ToString());
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(ContaBancaria item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE conta_bancaria SET");
            sql.AppendLine("      id_tipo_conta = @id_tipo_conta");
            sql.AppendLine("    , descricao = @descricao");
            sql.AppendLine("    , agencia = @agencia");
            sql.AppendLine("    , conta = @conta");
            sql.AppendLine("    , titular_nome = @titular_nome");
            sql.AppendLine("    , titular_documento = @titular_documento");
            sql.AppendLine("    , principal = @principal");
            sql.AppendLine("    , data_ultalt = NOW() ");
            sql.AppendLine("    , saldo_inicial=@saldo_inicial");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_tipo_conta", item.Tipo);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@agencia", item.SAgencia + "");
            scom.AddWithValue("@conta", item.SConta + "");
            scom.AddWithValue("@titular_nome", item.STitularNome + "");
            scom.AddWithValue("@titular_documento", item.STitularDocumento + "");
            scom.AddWithValue("@principal", item.Principal ? 1 : 0);
            scom.AddWithValue("@saldo_inicial", item.DSaldoInicial);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}