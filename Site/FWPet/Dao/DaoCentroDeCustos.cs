using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoCentroDeCustos
    {
        internal static List<CentroDeCustos> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    id");
            sql.AppendLine("  , descricao");
            sql.AppendLine("  , data_cadastro");
            sql.AppendLine("  , data_ultalt");
            sql.AppendLine("  , status");
            sql.AppendLine("  , custo_ou_lucro");
            sql.AppendLine("FROM centro_de_custos_lucro");
            sql.AppendLine("WHERE status = 1");
            sql.AppendLine("ORDER BY descricao");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            List<CentroDeCustos> Lst = new List<CentroDeCustos>();

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<CentroDeCustos>();
                    CentroDeCustos item = null;
                    while (scom.Read())
                    {
                        item = new CentroDeCustos()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SCustoLucro = scom.GetValue<string>("custo_ou_lucro"),
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

        internal static CentroDeCustos Obter(int _Centro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    id");
            sql.AppendLine("  , descricao");
            sql.AppendLine("  , data_cadastro");
            sql.AppendLine("  , data_ultalt");
            sql.AppendLine("  , status");
            sql.AppendLine("  , custo_ou_lucro");
            sql.AppendLine("FROM centro_de_custos_lucro");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Centro);
            CentroDeCustos item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new CentroDeCustos()
                        {
                            Id = scom.GetValue<int>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SCustoLucro = scom.GetValue<string>("custo_ou_lucro"),
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

        internal static void Salvar(CentroDeCustos item)
        {
            if (item != null)
            {
                if (item.Id == 0) Inserir(item);
                else Alterar(item);
            }
            else throw new Exception("Atenção! O objeto CENTRO DE CUSTOS não foi instanciado para salvar.");
        }

        private static void Alterar(CentroDeCustos item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE centro_de_custos_lucro SET");
            sql.AppendLine("    data_ultalt = NOW()");
            sql.AppendLine("  , descricao = @descricao");
            sql.AppendLine("  , status = @status");
            sql.AppendLine("  , custo_ou_lucro = @custo_ou_lucro");
            sql.AppendLine("WHERE ");
            sql.AppendLine("    id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@custo_ou_lucro", item.SCustoLucro + "");
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Inserir(CentroDeCustos item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO centro_de_custos_lucro (descricao, custo_ou_lucro)");
            sql.AppendLine("VALUES (@descricao, @custo_ou_lucro);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@custo_ou_lucro", item.SCustoLucro);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read()) item.Id = int.Parse(scom.GetValue<object>(0).ToString());
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(CentroDeCustos centroDeCustos)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE centro_de_custos_lucro SET");
            sql.AppendLine("    data_ultalt = NOW()");
            sql.AppendLine("  , status = 0");
            sql.AppendLine("WHERE ");
            sql.AppendLine("    id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            try { scom.ExecuteNonQuery(); }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
