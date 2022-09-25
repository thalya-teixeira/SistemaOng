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

        public void CadastroAdocao()
        {
            Console.Write("Informe o número de identificação do animal: ");
            Num_Chip = int.Parse(Console.ReadLine());
            Console.Write("Informe o númedo do CPF: ");
            CPF = Console.ReadLine();
            DataAdocao = DateTime.Now;
        }
        #region Visualizar CadastroAdocao
        public void VisualizarAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Num_Chip, CPF, DataAdocao FROM Controle_Adocao";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
              
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            conexaosql.Close();

        }
        #endregion
    }
}
