using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class RelatorioTotalizador : paginaBase
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        InvestimentoDAL objinvestimento = new InvestimentoDAL();
        ExtratoBancarioDAL objextratobancario = new ExtratoBancarioDAL();
        ExtratosBancariosInformation extratosinf = new ExtratosBancariosInformation();

        DespesaFixaInformation despesasfixasinf = new DespesaFixaInformation();
        DespesasFixasDAL objdespesasfixas = new DespesasFixasDAL();

        ContasAPagarDAL objcontaapagar = new ContasAPagarDAL();
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarStatus(DropOrganizarpor, new StatusEnum.OrganizarPorRelatorios());
                carrega_data();
                CarregarContasBancarias();
                CarregarClassificacao();
                CarregaGrid();

            }



        }

        public void MudarDataPositivo(object sender, EventArgs e)
        {
            

        }

        public void MudarDataNegativo(object sender, EventArgs e)
        {
           
        }
        public void CacularRodape(DataSet tabela)
        {
            try
            {
                CalcularTotalizadorInformation calc = new CalcularTotalizadorInformation();
                
               
              

                for (int i = 0; i < tabela.Tables[0].Rows.Count; i++)
                {

                    calc.TotReceitas += validador.ValidarDecimal(tabela.Tables[0].Rows[i]["receitas"].ToString());
                    calc.TotDespesasVariadas += validador.ValidarDecimal(tabela.Tables[0].Rows[i]["Despesasvariadas"].ToString());
                    calc.TotDespesasFixasPagas += validador.ValidarDecimal(tabela.Tables[0].Rows[i]["DespesaFixaPaga"].ToString());
                    calc.TotDespesasFixasAPagar += validador.ValidarDecimal(tabela.Tables[0].Rows[i]["DespesaFixaapagar"].ToString());
                    calc.TotInvestimento += validador.ValidarDecimal(tabela.Tables[0].Rows[i]["investimento"].ToString());


                }

                GridViewRow footer = GrdDados.FooterRow;
                footer.Cells[0].Text = "Total";
                footer.Cells[1].Text = string.Format("{0:c}", calc.TotReceitas);
                footer.Cells[2].Text = string.Format("{0:c}", calc.TotDespesasVariadas);
                footer.Cells[3].Text = string.Format("{0:c}", calc.TotDespesasFixasPagas);
                footer.Cells[4].Text = string.Format("{0:c}", calc.TotDespesasFixasAPagar);
                footer.Cells[5].Text = string.Format("{0:c}", calc.TotInvestimento);
                CalcularTotalizadores(calc);


            }
            catch(Exception ex)
            {

            }
        }
        public void CalcularTotalizadores(CalcularTotalizadorInformation calc)
        {
            try
            {
                 decimal TotReceitas = calc.TotReceitas;
                //decimal TotReceitasDespesasvariadas = calc.TotReceitas - calc.TotDespesasVariadas;
                //decimal TotReceitasDespesasFixasPagas = calc.TotReceitas - calc.TotDespesasFixasPagas;
                //decimal TotReceitasDespesasFixasAPagar = calc.TotReceitas - calc.TotDespesasFixasAPagar;
                decimal TotDespesasVariadasFixasPagas = calc.TotDespesasVariadas + calc.TotDespesasFixasPagas;



                lblreceitaDespesasVariadas.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", calc.TotDespesasVariadas + calc.TotReceitas);
                lblreceitasdespesasfixaspagas.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", calc.TotDespesasFixasPagas + calc.TotReceitas);
                lblreceitasdespesasfixasapagar.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", calc.TotReceitas - calc.TotDespesasFixasAPagar);
                lblreceitasdespesasvariadasfixas.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", TotDespesasVariadasFixasPagas + TotReceitas);

                lbldespesasvariadasfixas.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", calc.TotDespesasVariadas + calc.TotDespesasFixasPagas);
                lblreceitasinvest.Text = String.Format(new CultureInfo("pt-BR"), "{0:C}", calc.TotInvestimento + calc.TotReceitas);
            }
            catch(Exception ex)
            {

            }
          
        }
        public void carrega_data()
        {
            DateTime abre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatainicialpesquisa.Text = abre.ToString("yyyy-MM-dd");

            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatafinalpesquisa.Text = fecha.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");




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
        public void CarregaGrid()
        {
            try
            {
                DataSet Grid = new DataSet();

                ExtratosBancariosInformation extratosinf = new ExtratosBancariosInformation();


              
                extratosinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
                extratosinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);

                extratosinf.DataInicialPesquisa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                extratosinf.DataFinalPesquisa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);

                if (DropOrganizarpor.SelectedItem.ToString() == EnumExtensions.GetEnumDescription((StatusEnum.OrganizarPorRelatorios.ContasBancarias)))
                {
                    Grid = objextratobancario.RelatorioExtratoTotalizadorContasBancarias(extratosinf);
                    GrdDados.DataSource = Grid;
                }
                else
                {
                    Grid = objextratobancario.RelatorioExtratoTotalizadorClassificacao(extratosinf);
                    GrdDados.DataSource = Grid;
                }

                   







                GrdDados.DataBind();
                CacularRodape(Grid);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
       
      
        public void VerificarInvestimento()
        {
            try
            {



                foreach (ClassificacaoInformation classificacaoinf in objclassificacao.CarregarClassificacao(Dropclassificacao.SelectedValue, ""))
                {
                    if (classificacaoinf.TipoClassificacao == EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Investimento)))
                    {
                        DropInvestimento.Visible = true;
                        lblinvestimento.Visible = true;
                        //CarregarInvestimento();
                    }
                    else
                    {
                        DropInvestimento.Visible = false;
                        lblinvestimento.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void DesabilitaHabilitaCampos()
        {
            if (txtStatus.Text == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas)))
            {
                Dropcontasbancariasapagar.Enabled = false;
                Txtvalorpago.ReadOnly = true;
                txtdatapagamento.ReadOnly = true;
                Button2.Visible = false;
                Button5.Visible = true;
            }
            else
            {
                Dropcontasbancariasapagar.Enabled = true;
                Txtvalorpago.ReadOnly = false;
                txtdatapagamento.ReadOnly = false;
                Button2.Visible = true;
                Button5.Visible = false;
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

                Dropclassificacao.DataSource = objclassificacao.CarregarClassificacao("", "Extrato");
                Dropclassificacao.DataTextField = "DescricaoClassificacao";
                Dropclassificacao.DataValueField = "Idclassificacao";
                Dropclassificacao.DataBind();


                Dropclassificacaopesquisa.DataSource = objclassificacao.CarregarClassificacao("", "Extrato");
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
           
            Dropcontasbancariaspesquisa.SelectedIndex = 0;
            Dropclassificacaopesquisa.SelectedIndex = 0;
            carrega_data();
        

        }

        public void LimparCampos()
        {

            DropInvestimento.Visible = false;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void ExportExcel(object sender, EventArgs e)
        {

            if (GrdDados.Rows.Count != 0)
            {

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Relatório de Contas a Pagar .xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    //To Export all pages
                    GrdDados.AllowPaging = false;
                    this.CarregaGrid();
                    GrdDados.Columns[10].Visible = false;
                    GrdDados.Columns[11].Visible = false;
                    GrdDados.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in GrdDados.HeaderRow.Cells)
                    {
                        cell.BackColor = GrdDados.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GrdDados.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = GrdDados.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = GrdDados.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    GrdDados.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
                DesabilitaHabilitaCampos();
            }
        }


        protected void ExportPdf(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            LimparCamposPesquisa();
            CarregaGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

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
           

        }

        protected void GrdDados_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GrdDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDados.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }
       
        protected void GrdDados_RowDataBound(object sender, GridViewRowEventArgs e)
        { 
            
            

        }
    }
}