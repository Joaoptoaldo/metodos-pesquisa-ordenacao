package model.algoritmos;

import model.ResultadoOrdenacao;
import java.util.Collections;
import java.util.List;

/**
 * Sort nativo (Collections.sort)
 * Usa TimSort internamente. Métricas de comparações/trocas ficam zeradas
 * pois a API não as expõe
 */
public class SortNativo implements IAlgoritmoOrdenacao {

    @Override
    public String getNome() {
        return "Sort nativo (Collections.sort)";
    }

    @Override
    public ResultadoOrdenacao ordenar(List<Integer> lista) {
        long inicio = System.nanoTime();

        Collections.sort(lista);

        long tempoMs = (System.nanoTime() - inicio) / 1_000_000;

        return new ResultadoOrdenacao(0, 0, 0, tempoMs, lista.size());
    }
}
