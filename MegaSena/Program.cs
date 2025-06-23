using System;
using System.Collections.Generic;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }

    public struct InfoJogo
    {
        public string NomeDoApostador;
        public const char SAIR = '0';
        public const char OPCAO_VER_PRECOS = '1';
        public const char OPCAO_FAZER_APOSTA = '2';
        public const char SORTEIO = '3';

        private int[] QuantidadesDeNumeros;
        private decimal[] ValoresDasApostas;

        public InfoJogo()
        {
            NomeDoApostador = " ";

            QuantidadesDeNumeros = new int[]
            {
                6, 7, 8, 9, 10, 11, 12, 13, 14
            };

            ValoresDasApostas = new decimal[]
            {
                5.00M,
                24.50M,
                98.00M,
                735.00M,
                1617.00M,
                3234.00M,
                6006.00M,
                10510.50M,
                17517.50M
            };
        }

        public void MostrarTitulo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" \t\t🍀 MEGA-SENA\n ");
            Console.ResetColor();
        }

        public void MostrarValoresDasApostas()
        {
            int textoMaior = 0;
            MostrarTitulo();
            string[] linhas = new string[QuantidadesDeNumeros.Length];

            for (int i = 0; i < QuantidadesDeNumeros.Length; i++)
            {
                linhas[i] = $"Aposta com {QuantidadesDeNumeros[i]} números {ValoresDasApostas[i]:C}";
                if (linhas[i].Length > textoMaior)
                    textoMaior = linhas[i].Length;
            }

            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('-', textoMaior));
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚠ Para voltar ao MENU digite qualquer tecla.");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void MostrarCartelaDasApostas(List<ushort> numeros)
        {
            MostrarTitulo();
            int contador = 0;

            for (int i = 1; i <= 60; i++)
            {
                if (numeros.Contains((ushort)i))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.Write($"[{i.ToString("D2")}] ");
                contador++;

                if (contador % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.ResetColor();
        }
    }

    public static InfoJogo TelaInicial()
    {
        InfoJogo info = new InfoJogo();

        while (true)
        {
            info.MostrarTitulo();
            Console.Write("Bem-vindo apostador! Digite seu nome: ");
            string nome = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nErro: ");
                Console.ResetColor();
                Console.WriteLine("Nome inválido! O nome não pode ser vazio ou só conter espaços.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Tente novamente.");
                Console.ResetColor();
                Thread.Sleep(2000);
                continue;
            }

            info.NomeDoApostador = nome;
            break;
        }
        return info;
    }

    public static void Menu()
    {
        InfoJogo info = TelaInicial();
        List<ushort> apostaUsuario = new List<ushort>();

        while (true)
        {
            Console.Clear();
            info.MostrarTitulo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{info.NomeDoApostador}, escolha: \n");
            Console.ResetColor();

            Console.WriteLine($"\n{InfoJogo.OPCAO_VER_PRECOS} - Preço de cada aposta.");
            Console.WriteLine($"{InfoJogo.OPCAO_FAZER_APOSTA} - Faça sua aposta.");
            Console.WriteLine($"{InfoJogo.SORTEIO} - Realizar o sorteio");
            Console.WriteLine($"{InfoJogo.SAIR} - Sair\n");

            ConsoleKeyInfo tecla = Console.ReadKey(true);

            switch (tecla.KeyChar)
            {
                case InfoJogo.OPCAO_VER_PRECOS:
                    info.MostrarValoresDasApostas();
                    break;

                case InfoJogo.OPCAO_FAZER_APOSTA:
                    apostaUsuario = Aposta(info);
                    break;

                case InfoJogo.SORTEIO:
                    if (apostaUsuario.Count <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Você ainda não fez uma aposta.");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;
                    }
                    GerarNumerosDoSorteio(info, apostaUsuario);
                    break;

                case InfoJogo.SAIR:
                    Console.WriteLine($"Ok, {info.NomeDoApostador}! Até a próxima. Tchau!!");
                    Thread.Sleep(2000);
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }
        }
    }

    public static List<ushort> Aposta(InfoJogo info)
    {
        List<ushort> apostaDoUsuario = new List<ushort>();

        while (apostaDoUsuario.Count < 14)
        {
            info.MostrarCartelaDasApostas(apostaDoUsuario);
            Console.WriteLine("\nEscolha os números de sua aposta!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Aposta mínima de 6 números e aposta máxima 14 números.\n");
            Console.ResetColor();

            Console.Write($"Número {apostaDoUsuario.Count + 1}: ");
            bool sucesso = ushort.TryParse(Console.ReadLine(), out ushort resultado);
            if (!sucesso || resultado < 1 || resultado > 60)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ Valor inválido. Escolha números entre 1 e 60.");
                Console.ResetColor();
                Thread.Sleep(2000);
                continue;
            }

            if (apostaDoUsuario.Contains(resultado))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("⚠ Número repetido. Escolha outro.");
                Console.ResetColor();
                Thread.Sleep(2000);
                continue;
            }

            apostaDoUsuario.Add(resultado);
            apostaDoUsuario.Sort();

            MostrarNumerosEscolhidos(apostaDoUsuario);
            info.MostrarCartelaDasApostas(apostaDoUsuario);

            if (apostaDoUsuario.Count >= 6 && apostaDoUsuario.Count < 14)
            {
                while (true)
                {
                    Console.Write("\nDeseja adicionar mais números? (S/N): ");
                    string escolha = Console.ReadLine()!.Trim().ToUpper();

                    if (escolha == "S")
                    {
                        break;
                    }
                    else if (escolha == "N")
                    {
                        return apostaDoUsuario;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Erro: Valor inválido! Digite apenas S ou N.");
                        Console.ResetColor();
                    }
                }
            }

            if (apostaDoUsuario.Count == 14)
            {
                Console.WriteLine("✅ Você atingiu o limite máximo de 14 números.");
                Thread.Sleep(1500);
                break;
            }
        }

        return apostaDoUsuario;
    }

    public static void MostrarNumerosEscolhidos(List<ushort> numeros)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (ushort numero in numeros)
        {
            Console.Write($"[{numero.ToString("D2")}] ");
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void GerarNumerosDoSorteio(InfoJogo info, List<ushort> apostaUsuario)
    {
        List<ushort> numerosSorteados = new List<ushort>();
        Random sorteio = new Random();

        while (numerosSorteados.Count < 6)
        {
            ushort novoNumero = (ushort)sorteio.Next(1, 61);
            if (!numerosSorteados.Contains(novoNumero))
            {
                numerosSorteados.Add(novoNumero);
            }
        }

        Console.Clear();
        info.MostrarTitulo();

        Console.WriteLine("\n🎰 Números Sorteados:");
        MostrarNumerosEscolhidos(numerosSorteados);

        Console.WriteLine("\n🎯 Sua Aposta:");
        MostrarNumerosEscolhidos(apostaUsuario);

        int acertos = apostaUsuario.Intersect(numerosSorteados).Count();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n✅ Você acertou {acertos} número(s)!");
        Console.ResetColor();

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}
