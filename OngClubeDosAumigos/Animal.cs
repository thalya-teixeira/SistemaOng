using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class Animal
    {
        public int Num_Chip { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
       
        public Animal()
        {

        }

        public Animal(int num_chip, string familia, string raca, char sexo, string nome)
        {
            this.Num_Chip = num_chip;
            this.Familia = familia;
            this.Raca = raca;
            this.Sexo = sexo;
            this.Nome = nome;
        }

        public void CadastrarAnimal()
        {
            Console.Clear();
            Console.WriteLine(">>> CADASTRO DO ANIMAL <<<");
            //CHIP NUM
            Console.Write("Informe a família [cachorro, gato, papagaio...]: ");
            Familia = Console.ReadLine();
            Console.Write("Informe a raça: ");
            Raca = Console.ReadLine();
            Console.Write("Informe [F] para feminino ou [M] para masculino: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.Write("Informe o nome: ");
            Nome = Console.ReadLine();

        }

        #region INSERIR ADOTANTE 
        public void InserirAanimal()
        {
            //Adotante adotante = new Adotante();
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            //busca ou define o meu comando, no caso inserir
            cmd.CommandText = "INSERT INTO Adotante(Num_Chip, Familia, Raca, Sexo, Nome) VALUES (@Num_Chip, @Familia, @Raca, @Sexo, @Nome);";

            cmd.Parameters.Add(new SqlParameter("@Num_Chip", this.Num_Chip));
            cmd.Parameters.Add(new SqlParameter("@Familia", this.Familia));
            cmd.Parameters.Add(new SqlParameter("@Raca", this.Raca));
            cmd.Parameters.Add(new SqlParameter("@Sexo", this.Sexo));
            cmd.Parameters.Add(new SqlParameter("@Nome", this.Nome));

            Console.WriteLine(cmd.CommandText);
            Console.WriteLine("\n\nAQUI FOI");
            Console.ReadKey();

            cmd.Connection = conexaosql;
            //DANDO ERRO 
            cmd.ExecuteNonQuery();

            conexaosql.Close();
        }
        #endregion

        #region Visualizar Animal
        public void VisualizarAnimal()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Num_Chip, Familia, Raca, Sexo, Nome FROM Animal";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetString(3));
                    Console.WriteLine("{0}", reader.GetString(4));
                    
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            conexaosql.Close();

        }
        #endregion
    }
}
