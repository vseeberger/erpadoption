using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Raca
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private Especie especie;
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
        public Especie Especie
        {
            get { return especie; }
            set { especie = value; }
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
        public Raca() { }
        public Raca(int _id) { this.id = _id; }
        public Raca(int _id, string _descricao) { this.id = _id;  this.sDescricao = _descricao; }
        #endregion

        public static List<Raca> Pesquisar()
        {
            return DaoRaca.Pesquisar();
        }

        public static Raca Obter(int _Raca)
        {
            return DaoRaca.Obter(_Raca);
        }

        public void Salvar()
        {
            DaoRaca.Salvar(this);
        }

        public void Salvar(Raca _item)
        {
            DaoRaca.Salvar(_item);
        }

        public void Excluir()
        {
            DaoRaca.Excluir(this);
        }

    }
}
