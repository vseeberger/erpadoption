using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Anexo
    {
        #region Atributos
        private long id;
        private string sDescricao;
        private string sCaminhoAnexo;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private long idRelacionado;
        private bool status;
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
        public string SCaminhoAnexo
        {
            get { return sCaminhoAnexo; }
            set { sCaminhoAnexo = value; }
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
        public long IdRelacionado
        {
            get { return idRelacionado; }
            set { idRelacionado = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion
    }
}
