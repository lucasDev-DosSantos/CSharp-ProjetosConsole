/*   Progeto Sorteio da Mega-Sena

Fase de desenvolvimento - versão 1.0

OBJETIVOS: 
           1° Gerar 6 números aleatórios com a classe Random
           2° Formatar a data do sorteio com a mesma data atual.
           3° Não permitir números repetidos.
           4° Mostrar o resultado na tela.
*/

Random dice = new Random();

int n1 = dice.Next(1, 61);
int n2 = dice.Next(1, 61);

int n3 = dice.Next(1, 61);
int n4 = dice.Next(1, 61);

int n5 = dice.Next(1, 61);
int n6 = dice.Next(1, 61);

Console.WriteLine($@"Sorteio da mega-sena data xx\xx\xxx
       
        Os números são: {n1} - {n2} - {n3} - {n4} - {n5} - {n6}");