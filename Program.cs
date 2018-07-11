using System;
using prova_02.estrutura;
using prova_02.logica;

namespace prova_02
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                PartidaDeDamas partida = new PartidaDeDamas();

                while (!partida.terminada) {

                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem(Ex:a3): ");
                        Posicao origem = Tela.lerPosicaoDamas().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino(Ex:b4): ");
                        Posicao destino = Tela.lerPosicaoDamas().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);                        
                    
                    }
                    catch (TabuleiroException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
