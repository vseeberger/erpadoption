using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class AnimalAdotado
    {
        #region Atributos
        private long id;
        private DateTime dtmAdocao;
        private DateTime? dtmDevolucao;
        private Animal animal;
        private Adotante adotante;
        private Endereco enderecoOndeFicaOAnimal;
        private bool status;
        private bool alterado;
        private bool enderecoDoAdotante;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime DtmAdocao
        {
            get { return dtmAdocao; }
            set { dtmAdocao = value; }
        }
        public DateTime? DtmDevolucao
        {
            get { return dtmDevolucao; }
            set { dtmDevolucao = value; }
        }
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
        }
        public Adotante Adotante
        {
            get { return adotante; }
            set { adotante = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public Endereco EnderecoOndeFicaOAnimal
        {
            get { return enderecoOndeFicaOAnimal; }
            set { enderecoOndeFicaOAnimal = value; }
        }
        public bool Alterado
        {
            get { return alterado; }
            set { alterado = value; }
        }
        public bool EnderecoDoAdotante
        {
            get { return enderecoDoAdotante; }
            set { enderecoDoAdotante = value; }
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
        #endregion

        public void Salvar()
        {
            DaoAnimalAdotado.Salvar(this);
        }

        public static List<AnimalAdotado> Pesquisar(long? _Adotante, long? _Animal, int _Tipo)
        {
            return DaoAnimalAdotado.Pesquisar(_Adotante, _Animal, _Tipo);
        }

        public static AnimalAdotado Obter(long _AdocaoID)
        {
            return DaoAnimalAdotado.Obter(_AdocaoID);
        }

        public void Desistir()
        {
            DaoAnimalAdotado.Desistir(this);
        }
    }
}