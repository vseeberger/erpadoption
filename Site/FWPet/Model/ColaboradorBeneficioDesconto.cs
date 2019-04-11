using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class ColaboradorBeneficioDesconto
    {
        #region Atributos
        private long id;
        private decimal dValor;
        private BeneficioDesconto beneficio;
        private Colaborador colaborador;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private string sTipo;
        private bool status;
        private bool alterou;
        public long Sequencia { get; set; }
        public bool Corrigir { get; set; }
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public decimal DValor
        {
            get { return dValor; }
            set { dValor = value; }
        }
        public BeneficioDesconto Beneficio
        {
            get { return beneficio; }
            set { beneficio = value; }
        }
        public string STipo
        {
            get { return sTipo; }
            set { sTipo = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public bool Alterou
        {
            get { return alterou; }
            set { alterou = value; }
        }
        public Colaborador Colaborador
        {
            get { return colaborador; }
            set { colaborador = value; }
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
        #endregion
    }
}