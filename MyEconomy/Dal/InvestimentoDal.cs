using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class InvestimentoDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarInvestimento(InvestimentoInformation investimentosinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaInvestimento";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoinvestimento"].Value = investimentosinf.DescricaoInvestimento;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = investimentosinf.IdContasBancarias;

               





                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = investimentosinf.Isdelete;

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


        public List<InvestimentoInformation> Carregarinvestimentoscampos(string IdInvestimento)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdInvestimento == "")
                {
                    sql = "select * from tbl_investimento where isdelete = false order by descricaocontas";
                }
                else
                {
                    sql = "select * from tbl_investimento  where IdInvestimento = " + IdInvestimento;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<InvestimentoInformation> ListaDeDados = new List<InvestimentoInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new InvestimentoInformation()
                    {
                        IdInvestimento = int.Parse(dataRow["IdInvestimento"].ToString()),
                        DescricaoInvestimento = dataRow["Descricaoinvestimento"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                       
                        SaldoInvestimento = Convert.ToDecimal(dataRow["SaldoInvestimento"].ToString()),
                     
                        Isdelete = Convert.ToBoolean(dataRow["Isdelete"].ToString())
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

        public List<InvestimentoInformation> Carregarinvestimentosdrop(string IdContasBancarias)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdContasBancarias == "")
                {
                    sql = "";
                }
                else
                {
                    sql = "select a.IdInvestimento, a.Descricaoinvestimento  from tbl_investimento a, tbl_contasbancarias b where a.Idcontasbancarias = b.Idcontasbancarias and a.Isdelete = false and b.Idcontasbancarias  = " + IdContasBancarias;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<InvestimentoInformation> ListaDeDados = new List<InvestimentoInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new InvestimentoInformation()
                    {
                        IdInvestimento = int.Parse(dataRow["IdInvestimento"].ToString()),
                        DescricaoInvestimento = dataRow["Descricaoinvestimento"].ToString()
                        
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



        public void InserirInvestimento(InvestimentoInformation investimentosinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirInvestimento";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idinvestimento", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 200);
                pdescricao.Value = investimentosinf.DescricaoInvestimento;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = investimentosinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

              

                MySqlParameter psaldoinvestimento = new MySqlParameter("_saldoinvestimento", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = investimentosinf.SaldoInvestimento;
                objCommand.Parameters.Add(psaldoinvestimento);




                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = investimentosinf.Isdelete;
                objCommand.Parameters.Add(pisdelete);




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_Idinvestimento"].Value;


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

        public void AlterarInvestimento(InvestimentoInformation investimentosinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarInvestimento";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idinvestimento", MySqlDbType.Int32);
                pid.Value = investimentosinf.IdInvestimento;
                objCommand.Parameters.Add(pid);

                MySqlParameter pdescricao = new MySqlParameter("_descricaoinvestimento", MySqlDbType.VarChar, 200);
                pdescricao.Value = investimentosinf.DescricaoInvestimento;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = investimentosinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);



                MySqlParameter psaldoinvestimento = new MySqlParameter("_saldoinvestimento", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = investimentosinf.SaldoInvestimento;
                objCommand.Parameters.Add(psaldoinvestimento);




                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = investimentosinf.Isdelete;
                objCommand.Parameters.Add(pisdelete);

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