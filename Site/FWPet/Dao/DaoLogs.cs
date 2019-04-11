using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoLogs
    {
        internal static List<Logs> Pesquisar(DateTime? _PeriodoDe, DateTime? _PeriodoAte, int? _Tela, long? _Usuario, int? _Acao, int _QuantRegistros)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      logs.id");
            sql.AppendLine("    , logs.descricao");
            sql.AppendLine("    , logs.data_cadastro");
            sql.AppendLine("    , logs.id_usuario");
            sql.AppendLine("    , logs.id_formulario");
            sql.AppendLine("    , logs.id_log_acao");
            sql.AppendLine("    , logs.objeto_antes");
            sql.AppendLine("    , logs.objeto_depois");
            sql.AppendLine("    , logs.tipo_do_objeto");

            //USUÁRIO
            sql.AppendLine("    , usuario.sid AS UsuarioID");
            sql.AppendLine("    , usuario.login AS UsuarioLOGIN");
            sql.AppendLine("    , usuario.nome AS UsuarioNOME");
            
            //LOG AÇÃO
            sql.AppendLine(", log_acao.descricao AS AcaoDescricao");
            sql.AppendLine(", log_acao.texto AS AcaoTexto");

            //FORMULÁRIO
            sql.AppendLine("    , formularios.nome AS FormularioNome");
            sql.AppendLine("    , formularios.path AS FormularioPath");

            sql.AppendLine("FROM logs");

            sql.AppendLine("LEFT JOIN usuario ON usuario.id = logs.id_usuario");
            sql.AppendLine("LEFT JOIN formularios ON formularios.id = logs.id_formulario");
            sql.AppendLine("LEFT JOIN log_acao ON log_acao.id = logs.id_log_acao");

            sql.AppendLine("WHERE 1=1");
            if (_PeriodoDe != null && _PeriodoDe != new DateTime() && _PeriodoAte != null && _PeriodoAte != new DateTime())
                sql.AppendLine("AND logs.data_cadastro BETWEEN @periodo_de AND @periodo_ate");
            else
            {
                if (_PeriodoDe != null && _PeriodoDe != new DateTime())
                    sql.AppendLine("AND logs.data_cadastro >= @periodo_de");
                if (_PeriodoAte != null && _PeriodoAte != new DateTime())
                    sql.AppendLine("AND logs.data_cadastro <= @periodo_ate");
            }

            if (_Tela != null && _Tela > 0)
                sql.AppendLine("AND logs.id_formulario=@id_formulario");
            if (_Usuario != null && _Usuario > 0)
                sql.AppendLine("AND logs.id_usuario=@id_usuario");
            if (_Acao != null && _Acao > 0)
                sql.AppendLine("AND logs.id_log_acao=@id_log_acao");

            sql.AppendLine("ORDER BY logs.data_cadastro DESC");
            if (_QuantRegistros > 0)
                sql.AppendLine(" LIMIT " + _QuantRegistros);

            _PeriodoDe = new DateTime(_PeriodoDe.Value.Year, _PeriodoDe.Value.Month, _PeriodoDe.Value.Day, 0, 0, 0);
            _PeriodoAte = new DateTime(_PeriodoAte.Value.Year, _PeriodoAte.Value.Month, _PeriodoAte.Value.Day, 23, 59, 59);
            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@periodo_de", _PeriodoDe);
            scom.AddWithValue("@periodo_ate", _PeriodoAte);
            scom.AddWithValue("@id_formulario", _Tela);
            scom.AddWithValue("@id_usuario", _Usuario);
            scom.AddWithValue("@id_log_acao", _Acao);

            List<Logs> Lst = new List<Logs>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Logs>();
                    Logs item = null;
                    while (scom.Read())
                    {
                        item = new Logs()
                        {
                            Id = scom.GetValue<long>("id"),
                            SDescricao = scom.GetValue<string>("descricao"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            SObjetoAntes = scom.GetValue<string>("objeto_antes"),
                            SObjetoDepois = scom.GetValue<string>("objeto_depois"),
                            TipoDoObjeto = (scom.GetValue<object>("tipo_do_objeto") as Type)
                        };

                        if (scom.GetValue<long?>("id_usuario") != null)
                        {
                            item.Usuario = new Usuario()
                            {
                                Id = scom.GetValue<long>("id_usuario"),
                                SId = scom.GetValue<string>("UsuarioID"),
                                SLogin = scom.GetValue<string>("UsuarioLOGIN"),
                                SNome = scom.GetValue<string>("UsuarioNOME"),
                            };
                        }

                        if (scom.GetValue<int?>("id_formulario") != null)
                        {
                            item.Tela = new Formulario()
                            {
                                Id = scom.GetValue<int>("id_formulario"),
                                SNome = scom.GetValue<string>("FormularioNome"),
                                SPath = scom.GetValue<string>("FormularioPath")
                            };
                        }

                        if (scom.GetValue<int?>("id_log_acao") != null)
                        {
                            item.Acao = new LogAcao()
                            {
                                Id = scom.GetValue<int>("id_log_acao"),
                                SDescricao = scom.GetValue<string>("AcaoDescricao"),
                                STexto = scom.GetValue<string>("AcaoTexto"),
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

        internal static Logs Obter(long id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      logs.id");
            sql.AppendLine("    , logs.descricao");
            sql.AppendLine("    , logs.data_cadastro");
            sql.AppendLine("    , logs.id_usuario");
            sql.AppendLine("    , logs.id_formulario");
            sql.AppendLine("    , logs.id_log_acao");
            sql.AppendLine("    , logs.objeto_antes");
            sql.AppendLine("    , logs.objeto_depois");
            sql.AppendLine("    , logs.tipo_do_objeto");

            //USUÁRIO
            sql.AppendLine("    , usuario.sid AS UsuarioID");
            sql.AppendLine("    , usuario.login AS UsuarioLOGIN");
            sql.AppendLine("    , usuario.nome AS UsuarioNOME");

            //LOG AÇÃO
            sql.AppendLine("    , log_acao.descricao AS AcaoDescricao");
            sql.AppendLine("    , log_acao.texto AS AcaoTexto");

            //FORMULÁRIO
            sql.AppendLine("    , formularios.nome AS FormularioNome");
            sql.AppendLine("    , formularios.path AS FormularioPath");

            sql.AppendLine("FROM logs");

            sql.AppendLine("LEFT JOIN usuario ON usuario.id = logs.id_usuario");
            sql.AppendLine("LEFT JOIN formularios ON formularios.id = logs.id_formulario");
            sql.AppendLine("LEFT JOIN log_acao ON log_acao.id = logs.id_log_acao");

            sql.AppendLine("WHERE 1=1");
            sql.AppendLine("    AND logs.id = @id");

            cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
            scom.AddWithValue("@id", id);

            Logs item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows && scom.Read())
                {
                    item = new Logs()
                    {
                        Id = scom.GetValue<long>("id"),
                        SDescricao = scom.GetValue<string>("descricao"),
                        DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                        SObjetoAntes = scom.GetValue<string>("objeto_antes"),
                        SObjetoDepois = scom.GetValue<string>("objeto_depois"),
                        TipoDoObjeto = scom.GetValue<object>("tipo_do_objeto") as Type
                    };

                    if (scom.GetValue<long?>("id_usuario") != null)
                    {
                        item.Usuario = new Usuario()
                        {
                            Id = scom.GetValue<long>("id_usuario"),
                            SId = scom.GetValue<string>("UsuarioID"),
                            SLogin = scom.GetValue<string>("UsuarioLOGIN"),
                            SNome = scom.GetValue<string>("UsuarioNOME"),
                        };
                    }

                    if (scom.GetValue<int?>("id_formulario") != null)
                    {
                        item.Tela = new Formulario()
                        {
                            Id = scom.GetValue<int>("id_formulario"),
                            SNome = scom.GetValue<string>("FormularioNome"),
                            SPath = scom.GetValue<string>("FormularioPath")
                        };
                    }

                    if (scom.GetValue<int?>("id_log_acao") != null)
                    {
                        item.Acao = new LogAcao()
                        {
                            Id = scom.GetValue<int>("id_log_acao"),
                            SDescricao = scom.GetValue<string>("AcaoDescricao"),
                            STexto = scom.GetValue<string>("AcaoTexto"),
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(Logs item)
        {
            if (item == null) throw new Exception("Atenção! O objeto LOGS não foi instanciado, verifique os dados!");
            else
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO logs (descricao, id_usuario, id_formulario, id_log_acao, objeto_antes, objeto_depois, tipo_do_objeto)");
                sql.AppendLine("VALUES (@descricao, @id_usuario, @id_formulario, @id_log_acao, @objeto_antes, @objeto_depois, @tipo_do_objeto);SELECT LAST_INSERT_ID();");

                cMySqlCommand scom = new cMySqlCommand(sql, System.Data.CommandType.Text);
                scom.AddWithValue("@descricao", item.SDescricao);
                scom.AddWithValue("@id_usuario", item.Usuario == null ? 0 : item.Usuario.Id);
                scom.AddWithValue("@id_formulario", item.Tela == null ? 0 : item.Tela.Id);
                scom.AddWithValue("@id_log_acao", item.Acao == null ? 0 : item.Acao.Id);
                scom.AddWithValue("@objeto_antes", item.SObjetoAntes + "");
                scom.AddWithValue("@objeto_depois", item.SObjetoDepois + "");
                scom.AddWithValue("@tipo_do_objeto", item.TipoDoObjeto.ToString());

                try
                {
                    scom.ExecuteReader();
                    if (scom.HasRows && scom.Read())
                    {
                        object id = scom.GetValue<object>(0);
                        if (id != null && !String.IsNullOrEmpty(id.ToString())) item.Id = Convert.ToInt64(id);
                    }
                }
                catch(Exception ex) { throw ex; }
                finally { scom.Close(); }
            }
        }
    }
}
