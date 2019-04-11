using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class AnimalFotos
    {
        #region Atributos
        private long id;
        private Animal animal;
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
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
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
            get
            {
                return bFotoMiniatura;
            }

            set
            {
                bFotoMiniatura = value;
            }
        }
        #endregion

        #region Construtor
        public AnimalFotos() { }
        public AnimalFotos(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoAnimalFotos.Salvar(this);
        }

        public static List<AnimalFotos> Pesquisar(long _Animal)
        {
            return DaoAnimalFotos.Pesquisar(_Animal);
        }

        public void Excluir()
        {
            DaoAnimalFotos.Excluir(this);
        }
    }
}
