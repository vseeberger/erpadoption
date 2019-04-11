using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class PedidoCompraItens
    {
        #region Atributos
        private long id;
        private long idPedido;
        private Produto produto;
        private int iQuantidade;
        private int iQuantidadeAtendida;
        private Usuario usuarioSolicitante;
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
        public long IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }
        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public int IQuantidade
        {
            get { return iQuantidade; }
            set { iQuantidade = value; }
        }
        public Usuario UsuarioSolicitante
        {
            get { return usuarioSolicitante; }
            set { usuarioSolicitante = value; }
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

        public int IQuantidadeAtendida
        {
            get
            {
                return iQuantidadeAtendida;
            }

            set
            {
                iQuantidadeAtendida = value;
            }
        }
        #endregion

        public void Inserir()
        {
            DaoPedidoCompraItens.Inserir(this);           
        }
    }
}