using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoFormulario
    {
        internal static Formulario Obter(int _Formulario)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , path");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , eh_menu");
            sql.AppendLine("    , id_menu_pai");
            sql.AppendLine("    , css_menu");
            sql.AppendLine("    , css_icone");
            sql.AppendLine("    , grupo");
            sql.AppendLine("    , sequencia_menu");
            sql.AppendLine("    , url_curta");
            sql.AppendLine("FROM formularios");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Formulario);

            Formulario item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Formulario()
                        {
                            Id = scom.GetValue<int>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SPath = scom.GetValue<string>("path"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            EhMenu = scom.GetValue<bool>("eh_menu"),
                            IdPai = scom.GetValue<int?>("id_menu_pai"),
                            SClass = scom.GetValue<string>("css_menu"),
                            SIcone = scom.GetValue<string>("css_icone"),
                            IAgrupador = scom.GetValue<int>("grupo"),
                            ISequenciaMenu = scom.GetValue<int>("sequencia_menu"),
                            SUrlCurta = scom.GetValue<string>("url_curta")
                        };
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static List<Formulario> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , path");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("    , eh_menu");
            sql.AppendLine("    , id_menu_pai");
            sql.AppendLine("    , css_menu");
            sql.AppendLine("    , css_icone");
            sql.AppendLine("    , grupo");
            sql.AppendLine("    , sequencia_menu");
            sql.AppendLine("    , url_curta");
            sql.AppendLine("FROM formularios");
            sql.AppendLine("WHERE status = 1;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);

            List<Formulario> Lst = new List<Formulario>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Formulario>();
                    Formulario item = null;
                    while (scom.Read())
                    {
                        item = new Formulario()
                        {
                            Id = scom.GetValue<int>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            SPath = scom.GetValue<string>("path"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status"),
                            EhMenu = scom.GetValue<bool>("eh_menu"),
                            IdPai = scom.GetValue<int?>("id_menu_pai"),
                            SClass = scom.GetValue<string>("css_menu"),
                            SIcone = scom.GetValue<string>("css_icone"),
                            IAgrupador = scom.GetValue<int>("grupo"),
                            ISequenciaMenu = scom.GetValue<int>("sequencia_menu"),
                            SUrlCurta = scom.GetValue<string>("url_curta")
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static void Excluir(Formulario item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE formularios SET ");
            sql.AppendLine("      data_ultalt = NOW()");
            sql.AppendLine("    , status = 0");
            sql.AppendLine("WHERE id = @id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Salvar(Formulario item)
        {
            if (item == null) throw new Exception("Atenção! O objeto FORMULARIO não foi instanciado, verifique os dados!");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }
        
        private static void Inserir(Formulario item)
        {
            cMySqlCommand scom = new cMySqlCommand("INSERT INTO formularios (nome, path, eh_menu, id_menu_pai, css_menu, css_icone, grupo, sequencia_menu, url_curta)VALUES(@nome, @path, @eh_menu, @id_menu_pai, @css_menu, @css_icone, @grupo, @sequencia_menu, @url_curta);SELECT LAST_INSERT_ID();", System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@path", item.SPath);
            scom.AddWithValue("@eh_menu", item.EhMenu ? 1 : 0);
            scom.AddWithValue("@id_menu_pai", item.IdPai);
            scom.AddWithValue("@css_menu", item.SClass);
            scom.AddWithValue("@css_icone", item.SIcone);
            scom.AddWithValue("@grupo", item.IAgrupador);
            scom.AddWithValue("@sequencia_menu", item.ISequenciaMenu);
            scom.AddWithValue("@url_curta", item.SUrlCurta);

            try
            {
                scom.ExecuteReader();
                int i = 0;
                if (scom.HasRows && scom.Read()) int.TryParse(scom.GetValue<object>(0).ToString(), out i);
                item.Id = i;
                //INSERIR O FORMULÁRIO EM TODOS OS PERFIS CADASTRADOS
                cMySqlCommand scom2 = new cMySqlCommand("REPLACE INTO formulario_x_perfil_x_acesso (id_formulario, id_perfil) SELECT @id_formulario, id FROM perfil;", System.Data.CommandType.Text);
                scom2.AddWithValue("@id_formulario", item.Id);
                scom2.ExecuteNonQuery();
                scom2.Close();
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Formulario item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE formularios SET ");
            sql.AppendLine("      nome = @nome");
            sql.AppendLine("    , path = @path");
            sql.AppendLine("    , data_ultalt = NOW()");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("    , eh_menu = @eh_menu");
            sql.AppendLine("    , id_menu_pai = @id_menu_pai");
            sql.AppendLine("    , css_menu= @css_menu");
            sql.AppendLine("    , css_icone= @css_icone");
            sql.AppendLine("    , grupo = @grupo");
            sql.AppendLine("    , sequencia_menu=@sequencia_menu");
            sql.AppendLine("    , url_curta = @url_curta");
            sql.AppendLine("WHERE id = @id;");
            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@path", item.SPath);
            scom.AddWithValue("@eh_menu", item.EhMenu ? 1 : 0);
            scom.AddWithValue("@id_menu_pai", item.IdPai);
            scom.AddWithValue("@status", item.Status ? 1 : 0);
            scom.AddWithValue("@css_menu", item.SClass);
            scom.AddWithValue("@css_icone", item.SIcone);
            scom.AddWithValue("@grupo", item.IAgrupador);
            scom.AddWithValue("@sequencia_menu", item.ISequenciaMenu);
            scom.AddWithValue("@url_curta", item.SUrlCurta);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}