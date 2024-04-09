namespace screen_sound_alura
{
    static public class ScreenSound
    {

        static Dictionary<string, List<int>> Bandas { get; set; } = new()
        {
            { "Calypso", [10] },
            { "Skillet", [10] },
            { "Hatsune Miko", [10] }
        };
        const int ResponseDelay = 1500;
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
                        AvaliarBanda();
                        break;
                    case 4:
                        ExibirMediaBanda();
                        break;
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

        static void ExibirMediaBanda()
        {
            if (Bandas.Count == 0)
            {
                Console.WriteLine("Não tem bandas para ver a média :<");
                Wait();
                return;
            }

            ShowTitle("Escolha uma banda para ver a média: ");

            ListarBandas();

            var nomeBanda = GetUserInputStr();

            if (!Bandas.ContainsKey(nomeBanda))
            {
                Console.Clear();
                Console.WriteLine("Banda não encontrada!");
                Wait();
                return;
            }

            var media = (float) Bandas[nomeBanda].Average();

            Console.WriteLine($"\nA média da banda selecionada ({nomeBanda}) é: {media}");
            Wait();
        }

        static void AvaliarBanda()
        {
            if (Bandas.Count == 0)
            {
                Console.WriteLine("Não tem bandas para avaliar :<");
                Wait();
                return;
            }

            ShowTitle("Escolha uma banda para avaliar: ");

            ListarBandas();

            var nomeBanda = GetUserInputStr();

            if (!Bandas.ContainsKey(nomeBanda))
            {
                Console.Clear();
                Console.WriteLine("Banda não encontrada!");
                Wait();
                return;
            }

            while (true)
            {
                var nota = GetUserInputInt($"{nomeBanda} selecionada. Digite uma nota:");

                if (nota < 0)
                {
                    Console.WriteLine("A nota não pode ser menor que zero!");
                    continue;
                }
                if (nota > 10)
                {
                    Console.WriteLine("A nota não pode ser maior que dez!");
                    continue;
                }

                Bandas[nomeBanda].Add(nota);

                Console.WriteLine("\nNota adicionada com sucesso!");

                Wait();
                return;
            }
        }

        static void MostrarBandas()
        {
            if (Bandas.Count == 0)
            {
                Console.WriteLine("Não tem bandas para mostrar :<");
                Wait();
                return;
            }

            ShowTitle("Bandas: ");

            ListarBandas();


            Console.WriteLine("\n(Pressione 'enter' tecla para voltar)");
            Console.ReadLine();
        }

        static void ListarBandas()
        {
            foreach (var banda in Bandas.Keys)
            {
                Console.WriteLine($"- {banda}");
            }
        }

        static void RegistrarBanda()
        {
            ShowTitle("Registro de banda");
            var nomeBanda = GetUserInputStr("Digite o nome da banda: ");

            Bandas.Add(nomeBanda, []);

            Console.WriteLine($"\nBanda {nomeBanda} registrada com sucesso!");
            Wait();
        }

        static void Wait(int time = ResponseDelay)
        {
            Thread.Sleep(time);
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
            Console.Write(inputText);

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
            Console.Write(inputText);

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
