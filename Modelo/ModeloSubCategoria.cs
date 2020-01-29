using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{                                   /// <summary>
                                    /// CAMPOS DA TEBELA DE SUB CATEGORIA sql
                                    /// </summary>
    public class ModeloSubCategoria
    {      
        public  ModeloSubCategoria()         //CONSTRUTOR para iniciar as propriedades
        {
            CatCod = 0;
            ScatCod = 0;
            ScatNome = "";
        }
        public ModeloSubCategoria(int catcod, int scatcod, string scatnome) //CONSTRUTOR COM PARAMETROS-
        {
            CatCod = catcod;        //recebe parametro
            ScatCod = scatcod;      //recebe parametro  
            ScatNome = scatnome;    //recebe parametro
        }    

        private int scat_cod;
        public int ScatCod         //Sub Categoria
        {
            get
            {
                return scat_cod;
            }
            set
            {
                scat_cod = value;
            }
        }   

        private string scat_nome;
        public string ScatNome      //Sub Categoria
        {
            get
            {
                return scat_nome;
            }
            set
            {
                scat_nome = value;
            }
        }

        private int cat_cod;
        public int CatCod          //Sub Categoria
        {
            get
            {
                return cat_cod;
            }
            set
            {
                cat_cod = value;
            }
        }







    }
}
