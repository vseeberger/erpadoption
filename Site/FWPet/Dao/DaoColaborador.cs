using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoColaborador
    {
        internal static void Salvar(Colaborador item)
        {
            if (item == null) throw new Exception("Atenção! O objeto COLABORADOR não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);

                //Salvar as férias
                if (item.LstFerias != null && item.LstFerias.Count > 0)
                {
                    for (int i = 0; i < item.LstFerias.Count; i++)
                    {
                        ColaboradorFerias _ferias = item.LstFerias[i];
                        _ferias.IdColaborador = item.Id;
                        DaoColaboradorFerias.Salvar(_ferias);
                    }
                }

                //Salvar os dependentes
                if(item.LstDependentes != null && item.LstDependentes.Count > 0)
                {
                    for (int i = 0; i < item.LstDependentes.Count; i++)
                    {
                        PessoasDependentes _dep = item.LstDependentes[i];
                        _dep.IdPessoa = item.Id;
                        DaoPessoasDependentes.Salvar(_dep);
                    }
                }

                //Salvar os Beneficios
                if(item.LstBeneficios != null && item.LstBeneficios.Count > 0)
                {
                    for (int i = 0; i < item.LstBeneficios.Count; i++)
                    {
                        ColaboradorBeneficioDesconto _bene = item.LstBeneficios[i];
                        _bene.Colaborador = new Colaborador(item.Id);
                        DaoBeneficioDesconto.VincularComPessoa(_bene);
                    }
                }
            }
        }

        internal static List<Colaborador> Pesquisar()
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

            sSql.AppendLine("   , pessoa.hora_trab_entrada");
            sSql.AppendLine("   , pessoa.hora_trab_saida");
            sSql.AppendLine("   , pessoa.trab_domingo");
            sSql.AppendLine("   , pessoa.trab_segunda");
            sSql.AppendLine("   , pessoa.trab_terca");
            sSql.AppendLine("   , pessoa.trab_quarta");
            sSql.AppendLine("   , pessoa.trab_quinta");
            sSql.AppendLine("   , pessoa.trab_sexta");
            sSql.AppendLine("   , pessoa.trab_sabado");

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

            sSql.AppendLine("   , pessoa.diarista");
            sSql.AppendLine("   , pessoa.valor");
            sSql.AppendLine("   , pessoa.recebe_na_diaria");
            sSql.AppendLine("   , pessoa.dia_pagamento");
            
            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("   left join pessoa_x_endereco pe ON pe.id_pessoa = pessoa.id AND pe.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = pe.id_endereco AND en.status = 1 ");

            sSql.AppendLine("WHERE pessoa.status=1");
            sSql.AppendLine("AND pessoa.tipo='C';");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Colaborador> Lst = new List<Colaborador>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Colaborador>();
                    Colaborador item = null;
                    while (scom.Read())
                    {
                        item = new Colaborador()
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
                            SHoraTrabalhoInicio = scom.GetValue<string>("hora_trab_entrada"),
                            SHoraTrabalhoTermino = scom.GetValue<string>("hora_trab_saida"),
                            EscalaDomingo = scom.GetValue<bool>("trab_domingo"),
                            EscalaSegunda = scom.GetValue<bool>("trab_segunda"),
                            EscalaTerca = scom.GetValue<bool>("trab_terca"),
                            EscalaQuarta = scom.GetValue<bool>("trab_quarta"),
                            EscalaQuinta = scom.GetValue<bool>("trab_quinta"),
                            EscalaSexta = scom.GetValue<bool>("trab_sexta"),
                            EscalaSabado = scom.GetValue<bool>("trab_sabado"),
                            BDiarista = scom.GetValue<bool>("diarista"),
                            DValor = scom.GetValue<decimal>("valor"),
                            BDiaristaRecebeNaDiaria = scom.GetValue<bool>("recebe_na_diaria"),
                            DiaPagamento = scom.GetValue<int>("dia_pagamento")
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

        internal static void Excluir(Colaborador item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE pessoa SET ");
            sSql.AppendLine("      status = 0");
            sSql.AppendLine("    , data_ultalt      = NOW()");
            sSql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static Colaborador Obter(long _Colaborador)
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

            sSql.AppendLine("   , pessoa.hora_trab_entrada");
            sSql.AppendLine("   , pessoa.hora_trab_saida");
            sSql.AppendLine("   , pessoa.trab_domingo");
            sSql.AppendLine("   , pessoa.trab_segunda");
            sSql.AppendLine("   , pessoa.trab_terca");
            sSql.AppendLine("   , pessoa.trab_quarta");
            sSql.AppendLine("   , pessoa.trab_quinta");
            sSql.AppendLine("   , pessoa.trab_sexta");
            sSql.AppendLine("   , pessoa.trab_sabado");

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

            sSql.AppendLine("   , pessoa.diarista");
            sSql.AppendLine("   , pessoa.valor");
            sSql.AppendLine("   , pessoa.recebe_na_diaria");
            sSql.AppendLine("   , pessoa.dia_pagamento");

            //Add 06.03.2017
            sSql.AppendLine("   , pessoa.rg_uf ");
            sSql.AppendLine("   , pessoa.rg_orgao");
            sSql.AppendLine("   , pessoa.rg_data");
            sSql.AppendLine("   , pessoa.ctps");
            sSql.AppendLine("   , pessoa.ctps_serie");
            sSql.AppendLine("   , pessoa.ctps_uf");
            sSql.AppendLine("   , pessoa.tit_eleitor");
            sSql.AppendLine("   , pessoa.tit_eleitor_zona");
            sSql.AppendLine("   , pessoa.tit_eleitor_secao");
            sSql.AppendLine("   , pessoa.pis_pasep");
            sSql.AppendLine("   , pessoa.data_admissao");
            sSql.AppendLine("   , pessoa.data_demissao");
            sSql.AppendLine("   , nome_mae");
            sSql.AppendLine("   , nome_pai");
            sSql.AppendLine("   , estrangeiro");
            sSql.AppendLine("   , naturalidade");
            sSql.AppendLine("   , uf_nascimento");
            sSql.AppendLine("   , nacionalidade");
            sSql.AppendLine("   , passaporte");
            sSql.AppendLine("   , tipo_sanguineo");
            sSql.AppendLine("   , estado_civil");
            sSql.AppendLine("   , numero_filhos");

            sSql.AppendLine("FROM pessoa");
            sSql.AppendLine("   left join pessoa_x_endereco pe ON pe.id_pessoa = pessoa.id AND pe.status = 1 ");
            sSql.AppendLine("   left join endereco en ON en.id = pe.id_endereco AND en.status = 1 ");
            sSql.AppendLine("WHERE pessoa.id=@id");
            sSql.AppendLine("AND pessoa.tipo='C';");

            //add 06.03.2017
            sSql.AppendLine("SELECT");
            sSql.AppendLine("      pessoa_ferias.id");
            sSql.AppendLine("    , pessoa_ferias.idPessoa");
            sSql.AppendLine("    , pessoa_ferias.observacoes");
            sSql.AppendLine("    , pessoa_ferias.data_cadastro");
            sSql.AppendLine("    , pessoa_ferias.data_ultalt");
            sSql.AppendLine("    , pessoa_ferias.data_comp_de");
            sSql.AppendLine("    , pessoa_ferias.data_comp_ate");
            sSql.AppendLine("    , pessoa_ferias.data_periodo_de");
            sSql.AppendLine("    , pessoa_ferias.data_periodo_ate");
            sSql.AppendLine("    , pessoa_ferias.agendado");
            sSql.AppendLine("    , pessoa_ferias.realizou");
            sSql.AppendLine("    , pessoa_ferias.status");
            sSql.AppendLine("FROM pessoa_ferias");
            sSql.AppendLine("where idPessoa = @id;");

            //09.03.2017
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     beneficio_desconto_pessoa.id");
            sSql.AppendLine("   , beneficio_desconto_pessoa.id_beneficio_desconto");
            sSql.AppendLine("   , beneficio_desconto_pessoa.tipo");
            sSql.AppendLine("   , beneficio_desconto_pessoa.valor_desconto");
            sSql.AppendLine("   , beneficio_desconto_pessoa.data_cadastro");
            sSql.AppendLine("   , beneficio_desconto_pessoa.data_ultalt");
            sSql.AppendLine("   , beneficio_desconto_pessoa.status");
            sSql.AppendLine("   , beneficio_desconto.descricao AS BeneficioDescricao");
            sSql.AppendLine("   , IFNULL(beneficio_desconto.valor_maximo,0) AS BeneficioValorMaximo");
            sSql.AppendLine("   , IFNULL(beneficio_desconto.percentual_salario,0) AS BeneficioPercentual");
            sSql.AppendLine("FROM beneficio_desconto_pessoa");
            sSql.AppendLine("INNER JOIN beneficio_desconto ON beneficio_desconto.id = beneficio_desconto_pessoa.id_beneficio_desconto");
            sSql.AppendLine("WHERE ");
            sSql.AppendLine("    beneficio_desconto_pessoa.id_colaborador = @id_colaborador");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Colaborador);

            Colaborador item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    #region Carrega o colaborador
                    if (scom.Read())
                    {
                        
                        item = new Colaborador()
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
                            SHoraTrabalhoInicio = scom.GetValue<string>("hora_trab_entrada"),
                            SHoraTrabalhoTermino = scom.GetValue<string>("hora_trab_saida"),
                            EscalaDomingo = scom.GetValue<bool>("trab_domingo"),
                            EscalaSegunda = scom.GetValue<bool>("trab_segunda"),
                            EscalaTerca = scom.GetValue<bool>("trab_terca"),
                            EscalaQuarta = scom.GetValue<bool>("trab_quarta"),
                            EscalaQuinta = scom.GetValue<bool>("trab_quinta"),
                            EscalaSexta = scom.GetValue<bool>("trab_sexta"),
                            EscalaSabado = scom.GetValue<bool>("trab_sabado"),
                            BDiarista = scom.GetValue<bool>("diarista"),
                            DValor = scom.GetValue<decimal>("valor"),
                            DiaPagamento = scom.GetValue<int>("dia_pagamento"),
                            BDiaristaRecebeNaDiaria = scom.GetValue<bool>("recebe_na_diaria"),

                            //add 06.03.2017
                            DtmAdmissao = scom.GetValue<DateTime?>("data_admissao"),
                            DtmDemissao = scom.GetValue<DateTime?>("data_demissao"),

                            DtmRGExpedicao = scom.GetValue<DateTime?>("rg_data"),
                            SRGOrgao = scom.GetValue<string>("rg_orgao"),
                            SRGUF = scom.GetValue<string>("rg_uf"),

                            SCTPS = scom.GetValue<string>("ctps"),
                            SCTPSSerie = scom.GetValue<string>("ctps_serie"),
                            SCTPSUF = scom.GetValue<string>("ctps_uf"),

                            STitEleitor = scom.GetValue<string>("tit_eleitor"),
                            STitEleitorZona = scom.GetValue<string>("tit_eleitor_zona"),
                            STitEleitorSecao = scom.GetValue<string>("tit_eleitor_secao"),

                            SPISPASEP = scom.GetValue<string>("pis_pasep"),
                            SNomeMae = scom.GetValue<string>("nome_mae"),
                            SNomePai = scom.GetValue<string>("nome_pai"),
                            Estrangeiro = scom.GetValue<bool>("estrangeiro"),
                            SNaturalidade = scom.GetValue<string>("naturalidade"),
                            SUFNascimento = scom.GetValue<string>("uf_nascimento"),
                            SNacionalidade = scom.GetValue<string>("nacionalidade"),
                            SPassaporte = scom.GetValue<string>("passaporte"),
                            STipoSanguineo = scom.GetValue<string>("tipo_sanguineo"),
                            SEstadoCivil = scom.GetValue<string>("estado_civil"),
                            INumeroFilhos = scom.GetValue<int?>("numero_filhos"),
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

                        item.LstEscalas = DaoColaboradorEscala.Escalas(null, item.Id);
                    }

                    item.LstDependentes = PessoasDependentes.Pesquisar(item.Id);
                    item.LstFerias = new List<ColaboradorFerias>();
                    item.LstBeneficios = new List<ColaboradorBeneficioDesconto>(); 
                    #endregion

                    #region Carrega as ferias
                    scom.NextResult();
                    if (scom.HasRows)
                    {

                        ColaboradorFerias _ferias = null;
                        while (scom.Read())
                        {
                            _ferias = new ColaboradorFerias()
                            {
                                Id = scom.GetValue<long>("id"),
                                IdColaborador = scom.GetValue<long>("idPessoa"),
                                SObservacoes = scom.GetValue<string>("observacoes"),
                                Agendado = scom.GetValue<bool>("agendado"),
                                Status = scom.GetValue<bool>("status"),
                                Realizou = scom.GetValue<bool>("realizou"),
                                DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                                DtmCompetenciaAte = scom.GetValue<DateTime?>("data_comp_ate"),
                                DtmCompetenciaDe = scom.GetValue<DateTime?>("data_comp_de"),
                                DtmPeriodoAte = scom.GetValue<DateTime?>("data_periodo_ate"),
                                DtmPeriodoDe = scom.GetValue<DateTime?>("data_periodo_de"),
                                sequencia = scom.GetValue<long>("id")
                            };

                            item.LstFerias.Add(_ferias);
                        }
                    } 
                    #endregion

                    #region Carrega os beneficios
                    scom.NextResult();
                    if (scom.HasRows)
                    {
                        ColaboradorBeneficioDesconto _bene = null;
                        while (scom.Read())
                        {
                            _bene = new ColaboradorBeneficioDesconto()
                            {
                                Id = scom.GetValue<long>("id"),
                                Sequencia = scom.GetValue<long>("id"),
                                Beneficio = new BeneficioDesconto()
                                {
                                    Id = scom.GetValue<int>("id_beneficio_desconto"),
                                    SDescricao = scom.GetValue<string>("BeneficioDescricao"),
                                    DPercentualDesconto = scom.GetValue<decimal>("BeneficioPercentual"),
                                    DValorMaximo = scom.GetValue<decimal>("BeneficioValorMaximo"),
                                },
                                STipo = scom.GetValue<string>("tipo"),
                                DValor = scom.GetValue<decimal>("valor_desconto"),
                                DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                                Colaborador = new Colaborador(item.Id),
                                Alterou = false,
                                Status = scom.GetValue<bool>("status"),
                            };

                            if (_bene.STipo == "D")
                            {
                                _bene.Corrigir = DescontoCorreto(item.DValor, _bene.DValor, _bene.Beneficio.DPercentualDesconto, _bene.Beneficio.DValorMaximo);
                            }

                            item.LstBeneficios.Add(_bene);
                        }
                    } 
                    #endregion
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        private static bool DescontoCorreto(decimal _Salario, decimal _ValorAplicado, decimal _DescontoPercentual, decimal _DescontoMaximo)
        {
            bool DeveAlterar = false;
            //tem que ter salário maior do que zero
            //tem que o valor a ser descontado maior do que zero
            if (_Salario > (decimal)0.0 && _ValorAplicado > (decimal)0.0)
            {
                //o valor do desconto NÃO pode ser maior do que o valor máximo de desconto do benefício.
                if (_ValorAplicado > _DescontoMaximo) DeveAlterar = true;
                else
                {
                    decimal dPercentualAplicado = (_ValorAplicado * 100) / _Salario;
                    //o percentual do desconto NÃO pode ser maior do que o percentual do desconto do benefício.
                    if (dPercentualAplicado > _DescontoPercentual) DeveAlterar = true;
                }
            }

            return DeveAlterar;
        }

        private static void Inserir(Colaborador item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO pessoa (nome, rg, cpf, data_nascimento, tipo, sexo, email, celular, telefone, outro_contato, hora_trab_entrada, hora_trab_saida, trab_domingo, trab_segunda, trab_terca, trab_quarta, trab_quinta, trab_sexta, trab_sabado,valor, diarista, recebe_na_diaria, dia_pagamento, rg_uf , rg_orgao, rg_data, ctps, ctps_serie, ctps_uf, tit_eleitor, tit_eleitor_zona, tit_eleitor_secao, pis_pasep, data_admissao, data_demissao, nome_mae, nome_pai, estrangeiro, naturalidade, uf_nascimento, nacionalidade, passaporte, tipo_sanguineo, estado_civil, numero_filhos)");
            sSql.AppendLine("VALUES (@nome, @rg, @cpf, @data_nascimento, 'C', @sexo, @email, @celular, @telefone, @outro_contato, @hora_trab_entrada, @hora_trab_saida, @trab_domingo, @trab_segunda, @trab_terca, @trab_quarta, @trab_quinta, @trab_sexta, @trab_sabado, @valor, @diarista, @recebe_na_diaria, @dia_pagamento, @rg_uf , @rg_orgao, @rg_data, @ctps, @ctps_serie, @ctps_uf, @tit_eleitor, @tit_eleitor_zona, @tit_eleitor_secao, @pis_pasep, @data_admissao, @data_demissao, @nome_mae, @nome_pai, @estrangeiro, @naturalidade, @uf_nascimento, @nacionalidade, @passaporte, @tipo_sanguineo, @estado_civil, @numero_filhos);SELECT LAST_INSERT_ID();");
            
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

            scom.AddWithValue("@hora_trab_entrada", item.SHoraTrabalhoInicio);
            scom.AddWithValue("@hora_trab_saida", item.SHoraTrabalhoTermino);
            scom.AddWithValue("@trab_domingo", item.EscalaDomingo ? 1 : 0);
            scom.AddWithValue("@trab_segunda", item.EscalaSegunda ? 1 : 0);
            scom.AddWithValue("@trab_terca", item.EscalaTerca ? 1 : 0);
            scom.AddWithValue("@trab_quarta", item.EscalaQuarta ? 1 : 0);
            scom.AddWithValue("@trab_quinta", item.EscalaQuinta ? 1 : 0);
            scom.AddWithValue("@trab_sexta", item.EscalaSexta ? 1 : 0);
            scom.AddWithValue("@trab_sabado", item.EscalaSabado ? 1 : 0);

            scom.AddWithValue("@valor", item.DValor);
            scom.AddWithValue("@diarista", item.EscalaSabado ? 1 : 0);
            scom.AddWithValue("@recebe_na_diaria", item.BDiaristaRecebeNaDiaria ? 1 : 0);
            scom.AddWithValue("@dia_pagamento", item.DiaPagamento);

            //Add 06.03.2017
            scom.AddWithValue("@rg_uf", item.SRGUF);
            scom.AddWithValue("@rg_orgao", item.SRGOrgao);
            scom.AddWithValue("@rg_data", item.DtmRGExpedicao);
            scom.AddWithValue("@ctps", item.SCTPS);
            scom.AddWithValue("@ctps_serie", item.SCTPSSerie);
            scom.AddWithValue("@ctps_uf", item.SCTPSUF);
            scom.AddWithValue("@tit_eleitor", item.STitEleitor);
            scom.AddWithValue("@tit_eleitor_zona", item.STitEleitorZona);
            scom.AddWithValue("@tit_eleitor_secao", item.STitEleitorSecao);
            scom.AddWithValue("@pis_pasep", item.SPISPASEP);
            scom.AddWithValue("@data_admissao", item.DtmAdmissao);
            scom.AddWithValue("@data_demissao", item.DtmDemissao);

            scom.AddWithValue("@nome_mae", item.SNomeMae);
            scom.AddWithValue("@nome_pai", item.SNomePai);
            scom.AddWithValue("@estrangeiro", item.Estrangeiro ? 1 : 0);
            scom.AddWithValue("@naturalidade", item.SNaturalidade);
            scom.AddWithValue("@uf_nascimento", item.SUFNascimento);
            scom.AddWithValue("@nacionalidade", item.SNacionalidade);
            scom.AddWithValue("@passaporte", item.SPassaporte);
            scom.AddWithValue("@tipo_sanguineo", item.STipoSanguineo);
            scom.AddWithValue("@estado_civil", item.SEstadoCivil);
            scom.AddWithValue("@numero_filhos", item.INumeroFilhos);

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

        private static void Alterar(Colaborador item)
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

            sSql.AppendLine("    , hora_trab_entrada= @hora_trab_entrada");
            sSql.AppendLine("    , hora_trab_saida  = @hora_trab_saida");
            sSql.AppendLine("    , trab_domingo     = @trab_domingo");
            sSql.AppendLine("    , trab_segunda     = @trab_segunda");
            sSql.AppendLine("    , trab_terca       = @trab_terca");
            sSql.AppendLine("    , trab_quarta      = @trab_quarta");
            sSql.AppendLine("    , trab_quinta      = @trab_quinta");
            sSql.AppendLine("    , trab_sexta       = @trab_sexta");
            sSql.AppendLine("    , trab_sabado      = @trab_sabado");

            sSql.AppendLine("    , valor            = @valor");
            sSql.AppendLine("    , diarista         = @diarista");
            sSql.AppendLine("    , recebe_na_diaria = @recebe_na_diaria");
            sSql.AppendLine("    , dia_pagamento    = @dia_pagamento");

            //Add 06.03.2017
            sSql.AppendLine("    , rg_uf            = @rg_uf");
            sSql.AppendLine("    , rg_orgao         = @rg_orgao");
            sSql.AppendLine("    , rg_data          = @rg_data");
            sSql.AppendLine("    , ctps             = @ctps");
            sSql.AppendLine("    , ctps_serie       = @ctps_serie");
            sSql.AppendLine("    , ctps_uf          = @ctps_uf");
            sSql.AppendLine("    , tit_eleitor      = @tit_eleitor");
            sSql.AppendLine("    , tit_eleitor_zona = @tit_eleitor_zona");
            sSql.AppendLine("    , tit_eleitor_secao= @tit_eleitor_secao");
            sSql.AppendLine("    , pis_pasep        = @pis_pasep");
            sSql.AppendLine("    , data_admissao    = @data_admissao");
            sSql.AppendLine("    , data_demissao    = @data_demissao");
            sSql.AppendLine("    , nome_mae         = @nome_mae");
            sSql.AppendLine("    , nome_pai         = @nome_pai");
            sSql.AppendLine("    , estrangeiro      = @estrangeiro");
            sSql.AppendLine("    , naturalidade     = @naturalidade");
            sSql.AppendLine("    , uf_nascimento    = @uf_nascimento");
            sSql.AppendLine("    , nacionalidade    = @nacionalidade");
            sSql.AppendLine("    , passaporte       = @passaporte");
            sSql.AppendLine("    , tipo_sanguineo   = @tipo_sanguineo");
            sSql.AppendLine("    , estado_civil     = @estado_civil");
            sSql.AppendLine("    , numero_filhos    = @numero_filhos");
            
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
            scom.AddWithValue("@id", item.Id);

            scom.AddWithValue("@hora_trab_entrada", item.SHoraTrabalhoInicio);
            scom.AddWithValue("@hora_trab_saida", item.SHoraTrabalhoTermino);
            scom.AddWithValue("@trab_domingo", item.EscalaDomingo ? 1 : 0);
            scom.AddWithValue("@trab_segunda", item.EscalaSegunda ? 1 : 0);
            scom.AddWithValue("@trab_terca", item.EscalaTerca ? 1 : 0);
            scom.AddWithValue("@trab_quarta", item.EscalaQuarta ? 1 : 0);
            scom.AddWithValue("@trab_quinta", item.EscalaQuinta ? 1 : 0);
            scom.AddWithValue("@trab_sexta", item.EscalaSexta ? 1 : 0);
            scom.AddWithValue("@trab_sabado", item.EscalaSabado ? 1 : 0);

            scom.AddWithValue("@valor", item.DValor);
            scom.AddWithValue("@diarista", item.EscalaSabado ? 1 : 0);
            scom.AddWithValue("@recebe_na_diaria", item.BDiaristaRecebeNaDiaria ? 1 : 0);
            scom.AddWithValue("@dia_pagamento", item.DiaPagamento);

            //Add 06.03.2017
            scom.AddWithValue("@rg_uf", item.SRGUF);
            scom.AddWithValue("@rg_orgao", item.SRGOrgao);
            scom.AddWithValue("@rg_data", item.DtmRGExpedicao);
            scom.AddWithValue("@ctps", item.SCTPS);
            scom.AddWithValue("@ctps_serie", item.SCTPSSerie);
            scom.AddWithValue("@ctps_uf", item.SCTPSUF);
            scom.AddWithValue("@tit_eleitor", item.STitEleitor);
            scom.AddWithValue("@tit_eleitor_zona", item.STitEleitorZona);
            scom.AddWithValue("@tit_eleitor_secao", item.STitEleitorSecao);
            scom.AddWithValue("@pis_pasep", item.SPISPASEP);
            scom.AddWithValue("@data_admissao", item.DtmAdmissao);
            scom.AddWithValue("@data_demissao", item.DtmDemissao);
            scom.AddWithValue("@nome_mae", item.SNomeMae);
            scom.AddWithValue("@nome_pai", item.SNomePai);
            scom.AddWithValue("@estrangeiro", item.Estrangeiro ? 1 : 0);
            scom.AddWithValue("@naturalidade", item.SNaturalidade);
            scom.AddWithValue("@uf_nascimento", item.SUFNascimento);
            scom.AddWithValue("@nacionalidade", item.SNacionalidade);
            scom.AddWithValue("@passaporte", item.SPassaporte);
            scom.AddWithValue("@tipo_sanguineo", item.STipoSanguineo);
            scom.AddWithValue("@estado_civil", item.SEstadoCivil);
            scom.AddWithValue("@numero_filhos", item.INumeroFilhos);

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