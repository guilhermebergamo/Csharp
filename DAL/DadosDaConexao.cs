using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{                           
                            //TRABALHARA COM MEU BANCO DE DADOS
    public class DadosDaConexao        //IRÁ ARMAZENAR AS INFORMAÇÕES DA MINHA CONEXÃO
    {
        public static string Servidor = @"GUILHERME";
        public static string Banco = "ControleDeEstoque";
        public static string Usuario = "sa";
        public static string Senha = "123456789";
        public static string StringDeConexao 
        {
                            //IRA DEVOLVER OS DADOS DE MINHA CONEXÃO
            get
            {
                return $"Data Source={Servidor};Initial Catalog={Banco};User ID={Usuario};Password={Senha}";
                
            }
        }
    }


    //42,1
    
}
