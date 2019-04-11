using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class CentroDeCustos
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private string sCustoLucro;
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
        public string SCustoLucro
        {
            get { return sCustoLucro; }
            set { sCustoLucro = value; }
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
        public string SDescricao
        {
            get { return sDescricao; }
            set { sDescricao = value; }
        }
        #endregion

        #region Construtores
        public CentroDeCustos() { }
        public CentroDeCustos(int _id) { this.id = _id; }
        public CentroDeCustos(int _id, string _descricao) { this.id = _id; this.SDescricao = _descricao; }
        #endregion

        public static List<CentroDeCustos> Pesquisar()
        {
            return DaoCentroDeCustos.Pesquisar();
        }

        public static CentroDeCustos Obter(int _Centro)
        {
            return DaoCentroDeCustos.Obter(_Centro);
        }

        public void Salvar()
        {
            DaoCentroDeCustos.Salvar(this);
        }

        public void Excluir()
        {
            DaoCentroDeCustos.Excluir(this);
        }
    }
}
