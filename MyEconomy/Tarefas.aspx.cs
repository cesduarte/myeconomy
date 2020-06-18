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
    public partial class Tarefas : paginaBase
    {
        UsuariosInformation usuario = new UsuariosInformation();        
        UsuariosDAL objUsuario = new UsuariosDAL();

        TarefasInformation tarefasinf = new TarefasInformation();
        TarefaDAL objtarefa = new TarefaDAL();
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarStatus(Dropstatustarefapesquisa, new StatusEnum.StatusTarefa());
                CarregarUsuario();
                carrega_data();

                CarregaGrid();

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
        public void CarregaGrid()
        {
            try
            {

                tarefasinf.DescricaoTarefa = Txtdescricaopesquisa.Text;
                tarefasinf.IdUsuario = Convert.ToInt32(Dropusuariopesquisa.SelectedValue);

                tarefasinf.DataInicialPesquisa = Convert.ToDateTime(Txtdatainicialpesquisa.Text);
                tarefasinf.DataFinalPesquisa = Convert.ToDateTime(Txtdatafinalpesquisa.Text);
                tarefasinf.StatusOcorrencia = Dropstatustarefapesquisa.SelectedItem.ToString();

                GrdDados.DataSource = objtarefa.PesquisarTarefas(tarefasinf);
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

        public void CarregarTarefas(string id)
        {
            try
            {


                tarefasinf = null;
                foreach (TarefasInformation tarefasinf in objtarefa.CarregarTarefasCampos(id))
                {
                    Txtid.Text = Convert.ToString(tarefasinf.IdTarefa);
                    Txtdescricao.Text = tarefasinf.DescricaoTarefa;
                    Txtdata.Text = tarefasinf.DataTarefa.ToString("yyyy-MM-dd");
                    txtobs.Text = tarefasinf.ObsTarefa;
                    Dropusuario.SelectedValue = Convert.ToString(tarefasinf.IdUsuario);



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
            Dropusuariopesquisa.SelectedIndex = 0;
            Dropstatustarefapesquisa.SelectedIndex = 0;
            carrega_data();
           
         
        }

        public void LimparCampos()
        {
            Txtid.Text = "";
            Txtdescricao.Text = "";
            txtobs.Text = "";
            Txtdata.Text = "";
            Dropusuario.SelectedIndex = 0;
            

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


                tarefasinf.DescricaoTarefa = Txtdescricao.Text;
                tarefasinf.IdUsuario = Convert.ToInt32(Dropusuario.SelectedValue);
                tarefasinf.DataTarefa = Convert.ToDateTime(Txtdata.Text);
                tarefasinf.ObsTarefa = txtobs.Text;
                tarefasinf.StatusTarefa = EnumExtensions.GetEnumDescription((StatusEnum.StatusTarefa.afazer));

                objtarefa.InserirTarefa(tarefasinf);
                Txtid.Text = tarefasinf.IdTarefa.ToString();
                
                Label9.Text = "Registro incluido com sucesso";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#CadSucess').modal('show');", true);
                Timer1.Enabled = true;

            }
            else
            {
                tarefasinf.IdTarefa = Convert.ToInt32(Txtid.Text);
                tarefasinf.DescricaoTarefa = Txtdescricao.Text;
                tarefasinf.IdUsuario = Convert.ToInt32(Dropusuario.SelectedValue);
                tarefasinf.DataTarefa = Convert.ToDateTime(Txtdata.Text);
                tarefasinf.ObsTarefa = txtobs.Text;

                objtarefa.AlterarTarefa(tarefasinf);

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
                

                CarregarTarefas(e.CommandArgument.ToString());

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