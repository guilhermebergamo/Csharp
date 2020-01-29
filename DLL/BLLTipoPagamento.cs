using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;
using DAL;


namespace DLL
{
    public class BLLTipoPagamento
    {
        private DALConexao conexao;
        public BLLTipoPagamento(DALConexao cx)
        {

            this.conexao = cx;  

        }

        public void Incluir(ModeloTipoPagamento modelo)
        {

            if (modelo.TpaNome.Trim().Length == 0)  //USUARIO OBRIGATORIAMENTE DEVE DIGITAR NOME, (TRIM, VERIFICAR SE TEM ESPAÇO EM BRANCO E TIRA), (LENGTH, VERIFICA O TAMANHO)
            {
                throw new Exception("O tipo do pagamento é obrigatório !");
            }
            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
           
        }
        public void Alterar(ModeloTipoPagamento modelo)
        {

            if (modelo.TpaCod <= 0)                             //USUARIO OBRIGATORIAMENTE DEVE DIGITAR NOME
            {
                throw new Exception("O código do tipo de pagamento é obrigatório !");
            }
            if (modelo.TpaNome.Trim().Length == 0)
            {
                throw new Exception("O nome do tipo de pagamento é obrigatório !");
            }

            //modelo.CatNome = modelo.CatNome.ToUpper();

            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);        //passando a conexao, construtor
            DALobj.Alterar(modelo);

        }

        public void Excluir(int codigo)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor)
        {

            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            return DALobj.Localizar(valor);

        }
        public ModeloTipoPagamento CarregaModeloTipoPagamento(int codigo)
        {

            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            return DALobj.CarregaModeloTipoPagamento(codigo);

        }        

    }
}
