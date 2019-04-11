using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Animal
    {
        #region Atributos
        private long id;
        private string sNome;
        private Especie especie;
        private Raca raca;
        private char cSexo;
        private Disponibilidade situacao;
        private Adotante adotante;
        private Responsavel responsavel;
        private string sObservacoes;

        //INFORMAÇÕES
        private Porte porte;
        private string sNumeroChip;
        private string sCor;
        private DateTime? dtmChegou;
        private DateTime? dtmResgate;
        private DateTime? dtmNascimento;
        private Animal pai;
        private Animal mae;

        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;

        private bool status;

        private List<Anamnese> lstAnamneses;
        private List<AnimalVacina> lstVacinas;
        private List<Exame> lstExames;

        private bool castrado;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public Especie Especie
        {
            get { return especie; }
            set { especie = value; }
        }
        public Raca Raca
        {
            get { return raca; }
            set { raca = value; }
        }
        public char CSexo
        {
            get { return cSexo; }
            set { cSexo = value; }
        }
        public Disponibilidade Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
        public Adotante Adotante
        {
            get { return adotante; }
            set { adotante = value; }
        }
        public Responsavel Responsavel
        {
            get { return responsavel; }
            set { responsavel = value; }
        }
        public string SObservacoes
        {
            get { return sObservacoes; }
            set { sObservacoes = value; }
        }
        public Porte Porte
        {
            get { return porte; }
            set { porte = value; }
        }
        public string SNumeroChip
        {
            get { return sNumeroChip; }
            set { sNumeroChip = value; }
        }
        public string SCor
        {
            get { return sCor; }
            set { sCor = value; }
        }
        public DateTime? DtmResgate
        {
            get { return dtmResgate; }
            set { dtmResgate = value; }
        }
        public DateTime? DtmNascimento
        {
            get { return dtmNascimento; }
            set { dtmNascimento = value; }
        }
        public Animal Pai
        {
            get { return pai; }
            set { pai = value; }
        }
        public Animal Mae
        {
            get { return mae; }
            set { mae = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public List<Anamnese> LstAnamneses
        {
            get { return lstAnamneses; }
            set { lstAnamneses = value; }
        }
        public List<AnimalVacina> LstVacinas
        {
            get { return lstVacinas; }
            set { lstVacinas = value; }
        }
        public List<Exame> LstExames
        {
            get { return lstExames; }
            set { lstExames = value; }
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
        public bool Castrado
        {
            get { return castrado; }
            set { castrado = value; }
        }
        public DateTime? DtmChegou
        {
            get { return dtmChegou; }
            set { dtmChegou = value; }
        }
        #endregion

        #region Construtor
        public Animal() { }
        public Animal(long _id) { this.id = _id; }
        public Animal(long _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public override bool Equals(object obj)
        {
            return obj != null && this.GetType() == obj.GetType() && ((Animal)obj).id == this.id;
        }
        
        public static List<Animal> Pesquisar(string _Nome = null, int? _Situacao = null, bool? _Status = null, long? _Padrinho = null)
        {
            return DaoAnimal.Pesquisar(_Nome, _Situacao, _Status, _Padrinho);
        }

        public static Animal Obter(long _Animal)
        {
            return DaoAnimal.Obter(_Animal);
        }

        public void Salvar()
        {
            DaoAnimal.Salvar(this);
        }

        public void Excluir()
        {
            DaoAnimal.Excluir(this);
        }

        public static List<Animal> Disponiveis(long? _Animal = null)
        {
            return DaoAnimal.Disponiveis(_Animal);
        }

        /// <summary>
        /// Quantidade de animais cadastrados ATIVOS que estão em tratamento
        /// </summary>
        /// <returns></returns>
        public static int DashboardTotalTratamento()
        {
            return DaoAnimal.DashboardTotalTratamento();
        }

        /// <summary>
        /// Quantidade de animais cadastrados ATIVOS - E SITUACAO <> ADOTADO.
        /// </summary>
        /// <returns></returns>
        public static int DashboardTotal()
        {
            return DaoAnimal.DashboardTotal();
        }

        /// <summary>
        /// Quantidade de animais cadastrados nos últimos dias (_Dias)
        /// </summary>
        /// <param name="_Dias">dias anteriores a data de hoje.</param>
        /// <returns></returns>
        public static int DashboardNovosAnimais(int _Dias)
        {
            return DaoAnimal.DashboardNovosAnimais(_Dias);
        }
    }
}