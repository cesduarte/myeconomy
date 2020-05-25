using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class RelatorioExtratoAnalitico : System.Web.UI.Page
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
                CarregarStatus(DropTipoOcorrenciaPesquisa, new StatusEnum.TipoOcorrencias());
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

        //public void CarregarInvestimento()
        //{
        //    DropInvestimento.DataSource = null;


        //    DropInvestimento.DataSource = objinvestimento.Carregarinvestimentosdrop(Dropcontasbancarias.SelectedValue);
        //    DropInvestimento.DataTextField = "Descricaoinvestimento";
        //    DropInvestimento.DataValueField = "IdInvestimento";
        //    DropInvestimento.DataBind();



        //}
        public void CarregaGrid()
        {
            try
            {

                ExtratosBancariosInformation extratosinf = new ExtratosBancariosInformation();


                extratosinf.DescricaoExtratoBancario = Txtdescricaopesquisa.Text;
                extratosinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
                extratosinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);

                extratosinf.DataInicialPesquisa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                extratosinf.DataFinalPesquisa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);
                extratosinf.StatusOcorrencia = DropTipoOcorrenciaPesquisa.SelectedItem.ToString();
             
                 
                    GrdDados.DataSource = objextratobancario.RelatorioExtratoAnalitico(extratosinf);

               





                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarExtratosBancarios(string id)
        {
            //try
            //{


            //    contasapagarinf = null;
            //    foreach (ContasAPagarInformation contasapagarinf in objcontaapagar.CarregarContasAPagar(id))
            //    {
            //        Txtid.Text = Convert.ToString(contasapagarinf.IdContasAPagar);
            //        Txtdescricaoconta.Text = contasapagarinf.DescriaoDespesaFixa;
            //        Dropcontasbancarias.SelectedValue = Convert.ToString(contasapagarinf.IdContasBancarias);
            //        Dropclassificacao.SelectedValue = Convert.ToString(contasapagarinf.IdClassificacao);
            //        Txtvalor.Text = Convert.ToString(contasapagarinf.ValorDespesaFixa);
            //        Txtdatavencimento.Text = contasapagarinf.DataVencimentoContasAPagar.ToString("yyyy-MM-dd");
            //        txtStatus.Text = contasapagarinf.StatusContasAPagar;
            //        txtiddespesa.Text = contasapagarinf.IdDespesaFixa.ToString();

            //        if (contasapagarinf.StatusContasAPagar == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas)))
            //        {
            //            Dropcontasbancariasapagar.SelectedValue = Convert.ToString(contasapagarinf.IdContaBancariaPagamentoContasAPagar);
            //            Txtvalorpago.Text = Convert.ToString(contasapagarinf.ValorPagamentoContasAPagar);
            //            txtdatapagamento.Text = contasapagarinf.DataPagamentoContasAPagar.ToString("yyyy-MM-dd");
            //        }
            //        else
            //        {
            //            Dropcontasbancariasapagar.SelectedValue = Convert.ToString(contasapagarinf.IdContasBancarias);
            //            Txtvalorpago.Text = Convert.ToString(contasapagarinf.ValorDespesaFixa);
            //        }

            //        VerificarInvestimento();
            //        if (DropInvestimento.Visible = true && DropInvestimento.Text != "" && contasapagarinf.IdInvestimento != 0)
            //        {
            //            DropInvestimento.SelectedValue = Convert.ToString(contasapagarinf.IdInvestimento);
            //        }


            //    }
            //    DesabilitaHabilitaCampos();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception();
            //}
        }
        public void TrocaContaAPagarFiltro()
        {
            if (DropTipoOcorrenciaPesquisa.SelectedItem.ToString() == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas)))
            {
                Label6.Text = "Descrição Contas Bancárias Pagamento: ";

            }
            else if (DropTipoOcorrenciaPesquisa.SelectedItem.ToString() == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasAPagar)))
            {

                Label6.Text = "Descrição Contas Bancárias: ";

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

        public void InserirInvestimentoExtratoBancario()
        {


            extratosinf.DescricaoExtratoBancario = Txtdescricaoconta.Text;
            extratosinf.IdContasBancarias = Convert.ToInt32(DropInvestimento.SelectedValue);
            extratosinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);
            extratosinf.ValorOcorrencia = Convert.ToDecimal(Txtvalorpago.Text);
            extratosinf.IdOcorrencia = Convert.ToInt32(DropInvestimento.SelectedValue);
            extratosinf.DataOcorrencia = Convert.ToDateTime(txtdatapagamento.Text);
            extratosinf.StatusOcorrencia = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.InvestimentoCredito));
            objextratobancario.InserirExtratoBancario(extratosinf);
        }
        public void DeletarInvestimentoExtratoBancario()
        {
            extratosinf.IdOcorrencia = Convert.ToInt32(DropInvestimento.SelectedValue);
            extratosinf.StatusOcorrencia = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.InvestimentoCredito));
            objextratobancario.ExcluirExtratoBancario(extratosinf);
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
            DropTipoOcorrenciaPesquisa.SelectedIndex = 0;
            TrocaContaAPagarFiltro();

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
            if (e.CommandName == "Editar")
            {


                CarregarExtratosBancarios(e.CommandArgument.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

            }
            else if (e.CommandName == "Abrir")
            {

                CarregarExtratosBancarios(e.CommandArgument.ToString());


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

        protected void DropStatusPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrocaContaAPagarFiltro();
        }
    }
}
