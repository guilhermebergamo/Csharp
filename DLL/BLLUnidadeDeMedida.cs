using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Windows.Forms;
using System.Data;

namespace DLL
{                   ///FAZ A VERIFICAÇÃO
    public class BLLUnidadeDeMedida
    {
        private DALConexao conexao;
        public  BLLUnidadeDeMedida(DALConexao cx)
        {
            conexao = cx;
        }
        public void Incluir(ModeloUnidadeDeMedida modelo)
        {
            if (modelo.UmedNome.Trim().Length == 0)
            {
                MessageBox.Show("O nome da unidade de medida é obrigatorio !","AVISO", MessageBoxButtons.OK);
            }
            else
            {
                DALUnidadeDeMedida dalunidadedeMedida = new DALUnidadeDeMedida(conexao);        //Instanciando
                dalunidadedeMedida.Incluir(modelo); //Chamando Incluir

            }

            //DALUnidadeDeMedida dalunidadedeMedida = new DALUnidadeDeMedida(conexao);        //Instanciando
            //dalunidadedeMedida.Incluir(modelo); //Chamando o Incluir
        }

        public void Alterar (ModeloUnidadeDeMedida modelo)
        {
            DALUnidadeDeMedida dalunidadedeMedida = new DALUnidadeDeMedida(conexao);
            dalunidadedeMedida.Alterar(modelo);
        }

        public void Excluir(int _codigo)
        {
            DALUnidadeDeMedida dalunidadedeMeninda = new DALUnidadeDeMedida(conexao);
            dalunidadedeMeninda.Excluir(_codigo);         
        }

        public DataTable localizar( string valor)
        {
            DALUnidadeDeMedida unidadedeMedida = new DALUnidadeDeMedida(conexao);
            return unidadedeMedida.Localizar(valor);
        }

        public int VerificaUnidadeDeMedida(string valor)        // 0 - não existe || numero > 0 existe
        {
            DALUnidadeDeMedida dalunidadedeMedida = new DALUnidadeDeMedida(conexao);
            return dalunidadedeMedida.VerificaUnidade(valor);
        }
        public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int codigo)
        {
            DALUnidadeDeMedida dalunidadedeMedida = new DALUnidadeDeMedida(conexao);
            return dalunidadedeMedida.CarregaModeloSubCategoria(codigo);
        }    
    }
}
