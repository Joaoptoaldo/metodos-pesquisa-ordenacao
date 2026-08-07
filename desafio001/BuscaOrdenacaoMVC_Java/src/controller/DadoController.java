package controller;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import model.Dado;

/**
 * Classe responsável por controlar as operações relacionadas aos dados, 
 * incluindo carregamento de arquivos, ordenação e busca
 */
public class DadoController {

    private List<Dado> dados;

    /**
     * construtor da classe DadoController, inicializa a lista de dados
     */
    public DadoController() {
        dados = new ArrayList<>();
    }


    /**
     * carrega os dados de um arquivo e armazena na lista de dados
     * @param caminho caminho do arquivo de texto a ser carregado
     * @return true se o arquivo foi carregado com sucesso, false caso contrário
     */
    public boolean carregarArquivo(String caminho) {

        dados.clear();

        java.io.File arquivo = new java.io.File(caminho);
        if (!arquivo.exists()) {
            String nome = caminho.endsWith(".txt") ? caminho : caminho + ".txt";
            String[] tentativas = {
                "../Data/" + nome,
                "Data/" + nome
            };
            for (String t : tentativas) {
                java.io.File f = new java.io.File(t);
                if (f.exists()) {
                    caminho = f.getPath();
                    break;
                }
            }
        }

        try (BufferedReader leitor = new BufferedReader(new FileReader(caminho))) {

            String linha;

            while ((linha = leitor.readLine()) != null) {

                if (!linha.trim().isEmpty()) {
                    dados.add(new Dado(linha));
                }

            }
            
            return true;

        } catch (IOException e) {
            return false;
        }

    }

    /**
     * retorna a lista de dados carregados
     * @return lista de dados
     */
    public List<Dado> listarDados() {
        return dados;
    }



    // --- métodos de ordenação e busca ----

    // bubble sort

    /**
     * ordena a lista de dados utilizando o algoritmo Bubble Sort
     */
    public void bubbleSort() {

        int n = dados.size();

        for (int i = 0; i < n - 1; i++) {
            for (int j = 0; j < n - 1 - i; j++) {

                String atual = dados.get(j).getValor();
                String proximo = dados.get(j + 1).getValor();

                if (atual.compareToIgnoreCase(proximo) > 0) {

                    Dado aux = dados.get(j);

                    dados.set(j, dados.get(j + 1));

                    dados.set(j + 1, aux);

                }

            }
        }
    }

    /**
     * realiza uma busca linear na lista de dados para encontrar um dado com o valor especificado
     * @param valor valor a ser buscado
     * @return o dado encontrado ou null se não encontrado
     */
    public Dado buscaLinear(String valor) {

        for (Dado dado : dados) {

            if (dado.getValor().equalsIgnoreCase(valor)) {
                return dado;
            }

        }

        return null;

    }


    // quick sort

    public void quickSort() {
       quickSort(0, dados.size() - 1);
    }

    /**
     * ordena a lista de dados utilizando o algoritmo Quick Sort
     * @param inicio posição inicial do subarray a ser ordenado
     * @param fim posição final do subarray a ser ordenado
     */
    private void quickSort(int inicio, int fim) {

        if (inicio < fim) {

            int pivo = particionar(inicio, fim);

            quickSort(inicio, pivo - 1);

            quickSort(pivo + 1, fim);

        }

    }

    /**
     * particiona a lista de dados em torno de um pivô para o algoritmo Quick Sort
     * @param inicio posição inicial do subarray a ser particionado
     * @param fim posição final do subarray a ser particionado
     * @return a posição do pivô após a partição
     */
    private int particionar(int inicio, int fim) {

        String pivo = dados.get(fim).getValor();

        int i = inicio - 1;

        for (int j = inicio; j < fim; j++) {

            if (dados.get(j).getValor().compareToIgnoreCase(pivo) <= 0) {

                i++;

                Dado aux = dados.get(i);

                dados.set(i, dados.get(j));

                dados.set(j, aux);

            }

        }

        Dado aux = dados.get(i + 1);

        dados.set(i + 1, dados.get(fim));

        dados.set(fim, aux);

        return i + 1;

    }


    // busca binaria

    /**
     * realiza uma busca binária na lista de dados para encontrar um dado com o valor especificado
     * @param valor valor a ser buscado
     * @return o dado encontrado ou null se não encontrado
     */
    public Dado buscaBinaria(String valor) {

        int inicio = 0;

        int fim = dados.size() - 1;

        while (inicio <= fim) {

            int meio = (inicio + fim) / 2;

            int comparacao = dados.get(meio).getValor().compareToIgnoreCase(valor);

            if (comparacao == 0) {
                return dados.get(meio);
            }

            if (comparacao < 0) {
                inicio = meio + 1;
            } else {
                fim = meio - 1;
            }
        }

        return null;
    }

}