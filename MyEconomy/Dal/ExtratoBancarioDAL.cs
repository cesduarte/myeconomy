﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class ExtratoBancarioDAL
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();
        public DataSet RelatorioExtratoAnalitico(ExtratosBancariosInformation extratosinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
               

                if(extratosinf.StatusOcorrencia == EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.inicial)))
                {
                    objCommand.CommandText = "Procedure_RelatorioExtratoAnalitico";
                    objCommand.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    objCommand.CommandText = "Procedure_RelatorioExtratoAnaliticoStatus";
                    objCommand.CommandType = CommandType.StoredProcedure;
                    MySqlParameter pstatuscontaapagar = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                    pstatuscontaapagar.Value = extratosinf.StatusOcorrencia;
                    objCommand.Parameters.Add(pstatuscontaapagar);
                }

                objCommand.Parameters.Add(new MySqlParameter("_descricaoocorrencia", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricaoocorrencia"].Value = extratosinf.DescricaoExtratoBancario;

                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = extratosinf.IdContasBancarias;

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = extratosinf.IdClassificacao;

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = extratosinf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = extratosinf.DataFinalPesquisa;
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

        public DataSet RelatorioExtratoTotalizadorContasBancarias(ExtratosBancariosInformation extratosinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;                
                objCommand.CommandText = "Procedure_RelatorioTotalizadorContasBancarias";
                objCommand.CommandType = CommandType.StoredProcedure;
               

                

                objCommand.Parameters.Add(new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32));
                objCommand.Parameters["_idcontasbancarias"].Value = extratosinf.IdContasBancarias;

               

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = extratosinf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = extratosinf.DataFinalPesquisa;
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

        public DataSet RelatorioExtratoTotalizadorClassificacao(ExtratosBancariosInformation extratosinf)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_RelatorioTotalizadorClassificacao";
                objCommand.CommandType = CommandType.StoredProcedure;




                

                objCommand.Parameters.Add(new MySqlParameter("_idclassificacao", MySqlDbType.Int32));
                objCommand.Parameters["_idclassificacao"].Value = extratosinf.IdClassificacao;

                MySqlParameter pdatainicial = new MySqlParameter("_datainicial", MySqlDbType.DateTime, 200);
                pdatainicial.Value = extratosinf.DataInicialPesquisa;
                objCommand.Parameters.Add(pdatainicial);

                MySqlParameter pdatafinal = new MySqlParameter("_datafinal", MySqlDbType.DateTime, 200);
                pdatafinal.Value = extratosinf.DataFinalPesquisa;
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
        public void InserirExtratoBancario(ExtratosBancariosInformation extratobancarioinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirExtratoBancario";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idextratobancario", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoextrato", MySqlDbType.VarChar, 200);
                pdescricao.Value = extratobancarioinf.DescricaoExtratoBancario;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidcontasbancarias = new MySqlParameter("_idcontasbancarias", MySqlDbType.Int32, 200);
                pidcontasbancarias.Value = extratobancarioinf.IdContasBancarias;
                objCommand.Parameters.Add(pidcontasbancarias);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = extratobancarioinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pidOcorrencia = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                pidOcorrencia.Value = extratobancarioinf.TipoClassificacao;
                objCommand.Parameters.Add(pidOcorrencia);

                MySqlParameter psaldoinvestimento = new MySqlParameter("_valorocorrencia", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = extratobancarioinf.ValorOcorrencia;
                objCommand.Parameters.Add(psaldoinvestimento);

                MySqlParameter pdata = new MySqlParameter("_dataocorrencia", MySqlDbType.DateTime, 200);
                pdata.Value = extratobancarioinf.DataOcorrencia;
                objCommand.Parameters.Add(pdata);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = extratobancarioinf.StatusOcorrencia;
                objCommand.Parameters.Add(pstatusocorrencia);





                objConexao.Open();
                objCommand.ExecuteNonQuery();
                //investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_Idinvestimento"].Value;


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


        public void InserirExtratoBancarioInvestimento(ExtratosBancariosInformation extratobancarioinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirExtratoBancarioInvestimento";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idextratobancario", MySqlDbType.Int32);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoextrato", MySqlDbType.VarChar, 200);
                pdescricao.Value = extratobancarioinf.DescricaoExtratoBancario;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = extratobancarioinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = extratobancarioinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pidocorrencia = new MySqlParameter("_idocorrencia", MySqlDbType.Int32, 200);
                pidocorrencia.Value = extratobancarioinf.Idocorrencia;
                objCommand.Parameters.Add(pidocorrencia);

                MySqlParameter pidOcorrencia = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                pidOcorrencia.Value = extratobancarioinf.TipoClassificacao;
                objCommand.Parameters.Add(pidOcorrencia);

                MySqlParameter psaldoinvestimento = new MySqlParameter("_valorocorrencia", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = extratobancarioinf.ValorOcorrencia;
                objCommand.Parameters.Add(psaldoinvestimento);

                MySqlParameter pdata = new MySqlParameter("_dataocorrencia", MySqlDbType.DateTime, 200);
                pdata.Value = extratobancarioinf.DataOcorrencia;
                objCommand.Parameters.Add(pdata);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = extratobancarioinf.StatusOcorrencia;
                objCommand.Parameters.Add(pstatusocorrencia);





                objConexao.Open();
                objCommand.ExecuteNonQuery();
                //investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_Idinvestimento"].Value;


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

        public void AlterarExtratoBancarioInvestimento(ExtratosBancariosInformation extratobancarioinf)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_alterarExtratoBancarioInvestimento";
                objCommand.CommandType = CommandType.StoredProcedure;

                //MySqlParameter pid = new MySqlParameter("_Idextratobancario", MySqlDbType.Int32);
                //pid.Direction = ParameterDirection.Output;
                //objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricaoextrato", MySqlDbType.VarChar, 200);
                pdescricao.Value = extratobancarioinf.DescricaoExtratoBancario;
                objCommand.Parameters.Add(pdescricao);


                MySqlParameter pidinvestimento = new MySqlParameter("_idinvestimento", MySqlDbType.Int32, 200);
                pidinvestimento.Value = extratobancarioinf.IdInvestimento;
                objCommand.Parameters.Add(pidinvestimento);

                MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
                pidclassificacao.Value = extratobancarioinf.IdClassificacao;
                objCommand.Parameters.Add(pidclassificacao);

                MySqlParameter pidocorrencia = new MySqlParameter("_idocorrencia", MySqlDbType.Int32, 200);
                pidocorrencia.Value = extratobancarioinf.Idocorrencia;
                objCommand.Parameters.Add(pidocorrencia);

                MySqlParameter pidOcorrencia = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                pidOcorrencia.Value = extratobancarioinf.TipoClassificacao;
                objCommand.Parameters.Add(pidOcorrencia);

                MySqlParameter psaldoinvestimento = new MySqlParameter("_valorocorrencia", MySqlDbType.Decimal, 200);
                psaldoinvestimento.Value = extratobancarioinf.ValorOcorrencia;
                objCommand.Parameters.Add(psaldoinvestimento);

                MySqlParameter pdata = new MySqlParameter("_dataocorrencia", MySqlDbType.DateTime, 200);
                pdata.Value = extratobancarioinf.DataOcorrencia;
                objCommand.Parameters.Add(pdata);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = extratobancarioinf.StatusOcorrencia;
                objCommand.Parameters.Add(pstatusocorrencia);





                objConexao.Open();
                objCommand.ExecuteNonQuery();
                //investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_Idinvestimento"].Value;


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
        public void ExcluirExtratoBancario(ExtratosBancariosInformation extratosinf)
        {

            try
            {
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_excluirExtratoBancario";
                objCommand.CommandType = CommandType.StoredProcedure;


                MySqlParameter ptipoclassificacao = new MySqlParameter("_tipoclassificacao", MySqlDbType.VarChar, 200);
                ptipoclassificacao.Value = extratosinf.TipoClassificacao;
                objCommand.Parameters.Add(ptipoclassificacao);

                MySqlParameter pidocorrencia = new MySqlParameter("_idOcorrencia", MySqlDbType.VarChar, 200);
                pidocorrencia.Value = extratosinf.Idocorrencia;
                objCommand.Parameters.Add(pidocorrencia);


                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = extratosinf.StatusOcorrencia;
                objCommand.Parameters.Add(pstatusocorrencia);

                objConexao.Open();

                int resultado = objCommand.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("não foi possivel excluir o extrato" + extratosinf.Idocorrencia);
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