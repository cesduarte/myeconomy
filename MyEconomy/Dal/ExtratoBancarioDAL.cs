using MySql.Data.MySqlClient;
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

        //public void InserirExtratoBancario(InvestimentoInformation investimentosinf)
        //{

        //    try
        //    {

        //        objCommand.Connection = objConexao;
        //        objCommand.CommandText = "Procedure_inserirExtratoBancario";
        //        objCommand.CommandType = CommandType.StoredProcedure;

        //        MySqlParameter pid = new MySqlParameter("_Idextratobancario", MySqlDbType.Int32);
        //        pid.Direction = ParameterDirection.Output;
        //        objCommand.Parameters.Add(pid);



        //        MySqlParameter pdescricao = new MySqlParameter("_descricaoextrato", MySqlDbType.VarChar, 200);
        //        pdescricao.Value = investimentosinf.DescricaoInvestimento;
        //        objCommand.Parameters.Add(pdescricao);


        //        MySqlParameter pidcontasbancarias = new MySqlParameter("_idInvestimento", MySqlDbType.Int32, 200);
        //        pidcontasbancarias.Value = investimentosinf.IdInvestimento;
        //        objCommand.Parameters.Add(pidcontasbancarias);

        //        MySqlParameter pidclassificacao = new MySqlParameter("_idclassificacao", MySqlDbType.Int32, 200);
        //        pidclassificacao.Value = investimentosinf.IdClassificacao;
        //        objCommand.Parameters.Add(pidclassificacao);

        //        MySqlParameter psaldoinvestimento = new MySqlParameter("_saldoinvestimento", MySqlDbType.Decimal, 200);
        //        psaldoinvestimento.Value = investimentosinf.SaldoInvestimento;
        //        objCommand.Parameters.Add(psaldoinvestimento);

        //        MySqlParameter pdata = new MySqlParameter("_datainvestimento", MySqlDbType.DateTime, 200);
        //        pdata.Value = investimentosinf.DataInvestimento;
        //        objCommand.Parameters.Add(pdata);

        //        MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
        //        pstatusocorrencia.Value = EnumExtensions.GetEnumDescription((StatusEnum.TipoOcorrencias.InvestimentoCredito));
        //        objCommand.Parameters.Add(pstatusocorrencia);





        //        objConexao.Open();
        //        objCommand.ExecuteNonQuery();
        //        //investimentosinf.IdInvestimento = (Int32)objCommand.Parameters["_Idinvestimento"].Value;


        //    }
        //    catch (MySqlException ex)
        //    {
        //        throw new Exception("sqlerro" + ex.Number);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        objConexao.Close();
        //    }

        //}
        public void ExcluirExtratoBancario(ExtratosBancariosInformation extratosinf)
        {

            try
            {
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_excluirExtratoBancario";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_IdOcorrencia", MySqlDbType.Int32);
                pid.Value = extratosinf.IdOcorrencia;
                objCommand.Parameters.Add(pid);

                MySqlParameter pstatusocorrencia = new MySqlParameter("_statusocorrencia", MySqlDbType.VarChar, 200);
                pstatusocorrencia.Value = extratosinf.StatusOcorrencia;
                objCommand.Parameters.Add(pstatusocorrencia);

                objConexao.Open();

                int resultado = objCommand.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("não foi possivel excluir o extrato" + extratosinf.IdOcorrencia);
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