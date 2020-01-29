using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{                       //CLASSE RESPONSAVEL POR INTERAGIR COM A INTERFACE
                        //IRA PEGAR OS DADOS DA INTERFACE, VERIFICAR AS REGRAS E SE TIVER TUDO OK
                        //IRA CHAMAR A CLASSE DALL E EXECUTARA AS OPERACOES DO BANCO
    public class BLLCategoria
    {
        private DALConexao conexao;
        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloCategoria modelo)
        {
            if (modelo.CatNome.Trim().Length == 0)  //USUARIO OBRIGATORIAMENTE DEVE DIGITAR NOME, (TRIM, VERIFICAR SE TEM ESPAÇO EM BRANCO E TIRA), (LENGTH, VERIFICA O TAMANHO)
            {
                throw new Exception("O nome da categoria é obrigatório !");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloCategoria modelo)
        {
            if (modelo.CatCod <=0)                             //USUARIO OBRIGATORIAMENTE DEVE DIGITAR NOME
            {
                throw new Exception("O código da categoria é obrigatório !");
            }
            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório !");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALCategoria DALobj = new DALCategoria(conexao);        //passando a conexao, construtor
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);
        }
        public DataTable Localizar(string valor)
        {
            DALCategoria DALobj = new DALCategoria(conexao);

            return DALobj.Localizar(valor);
        }
        public ModeloCategoria CarregaModeloCategoria(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);

            return DALobj.CarregaModeloCategoria(codigo);
        }
    }
}
