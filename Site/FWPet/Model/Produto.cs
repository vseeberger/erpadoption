using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FWPet.Dao;

namespace FWPet.Model
{
    public class Produto
    {
        #region Atributos
        private long id;
        private MedicamentoGrupo grupo;
        private Empresa fabricantePrincipal;
        private string sTipoProduto;
        private string sReferencia;
        private string sNome;
        private string sNomeComercial;

        private bool trabalhaComLote;
        private bool possuiGrade;
        private bool importado;
        private bool ehMedicamento;
        private bool ehVacina;

        private decimal dPesoBruto;
        private decimal dPesoLiquido;
        private decimal dQuantidadeCompra;
        private decimal dEstoqueMinimo;
        private decimal dEstoqueMaximo;
        private int iQuantidadeEtiquetas;

        private bool temConversao;
        private List<ProdutoConversao> lstConversao;
        private List<ProdutoBarras> lstCodigoBarras;

        private List<ProdutoOutrosFabricantes> fabricantes;
        private List<ProdutoLote> lstLotes;
        private string sObservacoes;

        private DateTime dtmCadastro;
        private DateTime dtmUltAlt;
        private bool status;

        //CARACTERISTICAS DE MEDICAMENTO
        private MedicamentoGenerico generico;
        private MedicamentoPrincipioAtivo principioAtivo;

        //CARACTERISTICAS DE VACINA
        private Especie especie;
        private int iQuantidadeDiasValidade;
        private int iQuantidadeDoses;
        private int iQuantidadeDiasEntreDoses;

        private string sPathFotoCapa;
        private ProdutoMarca marca;
        #endregion

