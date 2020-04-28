using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEconomy
{
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuariosInformation usuario = new UsuariosInformation();
        UsuariosDAL obj = new UsuariosDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregaGrid();
            }
            
        }


        public void CarregaGrid()
        {

            usuario.Isdelete = chkinativoPesquisa.Checked;
            usuario.Descricao = Txtdescricaopesquisa.Text;
            usuario.Usuario = Txtusuariopesquisa.Text;
            GrdDados.DataSource = obj.PesquisarUsuarios(usuario);
            GrdDados.DataBind();

        }

        private void CarregaUsuarios(string id)
        {
            usuario = null;
            foreach (UsuariosInformation usuario in obj.CarregarUsuariosCampos(id))
            {
                Txtid.Text = Convert.ToString(usuario.Id);
                Txtdescricao.Text = usuario.Descricao;
                Txtusuario.Text = usuario.Usuario;
                Txtsenha.Text = usuario.Senha;
                Txtemail.Text = usuario.Email;
                Chkinativo.Checked = usuario.Isdelete;

            }
        }
      
        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricao.Text = "";
            Txtusuario.Text = "";
            Txtsenha.Text = "";
            Txtemail.Text = "";
            Chkinativo.Checked = false;

        }


        public void LimparCamposPesquisa()
        {
            Txtdescricaopesquisa.Text = "";
            Txtusuariopesquisa.Text = "";
            chkinativoPesquisa.Checked = false;

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
                usuario.Descricao = Txtdescricao.Text;
                usuario.Usuario = Txtusuario.Text;
                usuario.Senha = Txtsenha.Text;
                usuario.Email = Txtemail.Text;
                usuario.Isdelete = Chkinativo.Checked;
                usuario.TrocarSenha = true;
                obj.InserirUsuarios(usuario);
                //SuccessPanel.Visible = true;


                //Button2.Attributes.Add("onclick", "return confirm('teste')");
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;




            }
            else
            {
                usuario.Id = Convert.ToInt32(Txtid.Text);
                usuario.Descricao = Txtdescricao.Text;
                usuario.Usuario = Txtusuario.Text;
                usuario.Senha = Txtsenha.Text;
                usuario.Email = Txtemail.Text;
                usuario.Isdelete = Chkinativo.Checked;
                usuario.TrocarSenha = true;

                obj.AlterarUsuarios(usuario);
                Label9.Text = "Registro alterado com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregaGrid();
        }

        protected void GrdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string IdUsuarios = e.CommandArgument.ToString();

            CarregaUsuarios(IdUsuarios);

           ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadastroModal').modal('show');", true);

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('hide');", true);
            Timer1.Enabled = false;
        }
    }
}