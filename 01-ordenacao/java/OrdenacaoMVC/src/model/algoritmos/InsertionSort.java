package model.algoritmos;

import model.ResultadoOrdenacao;
import java.util.List;

/**
 * Insertion Sort
 * Insere cada elemento na posição correta do trecho já ordenado à esquerda
 */
public class InsertionSort implements IAlgoritmoOrdenacao {

    @Override
    public String getNome() {
        return "Insertion Sort";
    }

    @Override
    public ResultadoOrdenacao ordenar(List<Integer> lista) {
        long comparacoes = 0;
        long movimentacoes = 0;
        int i, j;
        int tmp;

        long inicio = System.nanoTime();

        for (i = 1; i < lista.size(); i++) {
            tmp = lista.get(i);
            for (j = i - 1; j >= 0; j--) {
                comparacoes++;
                if (tmp < lista.get(j)) {
                    lista.set(j + 1, lista.get(j)); // shift: arrastar maior para a direita
                    movimentacoes++;
                } else break; // posição correta encontrada, para de deslocar
            }
            lista.set(j + 1, tmp);
            movimentacoes++; // conta a reinserção do tmp como mais um deslocamento
        }

        long tempoMs = (System.nanoTime() - inicio) / 1_000_000;

        return new ResultadoOrdenacao(comparacoes, 0, movimentacoes, tempoMs, lista.size());
    }
}
