using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class AgendaContato
    {
        #region Atributos
        private long id;
        private long id_contato;
        private Agenda contato;
        private string sTipoContato;
        private string sNome;
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
        public long Id_contato
        {
            get { return id_contato; }
            set { id_contato = value; }
        }
        public Agenda Contato
        {
            get { return contato; }
            set { contato = value; }
        }
        public string STipoContato
        {
            get { return sTipoContato; }
            set { sTipoContato = value; }
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
        #endregion

        #region Construtores
        public AgendaContato() { }
        public AgendaContato(long _id) { this.id = _id; }
        public AgendaContato(long _id, string _nome) { this.id = _id; this.sNome = _nome; }
        public AgendaContato(long _id, string _nome, string _tipo_contato) { this.id = _id; this.sNome = _nome; this.sTipoContato = _tipo_contato; }
        #endregion

        public static void Salvar(List<AgendaContato> Lst, long _Contato)
        {
            DaoAgendaContato.Salvar(Lst, _Contato);
        }

        public static List<AgendaContato> Pesquisar(long? _Contato)
        {
            return DaoAgendaContato.Pesquisar(_Contato);
        }

        public void Excluir() { DaoAgendaContato.Excluir(this); }
    }
}