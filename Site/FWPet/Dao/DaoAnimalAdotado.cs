using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoAnimalAdotado
    {
        internal static void Salvar(AnimalAdotado item)
        {
            if (item == null) throw new Exception("Atenção! O objeto ANIMALADOTADO não foi instanciado para salvar.");
            else { Inserir(item); }
        }

        private static void Inserir(AnimalAdotado item)
        {
            //Antes de inserir a adoção, cadastro o endereço caso o ID == 0
            if (!item.EnderecoDoAdotante && item.EnderecoOndeFicaOAnimal.Id == 0)
            {
                item.EnderecoOndeFicaOAnimal.Salvar();
                Conexao.GravarLogFW("SALVOU O REGISTRO DO ENDEREÇO CODIGO " + item.EnderecoOndeFicaOAnimal.Id, item.GetType());
            }
            else item.EnderecoOndeFicaOAnimal = item.Adotante.Endereco;

            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("REPLACE INTO adocao (id, id_animal, id_adotante, id_endereco_animal, data_adocao, data_desadocao)");
            sSql.AppendLine("VALUES(@id, @id_animal, @id_adotante, @id_endereco_animal, @data_adocao, @data_desadocao);");
            sSql.AppendLine("UPDATE animal SET id_disponibilidade = 3, data_ultalt=NOW() WHERE id=@id_animal;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_animal", item.Animal);
            scom.AddWithValue("@id_adotante", item.Adotante);
            scom.AddWithValue("@id_endereco_animal", item.EnderecoOndeFicaOAnimal);
            scom.AddWithValue("@data_adocao", item.DtmAdocao);
            scom.AddWithValue("@data_desadocao", item.DtmDevolucao);

            try
            {
                scom.ExecuteNonQuery();
                Conexao.GravarLogFW("INSERIU O REGISTRO DE ADOÇÃO CODIGO " + item.Id + " - Animal: " + item.Animal.SNome, item.GetType());
                Conexao.GravarLogFW("ATUALIZOU O REGISTRO DO ANIMAL CODIGO " + item.Animal.Id + " - SITUAÇÃO: 3 - ADOTADO ", item.Animal.GetType());
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<AnimalAdotado> Pesquisar(long? _Adotante, long? _Animal, int _Tipo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      adocao.id");
            sql.AppendLine("    , adocao.id_animal");
            sql.AppendLine("    , adocao.id_adotante");
            sql.AppendLine("    , adocao.id_endereco_animal");
            sql.AppendLine("    , adocao.data_adocao");
            sql.AppendLine("    , adocao.data_desadocao");

            sql.AppendLine("    , animal.nome AS AnimalNome");
            sql.AppendLine("    , animal.sexo AS AnimalSexo");
            sql.AppendLine("    , animal.cor AS AnimalCor");
            sql.AppendLine("    , animal.data_nascimento AS AnimalDataNascimento");

            sql.AppendLine("    , adotante.nome AS AdotanteNome");
            sql.AppendLine("    , adotante.sexo AS AdotanteSexo");
            sql.AppendLine("    , adotante.rg AS AdotanteRG");
            sql.AppendLine("    , adotante.cpf AS AdotanteCPF");
            sql.AppendLine("    , adotante.email AS AdotanteEMAIL");
            sql.AppendLine("    , adotante.celular AS AdotanteCelular");
            sql.AppendLine("    , adotante.telefone AS AdotanteTelefone");
            sql.AppendLine("    , adotante.outro_contato AS AdotanteOutrosContatos");

            sql.AppendLine("    , endereco.endereco AS EnderecoEndereco");
            sql.AppendLine("    , endereco.bairro AS EnderecoBairro");
            sql.AppendLine("    , endereco.cidade AS EnderecoCidade");
            sql.AppendLine("    , endereco.uf AS EnderecoUF");
            sql.AppendLine("    , endereco.cep AS EnderecoCEP");
            sql.AppendLine("    , endereco.complemento AS EnderecoComplemento");
            sql.AppendLine("    , endereco.numero AS EnderecoNumero");

            sql.AppendLine("FROM adocao ");
            sql.AppendLine("    LEFT JOIN animal ON animal.id = adocao.id_animal");
            sql.AppendLine("    LEFT JOIN adotante ON adotante.id = adocao.id_adotante");
            sql.AppendLine("    LEFT JOIN endereco ON endereco.id = adocao.id_endereco_animal");
            sql.AppendLine("WHERE 1=1");

            if (_Tipo > 0) sql.AppendLine(" AND animal.id_disponibilidade = @TIPO");
            if (_Adotante != null) sql.AppendLine(" AND adotante.id = @id_adotante");
            if (_Animal != null) sql.AppendLine(" AND animal.id = @id_animal");

            sql.AppendLine("ORDER BY adocao.data_adocao");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@TIPO", _Tipo);
            scom.AddWithValue("@id_adotante", _Adotante);
            scom.AddWithValue("@id_animal", _Animal);

            List<AnimalAdotado> Lst = new List<AnimalAdotado>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalAdotado>();
                    AnimalAdotado item = null;
                    while (scom.Read())
                    {
                        item = new AnimalAdotado()
                        {
                            Id = scom.GetValue<long>("id"),
                            DtmAdocao = scom.GetValue<DateTime>("data_adocao"),
                            DtmDevolucao = scom.GetValue<DateTime?>("data_desadocao"),
                        };

                        if (scom.GetValue<object>("id_animal") != null)
                        {
                            item.Animal = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal"),
                                SNome = scom.GetValue<string>("AnimalNome"),
                                SCor = scom.GetValue<string>("AnimalCor"),
                                CSexo = Convert.ToChar(scom.GetValue<string>("AnimalSexo")),
                                DtmNascimento = scom.GetValue<DateTime?>("AnimalDataNascimento")
                            };
                        }

                        if (scom.GetValue<object>("id_adotante") != null)
                        {
                            item.Adotante = new Adotante()
                            {
                                Id = scom.GetValue<long>("id_adotante"),
                                SNome = scom.GetValue<string>("AdotanteNome"),
                                SSexo = scom.GetValue<string>("AdotanteSexo"),
                                SRG = scom.GetValue<string>("AdotanteRG"),
                                SCPF = scom.GetValue<string>("AdotanteCPF"),
                                SEmail = scom.GetValue<string>("AdotanteEMAIL"),
                                SCelular = scom.GetValue<string>("AdotanteCelular"),
                                STelefone = scom.GetValue<string>("AdotanteTelefone"),
                                SOutroContato = scom.GetValue<string>("AdotanteOutrosContatos"),
                            };
                        }

                        if (scom.GetValue<object>("id_endereco_animal") != null)
                        {
                            item.EnderecoOndeFicaOAnimal = new Endereco()
                            {
                                Id = scom.GetValue<long>("id_endereco_animal"),
                                SEndereco = scom.GetValue<string>("EnderecoEndereco"),
                                SBairro = scom.GetValue<string>("EnderecoBairro"),
                                SCidade = scom.GetValue<string>("EnderecoCidade"),
                                SUF = scom.GetValue<string>("EnderecoUF"),
                                SCEP = scom.GetValue<string>("EnderecoCEP"),
                                SComplemento = scom.GetValue<string>("EnderecoComplemento"),
                                SNumero = scom.GetValue<string>("EnderecoNumero"),
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

        internal static void Desistir(AnimalAdotado item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE adocao SET data_desadocao = NOW(), data_ultalt = NOW()");
            sSql.AppendLine("WHERE id = @id AND data_desadocao IS NULL;");
            sSql.AppendLine("UPDATE animal SET id_disponibilidade = 1, data_ultalt=NOW() WHERE id=@id_animal AND id_disponibilidade != 1;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_animal", item.Animal);

            try
            {
                scom.ExecuteNonQuery();
                Conexao.GravarLogFW("ATUALIZOU O REGISTRO DO ANIMAL PARA SITUAÇÃO DISPONÍVEL, CODIGO " + item.Animal.Id, item.Animal.GetType());
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static AnimalAdotado Obter(long _AdocaoID)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      adocao.id");
            sql.AppendLine("    , adocao.id_animal");
            sql.AppendLine("    , adocao.id_adotante");
            sql.AppendLine("    , adocao.id_endereco_animal");
            sql.AppendLine("    , adocao.data_adocao");
            sql.AppendLine("    , adocao.data_desadocao");
            sql.AppendLine("    , adocao.data_cadastro");
            sql.AppendLine("    , adocao.data_ultalt");
            sql.AppendLine("    , adocao.status");

            sql.AppendLine("    , animal.nome AS AnimalNome");
            sql.AppendLine("    , animal.sexo AS AnimalSexo");
            sql.AppendLine("    , animal.cor AS AnimalCor");
            sql.AppendLine("    , animal.data_nascimento AS AnimalDataNascimento");

            sql.AppendLine("    , adotante.nome AS AdotanteNome");
            sql.AppendLine("    , adotante.sexo AS AdotanteSexo");
            sql.AppendLine("    , adotante.rg AS AdotanteRG");
            sql.AppendLine("    , adotante.cpf AS AdotanteCPF");
            sql.AppendLine("    , adotante.email AS AdotanteEMAIL");
            sql.AppendLine("    , adotante.celular AS AdotanteCelular");
            sql.AppendLine("    , adotante.telefone AS AdotanteTelefone");
            sql.AppendLine("    , adotante.outro_contato AS AdotanteOutrosContatos");

            sql.AppendLine("    , endereco.endereco AS EnderecoEndereco");
            sql.AppendLine("    , endereco.bairro AS EnderecoBairro");
            sql.AppendLine("    , endereco.cidade AS EnderecoCidade");
            sql.AppendLine("    , endereco.uf AS EnderecoUF");
            sql.AppendLine("    , endereco.cep AS EnderecoCEP");
            sql.AppendLine("    , endereco.complemento AS EnderecoComplemento");
            sql.AppendLine("    , endereco.numero AS EnderecoNumero");

            sql.AppendLine("FROM adocao ");
            sql.AppendLine("    LEFT JOIN animal ON animal.id = adocao.id_animal");
            sql.AppendLine("    LEFT JOIN adotante ON adotante.id = adocao.id_adotante");
            sql.AppendLine("    LEFT JOIN endereco ON endereco.id = adocao.id_endereco_animal");
            sql.AppendLine("WHERE adocao.id = @id");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _AdocaoID);

            AnimalAdotado item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        Animal _animal = null;
                        Adotante _adotante = null;
                        Endereco _endereco = null;

                        if (scom.GetValue<object>("id_animal") != null)
                        {
                            _animal = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal"),
                                SNome = scom.GetValue<string>("AnimalNome"),
                                SCor = scom.GetValue<string>("AnimalCor"),
                                CSexo = Convert.ToChar(scom.GetValue<string>("AnimalSexo")),
                                DtmNascimento = scom.GetValue<DateTime?>("AnimalDataNascimento")
                            };
                        }

                        if (scom.GetValue<object>("id_adotante") != null)
                        {
                            _adotante = new Adotante()
                            {
                                Id = scom.GetValue<long>("id_adotante"),
                                SNome = scom.GetValue<string>("AdotanteNome"),
                                SSexo = scom.GetValue<string>("AdotanteSexo"),
                                SRG = scom.GetValue<string>("AdotanteRG"),
                                SCPF = scom.GetValue<string>("AdotanteCPF"),
                                SEmail = scom.GetValue<string>("AdotanteEMAIL"),
                                SCelular = scom.GetValue<string>("AdotanteCelular"),
                                STelefone = scom.GetValue<string>("AdotanteTelefone"),
                                SOutroContato = scom.GetValue<string>("AdotanteOutrosContatos"),
                            };
                        }

                        if (scom.GetValue<object>("id_endereco_animal") != null)
                        {
                            _endereco = new Endereco()
                            {
                                Id = scom.GetValue<long>("id_endereco_animal"),
                                SEndereco = scom.GetValue<string>("EnderecoEndereco"),
                                SBairro = scom.GetValue<string>("EnderecoBairro"),
                                SCidade = scom.GetValue<string>("EnderecoCidade"),
                                SUF = scom.GetValue<string>("EnderecoUF"),
                                SCEP = scom.GetValue<string>("EnderecoCEP"),
                                SComplemento = scom.GetValue<string>("EnderecoComplemento"),
                                SNumero = scom.GetValue<string>("EnderecoNumero"),
                            };
                        }

                        item = new AnimalAdotado()
                        {
                            Id = scom.GetValue<long>("id"),
                            DtmAdocao = scom.GetValue<DateTime>("data_adocao"),
                            DtmDevolucao = scom.GetValue<DateTime?>("data_desadocao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            Adotante = _adotante,
                            Animal = _animal,
                            EnderecoOndeFicaOAnimal = _endereco,
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
    }
}