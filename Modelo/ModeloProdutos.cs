using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProdutos
    {
        public ModeloProdutos()     //uniciando todos os campos
        {
            this.ProCod = 0;
            this.ProNome = "";
            this.ProDescricao = "";
           //null
            this.ProValorPago = 0;
            this.ProValorVenda = 0;
            this.ProQtde = 0;
            this.UmedCod = 0;
            this.CatCod = 0;
            this.ScatCod = 0;
        }

        //iniciando todos os campos passando todas as informacoes do produto ja de uma vez
        public ModeloProdutos( int pro_cod, string pro_nome, string pro_descricao,
                              String pro_foto, double pro_valorpago, int pro_valorvenda,       //construtor que indica onde esta a foto(string)
                              int pro_qtde, int umed_cod, int cat_cod, int scat_cod )
                                     
        {
            this.ProCod = pro_cod;
            this.ProNome = pro_nome;
            this.ProDescricao = pro_descricao;
            this.CarregaImagem(pro_foto);       //carrega a foto para dentro do vetor PROFOTO
            this.ProValorPago = pro_valorpago;
            this.ProValorVenda = pro_valorvenda;
            this.ProQtde = pro_qtde;
            this.UmedCod = umed_cod;
            this. CatCod = cat_cod;
            this.ScatCod = scat_cod;
        }

        public ModeloProdutos(int pro_cod, string pro_nome, string pro_descricao,
                             Byte[] pro_foto, double pro_valorpago, int pro_valorvenda,        //recebe o vetor pronto
                             int pro_qtde, int umed_cod, int cat_cod, int scat_cod)

        {
            this.ProCod = pro_cod;
            this.ProNome = pro_nome;
            this.ProDescricao = pro_descricao;
            this.ProFoto = pro_foto;     //armazena dentro da pro_foto
            this.ProValorPago = pro_valorpago;
            this.ProValorVenda = pro_valorvenda;
            this.ProQtde = pro_qtde;
            this.UmedCod = umed_cod;
            this.CatCod = cat_cod;
            this.ScatCod = scat_cod;
        }

        private int _pro_cod;
        public int ProCod 
        {
            get
            {
                return this._pro_cod;       //captura o valor do codigo e retorna ao usuario
            }
            set
            {
                this._pro_cod = value;      //ou pega um valor do usuairo e guarda em pro cod
            } 
        }

        private string _pro_nome;
        public string ProNome
        {
            get
            {
                return this._pro_nome;
            }
            set
            {
                this._pro_nome = value;
            }
        }

        private string _pro_descricao;
        public string ProDescricao
        {
            get
            {
                return this._pro_descricao;
            }
            set
            {
                this._pro_descricao = value;
            }            
        }

        private byte[] _pro_foto;                     //vetor de byte                   guardara a imagem dos dados

        public byte[] ProFoto
        {
            get
            {
                return this._pro_foto;          //pegando o vetor e devolvendo ao usuario
            }
            set
            {
                this._pro_foto = value;     //pegando o vetor e armazenando no profoto
            }
        }

        public void CarregaImagem(string imgCaminho)        //recebe caminho de onde encontra a imagem. C:/IMAGEN/IMAGENS/FOTO.JPEG... 
        {
            try //tente
            {
                if (string.IsNullOrEmpty(imgCaminho))//SE O CAMINHO DA IMAGEM ESTIVER VAZIA OU NULL, 
                    return;     //SAI DO METODO

                //OBJETOS TIPO FileInfo == INFORMAÇÕES RELACIONADAS AO ARQUIVO
                FileInfo arquivoImagem = new FileInfo(imgCaminho);      //caminho da imagem

                //cria FS. imgCaminho == passada o caminho(informações). FileMode.Open == OQUE QUERO FAZER, APENAS ABRIR. FileAccess.Read() == TIPO DE ACESSO AO ARQUIVO, APENAS LEITURA. FileShare == TIPO DE COMPARTILHAMENTO DAS INFORMACOES DA IMAGEM, APENAS LEITURA.
                FileStream Fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);

                this.ProFoto = new byte[Convert.ToInt32(imgCaminho.Length)]; //CRIA VETOR DE BYTES DO TAMANHO DA IMAGEM== conta quantidade de string e passa para a propriedade.

                int iBytesRead = Fs.Read(this.ProFoto, 0, Convert.ToInt32(imgCaminho.Length)); //iBytesRead == Faz a leituras dos dados. Le apartir da posição 0. 

                Fs.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                //  FileInfo    == Lê todo tipo de informação de um arquivo.
                //Use a FileInfo classe para operações típicas, como copiar, mover, renomear, criar, abrir,
                //excluir e acrescentar a arquivos. Recupere informações sobre um arquivo.               

                //FileStream == //REPRESETA-RA A FOTO. DADOS BRUTOS. APENAS OS BYTES. NAO RECONHECE O TIPO, 
                //APENAS REPRESETA A INFOMACAO NA MEMORIA DE MANEIRA BRUTA.

                //REPRESETA-RA A FOTO. DADOS BRUTOS. APENAS OS BYTES. NAO RECONHECE O TIPO, 
                //APENAS REPRESETA A INFOMACAO NA MEMORIA DE MANEIRA BRUTA.

                //FileAccess ==	Especifica acesso de leitura e gravação a um arquivo.

                //FileShare ==	Especifica o nível de acesso permitido para um arquivo que já está em uso.

                //FileMode ==   Especifica se o conteúdo de um arquivo existente é preservado ou substituído e se 
                //as solicitações para criar um arquivo existente causam uma exceção.

        private double _pro_valorpago;
        public double ProValorPago
        {
            get
            {
                return this._pro_valorpago;
            }
            set
            {
                this._pro_valorpago = value;
            }
        }

        private double _pro_valorvenda;
        public double ProValorVenda
        {
            get
            {
                return this._pro_valorvenda;
            }
            set
            {
                this._pro_valorvenda = value;
            }
        }

        private int _pro_qtde;
        public int ProQtde
        {
            get
            {
                return this._pro_qtde;
            }
            set
            {
                this._pro_qtde = value;
            }
        }

        private int _umed_cod;
        public int UmedCod
        {
            get
            {
                return this._umed_cod;
            }
            set
            {
                _umed_cod = value;
            }
        }

        private int _cat_cod;
        public int CatCod
        {
            get
            {
                return this._cat_cod;
            }
            set
            {
               this._cat_cod = value;
            }
        }

        private int _scat_cod;
        public int ScatCod 
        {
            get
            {
                return this._scat_cod;
            }
            set
            {
                this._scat_cod = value ;
            }
        }



    }
}
