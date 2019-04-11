using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class MedicamentoGenerico
    {
        #region Atributos
        private long id;
        private string sDescricao;
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
        }
        #endregion

        #region Construtores
        public MedicamentoGenerico() { }
        public MedicamentoGenerico(long _id) { this.id = _id; }
        public MedicamentoGenerico(long _id, string _desc) { this.id = _id; this.sDescricao = _desc; }
        #endregion

        public void Salvar() { DaoMedicamentoGenerico.Salvar(this); }

        public static List<MedicamentoGenerico> Pesquisar() { return DaoMedicamentoGenerico.Pesquisar(); }

        public static MedicamentoGenerico Obter(long _Generico) { return DaoMedicamentoGenerico.Obter(_Generico); }
    }
}