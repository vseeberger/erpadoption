using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Anamnese
    {
        #region Atributos
        private long id;
        private Animal animal;
        private string sDescricao;
        private string sAnamnese;

        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime dtmRealizacao;
        private Veterinario veterinario;

        private decimal? dPeso;
        private bool status;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
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
        public DateTime DtmRealizacao
        {
            get { return dtmRealizacao; }
            set { dtmRealizacao = value; }
        }
        public Veterinario Veterinario
        {
            get { return veterinario; }
            set { veterinario = value; }
        }
        public string SAnamnese
        {
            get { return sAnamnese; }
            set { sAnamnese = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public decimal? DPeso
        {
            get { return dPeso; }
            set { dPeso = value; }
        }
        #endregion

        #region Construtor
        public Anamnese() { }
        public Anamnese(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoAnamnese.Salvar(this);
        }

        public static List<Anamnese> Pesquisar(long _Animal)
        {
            return DaoAnamnese.Pesquisar(_Animal);
        }

        public static Anamnese Obter(long _Anamnese)
        {
            return DaoAnamnese.Obter(_Anamnese);
        }

        public void Excluir()
        {
            DaoAnamnese.Excluir(this);
        }
    }
}