using Modelo;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 

        public DALCategoria(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                   //conexao que recebe o objeto cx
        }
        public void Incluir(ModeloCategoria modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {
            SqlCommand cmd = new SqlCommand();                      //instância um comando
            cmd.Connection = conexao.ObjetoConexao;                 //usara a conexao dentro de DALconexao
            cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";     //comando que sera utilizado
            cmd.Parameters.AddWithValue("@nome", modelo.CatNome);           //parametros do comando informado

            conexao.Conectar();

            modelo.CatCod = Convert.ToInt32(cmd.ExecuteScalar());            ////modelo catcod receba o valor retornado pelo Identity, apos executar o comando ExecuteScalar...Retorna pouca informação do BD
                                          
            conexao.Desconectar();                              //Desconecta ao BD
        }
        public void Alterar(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update categoria set cat_nome = @nome where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.CatNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.CatCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();  //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.
            conexao.Desconectar();  
        }
        public void Excluir(int codigo)                 //executeRead opter varias informacoes, varios registros do BD
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from categoria where cat_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public DataTable Localizar(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {
            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from categoria where cat_nome like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;
        }
        public ModeloCategoria CarregaModeloCategoria(int codigo)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {
            ModeloCategoria modelo = new ModeloCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from categoria where cat_cod = " + codigo.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();       //obtera varias informações/registro do BD

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();                        // tiver alguma coisa, LEIA A LINHA
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);   //Carrega as informaçoes no modelo.CAT_COD RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA CAT-COD DO REGISTRO.
                modelo.CatNome = Convert.ToString(registro["cat_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }

    }
}
