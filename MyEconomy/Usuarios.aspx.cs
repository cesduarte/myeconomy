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
        public void CarregaGrid()
        {

            usuario.Isdelete = chkinativoPesquisa.Checked;
            usuario.Descricao = Txtdescricaopesquisa.Text;
            GrdDados.DataSource = obj.PesquisarUsuarios(usuario);
            GrdDados.DataBind();

        }










        protected void btnsalvar_Click(object sender, EventArgs e)
        {

          


            //if (Txtid.Text == "")
            //{
            //    usuario.Descricao = Txtdescricao.Text;
            //    usuario.Senha = Txtsenha.Text;
            //    usuario.Email = txtemail.Text;
            //    usuario.Isdelete = chkinativo.Checked;
            //    usuario.TrocarSenha = true;
            //    obj.InserirUsuarios(usuario);
                


            //}
            //else
            //{
            //    usuario.Id = Convert.ToInt32(Txtid.Text);
            //    usuario.Descricao = Txtdescricao.Text;
            //    usuario.Senha = Txtsenha.Text;
            //    usuario.Email = txtemail.Text;
            //    usuario.Isdelete = chkinativo.Checked;
            //    usuario.TrocarSenha = true;

            //}
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
                usuario.Senha = Txtsenha.Text;
                usuario.Email = Txtemail.Text;
                usuario.Isdelete = Chkinativo.Checked;
                usuario.TrocarSenha = true;
                obj.InserirUsuarios(usuario);
                



            }
            else
            {
                usuario.Id = Convert.ToInt32(Txtid.Text);
                usuario.Descricao = Txtdescricao.Text;
                usuario.Senha = Txtsenha.Text;
                usuario.Email = Txtemail.Text;
                usuario.Isdelete = Chkinativo.Checked;
                usuario.TrocarSenha = true;

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            LimparCampos();
            CarregaGrid();
        }
    }
}