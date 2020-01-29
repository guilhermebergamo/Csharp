using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;

namespace DLL
{
    public class BLLSubCategoria
    {
        private DALConexao conexao;                         //Conexao é uma variavel que representa a conexao 

        public BLLSubCategoria(DALConexao cx)                  //Construtor que recebe como parametro uma conexao
        {
            conexao = cx;                                  //conexao que recebe o objeto cx

        }

        public void Incluir(ModeloSubCategoria modelo)     //Metodo Incluir que recebe como parametro o modelo do tipo modelocategoria
        {
            if (modelo.ScatNome.Trim().Length == 0)     //USUARIO OBRIGATORIAMENTE DEVE DIGITAR NOME, (TRIM, VERIFICAR SE TEM ESPAÇO EM BRANCO E TIRA), (LENGTH, VERIFICA O TAMANHO)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            DALSubCategoria _dalsubCategoria = new DALSubCategoria(conexao);        //Instanciando
            _dalsubCategoria.Incluir(modelo);               //Chamando o Incluir

        }
        
        public void Alterar(ModeloSubCategoria modelo)
        {   //TRIM () - Remove os espaços em branco ou caracteres especificados em uma matriz de caracteres do início
            //e do final de uma cadeia de caracteres.

            //Lenght - Comprimento obtém a contagem de caracteres.
            if (modelo.ScatNome.Trim().Length == 0)   
            {
                throw new Exception("O nome da subcategoria é obrigatório !");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O Código da categoria é obrigadtório");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O Código da subcategoria é obrigadtório");
            }

            DALSubCategoria _dalsubCategoria = new DALSubCategoria(conexao);
            _dalsubCategoria.Alterar(modelo);
        }

        public void Excluir(int _Codigo)
        {

            DALSubCategoria _dalsubCategoria = new DALSubCategoria(conexao);
            _dalsubCategoria.Excluir(_Codigo);
        }
        public DataTable Localizar(string valor)
        {

            DALSubCategoria _dalsubCategoria = new DALSubCategoria(conexao);
            return _dalsubCategoria.Localizar(valor);           
        }

        public DataTable LocalizaPorCategoria(int categoria)
        {

            DALSubCategoria dalsubCategoria = new DALSubCategoria(conexao);
            return dalsubCategoria.LocalizaPorCategoria(categoria);            

        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int _Codigo)
        {

            DALSubCategoria _dalsubCategoria = new DALSubCategoria(conexao);
            return _dalsubCategoria.CarregaModeloSubCategoria(_Codigo);

        }
    }
}
