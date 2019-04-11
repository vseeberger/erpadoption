using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class ProdutoConversao
    {
        #region Atributos
        private long id;
        private long idProduto;
        private ProdutoUnidade unidadeComprada;
        private decimal dFator;
        private string sOperacao;
        private ProdutoUnidade unidadeDestino;
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
        public ProdutoUnidade UnidadeComprada
        {
            get { return unidadeComprada; }
            set { unidadeComprada = value; }
        }
        public decimal DFator
        {
            get { return dFator; }
            set { dFator = value; }
        }
        public string SOperacao
        {
            get { return sOperacao; }
            set { sOperacao = value; }
        }
        public ProdutoUnidade UnidadeDestino
        {
            get { return unidadeDestino; }
            set { unidadeDestino = value; }
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

    }
}