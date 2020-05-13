using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ClassificacaoDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarClassificacao(ClassificacaoInformation classificacaoinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaClassificacao";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricaoclassificacao", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoclassificacao"].Value = classificacaoinf.DescricaoClassificacao;

               



                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = classificacaoinf.Isdelete;

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


        public List<ClassificacaoInformation> CarregarClassificacao(string IdClassificacao)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdClassificacao == "")
                {
                    sql = "select * from tbl_classificacao where isdelete = false order by DescricaoClassificacao";
                }
                else
                {
                    sql = "select * from tbl_classificacao where Idclassificacao = " + IdClassificacao;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ClassificacaoInformation> ListaDeDados = new List<ClassificacaoInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new ClassificacaoInformation() { 
                    IdClassificacao = int.Parse(dataRow["Idclassificacao"].ToString()), 
                    DescricaoClassificacao = dataRow["DescricaoClassificacao"].ToString(),
                        TipoClassificacao = dataRow["TipoClassificacao"].ToString(),
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





        public void InserirClassificacao(ClassificacaoInformation classificacaoinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirClassificacao";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idclassificacao", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoclassificacao", MySqlDbType.VarChar, 200);
                pdescricao.Value = classificacaoinf.DescricaoClassificacao;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter ptipo = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                ptipo.Value = classificacaoinf.TipoClassificacao;
                objCommand.Parameters.Add(ptipo);




                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = classificacaoinf.Isdelete;
                objCommand.Parameters.Add(pisdelete);




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                classificacaoinf.IdClassificacao = (Int32)objCommand.Parameters["_Idclassificacao"].Value;
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

        public void AlterarClassificacao(ClassificacaoInformation classificacaoinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlteraClassificacao";
                objCommand.CommandType = CommandType.StoredProcedure;

               







                MySqlParameter pid = new MySqlParameter("_Idclassificacao", MySqlDbType.Int32);
                pid.Value = classificacaoinf.IdClassificacao;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoclassificacao", MySqlDbType.VarChar, 200);
                pdescricao.Value = classificacaoinf.DescricaoClassificacao;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter ptipo = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                ptipo.Value = classificacaoinf.TipoClassificacao;
                objCommand.Parameters.Add(ptipo);



                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = classificacaoinf.Isdelete;
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