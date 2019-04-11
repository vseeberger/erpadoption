using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoAnimalMedicamento
    {
        internal static void Excluir(AnimalMedicamento item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE animal_medicamento SET");
            sql.AppendLine("      status = 0");
            sql.AppendLine("    , data_ultalt=NOW()");
            sql.AppendLine("WHERE codigo_agrupamento = @codigo_agrupamento");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@codigo_agrupamento", item.SCodAgrupamento);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Salvar(List<AnimalMedicamento> items)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO animal_medicamento");
            sql.AppendLine("(");
            sql.AppendLine("      id_animal");
            sql.AppendLine("    , id_medicamento");
            sql.AppendLine("    , codigo_agrupamento");
            sql.AppendLine("    , dose");
            sql.AppendLine("    , total_dose");
            sql.AppendLine("    , posologia");
            sql.AppendLine("    , dia_atual");
            sql.AppendLine("    , total_dias");
            sql.AppendLine("    , data_iniciou");
            sql.AppendLine("    , data_previsao");
            sql.AppendLine("    , id_tratamento");
            sql.AppendLine("    , observacao");
            sql.AppendLine(") VALUES (");
            sql.AppendLine("      @id_animal");
            sql.AppendLine("    , @id_medicamento");
            sql.AppendLine("    , @codigo_agrupamento");
            sql.AppendLine("    , @dose");
            sql.AppendLine("    , @total_dose");
            sql.AppendLine("    , @posologia");
            sql.AppendLine("    , @dia_atual");
            sql.AppendLine("    , @total_dias");
            sql.AppendLine("    , @data_iniciou");
            sql.AppendLine("    , @data_previsao");
            sql.AppendLine("    , @id_tratamento");
            sql.AppendLine("    , @observacao");
            sql.AppendLine(");");

            if (items != null && items.Count > 0)
            {
                cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);

                try
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        scom.AddWithValue("@id_animal", items[i].AnimalMedicado);
                        scom.AddWithValue("@id_medicamento", items[i].Medicamento);
                        scom.AddWithValue("@codigo_agrupamento", items[i].SCodAgrupamento);
                        scom.AddWithValue("@dose", items[i].IDose);
                        scom.AddWithValue("@total_dose", items[i].ITotalDose);
                        scom.AddWithValue("@posologia", items[i].SPosologia);
                        scom.AddWithValue("@dia_atual", items[i].IDiaAtual);
                        scom.AddWithValue("@total_dias", items[i].IQuantidadeDias);
                        scom.AddWithValue("@data_iniciou", items[i].DtmInicio);
                        scom.AddWithValue("@data_previsao", items[i].DtmPrevisao);
                        scom.AddWithValue("@id_tratamento", items[i].Tratamento == null ? 0 : items[i].Tratamento.Id);
                        scom.AddWithValue("@observacao", items[i].SObservacao);

                        scom.ExecuteNonQuery();
                        scom.Clear();
                    }
                    //throw new ExceptionSucesso("Dados gravados com sucesso!");
                }   
                catch (Exception ex) { throw ex; }
                finally { scom.Close(); }
            }
            else throw new Exception("Nenhum medicamento foi agendado!");
        }

        internal static void RealizarAplicacao(AnimalMedicamento item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE animal_medicamento SET");
            sql.AppendLine("      aplicado = 1");
            sql.AppendLine("    , data_ultalt=NOW()");
            sql.AppendLine("    , data_realizou=NOW()");
            sql.AppendLine("    , id_usuario_aplicou=@id_usuario_aplicou");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@id_usuario_aplicou", item.QuemMedicou.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static AnimalMedicamento ObterAgrupamento(long _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      animal_medicamento.id");
            sql.AppendLine("    , animal_medicamento.id_animal");
            sql.AppendLine("    , animal_medicamento.id_medicamento");
            sql.AppendLine("    , animal_medicamento.id_usuario_aplicou");
            sql.AppendLine("    , animal_medicamento.codigo_agrupamento");
            sql.AppendLine("    , animal_medicamento.posologia");
            sql.AppendLine("    , animal_medicamento.dose");
            sql.AppendLine("    , animal_medicamento.total_dose");
            sql.AppendLine("    , animal_medicamento.dia_atual");
            sql.AppendLine("    , animal_medicamento.total_dias");
            sql.AppendLine("    , animal_medicamento.data_iniciou");
            sql.AppendLine("    , animal_medicamento.data_previsao");
            sql.AppendLine("    , animal_medicamento.data_realizou");
            sql.AppendLine("    , animal_medicamento.data_cadastro");
            sql.AppendLine("    , animal_medicamento.data_ultalt");
            sql.AppendLine("    , animal_medicamento.aplicado");
            sql.AppendLine("    , animal_medicamento.id_tratamento");
            sql.AppendLine("    , animal_medicamento.observacao");
            sql.AppendLine("FROM animal_medicamento");
            sql.AppendLine("WHERE codigo_agrupamento = @id");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            AnimalMedicamento item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new AnimalMedicamento()
                        {
                            Id = scom.GetValue<long>("id"),
                            SCodAgrupamento = scom.GetValue<string>("codigo_agrupamento"),
                            IDose = scom.GetValue<int>("dose"),
                            ITotalDose = scom.GetValue<int>("total_dose"),
                            IDiaAtual = scom.GetValue<int>("dia_atual"),
                            IQuantidadeDias = scom.GetValue<int>("total_dias"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Aplicado = scom.GetValue<bool>("aplicado"),
                            DtmInicio = scom.GetValue<DateTime?>("data_iniciou"),
                            DtmMedicado = scom.GetValue<DateTime?>("data_realizou"),
                            DtmPrevisao = scom.GetValue<DateTime?>("data_previsao"),
                            SPosologia = scom.GetValue<string>("posologia"),
                            SObservacao = scom.GetValue<string>("observacao"),
                        };

                        item.LstMedicacao = AnimalMedicamento.Pesquisar(null, null, null, null, item.SCodAgrupamento, null);

                        #region Carrega dados do animal
                        if (scom.GetValue<long?>("id_animal") != null)
                        {
                            item.AnimalMedicado = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal")
                            };
                        }
                        #endregion

                        #region Carrega dados do medicamento
                        if (scom.GetValue<long?>("id_medicamento") != null)
                        {
                            item.Medicamento = new Produto()
                            {
                                Id = scom.GetValue<long>("id_medicamento"),
                            };
                        }
                        #endregion

                        #region Carrega dados do usuário que aplicou
                        if (scom.GetValue<long?>("id_usuario_aplicou") != null)
                        {
                            item.QuemMedicou = new Usuario()
                            {
                                Id = scom.GetValue<long>("id_usuario_aplicou"),
                            };
                        }
                        #endregion

                        #region Carrega tratamento
                        if(scom.GetValue<int?>("id_tratamento") != null && scom.GetValue<int?>("id_tratamento") > 0)
                        {
                            item.Tratamento = new AnimalMedicamentoTratamento(scom.GetValue<int>("id_tratamento"));
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static AnimalMedicamento Obter(long _Codigo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      animal_medicamento.id");
            sql.AppendLine("    , animal_medicamento.id_animal");
            sql.AppendLine("    , animal_medicamento.id_medicamento");
            sql.AppendLine("    , animal_medicamento.id_usuario_aplicou");
            sql.AppendLine("    , animal_medicamento.codigo_agrupamento");
            sql.AppendLine("    , animal_medicamento.posologia");
            sql.AppendLine("    , animal_medicamento.dose");
            sql.AppendLine("    , animal_medicamento.total_dose");
            sql.AppendLine("    , animal_medicamento.dia_atual");
            sql.AppendLine("    , animal_medicamento.total_dias");
            sql.AppendLine("    , animal_medicamento.data_iniciou");
            sql.AppendLine("    , animal_medicamento.data_previsao");
            sql.AppendLine("    , animal_medicamento.data_realizou");
            sql.AppendLine("    , animal_medicamento.data_cadastro");
            sql.AppendLine("    , animal_medicamento.data_ultalt");
            sql.AppendLine("    , animal_medicamento.aplicado");
            sql.AppendLine("    , animal_medicamento.id_tratamento");
            sql.AppendLine("    , animal_medicamento.observacao");
            sql.AppendLine("FROM animal_medicamento");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Codigo);

            AnimalMedicamento item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new AnimalMedicamento()
                        {
                            Id = scom.GetValue<long>("id"),
                            SCodAgrupamento = scom.GetValue<string>("codigo_agrupamento"),
                            IDose = scom.GetValue<int>("dose"),
                            ITotalDose = scom.GetValue<int>("total_dose"),
                            IDiaAtual = scom.GetValue<int>("dia_atual"),
                            IQuantidadeDias = scom.GetValue<int>("total_dias"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Aplicado = scom.GetValue<bool>("aplicado"),
                            DtmInicio = scom.GetValue<DateTime?>("data_iniciou"),
                            DtmMedicado = scom.GetValue<DateTime?>("data_realizou"),
                            DtmPrevisao = scom.GetValue<DateTime?>("data_previsao"),
                            SPosologia = scom.GetValue<string>("posologia"),
                            SObservacao = scom.GetValue<string>("observacao")
                        };

                        #region Carrega dados do animal
                        if (scom.GetValue<long?>("id_animal") != null)
                        {
                            item.AnimalMedicado = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal")
                            };
                        }
                        #endregion

                        #region Carrega dados do medicamento
                        if (scom.GetValue<long?>("id_medicamento") != null)
                        {
                            item.Medicamento = new Produto()
                            {
                                Id = scom.GetValue<long>("id_medicamento"),
                            };
                        }
                        #endregion

                        #region Carrega dados do usuário que aplicou
                        if (scom.GetValue<long?>("id_usuario_aplicou") != null)
                        {
                            item.QuemMedicou = new Usuario()
                            {
                                Id = scom.GetValue<long>("id_usuario_aplicou"),
                            };
                        }
                        #endregion

                        #region Carrega tratamento
                        if(scom.GetValue<int?>("id_tratamento") != null)
                        {
                            item.Tratamento = new AnimalMedicamentoTratamento(scom.GetValue<int>("id_tratamento"));
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static List<AnimalMedicamento> Dashboard()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      animal_medicamento.id");
            sql.AppendLine("    , animal_medicamento.id_animal");
            sql.AppendLine("    , animal_medicamento.id_medicamento");
            sql.AppendLine("    , animal_medicamento.codigo_agrupamento");
            sql.AppendLine("    , animal_medicamento.total_dose");
            sql.AppendLine("    , animal_medicamento.total_dias");
            sql.AppendLine("    , animal_medicamento.data_iniciou");
            sql.AppendLine("    , animal_medicamento.data_cadastro");

            sql.AppendLine("    , animal.nome as AnimalNome");
            sql.AppendLine("    , animal.id_porte");

            sql.AppendLine("    , medicamento.nome as MedicamentoNome");
            sql.AppendLine("    , medicamento.nome_comercial as MedicamentoNomeComercial");

            sql.AppendLine("    , animal_medicamento.dose");
            sql.AppendLine("    , animal_medicamento.dia_atual");
            sql.AppendLine("    , animal_medicamento.data_previsao");
            sql.AppendLine("    , animal_medicamento.data_realizou");
            sql.AppendLine("    , animal_medicamento.data_ultalt");
            sql.AppendLine("    , animal_medicamento.aplicado");
            sql.AppendLine("    , animal_medicamento.posologia");

            sql.AppendLine("    , animal_medicamento.observacao");
            sql.AppendLine("    , animal_medicamento.id_tratamento");

            sql.AppendLine("    , animal_medicamento_tratamento.nome AS TratamentoNome");
            sql.AppendLine("    , animal_medicamento_tratamento.descricao AS TratamentoDescricao");
            sql.AppendLine("FROM animal_medicamento");

            sql.AppendLine("    INNER JOIN animal ON animal.id = animal_medicamento.id_animal AND animal.status = 1");
            sql.AppendLine("    INNER JOIN produto medicamento ON medicamento.id = animal_medicamento.id_medicamento");
            sql.AppendLine("    LEFT JOIN animal_medicamento_tratamento ON animal_medicamento_tratamento.id = animal_medicamento.id_tratamento");
            sql.AppendLine("WHERE animal_medicamento.status = 1");
            sql.AppendLine("    AND (animal_medicamento.data_previsao IS NULL OR animal_medicamento.data_previsao <= @data_previsao)");
            sql.AppendLine("    AND animal_medicamento.aplicado = 0");
            sql.AppendLine("ORDER BY data_previsao, dose, animal.nome, medicamento.nome ");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@data_previsao", DateTime.Today);

            List<AnimalMedicamento> Lst = new List<AnimalMedicamento>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalMedicamento>();
                    AnimalMedicamento item = null;

                    while (scom.Read())
                    {
                        item = new AnimalMedicamento()
                        {
                            SCodAgrupamento = scom.GetValue<string>("codigo_agrupamento"),
                            ITotalDose = scom.GetValue<int>("total_dose"),
                            IQuantidadeDias = scom.GetValue<int>("total_dias"),
                            DtmInicio = scom.GetValue<DateTime?>("data_iniciou"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            IDose = scom.GetValue<int>("dose"),
                            IDiaAtual = scom.GetValue<int>("dia_atual"),
                            DtmPrevisao = scom.GetValue<DateTime?>("data_previsao"),
                            DtmMedicado = scom.GetValue<DateTime?>("data_realizou"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Aplicado = scom.GetValue<bool>("aplicado"),
                            Id = scom.GetValue<long>("id"),
                            SPosologia = scom.GetValue<string>("posologia"),
                            SObservacao = scom.GetValue<string>("observacao")
                        };

                        item.Liberado = Lst.FirstOrDefault(w => w.SCodAgrupamento == item.SCodAgrupamento && w.DtmPrevisao == item.DtmPrevisao) == null;

                        #region Carrega dados do Animal
                        if (scom.GetValue<long?>("id_animal") != null)
                        {
                            item.AnimalMedicado = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal"),
                                SNome = scom.GetValue<string>("AnimalNome"),
                                Porte = Porte.Obter(scom.GetValue<int>("id_porte"))
                            };
                        }
                        #endregion

                        #region Carrega dados do Medicamento
                        if (scom.GetValue<long?>("id_medicamento") != null)
                        {
                            item.Medicamento = new Produto()
                            {
                                Id = scom.GetValue<long>("id_medicamento"),
                                SNome = scom.GetValue<string>("MedicamentoNome"),
                                SNomeComercial = scom.GetValue<string>("MedicamentoNomeComercial"),
                            };
                        }
                        #endregion

                        #region Carrega tratamento
                        if(scom.GetValue<int?>("id_tratamento") != null)
                        {
                            item.Tratamento = new AnimalMedicamentoTratamento()
                            {
                                Id = scom.GetValue<int>("id_tratamento"),
                                SDescricao = scom.GetValue<string>("TratamentoDescricao"),
                                SNome = scom.GetValue<string>("TratamentoNome"),
                            };
                        }
                        #endregion

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        /// <summary>
        /// Pesquisa agrupada, para a tela de listagem
        /// </summary>
        /// <param name="_Animal"></param>
        /// <param name="_Previsao"></param>
        /// <param name="_Medicamento"></param>
        /// <param name="_PendenteOuAplicado"></param>
        /// <param name="_Agrupamento"></param>
        /// <returns></returns>
        internal static List<AnimalMedicamento> Pesquisar(long? _Animal, DateTime? _Previsao, long? _Medicamento, bool? _PendenteOuAplicado, string _Agrupamento, int? _Tratamento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      animal_medicamento.id_animal");
            sql.AppendLine("    , animal_medicamento.id_medicamento");
            sql.AppendLine("    , animal_medicamento.codigo_agrupamento");
            sql.AppendLine("    , animal_medicamento.total_dose");
            sql.AppendLine("    , animal_medicamento.total_dias");
            sql.AppendLine("    , animal_medicamento.data_iniciou");
            sql.AppendLine("    , animal_medicamento.data_cadastro");

            sql.AppendLine("    , animal.nome as AnimalNome");
            sql.AppendLine("    , animal.id_porte");

            sql.AppendLine("    , medicamento.nome as MedicamentoNome");
            sql.AppendLine("    , medicamento.nome_comercial as MedicamentoNomeComercial");

            sql.AppendLine("    , animal_medicamento.observacao");
            sql.AppendLine("    , animal_medicamento.id_tratamento");
            sql.AppendLine("    , animal_medicamento_tratamento.nome AS TratamentoNome");

            sql.AppendLine("FROM animal_medicamento");

            sql.AppendLine("    INNER JOIN animal ON animal.id = animal_medicamento.id_animal");
            sql.AppendLine("    INNER JOIN produto medicamento ON medicamento.id = animal_medicamento.id_medicamento");
            sql.AppendLine("    LEFT JOIN animal_medicamento_tratamento ON animal_medicamento_tratamento.id = animal_medicamento.id_tratamento");

            sql.AppendLine("WHERE animal_medicamento.status = 1");

            if (_Animal != null && _Animal > 0)
                sql.AppendLine("    AND animal_medicamento.id_animal = @id_animal");

            if (_Previsao != null && _Previsao != new DateTime())
                sql.AppendLine("    AND (animal_medicamento.data_previsao IS NULL OR animal_medicamento.data_previsao = @data_previsao)");

            if (_Medicamento != null && _Medicamento > 0)
                sql.AppendLine("    AND animal_medicamento.id_medicamento = @id_medicamento");

            if (_PendenteOuAplicado != null)
                sql.AppendLine("    AND animal_medicamento.aplicado = @aplicado");

            if (!String.IsNullOrEmpty(_Agrupamento))
                sql.AppendLine("    AND animal_medicamento.codigo_agrupamento = @codigo_agrupamento");

            if (_Tratamento != null && _Tratamento > 0)
                sql.AppendLine("    AND animal_medicamento.id_tratamento = @id_tratamento");

            sql.AppendLine("GROUP BY   animal_medicamento.id_animal");
            sql.AppendLine("    , animal_medicamento.id_medicamento");
            sql.AppendLine("    , animal_medicamento.codigo_agrupamento");
            sql.AppendLine("    , animal_medicamento.total_dose");
            sql.AppendLine("    , animal_medicamento.total_dias");
            sql.AppendLine("    , animal_medicamento.data_iniciou");
            sql.AppendLine("    , DATE(animal_medicamento.data_cadastro)");
            sql.AppendLine("    , animal_medicamento.id_tratamento");
            sql.AppendLine("    , animal_medicamento.observacao");
            sql.AppendLine("    , animal_medicamento_tratamento.nome");


            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_animal", _Animal);
            scom.AddWithValue("@data_previsao", _Previsao);
            scom.AddWithValue("@id_medicamento", _Medicamento);
            scom.AddWithValue("@aplicado", _PendenteOuAplicado);
            scom.AddWithValue("@codigo_agrupamento", _Agrupamento);
            scom.AddWithValue("@id_tratamento", _Tratamento);

            List<AnimalMedicamento> Lst = new List<AnimalMedicamento>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<AnimalMedicamento>();
                    AnimalMedicamento item = null;

                    while (scom.Read())
                    {
                        item = new AnimalMedicamento()
                        {
                            SCodAgrupamento = scom.GetValue<string>("codigo_agrupamento"),
                            ITotalDose = scom.GetValue<int>("total_dose"),
                            IQuantidadeDias = scom.GetValue<int>("total_dias"),
                            DtmInicio = scom.GetValue<DateTime?>("data_iniciou"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            SObservacao = scom.GetValue<string>("observacao")
                        };

                        #region Carrega dados do Animal
                        if (scom.GetValue<long?>("id_animal") != null)
                        {
                            item.AnimalMedicado = new Animal()
                            {
                                Id = scom.GetValue<long>("id_animal"),
                                SNome = scom.GetValue<string>("AnimalNome"),
                            };

                            if (scom.GetValue<int?>("id_porte") != null)
                                item.AnimalMedicado.Porte = Porte.Obter(scom.GetValue<int>("id_porte"));
                            else item.AnimalMedicado.Porte = new Porte(0, "N/D");
                        }
                        #endregion

                        #region Carrega dados do Medicamento
                        if (scom.GetValue<long?>("id_medicamento") != null)
                        {
                            item.Medicamento = new Produto()
                            {
                                Id = scom.GetValue<long>("id_medicamento"),
                                SNome = scom.GetValue<string>("MedicamentoNome"),
                                SNomeComercial = scom.GetValue<string>("MedicamentoNomeComercial"),
                            };
                        }
                        #endregion

                        #region Carrega tratamento
                        if (scom.GetValue<int?>("id_tratamento") != null)
                        {
                            item.Tratamento = new AnimalMedicamentoTratamento()
                            {
                                Id = scom.GetValue<int>("id_tratamento"),
                                SNome = scom.GetValue<string>("TratamentoNome")
                            };
                        }
                        #endregion

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