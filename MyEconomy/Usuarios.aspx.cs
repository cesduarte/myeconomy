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
        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricao.Text = "";
            Txtsenha.Text = "";
            txtemail.Text = "";
            chkinativo.Checked = false;
            
        }
        public void CarregaGrid()
        {

            usuario.Isdelete =  chkinativoPesquisa.Checked;
            usuario.Descricao = TxtdescricaoPesquisa.Text;
            GrdDados.DataSource = obj.PesquisarUsuarios(usuario);
            GrdDados.DataBind();
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        protected void GrdDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnsalvar_Click(object sender, EventArgs e)
        {

          


            if (Txtid.Text == "")
            {
                usuario.Descricao = Txtdescricao.Text;
                usuario.Senha = Txtsenha.Text;
                usuario.Email = txtemail.Text;
                usuario.Isdelete = chkinativo.Checked;
                usuario.TrocarSenha = true;
                obj.InserirUsuarios(usuario);
                


            }
            else
            {
                usuario.Id = Convert.ToInt32(Txtid.Text);
                usuario.Descricao = Txtdescricao.Text;
                usuario.Senha = Txtsenha.Text;
                usuario.Email = txtemail.Text;
                usuario.Isdelete = chkinativo.Checked;
                usuario.TrocarSenha = true;

            }
        }
    }
}