using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ProdutoBarras
    {
        #region Atributos
        private long id;
        private long idProduto;
        private string sEAN;
        private decimal dQuantidade;
        private ProdutoUnidade undidade;
        private bool compra;
        private bool venda;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public long IdProduto
        {
            get { return idProduto; }
            set { idProduto = value; }
        }
        public string SEAN
        {
            get { return sEAN; }
            set { sEAN = value; }
        }
        public decimal DQuantidade
        {
            get { return dQuantidade; }
            set { dQuantidade = value; }
        }
        public ProdutoUnidade Undidade
        {
            get { return undidade; }
            set { undidade = value; }
        }
        public bool Compra
        {
            get { return compra; }
            set { compra = value; }
        }
        public bool Venda
        {
            get { return venda; }
            set { venda = value; }
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

        public static List<ProdutoBarras> Pesquisar(long _Produto)
        {
            return DaoProdutoBarras.Pesquisar(_Produto);
        }

        public static ProdutoBarras Obter(long _Id)
        {
            return DaoProdutoBarras.Obter(_Id);
        }

        public static ProdutoBarras Obter(string _EAN)
        {
            return DaoProdutoBarras.Obter(_EAN);
        }
    }
}
