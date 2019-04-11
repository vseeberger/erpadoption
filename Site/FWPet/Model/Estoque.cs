using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Estoque
    {
        #region Atributos
        private long id;
        private Usuario usuarioCadastrou;
        private string sNotaFiscal;
        private decimal dValorTotal;
        private DateTime dtmMovimentacao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private string sObservacao;
        private string sEstoqueTipoMovimentacao;//vem da table
        private bool finalizado;
        private DateTime? dtmEmissaoNF;
        private List<EstoqueItem> lstItens;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public Usuario UsuarioCadastrou
        {
            get { return usuarioCadastrou; }
            set { usuarioCadastrou = value; }
        }
        public string SNotaFiscal
        {
            get { return sNotaFiscal; }
            set { sNotaFiscal = value; }
        }
        public decimal DValorTotal
        {
            get { return dValorTotal; }
            set { dValorTotal = value; }
        }
        public DateTime DtmMovimentacao
        {
            get { return dtmMovimentacao; }
            set { dtmMovimentacao = value; }
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
        public string SObservacao
        {
            get { return sObservacao; }
            set { sObservacao = value; }
        }
        public string SEstoqueTipoMovimentacao
        {
            get { return sEstoqueTipoMovimentacao; }
            set { sEstoqueTipoMovimentacao = value; }
        }
        public bool Finalizado
        {
            get { return finalizado; }
            set { finalizado = value; }
        }
        public DateTime? DtmEmissaoNF
        {
            get { return dtmEmissaoNF; }
            set { dtmEmissaoNF = value; }
        }
        public List<EstoqueItem> LstItens
        {
            get { return lstItens; }
            set { lstItens = value; }
        }
        #endregion

        public Estoque() { }

        public void Salvar()
        {
            DaoEstoque.Salvar(this);
        }

        public static List<Estoque> Pesquisar()
        {
            return DaoEstoque.Pesquisar();
        }
    }
}