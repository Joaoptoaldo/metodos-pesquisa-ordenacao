package model;

/**
 * Métricas de uma execução de ordenação
 *
 * @param comparacoes quantidade de comparações
 * @param trocas quantidade de trocas (swap de dois elementos)
 * @param movimentacoes quantidade de movimentações/deslocamentos (Insertion Sort shifts)
 * @param tempoMs tempo em milissegundos
 * @param tamanhoLista tamanho da lista ordenada
 */
public record ResultadoOrdenacao(// record é imutável, não precisa de getters/setters
        long comparacoes,
        long trocas,
        long movimentacoes,
        long tempoMs,
        int tamanhoLista) {
}
