using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class EstoqueItem
    {
        #region Atributos
        private int idSequencia;
        private long idEstoque;
        private Produto produto;
        private ProdutoLote lote;
        private Usuario usuario;
        private string sNotaFiscal;
        private decimal dQuantidade;
        private decimal dValorUnitario;
        private DateTime? dtmMovimento;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool integrado;
        private int iEntradaSaida = 1;
        private long? idEnderecoDestino;
        private long? idEnderecoOrigem;
        #endregion

        #region Propriedades
        public int IdSequencia
        {
            get { return idSequencia; }
            set { idSequencia = value; }
        }
        public long IdEstoque
        {
            get { return idEstoque; }
            set { idEstoque = value; }
        }
        public Produto Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        public ProdutoLote Lote
        {
            get { return lote; }
            set { lote = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string SNotaFiscal
        {
            get { return sNotaFiscal; }
            set { sNotaFiscal = value; }
        }
        public decimal DQuantidade
        {
            get { return dQuantidade; }
            set { dQuantidade = value; }
        }
        public decimal DValorUnitario
        {
            get { return dValorUnitario; }
            set { dValorUnitario = value; }
        }
        public DateTime? DtmMovimento
        {
            get { return dtmMovimento; }
            set { dtmMovimento = value; }
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
        public bool Integrado
        {
            get { return integrado; }
            set { integrado = value; }
        }
        public int IEntradaSaida
        {
            get { return iEntradaSaida; }
            set { iEntradaSaida = value; }
        }
        public long? IdEnderecoDestino
        {
            get { return idEnderecoDestino; }
            set { idEnderecoDestino = value; }
        }
        public long? IdEnderecoOrigem
        {
            get { return idEnderecoOrigem; }
            set { idEnderecoOrigem = value; }
        }
        #endregion

        public EstoqueItem() { }
        public EstoqueItem(long _estoque, int _item) { this.idEstoque = _estoque; this.idSequencia = _item; }

        public void Salvar()
        {
            DaoEstoqueItem.Salvar(this);
        }

        public static List<EstoqueItem> BuscarEstoque(string _Tipo, bool? _Medicamento, bool? _Vacina, bool? _PesquisarOU, bool? _Status, int iQuantidade)
        {
            return DaoEstoqueItem.BuscarEstoque(_Tipo, _Medicamento, _Vacina, _PesquisarOU, _Status, iQuantidade);
        }
    }
}