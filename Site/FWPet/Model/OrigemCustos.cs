using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class OrigemCustos
    {
        #region Atributos
        private int id;
        private int? idPai;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private string sEntradaSaida;
        private string sClassificacao;
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
        public string SEntradaSaida
        {
            get { return sEntradaSaida; }
            set { sEntradaSaida = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public string SClassificacao
        {
            get { return sClassificacao; }
            set { sClassificacao = value; }
        }
        public int? IdPai
        {
            get { return idPai; }
            set { idPai = value; }
        }
        #endregion

        #region Construtores
        public OrigemCustos() { }
        public OrigemCustos(int _id) { this.id = _id; }
        public OrigemCustos(int _id, string _desc, string _entradasaida) { this.id = _id; this.sDescricao = _desc; this.sEntradaSaida = _entradasaida; }
        #endregion

        public static List<OrigemCustos> Pesquisar()
        {
            return DaoOrigemCustos.Pesquisar();
        }

        public static OrigemCustos Obter(int _Codigo)
        {
            return DaoOrigemCustos.Obter(_Codigo);
        }
    }
}