﻿using MySql.Data.MySqlClient;
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
                objCommand.Parameters.Add(new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaodespesa"].Value = contasapagarInf.DescriaoDespesaFixa;



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

                MySqlParameter pstatuscontaapagar = new MySqlParameter("_statuscontaapagar", MySqlDbType.VarChar, 200);
                pstatuscontaapagar.Value = contasapagarInf.StatusContasAPagar;
                objCommand.Parameters.Add(pstatuscontaapagar);




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
        public DataSet PesquisarContasPagas(ContasAPagarInformation contasapagarInf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaContaPaga";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaodespesa"].Value = contasapagarInf.DescriaoDespesaFixa;



                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancariaspagamento", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancariaspagamento"].Value = contasapagarInf.IdContaBancariaPagamentoContasAPagar;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = contasapagarInf.IdClassificacao;

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = contasapagarInf.DataVencimentoInicialDespesaFixa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = contasapagarInf.DataVencimentoFinalDespesaFixa;
                objCommand.Parameters.Add(pdatafinal);

                MySqlParameter pstatuscontaapagar = new MySqlParameter("_statuscontaapagar", MySqlDbType.VarChar, 200);
                pstatuscontaapagar.Value = contasapagarInf.StatusContasAPagar;
                objCommand.Parameters.Add(pstatuscontaapagar);




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
                    sql = "select a.IdDespesaFixa, a.Descricaodespesa, a.Idcontasbancarias, a.Idclassificacao, a.ValorDespesa, a.idinvestimento, b.IdContaAPagar, b.DataVencimentoContaAPagar, b.StatusContasAPagar, b.IdContaBancariaPagamento, b.ValorPagamento, b.DataPagamento, b.NParcelasContaAPagar from tbl_despesafixa a , tbl_contasapagar b where isdelete = false and b.Iddespesas = a.IdDespesaFixa and b.IdContaAPagar =  " + IdContasAPagar;
                }



                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<ContasAPagarInformation> ListaDeDados = new List<ContasAPagarInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    if (dataRow["StatusContasAPagar"].ToString() == EnumExtensions.GetEnumDescription((StatusEnum.Status.ContasPagas)))
                    {
                        ListaDeDados.Add(new ContasAPagarInformation()
                        {

                            IdDespesaFixa = int.Parse(dataRow["IdDespesaFixa"].ToString()),
                            IdContasAPagar = int.Parse(dataRow["IdContaAPagar"].ToString()),
                            DescriaoDespesaFixa = dataRow["Descricaodespesa"].ToString(),
                            IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                            IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                            IdInvestimento = Convert.ToInt32(dataRow["Idinvestimento"].ToString()),
                            NParcelaContasAPagar = dataRow["NParcelasContaAPagar"].ToString(),
                            ValorDespesaFixa = Convert.ToDecimal(dataRow["ValorDespesa"].ToString()),
                            DataVencimentoContasAPagar = Convert.ToDateTime(dataRow["DataVencimentoContaAPagar"].ToString()),
                            StatusContasAPagar = dataRow["StatusContasAPagar"].ToString(),
                            IdContaBancariaPagamentoContasAPagar = Convert.ToInt32(dataRow["IdContaBancariaPagamento"].ToString()),
                            ValorPagamentoContasAPagar = Convert.ToDecimal(dataRow["ValorPagamento"].ToString()),
                            DataPagamentoContasAPagar = Convert.ToDateTime(dataRow["DataPagamento"].ToString()),


                        });
                    }
                    else
                    {

                        ListaDeDados.Add(new ContasAPagarInformation()
                        {

                            IdDespesaFixa = int.Parse(dataRow["IdDespesaFixa"].ToString()),
                            IdContasAPagar = int.Parse(dataRow["IdContaAPagar"].ToString()),
                            DescriaoDespesaFixa = dataRow["Descricaodespesa"].ToString(),
                            IdContasBancarias = Convert.ToInt32(dataRow["Idcontasbancarias"].ToString()),
                            IdClassificacao = Convert.ToInt32(dataRow["Idclassificacao"].ToString()),
                            IdInvestimento = Convert.ToInt32(dataRow["Idinvestimento"].ToString()),
                            ValorDespesaFixa = Convert.ToDecimal(dataRow["ValorDespesa"].ToString()),
                            NParcelaContasAPagar = dataRow["NParcelasContaAPagar"].ToString(),
                            DataVencimentoContasAPagar = Convert.ToDateTime(dataRow["DataVencimentoContaAPagar"].ToString()),
                            StatusContasAPagar = dataRow["StatusContasAPagar"].ToString()


                        });
                    }
                    

                   
                    
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
        public void InserirContasAPagar(ContasAPagarInformation contasapagarInf)
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



                MySqlParameter pnparcelacontasapagar = new MySqlParameter("_nparcelacontasapagar", MySqlDbType.VarChar, 200);
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

        public void AlterarContasAPagar(ContasAPagarInformation contasapagarInf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlteraContasAPagarPagamento";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdContaAPagar", MySqlDbType.Int32);
                pid.Value =contasapagarInf.IdContasAPagar;
                objCommand.Parameters.Add(pid);







                MySqlParameter pidcontabancariapagamento = new MySqlParameter("_idContaBancariaPagamento", MySqlDbType.Int32);
                pidcontabancariapagamento.Value = contasapagarInf.IdContaBancariaPagamentoContasAPagar;
                objCommand.Parameters.Add(pidcontabancariapagamento);

                MySqlParameter pvalorpagamento = new MySqlParameter("_valorpagamento", MySqlDbType.Decimal);
                pvalorpagamento.Value = contasapagarInf.ValorPagamentoContasAPagar;
                objCommand.Parameters.Add(pvalorpagamento);



                MySqlParameter pdatapagamento = new MySqlParameter("_datapagamento", MySqlDbType.DateTime);
                pdatapagamento.Value = contasapagarInf.DataPagamentoContasAPagar;
                objCommand.Parameters.Add(pdatapagamento);


                MySqlParameter pdescricao = new MySqlParameter("_descricaodespesa", MySqlDbType.VarChar, 200);
                pdescricao.Value = contasapagarInf.DescriaoDespesaFixa;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = contasapagarInf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pstatuscontaapagar = new MySqlParameter("_statuscontaapagar", MySqlDbType.VarChar, 200);
                pstatuscontaapagar.Value = contasapagarInf.StatusContasAPagar;
                objCommand.Parameters.Add(pstatuscontaapagar);
                
                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.DespesasFixas));
                objCommand.Parameters.Add(pstatusocorrencia);

                MySqlParameter ptipoclassificacao = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                ptipoclassificacao.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoClassificacao.Despesas));
                objCommand.Parameters.Add(ptipoclassificacao);





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