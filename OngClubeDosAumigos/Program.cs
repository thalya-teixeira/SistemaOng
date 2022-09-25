using System;

namespace OngClubeDosAumigos
{
    internal class Program
    {
        static void Menu()
        {
            int op;
            Console.WriteLine("Informe a opção que deseja realizar");
            Console.WriteLine("\n1 - Cadastrar Adotante");
            Console.WriteLine("\n2 - Cadastrar Animal");
            Console.WriteLine("\n3 - Registrar Adoção");
            Console.WriteLine("\n4 - Editar Cadastrar Adotante");
            Console.WriteLine("\n5 - Editar Cadastrar Animal");
            Console.WriteLine("\n0 - SAIR");
            //Console.WriteLine("\n1 - Lista de Animais disponívels para adoção");
            op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 0:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Adotante adotante = new Adotante();
            adotante.CadastrarAdotante();
            adotante.InserirAdotante();


        }
    }
}
