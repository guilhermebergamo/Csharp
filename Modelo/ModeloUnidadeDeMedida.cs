using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUnidadeDeMedida
    {
        //umed_cod -- Tabela do Banco de Dados
        //umed_nome -- Tabela do Banco de Dados     

        public ModeloUnidadeDeMedida()
        {
            UmedCod = 0;
            UmedNome = "";
        }

        public ModeloUnidadeDeMedida(int cod, string nome)
        {
            UmedCod = cod;
            UmedNome = nome;
        }

        private string umed_nome;
        public string UmedNome
        {
            get
            {
                return this.umed_nome;
            }
            set
            {
                this.umed_nome = value;
            }
        }
        
        private int umed_cod;
        public int UmedCod
        {
            get
            {
                return this.umed_cod;
            }
            set
            {
                this.umed_cod = value;
            }
        }      
    }
}
