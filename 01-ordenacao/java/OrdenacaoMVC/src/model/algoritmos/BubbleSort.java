package model.algoritmos;

import model.ResultadoOrdenacao;
import java.util.List;

/**
 * Bubble Sort
 * Compara pares adjacentes e troca quando estão fora de ordem
 */
public class BubbleSort implements IAlgoritmoOrdenacao {

    @Override
    public String getNome() {
        return "Bubble Sort";
    }

    @Override
    public ResultadoOrdenacao ordenar(List<Integer> lista) {
        long comparacoes = 0;
        long trocas = 0;
        boolean houveTroca;
        int tmp;

        long inicio = System.nanoTime();

        do {
            houveTroca = false;
            for (int i = 0; i < lista.size() - 1; i++) {
                comparacoes++;
                if (lista.get(i) > lista.get(i + 1)) {
                    trocas++;
                    houveTroca = true;
                    tmp = lista.get(i);
                    lista.set(i, lista.get(i + 1));
                    lista.set(i + 1, tmp);
                }
            }
        } while (houveTroca); // repete enquanto houver troca na passada

        long tempoMs = (System.nanoTime() - inicio) / 1_000_000;

        return new ResultadoOrdenacao(comparacoes, trocas, 0, tempoMs, lista.size());
    }
}
