using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Agenda
    {
        #region Atributos
        private long id;
        private long id_usuario;
        private string sNome;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;
        private bool privado;
        private List<AgendaContato> contatos;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
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
        public List<AgendaContato> Contatos
        {
            get { return contatos; }
            set { contatos = value; }
        }
        public bool Privado
        {
            get { return privado; }
            set { privado = value; }
        }
        public long Id_usuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public string PrimeiroContato
        {
            get { return this.contatos == null || this.contatos.Count <= 0 ? "-" : this.contatos[0].STipoContato + ": " + this.contatos[0].SNome; }
        }
        #endregion

        #region Construtores
        public Agenda() { }
        public Agenda(long _id) { this.id = _id; }
        public Agenda(long _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public void Salvar()
        {
            DaoAgenda.Salvar(this);
        }

        public static List<Agenda> Pesquisar(long _Usuario)
        {
            return DaoAgenda.Pesquisar(_Usuario);
        }

        public static Agenda Obter(long _Agenda)
        {
            return DaoAgenda.Obter(_Agenda);
        }

        public void Excluir() { DaoAgenda.Excluir(this); }
    }
}