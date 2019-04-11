using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAnimal
    {
        internal static int DashboardTotalTratamento()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    COUNT(distinct animal.id) as Total");
            sql.AppendLine("FROM animal");
            sql.AppendLine("INNER JOIN animal_medicamento ON animal_medicamento.id_animal = animal.id");
            sql.AppendLine("						                AND animal_medicamento.aplicado  = 0");
            sql.AppendLine("						                AND animal_medicamento.status    = 1");
            sql.AppendLine("WHERE animal.status = 1");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            try { scom.ExecuteReader(); if (scom.HasRows && scom.Read()) return int.Parse(scom.GetValue<object>(0).ToString()); else return 0; }
            catch(Exception ex) { return 0; }
        }

        internal static int DashboardTotal()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    COUNT(distinct animal.id) as Total");
            sql.AppendLine("FROM animal");
            sql.AppendLine("WHERE animal.status = 1");
            sql.AppendLine("    AND animal.id_disponibilidade <> 3");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            try { scom.ExecuteReader(); if (scom.HasRows && scom.Read()) return int.Parse(scom.GetValue<object>(0).ToString()); else return 0; }
            catch (Exception ex) { return 0; }
        }

        internal static int DashboardNovosAnimais(int _Dias = 1)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    COUNT(distinct animal.id) as Total");
            sql.AppendLine("FROM animal");
            sql.AppendLine("WHERE animal.status = 1");
            sql.AppendLine("    AND data_cadastro between @data_inicio AND NOW()");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@data_inicio", DateTime.Today.AddDays(_Dias * -1));
            try { scom.ExecuteReader(); if (scom.HasRows && scom.Read()) return int.Parse(scom.GetValue<object>(0).ToString()); else return 0; }
            catch (Exception ex) { return 0; }
        }

        internal static List<Animal> Pesquisar(string _Nome, int? _Situacao, bool? _Status, long? _Padrinho)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("     animal.id");
            sSql.AppendLine("   , animal.nome");
            sSql.AppendLine("   , animal.id_especie");
            sSql.AppendLine("   , animal.sexo");
            sSql.AppendLine("   , animal.id_responsavel");
            sSql.AppendLine("   , animal.observacoes");
            sSql.AppendLine("   , animal.numero_chip");
            sSql.AppendLine("   , animal.cor");
            sSql.AppendLine("   , animal.data_chegou");
            sSql.AppendLine("   , animal.data_resgate");
            sSql.AppendLine("   , animal.data_nascimento");
            sSql.AppendLine("   , animal.data_ultalt");
            sSql.AppendLine("   , animal.id_porte");
            sSql.AppendLine("   , animal.id_disponibilidade");
            sSql.AppendLine("   , animal.castrado");
            sSql.AppendLine("   , animal.status");
            sSql.AppendLine("   , animal.data_cadastro");
            sSql.AppendLine("   , animal.id_raca");
            sSql.AppendLine("   , responsavel.nome as RespNome");
            sSql.AppendLine("   , especie.descricao as EspecieNome");
            sSql.AppendLine("   , porte.descricao as PorteDescricao");
            sSql.AppendLine("   , raca.descricao as RacaDescricao");
            sSql.AppendLine("FROM animal");
            sSql.AppendLine("   LEFT JOIN pessoa responsavel on responsavel.tipo = 'R' AND responsavel.id = animal.id_responsavel ");
            sSql.AppendLine("   LEFT JOIN especie ON especie.id = animal.id_especie ");
            sSql.AppendLine("   LEFT JOIN porte ON porte.id = animal.id_porte");
            sSql.AppendLine("   LEFT JOIN raca on raca.id = animal.id_raca");
            sSql.AppendLine("WHERE 1=1");
            if (_Status != null) sSql.AppendLine("AND animal.status=@status");
            if (_Situacao != null && _Situacao > 0) sSql.AppendLine("AND animal.id_disponibilidade = @id_disponibilidade");
            if (!String.IsNullOrWhiteSpace(_Nome)) sSql.AppendLine("AND animal.nome LIKE '@nome'");
            if (_Padrinho != null && _Padrinho != 0)
            {
                if (_Padrinho > 0) { sSql.AppendLine("AND animal.id_responsavel = @id_responsavel"); }
                else { sSql.AppendLine("AND (animal.id_responsavel IS NULL OR animal.id_responsavel = 0)"); }
            }

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@status", _Status == null ? 0 : _Status.Value ? 1 : 0);
            scom.AddWithValue("@id_disponibilidade", _Situacao);
            scom.AddWithValue("@nome", _Nome);
            scom.AddWithValue("@id_responsavel", _Padrinho);


            List<Animal> Lst = new List<Animal>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Animal>();
                    Animal item = null;
                    while (scom.Read())
                    {
                        item = new Animal()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            CSexo = scom.GetValue<char>("sexo"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SNumeroChip = scom.GetValue<string>("numero_chip"),
                            SCor = scom.GetValue<string>("cor"),
                            DtmChegou = scom.GetValue<DateTime?>("data_chegou"),
                            DtmResgate = scom.GetValue<DateTime?>("data_resgate"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Castrado = scom.GetValue<bool>("castrado"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        if (scom.GetValue<int?>("id_especie") > 0)
                        {
                            item.Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("EspecieNome"));
                        }

                        if (scom.GetValue<long?>("id_responsavel") > 0)
                        {
                            item.Responsavel = new Responsavel(scom.GetValue<long>("id_responsavel"), scom.GetValue<string>("RespNome"));
                        }

                        if (scom.GetValue<int?>("id_porte") > 0)
                        {
                            item.Porte = new Porte(scom.GetValue<int>("id_porte"), scom.GetValue<string>("PorteDescricao"));
                        }

                        if (scom.GetValue<int?>("id_disponibilidade") > 0)
                        {
                            item.Situacao = Disponibilidade.Obter(scom.GetValue<int>("id_disponibilidade"));
                        }

                        if (scom.GetValue<int?>("id_raca") > 0)
                        {
                            item.Raca = new Raca(scom.GetValue<int>("id_raca"), scom.GetValue<string>("RacaDescricao"));
                        }
                        
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static List<Animal> Disponiveis(long? _Animal = null)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("     animal.id");
            sSql.AppendLine("   , animal.nome");
            sSql.AppendLine("   , animal.id_especie");
            sSql.AppendLine("   , animal.sexo");
            sSql.AppendLine("   , animal.id_responsavel");
            sSql.AppendLine("   , animal.observacoes");
            sSql.AppendLine("   , animal.numero_chip");
            sSql.AppendLine("   , animal.cor");
            sSql.AppendLine("   , animal.data_chegou");
            sSql.AppendLine("   , animal.data_resgate");
            sSql.AppendLine("   , animal.data_nascimento");
            sSql.AppendLine("   , animal.data_ultalt");
            sSql.AppendLine("   , animal.id_porte");
            sSql.AppendLine("   , animal.id_disponibilidade");
            sSql.AppendLine("   , animal.castrado");
            sSql.AppendLine("   , animal.status");
            sSql.AppendLine("   , animal.data_cadastro");
            sSql.AppendLine("   , animal.id_raca");
            sSql.AppendLine("   , responsavel.nome as RespNome");
            sSql.AppendLine("   , especie.descricao as EspecieNome");
            sSql.AppendLine("   , porte.descricao as PorteDescricao");
            sSql.AppendLine("   , raca.descricao as RacaDescricao");
            sSql.AppendLine("FROM animal");
            sSql.AppendLine("   LEFT JOIN pessoa responsavel on responsavel.tipo = 'R' AND responsavel.id = animal.id_responsavel ");
            sSql.AppendLine("   LEFT JOIN especie ON especie.id = animal.id_especie ");
            sSql.AppendLine("   LEFT JOIN porte ON porte.id = animal.id_porte");
            sSql.AppendLine("   LEFT JOIN raca on raca.id = animal.id_raca");
            sSql.AppendLine("WHERE animal.status=1");
            if (_Animal != null && _Animal != 0)
                sSql.AppendLine("   AND (animal.id_disponibilidade = 1 OR animal.id = @id)");
            else
                sSql.AppendLine("   AND animal.id_disponibilidade = 1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Animal);

            List<Animal> Lst = new List<Animal>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Animal>();
                    Animal item = null;
                    while (scom.Read())
                    {
                        item = new Animal()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            CSexo = scom.GetValue<char>("sexo"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SNumeroChip = scom.GetValue<string>("numero_chip"),
                            SCor = scom.GetValue<string>("cor"),
                            DtmChegou = scom.GetValue<DateTime?>("data_chegou"),
                            DtmResgate = scom.GetValue<DateTime?>("data_resgate"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Castrado = scom.GetValue<bool>("castrado"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        if (scom.GetValue<int?>("id_especie") > 0)
                        {
                            item.Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("EspecieNome"));
                        }

                        if (scom.GetValue<long?>("id_responsavel") > 0)
                        {
                            item.Responsavel = new Responsavel(scom.GetValue<long>("id_responsavel"), scom.GetValue<string>("RespNome"));
                        }

                        if (scom.GetValue<int?>("id_porte") > 0)
                        {
                            item.Porte = new Porte(scom.GetValue<int>("id_porte"), scom.GetValue<string>("PorteDescricao"));
                        }

                        if (scom.GetValue<int?>("id_disponibilidade") > 0)
                        {
                            item.Situacao = Disponibilidade.Obter(scom.GetValue<int>("id_disponibilidade"));
                        }

                        if (scom.GetValue<int?>("id_raca") > 0)
                        {
                            item.Raca = new Raca(scom.GetValue<int>("id_raca"), scom.GetValue<string>("RacaDescricao"));
                        }

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(Animal item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE animal SET");
            sSql.AppendLine("      status      = 0");
            sSql.AppendLine("    , data_ultalt = NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Animal Obter(long _Animal)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("     animal.id");
            sSql.AppendLine("   , animal.nome");
            sSql.AppendLine("   , animal.id_especie");
            sSql.AppendLine("   , animal.sexo");
            sSql.AppendLine("   , animal.id_responsavel");
            sSql.AppendLine("   , animal.observacoes");
            sSql.AppendLine("   , animal.numero_chip");
            sSql.AppendLine("   , animal.cor");
            sSql.AppendLine("   , animal.data_chegou");
            sSql.AppendLine("   , animal.data_resgate");
            sSql.AppendLine("   , animal.data_nascimento");
            sSql.AppendLine("   , animal.data_ultalt");
            sSql.AppendLine("   , animal.id_porte");
            sSql.AppendLine("   , animal.id_disponibilidade");
            sSql.AppendLine("   , animal.castrado");
            sSql.AppendLine("   , animal.status");
            sSql.AppendLine("   , animal.data_cadastro");
            sSql.AppendLine("   , animal.id_raca");
            sSql.AppendLine("   , responsavel.nome as RespNome");
            sSql.AppendLine("   , especie.descricao as EspecieNome");
            sSql.AppendLine("   , porte.descricao as PorteDescricao");
            sSql.AppendLine("   , raca.descricao as RacaDescricao");
            sSql.AppendLine("FROM animal");
            sSql.AppendLine("   LEFT JOIN pessoa responsavel on responsavel.tipo = 'R' AND responsavel.id = animal.id_responsavel ");
            sSql.AppendLine("   LEFT JOIN especie ON especie.id = animal.id_especie ");
            sSql.AppendLine("   LEFT JOIN porte ON porte.id = animal.id_porte");
            sSql.AppendLine("   LEFT JOIN raca on raca.id = animal.id_raca");
            sSql.AppendLine("WHERE animal.id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Animal);
            Animal item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Animal()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            CSexo = scom.GetValue<char>("sexo"),
                            SObservacoes = scom.GetValue<string>("observacoes"),
                            SNumeroChip = scom.GetValue<string>("numero_chip"),
                            SCor = scom.GetValue<string>("cor"),
                            DtmChegou = scom.GetValue<DateTime?>("data_chegou"),
                            DtmResgate = scom.GetValue<DateTime?>("data_resgate"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Castrado = scom.GetValue<bool>("castrado"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        if (scom.GetValue<int?>("id_especie") > 0)
                        {
                            item.Especie = new Especie(scom.GetValue<int>("id_especie"), scom.GetValue<string>("EspecieNome"));
                        }

                        if (scom.GetValue<long?>("id_responsavel") > 0)
                        {
                            item.Responsavel = new Responsavel(scom.GetValue<long>("id_responsavel"), scom.GetValue<string>("RespNome"));
                        }

                        if (scom.GetValue<int?>("id_porte") > 0)
                        {
                            item.Porte = new Porte(scom.GetValue<int>("id_porte"), scom.GetValue<string>("PorteDescricao"));
                        }

                        if (scom.GetValue<int?>("id_disponibilidade") > 0)
                        {
                            item.Situacao = Disponibilidade.Obter(scom.GetValue<int>("id_disponibilidade"));
                        }

                        if (scom.GetValue<int?>("id_raca") > 0)
                        {
                            item.Raca = new Raca(scom.GetValue<int>("id_raca"), scom.GetValue<string>("RacaDescricao"));
                        }

                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(Animal animal)
        {
            if (animal == null) throw new Exception("Atenção! O objeto ANIMAL não foi instanciado para salvar.");
            else
            {
                if (animal.Id > 0) Alterar(animal);
                else Inserir(animal);
            }
        }

        private static void Inserir(Animal item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO animal (nome, id_especie, sexo, id_responsavel, observacoes, numero_chip, cor, data_chegou, data_resgate, data_nascimento, id_porte, id_disponibilidade, castrado, id_raca)");
            sSql.AppendLine("VALUES (@nome, @id_especie, @sexo, @id_responsavel, @observacoes, @numero_chip, @cor, @data_chegou, @data_resgate, @data_nascimento, @id_porte, @id_disponibilidade, @castrado, @id_raca);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@id_especie", item.Especie);
            scom.AddWithValue("@sexo", item.CSexo.ToString());
            scom.AddWithValue("@id_responsavel", item.Responsavel);
            scom.AddWithValue("@observacoes", item.SObservacoes);
            scom.AddWithValue("@numero_chip", item.SNumeroChip);
            scom.AddWithValue("@cor", item.SCor);
            scom.AddWithValue("@data_chegou", item.DtmChegou == new DateTime() ? null : item.DtmChegou);
            scom.AddWithValue("@data_resgate", item.DtmResgate == new DateTime() ? null : item.DtmResgate);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento == new DateTime() ? null : item.DtmNascimento);
            scom.AddWithValue("@id_porte", item.Porte);
            scom.AddWithValue("@id_disponibilidade", item.Situacao);
            scom.AddWithValue("@castrado", item.Castrado ? 1 : 0);
            scom.AddWithValue("@id_raca", item.Raca);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    scom.Read();
                    long i;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                    else item.Id = i;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Animal item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE animal SET");
            sSql.AppendLine("      nome               = @nome");
            sSql.AppendLine("    , id_especie         = @id_especie");
            sSql.AppendLine("    , sexo               = @sexo");
            sSql.AppendLine("    , id_responsavel     = @id_responsavel");
            sSql.AppendLine("    , observacoes        = @observacoes");
            sSql.AppendLine("    , numero_chip        = @numero_chip");
            sSql.AppendLine("    , cor                = @cor");
            sSql.AppendLine("    , data_chegou        = @data_chegou");
            sSql.AppendLine("    , data_resgate       = @data_resgate");
            sSql.AppendLine("    , data_nascimento    = @data_nascimento");
            sSql.AppendLine("    , data_ultalt        = NOW()");
            sSql.AppendLine("    , id_porte           = @id_porte");
            sSql.AppendLine("    , id_disponibilidade = @id_disponibilidade");
            sSql.AppendLine("    , castrado           = @castrado");
            sSql.AppendLine("    , status             = @status");
            sSql.AppendLine("    , id_raca            = @id_raca");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@id_especie", item.Especie);
            scom.AddWithValue("@sexo", item.CSexo.ToString());
            scom.AddWithValue("@id_responsavel", item.Responsavel);
            scom.AddWithValue("@observacoes", item.SObservacoes);
            scom.AddWithValue("@numero_chip", item.SNumeroChip);
            scom.AddWithValue("@cor", item.SCor);
            scom.AddWithValue("@data_chegou", item.DtmChegou == new DateTime() ? null : item.DtmChegou);
            scom.AddWithValue("@data_resgate", item.DtmResgate == new DateTime() ? null : item.DtmResgate);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento == new DateTime() ? null : item.DtmNascimento);
            scom.AddWithValue("@id_porte", item.Porte);
            scom.AddWithValue("@id_disponibilidade", item.Situacao);
            scom.AddWithValue("@castrado", item.Castrado ? 1 : 0);
            scom.AddWithValue("@id_raca", item.Raca);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}