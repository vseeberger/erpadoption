using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class ContaPagarReceber
    {
        #region Atributos
        private long id;
        private ContaBancaria conta;
        private CentroDeCustos centroDeCustos;
        private OrigemCustos classificacao;
        private string sDescricaoReferencia;
        private string sNomeDeQuemPagou;
        private string sNumeroDocumento;
        private string sCustoOuLucro;
        private string sMaisDetalhes;
        private DateTime? dtmPagamentoRecebimento;
        private DateTime dtmPrevisao;
        private DateTime? dtmCompetencia;
        private decimal dValor = 0;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private int situacao;

        private FormaPagamentoRecebimento formaPagRec;
        private long? idQuemRecebeuPagou;
        private string sTipoQuemRecebeuPagou;
        private string sNomeQuemRecebeuPagou;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public ContaBancaria Conta
        {
            get { return conta; }
            set { conta = value; }
        }
        public CentroDeCustos CentroDeCustos
        {
            get { return centroDeCustos; }
            set { centroDeCustos = value; }
        }
        public OrigemCustos Classificacao
        {
            get { return classificacao; }
            set { classificacao = value; }
        }
        public string SDescricaoReferencia
        {
            get { return sDescricaoReferencia; }
            set { sDescricaoReferencia = value; }
        }
        public string SNomeDeQuemPagou
        {
            get { return sNomeDeQuemPagou; }
            set { sNomeDeQuemPagou = value; }
        }
        public string SNumeroDocumento
        {
            get { return sNumeroDocumento; }
            set { sNumeroDocumento = value; }
        }
        public string SMaisDetalhes
        {
            get { return sMaisDetalhes; }
            set { sMaisDetalhes = value; }
        }
        public DateTime? DtmPagamentoRecebimento
        {
            get { return dtmPagamentoRecebimento; }
            set { dtmPagamentoRecebimento = value; }
        }
        public DateTime? DtmCompetencia
        {
            get { return dtmCompetencia; }
            set { dtmCompetencia = value; }
        }
        public decimal DValor
        {
            get { return dValor; }
            set { dValor = value; }
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
        public int Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
        public string SCustoOuLucro
        {
            get { return sCustoOuLucro; }
            set { sCustoOuLucro = value; }
        }
        public DateTime DtmPrevisao
        {
            get { return dtmPrevisao; }
            set { dtmPrevisao = value; }
        }
        public FormaPagamentoRecebimento FormaPagRec
        {
            get { return formaPagRec; }
            set { formaPagRec = value; }
        }
        public long? IdQuemRecebeuPagou
        {
            get { return idQuemRecebeuPagou; }
            set { idQuemRecebeuPagou = value; }
        }
        public string STipoQuemRecebeuPagou
        {
            get { return sTipoQuemRecebeuPagou; }
            set { sTipoQuemRecebeuPagou = value; }
        }
        public string SNomeQuemRecebeuPagou
        {
            get { return sNomeQuemRecebeuPagou; }
            set { sNomeQuemRecebeuPagou = value; }
        }
        #endregion

        #region Construtores
        public ContaPagarReceber() { }
        public ContaPagarReceber(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoContaPagarReceber.Salvar(this);
        }

        /// <summary>
        /// </summary>
        /// <param name="_Tipo">se é E=entrada ou S=saída</param>
        /// <param name="dtmPeriodo">datetime porém o período utilizado é mês e ano apenas</param>
        /// <param name="_TrazerNaoPagosAnteriormente">0 traz tudo do mês atual apenas, 1 traz tudo do mês atual e TUDO do período anterior que NÃO está pago.</param>
        /// <returns></returns>
        public static List<ContaPagarReceber> Pesquisar(string _Tipo, DateTime dtmPeriodo, int _TrazerNaoPagosAnteriormente)
        {
            return DaoContaPagarReceber.Pesquisar(_Tipo, dtmPeriodo, _TrazerNaoPagosAnteriormente);
        }

        public static ContaPagarReceber Obter(long _Codigo)
        {
            return DaoContaPagarReceber.Obter(_Codigo);
        }

        public void Excluir()
        {
            DaoContaPagarReceber.Excluir(this);
        }
    }
}