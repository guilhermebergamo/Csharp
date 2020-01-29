using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace DAL
{
    public class DALTipoPagamento
    {
        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 

        public DALTipoPagamento(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                   //conexao que recebe o objeto cx
        }
        public void Incluir(ModeloTipoPagamento modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {
            SqlCommand cmd = new SqlCommand();                      //instância um comando

            cmd.Connection = conexao.ObjetoConexao;                 //usara a conexao dentro de DALconexao
            cmd.CommandText = "insert into tipopagamento(tpa_nome) values (@nome); select @@IDENTITY;";     //comando que sera utilizado
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);           //parametros do comando informado

            conexao.Conectar();

            modelo.TpaCod = Convert.ToInt32(cmd.ExecuteScalar());            ////modelo catcod receba o valor retornado pelo Identity, apos executar o comando ExecuteScalar...Retorna pouca informação do BD

            conexao.Desconectar();                              //Desconecta ao BD
        }
        public void Alterar(ModeloTipoPagamento modelo)
        {

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update tipopagamento set tpa_nome = @nome where tpa_cod = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.TpaCod);

            conexao.Conectar();

            cmd.ExecuteNonQuery();  //O método ExecuteNonQuery é utilizado para executar instruções SQL que não retornam dados, como Insert, Update, Delete, e Set.
            
            conexao.Desconectar();

        }
        public void Excluir(int codigo)                 //executeRead opter varias informacoes, varios registros do BD
        {

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from tipopagamento where tpa_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }
        public DataTable Localizar(string valor)               //metodo localizar, vai devolver uma tabela em memoria e recebe um valor como parametro que queremos procurar dentro da tabela
        {

            DataTable tabela = new DataTable();                           //instancia objetop do tipo datatable
            SqlDataAdapter da = new SqlDataAdapter("select * from tipopagamento where tpa_nome like '%" + valor + "%'", conexao.StringConexao);    //seleciona todos os objetos da categoria onde o nome seja parecido com o valor informado pelo usuario... e passando a string de conexão.
            da.Fill(tabela);         //ira preencher a tabela com os valores do comando executado...

            return tabela;

        }
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int codigo)               //ira receber o codigo da categoria que nós desejamos pegar as informacoes
        {

            ModeloTipoPagamento modelo = new ModeloTipoPagamento();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tipopagamento where tpa_cod = " + codigo.ToString(); //....Onde codigo for igual ao codigo informado pelo usuario
            //cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //REGISTRO RECEBE O RETORNO DA EXECUCAO DO COMANDO !

            if (registro.HasRows)       //verificando se existe alguma linha dentro de objeto registro
            {
                registro.Read();                        // tiver alguma coisa, LEIA A LINHA
                modelo.TpaCod = Convert.ToInt32(registro["tpa_cod"]);   //Carrega as informaçoes no modelo.CAT_COD RECEBER A INFORMACAO QUE ESTA DENTRO DA COLUNA CAT-COD DO REGISTRO.
                modelo.TpaNome = Convert.ToString(registro["tpa_nome"]);
            }
            conexao.Desconectar();

            return modelo;

        }

    }
}
