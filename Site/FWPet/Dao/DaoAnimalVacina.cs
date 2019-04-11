using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAnimalVacina
    {
        internal static void Salvar(AnimalVacina item)
        {
            if (item == null) throw new Exception("Atenção! O objeto ANIMALVACINA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(AnimalVacina item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("INSERT INTO vacina_x_animal (id_animal, id_vacina, data_aplicacao, data_agendamento, aplicado, dose_aplicada, dose_total, status)");
            sSQL.AppendLine("                     VALUES(@id_animal, @id_vacina, @data_aplicacao, @data_agendamento, @aplicado, @dose_aplicada, @dose_total, 1);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@id_animal", item.AnimvalVacinado);
            scom.AddWithValue("@id_vacina", item.Vacina);
            scom.AddWithValue("@data_aplicacao", item.DtmAplicacao);
            scom.AddWithValue("@data_agendamento", item.DtmAgendamento);
            scom.AddWithValue("@aplicado", item.Aplicado);
            scom.AddWithValue("@dose_aplicada", item.IDoseAplicada);
            scom.AddWithValue("@dose_total", item.ITotalDoses);

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

        private static void Alterar(AnimalVacina item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("UPDATE vacina_x_animal SET");
            sSQL.AppendLine("     id_animal         = @id_animal");
            sSQL.AppendLine("   , id_vacina         = @id_vacina");
            sSQL.AppendLine("   , data_aplicacao    = @data_aplicacao");
            sSQL.AppendLine("   , data_agendamento  = @data_agendamento");
            sSQL.AppendLine("   , aplicado          = @aplicado");
            sSQL.AppendLine("   , dose_aplicada     = @dose_aplicada");
            sSQL.AppendLine("   , dose_total        = @dose_total");
            sSQL.AppendLine("   , status            = @status");
            sSQL.AppendLine("   , data_ultalt       = NOW()");
            sSQL.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@id_animal", item.AnimvalVacinado);
            scom.AddWithValue("@id_vacina", item.Vacina);
            scom.AddWithValue("@data_aplicacao", item.DtmAplicacao);
            scom.AddWithValue("@data_agendamento", item.DtmAgendamento);
            scom.AddWithValue("@aplicado", item.Aplicado);
            scom.AddWithValue("@dose_aplicada", item.IDoseAplicada);
            scom.AddWithValue("@dose_total", item.ITotalDoses);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static AnimalVacina Obter(long _AnimalVacina)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("SELECT");
            sSQL.AppendLine("     vacinas.id");
            sSQL.AppendLine("   , vacinas.id_animal");
            sSQL.AppendLine("   , vacinas.id_vacina");
            sSQL.AppendLine("   , vacinas.data_aplicacao");
            sSQL.AppendLine("   , vacinas.data_agendamento");
            sSQL.AppendLine("   , vacinas.data_cadastro");
            sSQL.AppendLine("   , vacinas.data_ultalt");
            sSQL.AppendLine("   , vacinas.aplicado");
            sSQL.AppendLine("   , vacinas.dose_aplicada");
            sSQL.AppendLine("   , vacinas.dose_total");
            sSQL.AppendLine("   , vacinas.observacoes");
            sSQL.AppendLine("   , vacinas.status");
            sSQL.AppendLine("   , vacina.nome as VacinaNome");
            sSQL.AppendLine("   , animal.nome as AnimalNome");
            sSQL.AppendLine("FROM vacina_x_animal vacinas");
            sSQL.AppendLine("   LEFT JOIN produto vacina ON vacina.id = vacinas.id_vacina");
            sSQL.AppendLine("   LEFT JOIN animal ON animal.id = vacinas.id_animal");
            sSQL.AppendLine("WHERE 1=1");
            sSQL.AppendLine("   AND vacinas.id = @id");
            sSQL.AppendLine("ORDER BY vacinas.data_aplicacao");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _AnimalVacina);

            AnimalVacina item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new AnimalVacina()
                        {
                            Id = scom.GetValue<long>("id"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            DtmAplicacao = scom.GetValue<DateTime?>("data_aplicacao"),
                            DtmAgendamento = scom.GetValue<DateTime?>("data_agendamento"),
                            Aplicado = scom.GetValue<bool>("aplicado"),
                            IDoseAplicada = scom.GetValue<int>("dose_aplicada"),
                            ITotalDoses = scom.GetValue<int>("dose_total"),
                            IdAnimal = scom.GetValue<long>("id_animal")
                        };

                        if (scom.GetValue<long?>("id_vacina") != null && scom.GetValue<long>("id_vacina") > 0) { item.Vacina = new Produto(scom.GetValue<long>("id_vacina"), scom.GetValue<string>("VacinaNome")); }
                        if (scom.GetValue<long?>("id_animal") != null) { item.AnimvalVacinado = new Animal(scom.GetValue<long>("id_animal")); }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Clear(); }
            return item;
        }

        internal static void Excluir(AnimalVacina item)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("UPDATE vacina_x_animal SET");
            sSQL.AppendLine("     status     = 0");
            sSQL.AppendLine("   , data_ultalt= NOW()");
            sSQL.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<AnimalVacina> Pesquisar(long? _Animal)
        {
            StringBuilder sSQL = new StringBuilder();
            sSQL.AppendLine("SELECT");
            sSQL.AppendLine("     vacinas.id");
            sSQL.AppendLine("   , vacinas.id_animal");
            sSQL.AppendLine("   , vacinas.id_vacina");
            sSQL.AppendLine("   , vacinas.data_aplicacao");
            sSQL.AppendLine("   , vacinas.data_agendamento");
            sSQL.AppendLine("   , vacinas.data_cadastro");
            sSQL.AppendLine("   , vacinas.data_ultalt");
            sSQL.AppendLine("   , vacinas.aplicado");
            sSQL.AppendLine("   , vacinas.dose_aplicada");
            sSQL.AppendLine("   , vacinas.dose_total");
            sSQL.AppendLine("   , vacinas.observacoes");
            sSQL.AppendLine("   , vacinas.status");
            sSQL.AppendLine("   , produto.nome as VacinaNome");
            sSQL.AppendLine("   , animal.nome as AnimalNome");
            sSQL.AppendLine("FROM vacina_x_animal vacinas");
            sSQL.AppendLine("   LEFT JOIN produto ON produto.id = vacinas.id_vacina");
            sSQL.AppendLine("		              AND produto.eh_vacina = 1");
            sSQL.AppendLine("    LEFT JOIN animal ON animal.id = vacinas.id_animal");
            sSQL.AppendLine("WHERE 1=1");
            if (_Animal != null && _Animal > 0)
                sSQL.AppendLine("   AND vacinas.id_animal = @id_animal");
            sSQL.AppendLine("   AND vacinas.status=1");

            sSQL.AppendLine("ORDER BY vacinas.data_aplicacao");

            cMySqlCommand scom = new cMySqlCommand(sSQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", _Animal);

            List<AnimalVacina> Lst = new List<AnimalVacina>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalVacina>();
                    AnimalVacina item = null;
                    while (scom.Read())
                    {
                        item = new AnimalVacina();
                        item.Id = scom.GetValue<long>("id");
                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        item.Status = scom.GetValue<bool>("status");
                        item.DtmAplicacao = scom.GetValue<DateTime?>("data_aplicacao");
                        item.DtmAgendamento = scom.GetValue<DateTime?>("data_agendamento");
                        item.Aplicado = scom.GetValue<bool>("aplicado");
                        item.IDoseAplicada = scom.GetValue<int>("dose_aplicada");
                        item.ITotalDoses = scom.GetValue<int>("dose_total");
                        item.IdAnimal = scom.GetValue<long>("id_animal");

                        if (scom.GetValue<long?>("id_vacina") != null && scom.GetValue<long>("id_vacina") > 0)
                        {
                            item.Vacina = new Produto(scom.GetValue<long>("id_vacina"), scom.GetValue<string>("VacinaNome"));
                        }


                        if (scom.GetValue<long?>("id_animal") != null) { item.AnimvalVacinado = new Animal(scom.GetValue<long>("id_animal")); }

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Clear(); }
            return Lst;
        }
    }
}