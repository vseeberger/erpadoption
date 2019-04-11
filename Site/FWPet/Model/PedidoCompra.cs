using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class PedidoCompra
    {
        /*
         CREATE TABLE IF NOT EXISTS `lista_compras` (
          `id` bigint(20) NOT NULL AUTO_INCREMENT,
          `id_usuario` bigint(20) NOT NULL DEFAULT '0',
          `descricao` varchar(255) DEFAULT NULL,
          `data_cadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
          `data_ultalt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
          `status` int(11) NOT NULL DEFAULT '1',
          PRIMARY KEY (`id`)
        ) ENGINE=InnoDB DEFAULT CHARSET=latin1;

            ALTER TABLE `lista_compras`
	ADD COLUMN `finalizado` int(11) NOT NULL DEFAULT '0'
	, ADD COLUMN `data_previsao` datetime DEFAULT NULL
	, ADD COLUMN `data_realizacao_compra` datetime DEFAULT NULL;
    
         */
        #region Atributos
        private long id;
        private Usuario usuario;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;

        private List<PedidoCompraItens> lstProdutos;
        private bool finalizado;
        private DateTime? dtmCompra;
        private DateTime? dtmPrevisaoCompra;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
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
        }public List<PedidoCompraItens> LstProdutos
        {
            get { return lstProdutos; }
            set { lstProdutos = value; }
        }
        public bool Finalizado
        {
            get { return finalizado; }
            set { finalizado = value; }
        }
        public DateTime? DtmCompra
        {
            get { return dtmCompra; }
            set { dtmCompra = value; }
        }
        public DateTime? DtmPrevisaoCompra
        {
            get { return dtmPrevisaoCompra; }
            set { dtmPrevisaoCompra = value; }
        }
        #endregion

        /// <summary>
        /// retorna o registro mais antigo que ainda está em aberto.
        /// </summary>
        /// <returns></returns>
        public static PedidoCompra ObterAberto()
        {
            return DaoPedidoCompra.ObterAberto();
        }

        /// <summary>
        /// registra um novo pedido
        /// </summary>
        /// <returns></returns>
        internal static PedidoCompra Novo(long _Usuario)
        {
            return DaoPedidoCompra.Novo(_Usuario);
        }
    }
}