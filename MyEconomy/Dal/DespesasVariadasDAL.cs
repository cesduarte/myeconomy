using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class DespesasVariadasDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarDespesaVariadas(DespesasVariadasInformation despesasinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaDespesasVariadas";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaodespesavariadas", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaodespesavariadas"].Value = despesasinf.DescricaoDespesaVariada;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = despesasinf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = despesasinf.IdClassificacao;



                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = despesasinf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = despesasinf.DataFinalPesquisa;
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


        public List<DespesasVariadasInformation> CarregarDespesaVariadascampos(string IdDespesaVariada)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdDespesaVariada == "")
                {
                    sql = "";
                }
                else
                {
                    sql = "select * from tbl_despesavariada where IdDespesaVariada = " + IdDespesaVariada;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<DespesasVariadasInformation> ListaDeDados = new List<DespesasVariadasInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new DespesasVariadasInformation()
                    {
                        IdDespesaVariada = int.Parse(dataRow["IdDespesaVariada"].ToString()),
                        DescricaoDespesaVariada = dataRow["DescricaodespesaVariada"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),                      
                        ValorDespesaVariada = Convert.ToDecimal(dataRow["ValorDespesaVariada"].ToString()),
                        DataDespesaVariada = Convert.ToDateTime(dataRow["DataDespesaVariada"].ToString())
                        
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





        public void InserirDespesaVariadas(DespesasVariadasInformation despesasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirDespesaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesaVariada", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaodespesavariadas", MySqlDbType.VarChar, 200);
                pdescricao.Value = despesasinf.DescricaoDespesaVariada;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = despesasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);


                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = despesasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                

                MySqlParameter pvalor = new MySqlParameter("_valordespesavariada", MySqlDbType.Decimal, 200);
                pvalor.Value = despesasinf.ValorDespesaVariada;
                objCommand.Parameters.Add(pvalor);

              

                MySqlParameter pdata = new MySqlParameter("_datadespesavariada", MySqlDbType.DateTime, 200);
                pdata.Value = despesasinf.DataDespesaVariada;
                objCommand.Parameters.Add(pdata);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.DespesasVariadas));
                objCommand.Parameters.Add(pstatusocorrencia);




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                despesasinf.IdDespesaVariada = (Int32)objCommand.Parameters["_IdDespesaVariada"].Value;


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

        public void AlterarDespesaVariadas(DespesasVariadasInformation despesasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarDespesaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesaVariada", MySqlDbType.Int32);
                pid.Value = despesasinf.IdDespesaVariada;
                objCommand.Parameters.Add(pid);




                MySqlParameter pdescricao = new MySqlParameter("_descricaodespesavariadas", MySqlDbType.VarChar, 200);
                pdescricao.Value = despesasinf.DescricaoDespesaVariada;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = despesasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);


                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = despesasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);



                MySqlParameter pvalor = new MySqlParameter("_valordespesavariada", MySqlDbType.Decimal, 200);
                pvalor.Value = despesasinf.ValorDespesaVariada;
                objCommand.Parameters.Add(pvalor);



                MySqlParameter pdata = new MySqlParameter("_datadespesavariada", MySqlDbType.DateTime, 200);
                pdata.Value = despesasinf.DataDespesaVariada;
                objCommand.Parameters.Add(pdata);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.DespesasVariadas));
                objCommand.Parameters.Add(pstatusocorrencia);

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



        public void ExcluirDespesaVariadas(int idDespesaVariada)
        {
           
            try
            {
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_excluirDespesaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesaVariada", MySqlDbType.Int32);
                pid.Value = idDespesaVariada;
                objCommand.Parameters.Add(pid);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.DespesasVariadas));
                objCommand.Parameters.Add(pstatusocorrencia);

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