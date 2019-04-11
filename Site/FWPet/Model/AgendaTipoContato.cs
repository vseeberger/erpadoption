using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class AgendaTipoContato
    {
        #region Atributos
        private string sTipo;
        private string sMascara;
        #endregion

        #region Propriedades
        public string STipo
        {
            get { return sTipo; }
            set { sTipo = value; }
        }
        public string SMascara
        {
            get { return sMascara; }
            set { sMascara = value; }
        }
        #endregion

        #region Construtores
        public AgendaTipoContato() { }
        public AgendaTipoContato(string _tipo) { this.sTipo = _tipo; }
        public AgendaTipoContato(string _tipo, string _mask) { this.sTipo = _tipo; this.sMascara = _mask; }
        #endregion

        public static List<AgendaTipoContato> Pesquisar()
        {
            List<AgendaTipoContato> Lst = new List<AgendaTipoContato>();
            Lst.Add(new AgendaTipoContato("Telefone", "fone-mask"));
            Lst.Add(new AgendaTipoContato("Celular", "cel-mask"));
            Lst.Add(new AgendaTipoContato("E-mail"));
            Lst.Add(new AgendaTipoContato("Outros"));
            return Lst;
        }

        public static AgendaTipoContato Obter(string _Tipo)
        {
            List<AgendaTipoContato> Lst = Pesquisar();
            return Lst.FirstOrDefault(w => w.sTipo == _Tipo);
        }
    }
}