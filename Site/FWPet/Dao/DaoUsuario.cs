using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Model;

namespace FWPet.Dao
{
    internal class DaoUsuario
    {
        internal static void Logar(Usuario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , sid");
            sSql.AppendLine("   , idpessoa");
            sSql.AppendLine("   , login");
            sSql.AppendLine("   , senha");
            sSql.AppendLine("   , email");
            sSql.AppendLine("   , idperfil");
            sSql.AppendLine("   , nome");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , data_ultimologin");
            sSql.AppendLine("   , status");
            sSql.AppendLine("   , ignora_permissao");
            sSql.AppendLine("FROM usuario");
            sSql.AppendLine("WHERE login = @login");
            sSql.AppendLine("  AND senha = @senha;");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@login", item.SLogin);
            scom.AddWithValue("@senha", Crypt.Criptografa(item.SSenha, Crypt.ProcuraGenerica("SELECT sid FROM usuario WHERE login='" + item.SLogin.Replace("'", "").Replace("%", "") + "'", "sid")));

            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if (scom.Read())
                    {
                        item.Id = scom.GetValue<long>("id");
                        item.SId = scom.GetValue<string>("sid");
                        item.IdPessoa = scom.GetValue<long?>("idpessoa");
                        item.SLogin = scom.GetValue<string>("login");
                        item.SSenha = scom.GetValue<string>("senha");
                        item.SEmail = scom.GetValue<string>("email");
                        item.SNome = scom.GetValue<string>("nome");
                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        item.DtmUltimoLogin = scom.GetValue<DateTime?>("data_ultimologin");
                        item.Status = scom.GetValue<bool>("status");
                        item.IgnoraPermissoes = scom.GetValue<bool>("ignora_permissao");//02.02.2017

                        if (scom.GetValue<long?>("idperfil") != null)
                            item.Perfil = Perfil.Obter(scom.GetValue<long>("idperfil"));

                        //Monta o menu do sistema
                        if(item.Perfil != null && item.Perfil.LstPermissao != null)
                        {
                            item.Perfil.LstPermissao = item.Perfil.LstPermissao.Where(w=>w.Abrir).OrderBy(w => w.Formulario.IdPai).OrderBy(w=>w.Formulario.ISequenciaMenu).ToList();
                            List<Formulario> Forms = new List<Formulario>();
                            List<Formulario> MenuPai = new List<Formulario>();

                            //Pega todos os forms que são menu.
                            for (int m = 0; m < item.Perfil.LstPermissao.Count; m++)
                            {
                                if (item.Perfil.LstPermissao[m].Formulario != null && item.Perfil.LstPermissao[m].Formulario.EhMenu)
                                    Forms.Add(item.Perfil.LstPermissao[m].Formulario);
                            }

                            //Pega todos os forms que estão na raiz ou seja IdPai = 0
                            MenuPai = Forms.Where(w => w.IdPai == 0).ToList();
                            //Pega todos os filhos dos pais
                            if (MenuPai != null && MenuPai.Count > 0)
                            {
                                for (int i = 0; i < MenuPai.Count; i++)
                                {
                                    MenuPai[i].Filhos = Forms.Where(w => w.IdPai == MenuPai[i].Id).ToList();
                                    if (MenuPai[i].Filhos.Count == 0) MenuPai[i].EhMenu = false;
                                }
                            }

                            item.Menu = MenuPai;
                        }

                        item.ConfigSis = Configuracoes.Obter();

                        sSql = new StringBuilder();
                        sSql.AppendLine("UPDATE usuario SET data_ultimologin = now() WHERE id = @id;");
                        scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
                        scom.AddWithValue("@id", item.Id);
                        scom.ExecuteNonQuery();
                    }
                }
                else throw new Exception("Nenhum resultado encontrado para os dados informados.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        internal static void ResetarSenha(Usuario item)
        {
            string sID = Crypt.ProcuraGenerica("SELECT sid FROM usuario WHERE login='" + item.SLogin.Replace("'", "").Replace("%", "") + "'", "sid");
            if (!String.IsNullOrEmpty(sID))
            {
                item.SId = sID;
                StringBuilder sSql = new StringBuilder();
                sSql.AppendLine("UPDATE usuario SET");
                sSql.AppendLine("     data_ultalt = NOW()");
                sSql.AppendLine("   , senha = @senha");
                sSql.AppendLine("WHERE sid = @sid;");

                string _ID = Crypt.ProcuraGenerica("SELECT email FROM usuario WHERE sid='" + sID + "'", "email");

                cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
                scom.AddWithValue("@sid", item.SId);
                scom.AddWithValue("@senha", Crypt.Criptografa(item.SSenha, sID));

                item.SEmail = _ID;

                try { scom.ExecuteNonQuery(); }
                catch (Exception ex) { throw ex; }
                finally { scom.Close(); }
            }
            else throw new Exception("Não foi localizado nenhum usuário correspondente.");
        }

        internal static void Excluir(Usuario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE usuario SET");
            sSql.AppendLine("   , data_ultalt = NOW()");
            sSql.AppendLine("   , status = 0");
            sSql.AppendLine("WHERE id=@id");
            sSql.AppendLine("   AND sid = @sid;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item.Id);
            scom.AddWithValue("@sid", item.SId);

            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
        
        internal static List<Usuario> Pesquisar()
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , sid");
            sSql.AppendLine("   , idpessoa");
            sSql.AppendLine("   , login");
            sSql.AppendLine("   , senha");
            sSql.AppendLine("   , email");
            sSql.AppendLine("   , idperfil");
            sSql.AppendLine("   , nome");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , data_ultimologin");
            sSql.AppendLine("   , status");
            sSql.AppendLine("FROM usuario");
            sSql.AppendLine("WHERE status=1");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            List<Usuario> Lst = new List<Usuario>();
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    Lst = new List<Usuario>();
                    Usuario item = null;
                    while (scom.Read())
                    {
                        item = new Usuario();
                        item.Id = scom.GetValue<long>("id");
                        item.SId = scom.GetValue<string>("sid");
                        item.IdPessoa = scom.GetValue<long?>("idpessoa");
                        item.SLogin = scom.GetValue<string>("login");
                        item.SSenha = scom.GetValue<string>("senha");
                        item.SEmail = scom.GetValue<string>("email");
                        item.SNome = scom.GetValue<string>("nome");
                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        item.DtmUltimoLogin = scom.GetValue<DateTime?>("data_ultimologin");
                        item.Status = scom.GetValue<bool>("status");

                        if(item.IdPessoa != null && item.IdPessoa > 0)
                        {
                            item.Pessoa = Pessoas.Obter((long)item.IdPessoa);
                        }

                        Lst.Add(item);
                    }
                }
                else throw new Exception("Nenhum resultado encontrado para os dados informados.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return Lst;
        }

        internal static Usuario Obter(long _Usuario)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("SELECT");
            sSql.AppendLine("     id");
            sSql.AppendLine("   , sid");
            sSql.AppendLine("   , idpessoa");
            sSql.AppendLine("   , login");
            sSql.AppendLine("   , senha");
            sSql.AppendLine("   , email");
            sSql.AppendLine("   , idperfil");
            sSql.AppendLine("   , nome");
            sSql.AppendLine("   , data_cadastro");
            sSql.AppendLine("   , data_ultalt");
            sSql.AppendLine("   , data_ultimologin");
            sSql.AppendLine("   , status");
            sSql.AppendLine("   , ignora_permissao");
            sSql.AppendLine("FROM usuario");
            sSql.AppendLine("WHERE id=@id");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", _Usuario);

            Usuario item = null;
            try
            {
                scom.ExecuteReader();
                if (scom.HasRows)
                {
                    if(scom.Read())
                    {
                        item = new Usuario();
                        item.Id = scom.GetValue<long>("id");
                        item.SId = scom.GetValue<string>("sid");
                        item.IdPessoa = scom.GetValue<long?>("idpessoa");
                        item.SLogin = scom.GetValue<string>("login");
                        item.SSenha = scom.GetValue<string>("senha");
                        item.SEmail = scom.GetValue<string>("email");
                        item.SNome = scom.GetValue<string>("nome");
                        item.DtmCadastro = scom.GetValue<DateTime>("data_cadastro");
                        item.DtmUltAlt = scom.GetValue<DateTime>("data_ultalt");
                        item.DtmUltimoLogin = scom.GetValue<DateTime?>("data_ultimologin");
                        item.Status = scom.GetValue<bool>("status");
                        item.IgnoraPermissoes = scom.GetValue<bool>("ignora_permissao");//02.02.2017

                        if (item.IdPessoa != null && item.IdPessoa > 0)
                        {
                            item.Pessoa = Pessoas.Obter((long)item.IdPessoa);
                        }

                        if(scom.GetValue<long?>("idperfil") != null)
                        {
                            item.Perfil = Perfil.Obter(scom.GetValue<long>("idperfil"));
                        }
                    }
                }
                else throw new Exception("Nenhum resultado encontrado para os dados informados.");
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
            return item;
        }

        internal static void Salvar(Usuario item)
        {
            if (item == null) throw new Exception("Atenção! O objeto USUARIO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) Alterar(item);
                else Inserir(item);
            }
        }

        private static void Inserir(Usuario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("INSERT INTO usuario(sid, idpessoa, login, senha, email, idperfil, nome)");
            sSql.AppendLine("VALUES (@sid, @idpessoa, @login, @senha, @email, @idperfil, @nome);SELECT LAST_INSERT_ID();");
            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@sid", item.SId);
            scom.AddWithValue("@idpessoa", item.IdPessoa);
            scom.AddWithValue("@login", item.SLogin);
            scom.AddWithValue("@senha", Crypt.Criptografa(item.SSenha, item.SId));
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@idperfil", item.Perfil);
            scom.AddWithValue("@nome", item.SNome);
            try
            {
                scom.ExecuteReader();
                if(scom.HasRows && scom.Read())
                {
                    long l;
                    long.TryParse(scom.GetValue<object>(0).ToString(), out l);
                    item.Id = l;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }

        private static void Alterar(Usuario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE usuario SET");
            sSql.AppendLine("       idpessoa = @idpessoa");
            sSql.AppendLine("     , login = @login");
            sSql.AppendLine("     , senha = @senha");
            sSql.AppendLine("     , email = @email");
            sSql.AppendLine("     , idperfil = @idperfil");
            sSql.AppendLine("     , nome = @nome");
            sSql.AppendLine("     , data_ultalt = NOW()");
            sSql.AppendLine("WHERE id = @id");
            sSql.AppendLine(" AND sid = @sid;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@sid", item.SId);
            scom.AddWithValue("@idpessoa", item.IdPessoa);
            scom.AddWithValue("@login", item.SLogin);
            scom.AddWithValue("@senha", Crypt.Criptografa(item.SSenha, item.SId));
            scom.AddWithValue("@email", item.SEmail);
            scom.AddWithValue("@idperfil", item.Perfil);
            scom.AddWithValue("@nome", item.SNome);
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

        internal static void SalvarPerfil(Usuario item)
        {
            if (item == null) throw new Exception("Atenção! O objeto USUARIO não foi instanciado para salvar.");
            else
            {
                if (item.Id > 0) AlterarPerfil(item);
                else InserirPerfil(item);
            }
        }

        private static void InserirPerfil(Usuario item)
        {
            throw new Exception("Não é possível criar uma conta de usuário utilizando esta tela!");
        }

        private static void AlterarPerfil(Usuario item)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.AppendLine("UPDATE usuario SET");
            sSql.AppendLine("       data_ultalt = NOW()");
            if (!String.IsNullOrEmpty(item.SSenha))
                sSql.AppendLine("     , senha = @senha");
            sSql.AppendLine("     , email = @email");
            sSql.AppendLine("WHERE id = @id");
            sSql.AppendLine(" AND sid = @sid;");

            cMySqlCommand scom = new cMySqlCommand(sSql.ToString(), System.Data.CommandType.Text);
            scom.AddWithValue("@id", item);
            scom.AddWithValue("@sid", item.SId);
            scom.AddWithValue("@senha", Crypt.Criptografa(item.SSenha, item.SId));
            scom.AddWithValue("@email", item.SEmail);
            try { scom.ExecuteNonQuery(); }
            catch (Exception ex) { throw ex; }
            finally { scom.Close(); }
        }
    }
}
