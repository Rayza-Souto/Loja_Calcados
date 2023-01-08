using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows;
using System.ComponentModel;
using Principal;

namespace Loja_Calcados
{
    public partial class clsFuncionarios
    {
        private SqlConnection con = null;
        private int cod_func;
        public int Cod_Func
        {
            get { return cod_func; }
            set { cod_func = value; }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string sexo;
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public clsFuncionarios(int cod_func, string nome, string sexo, string email)
        {
            this.Cod_Func = cod_func;
            this.Nome = nome;
            this.Sexo = sexo;
            this.Email = email;
        }
        public void InserirCliente(clsFuncionarios funcionario)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InserirFuncionario", con);
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod_func", funcionario.Cod_Func);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha na operação." + ex.Message);
            }
        }
        public void AlterarCliente(clsFuncionarios funcionario)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AtualizarCliente", con);
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteID", funcionario.Cod_Func);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@sexo", funcionario.Sexo);
                cmd.Parameters.AddWithValue("@email", funcionario.Email);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha na operação." + ex.Message);
            }
        }
        public void ExcluirCliente(clsFuncionario funcionario)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeletarCliente", con);
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteID", funcionario.Cod_Func);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha na operação." + ex.Message);
            }
        }
        public clsFuncionario RetornarUmCliente(clsFuncionario cliente)
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LocalizarClientePorID", con);
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteID", cliente.Cod_Func);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                clsFuncionario rcliente = new clsFuncionario();
                while (reader.Read())
                {
                    rcliente.Cod_Func = Convert.ToInt16(reader["Cod_Func"]);
                    rcliente.Nome = reader["nome"].ToString();
                    rcliente.Sexo = reader["sexo"].ToString();
                    rcliente.Email = reader["email"].ToString();
                }
                return rcliente;
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha na operação." + ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        public List<clsFuncionario> GetFuncionarios()
        {
            con = new SqlConnection(ConfigurationManager.AppSettings["conString"]);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("LocalizarTodosClientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                //Lista de todos os produtos retornados
                List<clsFuncionario> listaClientes = new List<clsFuncionario>();
                //Lê o registro reornado, se foi localizado
                while (reader.Read())
                {
                    clsFuncionario rcliente = new clsFuncionario();
                    rcliente.Cod_Func = Convert.ToInt16(reader["Cod_Func"]);
                    rcliente.Nome = reader["nome"].ToString();
                    rcliente.Sexo = reader["sexo"].ToString();
                    rcliente.Email = reader["email"].ToString();
                    listaClientes.Add(rcliente);
                }
                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na operação: " + ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
    }
}