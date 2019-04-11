using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class AnimalMedicamentoTratamento
    {
        #region Atributos
        private int id;
        private string sNome;
        private string sDescricao;
        private DateTime dtmUltAlt;
        private DateTime dtmCadastro;
        private bool status;
        #endregion

        #region Propriedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public string SDescricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
        }
        public DateTime DtmUltAlt
        {
            get { return dtmUltAlt; }
            set { dtmUltAlt = value; }
        }
        public DateTime DtmCadastro
        {
            get { return dtmCadastro; }
            set { dtmCadastro = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region construtor
        public AnimalMedicamentoTratamento() { }
        public AnimalMedicamentoTratamento(int _id) { this.id = _id; }
        public AnimalMedicamentoTratamento(int _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public void Salvar()
        {
            DaoAnimalMedicamentoTratamento.Salvar(this);
        }

        public void Excluir()
        {
            DaoAnimalMedicamentoTratamento.Excluir(this);
        }

        public static List<AnimalMedicamentoTratamento> Pesquisar()
        {
            return DaoAnimalMedicamentoTratamento.Pesquisar();
        }

        public static AnimalMedicamentoTratamento Obter(int _Codigo)
        {
            return DaoAnimalMedicamentoTratamento.Obter(_Codigo);
        }
    }
}