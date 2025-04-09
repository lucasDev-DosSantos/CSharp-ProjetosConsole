internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        Console.Clear();
        string titulo = @"█▓▒▒░░░ Calculadora ░░░▒▒▓█";
        string Menssagem = "\n1 - Soma\t2 - Subtração\t3 - Divisão\t4 - Multiplicação\t0 - Sair";
        Console.WriteLine(titulo.PadLeft(Menssagem.Length));
        Console.WriteLine("Escolha uma das operação abaixo:\n" + Menssagem + "\n");

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
                Environment.Exit(0);
                break;
            default:

                Menu();
                break;

        }

    }

    // Cada método abaixo, corresponde a sua respectiva operação matemática.
    static void Somar()
    {
        Console.Clear();
        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 + numero2;
        Console.WriteLine($"A soma de {numero1} + {numero2} = {resultado}");
        Console.ReadKey();
        Menu();
    }

    static void Subtrair()
    {
        Console.Clear();
        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 - numero2;
        Console.WriteLine($"A diferença de {numero1} - {numero2} = {resultado}");
        Console.ReadKey();
        Menu();
    }

    static void Dividir()
    {
        Console.Clear();
        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        if (numero2 == 0)
        {
            Console.WriteLine("Erro: Divisão por zero não é permitida.");
        }
        else
        {
            double resultado = numero1 / numero2;
            Console.WriteLine($"A divisão de {numero1} / {numero2} = {resultado}");
        }
        Console.ReadKey();
        Menu();
    }

    static void Multiplicar()
    {
        Console.Clear();
        double numero1 = LerNumero("Digite o primeiro valor:");
        double numero2 = LerNumero("Digite o segundo valor:");
        double resultado = numero1 * numero2;
        Console.WriteLine($"A multiplicação de {numero1} x {numero2} = {resultado}");
        Console.ReadKey();
        Menu();
    }

    
    // Este método válida a entrada dos números para o cálculo.
    static double LerNumero(string mensagem)
    {
        double numero;
        Console.WriteLine(mensagem);
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
        }
        return numero;
    }
}