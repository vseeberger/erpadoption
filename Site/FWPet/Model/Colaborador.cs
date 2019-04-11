using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Colaborador : Pessoas
    {
        #region Atributos
        private List<ColaboradorEscala> lstEscalas;
        private string sHoraTrabalhoInicio;
        private string sHoraTrabalhoTermino;
        private bool escalaSegunda;
        private bool escalaTerca;
        private bool escalaQuarta;
        private bool escalaQuinta;
        private bool escalaSexta;
        private bool escalaSabado;
        private bool escalaDomingo;

        private bool bDiarista;
        private decimal dValor;
        private int diaPagamento;
        private bool bDiaristaRecebeNaDiaria;

        private List<ColaboradorFerias> lstFerias;
        private List<ColaboradorBeneficioDesconto> lstBeneficios;
        #endregion

        #region Propriedades
        public List<ColaboradorEscala> LstEscalas
        {
            get { return lstEscalas; }
            set { lstEscalas = value; }
        }
        public string SHoraTrabalhoInicio
        {
            get { return sHoraTrabalhoInicio; }
            set { sHoraTrabalhoInicio = value; }
        }
        public string SHoraTrabalhoTermino
        {
            get { return sHoraTrabalhoTermino; }
            set { sHoraTrabalhoTermino = value; }
        }
        public bool EscalaSegunda
        {
            get { return escalaSegunda; }
            set { escalaSegunda = value; }
        }
        public bool EscalaTerca
        {
            get { return escalaTerca; }
            set { escalaTerca = value; }
        }
        public bool EscalaQuarta
        {
            get { return escalaQuarta; }
            set { escalaQuarta = value; }
        }
        public bool EscalaQuinta
        {
            get { return escalaQuinta; }
            set { escalaQuinta = value; }
        }
        public bool EscalaSexta
        {
            get { return escalaSexta; }
            set { escalaSexta = value; }
        }
        public bool EscalaSabado
        {
            get { return escalaSabado; }
            set { escalaSabado = value; }
        }
        public bool EscalaDomingo
        {
            get { return escalaDomingo; }
            set { escalaDomingo = value; }
        }
        public bool BDiarista
        {
            get { return bDiarista; }
            set { bDiarista = value; }
        }
        public decimal DValor
        {
            get { return dValor; }
            set { dValor = value; }
        }
        public int DiaPagamento
        {
            get { return diaPagamento; }
            set { diaPagamento = value; }
        }
        /// <summary>
        /// Quando marcado, significa que o conta a pagar tem que ser no dia da diária, quando não marcado deve informar o dia do pagamento
        /// </summary>
        public bool BDiaristaRecebeNaDiaria
        {
            get { return bDiaristaRecebeNaDiaria; }
            set { bDiaristaRecebeNaDiaria = value; }
        }
        public List<ColaboradorFerias> LstFerias
        {
            get { return lstFerias; }
            set { lstFerias = value; }
        }
        public List<ColaboradorBeneficioDesconto> LstBeneficios
        {
            get { return lstBeneficios; }
            set { lstBeneficios = value; }
        }
        #endregion

        #region Construtor
        public Colaborador() { }
        public Colaborador(long _id) { this.Id = _id; }
        public Colaborador(long _id, string _nome) { this.Id = _id; this.SNome = _nome; }
        #endregion

        public void Salvar()
        {
            DaoColaborador.Salvar(this);
        }

        public static List<Colaborador> Pesquisar()
        {
            return DaoColaborador.Pesquisar();
        }

        public static Colaborador Obter(long _Responsavel)
        {
            return DaoColaborador.Obter(_Responsavel);
        }

        public void Excluir()
        {
            DaoColaborador.Excluir(this);
        }
    }
}