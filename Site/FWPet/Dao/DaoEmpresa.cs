using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoEmpresa
    {
        internal static List<Empresa> Pesquisar(string _Tipo)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status, tipocadastro ");
            sSql.AppendLine("FROM fornecedor ");
            sSql.AppendLine("WHERE status=1 AND tipocadastro = @tipo;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@tipo", _Tipo);

            List<Empresa> Lst = new List<Empresa>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Empresa>();
                    Empresa item = null;
                    while (scom.Read())
                    {
                        item = new Empresa()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                            STipoCadastro = scom.GetValue<string>("tipocadastro")
                        };

                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Empresa Obter(long _Empresa, string _Tipo)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status ");
            sSql.AppendLine("FROM fornecedor ");
            sSql.AppendLine("WHERE id=@id AND tipocadastro = @tipo;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Empresa);
            scom.AddWithValue("@tipo", _Tipo);
            Empresa item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Empresa()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void SalvarEmpresa(Empresa item)
        {
            if (item == null) throw new Exception("Atenção! O objeto EMPRESA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) AlterarEmpresa(item);
                else InserirEmpresa(item);
            }
        }

        private static void AlterarEmpresa(Empresa item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE fornecedor SET");
            sSql.AppendLine("     razaosocial_nome      = @razaosocial_nome");
            sSql.AppendLine("   , nomefantasia_apelido  = @nomefantasia_apelido");
            sSql.AppendLine("   , email                 = @email");
            sSql.AppendLine("   , site                  = @site");
            sSql.AppendLine("   , data_fundacao_nasc    = @data_fundacao_nasc");
            sSql.AppendLine("   , tipo_pessoa           = @tipo_pessoa");
            sSql.AppendLine("   , cnpj_cpf              = @cnpj_cpf");
            sSql.AppendLine("   , insc_municipal        = @insc_municipal");
            sSql.AppendLine("   , insc_estadual         = @insc_estadual");
            sSql.AppendLine("   , endereco              = @endereco");
            sSql.AppendLine("   , endereco_numero       = @endereco_numero");
            sSql.AppendLine("   , endereco_bairro       = @endereco_bairro");
            sSql.AppendLine("   , endereco_cidade       = @endereco_cidade");
            sSql.AppendLine("   , endereco_uf           = @endereco_uf");
            sSql.AppendLine("   , endereco_cep          = @endereco_cep");
            sSql.AppendLine("   , endereco_observacoes  = @endereco_observacoes");
            sSql.AppendLine("   , tipocadastro			= @tipocadastro");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf + "");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", item.STipoCadastro + "");
        }

        private static void InserirEmpresa(Empresa item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO fornecedor (razaosocial_nome, nomefantasia_apelido, email, site, data_fundacao_nasc, tipo_pessoa, cnpj_cpf, insc_municipal, insc_estadual, endereco, endereco_numero, endereco_bairro, endereco_cidade, endereco_uf, endereco_cep, endereco_observacoes, tipocadastro)");
            sSql.AppendLine("VALUES (@razaosocial_nome, @nomefantasia_apelido, @email, @site, @data_fundacao_nasc, @tipo_pessoa, @cnpj_cpf, @insc_municipal, @insc_estadual, @endereco, @endereco_numero, @endereco_bairro, @endereco_cidade, @endereco_uf, @endereco_cep, @endereco_observacoes, @tipocadastro);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf + "");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", item.STipoCadastro + "");
            try
            {
                scom.ExecuteReader();
                int i = 0;
                if (scom.HasRows)
                {
                    scom.Read();
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                }

                if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                else item.Id = i;
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void ExcluirEmpresa(Empresa item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE fornecedor SET");
            sSql.AppendLine("     status      = 0");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        #region CLINICA
        internal static void SalvarClinica(LaboratorioClinico item)
        {
            if (item == null) throw new Exception("Atenção! O objeto LABORATORIOCLINICO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) AlterarClinica(item);
                else InserirClinica(item);
            }
        }

        private static void InserirClinica(LaboratorioClinico item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO clinica (razaosocial_nome, nomefantasia_apelido, email, site, data_fundacao_nasc, tipo_pessoa, cnpj_cpf, insc_municipal, insc_estadual, endereco, endereco_numero, endereco_bairro, endereco_cidade, endereco_uf, endereco_cep, endereco_observacoes, tipocadastro)");
            sSql.AppendLine("VALUES (@razaosocial_nome, @nomefantasia_apelido, @email, @site, @data_fundacao_nasc, @tipo_pessoa, @cnpj_cpf, @insc_municipal, @insc_estadual, @endereco, @endereco_numero, @endereco_bairro, @endereco_cidade, @endereco_uf, @endereco_cep, @endereco_observacoes, @tipocadastro);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf + "");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", "C");
            try
            {
                scom.ExecuteReader();
                int i = 0;
                if (scom.HasRows)
                {
                    scom.Read();
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                }

                if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                else item.Id = i;
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void AlterarClinica(LaboratorioClinico item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE clinica SET");
            sSql.AppendLine("     razaosocial_nome      = @razaosocial_nome");
            sSql.AppendLine("   , nomefantasia_apelido  = @nomefantasia_apelido");
            sSql.AppendLine("   , email                 = @email");
            sSql.AppendLine("   , site                  = @site");
            sSql.AppendLine("   , data_fundacao_nasc    = @data_fundacao_nasc");
            sSql.AppendLine("   , tipo_pessoa           = @tipo_pessoa");
            sSql.AppendLine("   , cnpj_cpf              = @cnpj_cpf");
            sSql.AppendLine("   , insc_municipal        = @insc_municipal");
            sSql.AppendLine("   , insc_estadual         = @insc_estadual");
            sSql.AppendLine("   , endereco              = @endereco");
            sSql.AppendLine("   , endereco_numero       = @endereco_numero");
            sSql.AppendLine("   , endereco_bairro       = @endereco_bairro");
            sSql.AppendLine("   , endereco_cidade       = @endereco_cidade");
            sSql.AppendLine("   , endereco_uf           = @endereco_uf");
            sSql.AppendLine("   , endereco_cep          = @endereco_cep");
            sSql.AppendLine("   , endereco_observacoes  = @endereco_observacoes");
            sSql.AppendLine("   , tipocadastro			= @tipocadastro");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf + "");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", "L");
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void ExcluirClinica(LaboratorioClinico item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE clinica SET");
            sSql.AppendLine("     status      = 0");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<LaboratorioClinico> PesquisarClinica()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status, tipocadastro ");
            sSql.AppendLine("FROM clinica ");
            sSql.AppendLine("WHERE status=1 AND tipocadastro = 'C';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);

            List<LaboratorioClinico> Lst = new List<LaboratorioClinico>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<LaboratorioClinico>();
                    LaboratorioClinico item = null;
                    while (scom.Read())
                    {
                        item = new LaboratorioClinico()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                            STipoCadastro = scom.GetValue<string>("tipocadastro")
                        };

                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static LaboratorioClinico ObterClinica(long _Empresa)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status ");
            sSql.AppendLine("FROM clinica ");
            sSql.AppendLine("WHERE id=@id AND tipocadastro = 'C';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Empresa);
            LaboratorioClinico item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new LaboratorioClinico()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }
        #endregion

        #region LABORATÓRIO
        internal static void SalvarLaboratorio(Laboratorio item)
        {
            if (item == null) throw new Exception("Atenção! O objeto LABORATORIO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) AlterarLaboratorio(item);
                else InserirLaboratorio(item);
            }
        }

        private static void InserirLaboratorio(Laboratorio item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO fornecedor (razaosocial_nome, nomefantasia_apelido, email, site, data_fundacao_nasc, tipo_pessoa, cnpj_cpf, insc_municipal, insc_estadual, endereco, endereco_numero, endereco_bairro, endereco_cidade, endereco_uf, endereco_cep, endereco_observacoes, tipocadastro)");
            sSql.AppendLine("VALUES (@razaosocial_nome, @nomefantasia_apelido, @email, @site, @data_fundacao_nasc, @tipo_pessoa, @cnpj_cpf, @insc_municipal, @insc_estadual, @endereco, @endereco_numero, @endereco_bairro, @endereco_cidade, @endereco_uf, @endereco_cep, @endereco_observacoes, @tipocadastro);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf+"");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", "L");
            try
            {
                scom.ExecuteReader();
                int i=0;
                if (scom.HasRows)
                {
                    scom.Read();
                    int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                }
                
                if (i == 0) throw new Exception("Atenção! Os dados podem não ter sido gravados, verifique no sistema!");
                else item.Id = i;
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void AlterarLaboratorio(Laboratorio item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE fornecedor SET");
            sSql.AppendLine("     razaosocial_nome      = @razaosocial_nome");
            sSql.AppendLine("   , nomefantasia_apelido  = @nomefantasia_apelido");
            sSql.AppendLine("   , email                 = @email");
            sSql.AppendLine("   , site                  = @site");
            sSql.AppendLine("   , data_fundacao_nasc    = @data_fundacao_nasc");
            sSql.AppendLine("   , tipo_pessoa           = @tipo_pessoa");
            sSql.AppendLine("   , cnpj_cpf              = @cnpj_cpf");
            sSql.AppendLine("   , insc_municipal        = @insc_municipal");
            sSql.AppendLine("   , insc_estadual         = @insc_estadual");
            sSql.AppendLine("   , endereco              = @endereco");
            sSql.AppendLine("   , endereco_numero       = @endereco_numero");
            sSql.AppendLine("   , endereco_bairro       = @endereco_bairro");
            sSql.AppendLine("   , endereco_cidade       = @endereco_cidade");
            sSql.AppendLine("   , endereco_uf           = @endereco_uf");
            sSql.AppendLine("   , endereco_cep          = @endereco_cep");
            sSql.AppendLine("   , endereco_observacoes  = @endereco_observacoes");
            sSql.AppendLine("   , tipocadastro			= @tipocadastro");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@razaosocial_nome", item.SRazaoSocial + "");
            scom.AddWithValue("@nomefantasia_apelido", item.SNomeFantasia + "");
            scom.AddWithValue("@email", item.SEmail + "");
            scom.AddWithValue("@site", item.SSite + "");
            scom.AddWithValue("@data_fundacao_nasc", item.DtmFundacao == null ? DateTime.Today : item.DtmFundacao);
            scom.AddWithValue("@tipo_pessoa", item.ITipoPessoa);
            scom.AddWithValue("@cnpj_cpf", item.SCnpjCpf + "");
            scom.AddWithValue("@insc_municipal", item.SInscricaoMunicipal + "");
            scom.AddWithValue("@insc_estadual", item.SInscricaoEstadual + "");
            scom.AddWithValue("@endereco", item.SEndereco + "");
            scom.AddWithValue("@endereco_numero", item.SEnderecoNumero + "");
            scom.AddWithValue("@endereco_bairro", item.SEnderecoBairro + "");
            scom.AddWithValue("@endereco_cidade", item.SEnderecoCidade + "");
            scom.AddWithValue("@endereco_uf", item.SEnderecoUF + "");
            scom.AddWithValue("@endereco_cep", item.SEnderecoCEP + "");
            scom.AddWithValue("@endereco_observacoes", item.SEnderecoObservacoes + "");
            scom.AddWithValue("@tipocadastro", "L");
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void ExcluirLaboratorio(Laboratorio item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE fornecedor SET");
            sSql.AppendLine("     status=0");
            sSql.AppendLine("	, data_ultalt			= NOW()");
            sSql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static List<Laboratorio> PesquisarLaboratorio()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status, tipocadastro ");
            sSql.AppendLine("FROM fornecedor ");
            sSql.AppendLine("WHERE status=1 AND tipocadastro = 'L';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);

            List<Laboratorio> Lst = new List<Laboratorio>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Laboratorio>();
                    Laboratorio item = null;
                    while (scom.Read())
                    {
                        item = new Laboratorio()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                            STipoCadastro = scom.GetValue<string>("tipocadastro")
                        };

                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Laboratorio ObterLaboratorio(long _Empresa)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT ");
            sSql.AppendLine("      id ");
            sSql.AppendLine("    , razaosocial_nome ");
            sSql.AppendLine("    , nomefantasia_apelido ");
            sSql.AppendLine("    , email ");
            sSql.AppendLine("    , site ");
            sSql.AppendLine("    , data_fundacao_nasc ");
            sSql.AppendLine("    , data_cadastro ");
            sSql.AppendLine("    , data_ultalt ");
            sSql.AppendLine("    , tipo_pessoa ");
            sSql.AppendLine("    , cnpj_cpf ");
            sSql.AppendLine("    , insc_municipal ");
            sSql.AppendLine("    , insc_estadual ");
            sSql.AppendLine("    , endereco ");
            sSql.AppendLine("    , endereco_numero ");
            sSql.AppendLine("    , endereco_bairro ");
            sSql.AppendLine("    , endereco_cidade ");
            sSql.AppendLine("    , endereco_uf ");
            sSql.AppendLine("    , endereco_cep ");
            sSql.AppendLine("    , endereco_observacoes ");
            sSql.AppendLine("    , status ");
            sSql.AppendLine("FROM fornecedor ");
            sSql.AppendLine("WHERE id=@id AND tipocadastro = 'L';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Empresa);
            Laboratorio item = null;

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Laboratorio()
                        {
                            Id = scom.GetValue<long>("id"),
                            SRazaoSocial = scom.GetValue<string>("razaosocial_nome"),
                            SNomeFantasia = scom.GetValue<string>("nomefantasia_apelido"),
                            SEmail = scom.GetValue<string>("email"),
                            SSite = scom.GetValue<string>("site"),
                            SCnpjCpf = scom.GetValue<string>("cnpj_cpf"),
                            SEndereco = scom.GetValue<string>("endereco"),
                            SEnderecoBairro = scom.GetValue<string>("endereco_bairro"),
                            SEnderecoCidade = scom.GetValue<string>("endereco_cidade"),
                            SEnderecoCEP = scom.GetValue<string>("endereco_cep"),
                            SEnderecoNumero = scom.GetValue<string>("endereco_numero"),
                            SEnderecoObservacoes = scom.GetValue<string>("endereco_observacoes"),
                            SEnderecoUF = scom.GetValue<string>("endereco_uf"),
                            SInscricaoEstadual = scom.GetValue<string>("insc_estadual"),
                            SInscricaoMunicipal = scom.GetValue<string>("insc_municipal"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmFundacao = scom.GetValue<DateTime?>("data_fundacao_nasc"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            ITipoPessoa = scom.GetValue<int>("tipo_pessoa"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        } 
        #endregion
    }
}