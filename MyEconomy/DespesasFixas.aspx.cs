using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class DespesasFixas : System.Web.UI.Page
    {


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

                CarregarContasBancarias();
                CarregarClassificacao();
                CarregaGrid();

            }



        }
        public void CarregaGrid()
        {
            try
            {


                despesasfixasinf.Isdelete = chkinativoPesquisa.Checked;
                despesasfixasinf.DescriaoDespesaFixa = Txtdescricaopesquisa.Text;
                despesasfixasinf.IdClassificacao = Convert.ToInt32(Dropclassificacaopesquisa.SelectedValue);
                despesasfixasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);





                GrdDados.DataSource = objdespesasfixas.PesquisarDespesa(despesasfixasinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarDespesasFixas(string id)
        {
            try
            {


                despesasfixasinf = null;
                foreach (DespesaFixaInformation despesasfixasinf in objdespesasfixas.CarregarDespesaFixascampos(id))
                {
                    Txtid.Text = Convert.ToString(despesasfixasinf.IdDespesaFixa);
                    Txtdescricaodespesa.Text = despesasfixasinf.DescriaoDespesaFixa;
                    Txtvalor.Text = Convert.ToString(despesasfixasinf.ValorDespesaFixa);
                    Txtvalortotal.Text = Convert.ToString(despesasfixasinf.ValorTotalDespesaFixa);
                    Dropcontasbancarias.SelectedValue = Convert.ToString(despesasfixasinf.IdContasBancarias);
                    Dropclassificacao.SelectedValue = Convert.ToString(despesasfixasinf.IdClassificacao);


                    //DateTime datateste = contasinf.DataVencimentoContas;
                    //string teste = datateste.ToString("yyyy-MM-dd");
                    Txtdatavencimento.Text = despesasfixasinf.DataVencimentoDespesaFixa.ToString("yyyy-MM-dd");
                    Txtparcelas.Text = Convert.ToString(despesasfixasinf.QuantParcelasDespesaFixa);


                    Chkinativo.Checked = despesasfixasinf.Isdelete;

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
        public void InserirContasAPagar(DespesaFixaInformation _contasinf)
        {
            ContasAPagarInformation contasapagarinf = new ContasAPagarInformation();

            DateTime dataatual = DateTime.Now.Date;


            for (int i = 0; i < _contasinf.QuantParcelasDespesaFixa; i++)
            {
                contasapagarinf.IdDespesaFixa = _contasinf.IdDespesaFixa;
                contasapagarinf.DataVencimentoContasAPagar = _contasinf.DataVencimentoDespesaFixa.AddMonths(i);
                contasapagarinf.NParcelaContasAPagar = i + 1;
                contasapagarinf.StatusContasAPagar = EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasAPagar));
                objcontaapagar.InserirContasAPagar(contasapagarinf);

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
            Txtdescricaodespesa.Text = "";

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
                despesasfixasinf.DescriaoDespesaFixa = Txtdescricaodespesa.Text;
                despesasfixasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                despesasfixasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                despesasfixasinf.ValorDespesaFixa = Convert.ToDecimal(Txtvalor.Text);
                despesasfixasinf.DataVencimentoDespesaFixa = Convert.ToDateTime(Txtdatavencimento.Text);
                despesasfixasinf.QuantParcelasDespesaFixa = Convert.ToInt32(Txtparcelas.Text);
                despesasfixasinf.ValorTotalDespesaFixa = despesasfixasinf.ValorDespesaFixa * despesasfixasinf.QuantParcelasDespesaFixa;
                despesasfixasinf.QuantParcelasaPagarDespesaFixa = Convert.ToInt32(Txtparcelas.Text);
                despesasfixasinf.Isdelete = Chkinativo.Checked;
                objdespesasfixas.InserirDespesaFixa(despesasfixasinf);
              
                InserirContasAPagar(despesasfixasinf);
                Txtid.Text = despesasfixasinf.IdDespesaFixa.ToString();
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {

                despesasfixasinf.IdDespesaFixa = Convert.ToInt32(Txtid.Text);
                despesasfixasinf.DescriaoDespesaFixa = Txtdescricaodespesa.Text;
                despesasfixasinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                despesasfixasinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);

                despesasfixasinf.ValorDespesaFixa = Convert.ToDecimal(Txtvalor.Text);
                despesasfixasinf.DataVencimentoDespesaFixa = Convert.ToDateTime(Txtdatavencimento.Text);
                despesasfixasinf.QuantParcelasaPagarDespesaFixa = Convert.ToInt32(Txtparcelas.Text);
                despesasfixasinf.ValorTotalDespesaFixa = despesasfixasinf.ValorDespesaFixa * despesasfixasinf.QuantParcelasDespesaFixa;

                despesasfixasinf.Isdelete = Chkinativo.Checked;

                objdespesasfixas.AlterarDespesaFixa(despesasfixasinf);

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

                CarregarDespesasFixas(e.CommandArgument.ToString());

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