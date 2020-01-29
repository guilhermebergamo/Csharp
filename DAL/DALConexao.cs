
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALConexao
    {
        private string _stringConexao;      //

        private SqlConnection _conexao;         //
        public DALConexao (string dadosConexao)            //Construtor que ira receber uma string de conexao
        {
            this._conexao = new SqlConnection();                      //instância dado privado conexao
            this.StringConexao = dadosConexao;                       //Define a string de conexao
            this._conexao.ConnectionString = dadosConexao;          //Define qual a string de conexao que ira ser utilizada para se conectar ao BD   
        }
        public string StringConexao 
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }         
        }
        public SqlConnection ObjetoConexao                       //Propriedade do tipo SqlConnection para poder setar e pegar o valor do _Conexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }
        public void Conectar()                        //Metodo para conectar ao BD
        {
            this._conexao.Open();
        }
        public void Desconectar()                    //Metodo para desconectar ao BD
        {
            this._conexao.Close();
        }
    }
}

