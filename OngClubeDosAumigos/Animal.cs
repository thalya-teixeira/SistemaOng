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
        public string Sexo { get; set; }
        public string Nome { get; set; }
       
        public Animal()
        {

        }

        public Animal(int num_chip, string familia, string raca, string sexo, string nome)
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
            
            ConexaoBanco conn = new ConexaoBanco();

            do
            {
                Console.Write("Informe a família [cachorro, gato, papagaio...]: ");
                Familia = Console.ReadLine();
                if (Familia.Length == 0)
                {
                    Console.WriteLine("Campo obrigatório!");
                }
                if (Familia.Length > 30)
                {
                    Console.WriteLine("Informe um nome de família com menos de 50 caracteres!");
                }
            } while (Familia.Length > 30 || Familia.Length == 0);

            do
            {
                Console.Write("Informe a raça: ");
                Raca = Console.ReadLine();
                if (Raca.Length == 0)
                {
                    Console.WriteLine("Raça opcional!");
                }
                if (Raca.Length > 30)
                {
                    Console.WriteLine("Informe uma raça com menos de 50 caracteres!");
                }
            } while (Raca.Length > 30 || Raca.Length == 0);

            do
            {

                Console.Write("Informe [F] para feminino ou [M] para masculino: ");
                Sexo = conn.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            do
            {
                Console.Write("Informe o nome: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome opcional!");
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Informe nome com menos de 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);

        }

        #region INSERIR ADOTANTE 
        public void InsertAnimal()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Animal(Familia, Raca, Sexo, Nome) VALUES (@Familia, @Raca, @Sexo, @Nome)";

            cmd.Parameters.Add(new SqlParameter("@Familia", this.Familia));
            cmd.Parameters.Add(new SqlParameter("@Raca", this.Raca));
            cmd.Parameters.Add(new SqlParameter("@Sexo", this.Sexo));
            cmd.Parameters.Add(new SqlParameter("@Nome", this.Nome));

            cmd.Connection = conexaosql;
            cmd.ExecuteNonQuery();

            conexaosql.Close();
        }
        #endregion

        #region Visualizar Animal
        public void SelectAnimal()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Num_Chip, Familia, Raca, Sexo, Nome FROM Animal";
            cmd.Connection = conexaosql;

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

        #region Editar Animal
        public void UpdateAdotante()
        {
            Console.Clear();
            Console.Write("Digite o nome que deseja alterar o contato: ");
            string alt = Console.ReadLine();
            ConexaoBanco conn = new ConexaoBanco();


            do
            {
                Console.Write("Informe a família [cachorro, gato, papagaio...]: ");
                Familia = Console.ReadLine();
                if (Familia.Length == 0)
                {
                    Console.WriteLine("Campo obrigatório!");
                }
                if (Familia.Length > 30)
                {
                    Console.WriteLine("Informe um nome de família com menos de 50 caracteres!");
                }
            } while (Familia.Length > 30 || Familia.Length == 0);

            do
            {
                Console.Write("Informe a raça: ");
                Raca = Console.ReadLine();
                if (Raca.Length == 0)
                {
                    Console.WriteLine("Raça opcional!");
                }
                if (Raca.Length > 30)
                {
                    Console.WriteLine("Informe uma raça com menos de 50 caracteres!");
                }
            } while (Raca.Length > 30 || Raca.Length == 0);

            do
            {

                Console.Write("Informe [F] para feminino ou [M] para masculino: ");
                Sexo = conn.TratamentoDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");

            do
            {
                Console.Write("Informe o nome: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome opcional!");
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Informe nome com menos de 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);


            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = ("UPDATE Adotante SET Familia = @Familia, Raca = @Raca, Sexo = @Sexo, Nome = @Nome WHERE Nome = @Novo;");

            SqlParameter novo = new SqlParameter("@Novo", System.Data.SqlDbType.VarChar, 50);
            SqlParameter familia = new SqlParameter("@Familia", System.Data.SqlDbType.VarChar, 50);
            SqlParameter raca = new SqlParameter("@Raca", System.Data.SqlDbType.VarChar, 50);
            SqlParameter sexo = new SqlParameter("@Sexo", System.Data.SqlDbType.Date);
            SqlParameter nome = new SqlParameter("@Nome", System.Data.SqlDbType.Char, 1);

            novo.Value = alt;
            familia.Value = Familia;
            raca.Value = Raca;
            sexo.Value = Sexo;
            nome.Value = Nome;

            cmd.Parameters.Add(novo);
            cmd.Parameters.Add(familia);
            cmd.Parameters.Add(raca);
            cmd.Parameters.Add(sexo);
            cmd.Parameters.Add(nome);

            cmd.Connection = conexaosql;
            cmd.ExecuteNonQuery();

            conexaosql.Close();
        }
#endregion
    }
}
