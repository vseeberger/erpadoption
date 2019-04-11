using FWPet.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FWPet.Model
{
    public class LaboratorioClinico : Empresa
    {
        #region Construtor
        public LaboratorioClinico() { }
        public LaboratorioClinico(long _id) { this.Id = _id; }
        public LaboratorioClinico(long _id, string _nomefantasia) { this.Id = _id; this.SNomeFantasia = _nomefantasia; } 
        #endregion

        public void SalvarLaboratorio()
        {
            StringBuilder _Err = new StringBuilder();
            if (!String.IsNullOrEmpty(_Err.ToString().Trim())) throw new Exception("Atenção!<br/>" + _Err);
            DaoEmpresa.SalvarClinica(this);
        }

        public static List<LaboratorioClinico> Pesquisar()
        {
            return DaoEmpresa.PesquisarClinica();
        }

        public static LaboratorioClinico Obter(long _Empresa)
        {
            return DaoEmpresa.ObterClinica(_Empresa);
        }

        public void Excluir()
        {
            DaoEmpresa.ExcluirClinica(this);
        }
    }
}