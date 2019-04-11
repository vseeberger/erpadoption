using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Disponibilidade
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

        #region Construtores
        public Disponibilidade() { }
        public Disponibilidade(int _id) { this.id = _id; }
        public Disponibilidade(int _id, string _descricao) { this.id = _id; this.sDescricao = _descricao; }
        #endregion

        public static List<Disponibilidade> Lista()
        {
            List<Disponibilidade> lst = new List<Disponibilidade>();
            lst.Add(new Disponibilidade() { id = 1, sDescricao = "Disponível" });
            lst.Add(new Disponibilidade() { id = 2, sDescricao = "Em adoção" });
            lst.Add(new Disponibilidade() { id = 3, sDescricao = "Adotado" });
            lst.Add(new Disponibilidade() { id = 4, sDescricao = "Indisponível" });

            return lst;
        }

        public static Disponibilidade Obter(int id)
        {
            return Lista().Where(w => w.id == id).FirstOrDefault();
        }
    }
}