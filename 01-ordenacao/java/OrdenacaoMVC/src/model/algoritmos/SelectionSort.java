package model.algoritmos;

import model.ResultadoOrdenacao;
import java.util.List;

/**
 * Selection Sort
 * Seleciona o menor do trecho restante e coloca na posição correta
 */
public class SelectionSort implements IAlgoritmoOrdenacao {

    @Override
    public String getNome() {
        return "Selection Sort";
    }

    @Override
    public ResultadoOrdenacao ordenar(List<Integer> lista) {
        long comparacoes = 0;
        long trocas = 0;
        int posMenor;
        int tmp;

        long inicio = System.nanoTime();

        for (int i = 0; i < lista.size() - 1; i++) {
            posMenor = i;
            for (int j = i + 1; j < lista.size(); j++) {
                comparacoes++;
                if (lista.get(j) < lista.get(posMenor)) {
                    posMenor = j;
                }
            }
            if (i != posMenor) {
                trocas++;
                tmp = lista.get(i);
                lista.set(i, lista.get(posMenor));
                lista.set(posMenor, tmp);
            } // troca só se a posição mudou (evita contar troca consigo mesmo)
        }

        long tempoMs = (System.nanoTime() - inicio) / 1_000_000;

        return new ResultadoOrdenacao(comparacoes, trocas, 0, tempoMs, lista.size());
    }
}
