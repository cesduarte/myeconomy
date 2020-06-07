using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Linq;



namespace MyEconomy
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            carrega_login();
        }

        public void carrega_login()
        {
            string usuario = Request["txtlogin"];
            string senha = Request["txtsenha"];

            validarlogin validLog = new validarlogin();

            DataSet ds = validLog.ValidarLogin(usuario, senha);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                //lblerro.Text = "Usuário e senha incorretos";
            }
            else
            {
                this.Session["UserID"] = dt.Rows[0]["Idusuario"].ToString();
                this.Session["UserName"] = dt.Rows[0]["Usuario"].ToString();



                Response.Redirect("Default.aspx");



            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            carrega_login();
        }
    }
}