using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_vacinas : _Herdar
    {
        private static Vacina _Origem;
        private Vacina item
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar o nome da <b>Vacina</b>!");
                int i;
                Vacina item = new Vacina()
                {
                    SDescricao = txtDescricao.Text,
                    Especie = new Especie(int.TryParse(ddlEspecie.SelectedValue, out i) ? i : 0, ddlEspecie.SelectedItem.Text),
                    SNome = txtNome.Text,
                    SAtencao = txtAtencao.Text,
                    IQuantidadeDiasValidade = int.TryParse(txtQntDiasValidade.Text, out i) ? i : 1,
                    IQuantidadeDoses = int.TryParse(txtQntDoses.Text, out i) ? i : 1,
                    IQuantidadeDiasEntreDoses = int.TryParse(txtEntreDoses.Text, out i) ? i : 0,
                };
                
                item.Id = int.TryParse(txtCodigo.Text, out i) ? i : 0;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    ddlEspecie.SelectedValue = value.Especie.Id.ToString();
                    txtDescricao.Text = value.SDescricao;
                    txtNome.Text = value.SNome;
                    txtAtencao.Text = value.SAtencao;
                    txtQntDiasValidade.Text = value.IQuantidadeDiasValidade.ToString();
                    txtQntDoses.Text = value.IQuantidadeDoses.ToString();
                    txtEntreDoses.Text = value.IQuantidadeDiasEntreDoses.ToString();
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    ddlEspecie.SelectedIndex = 0;
                    txtDescricao.Text = "";
                    txtNome.Text = "";
                    txtAtencao.Text = "";
                    txtQntDiasValidade.Text = "1";
                    txtQntDoses.Text = "1";
                    txtEntreDoses.Text = "0";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                ddlEspecie.DataSource = Especie.Pesquisar();
                ddlEspecie.DataTextField = "SDescricao";
                ddlEspecie.DataValueField = "Id";
                ddlEspecie.DataBind();

                if (!IsPostBack)
                {
                    String id = Request.QueryString.ToString();
                    _Origem = null;
                    int i;
                    if (int.TryParse(id, out i) && i > 0)
                    {
                        Vacina vac = Vacina.Obter(i);
                        item = vac;
                        _Origem = vac;
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
                Redirecionar("TodasAsVacinas");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Vacina vac = item;
                vac.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " A VACINA CÓDIGO: " + vac.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(vac, vac.GetType()), vac.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + vac.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodasAsVacinas", "/CadastroDeVacina");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}