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
            bool validacao = false;

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
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if (Nome.Length > 50)
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

                try
                {
                    DataNasc = DateTime.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Formato de data inválido [dd/mm/aaaa]");
                    validacao = true;
                }
                if (DataNasc > DateTime.Now)
                {
                    Console.WriteLine("Data de aniversário não pode ser futura!");
                    validacao = true;
                }

            } while (validacao);

            do
            {
                Console.Write("Informe o seu telefone para contato: ");
                Telefone = Console.ReadLine();
                if (Telefone.Length == 0)
                {
                    Console.WriteLine("Telefone obrigatório!");
                }
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("Informe um telefone com menos de 11 caracteres!");
                }
            } while (Telefone.Length > 11 || Telefone.Length == 0);

            do
            {
                Console.Write("Logradouro: ");
                Logradouro = Console.ReadLine();
                if (Logradouro.Length == 0)
                {
                    Console.WriteLine("Logradouro obrigatório!");
                }
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("Informe um logradouro com menos de 50 caracteres!");
                }
            } while (Logradouro.Length > 50 || Logradouro.Length == 0);

            do
            {
                Console.Write("Número da residência: ");
                Numero = Console.ReadLine();
                if (Numero.Length == 0)
                {
                    Console.WriteLine("Número obrigatório!");
                }
                if (Numero.Length > 10)
                {
                    Console.WriteLine("Informe um número com menos de 10 caracteres!");
                }
            } while (Numero.Length > 10 || Numero.Length == 0);

            do
            {
                //verificar se tem ou nao complemento

                Console.Write("Complemento: ");
                Complemento = Console.ReadLine();
                if (Complemento.Length == 0)
                {
                    Console.WriteLine("Complemento obrigatório!");
                }
                if (Complemento.Length > 10)
                {
                    Console.WriteLine("Informe um complemento com menos de 10 caracteres!");
                }
            } while (Complemento.Length > 10 || Logradouro.Length == 0);

            do
            {
                Console.Write("Bairro: ");
                Bairro = Console.ReadLine();
                if (Bairro.Length == 0)
                {
                    Console.WriteLine("Bairro obrigatório!");
                }
                if (Bairro.Length > 50)
                {
                    Console.WriteLine("Informe nome de bairro com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Cidade: ");
                Cidade = Console.ReadLine();
                if (Cidade.Length == 0)
                {
                    Console.WriteLine("Cidade obrigatório!");
                }
                if (Cidade.Length > 50)
                {
                    Console.WriteLine("Informe nome de cidade com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Estado [Ex: SP]: ");
                Estado = Console.ReadLine();
                if (Estado.Length == 0)
                {
                    Console.WriteLine("Estado obrigatório!");
                }
                if (Estado.Length > 2)
                {
                    Console.WriteLine("Informe apenas 2 caracter para estado!");
                }
            } while (Estado.Length > 2 || Estado.Length == 0);



        }
        #endregion

        public override string ToString()
        {
            return $"\nCPF: {this.CPF} \nNome: {this.Nome} \nSexo: {this.Sexo} \nData de Nascimento {this.DataNasc} \nTelefone: {this.Telefone} \nLogradouro: {this.Logradouro} \nNúmero:" +
                $"{this.Numero} \nComplemento: {this.Complemento} \nBairro: {this.Bairro} \nCidade {this.Cidade} \nEstado {this.Estado}";
        }

        #region INSERIR ADOTANTE 
        public void InsertAdotante()
        {

            ConexaoBanco conn = new ConexaoBanco();
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();
            SqlCommand cmd = new SqlCommand();

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
            cmd.Connection = conexaosql;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader.GetString(0));
                    Console.WriteLine("{0}", reader.GetString(1));
                    Console.WriteLine("{0}", reader.GetString(2));
                    Console.WriteLine("{0}", reader.GetDateTime(3));
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
            Console.Clear();
            Console.Write("Digite o nome que deseja alterar o contato: ");
            string alt = Console.ReadLine();
            bool validacao = false;
            ConexaoBanco conn = new ConexaoBanco();

            do
            {
                Console.Write("\nNome: ");
                Nome = Console.ReadLine();
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Nome obrigatório!");
                }
                if (Nome.Length > 50)
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

                try
                {
                    DataNasc = DateTime.Parse(Console.ReadLine());
                    validacao = false;
                }
                catch (Exception)
                {

                    Console.WriteLine("Formato de data inválido [dd/mm/aaaa]");
                    validacao = true;
                }
                if (DataNasc > DateTime.Now)
                {
                    Console.WriteLine("Data de aniversário não pode ser futura!");
                    validacao = true;
                }

            } while (validacao);

            do
            {
                Console.Write("Informe o seu telefone para contato: ");
                Telefone = Console.ReadLine();
                if (Telefone.Length == 0)
                {
                    Console.WriteLine("Telefone obrigatório!");
                }
                if (Telefone.Length > 11)
                {
                    Console.WriteLine("Informe um telefone com menos de 11 caracteres!");
                }
            } while (Telefone.Length > 11 || Telefone.Length == 0);

            do
            {
                Console.Write("Logradouro: ");
                Logradouro = Console.ReadLine();
                if (Logradouro.Length == 0)
                {
                    Console.WriteLine("Logradouro obrigatório!");
                }
                if (Logradouro.Length > 50)
                {
                    Console.WriteLine("Informe um logradouro com menos de 50 caracteres!");
                }
            } while (Logradouro.Length > 50 || Logradouro.Length == 0);

            do
            {
                Console.Write("Número da residência: ");
                Numero = Console.ReadLine();
                if (Numero.Length == 0)
                {
                    Console.WriteLine("Número obrigatório!");
                }
                if (Numero.Length > 10)
                {
                    Console.WriteLine("Informe um número com menos de 10 caracteres!");
                }
            } while (Numero.Length > 10 || Numero.Length == 0);

            do
            {
                //verificar se tem ou nao complemento

                Console.Write("Complemento: ");
                Complemento = Console.ReadLine();
                if (Complemento.Length == 0)
                {
                    Console.WriteLine("Complemento obrigatório!");
                }
                if (Complemento.Length > 10)
                {
                    Console.WriteLine("Informe um complemento com menos de 10 caracteres!");
                }
            } while (Complemento.Length > 10 || Logradouro.Length == 0);

            do
            {
                Console.Write("Bairro: ");
                Bairro = Console.ReadLine();
                if (Bairro.Length == 0)
                {
                    Console.WriteLine("Bairro obrigatório!");
                }
                if (Bairro.Length > 50)
                {
                    Console.WriteLine("Informe nome de bairro com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Cidade: ");
                Cidade = Console.ReadLine();
                if (Cidade.Length == 0)
                {
                    Console.WriteLine("Cidade obrigatório!");
                }
                if (Cidade.Length > 50)
                {
                    Console.WriteLine("Informe nome de cidade com menos de 50 caracteres!");
                }
            } while (Bairro.Length > 50 || Bairro.Length == 0);

            do
            {
                Console.Write("Estado [Ex: SP]: ");
                Estado = Console.ReadLine();
                if (Estado.Length == 0)
                {
                    Console.WriteLine("Estado obrigatório!");
                }
                if (Estado.Length > 2)
                {
                    Console.WriteLine("Informe apenas 2 caracter para estado!");
                }
            } while (Estado.Length > 2 || Estado.Length == 0);

           
            SqlConnection conexaosql = new SqlConnection(conn.Caminho());
            conexaosql.Open();
            SqlCommand cmd = new SqlCommand();

            
            cmd.CommandText = ("UPDATE Adotante SET Nome = @Nome, Sexo = @Sexo, DataNasc = @DataNasc, Telefone = @Telefone, Logradouro = @Logradouro, Numero = @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado WHERE Nome = @Novo;");

            SqlParameter novo = new SqlParameter("@Novo", System.Data.SqlDbType.VarChar, 50);
            SqlParameter nome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter datanasc = new SqlParameter("@DataNasc", System.Data.SqlDbType.Date);
            SqlParameter sexo = new SqlParameter("@Sexo", System.Data.SqlDbType.Char, 1);
            SqlParameter telefone = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar, 11);
            SqlParameter logradouro = new SqlParameter("@Logradouro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter numero = new SqlParameter("@Numero", System.Data.SqlDbType.VarChar, 10);
            SqlParameter complemento = new SqlParameter("@Complemento", System.Data.SqlDbType.VarChar, 10);
            SqlParameter bairro = new SqlParameter("@Bairro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter cidade = new SqlParameter("@Cidade", System.Data.SqlDbType.VarChar, 50);
            SqlParameter es = new SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 2);

            novo.Value = alt;
            nome.Value = Nome;
            datanasc.Value = DataNasc;
            sexo.Value = Sexo;
            telefone.Value = Telefone;
            logradouro.Value = Logradouro;
            numero.Value = Numero;
            complemento.Value = Complemento;
            bairro.Value = Bairro;
            cidade.Value = Cidade;
            es.Value = Estado;

            cmd.Parameters.Add(novo);
            cmd.Parameters.Add(nome);
            cmd.Parameters.Add(datanasc);
            cmd.Parameters.Add(sexo);
            cmd.Parameters.Add(telefone);
            cmd.Parameters.Add(logradouro);
            cmd.Parameters.Add(numero);
            cmd.Parameters.Add(complemento);
            cmd.Parameters.Add(bairro);
            cmd.Parameters.Add(cidade);
            cmd.Parameters.Add(es);


            cmd.Connection = conexaosql;
            cmd.ExecuteNonQuery();

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
