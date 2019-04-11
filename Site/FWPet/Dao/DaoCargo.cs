using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoCargo
    {
        internal static List<Cargo> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      cargos_funcoes.id");
            sql.AppendLine("    , cargos_funcoes.id_cbo");
            sql.AppendLine("    , cargos_funcoes.descricao");
            sql.AppendLine("    , cargos_funcoes.data_cadastro");
            sql.AppendLine("    , cargos_funcoes.data_ultalt");
            sql.AppendLine("    , cargos_funcoes.status");

            sql.AppendLine("    , cbo_cargos_funcoes.cbo AS CBOCodigo");
            sql.AppendLine("    , cbo_cargos_funcoes.descricao AS CBODescricao");
            sql.AppendLine("    , cbo_cargos_funcoes.complemento AS CBOComplemento");
            sql.AppendLine("    , cbo_cargos_funcoes.versao AS CBOVersao");
            sql.AppendLine("    , cbo_cargos_funcoes.data_cadastro AS CBOCadastro");
            sql.AppendLine("    , cbo_cargos_funcoes.data_ultalt AS CBOUltAlt");
            sql.AppendLine("    , cbo_cargos_funcoes.status AS CBOStatus");
            sql.AppendLine("FROM cargos_funcoes");
            sql.AppendLine("LEFT JOIN cbo_cargos_funcoes ON cbo_cargos_funcoes.id = cargos_funcoes.id_cbo");
            sql.AppendLine("WHERE cargos_funcoes.status = 1;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);

            List<Cargo> Lst = new List<Cargo>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Cargo>();
                    Cargo item = null;
                    while (scom.Read())
                    {
                        item = new Cargo()
                        {
                            Id = scom.GetValue<long>("id"),
                            IdCBO = scom.GetValue<long>("id_cbo"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        if(item.IdCBO > 0)
                        {
                            item.Cbo = new CBO()
                            {
                                Id = item.IdCBO,
                                SCbo = scom.GetValue<string>("CBOCodigo"),
                                SComplemento = scom.GetValue<string>("CBOComplemento"),
                                SDescricao = scom.GetValue<string>("CBODescricao"),
                                SVersao = scom.GetValue<string>("CBOVersao"),
                                DtmCadastro = scom.GetValue<DateTime>("CBOCadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("CBOUltAlt"),
                                Status = scom.GetValue<bool>("CBOStatus"),
                            };
                        }
                        
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Cargo Obter(long _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      cargos_funcoes.id");
            sql.AppendLine("    , cargos_funcoes.id_cbo");
            sql.AppendLine("    , cargos_funcoes.descricao");
            sql.AppendLine("    , cargos_funcoes.data_cadastro");
            sql.AppendLine("    , cargos_funcoes.data_ultalt");
            sql.AppendLine("    , cargos_funcoes.status");

            sql.AppendLine("    , cbo_cargos_funcoes.cbo AS CBOCodigo");
            sql.AppendLine("    , cbo_cargos_funcoes.descricao AS CBODescricao");
            sql.AppendLine("    , cbo_cargos_funcoes.complemento AS CBOComplemento");
            sql.AppendLine("    , cbo_cargos_funcoes.versao AS CBOVersao");
            sql.AppendLine("    , cbo_cargos_funcoes.data_cadastro AS CBOCadastro");
            sql.AppendLine("    , cbo_cargos_funcoes.data_ultalt AS CBOUltAlt");
            sql.AppendLine("    , cbo_cargos_funcoes.status AS CBOStatus");
            sql.AppendLine("FROM cargos_funcoes");
            sql.AppendLine("LEFT JOIN cbo_cargos_funcoes ON cbo_cargos_funcoes.id = cargos_funcoes.id_cbo");
            sql.AppendLine("WHERE cargos_funcoes.id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            Cargo item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Cargo()
                        {
                            Id = scom.GetValue<long>("id"),
                            IdCBO = scom.GetValue<long>("id_cbo"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        if (item.IdCBO > 0)
                        {
                            item.Cbo = new CBO()
                            {
                                Id = item.IdCBO,
                                SCbo = scom.GetValue<string>("CBOCodigo"),
                                SComplemento = scom.GetValue<string>("CBOComplemento"),
                                SDescricao = scom.GetValue<string>("CBODescricao"),
                                SVersao = scom.GetValue<string>("CBOVersao"),
                                DtmCadastro = scom.GetValue<DateTime>("CBOCadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("CBOUltAlt"),
                                Status = scom.GetValue<bool>("CBOStatus"),
                            };
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(Cargo item)
        {
            if (item == null) throw new Exception("");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Cargo item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO cargos_funcoes (id_cbo, descricao)");
            sql.AppendLine("VALUES (@id_cbo, @descricao);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_cbo", item.IdCBO);
            scom.AddWithValue("@descricao", item.SDescricao);
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

        private static void Alterar(Cargo item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE cargos_funcoes SET");
            sql.AppendLine("      id_cbo= @id_cbo");
            sql.AppendLine("    , descricao= @descricao");
            sql.AppendLine("    , data_ultalt= NOW()");
            sql.AppendLine("    , status= @status");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_cbo", item.IdCBO);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Cargo item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE cargos_funcoes SET");
            sql.AppendLine("      data_ultalt= NOW()");
            sql.AppendLine("    , status= 0");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
