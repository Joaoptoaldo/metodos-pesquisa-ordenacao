package model.algoritmos;

import java.util.List;
import model.ResultadoOrdenacao;

/**
 * Contrato dos algoritmos de ordenação
 */
public interface IAlgoritmoOrdenacao {

    /**
    * Nome exibido no menu 
    */
    String getNome();

    /**
     * Executa o algoritmo de ordenação na lista fornecida
     * @param lista lista de números a ordenar
     * @return ResultadoOrdenacao métricas da execução
     */
    ResultadoOrdenacao ordenar(List<Integer> lista);
}
