using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;
namespace MyEconomy
{
    public partial class Contas : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        ContasInformation contasinf = new ContasInformation();
        ContasDAL objconta = new ContasDAL();
        ContasAPagarDAL objcontaapagar = new ContasAPagarDAL();
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                CarregarContasBancarias();
                CarregarClassificacao();
                CarregaGrid();

            }



        }
        public void CarregaGrid()
        {
            try
            {


                contasinf.Isdelete = chkinativoPesquisa.Checked;
                contasinf.DescriaoContas = Txtdescricaopesquisa.Text;
                contasinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);
                contasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
               
               



                GrdDados.DataSource = objconta.PesquisarContas(contasinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarConta(string id)
        {
            try
            {


                contasinf = null;
                foreach (ContasInformation contasinf in objconta.Carregarcontascampos(id))
                {
                    Txtid.Text = Convert.ToString(contasinf.IdContas);
                    Txtdescricaoconta.Text = contasinf.DescriaoContas;
                    Txtvalor.Text = Convert.ToString(contasinf.ValorContas);
                    Txtvalortotal.Text = Convert.ToString(contasinf.ValorTotalContas);
                    Dropcontasbancarias.SelectedValue = Convert.ToString(contasinf.IdContasBancarias);
                    Dropclassificacao.SelectedValue = Convert.ToString(contasinf.IdClassificacao);


                    //DateTime datateste = contasinf.DataVencimentoContas;
                    //string teste = datateste.ToString("yyyy-MM-dd");
                    Txtdatavencimento.Text = contasinf.DataVencimentoContas.ToString("yyyy-MM-dd");
                    Txtparcelas.Text = Convert.ToString(contasinf.QuantParcelasContas);


                    Chkinativo.Checked = contasinf.Isdelete;

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void CarregarContasBancarias()
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
        public void InserirContasAPagar(ContasInformation _contasinf)
        {
            ContasAPagarInformation contasapagarinf = new ContasAPagarInformation();

            DateTime dataatual = DateTime.Now.Date;
            

                for (int i = 0; i < _contasinf.QuantParcelasContas; i++)
                {
                    contasapagarinf.IdContas = _contasinf.IdContas;
                    contasapagarinf.DataVencimentoContasAPagar = _contasinf.DataVencimentoContas.AddMonths(i);
                    contasapagarinf.NParcelaContasAPagar = i+1;
                    contasapagarinf.StatusContasAPagar = Convert.ToInt32(StatusEnum.Status.ContasAPagar);
                    objcontaapagar.InserirContas(contasapagarinf);

                }
            



            
           
            



            

        }
        public void CarregarClassificacao()
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

                contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
                contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
                contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);
                contasinf.ValorTotalContas = contasinf.ValorContas * contasinf.QuantParcelasContas;
                contasinf.QuantParcelasaPagarContas = Convert.ToInt32(Txtparcelas.Text);
                contasinf.Isdelete = Chkinativo.Checked;
                objconta.InserirContas(contasinf);
                Txtid.Text =  contasinf.IdContas.ToString();
                InserirContasAPagar(contasinf);
               
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

                contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
                contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
                contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);
                contasinf.ValorTotalContas = contasinf.ValorContas * contasinf.QuantParcelasContas;

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
                string IdContasBancárias = e.CommandArgument.ToString();

                CarregarConta(e.CommandArgument.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

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