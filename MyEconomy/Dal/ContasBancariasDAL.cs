using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ContasBancariasDAL
    {

        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarContasBancarias(ContasBancariasInformation ContasBancariasinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaContasBancarias";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricaocontasbancarias", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaocontasbancarias"].Value = ContasBancariasinf.DescricaoContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idusuario", MySqlDbType.Int32));
                objCommand.Parameters["_idusuario"].Value = ContasBancariasinf.IdUsuario;



                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = ContasBancariasinf.Isdelete;

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


        public List<ContasBancariasInformation> CarregarContasBancariasCampos(string IdContasBancarias)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdContasBancarias == "")
                {
                    sql = "select * from tbl_contasBancarias where isdelete = false order by DescricaoContasBancarias";
                }
                else
                {
                    sql = "select * from tbl_contasBancarias where Idcontasbancarias = " + IdContasBancarias;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ContasBancariasInformation> ListaDeDados = new List<ContasBancariasInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new ContasBancariasInformation() { 
                        IdContasBancarias = int.Parse(dataRow["Idcontasbancarias"].ToString()), 
                        DescricaoContasBancarias = dataRow["DescricaoContasBancarias"].ToString(),
                        SaldoContasBancarias = Convert.ToDecimal(dataRow["Saldo"].ToString()), 
                        IdUsuario = Convert.ToInt32(dataRow["Idusuario"].ToString()), 
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





        public void InserirUsuarios(ContasBancariasInformation ContasBancariasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirContasBancarias";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idcontasbancarias", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaocontasbancarias", MySqlDbType.VarChar, 200);
                pdescricao.Value = ContasBancariasinf.DescricaoContasBancarias;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter psaldo = new MySqlParameter("_saldo", MySqlDbType.Decimal, 100);
                psaldo.Value = ContasBancariasinf.SaldoContasBancarias;
                objCommand.Parameters.Add(psaldo);

                MySqlParameter pIdusuario = new MySqlParameter("_idusuario", MySqlDbType.Int32);
                pIdusuario.Value = ContasBancariasinf.IdUsuario;
                objCommand.Parameters.Add(pIdusuario);

                

                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = ContasBancariasinf.Isdelete;
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

        public void AlterarUsuarios(ContasBancariasInformation ContasBancariasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlteraContasBancarias";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idcontasbancarias", MySqlDbType.Int32);
                pid.Value = ContasBancariasinf.IdContasBancarias;
                objCommand.Parameters.Add(pid);



              



                MySqlParameter pdescricao = new MySqlParameter("_descricaocontasbancarias", MySqlDbType.VarChar, 200);
                pdescricao.Value = ContasBancariasinf.DescricaoContasBancarias;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter psaldo = new MySqlParameter("_saldo", MySqlDbType.Decimal);
                psaldo.Value = ContasBancariasinf.SaldoContasBancarias;
                objCommand.Parameters.Add(psaldo);

                MySqlParameter pIdusuario = new MySqlParameter("_idusuario", MySqlDbType.Int32);
                pIdusuario.Value = ContasBancariasinf.IdUsuario;
                objCommand.Parameters.Add(pIdusuario);



                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = ContasBancariasinf.Isdelete;
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