using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoContaPagarReceber
    {
        internal static List<ContaPagarReceber> Pesquisar(string _Tipo, DateTime dtmPeriodo, int _TrazerNaoPagos)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      conta_pagar_receber.id");
            sql.AppendLine("    , conta_pagar_receber.id_conta_bancaria");
            sql.AppendLine("    , conta_pagar_receber.id_centro_de_custos_lucro");
            sql.AppendLine("    , conta_pagar_receber.id_origem_de_custos_lucro");
            sql.AppendLine("    , conta_pagar_receber.descricao_ou_referencia");
            sql.AppendLine("    , conta_pagar_receber.nome_de_quem_pagou");
            sql.AppendLine("    , conta_pagar_receber.numero_do_documento");
            sql.AppendLine("    , conta_pagar_receber.custo_ou_lucro");
            sql.AppendLine("    , conta_pagar_receber.mais_detalhes");
            sql.AppendLine("    , conta_pagar_receber.data_pagamento");
            sql.AppendLine("    , conta_pagar_receber.data_previsao");
            sql.AppendLine("    , conta_pagar_receber.data_competencia");
            sql.AppendLine("    , conta_pagar_receber.valor");
            sql.AppendLine("    , conta_pagar_receber.data_cadastro");
            sql.AppendLine("    , conta_pagar_receber.data_ultalt");
            sql.AppendLine("    , conta_pagar_receber.status");
            sql.AppendLine("    , conta_pagar_receber.situacao");
            sql.AppendLine("    , conta_pagar_receber.id_forma_pagamento");

            sql.AppendLine("    , origem_de_custos_lucro.id_origem_de_custos_lucro AS Origem_Pai");
            sql.AppendLine("    , origem_de_custos_lucro.descricao AS Origem_Descricao");
            sql.AppendLine("    , origem_de_custos_lucro.data_cadastro AS Origem_DataCadastro");
            sql.AppendLine("    , origem_de_custos_lucro.data_ultalt AS Origem_DataUltAlt");
            sql.AppendLine("    , origem_de_custos_lucro.status AS Origem_Status");
            sql.AppendLine("    , origem_de_custos_lucro.entrada_saida AS Origem_EntradaSaida");
            sql.AppendLine("    , origem_de_custos_lucro.classificacao AS Origem_Classificacao");

            sql.AppendLine("    , conta_pagar_receber.pagopara_tipo");
            sql.AppendLine("    , conta_pagar_receber.id_pagopara");


            sql.AppendLine("FROM conta_pagar_receber");
            sql.AppendLine("    LEFT JOIN origem_de_custos_lucro ON origem_de_custos_lucro.id = conta_pagar_receber.id_origem_de_custos_lucro");
            sql.AppendLine("WHERE conta_pagar_receber.status = 1");
            

            if (!String.IsNullOrEmpty(_Tipo))
                sql.AppendLine("    AND conta_pagar_receber.custo_ou_lucro = @tipo");

            if (_TrazerNaoPagos > 0)
            {
                sql.AppendLine("    AND (");
                sql.AppendLine("        conta_pagar_receber.data_previsao BETWEEN @DATAINICIO AND @DATAFINAL");
                sql.AppendLine("        OR (conta_pagar_receber.data_pagamento IS NOT NULL AND conta_pagar_receber.data_pagamento BETWEEN @DATAINICIO AND @DATAFINAL)");
                sql.AppendLine("        OR (conta_pagar_receber.data_pagamento IS NULL AND conta_pagar_receber.data_previsao < @DATAFINAL)");
                sql.AppendLine("        )");

            }
            else
            {
                sql.AppendLine("    AND (");
                sql.AppendLine("        conta_pagar_receber.data_previsao BETWEEN @DATAINICIO AND @DATAFINAL");
                sql.AppendLine("        OR (conta_pagar_receber.data_pagamento IS NOT NULL AND conta_pagar_receber.data_pagamento BETWEEN @DATAINICIO AND @DATAFINAL)");
                sql.AppendLine("        )");
            }

            //if (_TrazerNaoPagos > 0)
            //{
            //    //sql.AppendLine("    AND (conta_pagar_receber.data_competencia BETWEEN @DATAINICIO AND @DATAFINAL OR (conta_pagar_receber.data_competencia < @DATAFINAL AND conta_pagar_receber.situacao = 0))");

            //    sql.AppendLine("    AND (");
            //    sql.AppendLine("        conta_pagar_receber.data_competencia BETWEEN @DATAINICIO AND @DATAFINAL");
            //    sql.AppendLine("        OR (conta_pagar_receber.data_pagamento IS NOT NULL AND conta_pagar_receber.data_pagamento BETWEEN @DATAINICIO AND @DATAFINAL)");
            //    sql.AppendLine("        OR (conta_pagar_receber.data_competencia < @DATAFINAL AND conta_pagar_receber.situacao = 0)");
            //    sql.AppendLine("        )");

            //}
            //else
            //{
            //    sql.AppendLine("    AND (");
            //    sql.AppendLine("        conta_pagar_receber.data_competencia BETWEEN @DATAINICIO AND @DATAFINAL");
            //    sql.AppendLine("        OR (conta_pagar_receber.data_pagamento IS NOT NULL AND conta_pagar_receber.data_pagamento BETWEEN @DATAINICIO AND @DATAFINAL)");
            //    sql.AppendLine("        )");
            //}

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@tipo", _Tipo);
            scom.AddWithValue("@DATAINICIO", new DateTime(dtmPeriodo.Year, dtmPeriodo.Month, 1));
            scom.AddWithValue("@DATAFINAL", new DateTime(dtmPeriodo.Year, dtmPeriodo.Month, 1).AddMonths(1).AddDays(-1));

            List<ContaPagarReceber> Lst = new List<ContaPagarReceber>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ContaPagarReceber>();
                    ContaPagarReceber item = null;
                    while (scom.Read())
                    {
                        item = new ContaPagarReceber()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricaoReferencia = scom.GetValue<string>("descricao_ou_referencia"),
                            SNomeDeQuemPagou = scom.GetValue<string>("nome_de_quem_pagou"),
                            SNumeroDocumento = scom.GetValue<string>("numero_do_documento"),
                            SCustoOuLucro = scom.GetValue<string>("custo_ou_lucro"),
                            SMaisDetalhes = scom.GetValue<string>("mais_detalhes"),

                            DtmPagamentoRecebimento = scom.GetValue<DateTime?>("data_pagamento"),
                            DtmPrevisao = scom.GetValue<DateTime>("data_previsao"),
                            DtmCompetencia = scom.GetValue<DateTime?>("data_competencia"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),

                            DValor = scom.GetValue<decimal>("valor"),
                            Situacao = scom.GetValue<int>("situacao"),
                            Status = scom.GetValue<bool>("status"),

                            STipoQuemRecebeuPagou = scom.GetValue<string>("pagopara_tipo"),
                            IdQuemRecebeuPagou = scom.GetValue<long?>("id_pagopara"),
                        };

                        if (scom.GetValue<int?>("id_conta_bancaria") != null)
                            item.Conta = new ContaBancaria(scom.GetValue<int>("id_conta_bancaria"));

                        if (scom.GetValue<int?>("id_centro_de_custos_lucro") != null)
                        {
                            item.CentroDeCustos = new CentroDeCustos(scom.GetValue<int>("id_centro_de_custos_lucro"));
                        }

                        if (scom.GetValue<int?>("id_origem_de_custos_lucro") != null)
                        {
                            item.Classificacao = new OrigemCustos()
                            {
                                Id = scom.GetValue<int>("id_origem_de_custos_lucro"),
                                IdPai = scom.GetValue<int?>("Origem_Pai"),
                                SDescricao = scom.GetValue<string>("Origem_Descricao"),
                                DtmCadastro = scom.GetValue<DateTime>("Origem_DataCadastro"),
                                DtmUltAlt = scom.GetValue<DateTime>("Origem_DataUltAlt"),
                                Status = scom.GetValue<bool>("Origem_Status"),
                                SClassificacao = scom.GetValue<string>("Origem_EntradaSaida"),
                                SEntradaSaida = scom.GetValue<string>("Origem_Classificacao"),
                            };
                        }
                        if (scom.GetValue<int?>("id_forma_pagamento") != null)
                            item.FormaPagRec = new FormaPagamentoRecebimento(scom.GetValue<int>("id_forma_pagamento"));

                        if (item.IdQuemRecebeuPagou != null && item.IdQuemRecebeuPagou > 0)
                        {
                            if (item.STipoQuemRecebeuPagou == "R") { var resp = Responsavel.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SNome; }
                            if (item.STipoQuemRecebeuPagou == "C") { var resp = Colaborador.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SNome; }
                            if (item.STipoQuemRecebeuPagou == "F") { var resp = Laboratorio.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SRazaoSocial; }
                        }

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(ContaPagarReceber item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE conta_pagar_receber SET");
            sql.AppendLine("      data_ultalt               = NOW()");
            sql.AppendLine("    , status                    = 0");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static ContaPagarReceber Obter(long _Conta)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      conta_pagar_receber.id");
            sql.AppendLine("    , conta_pagar_receber.id_conta_bancaria");
            sql.AppendLine("    , conta_pagar_receber.id_centro_de_custos_lucro");
            sql.AppendLine("    , conta_pagar_receber.id_origem_de_custos_lucro");
            sql.AppendLine("    , conta_pagar_receber.descricao_ou_referencia");
            sql.AppendLine("    , conta_pagar_receber.nome_de_quem_pagou");
            sql.AppendLine("    , conta_pagar_receber.numero_do_documento");
            sql.AppendLine("    , conta_pagar_receber.custo_ou_lucro");
            sql.AppendLine("    , conta_pagar_receber.mais_detalhes");
            sql.AppendLine("    , conta_pagar_receber.data_pagamento");
            sql.AppendLine("    , conta_pagar_receber.data_previsao");
            sql.AppendLine("    , conta_pagar_receber.data_competencia");
            sql.AppendLine("    , conta_pagar_receber.valor");
            sql.AppendLine("    , conta_pagar_receber.data_cadastro");
            sql.AppendLine("    , conta_pagar_receber.data_ultalt");
            sql.AppendLine("    , conta_pagar_receber.status");
            sql.AppendLine("    , conta_pagar_receber.situacao");
            sql.AppendLine("    , conta_pagar_receber.id_forma_pagamento");

            sql.AppendLine("    , conta_pagar_receber.pagopara_tipo");
            sql.AppendLine("    , conta_pagar_receber.id_pagopara");

            sql.AppendLine("FROM conta_pagar_receber");
            sql.AppendLine("WHERE 1 = 1");
            sql.AppendLine("    AND conta_pagar_receber.id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Conta);

            ContaPagarReceber item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ContaPagarReceber()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricaoReferencia = scom.GetValue<string>("descricao_ou_referencia"),
                            SNomeDeQuemPagou = scom.GetValue<string>("nome_de_quem_pagou"),
                            SNumeroDocumento = scom.GetValue<string>("numero_do_documento"),
                            SCustoOuLucro = scom.GetValue<string>("custo_ou_lucro"),
                            SMaisDetalhes = scom.GetValue<string>("mais_detalhes"),

                            DtmPagamentoRecebimento = scom.GetValue<DateTime?>("data_pagamento"),
                            DtmPrevisao = scom.GetValue<DateTime>("data_previsao"),
                            DtmCompetencia = scom.GetValue<DateTime?>("data_competencia"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),

                            DValor = scom.GetValue<decimal>("valor"),
                            Situacao = scom.GetValue<int>("situacao"),
                            Status = scom.GetValue<bool>("status"),

                            STipoQuemRecebeuPagou = scom.GetValue<string>("pagopara_tipo"),
                            IdQuemRecebeuPagou = scom.GetValue<long?>("id_pagopara"),
                        };

                        if (scom.GetValue<int?>("id_conta_bancaria") != null)
                            item.Conta = new ContaBancaria(scom.GetValue<int>("id_conta_bancaria"));

                        if (scom.GetValue<int?>("id_centro_de_custos_lucro") != null)
                            item.CentroDeCustos = new CentroDeCustos(scom.GetValue<int>("id_centro_de_custos_lucro"));

                        if (scom.GetValue<int?>("id_origem_de_custos_lucro") != null)
                            item.Classificacao = new OrigemCustos(scom.GetValue<int>("id_origem_de_custos_lucro"));

                        if (scom.GetValue<int?>("id_forma_pagamento") != null)
                            item.FormaPagRec = new FormaPagamentoRecebimento(scom.GetValue<int>("id_forma_pagamento"));


                        if(item.IdQuemRecebeuPagou != null && item.IdQuemRecebeuPagou> 0)
                        {
                            if (item.STipoQuemRecebeuPagou == "R") { var resp = Responsavel.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SNome; }
                            if (item.STipoQuemRecebeuPagou == "C") { var resp = Colaborador.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SNome; }
                            if (item.STipoQuemRecebeuPagou == "F") { var resp = Laboratorio.Obter((long)item.IdQuemRecebeuPagou); item.SNomeQuemRecebeuPagou = resp.SRazaoSocial; }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(ContaPagarReceber item)
        {
            if (item == null) throw new Exception("O objeto CONTAPAGARRECEBER não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(ContaPagarReceber item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO conta_pagar_receber (id_conta_bancaria, id_centro_de_custos_lucro, id_origem_de_custos_lucro, descricao_ou_referencia, nome_de_quem_pagou, numero_do_documento, custo_ou_lucro, mais_detalhes, data_pagamento, data_previsao, data_competencia, valor, situacao, id_forma_pagamento, id_pagopara, pagopara_tipo)");
            sql.AppendLine("VALUES (@id_conta_bancaria, @id_centro_de_custos_lucro, @id_origem_de_custos_lucro, @descricao_ou_referencia, @nome_de_quem_pagou, @numero_do_documento, @custo_ou_lucro, @mais_detalhes, @data_pagamento, @data_previsao, @data_competencia, @valor, @situacao, @id_forma_pagamento, @id_pagopara, @pagopara_tipo);SELECT LAST_INSERT_ID();");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_conta_bancaria", item.Conta);
            scom.AddWithValue("@id_centro_de_custos_lucro", item.CentroDeCustos);
            scom.AddWithValue("@id_origem_de_custos_lucro", item.Classificacao);
            scom.AddWithValue("@descricao_ou_referencia", item.SDescricaoReferencia + "");
            scom.AddWithValue("@nome_de_quem_pagou", item.SNomeDeQuemPagou + "");
            scom.AddWithValue("@numero_do_documento", item.SNumeroDocumento + "");
            scom.AddWithValue("@custo_ou_lucro", item.SCustoOuLucro + "");
            scom.AddWithValue("@mais_detalhes", item.SMaisDetalhes + "");
            scom.AddWithValue("@data_pagamento", item.DtmPagamentoRecebimento);
            scom.AddWithValue("@data_previsao", item.DtmPrevisao);
            scom.AddWithValue("@data_competencia", item.DtmCompetencia);
            scom.AddWithValue("@valor", item.DValor);
            scom.AddWithValue("@situacao", item.Situacao);
            scom.AddWithValue("@id_forma_pagamento", item.FormaPagRec);
            
            scom.AddWithValue("@id_pagopara", item.IdQuemRecebeuPagou);
            scom.AddWithValue("@pagopara_tipo", item.STipoQuemRecebeuPagou);
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long l;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out l);
                    item.Id = l;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(ContaPagarReceber item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE conta_pagar_receber SET");
            sql.AppendLine("      id_conta_bancaria         = @id_conta_bancaria");
            sql.AppendLine("    , id_centro_de_custos_lucro = @id_centro_de_custos_lucro");
            sql.AppendLine("    , id_origem_de_custos_lucro = @id_origem_de_custos_lucro ");
            sql.AppendLine("    , descricao_ou_referencia   = @descricao_ou_referencia");
            sql.AppendLine("    , nome_de_quem_pagou        = @nome_de_quem_pagou");
            sql.AppendLine("    , numero_do_documento       = @numero_do_documento");
            sql.AppendLine("    , custo_ou_lucro            = @custo_ou_lucro");
            sql.AppendLine("    , mais_detalhes             = @mais_detalhes");
            sql.AppendLine("    , data_pagamento            = @data_pagamento");
            sql.AppendLine("    , data_previsao             = @data_previsao");
            sql.AppendLine("    , data_competencia          = @data_competencia");
            sql.AppendLine("    , valor                     = @valor");
            sql.AppendLine("    , data_ultalt               = NOW()");
            sql.AppendLine("    , status                    = @status");
            sql.AppendLine("    , situacao                  = @situacao");
            sql.AppendLine("    , id_forma_pagamento        = @id_forma_pagamento");
            sql.AppendLine("    , id_pagopara               = @id_pagopara");
            sql.AppendLine("    , pagopara_tipo             = @pagopara_tipo");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id_conta_bancaria", item.Conta);
            scom.AddWithValue("@id_centro_de_custos_lucro", item.CentroDeCustos);
            scom.AddWithValue("@id_origem_de_custos_lucro", item.Classificacao);
            scom.AddWithValue("@descricao_ou_referencia", item.SDescricaoReferencia + "");
            scom.AddWithValue("@nome_de_quem_pagou", item.SNomeDeQuemPagou + "");
            scom.AddWithValue("@numero_do_documento", item.SNumeroDocumento + "");
            scom.AddWithValue("@custo_ou_lucro", item.SCustoOuLucro + "");
            scom.AddWithValue("@mais_detalhes", item.SMaisDetalhes + "");
            scom.AddWithValue("@data_pagamento", item.DtmPagamentoRecebimento);
            scom.AddWithValue("@data_previsao", item.DtmPrevisao);
            scom.AddWithValue("@data_competencia", item.DtmCompetencia);
            scom.AddWithValue("@valor", item.DValor);
            scom.AddWithValue("@situacao", item.Situacao);
            scom.AddWithValue("@id_forma_pagamento", item.FormaPagRec);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@id_pagopara", item.IdQuemRecebeuPagou);
            scom.AddWithValue("@pagopara_tipo", item.STipoQuemRecebeuPagou);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
