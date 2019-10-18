using MySql.Data.MySqlClient;

namespace AppMySqlMvcDAO
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private readonly MySqlConnection Conexao;

        private ConexaoDB()
        {
            Conexao = new MySqlConnection("server=localhost; user id=root; password=1234567; database=dbECOMMERCE");
        }

        public static ConexaoDB ConexaoStatus()
        {
            if(objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }
            return objConexaoDB;
        }

        public MySqlConnection ConexaoPegar()
        {
            return Conexao;
        }

        public void ConexaoFechar()
        {
            objConexaoDB = null;
        }
    }
}
