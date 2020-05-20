using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class Classificacao : System.Web.UI.Page
    {
        ClassificacaoInformation classificacao = new ClassificacaoInformation();
        ClassificacaoDAL obj = new ClassificacaoDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                CarregarTipo(DropTipo, new StatusEnum.TipoClassificacao());
                CarregaGrid();
            }

        }

        protected void GrdDados_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
        public void CarregaGrid()
        {
            try
            {


                ClassificacaoInformation classificacao = new ClassificacaoInformation();
                
                classificacao.Isdelete = chkinativoPesquisa.Checked;
                classificacao.DescricaoClassificacao = Txtdescricaopesquisa.Text;

                GrdDados.DataSource = obj.PesquisarClassificacao(classificacao);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        public void CarregarTipo(DropDownList ddl, Enum source)
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
        private void Carregaclassificacao(string id)
        {
            try
            {


                classificacao = null;
                foreach (ClassificacaoInformation classificacao in obj.CarregarClassificacao(id,""))
                {
                    Txtid.Text = Convert.ToString(classificacao.IdClassificacao);
                    Txtdescricao.Text = classificacao.DescricaoClassificacao;
                    if (classificacao.TipoClassificacao == EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Investimento)))
                    {
                        DropTipo.SelectedValue = "1";
                    }
                    else
                    {
                        DropTipo.SelectedValue = "2";
                    }


                     
                    Chkinativo.Checked = classificacao.Isdelete;

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public void LimparCamposPesquisa()
        {
            Txtdescricaopesquisa.Text = "";
            chkinativoPesquisa.Checked = false;
        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricao.Text = "";
            DropTipo.SelectedIndex = 0;
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
            try
            {
                if (Txtid.Text == "")
                {
                    classificacao.DescricaoClassificacao = Txtdescricao.Text;
                    classificacao.TipoClassificacao = DropTipo.SelectedItem.ToString();
                    classificacao.Isdelete = Chkinativo.Checked;
                   
                    obj.InserirClassificacao(classificacao);
                    //SuccessPanel.Visible = true;
                    Txtid.Text = classificacao.IdClassificacao.ToString();

                    //Button2.Attributes.Add("onclick", "return confirm('teste')");
                    Label9.Text = "Registro incluido com sucesso";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                    Timer1.Enabled = true;




                }
                else
                {
                    classificacao.IdClassificacao = Convert.ToInt32(Txtid.Text);
                    classificacao.DescricaoClassificacao = Txtdescricao.Text;
                    classificacao.TipoClassificacao = DropTipo.SelectedItem.ToString();
                    classificacao.Isdelete = Chkinativo.Checked;

                    obj.AlterarClassificacao(classificacao);
                    Label9.Text = "Registro alterado com sucesso!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                    Timer1.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregaGrid();
        }

        protected void GrdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
               

                Carregaclassificacao(e.CommandArgument.ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('hide');", true);
            Timer1.Enabled = false;
        }

        protected void GrdDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdDados.PageIndex = e.NewPageIndex;
            CarregaGrid();
        }

        protected void GrdDados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}