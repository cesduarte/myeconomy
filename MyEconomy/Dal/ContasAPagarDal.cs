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

        public DataSet PesquisarContasAPagar(ContasAPagarInformation contasapagarInf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaContaAPagar";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricaoconta", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoconta"].Value = contasapagarInf.DescriaoDespesaFixa;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = contasapagarInf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = contasapagarInf.IdClassificacao;

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = contasapagarInf.DataVencimentoInicialDespesaFixa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = contasapagarInf.DataVencimentoFinalDespesaFixa;
                objCommand.Parameters.Add(pdatafinal);





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


        public List<ContasAPagarInformation> CarregarContasAPagar(string IdContasAPagar)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdContasAPagar == "")
                {
                    sql = "";
                }
                else
                {
                    sql = "select  a.Descricaodespesa, a.Idcontasbancarias, a.Idclassificacao, a.ValorDespesa, b.IdContaAPagar, b.DataVencimentoContaAPagar, b.StatusContasAPagar  from tbl_despesafixa a , tbl_contasapagar b where isdelete = false and b.Iddespesas = a.IdDespesaFixa and b.IdContaAPagar =  " + IdContasAPagar;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ContasAPagarInformation> ListaDeDados = new List<ContasAPagarInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new ContasAPagarInformation()
                    {


                        IdContasAPagar = int.Parse(dataRow["IdContaAPagar"].ToString()),
                        DescriaoDespesaFixa = dataRow["Descricaodespesa"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                        ValorDespesaFixa = Convert.ToDecimal(dataRow["ValorDespesa"].ToString()),

                        DataVencimentoContasAPagar = Convert.ToDateTime(dataRow["DataVencimentoContaAPagar"].ToString()),
                        StatusContasAPagar = dataRow["StatusContasAPagar"].ToString()
                    }) ; 
                }


                return ListaDeDados;



            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                objConexao.Close();
            }
        }
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

                MySqlParameter pidcontas = new MySqlParameter("_IdDespesa", MySqlDbType.Int32);
                pidcontas.Value = contasapagarInf.IdDespesaFixa;
                objCommand.Parameters.Add(pidcontas);



                MySqlParameter pdatavencimentocontasapagar = new MySqlParameter("_datavencimentocontasapagar", MySqlDbType.DateTime, 200);
                pdatavencimentocontasapagar.Value = contasapagarInf.DataVencimentoContasAPagar;
                objCommand.Parameters.Add(pdatavencimentocontasapagar);



                MySqlParameter pnparcelacontasapagar = new MySqlParameter("_nparcelacontasapagar", MySqlDbType.Int32, 200);
                pnparcelacontasapagar.Value = contasapagarInf.NParcelaContasAPagar;
                objCommand.Parameters.Add(pnparcelacontasapagar);


                MySqlParameter pstatuscontaapagar = new MySqlParameter("_statuscontaapagar", MySqlDbType.VarChar, 200);
                pstatuscontaapagar.Value = contasapagarInf.StatusContasAPagar;
                objCommand.Parameters.Add(pstatuscontaapagar);









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