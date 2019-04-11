using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoCBO
    {
        internal static List<CBO> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      cbo_cargos_funcoes.id");
            sql.AppendLine("    , cbo_cargos_funcoes.cbo");
            sql.AppendLine("    , cbo_cargos_funcoes.descricao");
            sql.AppendLine("    , cbo_cargos_funcoes.complemento");
            sql.AppendLine("    , cbo_cargos_funcoes.versao");
            sql.AppendLine("    , cbo_cargos_funcoes.data_cadastro");
            sql.AppendLine("    , cbo_cargos_funcoes.data_ultalt");
            sql.AppendLine("    , cbo_cargos_funcoes.status");
            sql.AppendLine("FROM cbo_cargos_funcoes");
            sql.AppendLine("WHERE status = 1");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<CBO> Lst = new List<CBO>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<CBO>();
                    CBO item = null;
                    while (scom.Read())
                    {
                        item = new CBO()
                        {
                            Id = scom.GetValue<long>("id"),
                            SCbo = scom.GetValue<string>("cbo"),
                            SComplemento = scom.GetValue<string>("complemento"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SVersao = scom.GetValue<string>("versao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static CBO Obter(long _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      cbo_cargos_funcoes.id");
            sql.AppendLine("    , cbo_cargos_funcoes.cbo");
            sql.AppendLine("    , cbo_cargos_funcoes.descricao");
            sql.AppendLine("    , cbo_cargos_funcoes.complemento");
            sql.AppendLine("    , cbo_cargos_funcoes.versao");
            sql.AppendLine("    , cbo_cargos_funcoes.data_cadastro");
            sql.AppendLine("    , cbo_cargos_funcoes.data_ultalt");
            sql.AppendLine("    , cbo_cargos_funcoes.status");
            sql.AppendLine("FROM cbo_cargos_funcoes");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            CBO item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if(scom.Read())
                    {
                        item = new CBO()
                        {
                            Id = scom.GetValue<long>("id"),
                            SCbo = scom.GetValue<string>("cbo"),
                            SComplemento = scom.GetValue<string>("complemento"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SVersao = scom.GetValue<string>("versao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(CBO item)
        {
            if (item == null) throw new Exception("");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
           
        }

        private static void Inserir(CBO item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO cbo_cargos_funcoes (cbo, descricao, complemento, versao)");
            sql.AppendLine("VALUES (@cbo, @descricao, @complemento, @versao);");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@versao", item.SVersao);
            scom.AddWithValue("@complemento", item.SComplemento);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@cbo", item.SCbo);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long l;
                    if (long.TryParse(scom.GetValue<object>(0).ToString(), out l)) item.Id = l;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(CBO item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE cbo_cargos_funcoes SET");
            sql.AppendLine("      cbo = @cbo");
            sql.AppendLine("    , descricao = @descricao");
            sql.AppendLine("    , complemento = @complemento");
            sql.AppendLine("    , versao = @versao");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@versao", item.SVersao);
            scom.AddWithValue("@complemento", item.SComplemento);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@cbo", item.SCbo);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(CBO item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE cbo_cargos_funcoes SET");
            sql.AppendLine("      data_ultalt = NOW()");
            sql.AppendLine("    , status = 0");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
