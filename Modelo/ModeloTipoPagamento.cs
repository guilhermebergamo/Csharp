using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloTipoPagamento
    {

        public ModeloTipoPagamento()         //CONSTRUTOR para iniciar as propriedades
        {
            TpaCod = 0;
            TpaNome = "";
        }
        public ModeloTipoPagamento(int tpacod, string tpanome) //CONSTRUTOR COM PARAMETROS
        {
            TpaCod = tpacod;
            TpaNome = tpanome;
        }
        private int tpa_cod;
        public int TpaCod
        {
            get
            {
                return this.tpa_cod;     //Ira representar as tabelas Catcod e catnome do BD
            }
            set
            {
                this.tpa_cod = value;
            }
        }
        private string Tpa_nome;        //propriedade

        public string TpaNome
        {
            get
            {
                return this.Tpa_nome;       //Ira resepresentar as tabelas Catcod e carnome do banco de dados
            }
            set
            {
                this.Tpa_nome = value;
            }




        }
    }
}
