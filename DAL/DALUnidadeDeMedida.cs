using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALUnidadeDeMedida
    {
        private DALConexao conexao;

        public DALUnidadeDeMedida(DALConexao cx)
        {
           this.conexao = cx;
        }

        public void Incluir(ModeloUnidadeDeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "Insert into undmedida(umed_nome) values (@nome) select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
                conexao.Conectar();

                modelo.UmedNome = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Alterar(ModeloUnidadeDeMedida modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update undmedida set umed_nome = @nome where umed_cod = @cod;";
                cmd.Parameters.AddWithValue("nome", modelo.UmedNome);
                cmd.Parameters.AddWithValue("cod", modelo.UmedCod);

                conexao.Conectar();

                cmd.ExecuteNonQuery();    

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Excluir( int _codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from undmedida where umed_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", _codigo);

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter _sqldataAdapter = new SqlDataAdapter("select * from undmedida where umed_nome like'%" + valor + "%'", conexao.StringConexao);
           _sqldataAdapter.Fill(tabela);

            return tabela;
        }

        public int VerificaUnidade(string valor)        //0 - Não existe valor no banco // > 0 Então existe valor no banco
        {
            int R = 0;      //Ja esta falando que nao existe, apos isso vamos verificar

            SqlCommand sqlComamand = new SqlCommand();
            sqlComamand.Connection = conexao.ObjetoConexao;
            sqlComamand.CommandText = "select * from undmedida where umed_nome = @nome";
            sqlComamand.Parameters.AddWithValue("@nome", valor);

            conexao.Conectar();

            SqlDataReader registro = sqlComamand.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();

                R = Convert.ToInt32(registro["umed_cod"]);
            }
            conexao.Desconectar();
            return R;
        }


        public ModeloUnidadeDeMedida CarregaModeloSubCategoria(int codigo)
        {
            ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undmedida where umed_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();

            if (registro.HasRows)
            {
                registro.Read();
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.UmedNome = Convert.ToString(registro["umed_nome"]);
            }
            conexao.Desconectar();

            return modelo;
        }
        


    }
}
