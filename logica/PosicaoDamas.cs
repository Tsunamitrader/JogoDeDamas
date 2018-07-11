using prova_02.estrutura;

namespace prova_02.logica
{
    class PosicaoDamas {

        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoDamas(char coluna, int linha) {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }

        public override string ToString() {
            return "" + coluna + linha;
        }
    }
}