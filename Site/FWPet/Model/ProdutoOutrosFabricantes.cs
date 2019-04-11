using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ProdutoOutrosFabricantes
    {
        #region Atributos
        private long id;
        private int sequencia;
        private long idProdutoOriginal;
        private Empresa fabricante;
        private string sCodigoDoFabricante;
        private string sNomeDoProdutoDoFabricante;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool generico;
        private string sNomeGenerico;
        private bool alterou = false;
        #endregion

        #region Propriedades
        public Empresa Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }
        /// <summary>
        /// Código do produto no fabricante
        /// </summary>
        public string SCodigoDoFabricante
        {
            get { return sCodigoDoFabricante; }
            set { sCodigoDoFabricante = value; }
        }
        /// <summary>
        /// Nome do produto que o fabricante apresenta.
        /// </summary>
        public string SNomeDoProdutoDoFabricante
        {
            get { return sNomeDoProdutoDoFabricante; }
            set { sNomeDoProdutoDoFabricante = value; }
        }
        /// <summary>
        /// Código sequencia dentro do cadastro do produto (PROD: 001 - seq: 1 // PROD: 001 - seq 2 ...)
        /// </summary>
        public int Sequencia
        {
            get { return sequencia; }
            set { sequencia = value; }
        }
        /// <summary>
        /// Código do produto cadastrado no sistema.
        /// </summary>
        public long IdProdutoOriginal
        {
            get { return idProdutoOriginal; }
            set { idProdutoOriginal = value; }
        }
        /// <summary>
        /// Data do cadastro
        /// </summary>
        public DateTime DtmCadastro
        {
            get { return dtmCadastro; }
            set { dtmCadastro = value; }
        }
        /// <summary>
        /// data da ultima alteração do registro
        /// </summary>
        public DateTime DtmUltAlt
        {
            get { return dtmUltAlt; }
            set { dtmUltAlt = value; }
        }
        /// <summary>
        /// status (True - ativo // False - inativo)
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// indica se o medicamento é genérico
        /// </summary>
        public bool Generico
        {
            get
            {
                return generico;
            }

            set
            {
                generico = value;
            }
        }
        /// <summary>
        /// qual o nome genérico
        /// </summary>
        public string SNomeGenerico
        {
            get
            {
                return sNomeGenerico;
            }

            set
            {
                sNomeGenerico = value;
            }
        }

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool Alterou
        {
            get
            {
                return alterou;
            }

            set
            {
                alterou = value;
            }
        }
        #endregion

        public static List<ProdutoOutrosFabricantes> Pesquisar(long _Produto)
        {
            return DaoProdutoOutrosFabricantes.Pesquisar(_Produto);
        }

        public void Salvar()
        {
            DaoProdutoOutrosFabricantes.Salvar(this);
        }
    }
}