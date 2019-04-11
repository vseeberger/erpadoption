using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class AdocaoAnexos
    {
        #region Atributos
        private long id;
        private AnimalAdotado adocao;
        private string sNome_original_arquivo;
        private string sNome_novo_arquivo;
        private string sExtensao;
        private byte[] bArquivo;
        private byte[] bFotoMiniatura;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome_original_arquivo
        {
            get { return sNome_original_arquivo; }
            set { sNome_original_arquivo = value; }
        }
        public string SNome_novo_arquivo
        {
            get { return sNome_novo_arquivo; }
            set { sNome_novo_arquivo = value; }
        }
        public string SExtensao
        {
            get { return sExtensao; }
            set { sExtensao = value; }
        }
        public byte[] BArquivo
        {
            get { return bArquivo; }
            set { bArquivo = value; }
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
        public byte[] BFotoMiniatura
        {
            get { return bFotoMiniatura; }
            set { bFotoMiniatura = value; }
        }
        public AnimalAdotado Adocao
        {
            get { return adocao; }
            set { adocao = value; }
        }
        #endregion
    }
}
