using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class ProdutoLote
    {
        #region Atributos
        private long id;
        private long idProduto;
        private string sLote;
        private DateTime dtmValidade;
        private DateTime dtmFabricacao;
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
        public string SLote
        {
            get { return sLote; }
            set { sLote = value; }
        }
        public DateTime DtmValidade
        {
            get { return dtmValidade; }
            set { dtmValidade = value; }
        }
        public DateTime DtmFabricacao
        {
            get { return dtmFabricacao; }
            set { dtmFabricacao = value; }
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