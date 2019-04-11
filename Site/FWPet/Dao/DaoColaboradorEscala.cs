using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    class DaoColaboradorEscala
    {
        internal static List<ColaboradorEscala> Escalas(string _MesAno, long _Colaborador)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      colaborador_escalas.id");
            sql.AppendLine("    , colaborador_escalas.idColaborador");
            sql.AppendLine("    , colaborador_escalas.titulo");
            sql.AppendLine("    , colaborador_escalas.url");
            sql.AppendLine("    , colaborador_escalas.css_classe");
            sql.AppendLine("    , colaborador_escalas.descricao");
            sql.AppendLine("    , colaborador_escalas.data_inicio");
            sql.AppendLine("    , colaborador_escalas.data_final");
            sql.AppendLine("    , colaborador_escalas.data_cadastro");
            sql.AppendLine("    , colaborador_escalas.data_ultalt");
            sql.AppendLine("    , colaborador_escalas.status");
            sql.AppendLine("FROM colaborador_escalas");
            sql.AppendLine("    INNER JOIN pessoa ON pessoa.id = colaborador_escalas.idColaborador");
            sql.AppendLine("WHERE colaborador_escalas.status = 1");
            if (_Colaborador > 0)
                sql.AppendLine("AND colaborador_escalas.idColaborador = @colaborador");

            DateTime dtmInicio;
            DateTime dtmFinal;
            if (DateTime.TryParse("01/" + _MesAno + " 00:00:00", out dtmInicio) && dtmInicio != new DateTime())
                dtmFinal = dtmInicio.AddMonths(1);
            else
            {
                dtmInicio = DateTime.Today;
                dtmFinal = dtmInicio.AddMonths(1);
            }

            if (!String.IsNullOrEmpty(_MesAno))
                sql.AppendLine("AND colaborador_escalas.data_inicio BETWEEN @datainicio AND @datafinal");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@colaborador", _Colaborador);
            scom.AddWithValue("@datainicio", dtmInicio.ToString("yyyy-MM-dd HH:mm:ss"));
            scom.AddWithValue("@datafinal", dtmFinal.ToString("yyyy-MM-dd HH:mm:ss"));

            List <ColaboradorEscala> Lst = new List<ColaboradorEscala>();
            try
            {
                scom.ExecuteReader();
                if(scom.HasRows)
                {
                    Lst = new List<ColaboradorEscala>();
                    ColaboradorEscala item = null;
                    while (scom.Read())
                    {
                        item = new ColaboradorEscala()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNomeColaborador = scom.GetValue<string>("titulo"),
                            SUrl = scom.GetValue<string>("url"),
                            SClasse = scom.GetValue<string>("css_classe"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmInicio = scom.GetValue<DateTime>("data_inicio"),
                            DtmFinal = scom.GetValue<DateTime?>("data_final"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch(Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static List<ColaboradorEscala> Escalas(string _DataInicio, string _DataTermino, long _Colaborador)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      colaborador_escalas.id");
            sql.AppendLine("    , colaborador_escalas.idColaborador");
            sql.AppendLine("    , colaborador_escalas.titulo");
            sql.AppendLine("    , colaborador_escalas.url");
            sql.AppendLine("    , colaborador_escalas.css_classe");
            sql.AppendLine("    , colaborador_escalas.descricao");
            sql.AppendLine("    , colaborador_escalas.data_inicio");
            sql.AppendLine("    , colaborador_escalas.data_final");
            sql.AppendLine("    , colaborador_escalas.data_cadastro");
            sql.AppendLine("    , colaborador_escalas.data_ultalt");
            sql.AppendLine("    , colaborador_escalas.status");
            sql.AppendLine("FROM colaborador_escalas");
            sql.AppendLine("    INNER JOIN pessoa ON pessoa.id = colaborador_escalas.idColaborador");
            sql.AppendLine("WHERE colaborador_escalas.status = 1");
            if (_Colaborador > 0)
                sql.AppendLine("AND colaborador_escalas.idColaborador = @colaborador");

            DateTime dtmInicio = new DateTime();
            DateTime dtmFinal = new DateTime();
            
            if (DateTime.TryParse(_DataInicio, out dtmInicio) && DateTime.TryParse(_DataTermino, out dtmFinal))
                sql.AppendLine("AND colaborador_escalas.data_inicio BETWEEN @datainicio AND @datafinal");
            else if(dtmInicio != new DateTime()) sql.AppendLine("AND colaborador_escalas.data_inicio > @datainicio");
            else if(dtmFinal != new DateTime()) sql.AppendLine("AND colaborador_escalas.data_inicio < @datafinal");


            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@colaborador", _Colaborador);
            scom.AddWithValue("@datainicio", dtmInicio.ToString("yyyy-MM-dd") + " 00:00:00");
            scom.AddWithValue("@datafinal", dtmFinal.ToString("yyyy-MM-dd") + " 23:59:59");

            List<ColaboradorEscala> Lst = new List<ColaboradorEscala>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<ColaboradorEscala>();
                    ColaboradorEscala item = null;
                    while (scom.Read())
                    {
                        item = new ColaboradorEscala()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNomeColaborador = scom.GetValue<string>("titulo"),
                            SUrl = scom.GetValue<string>("url"),
                            SClasse = scom.GetValue<string>("css_classe"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmInicio = scom.GetValue<DateTime>("data_inicio"),
                            DtmFinal = scom.GetValue<DateTime?>("data_final"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Salvar(ColaboradorEscala item)
        {
            if (item == null) throw new Exception("Atenção! O objeto COLABORADORESCALA não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        internal static ColaboradorEscala Obter(long _Escala)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      colaborador_escalas.id");
            sql.AppendLine("    , colaborador_escalas.idColaborador");
            sql.AppendLine("    , colaborador_escalas.titulo");
            sql.AppendLine("    , colaborador_escalas.url");
            sql.AppendLine("    , colaborador_escalas.css_classe");
            sql.AppendLine("    , colaborador_escalas.descricao");
            sql.AppendLine("    , colaborador_escalas.data_inicio");
            sql.AppendLine("    , colaborador_escalas.data_final");
            sql.AppendLine("    , colaborador_escalas.data_cadastro");
            sql.AppendLine("    , colaborador_escalas.data_ultalt");
            sql.AppendLine("    , colaborador_escalas.status");
            sql.AppendLine("FROM colaborador_escalas");
            sql.AppendLine("    INNER JOIN pessoa ON pessoa.id = colaborador_escalas.idColaborador");
            sql.AppendLine("WHERE colaborador_escalas.id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Escala);

            ColaboradorEscala item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new ColaboradorEscala()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNomeColaborador = scom.GetValue<string>("titulo"),
                            SUrl = scom.GetValue<string>("url"),
                            SClasse = scom.GetValue<string>("css_classe"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmInicio = scom.GetValue<DateTime>("data_inicio"),
                            DtmFinal = scom.GetValue<DateTime?>("data_final"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Excluir(ColaboradorEscala item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE colaborador_escalas SET ");
            sql.AppendLine("      data_ultalt   = NOW()");
            sql.AppendLine("    , status        = 0");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Inserir(ColaboradorEscala item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO colaborador_escalas(idColaborador, titulo, url, css_classe, descricao, data_inicio, data_final)");
            sql.AppendLine("VALUES (@idColaborador, @titulo, @url, @css_classe, @descricao, @data_inicio, @data_final);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@idColaborador", item.IdColaborador);
            scom.AddWithValue("@titulo", item.SNomeColaborador);
            scom.AddWithValue("@url", item.SUrl);
            scom.AddWithValue("@css_classe", item.SClasse);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@data_inicio", item.DtmInicio);
            scom.AddWithValue("@data_final", item.DtmFinal);

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    long id;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out id);
                    item.Id = id;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(ColaboradorEscala item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE colaborador_escalas SET ");
            sql.AppendLine("      idColaborador = @idColaborador");
            sql.AppendLine("    , titulo        = @titulo");
            sql.AppendLine("    , url           = @url");
            sql.AppendLine("    , css_classe    = @css_classe");
            sql.AppendLine("    , descricao     = @descricao");
            sql.AppendLine("    , data_inicio   = @data_inicio");
            sql.AppendLine("    , data_final    = @data_final");
            sql.AppendLine("    , data_ultalt   = NOW()");
            sql.AppendLine("    , status        = @status");
            sql.AppendLine("WHERE id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@idColaborador", item.IdColaborador);
            scom.AddWithValue("@titulo", item.SNomeColaborador);
            scom.AddWithValue("@url", item.SUrl);
            scom.AddWithValue("@css_classe", item.SClasse);
            scom.AddWithValue("@descricao", item.SDescricao);
            scom.AddWithValue("@data_inicio", item.DtmInicio);
            scom.AddWithValue("@data_final", item.DtmFinal);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
