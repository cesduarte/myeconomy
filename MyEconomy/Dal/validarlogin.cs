using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class validarlogin
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();
        public DataSet ValidarLogin(string usuario, string senha)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_ValidarLogin";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_usuario", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_usuario"].Value = usuario;

                objCommand.Parameters.Add(new MySqlParameter("_senha", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_senha"].Value = senha;




            

                MySqlDataAdapter da;

                da = new MySqlDataAdapter(objCommand);
                ds = new DataSet();



                da.Fill(ds);
                return ds;
            }
            catch (MySqlException ex)
            {
                throw new Exception("sqlerro" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objConexao.Close();
            }

        }
    }
}