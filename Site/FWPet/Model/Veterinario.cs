using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Veterinario : Pessoas
    {
        #region Atributos & Propriedades
        private string sCRMV;

        /// <summary>
        /// Número do CRMV (conselho regional de medicina veterinária)
        /// </summary>
        public string SCRMV
        {
            get { return sCRMV; }
            set { sCRMV = value; }
        }
        #endregion

        #region Construtor
        public Veterinario() { }
        public Veterinario(long _id) { this.Id = _id; }
        public Veterinario(long _id, string _nome) { this.Id = _id; this.SNome = _nome; }
        public Veterinario(long _id, string _nome, string _crmv) { this.Id = _id; this.SNome = _nome; this.sCRMV = _crmv; }
        #endregion

        public void Salvar()
        {
            DaoVeterinario.Salvar(this);
        }

        public static List<Veterinario> Pesquisar()
        {
            return DaoVeterinario.Pesquisar();
        }

        public static Veterinario Obter(long _Responsavel)
        {
            return DaoVeterinario.Obter(_Responsavel);
        }

        public void Excluir()
        {
            DaoVeterinario.Excluir(this);
        }
    }
}
