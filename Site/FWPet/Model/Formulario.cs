using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Formulario
    {
        #region Atributos
        private int id;
        private string sNome;
        private string sPath;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool ehMenu;
        private int? idPai;
        private Formulario pai;
        private List<Formulario> filhos;
        private string sClass;
        private string sIcone;
        private int iAgrupador;
        private int iSequenciaMenu;
        private string sUrlCurta;
        private int? menuPaiFull;
        #endregion

        #region Propriedades
        public bool TemFilhos { get { return this.filhos != null && this.filhos.Count > 0; } }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public string SPath
        {
            get { return sPath; }
            set { sPath = value; }
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
        public List<Formulario> Filhos
        {
            get { return filhos; }
            set { filhos = value; }
        }
        public bool EhMenu
        {
            get { return ehMenu; }
            set { ehMenu = value; }
        }
        public Formulario Pai
        {
            get { return pai; }
            set { pai = value; }
        }
        public int? IdPai
        {
            get { return idPai; }
            set { idPai = value; }
        }
        public string SClass
        {
            get { return sClass; }
            set { sClass = value; }
        }
        public string SIcone
        {
            get { return sIcone; }
            set { sIcone = value; }
        }
        public string CodNome
        {
            get { return this.id + " - " + this.SNome; }
        }
        public int IAgrupador
        {
            get { return iAgrupador; }
            set { iAgrupador = value; }
        }
        public int ISequenciaMenu
        {
            get { return iSequenciaMenu; }
            set { iSequenciaMenu = value; }
        }
        public string SUrlCurta
        {
            get { return sUrlCurta; }
            set { sUrlCurta = value; }
        }
        public int? MenuPaiFull
        {
            get { return menuPaiFull; }
            set { menuPaiFull = value; }
        }
        #endregion

        #region Construtores
        public Formulario() { }
        public Formulario(int _id) { this.id = _id; }
        public Formulario(int _id, string _nome) { this.id = _id; this.sNome = _nome; }
        public Formulario(int _id, string _nome, string _path) { this.id = _id; this.sNome = _nome; this.sPath = _path; }
        public Formulario(int _id, string _nome, string _path, bool _status) { this.id = _id; this.sNome = _nome; this.sPath = _path; this.status = _status; }
        #endregion

        public static Formulario Obter(int _Formulario)
        {
            return DaoFormulario.Obter(_Formulario);
        }

        public static List<Formulario> Pesquisar()
        {
            return DaoFormulario.Pesquisar();
        }

        public void Excluir()
        {
            DaoFormulario.Excluir(this);
        }

        public void Salvar()
        {
            DaoFormulario.Salvar(this);
        }
    }
}