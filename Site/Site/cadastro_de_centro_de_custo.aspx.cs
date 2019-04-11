using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_centro_de_custo : _Herdar
    {
        private static CentroDeCustos _Origem;
        private CentroDeCustos _Centro
        {
            get
            {
                int i;
                CentroDeCustos item = new CentroDeCustos()
                {
                    Id = int.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SDescricao = txtDescricao.Text,
                    SCustoLucro = "I",
                    Status = true,
                };

                if (String.IsNullOrEmpty(item.SDescricao)) throw new Exception("Informe a descrição da conta.");
                
                return item;
            }
            set
            {
                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtDescricao.Text = "";
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtDescricao.Text = value.SDescricao;
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                _Origem = null;
                String id = Request.QueryString.ToString();
                int i;
                if (int.TryParse(id, out i) && i > 0)
                {
                    CentroDeCustos itm = CentroDeCustos.Obter(i);
                    _Centro = itm;
                    _Origem = itm;
                }
                else
                    _Centro = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                CentroDeCustos o = _Centro;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O CENTRO DE CUSTOS CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsCentrosDeCustos", "/CadastroDeCentroDeCustos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsCentrosDeCustos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}