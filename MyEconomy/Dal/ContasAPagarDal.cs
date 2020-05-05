using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;


namespace MyEconomy
{
    public class ContasAPagarDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();
        public void InserirContas(ContasAPagarInformation contasapagarInf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirContasAPagar";
                objCommand.CommandType = CommandType.StoredProcedure;

                //MySqlParameter pid = new MySqlParameter("_IdContaAPagar", MySqlDbType.Int32);
                //pid.Direction = ParameterDirection.Output;
                //objCommand.Parameters.Add(pid);

                MySqlParameter pidcontas = new MySqlParameter("_idcontas", MySqlDbType.Int32);
                pidcontas.Value = contasapagarInf.IdContas;
                objCommand.Parameters.Add(pidcontas);



                MySqlParameter pdatavencimentocontasapagar = new MySqlParameter("_datavencimentocontasapagar", MySqlDbType.DateTime, 200);
                pdatavencimentocontasapagar.Value = contasapagarInf.DataVencimentoContasAPagar;
                objCommand.Parameters.Add(pdatavencimentocontasapagar);



                MySqlParameter pnparcelacontasapagar = new MySqlParameter("_nparcelacontasapagar", MySqlDbType.Int32, 200);
                pnparcelacontasapagar.Value = contasapagarInf.NParcelaContasAPagar;
                objCommand.Parameters.Add(pnparcelacontasapagar);

                



                




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                //usuario.Id = (Int32)objCommand.Parameters["id"].Value;
                objCommand.Parameters.Clear();

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