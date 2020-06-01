using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class InvestimentoManualDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();

        public DataSet PesquisarInvestimento(InvestimentoManualInformation investimentosinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaInvestimentoManual";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoinvestimento"].Value = investimentosinf.DescricaoInvestimento;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = investimentosinf.IdContasBancarias;


                objCommand.Parameters.Add(new MySqlParameter("_idinvestimento", MySqlDbType.Int32));
                objCommand.Parameters["_idinvestimento"].Value = investimentosinf.IdInvestimento;


                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = investimentosinf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = investimentosinf.DataFinalPesquisa;
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

        public List<InvestimentoManualInformation> Carregarinvestimentoscampos(string IdInvestimentoManual)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdInvestimentoManual == "")
                {
                    sql = "select * from tbl_investimentomanual where isdelete = false order by descricaoinvestimento";
                }
                else
                {
                    sql = "select * from tbl_investimentomanual  where IdInvestimentoManual = " + IdInvestimentoManual;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<InvestimentoManualInformation> ListaDeDados = new List<InvestimentoManualInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new InvestimentoManualInformation()
                    {
                        IdinvestimentoManual = int.Parse(dataRow["IdInvestimentoManual"].ToString()),
                        DescricaoInvestimento = dataRow["Descricaoinvestimento"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdInvestimento = Convert.ToInt32(dataRow["Idinvestimento"].ToString()),
                        SaldoInvestimento = Convert.ToDecimal(dataRow["valorinvestimento"].ToString()),
                        DataInvestimento = Convert.ToDateTime(dataRow["DataInvestimento"].ToString()),

                    });
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
        public void InserirInvestimento(InvestimentoManualInformation investimentosinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirInvestimentoManual";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdinvestimentoManual", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 200);
                pdescricao.Value = investimentosinf.DescricaoInvestimento;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = investimentosinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = investimentosinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);



                MySqlParameter psaldoinvestimento = new MySqlParameter("_valorinvestimento", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = investimentosinf.SaldoInvestimento;
                objCommand.Parameters.Add(psaldoinvestimento);




                MySqlParameter pdatainvestimento = new MySqlParameter("_datainvestimento", MySqlDbType.Datetime, 200);
                pdatainvestimento.Value = investimentosinf.DataInvestimento;
                objCommand.Parameters.Add(pdatainvestimento);




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_IdinvestimentoManual"].Value;


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

        public void AlterarInvestimento(InvestimentoManualInformation investimentosinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarInvestimentoManual";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdinvestimentoManual", MySqlDbType.Int32);
                pid.Value = investimentosinf.IdinvestimentoManual;
                objCommand.Parameters.Add(pid);

                MySqlParameter pdescricao = new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 200);
                pdescricao.Value = investimentosinf.DescricaoInvestimento;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = investimentosinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = investimentosinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);



                MySqlParameter psaldoinvestimento = new MySqlParameter("_valorinvestimento", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = investimentosinf.SaldoInvestimento;
                objCommand.Parameters.Add(psaldoinvestimento);




                MySqlParameter pdatainvestimento = new MySqlParameter("_datainvestimento", MySqlDbType.Datetime, 200);
                pdatainvestimento.Value = investimentosinf.DataInvestimento;
                objCommand.Parameters.Add(pdatainvestimento);

                objConexao.Open();
                objCommand.ExecuteNonQuery();
                //usuario.Id = (Int32)objCommand.Parameters["id"].Value;

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