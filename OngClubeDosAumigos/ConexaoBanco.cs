using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class ConexaoBanco
    {
        //conectar com o banco de dados // obj de string de conexao // initial catalog é o USE do sql
        string Conexao = "Data Source= localhost; Initial Catalog=ONGClubeDosAumigos; User Id = sa; Password = th031425;";

        public ConexaoBanco()
        {

        }

        public string Caminho()
        {
            return Conexao;
        }
        /*
        #region verifica se o cpf já está cadastrado
        public bool VerificaCPF(string dado, string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = '{dado}'";
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection();
            SqlCommand cmd = new SqlCommand(queryString, conexaosql);

            try
            {
                conexaosql.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        conexaosql.Close();
                        return true;
                    }
                    else
                    {
                        conexaosql.Close();
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                conexaosql.Close();
                Console.WriteLine($"Erro!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar...");
                Console.ReadKey();
                return false;
            }
            #endregion

        }

        
        #region verifica se o animal já está cadastrado
        public bool VerificaChip(string dado, string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = '{dado}'";
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection();
            SqlCommand cmd = new SqlCommand(queryString, conexaosql);

            try
            {
                conexaosql.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        conexaosql.Close();
                        return true;
                    }
                    else
                    {
                        conexaosql.Close();
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                conexaosql.Close();
                Console.WriteLine($"Erro!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar...");
                Console.ReadKey();
                return false;
            }
            #endregion

        }
        */
        #region Método para tratar os dados que serão inseridos no banco pelo usuário
        public string TratamentoDado(string dado)
        {
            string dadoTratado = dado.Replace(".", "").Replace("-", "").Replace("'", "").Replace("]", "").Replace("[", "");
            return dadoTratado;
        }
        #endregion

    }
}
