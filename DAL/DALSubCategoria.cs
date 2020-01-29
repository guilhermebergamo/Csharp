using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace DAL
{       
                                        /// <summary>
                                        /// TODA A PARTE DE COMANDOS E CONEXAO QUE SERA REALIZADO NO SQL
                                        /// </summary>
    public class DALSubCategoria
    {
        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 

        public DALSubCategoria(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                   //conexao que recebe o objeto cx
        }
        public void Incluir(ModeloSubCategoria modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {
            try
            {
                SqlCommand cmd = new SqlCommand();                      //instância um comando
                cmd.Connection = conexao.ObjetoConexao;                 //usara a conexao dentro de DALconexao
                cmd.CommandText = "insert into subcategoria(cat_cod, scat_nome) values (@catcod, @nome); select @@IDENTITY;";     //comando que sera utilizado
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);                   //parametros do comando informado
                cmd.Parameters.AddWithValue("@nome", modelo.ScatNome);                    //parametros do comando informado

                conexao.Conectar();                                     //Conecta ao BD

                modelo.ScatCod = Convert.ToInt32(cmd.ExecuteScalar());            ////modelo catcod receba o valor retornado pelo Chave Primaria                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
            finally
            {
                conexao.Desconectar();    //Desconecta do BD
            }
        }
        public void Alterar(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update subcategoria set scat_nome = @nome, cat_cod = @catcod where scat_cod = @scatcod;";
                cmd.Parameters.AddWithValue("@nome", modelo.ScatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);

                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }            
        }
        public void Excluir(int _Codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from subcategoria where scat_cod = @codigo;";
                cmd.Parameters.AddWithValue("@codigo", _Codigo);     
                
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
            DataTable _dataTable = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter _dataAdapter = new SqlDataAdapter("select sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " + 
                "from subcategoria sc inner join categoria c on sc.cat_cod = c.cat_cod where scat_nome like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            _dataAdapter.Fill(_dataTable);        //ira preencher a tabela com os valores do comando executado...

            return _dataTable;
        }

        public DataTable LocalizaPorCategoria(int categoria)        // FAZ A BUSCA PELA CATEGORIA
        {
            DataTable _dataTable = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter _dataAdapter = new SqlDataAdapter("select sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " +
                "from subcategoria sc inner join categoria c on sc.cat_cod = c.cat_cod where sc.cat_cod = " + categoria.ToString(), conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            _dataAdapter.Fill(_dataTable);        //ira preencher a tabela com os valores do comando executado...

            return _dataTable;
        } 


        public ModeloSubCategoria CarregaModeloSubCategoria(int _Codigo)
        {
            try
            {
                ModeloSubCategoria _modelosubCategoria = new ModeloSubCategoria();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = " select * from subcategoria where Scat_cod = @codigo";
                cmd.Parameters.AddWithValue("@codigo", _Codigo);

                conexao.Conectar();
                SqlDataReader Registro = cmd.ExecuteReader();

                if (Registro.HasRows)                           //verificando se existe alguma linha dentro de objeto registr
                {
                    Registro.Read();                            // tiver alguma coisa, LEIA A LINHA
                    _modelosubCategoria.CatCod = Convert.ToInt32(Registro["cat_cod"]);
                    _modelosubCategoria.ScatNome = Convert.ToString(Registro["scat_nome"]);
                    _modelosubCategoria.ScatCod = Convert.ToInt32(Registro["scat_cod"]);
                }
                conexao.Desconectar();

                return _modelosubCategoria;                
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

    }
}
