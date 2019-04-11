using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWPet.Model
{
    public class Laboratorio : Empresa
    {
        #region Construtor
        public Laboratorio() { }
        public Laboratorio(long _id) { this.Id = _id; }
        public Laboratorio(long _id,  string _nome) { this.Id = _id;  this.SRazaoSocial = _nome; }
        #endregion
        public void SalvarLaboratorio()
        {
            StringBuilder _Err = new StringBuilder();
            if (!String.IsNullOrEmpty(_Err.ToString().Trim())) throw new Exception("Atenção!<br/>" + _Err);
            DaoEmpresa.SalvarLaboratorio(this);
        }

        public static List<Laboratorio> Pesquisar()
        {
            return DaoEmpresa.PesquisarLaboratorio();
        }

        public static Laboratorio Obter(long _Empresa)
        {
            return DaoEmpresa.ObterLaboratorio(_Empresa);
        }

        public void Excluir()
        {
            DaoEmpresa.ExcluirLaboratorio(this);
        }
    }
}