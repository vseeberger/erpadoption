using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Empresa
    {
        #region Atributos
        private long id;
        private string sRazaoSocial;
        private string sNomeFantasia;
        private string sEmail;
        private string sSite;
        private string sCnpjCpf;
        private int iTipoPessoa;
        private string sInscricaoMunicipal;
        private string sInscricaoEstadual;
        private string sEndereco;
        private string sEnderecoNumero;
        private string sEnderecoBairro;
        private string sEnderecoCidade;
        private string sEnderecoUF;
        private string sEnderecoCEP;
        private string sEnderecoObservacoes;
        private DateTime? dtmFundacao;
        private DateTime dtmUltAlt;
        private DateTime dtmCadastro;
        private bool status;
        private string sTipoCadastro;
        #endregion

        #region Propriedades
        public string SNome { get { return this.sRazaoSocial; } }
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SRazaoSocial
        {
            get { return sRazaoSocial; }
            set { sRazaoSocial = value; }
        }
        public string SNomeFantasia
        {
            get { return sNomeFantasia; }
            set { sNomeFantasia = value; }
        }
        public string SEmail
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public string SSite
        {
            get { return sSite; }
            set { sSite = value; }
        }
        public int ITipoPessoa
        {
            get { return iTipoPessoa; }
            set { iTipoPessoa = value; }
        }
        public string SInscricaoMunicipal
        {
            get { return sInscricaoMunicipal; }
            set { sInscricaoMunicipal = value; }
        }
        public string SInscricaoEstadual
        {
            get { return sInscricaoEstadual; }
            set { sInscricaoEstadual = value; }
        }
        public string SEndereco
        {
            get { return sEndereco; }
            set { sEndereco = value; }
        }
        public string SEnderecoNumero
        {
            get { return sEnderecoNumero; }
            set { sEnderecoNumero = value; }
        }
        public string SEnderecoBairro
        {
            get { return sEnderecoBairro; }
            set { sEnderecoBairro = value; }
        }
        public string SEnderecoCidade
        {
            get { return sEnderecoCidade; }
            set { sEnderecoCidade = value; }
        }
        public string SEnderecoUF
        {
            get { return sEnderecoUF; }
            set { sEnderecoUF = value; }
        }
        public string SEnderecoCEP
        {
            get { return sEnderecoCEP; }
            set { sEnderecoCEP = value; }
        }
        public string SEnderecoObservacoes
        {
            get { return sEnderecoObservacoes; }
            set { sEnderecoObservacoes = value; }
        }
        public DateTime? DtmFundacao
        {
            get { return dtmFundacao; }
            set { dtmFundacao = value; }
        }
        public DateTime DtmUltAlt
        {
            get { return dtmUltAlt; }
            set { dtmUltAlt = value; }
        }
        public DateTime DtmCadastro
        {
            get { return dtmCadastro; }
            set { dtmCadastro = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public string SCnpjCpf
        {
            get { return sCnpjCpf; }
            set { sCnpjCpf = value; }
        }
        /// <summary>
        /// L -> Laboratorio
        /// F -> Fornecedor
        /// ...
        /// </summary>
        public string STipoCadastro
        {
            get { return sTipoCadastro; }
            set { sTipoCadastro = value; }
        }
        #endregion

        #region Construtor
        public Empresa() { }
        public Empresa(long _id) { this.id = _id; }
        public Empresa(long _id, string _nome) { this.id = _id; this.sRazaoSocial = _nome; }
        #endregion

        public static List<Empresa> Pesquisar(string _Tipo)
        {
            return DaoEmpresa.Pesquisar(_Tipo);
        }

        public static Empresa Obter(long _Empresa, string _Tipo)
        {
            return DaoEmpresa.Obter(_Empresa, _Tipo);
        }

        public void Salvar()
        {
            DaoEmpresa.SalvarEmpresa(this);
        }

        public void Excluir()
        {
            DaoEmpresa.ExcluirEmpresa(this);
        }
    }
}