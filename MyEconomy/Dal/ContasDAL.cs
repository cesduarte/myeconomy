using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ContasDAL
    {

        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarContas(ContasInformation contasInf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaConta";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricaoconta", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoconta"].Value = contasInf.DescriaoContas;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = contasInf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = contasInf.IdClassificacao;

               



                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = contasInf.Isdelete;

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
        

        public List<ContasInformation> Carregarcontascampos(string Idcontas)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (Idcontas == "")
                {
                    sql = "select * from tbl_contas where isdelete = false order by descricaocontas";
                }
                else
                {
                    sql = "select * from tbl_contas where Idcontas = " + Idcontas;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ContasInformation> ListaDeDados = new List<ContasInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new ContasInformation() { IdContas = int.Parse(dataRow["Idcontas"].ToString()),
                        DescriaoContas = dataRow["Descricaocontas"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                        ValorContas = Convert.ToDecimal(dataRow["ValorContas"].ToString()),
                        ValorTotalContas = Convert.ToDecimal(dataRow["ValorTotalContas"].ToString()),
                        DataVencimentoContas = Convert.ToDateTime(dataRow["DataVencimento"].ToString()),
                        QuantParcelasContas = Convert.ToInt32(dataRow["QuantParcelas"].ToString()),
                        Isdelete = Convert.ToBoolean(dataRow["Isdelete"].ToString()) });
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





        public void InserirContas(ContasInformation contasInf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirContas";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdConta", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoconta", MySqlDbType.VarChar, 200);
                pdescricao.Value = contasInf.DescriaoContas;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = contasInf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = contasInf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pvalorparcela = new MySqlParameter("_valorparcela", MySqlDbType.Decimal, 200);
                pvalorparcela.Value = contasInf.ValorContas;
                objCommand.Parameters.Add(pvalorparcela);

                MySqlParameter pvalortotalparcela = new MySqlParameter("_valortotalparcela", MySqlDbType.Decimal, 200);
                pvalortotalparcela.Value = contasInf.ValorTotalContas;
                objCommand.Parameters.Add(pvalortotalparcela);

                MySqlParameter pdatavencimento = new MySqlParameter("_datavencimento", MySqlDbType.DateTime, 200);
                pdatavencimento.Value = contasInf.DataVencimentoContas;
                objCommand.Parameters.Add(pdatavencimento);

                MySqlParameter pquantparcela = new MySqlParameter("_quantparcela", MySqlDbType.Int32, 200);
                pquantparcela.Value = contasInf.QuantParcelasContas;
                objCommand.Parameters.Add(pquantparcela);

                MySqlParameter pquantparcelaapagar = new MySqlParameter("_quantparcelaapagar", MySqlDbType.Int32, 200);
                pquantparcelaapagar.Value = contasInf.QuantParcelasaPagarContas;
                objCommand.Parameters.Add(pquantparcelaapagar);



                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = contasInf.Isdelete;
                objCommand.Parameters.Add(pisdelete);

        


                objConexao.Open();
                objCommand.ExecuteNonQuery();
                contasInf.IdContas= (Int32)objCommand.Parameters["_IdConta"].Value;
                

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

        public void AlterarContas(ContasInformation contasInf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarConta";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_idcontas", MySqlDbType.Int32);
                pid.Value = contasInf.IdContas;
                objCommand.Parameters.Add(pid);




                MySqlParameter pdescricao = new MySqlParameter("_descricaoconta", MySqlDbType.VarChar, 200);
                pdescricao.Value = contasInf.DescriaoContas;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = contasInf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = contasInf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pvalorparcela = new MySqlParameter("_valorparcela", MySqlDbType.Decimal, 200);
                pvalorparcela.Value = contasInf.ValorContas;
                objCommand.Parameters.Add(pvalorparcela);

                MySqlParameter pvalortotalparcela = new MySqlParameter("_valortotalparcela", MySqlDbType.Decimal, 200);
                pvalortotalparcela.Value = contasInf.ValorTotalContas;
                objCommand.Parameters.Add(pvalortotalparcela);

                MySqlParameter pdatavencimento = new MySqlParameter("_datavencimento", MySqlDbType.DateTime, 200);
                pdatavencimento.Value = contasInf.DataVencimentoContas;
                objCommand.Parameters.Add(pdatavencimento);

                MySqlParameter pquantparcela = new MySqlParameter("_quantparcela", MySqlDbType.Int32, 200);
                pquantparcela.Value = contasInf.QuantParcelasContas;
                objCommand.Parameters.Add(pquantparcela);




                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = contasInf.Isdelete;
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