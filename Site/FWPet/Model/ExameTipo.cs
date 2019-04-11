using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class ExameTipo
    {
        #region Atributos
        private int id;
        private string sDescricao;
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
        #endregion

        public static List<ExameTipo> Lista()
        {
            List<ExameTipo> lst = new List<ExameTipo>();
            lst.Add(new ExameTipo() { id = 1, sDescricao = "Exame" });
            lst.Add(new ExameTipo() { id = 2, sDescricao = "Laudo" });
            lst.Add(new ExameTipo() { id = 3, sDescricao = "Outros" });
            return lst;
        }

        public static ExameTipo Obter(int id)
        {
            return Lista().Where(w => w.id == id).FirstOrDefault();
        }
    }
}
