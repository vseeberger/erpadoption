using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAnamnese
    {
        internal static void Salvar(Anamnese item)
        {
            if (item == null) throw new Exception("Atenção! O objeto RAÇA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Anamnese item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("INSERT INTO anamnese (id_animal, id_veterinario, descricao, anamnese, data_realizacao, peso, status)");
            sSQL.AppendLine("               VALUES(@id_animal, @id_veterinario, @descricao, @anamnese, @data_realizacao, @peso, 1);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", item.Animal);
            scom.AddWithValue("@id_veterinario", item.Veterinario);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@anamnese", item.SAnamnese + "");
            scom.AddWithValue("@data_realizacao", item.DtmRealizacao);
            scom.AddWithValue("@peso", item.DPeso == null ? 0 : item.DPeso.Value);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    long i;
                    if (!long.TryParse(scom.GetValue<object>(0).ToString(), out i) || i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Anamnese item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("UPDATE anamnese SET");
            sSQL.AppendLine("     id_veterinario    = @id_veterinario");
            sSQL.AppendLine("   , descricao         = @descricao");
            sSQL.AppendLine("   , anamnese          = @anamnese");
            sSQL.AppendLine("   , data_realizacao   = @data_realizacao");
            sSQL.AppendLine("   , peso              = @peso");
            sSQL.AppendLine("   , status            = @status");
            sSQL.AppendLine("   , data_ultalt       = NOW()");
            sSQL.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@id_veterinario", item.Veterinario);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@anamnese", item.SAnamnese + "");
            scom.AddWithValue("@data_realizacao", item.DtmRealizacao);
            scom.AddWithValue("@peso", item.DPeso == null ? 0 : item.DPeso.Value);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Anamnese item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("UPDATE anamnese SET");
            sSQL.AppendLine("     status            = 0");
            sSQL.AppendLine("   , data_ultalt       = NOW()");
            sSQL.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Anamnese> Pesquisar(long _Animal)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("SELECT");
            sSQL.AppendLine("     anamnese.id");
            sSQL.AppendLine("   , anamnese.id_animal");
            sSQL.AppendLine("   , anamnese.id_veterinario");
            sSQL.AppendLine("   , anamnese.descricao");
            sSQL.AppendLine("   , anamnese.anamnese");
            sSQL.AppendLine("   , anamnese.data_realizacao");
            sSQL.AppendLine("   , anamnese.peso");
            sSQL.AppendLine("   , anamnese.status");
            sSQL.AppendLine("   , anamnese.data_cadastro");
            sSQL.AppendLine("   , anamnese.data_ultalt");

            sSQL.AppendLine("   , pessoa.nome as VetNome");
            sSQL.AppendLine("   , pessoa.crmv as VetCRMV");
            sSQL.AppendLine("FROM anamnese");
            sSQL.AppendLine("   LEFT JOIN pessoa ON pessoa.id = anamnese.id_veterinario");
            sSQL.AppendLine("                   AND pessoa.tipo='V'");

            sSQL.AppendLine("WHERE anamnese.id_animal = @id_animal");
            sSQL.AppendLine("   AND anamnese.status=1;");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", _Animal);

            List<Anamnese> Lst = new List<Anamnese>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Anamnese>();
                    Anamnese item = null;
                    while (scom.Read())
                    {
                        item = new Anamnese()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAnamnese = scom.GetValue<string>("anamnese"),
                            DtmRealizacao = scom.GetValue<DateTime>("data_realizacao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DPeso = scom.GetValue<decimal>("peso"),
                            Status = scom.GetValue<bool>("status")
                        };

                        if (scom.GetValue<long?>("id_animal") != null) { item.Animal = new Animal(scom.GetValue<long>("id_animal")); }
                        if (scom.GetValue<long?>("id_veterinario") != null)
                        {
                            item.Veterinario = new Veterinario(
                                                                scom.GetValue<long>("id_veterinario"),
                                                                scom.GetValue<string>("VetNome"),
                                                                scom.GetValue<string>("VetCRMV")
                                                                );
                        }
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Clear(); }
            return Lst;
        }

        internal static Anamnese Obter(long _Anamnese)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("SELECT");
            sSQL.AppendLine("     anamnese.id");
            sSQL.AppendLine("   , anamnese.id_animal");
            sSQL.AppendLine("   , anamnese.id_veterinario");
            sSQL.AppendLine("   , anamnese.descricao");
            sSQL.AppendLine("   , anamnese.anamnese");
            sSQL.AppendLine("   , anamnese.data_realizacao");
            sSQL.AppendLine("   , anamnese.peso");
            sSQL.AppendLine("   , anamnese.status");
            sSQL.AppendLine("   , anamnese.data_cadastro");
            sSQL.AppendLine("   , anamnese.data_ultalt");

            sSQL.AppendLine("   , pessoa.nome as VetNome");
            sSQL.AppendLine("   , pessoa.crmv as VetCRMV");
            sSQL.AppendLine("FROM anamnese");
            sSQL.AppendLine("   LEFT JOIN pessoa ON pessoa.id = anamnese.id_veterinario");
            sSQL.AppendLine("                   AND pessoa.tipo='V'");

            sSQL.AppendLine("WHERE anamnese.id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Anamnese);

            Anamnese item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Anamnese()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SAnamnese = scom.GetValue<string>("anamnese"),
                            DtmRealizacao = scom.GetValue<DateTime>("data_realizacao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DPeso = scom.GetValue<decimal>("peso"),
                            Status = scom.GetValue<bool>("status")
                        };

                        if (scom.GetValue<long?>("id_animal") != null) { item.Animal = new Animal(scom.GetValue<long>("id_animal")); }
                        if (scom.GetValue<long?>("id_veterinario") != null)
                        {
                            item.Veterinario = new Veterinario(
                                                                scom.GetValue<long>("id_veterinario"),
                                                                scom.GetValue<string>("VetNome"),
                                                                scom.GetValue<string>("VetCRMV")
                                                                );
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Clear(); }
            return item;
        }
    }
}