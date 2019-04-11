using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Porte
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private string sSigla;
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
        public string SSigla
        {
            get { return sSigla; }
            set { sSigla = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region Construtor
        public Porte() { }
        public Porte(int _id) { this.id = _id; }
        public Porte(int _id, string _descricao) { this.id = _id; this.sDescricao = _descricao; }
        #endregion

        public static List<Porte> Pesquisar()
        {
            return DaoPorte.Pesquisar();
        }

        public static Porte Obter(int _Porte)
        {
            return DaoPorte.Obter(_Porte);
        }
    }
}