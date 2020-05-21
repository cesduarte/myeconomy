using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class DespesasVariadas : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        DespesasVariadasInformation despesasvariadasinf = new DespesasVariadasInformation();
        DespesasVariadasDAL objdespesasvariadas = new DespesasVariadasDAL();

        ContasAPagarDAL objcontaapagar = new ContasAPagarDAL();
        
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carrega_data();
                CarregarContasBancarias();
                CarregarClassificacao();
                CarregaGrid();

            }



        }

        public void carrega_data()
        {
            DateTime abre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatainicialpesquisa.Text = abre.ToString("yyyy-MM-dd");

            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatafinalpesquisa.Text = fecha.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");




        }
        //public void AtualizaSaldoContaBancaria(int IdContasBancarias, decimal Saldo)
        //{
        //    ContasBancariasInformation ContasBancariasInf = new ContasBancariasInformation();
        //    ContasBancariasInf.IdContasBancarias = IdContasBancarias;
        //    ContasBancariasInf.SaldoContasBancarias = Saldo;
        //    ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        //    objcontasbancarias.AlterarSaldoContasBancarias(ContasBancariasInf);
        //}

        public void CarregaGrid()
        {
            try
            {


               
                despesasvariadasinf.DescricaoDespesaVariada = Txtdescricaopesquisa.Text;
                despesasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);
                despesasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
                despesasvariadasinf.DataInicialPesquisa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                despesasvariadasinf.DataFinalPesquisa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);




                GrdDados.DataSource = objdespesasvariadas.PesquisarDespesaVariadas(despesasvariadasinf);
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


                despesasvariadasinf = null;
                foreach (DespesasVariadasInformation despesasvariadasinf in objdespesasvariadas.CarregarDespesaVariadascampos(id))
                {
                    Txtid.Text = Convert.ToString(despesasvariadasinf.IdDespesaVariada);
                    Txtdescricaodespesa.Text = despesasvariadasinf.DescricaoDespesaVariada;
                    Txtvalor.Text = Convert.ToString(despesasvariadasinf.ValorDespesaVariada);
                   
                    Dropcontasbancarias.SelectedValue = Convert.ToString(despesasvariadasinf.IdContasBancarias);
                    Dropclassificacao.SelectedValue = Convert.ToString(despesasvariadasinf.IdClassificacao);


                    //DateTime datateste = contasinf.DataVencimentoContas;
                    //string teste = datateste.ToString("yyyy-MM-dd");
                    Txtdata.Text = despesasvariadasinf.DataDespesaVariada.ToString("yyyy-MM-dd");
                   


                    

                   

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

                Dropclassificacao.DataSource = objclassificacao.CarregarClassificacao("", EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Despesas)));
                Dropclassificacao.DataTextField = "DescricaoClassificacao";
                Dropclassificacao.DataValueField = "Idclassificacao";
                Dropclassificacao.DataBind();


                Dropclassificacaopesquisa.DataSource = objclassificacao.CarregarClassificacao("", EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Despesas)));
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
            carrega_data();
            
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
                despesasvariadasinf.DescricaoDespesaVariada = Txtdescricaodespesa.Text;
                despesasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                despesasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                despesasvariadasinf.ValorDespesaVariada = Convert.ToDecimal(Txtvalor.Text);
                despesasvariadasinf.DataDespesaVariada = Convert.ToDateTime(Txtdata.Text);

                //AtualizaSaldoContaBancaria(Convert.ToInt32(Dropcontasbancarias.SelectedValue), (-Convert.ToDecimal(Txtvalor.Text)));

                objdespesasvariadas.InserirDespesaVariadas(despesasvariadasinf);

               
                Txtid.Text = despesasvariadasinf.IdDespesaVariada.ToString();
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {

                despesasvariadasinf.IdDespesaVariada = Convert.ToInt32(Txtid.Text);
                despesasvariadasinf.DescricaoDespesaVariada = Txtdescricaodespesa.Text;
                despesasvariadasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                despesasvariadasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                despesasvariadasinf.ValorDespesaVariada = Convert.ToDecimal(Txtvalor.Text);
                despesasvariadasinf.DataDespesaVariada = Convert.ToDateTime(Txtdata.Text);
                objdespesasvariadas.AlterarDespesaVariadas(despesasvariadasinf);

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
           

            

            objdespesasvariadas.ExcluirDespesaVariadas(int.Parse(txtidexclusao.Text));
            LimparCampos();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#ConfirmaExclusao').modal('hide');", true);
            CarregaGrid();
        }
    }
}