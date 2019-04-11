using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class AnimalVacina
    {
        #region Atributos
        private long id;
        private long idAnimal;
        private Animal animvalVacinado;
        private Produto vacina;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime? dtmAplicacao;
        private DateTime? dtmAgendamento;
        private bool status;
        private bool aplicado = false;
        private int iDoseAplicada;
        private int iTotalDoses;
        #endregion

        #region Propriedades
        /// <summary>
        /// Código sequencia da vacinação.
        /// </summary>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Código do animal que recebeu a vacina
        /// </summary>
        public long IdAnimal
        {
            get { return idAnimal; }
            set { idAnimal = value; }
        }
        /// <summary>
        /// Qual a vacina que foi aplicada
        /// </summary>
        public Produto Vacina
        {
            get { return vacina; }
            set { vacina = value; }
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
        /// <summary>
        /// Data que foi realizada a aplicação
        /// </summary>
        public DateTime? DtmAplicacao
        {
            get { return dtmAplicacao; }
            set { dtmAplicacao = value; }
        }
        /// <summary>
        /// Data prevista para aplicação
        /// </summary>
        public DateTime? DtmAgendamento
        {
            get { return dtmAgendamento; }
            set { dtmAgendamento = value; }
        }
        /// <summary>
        /// Status /0 - inativo // 1 - Ativo
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Se a vacina foi aplicada ou está pendente.
        /// </summary>
        public bool Aplicado
        {
            get { return aplicado; }
            set { aplicado = value; }
        }
        /// <summary>
        /// Numero da dose que foi aplicada.
        /// </summary>
        public int IDoseAplicada
        {
            get { return iDoseAplicada; }
            set { iDoseAplicada = value; }
        }
        /// <summary>
        /// Quantidade de doses que devem ser dadas da vacina.
        /// </summary>
        public int ITotalDoses
        {
            get { return iTotalDoses; }
            set { iTotalDoses = value; }
        }
        public Animal AnimvalVacinado
        {
            get { return animvalVacinado; }
            set { animvalVacinado = value; }
        }
        #endregion

        #region Construtor
        public AnimalVacina() { }
        public AnimalVacina(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoAnimalVacina.Salvar(this);
        }

        public void Excluir()
        {
            DaoAnimalVacina.Excluir(this);
        }

        public static List<AnimalVacina> Pesquisar(long? _Animal)
        {
            return DaoAnimalVacina.Pesquisar(_Animal);
        }

        public static AnimalVacina Obter(long _AnimalVacina)
        {
            return DaoAnimalVacina.Obter(_AnimalVacina);
        }
    }
}