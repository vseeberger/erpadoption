using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class AnimalMedicamento
    {
        #region Atributos
        private long id;
        private string sCodAgrupamento;
        private string sPosologia;

        private Animal animalMedicado;
        private Produto medicamento;
        private Usuario quemMedicou;

        private int iDose;
        private int iTotalDose;
        private int iDiaAtual;
        private int iQuantidadeDias;
        
        private DateTime? dtmInicio;
        private DateTime? dtmMedicado;
        private DateTime? dtmPrevisao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;

        private bool aplicado;
        private List<AnimalMedicamento> lstMedicacao;
        private string sObservacao;
        private AnimalMedicamentoTratamento tratamento;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Quando um medicamento for por mais de uma vez, todos os registros terão este código igual e o ID diferente.
        /// </summary>
        public string SCodAgrupamento
        {
            get { return sCodAgrupamento; }
            set { sCodAgrupamento = value; }
        }

        public Animal AnimalMedicado
        {
            get { return animalMedicado; }
            set { animalMedicado = value; }
        }
        public Produto Medicamento
        {
            get { return medicamento; }
            set { medicamento = value; }
        }
        public Usuario QuemMedicou
        {
            get { return quemMedicou; }
            set { quemMedicou = value; }
        }

        public int IDose
        {
            get { return iDose; }
            set { iDose = value; }
        }
        public int ITotalDose
        {
            get { return iTotalDose; }
            set { iTotalDose = value; }
        }
        
        public int IDiaAtual
        {
            get { return iDiaAtual; }
            set { iDiaAtual = value; }
        }
        public int IQuantidadeDias
        {
            get { return iQuantidadeDias; }
            set { iQuantidadeDias = value; }
        }

        public DateTime? DtmMedicado
        {
            get { return dtmMedicado; }
            set { dtmMedicado = value; }
        }
        public DateTime? DtmInicio
        {
            get { return dtmInicio; }
            set { dtmInicio = value; }
        }
        /// <summary>
        /// Data que a aplicação está prevista para ocorrer.
        /// </summary>
        public DateTime? DtmPrevisao
        {
            get { return dtmPrevisao; }
            set { dtmPrevisao = value; }
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
        public bool Aplicado
        {
            get { return aplicado; }
            set { aplicado = value; }
        }
        public string SPosologia
        {
            get            {                return sPosologia;            }
            set            {                sPosologia = value;            }
        }
        public bool Liberado { get; set; }

        public List<AnimalMedicamento> LstMedicacao
        {
            get
            {
                return lstMedicacao;
            }

            set
            {
                lstMedicacao = value;
            }
        }

        public string SObservacao
        {
            get
            {
                return sObservacao;
            }

            set
            {
                sObservacao = value;
            }
        }

        public AnimalMedicamentoTratamento Tratamento
        {
            get
            {
                return tratamento;
            }

            set
            {
                tratamento = value;
            }
        }
        #endregion

        #region Construtor
        public AnimalMedicamento() { }
        public AnimalMedicamento(long _id) { this.id = _id; }
        #endregion

        public void Excluir()
        {
            DaoAnimalMedicamento.Excluir(this);
        }

        public void ConfirmarMedicacao()
        {
            DaoAnimalMedicamento.RealizarAplicacao(this);
        }

        public static void Salvar(List<AnimalMedicamento> lst)
        {
            DaoAnimalMedicamento.Salvar(lst);
        }

        public static AnimalMedicamento Obter(long _Codigo)
        {
            return DaoAnimalMedicamento.Obter(_Codigo);
        }

        public static AnimalMedicamento ObterAgrupamento(long _Codigo)
        {
            return DaoAnimalMedicamento.ObterAgrupamento(_Codigo);
        }

        public static List<AnimalMedicamento> Pesquisar(long? _Animal, DateTime? _Previsao, long? _Medicamento, bool? _PendenteOuAplicado, string _Agrupamento, int? _Tratamento)
        {
            return DaoAnimalMedicamento.Pesquisar(_Animal, _Previsao, _Medicamento, _PendenteOuAplicado, _Agrupamento, _Tratamento);
        }

        public static List<AnimalMedicamento> Dashboard()
        {
            return DaoAnimalMedicamento.Dashboard();
        }
    }
}