using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Dao
{
    internal class DaoPerfilPermissao
    {
        internal static List<PerfilPermissao> Pesquisar(long _Perfil)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("      formularios.id        AS FormularioID");
            sql.AppendLine("    , formularios.nome      AS FormularioNome");
            sql.AppendLine("    , formularios.path      AS FormularioPath");
            sql.AppendLine("    , formularios.data_cadastro AS FormularioData");
            sql.AppendLine("    , formularios.data_ultalt AS FormularioUltAlt");
            sql.AppendLine("    , formularios.status    AS FormularioStatus");
            sql.AppendLine("    , formularios.eh_menu   AS FormularioEhMenu");
            sql.AppendLine("    , formularios.id_menu_pai AS FormularioIdPai");
            sql.AppendLine("    , formularios.css_menu  AS FormularioCSSMenu");
            sql.AppendLine("    , formularios.css_icone AS FormularioCSSICone");
            sql.AppendLine("    , formularios.grupo     AS FormularioGrupo");
            sql.AppendLine("    , formularios.sequencia_menu AS FormularioSequencia");
            sql.AppendLine("    , formularios.url_curta AS FormularioUrlCurta");
            sql.AppendLine("    , IFNULL(CASE WHEN eh_menu = 1 AND id_menu_pai = 0 THEN formularios.id ELSE id_menu_pai END,0) AS MenuPaiFull");
            sql.AppendLine("    , IFNULL(fpa.abrir,0) as abrir");
            sql.AppendLine("    , IFNULL(fpa.pesquisar,0) as pesquisar");
            sql.AppendLine("    , IFNULL(fpa.inserir,0) as inserir");
            sql.AppendLine("    , IFNULL(fpa.alterar,0) as alterar");
            sql.AppendLine("    , IFNULL(fpa.excluir,0) as excluir");
            sql.AppendLine("    , IFNULL(fpa.especial,0) as especial");
            sql.AppendLine("FROM formularios");
            sql.AppendLine("LEFT JOIN formulario_x_perfil_x_acesso fpa ON fpa.id_formulario = formularios.id");
            sql.AppendLine("                                          AND fpa.id_perfil = @id_perfil");
            sql.AppendLine("WHERE status = 1");
            //sql.AppendLine("ORDER BY formularios.eh_menu, IFNULL(grupo,0);");
            sql.AppendLine("ORDER BY  IFNULL(CASE WHEN eh_menu = 1 AND id_menu_pai = 0 THEN formularios.id ELSE id_menu_pai END,0), id_menu_pai");
            
            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id_perfil", _Perfil);

            List<PerfilPermissao> Lst = new List<PerfilPermissao>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<PerfilPermissao>();
                    PerfilPermissao item = null;
                    while (scom.Read()) 
                    {
                        item = new PerfilPermissao()
                        {
                            Abrir = scom.GetValue<bool>("abrir"),
                            Pesquisar = scom.GetValue<bool>("pesquisar"),
                            Inserir = scom.GetValue<bool>("inserir"),
                            Alterar = scom.GetValue<bool>("alterar"),
                            Excluir = scom.GetValue<bool>("excluir"),
                            Especial = scom.GetValue<bool>("especial"),
                        };

                        item.Formulario = new Formulario()
                        {
                            Id = scom.GetValue<int>("FormularioID"),
                            SNome = scom.GetValue<string>("FormularioNome"),
                            SPath = scom.GetValue<string>("FormularioPath"),
                            Status = scom.GetValue<bool>("FormularioStatus"),

                            SClass = scom.GetValue<string>("FormularioCSSMenu"),
                            SIcone = scom.GetValue<string>("FormularioCSSICone"),
                            SUrlCurta = scom.GetValue<string>("FormularioUrlCurta"),
                            DtmCadastro = scom.GetValue<DateTime>("FormularioData"),
                            DtmUltAlt = scom.GetValue<DateTime>("FormularioUltAlt"),
                            EhMenu = scom.GetValue<bool>("FormularioEhMenu"),
                            IAgrupador = scom.GetValue<int>("FormularioGrupo"),
                            IdPai = scom.GetValue<int?>("FormularioIdPai"),
                            ISequenciaMenu = scom.GetValue<int>("FormularioSequencia"),
                        };

                        if (scom.GetValue<object>("MenuPaiFull") != null && item.Formulario != null) item.Formulario.MenuPaiFull = Convert.ToInt32(scom.GetValue<object>("MenuPaiFull"));

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