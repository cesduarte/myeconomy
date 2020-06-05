using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class InvestimentoManual : System.Web.UI.Page
    {
        ContasBancariasDAL objcontasbancarias = new ContasBancariasDAL();
        //InvestimentoInformation investimentosinf = new InvestimentoInformation();
        InvestimentoManualInformation investimentosmanualinf = new InvestimentoManualInformation();
        InvestimentoManualDAL objinvestimentos = new InvestimentoManualDAL();
        InvestimentoDAL objinvestimentosfixo = new InvestimentoDAL();
        ClassificacaoDAL objclassificacao = new ClassificacaoDAL();
        Validador validador = new Validador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carrega_data();
                CarregarContasBancarias(); 
                CarregarInvestimento("");
                CarregarClassificacao();
                CarregaGrid();
              
            }



        }
        public void InserirInvestimentoExtratoBancario(Char  Atividade)
        {
            ExtratoBancarioDAL objextratobancario = new ExtratoBancarioDAL();
            ExtratosBancariosInformation extratosinf = new ExtratosBancariosInformation();

            extratosinf.DescricaoExtratoBancario = Txtdescricaoinvestimento.Text;
            extratosinf.IdInvestimento = Convert.ToInt32(Dropinvestimento.SelectedValue);
            extratosinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);
            extratosinf.ValorOcorrencia = Convert.ToDecimal(Txtsaldo.Text);
            extratosinf.TipoClassificacao = EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Investimento));
            extratosinf.DataOcorrencia = Convert.ToDateTime(Txtdata.Text);
            extratosinf.StatusOcorrencia = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.Investimentocredito));
            extratosinf.Idocorrencia = Convert.ToInt32(Txtid.Text);
            if(Atividade == 'I')
            {
                objextratobancario.InserirExtratoBancarioInvestimento(extratosinf);
            }
            else
            {
                objextratobancario.AlterarExtratoBancarioInvestimento(extratosinf);
            }

        }
        public void CarregarClassificacao()
        {
            try
            {


                Dropclassificacao.DataSource = null;
                Dropclassificacaopesquisa.DataSource = null;

                Dropclassificacao.DataSource = objclassificacao.CarregarClassificacao("", EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Investimento)));
                Dropclassificacao.DataTextField = "DescricaoClassificacao";
                Dropclassificacao.DataValueField = "Idclassificacao";
                Dropclassificacao.DataBind();


                Dropclassificacaopesquisa.DataSource = objclassificacao.CarregarClassificacao("", EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Investimento)));
                Dropclassificacaopesquisa.DataTextField = "DescricaoClassificacao";
                Dropclassificacaopesquisa.DataValueField = "Idclassificacao";
                Dropclassificacaopesquisa.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void CarregaGrid()
        {
            try
            {



                investimentosmanualinf.DescricaoInvestimento = Txtdescricaopesquisa.Text;

                investimentosmanualinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancariaspesquisa.SelectedValue);
                investimentosmanualinf.IdInvestimento = Convert.ToInt32(Dropinvestimentopesquisa.SelectedValue);
                investimentosmanualinf.DataInicialPesquisa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                investimentosmanualinf.DataFinalPesquisa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);




                GrdDados.DataSource = objinvestimentos.PesquisarInvestimento(investimentosmanualinf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void carrega_data()
        {
            DateTime abre = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatainicialpesquisa.Text = abre.ToString("yyyy-MM-dd");

            DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Txtdatafinalpesquisa.Text = fecha.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");




        }

        public void CarregarInvestimentoContasbancarias()
        {
            Dropinvestimento.DataSource = null;


            Dropinvestimento.DataSource = objinvestimentosfixo.Carregarinvestimentosdrop(Dropcontasbancarias.SelectedValue);
            Dropinvestimento.DataTextField = "Descricaoinvestimento";
            Dropinvestimento.DataValueField = "IdInvestimento";
            Dropinvestimento.DataBind();



        }
        public void CarregarInvestimentomanual(string id)
        {
            try
            {


                investimentosmanualinf = null;
                foreach (InvestimentoManualInformation investimentosmanualinf in objinvestimentos.Carregarinvestimentoscampos(id))
                {
                    Txtid.Text = Convert.ToString(investimentosmanualinf.IdinvestimentoManual);
                    Txtdescricaoinvestimento.Text = investimentosmanualinf.DescricaoInvestimento;
                    Txtsaldo.Text = Convert.ToString(investimentosmanualinf.SaldoInvestimento);

                    Dropcontasbancarias.SelectedValue = Convert.ToString(investimentosmanualinf.IdContasBancarias);
                    CarregarInvestimentoContasbancarias();
                    Dropinvestimento.SelectedValue = Convert.ToString(investimentosmanualinf.IdInvestimento);
                    Txtdata.Text = investimentosmanualinf.DataInvestimento.ToString("yyyy-MM-dd");





                }
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

                Dropinvestimentopesquisa.DataSource = null;
                Dropinvestimentopesquisa.DataSource = objinvestimentosfixo.Carregarinvestimentoscampos("");
                Dropinvestimentopesquisa.DataTextField = "Descricaoinvestimento";
                Dropinvestimentopesquisa.DataValueField = "Idinvestimento";
                Dropinvestimentopesquisa.DataBind();

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
            carrega_data();

        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricaoinvestimento.Text = "";
            Txtdata.Text = "";
            Dropcontasbancarias.SelectedIndex = 0;

            Txtsaldo.Text = "";

           

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
                investimentosmanualinf.DescricaoInvestimento = Txtdescricaoinvestimento.Text;
                investimentosmanualinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                investimentosmanualinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);
                investimentosmanualinf.IdInvestimento = Convert.ToInt32(Dropinvestimento.SelectedValue);
                investimentosmanualinf.SaldoInvestimento = Convert.ToDecimal(Txtsaldo.Text);
                investimentosmanualinf.DataInvestimento = Convert.ToDateTime(Txtdata.Text);

              
                objinvestimentos.InserirInvestimento(investimentosmanualinf);
               


                Txtid.Text = investimentosmanualinf.IdinvestimentoManual.ToString();
                InserirInvestimentoExtratoBancario('I');
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {

                investimentosmanualinf.IdinvestimentoManual = Convert.ToInt32(Txtid.Text);
                investimentosmanualinf.DescricaoInvestimento = Txtdescricaoinvestimento.Text;
                investimentosmanualinf.IdContasBancarias = Convert.ToInt32(Dropcontasbancarias.SelectedValue);
                investimentosmanualinf.IdClassificacao = Convert.ToInt32(Dropclassificacao.SelectedValue);
                investimentosmanualinf.IdInvestimento = Convert.ToInt32(Dropinvestimento.SelectedValue);
                investimentosmanualinf.SaldoInvestimento = Convert.ToDecimal(Txtsaldo.Text);
                investimentosmanualinf.DataInvestimento = Convert.ToDateTime(Txtdata.Text);


                //objdespesasfixas.AlterarDespesaFixa(despesasfixasinf);
                objinvestimentos.AlterarInvestimento(investimentosmanualinf);
                InserirInvestimentoExtratoBancario('A');
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


               CarregarInvestimentomanual(e.CommandArgument.ToString());

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

        protected void Dropcontasbancarias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarInvestimentoContasbancarias();
        }
    }
}