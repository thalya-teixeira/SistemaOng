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
        public string Sexo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }


        public Adotante(string cpf, string n, string sexo, DateTime data, string tel, string logra, string num, string compl, string b, string cid, string es)
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
        #region Cadastrar Adotante
        public void CadastrarAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();

            Console.Clear();
            Console.WriteLine(">>> CADASTRO DO ADOTANTE <<<");

            do
            {
                Console.Write("Digite seu CPF: ");
                CPF = conn.TratamentoDado(Console.ReadLine());
                if (CPF == "0")
                    return;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                }
            } while (!ValidaCPF(CPF));

            do
            {
                Console.Write("\nInforme seu nome completo: ");
                Nome = Console.ReadLine();
                if(Nome.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if(Nome.Length > 50)
                {
                    Console.WriteLine("Informe um nome com menos de 50 caracteres!");
                }
            } while (Nome.Length > 50 || Nome.Length == 0);
          

            do
            {
                Console.Write("Sexo [F] Feminino [M] Masculino [N] Prefere não informar: ");
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
                Console.Write("Data de nascimento: ");
                DataNasc = DateTime.Parse(Console.ReadLine());
                if(DataNasc  )
                {

                }
            } while ();

            do
            {
                Console.Write("Informe o seu telefone para contato: ");
                Telefone = Console.ReadLine();
                if (Telefone.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if (Telefone.Length > 50)
                {
                    Console.WriteLine("Informe um nome com menos de 50 caracteres!");
                }
            } while (Telefone.Length > 50 || Nome.Length == 0);


                       
            Console.Write("Logradouro: ");
            Logradouro= Console.ReadLine();
            Console.Write("Número da residência: ");
            Numero = Console.ReadLine();
            Console.Write("Complemento se houve: ");
            Complemento = Console.ReadLine();
            Console.Write("Bairro: ");
            Bairro = Console.ReadLine();
            Console.Write("Cidade: ");
            Cidade = Console.ReadLine();
            Console.Write("Estado [Ex: SP]: ");
            Estado = Console.ReadLine();
            
           
        }
        #endregion

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
        public void SelectAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
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

        #region Editar Adotante
        public void UpdateAdotante()
        {
            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            //ver se está chamando
            //Console.WriteLine(conn.Caminho());
            conexaosql.Open();

            SqlCommand cmd = new SqlCommand();

            //fazer um switch para escolher o dado a partir do cpf
            //fazer um select pra achar o cpf e alterar dados

            conexaosql.Close();
        }
        #endregion


        #region Método Para Validar o CPF 
        private static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        #endregion
    }

}
