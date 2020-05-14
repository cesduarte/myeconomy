using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class DespesasFixasDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarDespesa(DespesaFixaInformation despesasinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaDespesaFixa";
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.Add(new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaodespesa"].Value = despesasinf.DescriaoDespesaFixa;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = despesasinf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = despesasinf.IdClassificacao;





                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = despesasinf.Isdelete;

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


        public List<DespesaFixaInformation> CarregarDespesaFixascampos(string IdDespesaFixa)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (IdDespesaFixa == "")
                {
                    sql = "select * from tbl_despesafixa where isdelete = false order by descricaocontas";
                }
                else
                {
                    sql = "select * from tbl_despesafixa  where IdDespesaFixa = " + IdDespesaFixa;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<DespesaFixaInformation> ListaDeDados = new List<DespesaFixaInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add(new DespesaFixaInformation()
                    {
                        IdDespesaFixa = int.Parse(dataRow["IdDespesaFixa"].ToString()),
                        DescriaoDespesaFixa = dataRow["Descricaodespesa"].ToString(),
                        IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                        IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                        IdInvestimento = Convert.ToInt32(dataRow["Idinvestimento"].ToString()),
                        ValorDespesaFixa  = Convert.ToDecimal(dataRow["ValorDespesa"].ToString()),
                        ValorTotalDespesaFixa = Convert.ToDecimal(dataRow["ValorTotalDespesa"].ToString()),
                        DataVencimentoDespesaFixa = Convert.ToDateTime(dataRow["DataVencimento"].ToString()),
                        QuantParcelasDespesaFixa = Convert.ToInt32(dataRow["QuantParcelas"].ToString()),
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

        



        public void InserirDespesaFixa(DespesaFixaInformation despesasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirDespesaFixa";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesa", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 200);
                pdescricao.Value = despesasinf.DescriaoDespesaFixa;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = despesasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);


                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = despesasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = despesasinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);

                MySqlParameter pvalorparcela = new MySqlParameter("_valorparceladespesa", MySqlDbType.Decimal, 200);
                pvalorparcela.Value = despesasinf.ValorDespesaFixa;
                objCommand.Parameters.Add(pvalorparcela);

                MySqlParameter pvalortotalparcela = new MySqlParameter("_valortotalparceladespesa", MySqlDbType.Decimal, 200);
                pvalortotalparcela.Value = despesasinf.ValorTotalDespesaFixa;
                objCommand.Parameters.Add(pvalortotalparcela);

                MySqlParameter pdatavencimento = new MySqlParameter("_datavencimento", MySqlDbType.DateTime, 200);
                pdatavencimento.Value = despesasinf.DataVencimentoDespesaFixa;
                objCommand.Parameters.Add(pdatavencimento);

                MySqlParameter pquantparcela = new MySqlParameter("_quantparcela", MySqlDbType.Int32, 200);
                pquantparcela.Value = despesasinf.QuantParcelasDespesaFixa;
                objCommand.Parameters.Add(pquantparcela);

                MySqlParameter pquantparcelaapagar = new MySqlParameter("_quantparcelaapagar", MySqlDbType.Int32, 200);
                pquantparcelaapagar.Value = despesasinf.QuantParcelasaPagarDespesaFixa;
                objCommand.Parameters.Add(pquantparcelaapagar);



                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = despesasinf.Isdelete;
                objCommand.Parameters.Add(pisdelete);




                objConexao.Open();
                objCommand.ExecuteNonQuery();
                despesasinf.IdDespesaFixa = (Int32)objCommand.Parameters["_IdDespesa"].Value;


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

        public void AlterarDespesaFixa(DespesaFixaInformation despesasinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarDespesaFixa";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesa", MySqlDbType.Int32);
                pid.Value = despesasinf.IdDespesaFixa;
                objCommand.Parameters.Add(pid);




                MySqlParameter pdescricao = new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 200);
                pdescricao.Value = despesasinf.DescriaoDespesaFixa;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = despesasinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = despesasinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);
                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = despesasinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);
                MySqlParameter pvalorparcela = new MySqlParameter("_valorparceladespesa", MySqlDbType.Decimal, 200);
                pvalorparcela.Value = despesasinf.ValorDespesaFixa;
                objCommand.Parameters.Add(pvalorparcela);

                MySqlParameter pvalortotalparcela = new MySqlParameter("_valortotalparceladespesa", MySqlDbType.Decimal, 200);
                pvalortotalparcela.Value = despesasinf.ValorTotalDespesaFixa;
                objCommand.Parameters.Add(pvalortotalparcela);

                MySqlParameter pdatavencimento = new MySqlParameter("_datavencimento", MySqlDbType.DateTime, 200);
                pdatavencimento.Value = despesasinf.DataVencimentoDespesaFixa;
                objCommand.Parameters.Add(pdatavencimento);

                MySqlParameter pquantparcela = new MySqlParameter("_quantparcela", MySqlDbType.Int32, 200);
                pquantparcela.Value = despesasinf.QuantParcelasDespesaFixa;
                objCommand.Parameters.Add(pquantparcela);

                MySqlParameter pquantparcelaapagar = new MySqlParameter("_quantparcelaapagar", MySqlDbType.Int32, 200);
                pquantparcelaapagar.Value = despesasinf.QuantParcelasaPagarDespesaFixa;
                objCommand.Parameters.Add(pquantparcelaapagar);

                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = despesasinf.Isdelete;
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

        public void AlterarSaldoDespesasPagas(int IdDespesa, int QuantParcelaPaga)
        {
            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarDespesaFixaQuantParcelas";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdDespesa", MySqlDbType.Int32);
                pid.Value = IdDespesa;
                objCommand.Parameters.Add(pid);




                


                MySqlParameter pidcontasbancarias = new MySqlParameter("_QuantParcela", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = QuantParcelaPaga;
                objCommand.Parameters.Add(pidcontasbancarias);

               

               

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