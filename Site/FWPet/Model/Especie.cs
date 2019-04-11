using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Especie
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
        public Especie() { }
        public Especie(int _id) { this.id = _id; }
        public Especie(int _id, string _desc) { this.id = _id; this.sDescricao = _desc; }
        #endregion

        public static List<Especie> Pesquisar()
        {
            return DaoEspecie.Pesquisar();
        }

        public static Especie Obter(int _Raca)
        {
            return DaoEspecie.Obter(_Raca);
        }
    }
}