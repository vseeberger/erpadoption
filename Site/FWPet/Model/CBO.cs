using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class CBO
    {
        #region Atributos
        private long id;
        private string sCbo;
        private string sDescricao;
        private string sComplemento;
        private string sVersao;
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
        public string SCbo
        {
            get { return sCbo; }
            set { sCbo = value; }
        }
        public string SDescricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
        }
        public string SComplemento
        {
            get { return sComplemento; }
            set { sComplemento = value; }
        }
        public string SVersao
        {
            get { return sVersao; }
            set { sVersao = value; }
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
        public CBO() { }
        public CBO(long _id) { this.id = _id; }
        #endregion

        public static List<CBO> Pesquisar()
        {
            return DaoCBO.Pesquisar();
        }

        public static CBO Obter(long _Codigo)
        {
            return DaoCBO.Obter(_Codigo);
        }

        public void Salvar()
        {
            DaoCBO.Salvar(this);
        }

        public void Excluir()
        {
            DaoCBO.Excluir(this);
        }
    }
}