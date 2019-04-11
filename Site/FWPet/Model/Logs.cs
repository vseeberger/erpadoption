using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class Logs
    {
        #region Atributos
        private long id;
        private string sDescricao;
        private DateTime dtmCadastro;
        private Usuario usuario;
        private Formulario tela;
        private LogAcao acao;
        private string sObjetoAntes;
        private string sObjetoDepois;
        private Type tipoDoObjeto;
        #endregion

        #region Propriedades
        public long Id
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
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public Formulario Tela
        {
            get { return tela; }
            set { tela = value; }
        }
        public LogAcao Acao
        {
            get { return acao; }
            set { acao = value; }
        }
        /// <summary>
        /// Objeto deve estar serializado.
        /// </summary>
        public string SObjetoAntes
        {
            get { return sObjetoAntes; }
            set { sObjetoAntes = value; }
        }
        /// <summary>
        /// Objeto deve estar serializado.
        /// </summary>
        public string SObjetoDepois
        {
            get { return sObjetoDepois; }
            set { sObjetoDepois = value; }
        }
        public Type TipoDoObjeto
        {
            get { return tipoDoObjeto; }
            set { tipoDoObjeto = value; }
        }

        #endregion

        #region Construtores
        public Logs() { }
        public Logs(long _id) { this.id = _id; }
        public Logs(string _Descricao, long _Usuario, int _Tela, int _Acao, string _ObjetoAntes, string _ObjetoDepois, Type _tipo)
        {
            this.sDescricao = _Descricao;
            this.usuario = new Usuario(_Usuario);
            this.tela = new Formulario(_Tela);
            this.acao = new LogAcao() { Id = _Acao };
            this.sObjetoAntes = _ObjetoAntes;
            this.sObjetoDepois = _ObjetoDepois;
            this.tipoDoObjeto = _tipo;
        }
        #endregion

        public static List<Logs> Pesquisar(DateTime? _PeriodoDe, DateTime? _PeriodoAte, int? _Tela, long? _Usuario, int? _Acao, int _QuantRegistros)
        {
            return DaoLogs.Pesquisar(_PeriodoDe, _PeriodoAte, _Tela, _Usuario, _Acao, _QuantRegistros);
        }

        public static Logs Obter(long id)
        {
            return DaoLogs.Obter(id);
        }

        public void Salvar()
        {
            DaoLogs.Salvar(this);
        }
        public static void Salvar(Logs item)
        {
            DaoLogs.Salvar(item);
        }
    }
}