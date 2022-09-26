using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class Controle_Adocao
    {
        public int Num_Chip { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdocao { get; set; }

        public Controle_Adocao(int num_Chip, string cpf, DateTime date)
        {
            Num_Chip = num_Chip;
            CPF = cpf;
            DataAdocao = date;
        }

        public Controle_Adocao()
        {

        }

        #region Cadastrar Adoçao
        public void CadastroAdocao()
        {
            Console.Clear();
            Console.Write("Informe o número de identificação do animal: ");
            Num_Chip = int.Parse(Console.ReadLine());
            Console.Write("Informe o númedo do CPF: ");
            CPF = Console.ReadLine();
            DataAdocao = DateTime.Now;
        }
        #endregion

        #region INSERIR ADOÇÃO 
        public void InsertAdocao()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexaosql;

            cmd.CommandText = "INSERT INTO Controle_Adocao(Num_Chip, CPF, DataAdocao) VALUES (@Num_Chip, @CPF, @DataAdocao)";

            cmd.Parameters.Add(new SqlParameter("@Num_Chip", this.Num_Chip));
            cmd.Parameters.Add(new SqlParameter("@CPF", this.CPF));
            cmd.Parameters.Add(new SqlParameter("@DataAdocao", this.DataAdocao));

            cmd.ExecuteNonQuery();

            conexaosql.Close();
        }
        #endregion

        #region Visualizar CadastroAdocao
        public void VisualizarAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Num_Chip, CPF, DataAdocao FROM Controle_Adocao";
            cmd.Connection = conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetDateTime(2));

                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            conexaosql.Close();

        }
        #endregion



    }
}
