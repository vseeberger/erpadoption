using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoAdotante
    {
        internal static void Salvar(Adotante item)
        {
            if (item == null) throw new Exception("Atenção! O objeto ADOTANTE não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);

                //Grava as adoções
                if(item.AnimaisAdotados != null && item.AnimaisAdotados.Count > 0)
                {
                    for (int i = 0; i < item.AnimaisAdotados.Count; i++)
                    {
                        AnimalAdotado _Adocao = item.AnimaisAdotados[i];
                        if (_Adocao.Alterado)
                        {
                            _Adocao.Adotante = item;
                            _Adocao.Salvar();
                        }
                    }
                }
            }
        }

        private static void Inserir(Adotante item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO adotante (nome, sexo, rg, cpf, profissao, email, celular, telefone, outro_contato, data_nascimento)");
            sSql.AppendLine("VALUES (@nome, @sexo, @rg, @cpf, @profissao, @email, @celular, @telefone, @outro_contato, @data_nascimento);SELECT LAST_INSERT_ID();");
            
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@sexo", item.SSexo);
            scom.AddWithValue("@rg", item.SRG);
            scom.AddWithValue("@cpf", item.SCPF);
            scom.AddWithValue("@profissao", item.SProfissao);
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@celular", item.SCelular);
            scom.AddWithValue("@telefone", item.STelefone);
            scom.AddWithValue("@outro_contato", item.SOutroContato);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long i;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i > 0)
                    {
                        item.Id = i;
                        if (item.Endereco.Id == 0)
                        {
                            item.Endereco.Salvar();
                            if (item.Endereco.Id > 0)
                            {
                                //Inativa TODOS os endereços de adotante_x_endereco para este adotante.
                                cMySqlCommand scom2 = new cMySqlCommand("UPDATE adotante_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_adotante=@id_adotante;", System.Data.CommandType.Text);
                                scom2.AddWithValue("@id_adotante", item.Id);

                                //Insere o vinculo da pessoa_x_endereco
                                scom2 = new cMySqlCommand("INSERT INTO adotante_x_endereco (id_adotante, id_endereco) VALUES (@id_adotante, @id_endereco);", System.Data.CommandType.Text);
                                scom2.AddWithValue("@id_adotante", item.Id);
                                scom2.AddWithValue("@id_endereco", item.Endereco.Id);
                                scom2.ExecuteNonQuery();
                                scom2.Close();
                            }
                        }
                    }
                    else throw new Exception("Atenção! O processo não pôde ser finalizado. Verifique os dados se foram gravados corretamente.");
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Adotante item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE adotante SET");
            sSql.AppendLine("      nome = @nome");
            sSql.AppendLine("    , sexo = @sexo");
            sSql.AppendLine("    , rg = @rg");
            sSql.AppendLine("    , cpf = @cpf");
            sSql.AppendLine("    , profissao = @profissao");
            sSql.AppendLine("    , email = @email");
            sSql.AppendLine("    , celular = @celular");
            sSql.AppendLine("    , telefone = @telefone");
            sSql.AppendLine("    , outro_contato = @outro_contato");
            sSql.AppendLine("    , id_endereco = @id_endereco");
            sSql.AppendLine("    , data_ultalt = NOW()");
            sSql.AppendLine("    , data_nascimento = @data_nascimento");
            sSql.AppendLine("    , status = @status");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@sexo", item.SSexo);
            scom.AddWithValue("@rg", item.SRG);
            scom.AddWithValue("@cpf", item.SCPF);
            scom.AddWithValue("@profissao", item.SProfissao);
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@celular", item.SCelular);
            scom.AddWithValue("@telefone", item.STelefone);
            scom.AddWithValue("@outro_contato", item.SOutroContato);
            scom.AddWithValue("@id_endereco", item.Endereco == null ? 0 : item.Endereco.Id);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);
            scom.AddWithValue("@status", item.Status);

            try
            {
                scom.ExecuteNonQuery();
                if (item.Endereco == null)
                {
                    //Inativa TODOS os endereços de pessoa_x_endereco para esta pessoa.
                    cMySqlCommand scom2 = new cMySqlCommand("UPDATE adotante_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_adotante=@id_adotante;", System.Data.CommandType.Text);
                    scom2.AddWithValue("@id_adotante", item.Id);
                    scom2.ExecuteNonQuery();
                    scom2.Close();
                }
                else if (item.Endereco.Id == 0)
                {
                    item.Endereco.Salvar();
                    if (item.Endereco.Id > 0)
                    {
                        //Inativa TODOS os endereços de adotante_x_endereco para este adotante.
                        cMySqlCommand scom2 = new cMySqlCommand("UPDATE adotante_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_adotante=@id_adotante;", System.Data.CommandType.Text);
                        scom2.AddWithValue("@id_adotante", item.Id);

                        //Insere o vinculo da pessoa_x_endereco
                        scom2 = new cMySqlCommand("INSERT INTO adotante_x_endereco (id_adotante, id_endereco) VALUES (@id_adotante, @id_endereco);", System.Data.CommandType.Text);
                        scom2.AddWithValue("@id_adotante", item.Id);
                        scom2.AddWithValue("@id_endereco", item.Endereco.Id);
                        scom2.ExecuteNonQuery();
                        scom2.Close();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Excluir(Adotante item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE adotante SET");
            sSql.AppendLine("      data_ultalt = NOW()");
            sSql.AppendLine("    , status = 0");
            sSql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Adotante Obter(long _Codigo)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     adotante.id");
            sSql.AppendLine("   , adotante.nome");
            sSql.AppendLine("   , adotante.sexo");
            sSql.AppendLine("   , adotante.rg");
            sSql.AppendLine("   , adotante.cpf");
            sSql.AppendLine("   , adotante.profissao");
            sSql.AppendLine("   , adotante.email");
            sSql.AppendLine("   , adotante.celular");
            sSql.AppendLine("   , adotante.telefone");
            sSql.AppendLine("   , adotante.outro_contato");
            sSql.AppendLine("   , adotante.id_endereco");
            sSql.AppendLine("   , adotante.data_cadastro");
            sSql.AppendLine("   , adotante.data_ultalt");
            sSql.AppendLine("   , adotante.data_nascimento");
            sSql.AppendLine("   , adotante.status");

            sSql.AppendLine("   , en.id AS Ender_ID");
            sSql.AppendLine("   , en.endereco AS Ender_ENDERECO");
            sSql.AppendLine("   , en.bairro AS Ender_BAIRRO");
            sSql.AppendLine("   , en.cidade AS Ender_CIDADE");
            sSql.AppendLine("   , en.uf AS Ender_UF");
            sSql.AppendLine("   , en.cep AS Ender_CEP");
            sSql.AppendLine("   , en.complemento AS Ender_COMPLEMENTO");
            sSql.AppendLine("   , en.numero AS Ender_NUMERO");
            sSql.AppendLine("   , en.data_cadastro AS Ender_DATACADASTRO");
            sSql.AppendLine("   , en.data_ultalt AS Ender_DATAULTALT");
            sSql.AppendLine("   , en.status AS Ender_STATUS");
            sSql.AppendLine("FROM adotante");
            sSql.AppendLine("   left join adotante_x_endereco ae ON ae.id_adotante = adotante.id AND ae.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = ae.id_endereco AND en.status = 1 ");
            sSql.AppendLine("WHERE adotante.id=@id;");
            sSql.AppendLine("");

            sSql.AppendLine("SELECT");
            sSql.AppendLine("     adocao.id AS AnimalAdocao");
            sSql.AppendLine("   , adocao.id_animal  AS AnimalID");
            sSql.AppendLine("   , adocao.id_adotante    AS AnimalADOTANTE");
            sSql.AppendLine("   , adocao.id_endereco_animal AS AnimalENDERECO");
            sSql.AppendLine("   , adocao.data_adocao    AS AnimalDataAdocao");
            sSql.AppendLine("   , adocao.data_desadocao AS AnimalDataDesadocao");
            sSql.AppendLine("   , adocao.data_cadastro  AS AnimalDataCadastro");
            sSql.AppendLine("   , adocao.data_ultalt    AS AnimalDataUltAlt");
            sSql.AppendLine("   , adocao.status AS AnimalStatus");

            sSql.AppendLine("   , endereco.id AS Ender_ID");
            sSql.AppendLine("   , endereco.endereco AS Ender_ENDERECO");
            sSql.AppendLine("   , endereco.bairro AS Ender_BAIRRO");
            sSql.AppendLine("   , endereco.cidade AS Ender_CIDADE");
            sSql.AppendLine("   , endereco.uf AS Ender_UF");
            sSql.AppendLine("   , endereco.cep AS Ender_CEP");
            sSql.AppendLine("   , endereco.complemento AS Ender_COMPLEMENTO");
            sSql.AppendLine("   , endereco.numero AS Ender_NUMERO");
            sSql.AppendLine("   , endereco.data_cadastro AS Ender_DATACADASTRO");
            sSql.AppendLine("   , endereco.data_ultalt AS Ender_DATAULTALT");
            sSql.AppendLine("   , endereco.status AS Ender_STATUS");
            
            sSql.AppendLine("   , animal.nome AS AnimalNOME");
            sSql.AppendLine("   , animal.sexo AS AnimalSEXO");
            sSql.AppendLine("   , animal.cor AS AnimalCOR");
            sSql.AppendLine("   , animal.data_chegou AS AnimalDATACHEGOU");
            sSql.AppendLine("   , animal.data_nascimento AS AnimalDATANASCIMENTO");
            sSql.AppendLine("   , animal.data_ultalt AS AnimalDATAULTALT");
            sSql.AppendLine("   , animal.data_cadastro AS AnimalDATACADASTRO");
            sSql.AppendLine("FROM adocao");
            sSql.AppendLine("LEFT JOIN animal ON animal.id = adocao.id_animal");
            sSql.AppendLine("LEFT JOIN endereco ON endereco.id = adocao.id_endereco_animal ");
            sSql.AppendLine("WHERE adocao.id_adotante = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            Adotante item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Adotante()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SSexo = scom.GetValue<string>("sexo"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            SProfissao = scom.GetValue<string>("profissao"),
                            SEmail = scom.GetValue<string>("email"),
                            SCelular = scom.GetValue<string>("celular"),
                            STelefone = scom.GetValue<string>("telefone"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),

                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<int>("status"),
                        };

                        if (scom.GetValue<long>("Ender_ID") > 0)
                        {
                            item.Endereco = new Endereco()
                            {
                                Id = scom.GetValue<long>("Ender_ID"),
                                SEndereco = scom.GetValue<string>("Ender_ENDERECO"),
                                SBairro = scom.GetValue<string>("Ender_BAIRRO"),
                                SCidade = scom.GetValue<string>("Ender_CIDADE"),
                                SUF = scom.GetValue<string>("Ender_UF"),
                                SCEP = scom.GetValue<string>("Ender_CEP"),
                                SComplemento = scom.GetValue<string>("Ender_COMPLEMENTO"),
                                SNumero = scom.GetValue<string>("Ender_NUMERO"),
                                DtmCadastro = scom.GetValue<DateTime>("Ender_DATACADASTRO"),
                                DtmUltAlt = scom.GetValue<DateTime>("Ender_DATAULTALT"),
                                Status = scom.GetValue<bool>("Ender_STATUS"),
                            };
                        }

                        item.AnimaisAdotados = new List<AnimalAdotado>();

                        scom.NextResult();
                        if (scom.HasRows)
                        {
                            AnimalAdotado _adocao = null;
                            while (scom.Read())
                            {
                                _adocao = new AnimalAdotado()
                                {
                                    Id = scom.GetValue<long>("AnimalAdocao"),
                                    Alterado = false,
                                    DtmAdocao = scom.GetValue<DateTime>("AnimalDataAdocao"),
                                    DtmDevolucao = scom.GetValue<DateTime?>("AnimalDataDesadocao"),
                                    EnderecoOndeFicaOAnimal = new Endereco()
                                    {
                                        Id = scom.GetValue<long>("AnimalENDERECO"),
                                        SEndereco = scom.GetValue<string>("Ender_ENDERECO"),
                                        SBairro = scom.GetValue<string>("Ender_BAIRRO"),
                                        SCidade = scom.GetValue<string>("Ender_CIDADE"),
                                        SUF = scom.GetValue<string>("Ender_UF"),
                                        SCEP = scom.GetValue<string>("Ender_CEP"),
                                        SComplemento = scom.GetValue<string>("Ender_COMPLEMENTO"),
                                        SNumero = scom.GetValue<string>("Ender_NUMERO"),
                                        DtmCadastro = scom.GetValue<DateTime>("Ender_DATACADASTRO"),
                                        DtmUltAlt = scom.GetValue<DateTime>("Ender_DATAULTALT"),
                                        Status = scom.GetValue<bool>("Ender_STATUS"),
                                    },
                                    Status = scom.GetValue<bool>("AnimalStatus"),
                                    Animal = new Animal()
                                    {
                                        Id = scom.GetValue<long>("AnimalID"),
                                        SNome = scom.GetValue<string>("AnimalNOME"),
                                        CSexo = char.Parse(scom.GetValue<string>("AnimalSEXO")),
                                        SCor = scom.GetValue<string>("AnimalCOR"),
                                        DtmChegou = scom.GetValue<DateTime?>("AnimalDATACHEGOU"),
                                        DtmNascimento = scom.GetValue<DateTime?>("AnimalDATANASCIMENTO"),
                                        DtmCadastro = scom.GetValue<DateTime>("AnimalDATACADASTRO"),
                                        DtmUltAlt = scom.GetValue<DateTime>("AnimalDATAULTALT"),
                                    },
                                    Adotante = new Adotante(scom.GetValue<long>("AnimalADOTANTE")),
                                    DtmCadastro = scom.GetValue<DateTime>("AnimalDataCadastro"),
                                    DtmUltAlt = scom.GetValue<DateTime>("AnimalDataUltAlt"),
                                };
                                
                                item.AnimaisAdotados.Add(_adocao);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static List<Adotante> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     adotante.id");
            sSql.AppendLine("   , adotante.nome");
            sSql.AppendLine("   , adotante.sexo");
            sSql.AppendLine("   , adotante.rg");
            sSql.AppendLine("   , adotante.cpf");
            sSql.AppendLine("   , adotante.profissao");
            sSql.AppendLine("   , adotante.email");
            sSql.AppendLine("   , adotante.celular");
            sSql.AppendLine("   , adotante.telefone");
            sSql.AppendLine("   , adotante.outro_contato");
            sSql.AppendLine("   , adotante.id_endereco");
            sSql.AppendLine("   , adotante.data_cadastro");
            sSql.AppendLine("   , adotante.data_ultalt");
            sSql.AppendLine("   , adotante.data_nascimento");
            sSql.AppendLine("   , adotante.status");

            sSql.AppendLine("   , en.id AS Ender_ID");
            sSql.AppendLine("   , en.endereco AS Ender_ENDERECO");
            sSql.AppendLine("   , en.bairro AS Ender_BAIRRO");
            sSql.AppendLine("   , en.cidade AS Ender_CIDADE");
            sSql.AppendLine("   , en.uf AS Ender_UF");
            sSql.AppendLine("   , en.cep AS Ender_CEP");
            sSql.AppendLine("   , en.complemento AS Ender_COMPLEMENTO");
            sSql.AppendLine("   , en.numero AS Ender_NUMERO");
            sSql.AppendLine("   , en.data_cadastro AS Ender_DATACADASTRO");
            sSql.AppendLine("   , en.data_ultalt AS Ender_DATAULTALT");
            sSql.AppendLine("   , en.status AS Ender_STATUS");
            sSql.AppendLine("	, IFNULL((SELECT COUNT(*) ");
            sSql.AppendLine("		 FROM adocao ");
            sSql.AppendLine("		 WHERE adocao.id_adotante = adotante.id");
            sSql.AppendLine("		 	AND adocao.status = 1");
            sSql.AppendLine("		 	AND adocao.data_desadocao is null");
            sSql.AppendLine("		),0) AS QtdAnimais");
            sSql.AppendLine("FROM adotante");
            sSql.AppendLine("   left join adotante_x_endereco ae ON ae.id_adotante = adotante.id AND ae.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = ae.id_endereco AND en.status = 1 ");
            sSql.AppendLine("WHERE adotante.status > 0;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Adotante> Lst = new List<Adotante>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Adotante>();
                    Adotante item = null;
                    while (scom.Read())
                    {
                        item = new Adotante()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SSexo = scom.GetValue<string>("sexo"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            SProfissao = scom.GetValue<string>("profissao"),
                            SEmail = scom.GetValue<string>("email"),
                            SCelular = scom.GetValue<string>("celular"),
                            STelefone = scom.GetValue<string>("telefone"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),

                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<int>("status"),
                        };

                        item.IQtdAnimais = Convert.ToInt32(scom.GetValue<object>("QtdAnimais"));

                        if (scom.GetValue<long>("Ender_ID") > 0)
                        {
                            item.Endereco = new Endereco()
                            {
                                Id = scom.GetValue<long>("Ender_ID"),
                                SEndereco = scom.GetValue<string>("Ender_ENDERECO"),
                                SBairro = scom.GetValue<string>("Ender_BAIRRO"),
                                SCidade = scom.GetValue<string>("Ender_CIDADE"),
                                SUF = scom.GetValue<string>("Ender_UF"),
                                SCEP = scom.GetValue<string>("Ender_CEP"),
                                SComplemento = scom.GetValue<string>("Ender_COMPLEMENTO"),
                                SNumero = scom.GetValue<string>("Ender_NUMERO"),
                                DtmCadastro = scom.GetValue<DateTime>("Ender_DATACADASTRO"),
                                DtmUltAlt = scom.GetValue<DateTime>("Ender_DATAULTALT"),
                                Status = scom.GetValue<bool>("Ender_STATUS"),
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
    }
}