﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEconomy
{
    public class UsuariosDAL
    {
      
        MySqlConnection objConexao = new  MySqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        MySqlCommand objCommand = new MySqlCommand();


        public DataSet PesquisarUsuarios(UsuariosInformation usuario)
        {
            try
            {
                DataSet ds;
                objConexao.Open();
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_PesquisaUsuarios";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add(new MySqlParameter("_descricao", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_descricao"].Value = usuario.Descricao;

                objCommand.Parameters.Add(new MySqlParameter("_isdelete", MySqlDbType.Bit, 100));
                objCommand.Parameters["_isdelete"].Value = usuario.Isdelete;

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








        public void InserirUsuarios(UsuariosInformation usuario)
        {

            try
            {
               
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_InserirUsuarios";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("@Idusuarios", SqlDbType.Int);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("Descricao", MySqlDbType.VarChar, 200);
                pdescricao.Value = usuario.Descricao;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter psenha = new MySqlParameter("Senha", MySqlDbType.VarChar, 200);
                psenha.Value = usuario.Senha;
                objCommand.Parameters.Add(psenha);

                MySqlParameter pemail = new MySqlParameter("Email", MySqlDbType.VarChar, 200);
                pemail.Value = usuario.Email;
                objCommand.Parameters.Add(pemail);

                MySqlParameter pisdelete = new MySqlParameter("Isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = usuario.Isdelete;
                objCommand.Parameters.Add(pisdelete);

                MySqlParameter ptrocarSenha= new MySqlParameter("TrocarSenha", MySqlDbType.Bit, 200);
                ptrocarSenha.Value = usuario.TrocarSenha;
                objCommand.Parameters.Add(ptrocarSenha);


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