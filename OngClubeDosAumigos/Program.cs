using System;

namespace OngClubeDosAumigos
{
    internal class Program
    {
        static void Menu()
        {
            string op;
            do
            {

                Console.WriteLine("\n°°°°°°°°°° BEM VINDO A ONG CLUBE DOS AUMIGOS °°°°°°°°°");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("|°°°°°°°°°°°°°°°°°°°°°°  MENU  °°°°°°°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : Cadastrar Adotante                       |");
                Console.WriteLine("|   opção 2 : Cadastrar Animal                         |");
                Console.WriteLine("|   opção 3 : Registrar Adoção                         |");
                Console.WriteLine("|   opção 4 : Editar Cadastro Adotante                 |");
                Console.WriteLine("|   opção 5 : Editar Cadastro Animal                   |");
                Console.WriteLine("|   opção 6 : Visualizar Cadastro Adotante             |");
                Console.WriteLine("|   opção 7 : Visualizar Cadastro Animais              |");
                Console.WriteLine("|   opção 8 : Visualizar Controle de Adoção            |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");
         
                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7" && op != "8" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }
            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6" && op != "7" && op != "8");
            Adotante cadAdotante = new();
            Animal cadAnimal = new();
            Controle_Adocao controleAdocao = new();

            switch (op)
            {

                case "1":
                    cadAdotante.CadastrarAdotante();
                    cadAdotante.InsertAdotante();
                    Menu();
                    break;

                case "2":
                    cadAnimal.CadastrarAnimal();
                    cadAnimal.InsertAnimal();
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    controleAdocao.CadastroAdocao();
                    controleAdocao.InsertAdocao();
                    Console.Clear();
                    Menu();
                    break;

                case "4":
                    cadAdotante.UpdateAdotante();
                    Console.Clear();
                    Menu();
                    break;

                case "5":
                    cadAnimal.UpdateAnimal();
                    Console.Clear();
                    Menu();
                    break;

                case "6":
                    cadAdotante.SelectAdotante();
                    Console.Clear();
                    Menu();
                    break;

                case "7":
                    cadAnimal.SelectAnimal();
                    Console.Clear();
                    Menu();
                    break;

                case "8":
                    controleAdocao.VisualizarAdotante();
                    Console.Clear();
                   // Menu();
                    break;

                case "0":
                    break;
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
