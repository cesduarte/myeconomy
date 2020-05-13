using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class Investimento : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        InvestimentoInformation investimentosinf = new InvestimentoInformation();
        InvestimentoDAL objinvestimentos = new InvestimentoDAL();
        
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                CarregarContasBancarias();
               
                CarregaGrid();

            }



        }
        public void CarregaGrid()
        {
            try
            {


                investimentosinf.Isdelete = chkinativoPesquisa.Checked;
                investimentosinf.DescricaoInvestimento = Txtdescricaopesquisa.Text;

                investimentosinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);





                GrdDados.DataSource = objinvestimentos.PesquisarInvestimento(investimentosinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarInvestimento(string id)
        {
            try
            {


                investimentosinf = null;
                foreach (InvestimentoInformation investimentosinf in objinvestimentos.Carregarinvestimentoscampos(id))
                {
                    Txtid.Text = Convert.ToString(investimentosinf.IdInvestimento);
                    Txtdescricaoinvestimento.Text = investimentosinf.DescricaoInvestimento;
                    Txtsaldo.Text = Convert.ToString(investimentosinf.SaldoInvestimento);
                  
                    Dropcontasbancarias.SelectedValue = Convert.ToString(investimentosinf.IdContasBancarias);                   


                


                    Chkinativo.Checked = investimentosinf.Isdelete;

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
     
       

        public void LimparCamposPesquisa()
        {
            Txtdescricaopesquisa.Text = "";
            Dropcontasbancariaspesquisa.SelectedIndex = 0;
            
            chkinativoPesquisa.Checked = false;
        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricaoinvestimento.Text = "";
           
            Dropcontasbancarias.SelectedIndex = 0;
           
            Txtsaldo.Text = "";
          
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
                investimentosinf.DescricaoInvestimento = Txtdescricaoinvestimento.Text;
                investimentosinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                investimentosinf.SaldoInvestimento = Convert.ToDecimal(Txtsaldo.Text);

               
                investimentosinf.Isdelete = Chkinativo.Checked;
                objinvestimentos.InserirInvestimento(investimentosinf);
                


                Txtid.Text = investimentosinf.IdInvestimento.ToString();
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {

                investimentosinf.IdInvestimento = Convert.ToInt32(Txtid.Text);
                investimentosinf.DescricaoInvestimento = Txtdescricaoinvestimento.Text;
                investimentosinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                investimentosinf.SaldoInvestimento = Convert.ToDecimal(Txtsaldo.Text);
                investimentosinf.Isdelete = Chkinativo.Checked;

                //objdespesasfixas.AlterarDespesaFixa(despesasfixasinf);
                objinvestimentos.AlterarInvestimento(investimentosinf);

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
               

                CarregarInvestimento(e.CommandArgument.ToString());

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