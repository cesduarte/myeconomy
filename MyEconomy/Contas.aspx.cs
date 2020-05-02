using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class Contas : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        ContasInformation contasinf = new ContasInformation();
        ContasDAL objconta = new ContasDAL();
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarCarregarContasBancarias();
                CarregarCarregarClassificacao();
                CarregaGrid();

            }



        }
        public void CarregaGrid()
        {
            //try
            //{
            //    ContasBancariasInf.Isdelete = chkinativoPesquisa.Checked;
            //    ContasBancariasInf.DescricaoContasBancarias = Txtdescricaopesquisa.Text;
            //    ContasBancariasInf.IdUsuario = Convert.ToInt32(Dropusuariopesquisa.SelectedValue);

            //    GrdDados.DataSource = objContasBancarias.PesquisarContasBancarias(ContasBancariasInf);
            //    GrdDados.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception();
            //}

        }

        public void CarregarCarregarContasBancarias()
        {
            try
            {


                Dropcontasbancarias.DataSource = null;
                Dropcontasbancariaspesquisa.DataSource = null;


                Dropcontasbancarias.DataSource = objcontasbancarias.CarregarContasBancariasCampos("");
                Dropcontasbancarias.DataTextField = "DescricaoContasBancarias";
                Dropcontasbancarias.DataValueField = "Idcontasbancarias";
                Dropcontasbancarias.DataBind();


                Dropcontasbancariaspesquisa.DataSource = objcontasbancarias.CarregarContasBancariasCampos("");
                Dropcontasbancariaspesquisa.DataTextField = "DescricaoContasBancarias";
                Dropcontasbancariaspesquisa.DataValueField = "Idcontasbancarias";
                Dropcontasbancariaspesquisa.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void CarregarCarregarClassificacao()
        {
            try
            {


                Dropclassificacao.DataSource = null;
                Dropclassificacaopesquisa.DataSource = null;

                Dropclassificacao.DataSource = objclassificacao.CarregarClassificacao("");
                Dropclassificacao.DataTextField = "DescricaoClassificacao";
                Dropclassificacao.DataValueField = "Idclassificacao";
                Dropclassificacao.DataBind();


                Dropclassificacaopesquisa.DataSource = objclassificacao.CarregarClassificacao("");
                Dropclassificacaopesquisa.DataTextField = "DescricaoClassificacao";
                Dropclassificacaopesquisa.DataValueField = "Idclassificacao";
                Dropclassificacaopesquisa.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void LimparCamposPesquisa()
        {
            Txtdescricaopesquisa.Text = "";
            Dropcontasbancariaspesquisa.SelectedIndex = 0;
            Dropclassificacaopesquisa.SelectedIndex = 0;
            TxtDatavencimentoPesquisa.Text = "";
            chkinativoPesquisa.Checked = false;
        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricaoconta.Text = "";

            Dropcontasbancarias.SelectedIndex = 0;
            Dropclassificacao.SelectedIndex = 0;
            Txtvalor.Text = "";
            Txtvalortotal.Text = "";
            Txtdatavencimento.Text = "";
            Txtparcelas.Text = "";
            Chkinativo.Checked = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            LimparCamposPesquisa();
            CarregaGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Txtid.Text == "")
            {
                contasinf.DescriaoContas = Txtdescricaoconta.Text;
                contasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                contasinf.IdClassificacao= Convert.ToInt32(Dropclassificacao.SelectedValue);




                if (validador.ValidarSaldo(Txtvalor.Text))
                {
                    contasinf.ValorContas = Convert.ToDecimal(0);
                    
                }
                else
                {
                    contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
                }

                if (validador.ValidarSaldo(Txtvalortotal.Text))
                {
                    contasinf.ValorTotalContas = Convert.ToDecimal(0);

                }
                else
                {
                    contasinf.ValorTotalContas = Convert.ToDecimal(Txtvalortotal.Text);
                }
                contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
                contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);


                contasinf.Isdelete = Chkinativo.Checked;
                objconta.InserirContas(contasinf);

               
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {
                contasinf.IdContas = Convert.ToInt32(Txtid.Text);
                contasinf.DescriaoContas = Txtdescricaoconta.Text;
                contasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                contasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);




                if (validador.ValidarSaldo(Txtvalor.Text))
                {
                    contasinf.ValorContas = Convert.ToDecimal(0);

                }
                else
                {
                    contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
                }

                if (validador.ValidarSaldo(Txtvalortotal.Text))
                {
                    contasinf.ValorTotalContas = Convert.ToDecimal(0);

                }
                else
                {
                    contasinf.ValorTotalContas = Convert.ToDecimal(Txtvalortotal.Text);
                }
                contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
                contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);


                contasinf.Isdelete = Chkinativo.Checked;
                objconta.AlterarContas(contasinf);

                Label9.Text = "Registro alterado com sucesso!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregaGrid();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('hide');", true);
            Timer1.Enabled = false;
        }

        protected void GrdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                //string IdContasBancárias = e.CommandArgument.ToString();

                //CarregarContasBancarias(IdContasBancárias);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

            }
        }

        protected void GrdDados_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GrdDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDados.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }

    }
}