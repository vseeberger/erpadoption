using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class ProdutoUnidade
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private string sSigla;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
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
        public string SSigla
        {
            get { return sSigla; }
            set { sSigla = value; }
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
        #endregion
        
        public static List<ProdutoUnidade> Pesquisa()
        {
            return DaoProdutoUnidade.Pesquisa();
        }       

        public static ProdutoUnidade Obter(int id)
        {
            return DaoProdutoUnidade.Obter(id);
        }
    }
}