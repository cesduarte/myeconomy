using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class ReceitasVariadas : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        ReceitasVariadasInformation receitasvariadasinf = new ReceitasVariadasInformation();
        ReceitasVariadasDAL objreceitasvariadas = new ReceitasVariadasDAL();

        

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
        public void AtualizaSaldoContaBancaria(int IdContasBancarias, decimal Saldo)
        {
            ContasBancariasInformation ContasBancariasInf = new ContasBancariasInformation();
            ContasBancariasInf.IdContasBancarias = IdContasBancarias;
            ContasBancariasInf.SaldoContasBancarias = Saldo;
            ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
            objcontasbancarias.AlterarSaldoContasBancarias(ContasBancariasInf);
        }

        public void CarregaGrid()
        {
            try
            {



                receitasvariadasinf.DescricaoReceitaVariada = Txtdescricaopesquisa.Text;
                receitasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);
                receitasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);





                GrdDados.DataSource = objreceitasvariadas.PesquisarReceitas(receitasvariadasinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarDespesasVariadas(string id)
        {
            try
            {


                receitasvariadasinf = null;
                foreach (ReceitasVariadasInformation receitasvariadasinf in objreceitasvariadas.CarregarDespesaVariadascampos(id))
                {
                    Txtid.Text = Convert.ToString(receitasvariadasinf.IdReceitaVariada);
                    Txtdescricaodespesa.Text = receitasvariadasinf.DescricaoReceitaVariada;
                    Txtvalor.Text = Convert.ToString(receitasvariadasinf.ValorReceita);

                    Dropcontasbancarias.SelectedValue = Convert.ToString(receitasvariadasinf.IdContasBancarias);
                    Dropclassificacao.SelectedValue = Convert.ToString(receitasvariadasinf.IdClassificacao);


                    //DateTime datateste = contasinf.DataVencimentoContas;
                    //string teste = datateste.ToString("yyyy-MM-dd");
                    Txtdata.Text = receitasvariadasinf.DataReceitaVariada.ToString("yyyy-MM-dd");







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

        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricaodespesa.Text = "";

            Dropcontasbancarias.SelectedIndex = 0;
            Dropclassificacao.SelectedIndex = 0;
            Txtvalor.Text = "";
            Txtvalor.Text = "";
            Txtdata.Text = "";


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
                receitasvariadasinf.DescricaoReceitaVariada = Txtdescricaodespesa.Text;
                receitasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                receitasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                receitasvariadasinf.ValorReceita = Convert.ToDecimal(Txtvalor.Text);
                receitasvariadasinf.DataReceitaVariada = Convert.ToDateTime(Txtdata.Text);

                AtualizaSaldoContaBancaria(Convert.ToInt32(Dropcontasbancarias.SelectedValue), (Convert.ToDecimal(Txtvalor.Text)));

                objreceitasvariadas.InserirReceitas(receitasvariadasinf);


                Txtid.Text = receitasvariadasinf.IdReceitaVariada.ToString();
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {

                receitasvariadasinf.IdReceitaVariada = Convert.ToInt32(Txtid.Text);
                receitasvariadasinf.DescricaoReceitaVariada = Txtdescricaodespesa.Text;
                receitasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                receitasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                receitasvariadasinf.ValorReceita = Convert.ToDecimal(Txtvalor.Text);
                receitasvariadasinf.DataReceitaVariada = Convert.ToDateTime(Txtdata.Text);
                objreceitasvariadas.AlterarDespesaVariadas(receitasvariadasinf);

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

                CarregarDespesasVariadas(e.CommandArgument.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

            }

            if (e.CommandName == "Deletar")
            {
                txtidexclusao.Text = e.CommandArgument.ToString();





                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#ConfirmaExclusao').modal('show');", true);

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

        protected void Excluir(object sender, EventArgs e)
        {






        }

        protected void Button7_Click(object sender, EventArgs e)
        {


            foreach (ReceitasVariadasInformation receitasvariadasinf1 in objreceitasvariadas.CarregarDespesaVariadascampos(txtidexclusao.Text))
            {









                AtualizaSaldoContaBancaria(receitasvariadasinf1.IdContasBancarias, (-receitasvariadasinf1.ValorReceita));
            }

            objreceitasvariadas.ExcluirReceitasVariadas(int.Parse(txtidexclusao.Text));
            LimparCampos();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#ConfirmaExclusao').modal('hide');", true);
            CarregaGrid();
        }
    }
}