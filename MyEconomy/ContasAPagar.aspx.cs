using System;
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
                CarregarStatus(DropStatus, new StatusEnum.Status());
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
        public void CarregarConta(string id)
        {
            try
            {


                despesasfixasinf = null;
                foreach (DespesaFixaInformation despesasfixasinf in objdespesasfixas.Carregarcontascampos(id))
                {
                    //Txtid.Text = Convert.ToString(despesasfixasinf.IdDespesaFixa);
                    Txtdescricaoconta.Text = despesasfixasinf.DescriaoDespesaFixa;
                    Txtvalor.Text = Convert.ToString(despesasfixasinf.ValorDespesaFixa);
                    Txtvalorcontaapagar.Text = Convert.ToString(despesasfixasinf.ValorDespesaFixa);
                    Dropcontasbancarias.SelectedValue = Convert.ToString(despesasfixasinf.IdContasBancarias);
                    Dropclassificacao.SelectedValue = Convert.ToString(despesasfixasinf.IdClassificacao);
                    Dropcontasbancariasapagar.SelectedValue = Convert.ToString(despesasfixasinf.IdContasBancarias);
                    
                    Txtdatavencimento.Text = despesasfixasinf.DataVencimentoDespesaFixa.ToString("yyyy-MM-dd");
               

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
        public void InserirContasAPagar(DespesaFixaInformation despesasfixasinf)
        {
            ContasAPagarInformation contasapagarinf = new ContasAPagarInformation();

            DateTime dataatual = DateTime.Now.Date;


            for (int i = 0; i < despesasfixasinf.QuantParcelasDespesaFixa; i++)
            {
                //contasapagarinf.IdContas = _contasinf.IdContas;
                //contasapagarinf.DataVencimentoContasAPagar = _contasinf.DataVencimentoContas.AddMonths(i);
                //contasapagarinf.NParcelaContasAPagar = i + 1;
                //objcontaapagar.InserirContas(contasapagarinf);

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
            DropStatus.SelectedIndex = 0;

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
            //if (Txtid.Text == "")
            //{
            //    contasinf.DescriaoContas = Txtdescricaoconta.Text;
            //    contasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
            //    contasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

            //    contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
            //    contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
            //    contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);
            //    contasinf.ValorTotalContas = contasinf.ValorContas * contasinf.QuantParcelasContas;
            //    contasinf.QuantParcelasaPagarContas = Convert.ToInt32(Txtparcelas.Text);
            //    contasinf.Isdelete = Chkinativo.Checked;
            //    objconta.InserirContas(contasinf);
            //    Txtid.Text = contasinf.IdContas.ToString();
            //    InserirContasAPagar(contasinf);

            //    Label9.Text = "Registro incluido com sucesso";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
            //    Timer1.Enabled = true;

            //}
            //else
            //{

            //    contasinf.IdContas = Convert.ToInt32(Txtid.Text);
            //    contasinf.DescriaoContas = Txtdescricaoconta.Text;
            //    contasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
            //    contasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

            //    contasinf.ValorContas = Convert.ToDecimal(Txtvalor.Text);
            //    contasinf.DataVencimentoContas = Convert.ToDateTime(Txtdatavencimento.Text);
            //    contasinf.QuantParcelasContas = Convert.ToInt32(Txtparcelas.Text);
            //    contasinf.ValorTotalContas = contasinf.ValorContas * contasinf.QuantParcelasContas;

            //    contasinf.Isdelete = Chkinativo.Checked;

            //    objconta.AlterarContas(contasinf);

            //    Label9.Text = "Registro alterado com sucesso!";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
            //    Timer1.Enabled = true;

            //}
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