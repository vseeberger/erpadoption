using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoVeterinario
    {
        internal static void Salvar(Veterinario item)
        {
            if (item == null) throw new Exception("Atenção! O objeto RESPONSÁVEL não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        internal static List<Veterinario> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     pessoa.id");
            sSql.AppendLine("   , pessoa.nome");
            sSql.AppendLine("   , pessoa.rg");
            sSql.AppendLine("   , pessoa.cpf");
            sSql.AppendLine("   , pessoa.data_cadastro");
            sSql.AppendLine("   , pessoa.data_ultalt");
            sSql.AppendLine("   , pessoa.data_nascimento");
            sSql.AppendLine("   , pessoa.tipo");
            sSql.AppendLine("   , pessoa.sexo");
            sSql.AppendLine("   , pessoa.status");
            sSql.AppendLine("   , pessoa.email");
            sSql.AppendLine("   , pessoa.telefone");
            sSql.AppendLine("   , pessoa.celular");
            sSql.AppendLine("   , pessoa.outro_contato");
            sSql.AppendLine("   , pessoa.crmv");

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
            
            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("   left join pessoa_x_endereco pe ON pe.id_pessoa = pessoa.id AND pe.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = pe.id_endereco AND en.status = 1 ");

            sSql.AppendLine("WHERE pessoa.status=1");
            sSql.AppendLine("AND pessoa.tipo='V';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Veterinario> Lst = new List<Veterinario>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Veterinario>();
                    Veterinario item = null;
                    while (scom.Read())
                    {
                        item = new Veterinario()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            CTipo = scom.GetValue<char>("tipo"),
                            SSexo = scom.GetValue<string>("sexo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<bool>("status"),
                            SCelular = scom.GetValue<string>("celular"),
                            SEmail = scom.GetValue<string>("email"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),
                            STelefone = scom.GetValue<string>("telefone"),
                            SCRMV = scom.GetValue<string>("crmv")
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

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(Veterinario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE pessoa SET ");
            sSql.AppendLine("      ativo            = 0");
            sSql.AppendLine("    , data_ultalt      = NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Veterinario Obter(long _Responsavel)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     pessoa.id");
            sSql.AppendLine("   , pessoa.nome");
            sSql.AppendLine("   , pessoa.rg");
            sSql.AppendLine("   , pessoa.cpf");
            sSql.AppendLine("   , pessoa.data_cadastro");
            sSql.AppendLine("   , pessoa.data_ultalt");
            sSql.AppendLine("   , pessoa.data_nascimento");
            sSql.AppendLine("   , pessoa.tipo");
            sSql.AppendLine("   , pessoa.sexo");
            sSql.AppendLine("   , pessoa.status");
            sSql.AppendLine("   , pessoa.email");
            sSql.AppendLine("   , pessoa.telefone");
            sSql.AppendLine("   , pessoa.celular");
            sSql.AppendLine("   , pessoa.outro_contato");
            sSql.AppendLine("   , pessoa.crmv");

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
            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("   left join pessoa_x_endereco pe ON pe.id_pessoa = pessoa.id AND pe.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = pe.id_endereco AND en.status = 1 ");
            sSql.AppendLine("WHERE pessoa.id=@id");
            sSql.AppendLine("AND pessoa.tipo='V';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Responsavel);

            Veterinario item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Veterinario()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SRG = scom.GetValue<string>("rg"),
                            SCPF = scom.GetValue<string>("cpf"),
                            CTipo = scom.GetValue<char>("tipo"),
                            SSexo = scom.GetValue<string>("sexo"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            DtmNascimento = scom.GetValue<DateTime?>("data_nascimento"),
                            Status = scom.GetValue<bool>("status"),
                            SCelular = scom.GetValue<string>("celular"),
                            SEmail = scom.GetValue<string>("email"),
                            SOutroContato = scom.GetValue<string>("outro_contato"),
                            STelefone = scom.GetValue<string>("telefone"),
                            SCRMV = scom.GetValue<string>("crmv")
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
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        private static void Inserir(Veterinario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO pessoa (nome, rg, cpf, data_nascimento, tipo, sexo, email, celular, telefone, outro_contato,crmv)");
            sSql.AppendLine("VALUES (@nome, @rg, @cpf, @data_nascimento, 'V', @sexo, @email, @celular, @telefone, @outro_contato,@crmv);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@rg", item.SRG);
            scom.AddWithValue("@cpf", item.SCPF);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);
            scom.AddWithValue("@sexo", item.SSexo);
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@celular", item.SCelular);
            scom.AddWithValue("@telefone", item.STelefone);
            scom.AddWithValue("@outro_contato", item.SOutroContato);
            scom.AddWithValue("@crmv", item.SCRMV);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long i;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out i);
                    if (i > 0) item.Id = i;
                    else throw new Exception("Atenção! O processo não pôde ser finalizado. Verifique os dados se foram gravados corretamente.");

                    if (item.Endereco == null)
                    {
                        //Inativa TODOS os endereços de pessoa_x_endereco para esta pessoa.
                        cMySqlCommand scom2 = new cMySqlCommand("UPDATE pessoa_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_pessoa=@id_pessoa;", System.Data.CommandType.Text);
                        scom2.AddWithValue("@id_pessoa", item.Id);
                        scom2.ExecuteNonQuery();
                        scom2.Close();
                    }
                    else if (item.Endereco.Id == 0)
                    {
                        item.Endereco.Salvar();
                        if (item.Endereco.Id > 0)
                        {
                            //Inativa TODOS os endereços de pessoa_x_endereco para esta pessoa.
                            cMySqlCommand scom2 = new cMySqlCommand("UPDATE pessoa_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_pessoa=@id_pessoa;", System.Data.CommandType.Text);
                            scom2.AddWithValue("@id_pessoa", item.Id);

                            //Insere o vinculo da pessoa_x_endereco
                            scom2 = new cMySqlCommand("INSERT INTO pessoa_x_endereco (id_pessoa, id_endereco) VALUES (@id_pessoa, @id_endereco);", System.Data.CommandType.Text);
                            scom2.AddWithValue("@id_pessoa", item.Id);
                            scom2.AddWithValue("@id_endereco", item.Endereco.Id);
                            scom2.ExecuteNonQuery();
                            scom2.Close();
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Veterinario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE pessoa SET ");
            sSql.AppendLine("      nome             = @nome");
            sSql.AppendLine("    , rg               = @rg");
            sSql.AppendLine("    , cpf              = @cpf");
            sSql.AppendLine("    , data_ultalt      = NOW()");
            sSql.AppendLine("    , data_nascimento  = @data_nascimento");
            sSql.AppendLine("    , sexo             = @sexo");
            sSql.AppendLine("    , email            = @email");
            sSql.AppendLine("    , celular          = @celular");
            sSql.AppendLine("    , telefone         = @telefone");
            sSql.AppendLine("    , outro_contato    = @outro_contato");
            sSql.AppendLine("    , crmv             = @crmv");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@rg", item.SRG);
            scom.AddWithValue("@cpf", item.SCPF);
            scom.AddWithValue("@data_nascimento", item.DtmNascimento);
            scom.AddWithValue("@sexo", item.SSexo);
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@celular", item.SCelular);
            scom.AddWithValue("@telefone", item.STelefone);
            scom.AddWithValue("@outro_contato", item.SOutroContato);
            scom.AddWithValue("@crmv", item.SCRMV);
            scom.AddWithValue("@id", item.Id);
            try
            {
                scom.ExecuteNonQuery();

                if (item.Endereco == null)
                {
                    //Inativa TODOS os endereços de pessoa_x_endereco para esta pessoa.
                    cMySqlCommand scom2 = new cMySqlCommand("UPDATE pessoa_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_pessoa=@id_pessoa;", System.Data.CommandType.Text);
                    scom2.AddWithValue("@id_pessoa", item.Id);
                    scom2.ExecuteNonQuery();
                    scom2.Close();
                }
                else if (item.Endereco.Id == 0)
                {
                    item.Endereco.Salvar();
                    if (item.Endereco.Id > 0)
                    {
                        //Inativa TODOS os endereços de pessoa_x_endereco para esta pessoa.
                        cMySqlCommand scom2 = new cMySqlCommand("UPDATE pessoa_x_endereco SET ativo=0, data_ultalt=NOW() WHERE id_pessoa=@id_pessoa;", System.Data.CommandType.Text);
                        scom2.AddWithValue("@id_pessoa", item.Id);

                        //Insere o vinculo da pessoa_x_endereco
                        scom2 = new cMySqlCommand("INSERT INTO pessoa_x_endereco (id_pessoa, id_endereco) VALUES (@id_pessoa, @id_endereco);", System.Data.CommandType.Text);
                        scom2.AddWithValue("@id_pessoa", item.Id);
                        scom2.AddWithValue("@id_endereco", item.Endereco.Id);
                        scom2.ExecuteNonQuery();
                        scom2.Close();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
