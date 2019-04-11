using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoPerfil
    {
        internal static List<Perfil> Pesquisar()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM perfil");
            sql.AppendLine("WHERE status=1;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);

            List<Perfil> Lst = new List<Perfil>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Perfil>();
                    Perfil item = null;
                    while (scom.Read())
                    {
                        item = new Perfil()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        Lst.Add(item);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Perfil Obter(long _Perfil)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("      id");
            sql.AppendLine("    , nome");
            sql.AppendLine("    , data_cadastro");
            sql.AppendLine("    , data_ultalt");
            sql.AppendLine("    , status");
            sql.AppendLine("FROM perfil");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Perfil);
            Perfil item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item = new Perfil()
                        {
                            Id = scom.GetValue<long>("id"),
                            SNome = scom.GetValue<string>("nome"),
                            DtmCadastro = scom.GetValue<DateTime>("data_cadastro"),
                            DtmUltAlt = scom.GetValue<DateTime>("data_ultalt"),
                            Status = scom.GetValue<bool>("status")
                        };

                        item.LstPermissao = DaoPerfilPermissao.Pesquisar(item.Id);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Excluir(Perfil item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE perfil SET");
            sql.AppendLine("      data_ultalt = NOW()");
            sql.AppendLine("    , status = 0");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void Salvar(Perfil item)
        {
            if (item == null) throw new Exception("Atenção! O objeto PERFIL não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Perfil item)
        {
            cMySqlCommand scom = new cMySqlCommand("INSERT INTO perfil (nome) VALUES (@nome);SELECT LAST_INSERT_ID();", System.Data.CommandType.Text);
            scom.AddWithValue("@nome", item.SNome);
            try
            {
                scom.ExecuteReader();
                long l = 0;
                if (scom.HasRows && scom.Read()) long.TryParse(scom.GetValue<object>(0).ToString(), out l);
                item.Id = l;

                if (item.Id > 0 && item.LstPermissao != null && item.LstPermissao.Count > 0)
                {
                    StringBuilder sql2 = new StringBuilder();
                    sql2.AppendLine("REPLACE INTO formulario_x_perfil_x_acesso (id_formulario, id_perfil, abrir, pesquisar, inserir, alterar, excluir, especial)");
                    sql2.AppendLine("VALUES (@id_formulario, @id_perfil, @abrir, @pesquisar, @inserir, @alterar, @excluir, @especial);");
                    cMySqlCommand scom2 = new cMySqlCommand(sql2.ToString(), System.Data.CommandType.Text);
                    for (int i = 0; i < item.LstPermissao.Count; i++)
                    {
                        scom2.AddWithValue("@id_formulario", item.LstPermissao[i].Formulario.Id);
                        scom2.AddWithValue("@id_perfil", item.Id);
                        scom2.AddWithValue("@abrir", item.LstPermissao[i].Abrir ? 1 : 0);
                        scom2.AddWithValue("@pesquisar", item.LstPermissao[i].Pesquisar ? 1 : 0);
                        scom2.AddWithValue("@inserir", item.LstPermissao[i].Inserir ? 1 : 0);
                        scom2.AddWithValue("@alterar", item.LstPermissao[i].Alterar ? 1 : 0);
                        scom2.AddWithValue("@excluir", item.LstPermissao[i].Excluir ? 1 : 0);
                        scom2.AddWithValue("@especial", item.LstPermissao[i].Especial ? 1 : 0);

                        scom2.ExecuteNonQuery();
                        scom2.Clear();
                    }

                    scom2.Close();
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Perfil item)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE perfil SET");
            sql.AppendLine("      nome = @nome");
            sql.AppendLine("    , status = @status");
            sql.AppendLine("WHERE id=@id;");

            cMySqlCommand scom = new cMySqlCommand(sql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@nome", item.SNome);
            scom.AddWithValue("@status", item.Status ? 1 : 0);

            try
            {
                scom.ExecuteNonQuery();
                if (item.Id > 0 && item.LstPermissao != null && item.LstPermissao.Count > 0)
                {
                    StringBuilder sql2 = new StringBuilder();
                    sql2.AppendLine("REPLACE INTO formulario_x_perfil_x_acesso (id_formulario, id_perfil, abrir, pesquisar, inserir, alterar, excluir, especial)");
                    sql2.AppendLine("VALUES (@id_formulario, @id_perfil, @abrir, @pesquisar, @inserir, @alterar, @excluir, @especial);");
                    cMySqlCommand scom2 = new cMySqlCommand(sql2.ToString(), System.Data.CommandType.Text);
                    for (int i = 0; i < item.LstPermissao.Count; i++)
                    {
                        scom2.AddWithValue("@id_formulario", item.LstPermissao[i].Formulario.Id);
                        scom2.AddWithValue("@id_perfil", item.Id);
                        scom2.AddWithValue("@abrir", item.LstPermissao[i].Abrir ? 1 : 0);
                        scom2.AddWithValue("@pesquisar", item.LstPermissao[i].Pesquisar ? 1 : 0);
                        scom2.AddWithValue("@inserir", item.LstPermissao[i].Inserir ? 1 : 0);
                        scom2.AddWithValue("@alterar", item.LstPermissao[i].Alterar ? 1 : 0);
                        scom2.AddWithValue("@excluir", item.LstPermissao[i].Excluir ? 1 : 0);
                        scom2.AddWithValue("@especial", item.LstPermissao[i].Especial ? 1 : 0);

                        scom2.ExecuteNonQuery();
                        scom2.Clear();
                    }

                    scom2.Close();
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}