using MySql.Data.MySqlClient;
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
                objCommand.Parameters.Add(new MySqlParameter("_usuario", MySqlDbType.VarChar, 100));
                objCommand.Parameters["_usuario"].Value = usuario.Usuario;

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


        public List<UsuariosInformation> CarregarUsuariosCampos(string Idusuario)
        {
            try
            {
                objConexao.Open();
                string sql;

                if (Idusuario== "")
                {
                    sql = "select * from tbl_usuarios where isdelete = false order by descricao";
                }
                else
                {
                    sql = "select * from tbl_usuarios where Idusuario = " + Idusuario;
                }
                

               
                objCommand = new MySqlCommand(sql, objConexao);
                MySqlDataAdapter Objdata = new MySqlDataAdapter(objCommand);

                DataTable objDataTable = new DataTable();
                Objdata.Fill(objDataTable);

                List<UsuariosInformation> ListaDeDados = new List<UsuariosInformation>();
                foreach (DataRow dataRow in objDataTable.Rows)
                {
                    ListaDeDados.Add( new UsuariosInformation() { Id = int.Parse(dataRow["Idusuario"].ToString()), Descricao = dataRow["Descricao"].ToString(), Usuario = dataRow["Usuario"].ToString(), Senha = dataRow["Senha"].ToString(), Email = dataRow["Email"].ToString(),Isdelete= Convert.ToBoolean(dataRow["Isdelete"].ToString()) });
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

       



        public void InserirUsuarios(UsuariosInformation usuario)
        {

            try
            {
               
                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_inserirUsuarios";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_Idusuarios", SqlDbType.Int);
                pid.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricao", MySqlDbType.VarChar, 200);
                pdescricao.Value = usuario.Descricao;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter pusuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 200);
                pusuario.Value = usuario.Usuario;
                objCommand.Parameters.Add(pusuario);

                MySqlParameter psenha = new MySqlParameter("_senha", MySqlDbType.VarChar, 200);
                psenha.Value = usuario.Senha;
                objCommand.Parameters.Add(psenha);

                MySqlParameter pemail = new MySqlParameter("_email", MySqlDbType.VarChar, 200);
                pemail.Value = usuario.Email;
                objCommand.Parameters.Add(pemail);

                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = usuario.Isdelete;
                objCommand.Parameters.Add(pisdelete);

                MySqlParameter ptrocarSenha= new MySqlParameter("_trocarSenha", MySqlDbType.Bit, 200);
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

        public void AlterarUsuarios(UsuariosInformation usuario)
        {

            try
            {

                objCommand.Connection = objConexao;
                objCommand.CommandText = "Procedure_AlterarUsuarios";
                objCommand.CommandType = CommandType.StoredProcedure;

                MySqlParameter pid = new MySqlParameter("_idusuarios", SqlDbType.Int);
                pid.Value = usuario.Id;
                objCommand.Parameters.Add(pid);



                MySqlParameter pdescricao = new MySqlParameter("_descricao", MySqlDbType.VarChar, 200);
                pdescricao.Value = usuario.Descricao;
                objCommand.Parameters.Add(pdescricao);

                MySqlParameter pusuario = new MySqlParameter("_usuario", MySqlDbType.VarChar, 200);
                pusuario.Value = usuario.Usuario;
                objCommand.Parameters.Add(pusuario);

                MySqlParameter psenha = new MySqlParameter("_senha", MySqlDbType.VarChar, 200);
                psenha.Value = usuario.Senha;
                objCommand.Parameters.Add(psenha);

                MySqlParameter pemail = new MySqlParameter("_email", MySqlDbType.VarChar, 200);
                pemail.Value = usuario.Email;
                objCommand.Parameters.Add(pemail);

                MySqlParameter pisdelete = new MySqlParameter("_isdelete", MySqlDbType.Bit, 200);
                pisdelete.Value = usuario.Isdelete;
                objCommand.Parameters.Add(pisdelete);

                MySqlParameter ptrocarSenha = new MySqlParameter("_trocarSenha", MySqlDbType.Bit, 200);
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