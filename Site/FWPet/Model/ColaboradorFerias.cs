using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class ColaboradorFerias
    {
        #region Atributos
        private long id;
        private long idColaborador;
        private DateTime? dtmCompetenciaDe;
        private DateTime? dtmCompetenciaAte;
        private DateTime? dtmPeriodoDe;
        private DateTime? dtmPeriodoAte;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private string sObservacoes;
        private bool agendado;
        private bool realizou;
        private bool status;
        private bool alterou = false;
        public long sequencia { get; set; }//apenas para a tela
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime? DtmCompetenciaDe
        {
            get { return dtmCompetenciaDe; }
            set { dtmCompetenciaDe = value; }
        }
        public DateTime? DtmCompetenciaAte
        {
            get { return dtmCompetenciaAte; }
            set { dtmCompetenciaAte = value; }
        }
        public DateTime? DtmPeriodoDe
        {
            get { return dtmPeriodoDe; }
            set { dtmPeriodoDe = value; }
        }
        public DateTime? DtmPeriodoAte
        {
            get { return dtmPeriodoAte; }
            set { dtmPeriodoAte = value; }
        }
        public bool Agendado
        {
            get { return agendado; }
            set { agendado = value; }
        }
        public bool Realizou
        {
            get { return realizou; }
            set { realizou = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
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
        public string SObservacoes
        {
            get { return sObservacoes; }
            set { sObservacoes = value; }
        }
        public long IdColaborador
        {
            get { return idColaborador; }
            set { idColaborador = value; }
        }
        public bool Alterou
        {
            get { return alterou; }
            set { alterou = value; }
        }
        #endregion
    }
}