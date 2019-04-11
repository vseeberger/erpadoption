using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoMedicamento
    {
        internal static void Salvar(Medicamento item)
        {
            if (item == null) throw new Exception("Atenção! O objeto MEDICAMENTO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Medicamento item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO medicamento (nome, nome_comercial, referencia, id_principioativo, id_grupo, id_generico, id_fabricante, observacoes)");
            sSql.AppendLine("                  VALUES(@nome, @nome_comercial, @referencia, @id_principioativo, @id_grupo, @id_generico, @id_fabricante, @observacoes);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome.ToString());
            scom.AddWithValue("@nome_comercial", item.SNomeComercial.ToString());
            scom.AddWithValue("@referencia", item.SReferencia.ToString());
            scom.AddWithValue("@id_principioativo", item.PrincipioAtivo == null ? 0 : item.PrincipioAtivo.Id);
            scom.AddWithValue("@id_grupo", item.Grupo == null ? 0 : item.Grupo.Id);
            scom.AddWithValue("@id_generico", item.Generico == null ? 0 : item.Generico.Id);
            scom.AddWithValue("@id_fabricante", item.FabricantePrincipal == null ? 0 : item.FabricantePrincipal.Id);
            scom.AddWithValue("@observacoes", item.SObservacoes.ToString());

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    int i;
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    else item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Medicamento> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     medicamento.id");
            sSql.AppendLine("   , medicamento.nome");
            sSql.AppendLine("   , medicamento.nome_comercial");
            sSql.AppendLine("   , medicamento.referencia");
            sSql.AppendLine("   , medicamento.id_principioativo");
            sSql.AppendLine("   , medicamento.id_grupo");
            sSql.AppendLine("   , medicamento.id_generico");
            sSql.AppendLine("   , medicamento.id_fabricante");
            sSql.AppendLine("   , medicamento.observacoes");
            sSql.AppendLine("   , medicamento.data_cadastro");
            sSql.AppendLine("   , medicamento.data_ultalt");
            sSql.AppendLine("   , medicamento.status");
            sSql.AppendLine("FROM medicamento");
            sSql.AppendLine("WHERE medicamento.status=1;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);

            List<Medicamento> Lst = new List<Medicamento>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Medicamento item = null;
                    while (scom.Read())
                    {
                        item = new Medicamento()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SNomeComercial = scom.GetValue<string>("nome_comercial"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SReferencia = scom.GetValue<string>("referencia"),
                            Status = scom.GetValue<bool>("status"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                        };

                        if (scom.GetValue<int>("id_principioativo") > 0)
                        {
                            item.PrincipioAtivo = new MedicamentoPrincipioAtivo()
                            {
                                Id = scom.GetValue<int>("id_principioativo")
                            };
                        }

                        if (scom.GetValue<int>("id_grupo") > 0)
                        {
                            item.Grupo = new MedicamentoGrupo()
                            {
                                Id = scom.GetValue<int>("id_grupo")
                            };
                        }

                        if (scom.GetValue<long>("id_generico") > 0)
                        {
                            item.Generico = new MedicamentoGenerico()
                            {
                                Id = scom.GetValue<long>("id_generico")
                            };
                        }

                        if (scom.GetValue<long>("id_fabricante") > 0)
                        {
                            item.FabricantePrincipal = new Empresa()
                            {
                                Id = scom.GetValue<long>("id_fabricante")
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

        internal static void Excluir(Medicamento item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE medicamento SET ");
            sSql.AppendLine("	  status = 0");
            sSql.AppendLine("	, data_ultalt       = NOW()");
            sSql.AppendLine("WHERE id = @id");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Medicamento Obter(long _Medicamento)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     medicamento.id");
            sSql.AppendLine("   , medicamento.nome");
            sSql.AppendLine("   , medicamento.nome_comercial");
            sSql.AppendLine("   , medicamento.referencia");
            sSql.AppendLine("   , medicamento.id_principioativo");
            sSql.AppendLine("   , medicamento.id_grupo");
            sSql.AppendLine("   , medicamento.id_generico");
            sSql.AppendLine("   , medicamento.id_fabricante");
            sSql.AppendLine("   , medicamento.observacoes");
            sSql.AppendLine("   , medicamento.data_cadastro");
            sSql.AppendLine("   , medicamento.data_ultalt");
            sSql.AppendLine("   , medicamento.status");
            sSql.AppendLine("FROM medicamento");
            sSql.AppendLine("WHERE medicamento.id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Medicamento);
            Medicamento item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Medicamento()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SNomeComercial = scom.GetValue<string>("nome_comercial"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SReferencia = scom.GetValue<string>("referencia"),
                            Status = scom.GetValue<bool>("status"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                        };

                        if (scom.GetValue<int>("id_principioativo") > 0)
                        {
                            item.PrincipioAtivo = new MedicamentoPrincipioAtivo()
                            {
                                Id = scom.GetValue<int>("id_principioativo")
                            };
                        }

                        if (scom.GetValue<int>("id_grupo") > 0)
                        {
                            item.Grupo = new MedicamentoGrupo()
                            {
                                Id = scom.GetValue<int>("id_grupo")
                            };
                        }

                        if (scom.GetValue<long>("id_generico") > 0)
                        {
                            item.Generico = new MedicamentoGenerico()
                            {
                                Id = scom.GetValue<long>("id_generico")
                            };
                        }

                        if (scom.GetValue<long>("id_fabricante") > 0)
                        {
                            item.FabricantePrincipal = new Empresa()
                            {
                                Id = scom.GetValue<long>("id_fabricante")
                            };
                        }

                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        private static void Alterar(Medicamento item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE medicamento SET ");
            sSql.AppendLine("	  nome              = @nome");
            sSql.AppendLine("	, nome_comercial    = @nome_comercial");
            sSql.AppendLine("	, referencia        = @referencia");
            sSql.AppendLine("	, id_principioativo = @id_principioativo");
            sSql.AppendLine("	, id_grupo          = @id_grupo");
            sSql.AppendLine("	, id_generico       = @id_generico");
            sSql.AppendLine("	, id_fabricante     = @id_fabricante");
            sSql.AppendLine("	, observacoes       = @observacoes");
            sSql.AppendLine("	, data_ultalt       = NOW()");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@nome", item.SNome.ToString());
            scom.AddWithValue("@nome_comercial", item.SNomeComercial.ToString());
            scom.AddWithValue("@referencia", item.SReferencia.ToString());
            scom.AddWithValue("@id_principioativo", item.PrincipioAtivo == null ? 0 : item.PrincipioAtivo.Id);
            scom.AddWithValue("@id_grupo", item.Grupo == null ? 0 : item.Grupo.Id);
            scom.AddWithValue("@id_generico", item.Generico == null ? 0 : item.Generico.Id);
            scom.AddWithValue("@id_fabricante", item.FabricantePrincipal == null ? 0 : item.FabricantePrincipal.Id);
            scom.AddWithValue("@observacoes", item.SObservacoes.ToString());

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}