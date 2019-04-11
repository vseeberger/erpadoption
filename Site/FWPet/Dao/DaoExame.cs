using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoExame
    {
        internal static void Salvar(Exame item)
        {
            if (item != null)
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
            else throw new Exception("Atenção! O objeto EXAME não foi instanciado, verifique os dados!");
        }
        
        internal static void Inserir(Exame item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO exame (descricao, id_tipo, id_clinica, profissional_que_assinou, id_veterinario, id_animal, data_realizado, data_agendado, anexo)");
            sSql.AppendLine("VALUES (@descricao, @id_tipo, @id_clinica, @profissional_que_assinou, @id_veterinario, @id_animal, @data_realizado, @data_agendado, @anexo);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@descricao", item.SDescricao+"");
            scom.AddWithValue("@corpo_exame", item.SCorpoExame + "");
            scom.AddWithValue("@id_tipo", item.Tipo);
            scom.AddWithValue("@id_clinica", item.Laboratorio);
            scom.AddWithValue("@profissional_que_assinou", item.SProfissionalQueAssinou);
            scom.AddWithValue("@id_veterinario", item.ProfissionalQueRequisitou);
            scom.AddWithValue("@id_animal", item.Animal);
            scom.AddWithValue("@data_realizado", item.DtmRealizacao);
            scom.AddWithValue("@data_agendado", item.DtmAgendamento);
            scom.AddWithValue("@anexo", item.SPathAnexo);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    int i;
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
        
        internal static void Alterar(Exame item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE exame SET ");
            sSql.AppendLine("         descricao                 = @descricao                 ");
            sSql.AppendLine("       , id_tipo                   = @id_tipo                   ");
            sSql.AppendLine("       , id_clinica                = @id_clinica                ");
            sSql.AppendLine("       , profissional_que_assinou  = @profissional_que_assinou  ");
            sSql.AppendLine("       , id_veterinario            = @id_veterinario            ");
            sSql.AppendLine("       , id_animal                 = @id_animal                 ");
            sSql.AppendLine("       , data_realizado            = @data_realizado            ");
            sSql.AppendLine("       , data_agendado             = @data_agendado             ");
            sSql.AppendLine("       , corpo_exame               = @corpo_exame               ");
            sSql.AppendLine("       , anexo                     = @anexo");
            sSql.AppendLine("       , data_ultalt= NOW()        ");
            sSql.AppendLine("WHERE id = @id;");
            
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@descricao", item.SDescricao + "");
            scom.AddWithValue("@corpo_exame", item.SCorpoExame + "");
            scom.AddWithValue("@id_tipo", item.Tipo);
            scom.AddWithValue("@id_clinica", item.Laboratorio);
            scom.AddWithValue("@profissional_que_assinou", item.SProfissionalQueAssinou);
            scom.AddWithValue("@id_veterinario", item.ProfissionalQueRequisitou);
            scom.AddWithValue("@id_animal", item.Animal);
            scom.AddWithValue("@data_realizado", item.DtmRealizacao);
            scom.AddWithValue("@data_agendado", item.DtmAgendamento);
            scom.AddWithValue("@anexo", item.SPathAnexo);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Exame item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE exame SET ");
            sSql.AppendLine("         status     = 0");
            sSql.AppendLine("       , data_ultalt= NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Exame> Pesquisar(long _Animal)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("SELECT ");
            SQL.AppendLine("         exame.id");
            SQL.AppendLine("       , exame.descricao");
            SQL.AppendLine("       , exame.corpo_exame");
            SQL.AppendLine("       , exame.id_tipo");
            SQL.AppendLine("       , exame.id_clinica");
            SQL.AppendLine("       , exame.profissional_que_assinou");
            SQL.AppendLine("       , exame.id_veterinario");
            SQL.AppendLine("       , exame.id_animal");
            SQL.AppendLine("       , exame.data_realizado");
            SQL.AppendLine("       , exame.data_agendado");
            SQL.AppendLine("       , exame.data_cadastro");
            SQL.AppendLine("       , exame.data_ultalt");
            SQL.AppendLine("       , exame.status");
            SQL.AppendLine("       , exame.anexo");
            SQL.AppendLine("FROM exame");
            SQL.AppendLine("WHERE 1=1");
            if (_Animal > 0)
                SQL.AppendLine("    AND exame.id_animal = @id_animal");
            SQL.AppendLine("    AND exame.status = 1");

            cMySqlCommand scom = new cMySqlCommand(SQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", _Animal);

            List<Exame> Lst = new List<Exame>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Exame>();
                    Exame item = null;
                    while (scom.Read())
                    {
                        item = new Exame()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SCorpoExame = scom.GetValue<string>("corpo_exame"),
                            Tipo = ExameTipo.Obter(scom.GetValue<int>("id_tipo")),
                            SProfissionalQueAssinou = scom.GetValue<string>("profissional_que_assinou"),
                            DtmRealizacao = scom.GetValue<DateTime?>("data_realizado"),
                            DtmAgendamento = scom.GetValue<DateTime?>("data_agendado"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Animal = new Animal(scom.GetValue<long>("id_animal")),
                            SPathAnexo = scom.GetValue<string>("anexo")
                        };

                        if (scom.GetValue<long?>("id_clinica") != null)
                        {
                            item.Laboratorio = new LaboratorioClinico(scom.GetValue<long>("id_clinica"));
                        }
                        if(scom.GetValue<long?>("id_veterinario") > 0)
                        {
                            item.ProfissionalQueRequisitou = new Veterinario(scom.GetValue<long>("id_veterinario"));
                        }

                        Lst.Add(item);
                    }
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Exame Obter(long _Exame)
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendLine("SELECT ");
            SQL.AppendLine("         exame.id");
            SQL.AppendLine("       , exame.descricao");
            SQL.AppendLine("       , exame.corpo_exame");
            SQL.AppendLine("       , exame.id_tipo");
            SQL.AppendLine("       , exame.id_clinica");
            SQL.AppendLine("       , exame.profissional_que_assinou");
            SQL.AppendLine("       , exame.id_veterinario");
            SQL.AppendLine("       , exame.id_animal");
            SQL.AppendLine("       , exame.data_realizado");
            SQL.AppendLine("       , exame.data_agendado");
            SQL.AppendLine("       , exame.data_cadastro");
            SQL.AppendLine("       , exame.data_ultalt");
            SQL.AppendLine("       , exame.status");
            SQL.AppendLine("       , exame.anexo");
            SQL.AppendLine("FROM exame");
            SQL.AppendLine("WHERE exame.id = @id");
            
            cMySqlCommand scom = new cMySqlCommand(SQL.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Exame);

            Exame item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Exame()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            SCorpoExame = scom.GetValue<string>("corpo_exame"),
                            Tipo = ExameTipo.Obter(scom.GetValue<int>("id_tipo")),
                            SProfissionalQueAssinou = scom.GetValue<string>("profissional_que_assinou"),
                            DtmRealizacao = scom.GetValue<DateTime?>("data_realizado"),
                            DtmAgendamento = scom.GetValue<DateTime?>("data_agendado"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Animal = new Animal(scom.GetValue<long>("id_animal")),
                            SPathAnexo = scom.GetValue<string>("anexo")
                        };

                        if (scom.GetValue<long?>("id_clinica") != null)
                        {
                            item.Laboratorio = new LaboratorioClinico(scom.GetValue<long>("id_clinica"));
                        }
                        if (scom.GetValue<long?>("id_veterinario") > 0)
                        {
                            item.ProfissionalQueRequisitou = new Veterinario(scom.GetValue<long>("id_veterinario"));
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}
