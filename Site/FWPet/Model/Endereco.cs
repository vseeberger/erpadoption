using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Endereco
    {
        #region Atributos
        private long id;
        private string sEndereco;
        private string sBairro;
        private string sCidade;
        private string sUF;
        private string sCEP;
        private string sComplemento;
        private string sNumero;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool alterou;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SEndereco
        {
            get { return sEndereco; }
            set { sEndereco = value; }
        }
        public string SBairro
        {
            get { return sBairro; }
            set { sBairro = value; }
        }
        public string SCidade
        {
            get { return sCidade; }
            set { sCidade = value; }
        }
        public string SUF
        {
            get { return sUF; }
            set { sUF = value; }
        }
        public string SCEP
        {
            get { return sCEP; }
            set { sCEP = value; }
        }
        public string SComplemento
        {
            get { return sComplemento; }
            set { sComplemento = value; }
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

        public string SNumero
        {
            get
            {
                return sNumero;
            }

            set
            {
                sNumero = value;
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

        public void Salvar()
        {
            DaoEndereco.Salvar(this);
        }
    }
}