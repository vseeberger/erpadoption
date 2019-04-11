using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWPet.Model;

namespace Site
{
    public partial class cadastro_de_principioativo :_Herdar
    {
        private static MedicamentoPrincipioAtivo _Origem;
        private MedicamentoPrincipioAtivo item
        {
            get
            {
                int i;
                MedicamentoPrincipioAtivo item = new MedicamentoPrincipioAtivo()
                {
                    SDescricao = txtNome.Text,
                    Id = int.TryParse(txtCodigo.Text, out i) ? i : 0
                };
                if (this.item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (this.item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                if(value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SDescricao;
                }else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMÁTICO";
                    txtNome.Text = "";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = Request.QueryString.ToString();
                _Origem = null;
                int i;
                if (int.TryParse(id, out i) && i > 0)
                {
                    MedicamentoPrincipioAtivo o = MedicamentoPrincipioAtivo.Obter(i);
                    item = o;
                    _Origem = o;
                }
                else
                    item = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicamentoPrincipioAtivo o = item;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O PRINCIPIO ATIVO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosPrincipioAtivo", "/CadastroDePrincipioAtivo");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosPrincipioAtivo");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}