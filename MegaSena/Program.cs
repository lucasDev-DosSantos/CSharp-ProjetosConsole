/*   Progeto Sorteio da Mega-Sena

Fase de desenvolvimento - versão 1.0

OBJETIVOS: 
           1° Gerar 6 números aleatórios com a classe Random
           2° Formatar a data do sorteio com a  data atual.
           3° Não permitir números repetidos.
           4° Mostrar o resultado na tela.
*/

using System.Net;

internal class Program
{
        private static void Main(string[] args)
        {
                string nome;
                InfoJogo info = new InfoJogo();

                while (true)
                {
                        Console.Clear();
                        info.MostrarTitulo();
                        Console.Write("Bem-vindo apostador! Digite seu nome: ");
                        nome = Console.ReadLine()!;
                        if (string.IsNullOrWhiteSpace(nome))
                        {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nErro: ");
                                Console.ResetColor();
                                Console.WriteLine("Nome inválido. Não pode ser vazio ou só espaços.");
                                Console.ReadKey();
                                continue;
                        }

                        break;
                }

                Menu(info, nome);
        }
        public static void Menu(InfoJogo info, string nome)
        {


                while (true)
                {
                       
                        info.MostrarTitulo();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{nome}, escolha: \n");
                        Console.ResetColor();

                        Console.WriteLine("\n1 - Preço de cada aposta.\n2 - Faça sua aposta.");
                        string? opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                                
                                info.MostrarTitulo();
                                info.MostrarValoresDasApostas();
                                continue;
                        }
                        else if (opcao == "2")
                        {
                                
                                info.MostrarTitulo();
                                Console.ForegroundColor = ConsoleColor.Green;
                                int contador = 0;
                                foreach (string item in info.MostrarCartelaDasApostas())
                                {

                                        Console.Write(item + "  ");
                                        contador++;
                                        if (contador % 10 == 0)
                                        {
                                                Console.WriteLine(); // quebra de linha a cada 10 números
                                        }


                                }
                                Console.ReadKey();
                        }
                        else
                        {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nErro: ");
                                Console.ResetColor();
                                Console.WriteLine("Valor inválido. Escolha uma opção válida");
                                Console.ReadKey();
                        }
                }
        }

        public struct InfoJogo
        {
                public string[] ValoresDasApostas;

                public InfoJogo()
                {
                        ValoresDasApostas = new string[]
                         {
                                "Aposta mínima de 6 números R$5,00",
                                "Aposta com 7 números R$24,50",
                                "Aposta com 8 números R$98,00",
                                "Aposta com 9 números R$735,00",
                                "Aposta com 10 números R$1.617,00",
                                "Aposta com 11 números R$3.234,00",
                                "Aposta com 12 números R$6.006,00",
                                "Aposta com 13 números R$10.510,50",
                                "Aposta com 14 números R$17.517,50",


                         };
                }

                public void MostrarValoresDasApostas()
                {
                        int textoMaior = 0;

                        for (int i = 0; i < ValoresDasApostas.Length; i++)
                        {
                                if (textoMaior < ValoresDasApostas[i].Length)
                                {
                                        textoMaior = ValoresDasApostas[i].Length;
                                }
                        }

                        foreach (string item in ValoresDasApostas)
                        {

                                Console.WriteLine(item);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(new string('-', textoMaior));
                                Console.ResetColor();

                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n⚠ Para voltar ao MENU digite qualquer tecla.");
                        Console.ResetColor();
                        Console.ReadKey();
                }

                public string[] MostrarCartelaDasApostas()
                {
                        string[] cartela = new string[60];
                        for (int i = 0; i < cartela.Length; i++)
                        {
                                cartela[i] = $"[{(i + 1).ToString("D2")}]";
                        }
                        return cartela;
                }

                public void MostrarTitulo()
                {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(" \t\t🍀 MEGA-SENA\n ");
                        Console.ResetColor();
                }
        }

        public static int[] GerarNumerosDoSorteio()
        {
                int[] numero = new int[6];
                Random numeroAleatorio = new Random();
                for (int i = 0; i < numero.Length; i++)
                {
                        numero[i] = numeroAleatorio.Next(1, 61);
                }

                return numero;
        }
}