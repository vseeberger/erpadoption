using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Adotante
    {
        #region Atributos
        private long id;
        private string sNome;
        private string sSexo;

        private string sRG;
        private string sCPF;
        private string sProfissao;

        private string sEmail;
        private string sTelefone;
        private string sCelular;
        private string sOutroContato;

        private Endereco endereco;
        private List<AnimalAdotado> animaisAdotados;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime? dtmNascimento;
        private int status;
        private int iQtdAnimais;
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
        public string SSexo
        {
            get { return sSexo; }
            set { sSexo = value; }
        }
        public string SRG
        {
            get { return sRG; }
            set { sRG = value; }
        }
        public string SCPF
        {
            get { return sCPF; }
            set { sCPF = value; }
        }
        public string SProfissao
        {
            get { return sProfissao; }
            set { sProfissao = value; }
        }
        public string SEmail
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public string STelefone
        {
            get { return sTelefone; }
            set { sTelefone = value; }
        }
        public string SCelular
        {
            get { return sCelular; }
            set { sCelular = value; }
        }
        public string SOutroContato
        {
            get { return sOutroContato; }
            set { sOutroContato = value; }
        }
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public List<AnimalAdotado> AnimaisAdotados
        {
            get { return animaisAdotados; }
            set { animaisAdotados = value; }
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
        public DateTime? DtmNascimento
        {
            get { return dtmNascimento; }
            set { dtmNascimento = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public int IQtdAnimais
        {
            get
            {
                return iQtdAnimais;
            }

            set
            {
                iQtdAnimais = value;
            }
        }
        #endregion

        #region Construtores
        public Adotante() { }
        public Adotante(long _id) { this.id = _id; }
        public Adotante(long _id, string _nome) { this.id = _id;  this.sNome = _nome; }
        #endregion

        public void Salvar()
        {
            DaoAdotante.Salvar(this);
        }

        public void Excluir()
        {
            DaoAdotante.Excluir(this);
        }

        public static List<Adotante> Pesquisar()
        {
            return DaoAdotante.Pesquisar();
        }

        public static Adotante Obter(long _Codigo)
        {
            return DaoAdotante.Obter(_Codigo);
        }
    }
}