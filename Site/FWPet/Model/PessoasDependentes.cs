using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class PessoasDependentes
    {
        #region Atributos
        private long id;
        private long idPessoa;
        private string sNome;
        private DateTime? dtmNascimento;
        private PessoaGrauParentesco grauParentesco;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        public bool Alterou { get; set; }
        public long Sequencia { get; set; }
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public long IdPessoa
        {
            get { return idPessoa; }
            set { idPessoa = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public DateTime? DtmNascimento
        {
            get { return dtmNascimento; }
            set { dtmNascimento = value; }
        }
        public PessoaGrauParentesco GrauParentesco
        {
            get { return grauParentesco; }
            set { grauParentesco = value; }
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
        #endregion

        #region Construtores
        public PessoasDependentes() { }
        public PessoasDependentes(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoPessoasDependentes.Salvar(this);
        }

        public void Excluir()
        {
            DaoPessoasDependentes.Excluir(this);
        }

        public static List<PessoasDependentes> Pesquisar(long _Pessoa)
        {
            return DaoPessoasDependentes.Pesquisar(_Pessoa);
        }
    }
}