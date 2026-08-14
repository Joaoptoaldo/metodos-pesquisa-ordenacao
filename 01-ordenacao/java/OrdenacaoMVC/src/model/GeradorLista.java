package model;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 * Gera listas de inteiros para entrada dos algoritmos
 */
public final class GeradorLista {

    private GeradorLista() {
    }

    /**
     * Método que cria uma lista preenchida com números aleatórios
     * @param quantidade números a gerar
     * @param minimo mínimo (inclusivo)
     * @param maximo máximo (exclusivo)
     */
    public static List<Integer> gerar(int quantidade, int minimo, int maximo) {
        List<Integer> lista = new ArrayList<>(quantidade);
        Random gerador = new Random();

        for (int i = 0; i < quantidade; i++) {
            lista.add(gerador.nextInt(minimo, maximo));
        }

        return lista;
    }
}
