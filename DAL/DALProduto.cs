using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;


namespace DAL
{
    public class DALProduto
    {
        
        private DALConexao conexao;
        public DALProduto(DALConexao cx)
        {
            conexao = cx;
        }
        public void Incluir(ModeloProdutos modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();      //cria sqlcommand / comando  
                cmd.Connection = conexao.ObjetoConexao;     //cria a conexao.
                cmd.CommandText = "insert into produto (pro_nome, pro_descricao, pro_foto, pro_valorpago, pro_valorvenda, pro_qtde, umed_cod, cat_cod, scat_cod) " +
                "values (@nome, @descricao, @foto, @valorpago, @valorvenda, @qtde, @undmedcod, @catcod, @scatcod); select @@IDENTITY; ";
                cmd.Parameters.AddWithValue("@nome", modelo.ProNome);        //PARAMETRO nome RECEBE O VALOR ProNome                (AddWithValue = Adiciona parado ja com devido valor)
                cmd.Parameters.AddWithValue("@descricao", modelo.ProDescricao);//PARAMETRO ProDescricao RECEBE O VALOR ProDescricao
                ////PARAMETRO foto RECEBE imagem))))- Tipo de parrametro, oque ele representa, representa uma IMAGEM, System.DATA.SqlDbType reseprenta Image
                cmd.Parameters.AddWithValue("@foto", System.Data.SqlDbType.Image);  //PARAMETRO foto RECEBE imagem.


                if (modelo.ProFoto == null)        //Se pro foto == NULL - Se ele nao informou nenhuma foto
                {
                    //FAZ PARAMETRO FOTO receber valor NULL 
                    cmd.Parameters["@foto"].Value = DBNull.Value;
                }
                else
                {
                    //FAZ PARAMETRO FOTO RECEBER O VALOR DA FOTO
                    cmd.Parameters["@foto"].Value = modelo.ProFoto;
                }

                cmd.Parameters.AddWithValue("@valorpago", modelo.ProValorPago);
                cmd.Parameters.AddWithValue("@valorvenda", modelo.ProValorVenda);
                cmd.Parameters.AddWithValue("@qtde", modelo.ProQtde);
                cmd.Parameters.AddWithValue("@undmedcod", modelo.UmedCod);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
            
                conexao.Conectar();

                modelo.ProCod = Convert.ToInt32(cmd.ExecuteScalar());

                conexao.Desconectar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }   

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = " delete from produto where (pro_cod) = (@codigo)";
                cmd.Parameters.AddWithValue("codigo", codigo);

                conexao.Conectar();

                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }   
        }

        public void Alterar(ModeloProdutos modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = " update produto SET pro_nome = (@nome), pro_descricao = (@descricao), pro_foto = (@foto)," +
                "pro_valorpago = (@valorpago), pro_valorvenda = (@valorvenda), pro_qtde = (@qtde), umed_cod, (@undmed_cod)," +
                "cat_cod = (@catcod), scat_cod = (@scatcod), WHERE pro_cod = (@codigo) ";
                cmd.Parameters.AddWithValue("@nome", modelo.ProNome);
                cmd.Parameters.AddWithValue("@descricao", modelo.ProDescricao);
                cmd.Parameters.Add("foto", System.Data.SqlDbType.Image);        //System.Data.SqlDbType == Representa imagem

                if (modelo.ProFoto == null)    //FOTO == NULL (Não existir foto)
                {
                    cmd.Parameters["@foto"].Value = DBNull.Value;       //ADICIONA VALOR == NULL
                }
                else
                {
                    cmd.Parameters["@foto"].Value = modelo.ProFoto;     //ADICIONA VALOR == CONTIDO DENTRO DE FOTO
                }

                cmd.Parameters.AddWithValue("@valorpago", modelo.ProValorPago);     // "@Valorpago" RECEBE ProValorPago
                cmd.Parameters.AddWithValue("@valorvenda", modelo.ProValorVenda);
                cmd.Parameters.AddWithValue("@qtde", modelo.ProQtde);
                cmd.Parameters.AddWithValue("@undmedcod", modelo.UmedCod);
                cmd.Parameters.AddWithValue("@catcod", modelo.CatCod);
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
                cmd.Parameters.AddWithValue("@codigo", modelo.ProCod);

                conexao.Conectar();

                cmd.ExecuteNonQuery();                             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Desconectar();
            }            
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();     //cria novo DataTable
            SqlDataAdapter dataDapter = new SqlDataAdapter("select p.pro_cod, p.pro_nome, p.pro_descricao, p.pro_foto, p.pro_valorpago, " + 
            " p.pro_valorvenda, p.pro_qtde, p.umed_cod, p.cat_cod, p.scat_cod, u.umed_nome, c.cat_nome, sc.scat_nome from produto p inner join " + 
            " undmedida u on p.umed_cod = u.umed_cod inner join categoria c on p.cat_cod = c.cat_cod inner join subcategoria sc on p.scat_cod = sc.scat_cod " + 
            " where pro_nome like '%" + valor + "%'", conexao.StringConexao);  //Onde seja parercido com o valor //informa stirng de conexao
            dataDapter.Fill(tabela);
        
            return tabela;

            //O SqlDataAdapter, serve como uma ponte entre a DataSet e SQL Server para recuperar e salvar dados.
            //O SqlDataAdapter fornece essa ponte por mapeamento Fill !
        }

        public ModeloProdutos CarregaModeloProdutos(int codigo)
        {
            ModeloProdutos modelo = new ModeloProdutos();       
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from produto where ( pro_cod) = " + codigo.ToString(); //seja igual ao codigo informado

            conexao.Conectar();

            SqlDataReader registro = cmd.ExecuteReader();       //cria DataReader com base no comando executado 

            if (registro.HasRows)
            {
                registro.Read();
                modelo.ProCod = Convert.ToInt32(registro["pro_cod"]);   //ProCod recebe pro_cod
                modelo.ProNome = Convert.ToString(registro["pro_nome"]);
                modelo.ProDescricao = Convert.ToString(registro["pro_descricao"]);

                try
                {       //TENTE
                    modelo.ProFoto = (byte[])registro["pro_foto"];    //FAZER LEITURA DENTRO DE PRO_FOTO, CASO NAO CONSIGA == NULL
                }
                catch { }   
                
                modelo.ProValorPago = Convert.ToDouble(registro["pro_valorpago"]);
                modelo.ProValorVenda = Convert.ToDouble(registro["pro_valorvenda"]);
                modelo.ProQtde = Convert.ToInt32(registro["pro_qtde"]);
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.ScatCod = Convert.ToInt32(registro["scat_cod"]);                


            }
            conexao.Desconectar();

            return modelo;
        }
    }
}
//40,2