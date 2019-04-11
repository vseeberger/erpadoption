using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_produto : _Herdar
    {
        private static Produto _Origem;
        private static List<ProdutoOutrosFabricantes> _OutrosFornecedores;
        private static FileUpload _Foto;

        private Produto _Medicamento
        {
            get
            {
                int i = 0;
                long l = 0;
                decimal d;

                Produto __item = new Produto()
                {
                    Id = long.TryParse(txtCodigo.Text, out l) ? l : 0,
                    SNome = txtNomeDoProduto.Text,
                    SNomeComercial = txtNomeComercial.Text,
                    SObservacoes = txtObservacoes.Text,
                    SReferencia = txtReferencia.Text,
                    STipoProduto = rblTipos.SelectedValue,

                    DEstoqueMaximo = decimal.TryParse(txtEstoqueMaximo.Text, out d) ? d : 0,
                    DEstoqueMinimo = decimal.TryParse(txtEstoqueMinimo.Text, out d) ? d : 0,
                    DPesoBruto = decimal.TryParse(txtPesoBruto.Text, out d) ? d : 0,
                    DPesoLiquido = decimal.TryParse(txtPesoLiquido.Text, out d) ? d : 0,
                    DQuantidadeCompra = decimal.TryParse(txtQtdCaixa.Text, out d) ? d : 0,

                    EhMedicamento = cbxEhMedicamento.Checked,
                    EhVacina = cbxEhVacina.Checked,

                    Importado = cbxImportado.Checked,
                    PossuiGrade = cbxPossuiGrade.Checked,
                    TrabalhaComLote = cbxTrabalhaComLote.Checked,

                    IQuantidadeDiasEntreDoses = int.TryParse(txtEntreDoses.Text, out i) ? i : 0,
                    IQuantidadeDiasValidade = int.TryParse(txtQntDiasValidade.Text, out i) ? i : 0,
                    IQuantidadeDoses = int.TryParse(txtQntDoses.Text, out i) ? i : 0,
                    IQuantidadeEtiquetas = 0,

                    FabricantePrincipal = new Empresa(long.TryParse(ddlFornecedor.SelectedValue.ToString(), out l) ? l : 0),
                    Fabricantes = _OutrosFornecedores,

                    Especie = new Especie(int.TryParse(ddlEspecie.SelectedValue.ToString(), out i) ? i : 0),
                    Generico = new MedicamentoGenerico(long.TryParse(ddlGenerico.SelectedValue.ToString(), out l) ? l : 0),
                    Grupo = new MedicamentoGrupo(int.TryParse(ddlGrupo.SelectedValue.ToString(), out i) ? i : 0),
                    PrincipioAtivo = new MedicamentoPrincipioAtivo(int.TryParse(ddlPrincipioAtivo.SelectedValue.ToString(), out i) ? i : 0),
                    Marca = new ProdutoMarca(int.TryParse(ddlMarca.SelectedValue.ToString(), out i) ? i : 0),

                    Status = true,
                };

                //verifica se tem nova foto
                if (fupCapa.HasFile)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fupCapa.FileName);

                    String _NovoNomeDoArquivo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String _NovoNomeCheck = _NovoNomeDoArquivo;
                    String _PastaWebconfig = "~/Arquivos/Produtos";
                    String _DestinoDoArquivo = Server.MapPath(_PastaWebconfig);

                    int conta = 0;
                    while (System.IO.File.Exists(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension))
                    {
                        conta++;
                        _NovoNomeCheck = _NovoNomeDoArquivo + "_" + conta;
                    }

                    fupCapa.SaveAs(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension);
                    __item.SPathFotoCapa = _NovoNomeCheck + fi.Extension;
                }
                else __item.SPathFotoCapa = hdfFotoAtual.Value.ToString();

                //validar o fornecedor principal, deve estar selecionado > 0

                //validar o nome, deve estar preenchido
                //caso o nome comercial esteja vazio, então recebe o nome do produto

                //validar espécie caso seja VACINA

                //validar princípio ativo caso seja MEDICAMENTO


                if (__item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (__item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return __item;
            }
            set
            {
                _Foto = null;
                //Carrega os grupos
                List<MedicamentoGrupo> LstGrupo = new List<MedicamentoGrupo>();
                LstGrupo.Add(new MedicamentoGrupo() { Id = 0, SDescricao = "selecione..." });
                LstGrupo.AddRange(MedicamentoGrupo.Pesquisar());
                ddlGrupo.DataSource = LstGrupo;
                ddlGrupo.DataValueField = "Id";
                ddlGrupo.DataTextField = "SDescricao";
                ddlGrupo.DataBind();

                //Carrega os genericos na dropdown
                List<MedicamentoGenerico> Lst = new List<MedicamentoGenerico>();
                Lst.Add(new MedicamentoGenerico() { Id = 0, SDescricao = "selecione..." });
                Lst.AddRange(MedicamentoGenerico.Pesquisar());
                ddlGenerico.DataSource = Lst;
                ddlGenerico.DataValueField = "Id";
                ddlGenerico.DataTextField = "SDescricao";
                ddlGenerico.DataBind();

                //Carrega os Laboratórios
                List<Laboratorio> LstFornecedor = new List<Laboratorio>();
                LstFornecedor.Add(new Laboratorio() { Id = 0, SRazaoSocial = "selecione..." });
                LstFornecedor.AddRange(Laboratorio.Pesquisar());
                ddlFornecedor.DataSource = LstFornecedor;
                ddlFornecedor.DataValueField = "Id";
                ddlFornecedor.DataTextField = "SRazaoSocial";
                ddlFornecedor.DataBind();

                //Carrega o principio ativo
                List<MedicamentoPrincipioAtivo> LstPAtivo = new List<MedicamentoPrincipioAtivo>();
                LstPAtivo.Add(new MedicamentoPrincipioAtivo() { Id = 0, SDescricao = "selecione..." });
                LstPAtivo.AddRange(MedicamentoPrincipioAtivo.Pesquisar());
                ddlPrincipioAtivo.DataSource = LstPAtivo;
                ddlPrincipioAtivo.DataValueField = "Id";
                ddlPrincipioAtivo.DataTextField = "SDescricao";
                ddlPrincipioAtivo.DataBind();

                //Inicializa a lista para não dar erro e dispensar validação de NULL
                _OutrosFornecedores = new List<ProdutoOutrosFabricantes>();

                List<ProdutoMarca> LstMarcas = new List<ProdutoMarca>();
                LstMarcas.Add(new ProdutoMarca() { Id = 0, SDescricao = "selecione" });
                LstMarcas.AddRange(ProdutoMarca.Pesquisar());
                ddlMarca.DataSource = LstMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "SDescricao";
                ddlMarca.DataBind();

                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtNomeDoProduto.Text = "";
                    txtNomeComercial.Text = "";
                    txtObservacoes.Text = "";
                    txtReferencia.Text = "";
                    rblTipos.SelectedValue = "C";
                    txtEstoqueMaximo.Text = "";
                    txtEstoqueMinimo.Text = "";
                    txtPesoBruto.Text = "";
                    txtPesoLiquido.Text = "";
                    txtQtdCaixa.Text = "";
                    cbxEhMedicamento.Checked = false;
                    cbxEhVacina.Checked = false;
                    cbxImportado.Checked = false;
                    cbxPossuiGrade.Checked = false;
                    cbxTrabalhaComLote.Checked = false;
                    txtEntreDoses.Text = "";
                    txtQntDiasValidade.Text = "";
                    txtQntDoses.Text = "";
                    ddlFornecedor.SelectedValue = "0";
                    ddlEspecie.SelectedValue = "0";
                    ddlGenerico.SelectedValue = "0";
                    ddlGrupo.SelectedValue = "0";
                    ddlPrincipioAtivo.SelectedValue = "0";
                    hdfFotoAtual.Value = "";
                    ddlMarca.SelectedValue = "0";
                    img.ImageUrl = "~/img/pic.jpg";
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNomeDoProduto.Text = value.SNome;
                    txtNomeComercial.Text = value.SNomeComercial;
                    txtObservacoes.Text = value.SObservacoes;
                    txtReferencia.Text = value.SReferencia;
                    rblTipos.SelectedValue = value.STipoProduto;
                    txtEstoqueMaximo.Text = value.DEstoqueMaximo.ToString("0");
                    txtEstoqueMinimo.Text = value.DEstoqueMinimo.ToString("0");
                    txtPesoBruto.Text = value.DPesoBruto.ToString("#,0.000");
                    txtPesoLiquido.Text = value.DPesoLiquido.ToString("#,0.000");
                    txtQtdCaixa.Text = value.DQuantidadeCompra.ToString("0");
                    cbxEhMedicamento.Checked = value.EhMedicamento;
                    cbxEhVacina.Checked = value.EhVacina;
                    cbxImportado.Checked = value.Importado;
                    cbxPossuiGrade.Checked = value.PossuiGrade;
                    cbxTrabalhaComLote.Checked = value.TrabalhaComLote;
                    txtEntreDoses.Text = value.IQuantidadeDiasEntreDoses.ToString();
                    txtQntDiasValidade.Text = value.IQuantidadeDiasValidade.ToString();
                    txtQntDoses.Text = value.IQuantidadeDoses.ToString();
                    ddlFornecedor.SelectedValue = value.FabricantePrincipal == null ? "0" : value.FabricantePrincipal.Id.ToString();
                    ddlEspecie.SelectedValue = value.Especie == null ? "0" : value.Especie.Id.ToString();
                    ddlGenerico.SelectedValue = value.Generico == null ? "" : value.Generico.Id.ToString();
                    ddlGrupo.SelectedValue = value.Grupo == null ? "0" : value.Grupo.Id.ToString();
                    ddlPrincipioAtivo.SelectedValue = value.PrincipioAtivo == null ? "0" : value.PrincipioAtivo.Id.ToString();
                    hdfFotoAtual.Value = value.SPathFotoCapa;
                    ddlMarca.SelectedValue = value.Marca == null ? "0" : value.Marca.Id.ToString();
                    img.ImageUrl = String.IsNullOrEmpty(value.SPathFotoCapa) ? "~/img/pic.jpg" : "~/Arquivos/Produtos/" + value.SPathFotoCapa;
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = String.IsNullOrEmpty(Request.QueryString.ToString()) ? "" : Request.QueryString[0];
                _Origem = null;
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    Produto item = Produto.Obter(i);
                    _Medicamento = item;
                    _Origem = item;
                }
                else
                    _Medicamento = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto o = _Medicamento;
                o.Salvar();
                Type tipo = o.GetType();
                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O PRODUTO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsProdutos", "/CadastroDeProduto");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsProdutos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        #region Genéricos
        private MedicamentoGenerico _Genericos
        {
            get
            {
                long l;
                MedicamentoGenerico item = new MedicamentoGenerico()
                {
                    Id = long.TryParse(txtGenericoCodigo.Text, out l) ? l : 0,
                    SDescricao = txtGenericoDescricao.Text,
                    Status = true
                };
                return item;
            }
            set
            {
                if(value == null)
                {
                    //limpa
                    txtGenericoDescricao.Text = "";
                    txtGenericoCodigo.Text = "AUTOMATICO";
                }
                else
                {
                    //valores
                    txtGenericoDescricao.Text = value.SDescricao;
                    txtGenericoCodigo.Text = value.Id.ToString("00000");
                }
            }
        }

        protected void btnCancelarGenerico_Click(object sender, EventArgs e)
        {
            try
            {
                txtGenericoCodigo.Text = "AUTOMATICO";
                txtGenericoDescricao.Text = "";

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "fnFechar(); fnSelect();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnSalvarGenerico_Click(object sender, EventArgs e)
        {
            MedicamentoGenerico _item = null;
            try
            {
                //Salva o genérico
                _item = _Genericos;
                MedicamentoGenerico __origem = _Genericos;
                _item.Salvar();
                
                //Limpa os campos
                txtGenericoCodigo.Text = "AUTOMATICO";
                txtGenericoDescricao.Text = "";

                GravarLog(__origem == null || __origem.Id == 0 ? 1 : 2, " O PRODUTO GENÉRICO CÓDIGO: " + _item.Id, Util.serializarObjetos(__origem, _item.GetType()), Util.serializarObjetos(_item, _item.GetType()), _item.GetType());
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "fnFechar(); fnSelect();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally
            {
                //Atualiza o ddlGenericos
                if (_item != null && _item.Id > 0) CarregaGenericos(_item.Id);
                RegistrarJavascripts(this);
            }
        }

        protected void CarregaGenericos(long? _codigo = null)
        {
            try
            {
                List<MedicamentoGenerico> Lst = new List<MedicamentoGenerico>();
                Lst.Add(new MedicamentoGenerico() { Id = -1, SDescricao = "selecione..." });
                Lst.AddRange(MedicamentoGenerico.Pesquisar());
                ddlGenerico.DataSource = Lst;
                ddlGenerico.DataValueField = "Id";
                ddlGenerico.DataTextField = "SDescricao";
                ddlGenerico.DataBind();
                if (_codigo != null) ddlGenerico.SelectedValue = _codigo.ToString();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
        #endregion
    }
}