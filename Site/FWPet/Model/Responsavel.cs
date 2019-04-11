using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Responsavel : Pessoas
    {
        #region Construtor
        public Responsavel() { }
        public Responsavel(long _id) { this.Id = _id; }
        public Responsavel(long _id, string _nome) { this.Id = _id; this.SNome = _nome; } 
        #endregion

        public void Salvar()
        {
            DaoResponsavel.Salvar(this);
        }

        public static List<Responsavel> Pesquisar()
        {
            return DaoResponsavel.Pesquisar();
        }

        public static Responsavel Obter(long _Responsavel)
        {
            return DaoResponsavel.Obter(_Responsavel);
        }

        public void Excluir()
        {
            DaoResponsavel.Excluir(this);
        }
    }
}
