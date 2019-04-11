using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class LogAcao
    {
        #region Atributos
        private int id;
        private string sDescricao;
        private string sTexto;
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
        public string STexto
        {
            get { return sTexto; }
            set { sTexto = value; }
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

        public static List<LogAcao> Pesquisar()
        {
            return DaoLogAcao.Listar();
        }

        public static LogAcao Obter(int id)
        {
            return DaoLogAcao.Obter(id);
        }
    }
}