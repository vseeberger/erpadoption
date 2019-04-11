using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;
namespace FWPet.Model
{
    public class PessoaGrauParentesco
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        #endregion

        #region Propriedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SDescricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
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
        public PessoaGrauParentesco() { }
        public PessoaGrauParentesco(int _id) { this.id = _id; }
        public PessoaGrauParentesco(int _id, string _desc) { this.id = _id; this.sDescricao = _desc; } 
        #endregion

        public static List<PessoaGrauParentesco> Pesquisar()
        {
            return DaoPessoaGrauParentesco.Pesquisar();
        }

        public static PessoaGrauParentesco Obter(int _Codigo)
        {
            return DaoPessoaGrauParentesco.Obter(_Codigo);
        }

        public void Salvar()
        {
            DaoPessoaGrauParentesco.Salvar(this);
        }

        public void Excluir()
        {
            DaoPessoaGrauParentesco.Excluir(this);
        }
    }
}
