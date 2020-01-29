using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
                        //------REPRESENTA MINHA TABELA CATEGORIA ONDE TEM DUAS COLUNAS.
    public class ModeloCategoria
    {
        public ModeloCategoria()         //CONSTRUTOR para iniciar as propriedades
        {
            CatCod = 0;            
            CatNome = "";
        }
        public ModeloCategoria(int catcod, string scatnome) //CONSTRUTOR COM PARAMETROS
        {
            CatCod = catcod;           
            CatNome = scatnome;
        }
        private int cat_cod;        
        public int CatCod
        {
            get
            {
                return this.cat_cod;     //Ira representar as tabelas Catcod e catnome do BD
            }
            set
            {
                this.cat_cod = value;
            }
        }
        private string cat_nome;        //propriedade

        public string CatNome 
        {
            get
            {
                return this.cat_nome;       //Ira resepresentar as tabelas Catcod e carnome do banco de dados
            }
            set
            {
                this.cat_nome = value;
            }
        }
    }
}
