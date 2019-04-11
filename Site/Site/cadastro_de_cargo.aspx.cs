using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_cargo : _Herdar
    {
        private static Cargo _Origem;
        private Cargo item
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar a descrição.");

                long i; decimal d;
                Cargo item = new Cargo()
                {
                    Id = long.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SDescricao = txtNome.Text,
                    Status = true,
                    IdCBO = long.TryParse(ddlCBO.SelectedValue.ToString(), out i) ? i : 0,
                };

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                List<CBO> LstCbo = new List<CBO>();
                LstCbo.Add(new CBO() { Id = 0, SDescricao = "selecione" });
                LstCbo.AddRange(CBO.Pesquisar());
                ddlCBO.DataSource = LstCbo;
                ddlCBO.DataValueField = "Id";
                ddlCBO.DataTextField = "SDescricao";
                ddlCBO.DataBind();

                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SDescricao;
                    ddlCBO.SelectedValue = value.IdCBO.ToString();
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtNome.Text = "";
                    ddlCBO.SelectedValue = "0";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    String id = Request.QueryString.ToString();
                    _Origem = null;
                    long i;
                    if (long.TryParse(id, out i) && i > 0)
                    {
                        Cargo raca = Cargo.Obter(i);
                        item = raca;
                        _Origem = raca;
                    }
                    else
                        item = null;
                }
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsCargos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cargo o = item;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O CARGO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsCargos", "/CadastroDeCargo");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}