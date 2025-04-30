using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.Clear();

            string titulo = @"█▓▒▒░░░ Calculadora ░░░▒▒▓█";
            string Mensagem = "\n1 - Soma\t2 - Subtração\t3 - Divisão\t4 - Multiplicação\t0 - Sair";

            Console.WriteLine(titulo.PadLeft(Mensagem.Length));
            Console.WriteLine("Escolha uma das operação abaixo:\n" + Mensagem + "\n");

            string escolhaDoUsuario = Console.ReadLine()!;

            switch (escolhaDoUsuario)
            {
                case "1":
                    Somar();
                    break;
                case "2":
                    Subtrair();
                    break;
                case "3":
                    Dividir();
                    break;
                case "4":
                    Multiplicar();
                    break;
                case "0":
                    Console.Clear();
                    Console.WriteLine("O programa será encerrado...");
                    Thread.Sleep(1000);
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }

        }
    }

    // Cada método abaixo, corresponde a sua respectiva operação matemática.
    static void Somar()
    {
        Console.Clear();
        Console.WriteLine("🔢 Operação de Soma");
        Console.WriteLine(new string('-', 40));

        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 + numero2;

        Console.WriteLine($"A soma de {numero1} + {numero2} = {resultado}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();

    }

    static void Subtrair()
    {
        Console.Clear();
        Console.WriteLine("🔢 Operação de subtração");
        Console.WriteLine(new string('-', 40));

        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 - numero2;

        Console.WriteLine($"A diferença de {numero1} - {numero2} = {resultado}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();

    }

    static void Dividir()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🔢 Operação de Divisão");
            Console.WriteLine(new string('-', 40));

            double numero1 = LerNumero("Digite o primeiro valor:");
            double numero2 = LerNumero("Digite o segundo valor:");
            if (numero2 == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro: Divisão por zero não é permitida.\n\t***** {numero1} / {numero2} *****");
                Console.ResetColor();
                Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
                continue; // Volta ao início do loop

            }

            double resultado = numero1 / numero2;
            Console.WriteLine($"A divisão de {numero1} / {numero2} = {resultado}");
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            return;
        }
    }

    static void Multiplicar()
    {
        Console.Clear();
        Console.WriteLine("🔢 Operação de Multiplicação");
        Console.WriteLine(new string('-', 40));

        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 * numero2;

        Console.WriteLine($"A multiplicação de {numero1} x {numero2} = {resultado}");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();

    }


    // Este método válida a entrada dos números para o cálculo.
    static double LerNumero(string mensagem)
    {
        double numero;
        Console.WriteLine(mensagem);
        while (!double.TryParse(Console.ReadLine()!.Replace('.', ','), out numero))
        {
            Console.Clear();
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
        return numero;
    }
}