namespace screen_sound_alura
{
    public class ScreenSound
    {
        static void Main(string[] args)
        {
            ShowGreetings();
            Menu();

        }

        static void ShowGreetings()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Bem vindo ao Screen Sound!");
            Console.WriteLine("************************************");
        }

        static void Menu()
        {
            var run = true;
            while(run)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("1 - Registrar banda");
                Console.WriteLine("2 - Mostrar todas as bandas");
                Console.WriteLine("3 - Avaliar banda");
                Console.WriteLine("4 - Exibir média de uma banda");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("----------------------");

                var input = GetUserInput();

                switch (input)
                {
                    case 1:
                        throw new NotImplementedException();
                    case 2:
                        throw new NotImplementedException();
                    case 3:
                        throw new NotImplementedException();
                    case 4:
                        throw new NotImplementedException();
                    case 0:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            
        }

        static int GetUserInput(string inputText = "")
        {
            Console.WriteLine(inputText);

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Por favor, digite um número.");
                    continue;
                }

                if (!int.TryParse(input, out int value))
                {
                    Console.WriteLine("Por favor, digite um número.");
                    continue;
                }

                return value;
            }
        }
    }
}