        #region Propriedades
        public string TextoDashboard
        {
            get
            {
                return (String.IsNullOrEmpty(this.sReferencia) ? "" : (this.sReferencia + " - ")) + this.sNome;
            }
        }
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public MedicamentoGrupo Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        public Empresa FabricantePrincipal
        {
            get { return fabricantePrincipal; }
            set { fabricantePrincipal = value; }
        }
        public string SReferencia
        {
            get { return sReferencia; }
            set { sReferencia = value; }
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
        public bool TrabalhaComLote
        {
            get { return trabalhaComLote; }
            set { trabalhaComLote = value; }
        }
        public bool PossuiGrade
        {
            get { return possuiGrade; }
            set { possuiGrade = value; }
        }
        public bool Importado
        {
            get { return importado; }
            set { importado = value; }
        }
        public decimal DPesoBruto
        {
            get { return dPesoBruto; }
            set { dPesoBruto = value; }
        }
        public decimal DPesoLiquido
        {
            get { return dPesoLiquido; }
            set { dPesoLiquido = value; }
        }
        public decimal DQuantidadeCompra
        {
            get { return dQuantidadeCompra; }
            set { dQuantidadeCompra = value; }
        }
        public decimal DEstoqueMinimo
        {
            get { return dEstoqueMinimo; }
            set { dEstoqueMinimo = value; }
        }
        public decimal DEstoqueMaximo
        {
            get { return dEstoqueMaximo; }
            set { dEstoqueMaximo = value; }
        }
        public int IQuantidadeEtiquetas
        {
            get { return iQuantidadeEtiquetas; }
            set { iQuantidadeEtiquetas = value; }
        }
        public bool TemConversao
        {
            get { return temConversao; }
            set { temConversao = value; }
        }
        public List<ProdutoConversao> LstConversao
        {
            get { return lstConversao; }
            set { lstConversao = value; }
        }
        public List<ProdutoBarras> LstCodigoBarras
        {
            get { return lstCodigoBarras; }
            set { lstCodigoBarras = value; }
        }
        public List<ProdutoOutrosFabricantes> Fabricantes
        {
            get { return fabricantes; }
            set { fabricantes = value; }
        }
        public string SObservacoes
        {
            get { return sObservacoes; }
            set { sObservacoes = value; }
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
        /// <summary>
        /// Tipos dos produtos
        /// --> M - MERCADORIA
        /// --> S - SERVIÇO
        /// --> I - IMOBILIZADO
        /// --> C - CONSUMO
        /// </summary>
        public string STipoProduto
        {
            get { return sTipoProduto; }
            set { sTipoProduto = value; }
        }
        public bool EhMedicamento
        {
            get { return ehMedicamento; }
            set { ehMedicamento = value; }
        }
        public bool EhVacina
        {
            get { return ehVacina; }
            set { ehVacina = value; }
        }
        public MedicamentoGenerico Generico
        {
            get { return generico; }
            set { generico = value; }
        }
        public MedicamentoPrincipioAtivo PrincipioAtivo
        {
            get { return principioAtivo; }
            set { principioAtivo = value; }
        }
        public Especie Especie
        {
            get { return especie; }
            set { especie = value; }
        }
        public int IQuantidadeDiasValidade
        {
            get { return iQuantidadeDiasValidade; }
            set { iQuantidadeDiasValidade = value; }
        }
        public int IQuantidadeDoses
        {
            get { return iQuantidadeDoses; }
            set { iQuantidadeDoses = value; }
        }
        public int IQuantidadeDiasEntreDoses
        {
            get { return iQuantidadeDiasEntreDoses; }
            set { iQuantidadeDiasEntreDoses = value; }
        }
        public List<ProdutoLote> LstLotes
        {
            get { return lstLotes; }
            set { lstLotes = value; }
        }
        public string SPathFotoCapa
        {
            get { return sPathFotoCapa; }
            set { sPathFotoCapa = value; }
        }
        public ProdutoMarca Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        #endregion

        #region Construtores
        public Produto() { }
        public Produto(long _id) { this.id = _id; }
        public Produto(long _id, string _nome) { this.id = _id; this.sNome = _nome; }
        #endregion

        public static List<Produto> Pesquisar(string _Tipo, bool? _Medicamento, bool? _Vacina, bool? PesquisarOU)
        {
            return DaoProduto.Pesquisar(_Tipo, _Medicamento, _Vacina, PesquisarOU);
        }

        public static Produto Obter(long _Codigo)
        {
            return DaoProduto.Obter(_Codigo);
        }

        public void Excluir()
        {
            DaoProduto.Excluir(this);
        }

        public void Salvar()
        {
            DaoProduto.Salvar(this);
        }

        /*
CADASTRO DE PRODUTO
   + CODIGO
   + SUBGRUPO
   + GRUPOO
   + FORNECEDOR PRINCIPAL
   + REFERENCIA
   + NOME
   + NOME COMERCIAL

[ DETALHES ]
   + [ ]TRABALHA COM LOTE
   + [ ]POSSUI GRADE
   + [ ]IMPORTADO
   + PESO BRUTO
   + PESO LIQUIDO
   + CAIXA (QUANTIDADE QUE SE COMPRA)
   + ESTOQUE MINIMO
   + ESTOQUE MAXIMO
   + ETIQUETAS
   + OBSERVACOES

[ FORNECEDORES ]

[ MEDICAMENTO ]
   + PRINCIPIO ATIVO
   + GENÉRICO

[ VACINA ]
   

[ CÓD. BARRAS ]
   + CODIGO DE BARRAS
       - TIPO [EAN 13]
       - GERAR [BOTÃO GERAR]
       - BARRA [texto do codigo de barras]
       - QUANTIDADE
       - UNIDADE
       - CÓDIGO SERVE PARA [ ] COMPRA    [ ] VENDA

    + [ ]TEM CONVERSAO
       - UNIDADE DE COMPRA
       - FATOR
       - OPERAÇÃO (MULTIPLICAÇÃO ou DIVISÃO)
       - UNIDADE DE CONTROLE (UNIDADE QUE SERÁ CONTROLADA - UNIDADE DE DESTINO --> 1 CAIXA * 12 --> 12 COMPRIMIDOS)
*/
    }
}