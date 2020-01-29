using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Modelo;

namespace DLL
{
    public class BLLProduto
    {
        private DALConexao conexao;

        public BLLProduto(DALConexao cx)
        {

            conexao = cx;
        }

        public void Incluir(ModeloProdutos modelo)
        {
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio !");
            }
            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("O Descrição do produto é obrigatorio !");
            }
            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do Produto é obrigatorio !");
            }
            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do Produto deve ser maior ou igual a 0 !");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O código da Subcategoria é obrigatório !");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da Categoria é obrigatório !");
            }
            if (modelo.UmedCod <= 0)
            {
                throw new Exception("O código da Unidade de Medida é obrigatório !");
            }

            DALProduto dalProduto = new DALProduto(conexao);
            dalProduto.Incluir(modelo);
        }

        public void Excluir(int codigo)
        {
            DALProduto dalProduto = new DALProduto(conexao);
            dalProduto.Excluir(codigo);
        }

        public void Alterar(ModeloProdutos modelo)
        {
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatorio !");
            }
            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("O Descrição do produto é obrigatorio !");
            }
            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do Produto é obrigatorio !");
            }
            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do Produto deve ser maior ou igual a 0 !");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O código da Subcategoria é obrigatório !");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da Categoria é obrigatório !");
            }
            if (modelo.UmedCod <= 0)
            {
                throw new Exception("O código da Unidade de Medida é obrigatório !");
            }
            if (modelo.ProCod <= 0)
            {
                throw new Exception("O código do Produto é obrigatório !");
            }

            DALProduto dalProduto = new DALProduto(conexao);
            dalProduto.Alterar(modelo);

        }

        public DataTable Localizar(string valor)
        {

            DALProduto dalProduto = new DALProduto(conexao);
            return dalProduto.Localizar(valor);

        }

        public ModeloProdutos CarregaModeloProduto(int codigo)
        {
            DALProduto dalProduto = new DALProduto(conexao);
            return dalProduto.CarregaModeloProdutos(codigo);

        }



    }
}
