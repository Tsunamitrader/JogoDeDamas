using System.Collections.Generic;
using prova_02.estrutura;
using prova_02.logica;

namespace prova_02.logica
{
    class PartidaDeDamas {

        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool sinuca { get; private set; }
        

        public PartidaDeDamas() {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            sinuca = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }     

            return pecaCapturada; 

        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null) {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);        
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);
            Peca p = tab.peca(destino);
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tab.peca(origem).movimentoPossivel(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }



        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.colocarPeca(peca, new PosicaoDamas(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas() {
            //peças brancas
            colocarNovaPeca('a', 1, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('c', 1, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('e', 1, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('g', 1, new Peao(tab, Cor.Branca));           
            colocarNovaPeca('b', 2, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('d', 2, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('f', 2, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('h', 2, new Peao(tab, Cor.Branca));
            colocarNovaPeca('a', 3, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('c', 3, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('e', 3, new Peao(tab, Cor.Branca));            
            colocarNovaPeca('g', 3, new Peao(tab, Cor.Branca));

            //peças pretas
            
            colocarNovaPeca('b', 8, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('d', 8, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('f', 8, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('h', 8, new Peao(tab, Cor.Preta));
            colocarNovaPeca('a', 7, new Peao(tab, Cor.Preta));           
            colocarNovaPeca('c', 7, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('e', 7, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('g', 7, new Peao(tab, Cor.Preta));
            colocarNovaPeca('b', 6, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('d', 6, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('f', 6, new Peao(tab, Cor.Preta));            
            colocarNovaPeca('h', 6, new Peao(tab, Cor.Preta));
            
        }
    }
}