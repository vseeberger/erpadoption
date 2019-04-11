using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Usuario
    {
        #region Atributos
        private long id;
        private string sId;
        private long? idPessoa;
        private string sLogin;
        private string sSenha;
        private string sEmail;
        private Perfil perfil;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime? dtmUltimoLogin;
        private bool status;
        private string sNome;
        private Pessoas pessoa;
        private bool ignoraPermissoes;
        private Configuracoes configSis;
        private List<Formulario> menu;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SId
        {
            get { return sId; }
            set { sId = value; }
        }
        public long? IdPessoa
        {
            get { return idPessoa; }
            set { idPessoa = value; }
        }
        public string SLogin
        {
            get { return sLogin; }
            set { sLogin = value; }
        }
        public string SSenha
        {
            get { return sSenha; }
            set { sSenha = value; }
        }
        public string SEmail
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public Perfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }
        public DateTime DtmCadastro
        {
            get { return dtmCadastro; }
            set { dtmCadastro = value; }
        }
        public DateTime DtmUltAlt
        {
            get { return dtmUltAlt; }
            set { dtmUltAlt = value; }
        }
        public DateTime? DtmUltimoLogin
        {
            get { return dtmUltimoLogin; }
            set { dtmUltimoLogin = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public Pessoas Pessoa
        {
            get { return pessoa; }
            set { pessoa = value; }
        }
        public bool IgnoraPermissoes
        {
            get { return ignoraPermissoes; }
            set { ignoraPermissoes = value; }
        }

        public Configuracoes ConfigSis
        {
            get
            {
                return configSis;
            }

            set
            {
                configSis = value;
            }
        }

        public List<Formulario> Menu
        {
            get
            {
                return menu;
            }

            set
            {
                menu = value;
            }
        }
        #endregion

        #region Construtores
        public Usuario() { }
        public Usuario(long _id) { this.id = _id; }
        #endregion

        public void ResetarSenha()
        {
            DaoUsuario.ResetarSenha(this);
        }

        public void Logar()
        {
            DaoUsuario.Logar(this);
        }

        public static void Logar(Usuario item)
        {
            DaoUsuario.Logar(item);
        }

        public static List<Usuario> Pesquisar()
        {
            return DaoUsuario.Pesquisar();
        }

        public void Excluir()
        {
            DaoUsuario.Excluir(this);
        }

        public static Usuario Obter(long _Usuario)
        {
            return DaoUsuario.Obter(_Usuario);
        }

        public void Salvar()
        {
            DaoUsuario.Salvar(this);
        }

        public void SalvarPerfil()
        {
            DaoUsuario.SalvarPerfil(this);
        }
    }
}