using FWPet.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class configuracoes : _Herdar
    {
        private Configuracoes _Config
        {
            get
            {
                decimal d; long l; int i;
                Configuracoes item = new Configuracoes()
                {
                    Id = int.TryParse(hdfID.Value.ToString(), out i) ? i : 0,
                    DiaPagamento = int.TryParse(txtDiaPagamento.Text, out i) ? i : 1,
                    DValorDiaria = decimal.TryParse(txtValorDiaria.Text, out d) ? d : 0,
                    IQtdDiasAlertaContatoDeAdocao = int.TryParse(txtQuantDiasParaContato.Text, out i) ? i : 0,
                };

                return item;
            }
            set
            {
                if (value == null)
                {
                    txtDiaPagamento.Text = "1";
                    txtValorDiaria.Text = "0";
                    hdfID.Value = "0";
                    txtQuantDiasParaContato.Text = "0";
                }
                else
                {
                    txtDiaPagamento.Text = value.DiaPagamento.ToString();
                    txtValorDiaria.Text = value.DValorDiaria.ToString("#,#0.00");
                    hdfID.Value = value.Id.ToString();
                    txtQuantDiasParaContato.Text = value.IQtdDiasAlertaContatoDeAdocao.ToString();
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                Configuracoes itm = Configuracoes.Obter();
                _Config = itm;

                //existe a pasta de exames
                if (PastaExiste("~/Arquivos/Exames"))
                {
                    btnPastaExames.Attributes.Add("class", "form-control btn btn-danger");
                    btnPastaExames.ToolTip = "A pasta de exames já existe.";
                }
                else
                {
                    btnPastaExames.Attributes.Add("class", "form-control btn btn-info");
                    btnPastaExames.ToolTip = "A pasta de exames NÃO existe, clique para criar!";
                }

                //existe a pasta de animais
                if (PastaExiste("~/Arquivos/Fotos"))
                {
                    btnPastaAnimais.Attributes.Add("class", "form-control btn btn-danger");
                    btnPastaAnimais.ToolTip = "A pasta de fotos dos animais já existe";
                }
                else
                {
                    btnPastaAnimais.Attributes.Add("class", "form-control btn btn-info");
                    btnPastaAnimais.ToolTip = "A pasta de fotos dos animais NÃO existe, clique para criar!";
                }

                //existe a pasta de produtos
                if (PastaExiste("~/Arquivos/Produtos"))
                {
                    btnPastaProduto.Attributes.Add("class", "form-control btn btn-danger");
                    btnPastaProduto.ToolTip = "A pasta das fotos dos produtos já existe";
                }
                else
                {
                    btnPastaProduto.Attributes.Add("class", "form-control btn btn-info");
                    btnPastaProduto.ToolTip = "A pasta de produtos NÃO existe, clique para criar!";
                }
            }
        }

        private bool PastaExiste(string _Caminho)
        {
            return Directory.Exists(Server.MapPath(_Caminho));
        }

        private void CriarPasta(string _Caminho)
        {
            _Caminho = Server.MapPath(_Caminho);
            if (Directory.Exists(_Caminho)) throw new Exception("A pasta <b>já existe</b> por isso não será possível criar.");
            else
            {
                Directory.CreateDirectory(_Caminho);
                throw new ExceptionPet("A pasta <b>"+ _Caminho + "</b> foi criada com sucesso!");
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuracoes o = _Config;
                o.Salvar();
                MensagemAlertaPopup("Os dados foram gravados com sucesso.", Mensagens.Sucesso, this, "/Dashboard");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Redirecionar("/Dashboard");
        }

        protected void btnPastaProduto_Click(object sender, EventArgs e)
        {
            try
            {
                CriarPasta("~/Arquivos/Produtos");
            }
            catch(ExceptionPet ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnPastaAnimais_Click(object sender, EventArgs e)
        {
            try
            {
                CriarPasta("~/Arquivos/Fotos");
            }
            catch (ExceptionPet ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnPastaExames_Click(object sender, EventArgs e)
        {
            try
            {
                CriarPasta("~/Arquivos/Exames");
            }
            catch (ExceptionPet ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}