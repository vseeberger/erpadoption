using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ContaBancariaTipo
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

        #region Construtores
        public ContaBancariaTipo() { }
        public ContaBancariaTipo(int _id) { this.id = _id; }
        public ContaBancariaTipo(int _id, string _descricao) { this.id = _id; this.sDescricao = _descricao; }
        #endregion

        public static List<ContaBancariaTipo> Pesquisar()
        {
            return DaoContaBancariaTipo.Pesquisar();
        }
    }
}