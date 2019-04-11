using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Exame
    {
        #region Atributos
        private long id;
        private string sDescricao;
        private ExameTipo tipo;
        private LaboratorioClinico laboratorio;
        private string sProfissionalQueAssinou;
        private Veterinario profissionalQueRequisitou;
        private Animal animal;
        private string sCorpoExame;
        private Anexo anexo;
        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private DateTime? dtmRealizacao;
        private DateTime? dtmAgendamento;
        private bool status;
        private string sPathAnexo;
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
        public ExameTipo Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public LaboratorioClinico Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }
        public string SProfissionalQueAssinou
        {
            get { return sProfissionalQueAssinou; }
            set { sProfissionalQueAssinou = value; }
        }
        public Veterinario ProfissionalQueRequisitou
        {
            get { return profissionalQueRequisitou; }
            set { profissionalQueRequisitou = value; }
        }
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
        }
        /// <summary>
        /// Caso o exame venha em TXT ou seja possível copiar o conteúdo e copiar, utilizar este campo ou utilizar para observações.
        /// </summary>
        public string SCorpoExame
        {
            get { return sCorpoExame; }
            set { sCorpoExame = value; }
        }
        public Anexo Anexo
        {
            get { return anexo; }
            set { anexo = value; }
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
        public DateTime? DtmRealizacao
        {
            get { return dtmRealizacao; }
            set { dtmRealizacao = value; }
        }
        public DateTime? DtmAgendamento
        {
            get { return dtmAgendamento; }
            set { dtmAgendamento = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

        public string SPathAnexo
        {
            get
            {
                return sPathAnexo;
            }

            set
            {
                sPathAnexo = value;
            }
        }
        #endregion

        #region Construtor
        public Exame() { }
        public Exame(long _id) { this.id = _id; }
        #endregion

        public void Salvar()
        {
            DaoExame.Salvar(this);
        }

        public static List<Exame> Pesquisar(long _Animal)
        {
            return DaoExame.Pesquisar(_Animal);
        }

        public static Exame Obter(long _Exame)
        {
            return DaoExame.Obter(_Exame);
        }

        public void Excluir()
        {
            DaoExame.Excluir(this);
        }
    }
}