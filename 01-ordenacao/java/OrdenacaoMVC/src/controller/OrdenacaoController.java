package controller;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Optional;
import model.GeradorLista;
import model.ResultadoOrdenacao;
import model.algoritmos.BubbleSort;
import model.algoritmos.IAlgoritmoOrdenacao;
import model.algoritmos.InsertionSort;
import model.algoritmos.SelectionSort;
import model.algoritmos.SortNativo;

/**
 * Media View e Model. Mantém a lista em memória
 */
public class OrdenacaoController {

    private final List<IAlgoritmoOrdenacao> algoritmos;
    private List<Integer> lista;

    public OrdenacaoController() {
        algoritmos = new ArrayList<>();
        algoritmos.add(new SortNativo());
        algoritmos.add(new BubbleSort());
        algoritmos.add(new SelectionSort());
        algoritmos.add(new InsertionSort());

        lista = new ArrayList<>();
    }

    /**
     * Método que retorna a lista de algoritmos disponíveis
     * @return lista de algoritmos
     */
    public List<IAlgoritmoOrdenacao> getAlgoritmos() {
        return Collections.unmodifiableList(algoritmos);
    }

    /**
     * método que cria uma lista preenchida com números aleatórios
     * @param quantidade quantidade de números a gerar
     * @param minimo mínimo (inclusivo)
     * @param maximo máximo (exclusivo)
     */
    public void gerarLista(int quantidade, int minimo, int maximo) {
        lista = GeradorLista.gerar(quantidade, minimo, maximo);
    }

    /**
     * Método que retorna a lista de números gerada
     * @return lista de números
     */
    public List<Integer> getLista() {
        return Collections.unmodifiableList(lista);
    }

    /**
     * Executa o algoritmo pelo índice (1-based)
     * @return vazio se o índice for inválido
     */
    public Optional<ResultadoOrdenacao> executarAlgoritmo(int indice1Based) {
        int idx = indice1Based - 1; // menu é 1-based, array é 0-based

        if (idx < 0 || idx >= algoritmos.size()) {
            return Optional.empty();
        }

        return Optional.of(algoritmos.get(idx).ordenar(lista));
    }

    /**
     * Executa todos os algoritmos sobre cópias independentes da lista atual.
     * Útil para comparação experimental justa.
     * @return lista de pares (nome do algoritmo, resultado)
     */
    public List<ResultadoOrdenacao> executarTodosAlgoritmos() {
        if (lista.isEmpty()) {
            return List.of();
        }

        List<ResultadoOrdenacao> resultados = new ArrayList<>(algoritmos.size());
        for (IAlgoritmoOrdenacao alg : algoritmos) {
            List<Integer> copia = new ArrayList<>(lista);
            resultados.add(alg.ordenar(copia));
        }
        return resultados;
    }
}
