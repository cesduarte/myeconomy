using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class ContasBancarias : System.Web.UI.Page
    {
        UsuariosInformation usuario = new UsuariosInformation();
        ContasBancariasInformation ContasBancariasInf = new ContasBancariasInformation();
        UsuariosDAL objUsuario = new UsuariosDAL();
        ContasBancariasDAL objContasBancarias = new ContasBancariasDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarUsuario();
                CarregaGrid();
              
            }

         

        }
        public void CarregaGrid()
        {
            try
            {
                ContasBancariasInf.Isdelete = chkinativoPesquisa.Checked;
                ContasBancariasInf.DescricaoContasBancarias = Txtdescricaopesquisa.Text;
                ContasBancariasInf.IdUsuario= Convert.ToInt32(Dropusuariopesquisa.SelectedValue);

                GrdDados.DataSource = objContasBancarias.PesquisarContasBancarias(ContasBancariasInf);
                GrdDados.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public void CarregarUsuario()
        {
            try
            {
             
                
                    Dropusuario.DataSource = null;
                    Dropusuariopesquisa.DataSource = null;


                    Dropusuario.DataSource = objUsuario.CarregarUsuariosCampos("");                
                    Dropusuario.DataTextField = "descricao";
                    Dropusuario.DataValueField = "IdUsuario";
                    Dropusuario.DataBind();


                Dropusuariopesquisa.DataSource = objUsuario.CarregarUsuariosCampos("");
                Dropusuariopesquisa.DataTextField = "descricao";
                Dropusuariopesquisa.DataValueField = "IdUsuario";
                Dropusuariopesquisa.DataBind();
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public void CarregarContasBancarias(string id)
        {
            try
            {


                ContasBancariasInf = null;
                foreach (ContasBancariasInformation ContasBancariasInf in objContasBancarias.CarregarContasBancariasCampos(id))
                {
                    Txtid.Text = Convert.ToString(ContasBancariasInf.IdContasBancarias);
                    Txtdescricao.Text = ContasBancariasInf.DescricaoContasBancarias;
                    Txtsaldo.Text = Convert.ToString(ContasBancariasInf.SaldoContasBancarias);
                    Dropusuario.SelectedValue = Convert.ToString(ContasBancariasInf.IdUsuario);

                    Chkinativo.Checked = usuario.Isdelete;

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
            Txtsaldo.Text = "";
            Dropusuario.SelectedIndex = 0;
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
            if(Txtid.Text=="")
            {
               

                ContasBancariasInf.DescricaoContasBancarias = Txtdescricao.Text;
                ContasBancariasInf.SaldoContasBancarias = Convert.ToDecimal(Txtsaldo.Text);
                ContasBancariasInf.IdUsuario = Convert.ToInt32(Dropusuario.SelectedValue);
                ContasBancariasInf.Isdelete = Chkinativo.Checked;
                objContasBancarias.InserirUsuarios(ContasBancariasInf);
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {
                ContasBancariasInf.IdContasBancarias = Convert.ToInt32(Txtid.Text);
                ContasBancariasInf.DescricaoContasBancarias = Txtdescricao.Text;
                ContasBancariasInf.SaldoContasBancarias = Convert.ToDecimal(Txtsaldo.Text);
                ContasBancariasInf.IdUsuario = Convert.ToInt32(Dropusuario.SelectedValue);
                ContasBancariasInf.Isdelete = Chkinativo.Checked;
                objContasBancarias.AlterarUsuarios(ContasBancariasInf);

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

                CarregarContasBancarias(IdContasBancárias);

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