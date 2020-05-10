﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel;
namespace MyEconomy
{
    public partial class ContasAPagar : System.Web.UI.Page
    {
        ContasAPagarInformation contasapagarinf = new ContasAPagarInformation();
        ContasAPagarDAL objcontasapagar = new ContasAPagarDAL();
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();


        DespesaFixaInformation despesasfixasinf = new DespesaFixaInformation();
        DespesasFixasDAL objdespesasfixas = new DespesasFixasDAL();

        ContasAPagarDAL objcontaapagar = new ContasAPagarDAL();
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarStatus(DropStatusPesquisa, new StatusEnum.Status());
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
        public void CarregaGrid()
        {
            try
            {



                contasapagarinf.DescriaoDespesaFixa = Txtdescricaopesquisa.Text;
                contasapagarinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);
                contasapagarinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
                contasapagarinf.DataVencimentoInicialDespesaFixa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                contasapagarinf.DataVencimentoFinalDespesaFixa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);





                GrdDados.DataSource = objcontasapagar.PesquisarContasAPagar(contasapagarinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarContaAPagar(string id)
        {
            try
            {


                contasapagarinf = null;
                foreach (ContasAPagarInformation contasapagarinf in objcontaapagar.CarregarContasAPagar(id))
                {
                    Txtid.Text = Convert.ToString(contasapagarinf.IdContasAPagar);
                    Txtdescricaoconta.Text = contasapagarinf.DescriaoDespesaFixa;
                    Dropcontasbancarias.SelectedValue = Convert.ToString(contasapagarinf.IdContasBancarias);                    
                    Dropclassificacao.SelectedValue = Convert.ToString(contasapagarinf.IdClassificacao);
                    Txtvalor.Text = Convert.ToString(contasapagarinf.ValorDespesaFixa);                    
                    Txtdatavencimento.Text = contasapagarinf.DataVencimentoContasAPagar.ToString("yyyy-MM-dd");
                    txtStatus.Text = contasapagarinf.StatusContasAPagar;

                    if(contasapagarinf.StatusContasAPagar == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas)))
                    {
                        Dropcontasbancariasapagar.SelectedValue = Convert.ToString(contasapagarinf.IdContaBancariaPagamentoContasAPagar);
                        Txtvalorpago.Text = Convert.ToString(contasapagarinf.ValorPagamentoContasAPagar);
                        txtdatapagamento.Text = contasapagarinf.DataPagamentoContasAPagar.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        Dropcontasbancariasapagar.SelectedValue = Convert.ToString(contasapagarinf.IdContasBancarias);
                        Txtvalorpago.Text = Convert.ToString(contasapagarinf.ValorDespesaFixa);
                    }

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
                Dropcontasbancariasapagar.DataSource = null;



                Dropcontasbancariasapagar.DataSource = objcontasbancarias.CarregarContasBancariasCampos("");
                Dropcontasbancariasapagar.DataTextField = "DescricaoContasBancarias";
                Dropcontasbancariasapagar.DataValueField = "Idcontasbancarias";
                Dropcontasbancariasapagar.DataBind();






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
        public void CarregarStatus(DropDownList ddl, Enum source)
        {
            foreach (FieldInfo fi in source.GetType().GetFields())
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    ddl.Items.Add(new ListItem(attributes[0].Description, fi.GetRawConstantValue().ToString()));
                }
            }


        }

        public void LimparCamposPesquisa()
        {
            Txtdescricaopesquisa.Text = "";
            Dropcontasbancariaspesquisa.SelectedIndex = 0;
            Dropclassificacaopesquisa.SelectedIndex = 0;
            carrega_data();
            DropStatusPesquisa.SelectedIndex = 0;

        }

        public void LimparCampos()
        {
            
          

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
           

           }
           else
            {
                contasapagarinf.IdContasAPagar = Convert.ToInt32(Txtid.Text);
                contasapagarinf.IdContaBancariaPagamentoContasAPagar = Convert.ToInt32(Dropcontasbancariasapagar.SelectedValue);
                contasapagarinf.ValorPagamentoContasAPagar = Convert.ToDecimal(Txtvalorpago.Text);
                contasapagarinf.DataPagamentoContasAPagar = Convert.ToDateTime(txtdatapagamento.Text);
                contasapagarinf.StatusContasAPagar = EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas));
                objcontasapagar.AlterarContasAPagar(contasapagarinf);
               
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
              

                CarregarContaAPagar(e.CommandArgument.ToString());

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