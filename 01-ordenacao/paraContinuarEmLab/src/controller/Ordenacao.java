package controller;

import java.util.ArrayList;

public class Ordenacao {

    /**
     * Método de ordenação bolha/bubble sort
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdTrocas
     */
    public static ArrayList bolha(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long qtdComparacoes = 0;
        long qtdTrocas = 0;
        int aux;
        boolean houveTroca;
        int i;
        do {
            houveTroca = false;
            for (i = 0; i < lista.size() - 1; i++) {
                qtdComparacoes++;
                if (lista.get(i) > lista.get(i + 1)) {
                    houveTroca = true;
                    aux = lista.get(i);
                    lista.set(i, lista.get(i + 1));
                    lista.set(i + 1, aux);
                    qtdTrocas++;
                }
            }
        } while (houveTroca);
        metricas.add((float)qtdComparacoes);
        metricas.add((float)qtdTrocas);
        return metricas;
    }


    /**
     * Método de ordenação por seleção
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdTrocas
     */
    public static ArrayList selecao(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long qtdComparacoes = 0;
        long qtdTrocas = 0;
        int i, j, posMenor, aux;
        // posMenor = 0; removido, será definido no loop

        for (i = 0; i < lista.size(); i++) {
            posMenor = i;
            for (j = i+1; j < lista.size(); j++) {
                qtdComparacoes++;
                if (lista.get(j) < lista.get(posMenor)) {
                    posMenor = j;
                }
            }
            // CORREÇÃO: swap deve estar DENTRO do loop externo (i), não fora
            if (posMenor != i) {
                aux = lista.get(i);
                lista.set(i, lista.get(posMenor));
                lista.set(posMenor, aux);
                qtdTrocas++;
            }
        }
        metricas.add((float)qtdComparacoes);
        metricas.add((float)qtdTrocas);
        return metricas;
    }

    /**
     * Método de ordenação por inserção
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdTrocas
     */
    public static ArrayList insercao(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long qtdComparacoes = 0;
        long qtdTrocas = 0;
        int i, j, aux;

        for (i = 1; i < lista.size(); i++) {
            aux = lista.get(i);
            // CORREÇÃO: j >= 0 (não j > 0) para comparar com lista.get(0)
            // CORREÇÃO: conta a comparação que falha (quando aux >= lista.get(j))

            for (j = i-1; j >= 0; j--, qtdComparacoes++) {
                if (aux < lista.get(j)) {
                    qtdTrocas++;
                    lista.set(j+1, lista.get(j));
                } else {
                    break; // achou posição correta
                }
            }
            lista.set(j+1, aux);
        }
        metricas.add((float)qtdComparacoes);
        metricas.add((float)qtdTrocas);
        return metricas;
    }

    /**
     * Método de ordenação pente
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdTrocas
     */
    public static ArrayList pente(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long qtdComparacoes = 0;
        long qtdTrocas = 0;
        int aux;
        boolean houveTroca;
        int i;
        int distancia = lista.size();
        do {
            distancia = (int)(distancia/1.3);
            if (distancia <= 0) {
                distancia = 1;
            }
            houveTroca = false;
            for (i = 0; i + distancia < lista.size(); i++) {
                qtdComparacoes++;
                if (lista.get(i) > lista.get(i + distancia)) {
                    houveTroca = true;
                    aux = lista.get(i);
                    lista.set(i, lista.get(i + distancia));
                    lista.set(i + distancia, aux);
                    qtdTrocas++;
                }
            }
        } while (distancia > 1 || houveTroca);
        metricas.add((float)qtdComparacoes);
        metricas.add((float)qtdTrocas);
        return metricas;
    }

    /**
     * Método de ordenação mergesort
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdMovimentacoes
     */
    public static ArrayList mergesort(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long[] contadores = new long[2]; // [0] = comparações, [1] = trocas/movimentações
        if (lista.size() > 1) {
            mergesortRecursivo(lista, 0, lista.size() - 1, contadores);
        }
        metricas.add((float)contadores[0]);
        metricas.add((float)contadores[1]);
        return metricas;
    }

