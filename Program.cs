namespace screen_sound_alura
{
    static public class ScreenSound
    {

        static List<string> Bandas { get; set; } = ["Calipso", "Hitsune Miku", "Skillet"];
        static int ResponseDelay = 1500;
        static void Main(string[] args)
        {
            
            Menu();

        }

        static void Menu()
        {
            var run = true;
            while (run)
            {
                ShowGreetings();

                Console.WriteLine("----------------------");
                Console.WriteLine("1 - Registrar banda");
                Console.WriteLine("2 - Mostrar todas as bandas");
                Console.WriteLine("3 - Avaliar banda");
                Console.WriteLine("4 - Exibir média de uma banda");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("----------------------");

                var input = GetUserInputInt();

                Console.Clear();

                switch (input)
                {
                    case 1:
                        RegistrarBanda();
                        break;
                    case 2:
                        MostrarBandas();
                        break;
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

                Console.Clear();
            }

        }

        static void MostrarBandas()
        {
            if (Bandas.Count == 0)
            {
                Console.WriteLine("Não tem bandas para mostrar :<");
                Thread.Sleep(ResponseDelay);
                return;
            }

            ShowTitle("Bandas: ");

            foreach (var banda in Bandas)
            {
                Console.WriteLine($"- {banda}");
            }


            Console.WriteLine("\n(Pressione 'enter' tecla para voltar)");
            Console.ReadLine();
        }

        static void RegistrarBanda()
        {
            ShowTitle("Registro de banda");
            var nomeBanda = GetUserInputStr("Digite o nome da banda: ");

            Bandas.Add(nomeBanda);

            Console.WriteLine($"\nBanda {nomeBanda} registrada com sucesso!");
            Thread.Sleep(ResponseDelay);
        }

        static void ShowGreetings()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("Bem vindo ao Screen Sound!");
            Console.WriteLine("************************************");
        }

        static void ShowTitle(string title)
        {
            Console.WriteLine("************************************");
            Console.WriteLine(title);
        }

        static int GetUserInputInt(string inputText = "")
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

        static string GetUserInputStr(string inputText = "")
        {
            Console.WriteLine(inputText);

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Por favor, digite algo.");
                    continue;
                }

                return input;
            }
        }
    }
}
