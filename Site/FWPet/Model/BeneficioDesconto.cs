using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class BeneficioDesconto
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private decimal dValorMaximo;
        private decimal dPercentualDesconto;
        private bool status;
        private long? idColaborador;
        public bool Alterou { get; set; }
        public int Sequencia { get; set; }
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
        public decimal DValorMaximo
        {
            get { return dValorMaximo; }
            set { dValorMaximo = value; }
        }
        public decimal DPercentualDesconto
        {
            get { return dPercentualDesconto; }
            set { dPercentualDesconto = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public long? IdColaborador
        {
            get { return idColaborador; }
            set { idColaborador = value; }
        }
        #endregion

        #region Construtores
        public BeneficioDesconto() { }
        public BeneficioDesconto(int _id) { this.id = _id; } 
        #endregion

        public static List<BeneficioDesconto> Pesquisar()
        {
            return DaoBeneficioDesconto.Pesquisar();
        }

        public static BeneficioDesconto Obter(int id)
        {
            return DaoBeneficioDesconto.Obter(id);
        }

        public void Salvar()
        {
            DaoBeneficioDesconto.Salvar(this);
        }

        public void Excluir()
        {
            DaoBeneficioDesconto.Excluir(this);
        }

        public static void Excluir(int _id)
        {
            DaoBeneficioDesconto.Excluir(new BeneficioDesconto(_id));
        }
    }
}
