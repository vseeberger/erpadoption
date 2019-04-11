using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Cargo
    {
        #region Atributos
        private long id;
        private long idCBO;
        private CBO cbo;
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
        public long IdCBO
        {
            get { return idCBO; }
            set { idCBO = value; }
        }
        public CBO Cbo
        {
            get { return cbo; }
            set { cbo = value; }
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
        public Cargo() { }
        public Cargo(long _id) { this.id=_id;}
        #endregion

        public static List<Cargo> Pesquisar()
        {
            return DaoCargo.Pesquisar();
        }

        public static Cargo Obter(long _Codigo)
        {
            return DaoCargo.Obter(_Codigo);
        }

        public void Salvar()
        {
            DaoCargo.Salvar(this);
        }

        public void Excluir()
        {
            DaoCargo.Excluir(this);
        }
    }
}