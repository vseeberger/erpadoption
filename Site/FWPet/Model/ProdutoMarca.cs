using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ProdutoMarca
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private string sTipo;
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
        public string STipo
        {
            get { return sTipo; }
            set { sTipo = value; }
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
        public ProdutoMarca() { }
        public ProdutoMarca(int _id) { this.id = _id; }
        #endregion

        public static List<ProdutoMarca> Pesquisar()
        {
            return DaoProdutoMarca.Pesquisar();
        }

        public static ProdutoMarca Obter(int _Codigo)
        {
            return DaoProdutoMarca.Obter(_Codigo);
        }

        public void Excluir()
        {
            DaoProdutoMarca.Excluir(this);
        }

        public void Salvar()
        {
            DaoProdutoMarca.Salvar(this);
        }
    }
}