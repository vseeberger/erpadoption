using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Vacina : Produto
    {
        #region Atributos
        private int id;
        private Especie especie;
        private Empresa empresa;
        private string sNome;
        private string sDescricao;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private int iQuantidadeDiasValidade;
        private bool status;
        private int iQuantidadeDoses;
        private string sAtencao;
        private int iQuantidadeDiasEntreDoses;
        #endregion

        #region Propriedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// FABRICANTE - USAR APENAS NA APLICAÇÃO DA VACINA e NÃO NO CADASTRO
        /// </summary>
        public Empresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
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
        public int IQuantidadeDiasValidade
        {
            get { return iQuantidadeDiasValidade; }
            set { iQuantidadeDiasValidade = value; }
        }
        public int IQuantidadeDoses
        {
            get { return iQuantidadeDoses; }
            set { iQuantidadeDoses = value; }
        }

        public string SAtencao
        {
            get
            {
                return sAtencao;
            }

            set
            {
                sAtencao = value;
            }
        }

        public Especie Especie
        {
            get
            {
                return especie;
            }

            set
            {
                especie = value;
            }
        }

        public int IQuantidadeDiasEntreDoses
        {
            get
            {
                return iQuantidadeDiasEntreDoses;
            }

            set
            {
                iQuantidadeDiasEntreDoses = value;
            }
        }
        #endregion

        #region Construtor
        public Vacina() { } 
        public Vacina(int _id) { this.id = _id; }
        public Vacina(int _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public void Salvar() { DaoVacina.Salvar(this); }
        public void Salvar(Vacina item) { DaoVacina.Salvar(item); }

        public static List<Vacina> Pesquisar()
        {
            return DaoVacina.Pesquisar();
        }

        public static Vacina Obter(int _Vacina)
        {
            return DaoVacina.Obter(_Vacina);
        }

        public void Excluir()
        {
            DaoVacina.Excluir(this);
        }
    }
}
