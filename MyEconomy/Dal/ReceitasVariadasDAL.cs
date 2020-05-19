using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy.Dal
{
    public class ReceitasVariadasDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarReceitas(DespesasVariadasInformation despesasinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaReceitas";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaoreceitas", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoreceitas"].Value = despesasinf.DescricaoDespesaVariada;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = despesasinf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = despesasinf.IdClassificacao;







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


        public List<ReceitasVariadasInformation> CarregarDespesaVariadascampos(string IdReceitas)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdReceitas == "")
                {
                    sql = "";
                }
                else
                {
                    sql = "select * from tbl_receitasvariadas where IdReceitas = " + IdReceitas;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ReceitasVariadasInformation> ListaDeDados = new List<ReceitasVariadasInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new ReceitasVariadasInformation()
                    {
                        IdReceitaVariada = int.Parse(dataRow["IdReceitas"].ToString()),
                        DescricaoReceitaVariada = dataRow["Descricaoreceitas"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                        ValorReceita = Convert.ToDecimal(dataRow["ValorReceitas"].ToString()),
                        DataReceitaVariada = Convert.ToDateTime(dataRow["DataReceita"].ToString())

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





        public void InserirReceitas(ReceitasVariadasInformation receitasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirReceitas";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdReceitavariada", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoreceitasvariadas", MySqlDbType.VarChar, 200);
                pdescricao.Value = receitasinf.DescricaoReceitaVariada;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = receitasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);


                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = receitasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);



                MySqlParameter pvalor = new MySqlParameter("_valorreceitavariada", MySqlDbType.Decimal, 200);
                pvalor.Value = receitasinf.ValorReceita;
                objCommand.Parameters.Add(pvalor);



                MySqlParameter pdata = new MySqlParameter("_datareceitavariada", MySqlDbType.DateTime, 200);
                pdata.Value = receitasinf.DataReceitaVariada;
                objCommand.Parameters.Add(pdata);






                objConexao.Open();
                objCommand.ExecuteNonQuery();
                receitasinf.IdReceitaVariada = (Int32)objCommand.Parameters["_IdReceitavariada"].Value;


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

        public void AlterarDespesaVariadas(ReceitasVariadasInformation receitasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarreceitaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdReceitavariada", MySqlDbType.Int32);
                pid.Value = receitasinf.IdReceitaVariada;
                objCommand.Parameters.Add(pid);




                MySqlParameter pdescricao = new MySqlParameter("_descricaoreceitasvariadas", MySqlDbType.VarChar, 200);
                pdescricao.Value = receitasinf.DescricaoReceitaVariada;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = receitasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);


                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = receitasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);



                MySqlParameter pvalor = new MySqlParameter("_valorreceitavariada", MySqlDbType.Decimal, 200);
                pvalor.Value = receitasinf.ValorReceita;
                objCommand.Parameters.Add(pvalor);



                MySqlParameter pdata = new MySqlParameter("_datareceitavariada", MySqlDbType.DateTime, 200);
                pdata.Value = receitasinf.DataReceitaVariada;
                objCommand.Parameters.Add(pdata);

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



        public void ExcluirReceitasVariadas(int idDespesaVariada)
        {

            try
            {
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_excluirDespesaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdReceitasVariada", MySqlDbType.Int32);
                pid.Value = idDespesaVariada;
                objCommand.Parameters.Add(pid);

                objConexao.Open();

                int resultado = objCommand.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("não foi possivel excluir o extrato" + idDespesaVariada);
                }
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