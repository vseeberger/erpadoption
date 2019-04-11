using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Configuracoes
    {
        #region Atributos
        private int id;
        private int diaPagamento;
        private decimal dValorDiaria;
        private int iQtdDiasAlertaContatoDeAdocao;
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
        public int DiaPagamento
        {
            get { return diaPagamento; }
            set { diaPagamento = value; }
        }
        public decimal DValorDiaria
        {
            get { return dValorDiaria; }
            set { dValorDiaria = value; }
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

        public int IQtdDiasAlertaContatoDeAdocao
        {
            get
            {
                return iQtdDiasAlertaContatoDeAdocao;
            }

            set
            {
                iQtdDiasAlertaContatoDeAdocao = value;
            }
        }
        #endregion

        public void Salvar()
        {
            DaoConfiguracoes.Salvar(this);
        }

        public static Configuracoes Obter()
        {
            return DaoConfiguracoes.Obter();
        }
    }
}