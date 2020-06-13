using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class TarefaDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarTarefas(TarefasInformation tarefainf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaTarefas";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaotarefa", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaotarefa"].Value = tarefainf.DescricaoTarefa;



            

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = tarefainf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = tarefainf.DataFinalPesquisa;
                objCommand.Parameters.Add(pdatafinal);


                objCommand.Parameters.Add(new MySqlParameter("_statustarefa", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_statustarefa"].Value = tarefainf.StatusTarefa;


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


        public List<TarefasInformation> CarregarTarefasCampos(string IdTarefa)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdTarefa == "")
                {
                    sql = "";
                }
                else
                {
                    sql = "select * from tbl_tarefas where Idreceitavariada = " + IdTarefa;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<TarefasInformation> ListaDeDados = new List<TarefasInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new TarefasInformation()
                    {
                        IdTarefa = int.Parse(dataRow["Idtarefa"].ToString()),
                        DescricaoTarefa = dataRow["Descricaotarefa"].ToString(),
                        //IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        //IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                        DataTarefa = Convert.ToDateTime(dataRow["Datatarefa"].ToString()),
                        ObsTarefa = dataRow["obstarefa"].ToString(),


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





        public void InserirTarefa(TarefasInformation tarefainf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirTarefas";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdTarefa", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaotarefa", MySqlDbType.VarChar, 200);
                pdescricao.Value = tarefainf.DescricaoTarefa;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter pIdusuario = new MySqlParameter("_idusuario", MySqlDbType.Int32);
                pIdusuario.Value = tarefainf.IdUsuario;
                objCommand.Parameters.Add(pIdusuario);

                //MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                //pidcontasbancarias.Value = tarefainf.IdContasBancarias;
                //objCommand.Parameters.Add(pidcontasbancarias);


                //MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                //pidclassificacao.Value = tarefainf.IdClassificacao;
                //objCommand.Parameters.Add(pidclassificacao);


                MySqlParameter pobstarefa = new MySqlParameter("_obstarefa", MySqlDbType.VarChar, 200);
                pobstarefa.Value = tarefainf.ObsTarefa;
                objCommand.Parameters.Add(pobstarefa);




                MySqlParameter pdata = new MySqlParameter("_datatarefa", MySqlDbType.DateTime, 200);
                pdata.Value = tarefainf.DataTarefa;
                objCommand.Parameters.Add(pdata);


                MySqlParameter pstatustarefa = new MySqlParameter("_statustarefa", MySqlDbType.VarChar, 200);
                pstatustarefa.Value = tarefainf.StatusTarefa;
                objCommand.Parameters.Add(pstatustarefa);

               


                objConexao.Open();
                objCommand.ExecuteNonQuery();
                tarefainf.IdTarefa = (Int32)objCommand.Parameters["_IdTarefa"].Value;


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

        public void AlterarTarefa(TarefasInformation tarefainf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarreceitaVariada";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdTarefa", MySqlDbType.Int32);
                pid.Value = tarefainf.IdTarefa;
                objCommand.Parameters.Add(pid);                



                MySqlParameter pdescricao = new MySqlParameter("_descricaotarefa", MySqlDbType.VarChar, 200);
                pdescricao.Value = tarefainf.DescricaoTarefa;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter pIdusuario = new MySqlParameter("_idusuario", MySqlDbType.Int32);
                pIdusuario.Value = tarefainf.IdUsuario;
                objCommand.Parameters.Add(pIdusuario);

                //MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                //pidcontasbancarias.Value = tarefainf.IdContasBancarias;
                //objCommand.Parameters.Add(pidcontasbancarias);


                //MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                //pidclassificacao.Value = tarefainf.IdClassificacao;
                //objCommand.Parameters.Add(pidclassificacao);







                MySqlParameter pdata = new MySqlParameter("_datatarefa", MySqlDbType.DateTime, 200);
                pdata.Value = tarefainf.DataTarefa;
                objCommand.Parameters.Add(pdata);


                MySqlParameter pstatustarefa = new MySqlParameter("_statustarefa", MySqlDbType.VarChar, 200);
                pstatustarefa.Value = tarefainf.StatusTarefa;
                objCommand.Parameters.Add(pstatustarefa);
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