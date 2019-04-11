using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ContaBancaria
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private string sAgencia;
        private string sConta;
        private string sTitularNome;
        private string sTitularDocumento;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool principal;
        private ContaBancariaTipo tipo;
        private decimal dSaldoInicial;
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
        public string SAgencia
        {
            get { return sAgencia; }
            set { sAgencia = value; }
        }
        public string SConta
        {
            get { return sConta; }
            set { sConta = value; }
        }
        public string STitularNome
        {
            get { return sTitularNome; }
            set { sTitularNome = value; }
        }
        public string STitularDocumento
        {
            get { return sTitularDocumento; }
            set { sTitularDocumento = value; }
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
        public bool Principal
        {
            get { return principal; }
            set { principal = value; }
        }
        public ContaBancariaTipo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public decimal DSaldoInicial
        {
            get { return dSaldoInicial; }
            set { dSaldoInicial = value; }
        }
        #endregion

        #region Construtores
        public ContaBancaria() { }
        public ContaBancaria(int _id) { this.id = _id; }
        public ContaBancaria(int _id, string _descricao) { this.id = _id; this.sDescricao = _descricao; }
        public ContaBancaria(int _id, string _descricao, string _nometitular) { this.id = _id; this.sDescricao = _descricao; this.sTitularDocumento = _nometitular; }
        #endregion

        public static List<ContaBancaria> Pesquisar()
        {
            return DaoContaBancaria.Pesquisar();
        }

        public static ContaBancaria Obter(int _Conta)
        {
            return DaoContaBancaria.Obter(_Conta);
        }

        public void Salvar()
        {
            DaoContaBancaria.Salvar(this);
        }

        public void Excluir()
        {
            DaoContaBancaria.Excluir(this);
        }

    }
}