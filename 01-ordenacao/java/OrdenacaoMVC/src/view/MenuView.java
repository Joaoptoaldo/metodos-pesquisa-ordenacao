package view;

import controller.OrdenacaoController;
import java.util.List;
import java.util.Optional;
import java.util.Scanner;
import model.ResultadoOrdenacao;
import model.algoritmos.IAlgoritmoOrdenacao;

/**
 * Exibe o menu e interage com o usuário via console
 */
public class MenuView {

    private static final int OPCAO_GERAR = 1;
    private static final int OPCAO_MOSTRAR = 2;
    private static final int OPCAO_COMPARAR_TODOS = 3;
    private static final int PRIMEIRA_OPCAO_ALGORITMO = 4;

    private final OrdenacaoController controller;
    private final Scanner scanner;

    public MenuView(OrdenacaoController controller) {
        this.controller = controller;
        this.scanner = new Scanner(System.in);
    }

    public void iniciar() {
        int opcao = 0;

        do {
            exibirMenu();

            String entrada = scanner.nextLine();

            try {
                opcao = Integer.parseInt(entrada);
            } catch (NumberFormatException e) {
                System.out.println("Entrada inválida! Digite um número.");
                continue;
            }

            if (opcao == OPCAO_GERAR) {
                gerarLista();
            } else if (opcao == OPCAO_MOSTRAR) {
                mostrarLista();
            } else if (opcao == OPCAO_COMPARAR_TODOS) {
                compararTodos();
            } else if (opcao >= PRIMEIRA_OPCAO_ALGORITMO &&
                       opcao < PRIMEIRA_OPCAO_ALGORITMO + controller.getAlgoritmos().size()) {
                executarAlgoritmo(opcao - PRIMEIRA_OPCAO_ALGORITMO + 1); // converte nº do menu para índice 1-based
            } else if (opcao == opcaoSair()) {
                System.out.println("Encerrando...");
            } else {
                System.out.println("Opção inválida!");
            }

        } while (opcao != opcaoSair());
    }

    private int opcaoSair() {
        return PRIMEIRA_OPCAO_ALGORITMO + controller.getAlgoritmos().size();
    }

    private void exibirMenu() {
        System.out.println("--- MENU ---");
        System.out.println(OPCAO_GERAR + " - Gerar nova lista");
        System.out.println(OPCAO_MOSTRAR + " - Mostrar lista atual");
        System.out.println(OPCAO_COMPARAR_TODOS + " - Comparar todos os algoritmos (cópia independente)");
        System.out.println(PRIMEIRA_OPCAO_ALGORITMO + " - Ordenar por " + controller.getAlgoritmos().get(0).getNome());

        for (int i = 1; i < controller.getAlgoritmos().size(); i++) {
            System.out.println(PRIMEIRA_OPCAO_ALGORITMO + i + " - Ordenar por " + controller.getAlgoritmos().get(i).getNome());
        }

        System.out.println(opcaoSair() + " - Sair");
        System.out.print("Escolha uma opção: ");
    }

    private void gerarLista() {
        System.out.print("Quantos números deseja gerar? ");
        String entrada = scanner.nextLine();

        int quantidade;
        try {
            quantidade = Integer.parseInt(entrada);
        } catch (NumberFormatException e) {
            System.out.println("Quantidade inválida!");
            return;
        }

        if (quantidade <= 0) {
            System.out.println("Quantidade inválida!");
            return;
        }

        controller.gerarLista(quantidade, 0, 100000);
        System.out.println("Lista gerada com " + quantidade + " números.");
    }

    private void mostrarLista() {
        List<Integer> lista = controller.getLista();

        if (lista.isEmpty()) {
            System.out.println("\nNenhuma lista carregada. Gere uma primeiro.");
            return;
        }

        System.out.println("\nLista atual (" + lista.size() + " itens):");

        for (int item : lista) {
            System.out.println(item);
        }
    }

    /**
     * Método que executa o algoritmo de ordenação pelo índice
     * @param indice1Based índice do algoritmo (1-based)
     */
    private void executarAlgoritmo(int indice1Based) {
        Optional<ResultadoOrdenacao> resultado = controller.executarAlgoritmo(indice1Based);

        if (resultado.isEmpty()) {
            System.out.println("Falha ao executar o algoritmo.");
            return;
        }

        ResultadoOrdenacao r = resultado.get();
        String nomeAlgoritmo = controller.getAlgoritmos().get(indice1Based - 1).getNome();

        System.out.println("\n" + nomeAlgoritmo + ":");
        System.out.println("  Comparações:   " + r.comparacoes());
        System.out.println("  Trocas:        " + r.trocas());
        System.out.println("  Movimentações: " + r.movimentacoes());
        System.out.println("  Tempo (ms):    " + r.tempoMs());
        System.out.println("  Tamanho:       " + r.tamanhoLista());
    }

    private void compararTodos() {
        List<ResultadoOrdenacao> resultados = controller.executarTodosAlgoritmos();

        if (resultados.isEmpty()) {
            System.out.println("\nNenhuma lista carregada. Gere uma primeiro.");
            return;
        }

        System.out.println("\n=== COMPARAÇÃO EXPERIMENTAL (cópia independente) ===");
        System.out.println("Algoritmo                    Comparações   Trocas  Movimentações  Tempo (ms)");
        System.out.println("--------------------------------------------------------------------------------");

        List<IAlgoritmoOrdenacao> algoritmos = controller.getAlgoritmos();
        for (int i = 0; i < algoritmos.size(); i++) {
            String nome = algoritmos.get(i).getNome();
            ResultadoOrdenacao r = resultados.get(i);

            System.out.printf("%-30s %12d %7d %13d %10d%n",
                nome, r.comparacoes(), r.trocas(), r.movimentacoes(), r.tempoMs());
        }
    }
}
