using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Medicamento
    {
        #region Atributos
        private long id;
        private string sReferencia;
        private Empresa fabricantePrincipal;
        private string sNome;
        private string sNomeComercial;
        private List<MedicamentoOutrosFabricantes> fabricantes;
        private MedicamentoGenerico generico;
        private MedicamentoGrupo grupo;
        private string sObservacoes;
        private MedicamentoPrincipioAtivo principioAtivo;
        private bool status;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        #endregion

        #region Propriedades
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string SReferencia
        {
            get { return sReferencia; }
            set { sReferencia = value; }
        }
        public Empresa FabricantePrincipal
        {
            get { return fabricantePrincipal; }
            set { fabricantePrincipal = value; }
        }
        public string SNome
        {
            get { return sNome; }
            set { sNome = value; }
        }
        public string SNomeComercial
        {
            get { return sNomeComercial; }
            set { sNomeComercial = value; }
        }
        public List<MedicamentoOutrosFabricantes> Fabricantes
        {
            get { return fabricantes; }
            set { fabricantes = value; }
        }
        public MedicamentoGenerico Generico
        {
            get { return generico; }
            set { generico = value; }
        }
        public MedicamentoGrupo Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        public string SObservacoes
        {
            get { return sObservacoes; }
            set { sObservacoes = value; }
        }
        public MedicamentoPrincipioAtivo PrincipioAtivo
        {
            get { return principioAtivo; }
            set { principioAtivo = value; }
        }

        public bool Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public DateTime DtmCadastro
        {
            get
            {
                return dtmCadastro;
            }

            set
            {
                dtmCadastro = value;
            }
        }

        public DateTime DtmUltAlt
        {
            get
            {
                return dtmUltAlt;
            }

            set
            {
                dtmUltAlt = value;
            }
        }
        #endregion

        #region Construtor
        public Medicamento() { }
        public Medicamento(long _id) { this.id = _id; }
        public Medicamento(long _id, string _medicamento) { this.id = _id; this.sNome = _medicamento; }
        #endregion

        public static List<Medicamento> Pesquisar()
        {
            return DaoMedicamento.Pesquisar();
        }

        public static Medicamento Obter(long _Medicamento)
        {
            return DaoMedicamento.Obter(_Medicamento);
        }

        public void Salvar()
        {
            StringBuilder _Err = new StringBuilder();
            if (String.IsNullOrEmpty(this.sReferencia)) _Err.Append("Informe a REFERÊNCIA do produto no fornecedor.<br />");
            if (String.IsNullOrEmpty(this.sNome)) _Err.Append("Informe o NOME do produto.<br />");
            if (this.FabricantePrincipal == null) _Err.Append("Selecione o LABORATÓRIO.<br />");
            if (!String.IsNullOrEmpty(_Err.ToString().Trim())) throw new Exception("Atenção!<br/>" + _Err.ToString());

            DaoMedicamento.Salvar(this);
        }

        public void Excluir()
        {
            DaoMedicamento.Excluir(this);
        }
    }
}