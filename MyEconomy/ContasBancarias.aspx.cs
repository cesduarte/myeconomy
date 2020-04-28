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
        UsuariosDAL obj = new UsuariosDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregarUsuario();
            }

            carregarUsuario();

        }

        public void carregarUsuario()
        {
            try
            {
             
                
                    Dropusuario.DataSource = null;
                   
                    Dropusuario.DataSource = obj.CarregarUsuariosCampos("");                
                    Dropusuario.DataTextField = "descricao";
                    Dropusuario.DataValueField = "Id";
                    Dropusuario.DataBind();
                

            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void GrdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}