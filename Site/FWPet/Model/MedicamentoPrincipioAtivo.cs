using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class MedicamentoPrincipioAtivo
    {
        #region Atributos
        private int id;
        private string sDescricao;
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

        #region Construtor
        public MedicamentoPrincipioAtivo() { }
        public MedicamentoPrincipioAtivo(int _id) { this.id = _id; }
        public MedicamentoPrincipioAtivo(int _id, string _desc) { this.id = _id; this.sDescricao = _desc; }
        #endregion

        public static List<MedicamentoPrincipioAtivo> Pesquisar()
        {
            return DaoMedicamentoPrincipioAtivo.Pesquisar();
        }

        public static MedicamentoPrincipioAtivo Obter(int _Principio)
        {
            return DaoMedicamentoPrincipioAtivo.Obter(_Principio);
        }

        public void Excluir()
        {
            DaoMedicamentoPrincipioAtivo.Excluir(this);
        }

        public void Salvar()
        {
            DaoMedicamentoPrincipioAtivo.Salvar(this);
        }
    }
}