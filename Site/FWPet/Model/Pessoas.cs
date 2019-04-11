using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Pessoas
    {
        #region Atributos
        private long id;
        private string sNome;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime? dtmNascimento;
        private char cTipo;
        private string sSexo;
        private bool status;
        private string sRG;
        private string sCPF;
        private Endereco endereco;
        private string sEmail;
        private string sTelefone;
        private string sCelular;
        private string sOutroContato;

        //Add 06.03.2017
        private string sRGOrgao;
        private string sRGUF;
        private DateTime? dtmRGExpedicao;

        private string sCTPS;
        private string sCTPSSerie;
        private string sCTPSUF;

        private string sTitEleitor;
        private string sTitEleitorZona;
        private string sTitEleitorSecao;
        private string sPISPASEP;

        private DateTime? dtmAdmissao;
        private DateTime? dtmDemissao;

        private string sNomeMae;
        private string sNomePai;
        private bool estrangeiro;
        private string sNaturalidade;
        private string sUFNascimento;
        private string sNacionalidade;
        private string sPassaporte;
        private string sTipoSanguineo;
        private string sEstadoCivil;
        private int? iNumeroFilhos;
        private List<PessoasDependentes> lstDependentes;
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
        /// <summary>
        /// Indica o tipo de cadastro:
        /// R - Responsável
        /// P - Padrinho
        /// A - Adotante
        /// V - Veterinário
        /// </summary>
        public char CTipo
        {
            get { return cTipo; }
            set { cTipo = value; }
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
        public DateTime? DtmNascimento
        {
            get { return dtmNascimento; }
            set { dtmNascimento = value; }
        }
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public string SSexo
        {
            get { return sSexo; }
            set { sSexo = value; }
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
        public string SRGOrgao
        {
            get { return sRGOrgao; }
            set { sRGOrgao = value; }
        }
        public string SRGUF
        {
            get { return sRGUF; }
            set { sRGUF = value; }
        }
        public DateTime? DtmRGExpedicao
        {
            get { return dtmRGExpedicao; }
            set { dtmRGExpedicao = value; }
        }
        public string SCTPS
        {
            get { return sCTPS; }
            set { sCTPS = value; }
        }
        public string SCTPSSerie
        {
            get { return sCTPSSerie; }
            set { sCTPSSerie = value; }
        }
        public string SCTPSUF
        {
            get { return sCTPSUF; }
            set { sCTPSUF = value; }
        }
        public string STitEleitor
        {
            get { return sTitEleitor; }
            set { sTitEleitor = value; }
        }
        public string STitEleitorZona
        {
            get { return sTitEleitorZona; }
            set { sTitEleitorZona = value; }
        }
        public string STitEleitorSecao
        {
            get { return sTitEleitorSecao; }
            set { sTitEleitorSecao = value; }
        }
        public string SPISPASEP
        {
            get { return sPISPASEP; }
            set { sPISPASEP = value; }
        }
        public DateTime? DtmAdmissao
        {
            get { return dtmAdmissao; }
            set { dtmAdmissao = value; }
        }
        public DateTime? DtmDemissao
        {
            get { return dtmDemissao; }
            set { dtmDemissao = value; }
        }
        public string SNomeMae
        {
            get { return sNomeMae; }
            set { sNomeMae = value; }
        }
        public string SNomePai
        {
            get { return sNomePai; }
            set { sNomePai = value; }
        }
        public bool Estrangeiro
        {
            get { return estrangeiro; }
            set { estrangeiro = value; }
        }
        public string SNaturalidade
        {
            get { return sNaturalidade; }
            set { sNaturalidade = value; }
        }
        public string SUFNascimento
        {
            get { return sUFNascimento; }
            set { sUFNascimento = value; }
        }
        public string SNacionalidade
        {
            get { return sNacionalidade; }
            set { sNacionalidade = value; }
        }
        public string SPassaporte
        {
            get { return sPassaporte; }
            set { sPassaporte = value; }
        }
        public string STipoSanguineo
        {
            get { return sTipoSanguineo; }
            set { sTipoSanguineo = value; }
        }
        public string SEstadoCivil
        {
            get { return sEstadoCivil; }
            set { sEstadoCivil = value; }
        }
        public int? INumeroFilhos
        {
            get { return iNumeroFilhos; }
            set { iNumeroFilhos = value; }
        }
        public List<PessoasDependentes> LstDependentes
        {
            get { return lstDependentes; }
            set { lstDependentes = value; }
        }
        #endregion

        public static List<Pessoas> Pesquisar()
        {
            return DaoPessoas.Pesquisar();
        }

        internal static Pessoas Obter(long idPessoa)
        {
            return DaoPessoas.Obter(idPessoa);
        }
    }
}