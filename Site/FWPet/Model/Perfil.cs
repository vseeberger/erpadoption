using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Perfil
    {
        #region Atributos
        private long id;
        private string sNome;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private List<PerfilPermissao> lstPermissao;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
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
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public List<PerfilPermissao> LstPermissao
        {
            get { return lstPermissao; }
            set { lstPermissao = value; }
        }
        #endregion

        #region Construtores
        public Perfil() { }
        public Perfil(long _id) { this.id = _id; }
        public Perfil(long _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public static List<Perfil> Pesquisar()
        {
            return DaoPerfil.Pesquisar();
        }

        public static Perfil Obter(long _Perfil)
        {
            return DaoPerfil.Obter(_Perfil);
        }

        public void Excluir()
        {
            DaoPerfil.Excluir(this);
        }

        public void Salvar()
        {
            DaoPerfil.Salvar(this);
        }
    }
}