    /**
     * Método auxiliar recursivo do mergesort
     * @param lista ArrayList a ser ordenado
     * @param inicio índice inicial da sublista
     * @param fim índice final da sublista
     * @param contadores array com contadores [0] = comparações, [1] = movimentações
     */
    private static void mergesortRecursivo(ArrayList<Integer> lista, int inicio, int fim, long[] contadores) {
        if (inicio < fim) {
            int meio = (inicio + fim) / 2;
            mergesortRecursivo(lista, inicio, meio, contadores);
            mergesortRecursivo(lista, meio + 1, fim, contadores);
            merge(lista, inicio, meio, fim, contadores);
        }
    }

    /**
     * Método auxiliar que mescla duas sublistas ordenadas
     * @param lista ArrayList contendo as sublistas
     * @param inicio índice inicial da primeira sublista
     * @param meio índice final da primeira sublista
     * @param fim índice final da segunda sublista
     * @param contadores array com contadores [0] = comparações, [1] = movimentações
     */
    private static void merge(ArrayList<Integer> lista, int inicio, int meio, int fim, long[] contadores) {
        int i = inicio;
        int j = meio + 1;
        int k = 0;
        ArrayList<Integer> temp = new ArrayList<>();

        while (i <= meio && j <= fim) {
            contadores[0]++; // comparação
            if (lista.get(i) <= lista.get(j)) {
                temp.add(lista.get(i));
                i++;
            } else {
                temp.add(lista.get(j));
                j++;
            }
            contadores[1]++; // movimentação (elemento colocado no temp)
        }

        while (i <= meio) {
            temp.add(lista.get(i));
            i++;
            contadores[1]++;
        }

        while (j <= fim) {
            temp.add(lista.get(j));
            j++;
            contadores[1]++;
        }

        // Copia de volta para a lista original
        for (k = 0; k < temp.size(); k++) {
            lista.set(inicio + k, temp.get(k));
        }
    }

    /**
     * Método de ordenação quicksort
     * @param lista ArrayList a ser ordenado
     * @return ArrayList com métricas: [0] = qtdComparacoes, [1] = qtdTrocas
     */
    public static ArrayList quicksort(ArrayList<Integer> lista) {
        ArrayList<Float> metricas = new ArrayList<>();
        long[] contadores = new long[2]; // [0] = comparações, [1] = trocas
        if (lista.size() > 1) {
            quicksortRecursivo(lista, 0, lista.size() - 1, contadores);
        }
        metricas.add((float)contadores[0]);
        metricas.add((float)contadores[1]);
        return metricas;
    }

    /**
     * Método auxiliar recursivo do quicksort
     * @param lista ArrayList a ser ordenado
     * @param inicio índice inicial da sublista
     * @param fim índice final da sublista
     * @param contadores array com contadores [0] = comparações, [1] = trocas
     */
    private static void quicksortRecursivo(ArrayList<Integer> lista, int inicio, int fim, long[] contadores) {
        if (inicio < fim) {
            int pivoIndex = particao(lista, inicio, fim, contadores);
            quicksortRecursivo(lista, inicio, pivoIndex - 1, contadores);
            quicksortRecursivo(lista, pivoIndex + 1, fim, contadores);
        }
    }

    /**
     * Método auxiliar que particiona a lista para o quicksort
     * @param lista ArrayList a ser particionado
     * @param inicio índice inicial da sublista
     * @param fim índice final da sublista (posição do pivô)
     * @param contadores array com contadores [0] = comparações, [1] = trocas
     * @return índice final do pivô após particionamento
     */
    private static int particao(ArrayList<Integer> lista, int inicio, int fim, long[] contadores) {
        int pivo = lista.get(fim); // pivô no final (Lomuto)
        int i = inicio - 1;
        int aux;

        for (int j = inicio; j < fim; j++) {
            contadores[0]++; // comparação
            if (lista.get(j) <= pivo) {
                i++;
                if (i != j) {
                    aux = lista.get(i);
                    lista.set(i, lista.get(j));
                    lista.set(j, aux);
                    contadores[1]++; // troca
                }
            }
        }

        // Troca o pivô com o elemento na posição correta
        if (i + 1 != fim) {
            aux = lista.get(i + 1);
            lista.set(i + 1, lista.get(fim));
            lista.set(fim, aux);
            contadores[1]++; // troca
        }
        return i + 1;
    }
}
