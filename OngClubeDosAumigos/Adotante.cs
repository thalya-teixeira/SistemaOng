using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class Adotante
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public Adotante(string cpf, string n, char sexo, DateTime data, string tel, string logra, string num, string compl, string b, string cid, string es)
        {
            this.CPF = cpf;
            this.Nome = n;
            this.Sexo = sexo;
            this.DataNasc = data;
            this.Telefone = tel;
            this.Logradouro = logra;
            this.Numero = num;
            this.Complemento = compl;
            this.Bairro = b;
            this.Cidade = cid;
            this.Estado = es;

        }

        public Adotante()
        {

        }

        public void CadastrarAdotante()
        {
            Console.Clear();
            Console.WriteLine(">>> CADASTRO DO ADOTANTE <<<");
            Console.Write("\nInforme seu nome completo: ");
            Nome = Console.ReadLine();
            Console.Write("Informe o seu CPF: ");
            CPF = Console.ReadLine();
            Console.Write("Informe [F] para feminino ou [M] para masculino: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.Write("Informe sua data de nascimento: ");
            DataNasc = DateTime.Parse(Console.ReadLine());
            Console.Write("Informe o seu telefone para contato: ");
            Telefone = Console.ReadLine();            
            Console.Write("Informe o logradouro: ");
            Logradouro= Console.ReadLine();
            Console.Write("Informe o número da residência: ");
            Numero = Console.ReadLine();
            Console.Write("Informe o complemento se houve: ");
            Complemento = Console.ReadLine();
            Console.Write("Informe o nome do bairro: ");
            Bairro = Console.ReadLine();
            Console.Write("Informe o nome da cidade: ");
            Cidade = Console.ReadLine();
            Console.Write("Informe o nome do estado [Exemplo: SP]: ");
            Estado = Console.ReadLine();
            
           
        }

        public override string ToString()
        {
            return $"\nCPF: {this.CPF} \nNome: {this.Nome} \nSexo: {this.Sexo} \nData de Nascimento {this.DataNasc} \nTelefone: {this.Telefone} \nLogradouro: {this.Logradouro} \nNúmero:" +
                $"{this.Numero} \nComplemento: {this.Complemento} \nBairro: {this.Bairro} \nCidade {this.Cidade} \nEstado {this.Estado}"; 
        }

        #region INSERIR ADOTANTE 
        public void InserirAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            //busca ou define o meu comando, no caso inserir
            cmd.CommandText = "INSERT INTO Adotante(CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado) VALUES (@CPF, @Nome, @Sexo, @DataNasc, @Telefone, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado);";
            cmd.Connection = conexaosql;

            cmd.Parameters.Add(new SqlParameter("@CPF", this.CPF));
            cmd.Parameters.Add(new SqlParameter("@Nome", this.Nome));
            cmd.Parameters.Add(new SqlParameter("@Sexo", this.Sexo));
            cmd.Parameters.Add(new SqlParameter("@DataNasc", this.DataNasc));
            cmd.Parameters.Add(new SqlParameter("@Telefone", this.Telefone));
            cmd.Parameters.Add(new SqlParameter("@Logradouro", this.Logradouro));
            cmd.Parameters.Add(new SqlParameter("@Numero", this.Numero));
            cmd.Parameters.Add(new SqlParameter("@Complemento", this.Complemento));
            cmd.Parameters.Add(new SqlParameter("@Bairro", this.Bairro));
            cmd.Parameters.Add(new SqlParameter("@Cidade", this.Cidade));
            cmd.Parameters.Add(new SqlParameter("@Estado", this.Estado));
            
            cmd.ExecuteNonQuery();

            conexaosql.Close();
        }
        #endregion

        #region Visualizar Adotante
        public void VisualizarAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado FROM Adotante";

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetInt32(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetString(3));
                    Console.WriteLine("{0}", reader.GetString(4));
                    Console.WriteLine("{0}", reader.GetString(5));
                    Console.WriteLine("{0}", reader.GetString(6));
                    Console.WriteLine("{0}", reader.GetString(7));
                    Console.WriteLine("{0}", reader.GetString(8));
                    Console.WriteLine("{0}", reader.GetString(9));
                    Console.WriteLine("{0}", reader.GetString(10));
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            conexaosql.Close();

        }
        #endregion

        #region Busca os Adotantes
        public void BuscarAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            Console.Write("Informe o CPF que deseja buscar: ");
            CPF = Console.ReadLine();
            //busca ou define o meu comando, no caso inserir
            cmd.CommandText = "SELECT CPF, Nome, Sexo, DataNasc, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado FROM Adotante WHERE cpf = @cpf;";
            cmd.Connection = conexaosql;
        }

        #endregion
    }
}
