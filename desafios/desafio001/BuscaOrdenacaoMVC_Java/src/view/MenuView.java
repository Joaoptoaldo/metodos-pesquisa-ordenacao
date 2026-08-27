package view;

import controller.DadoController;
import java.util.List;
import java.util.Scanner;
import model.Dado;

/**
 * Classe responsável por exibir o menu e interagir com o usuário
 */
public class MenuView {
    private DadoController controller;

    Scanner scanner = new Scanner(System.in);

    /**
     * construtor da classe MenuView
     * @param controller instância do controlador de dados
     */
    public MenuView(DadoController controller) {
        this.controller = controller;
    }

    public void iniciar() {

        int opcao;

        do {
            exibirMenu();

            opcao = scanner.nextInt();
            scanner.nextLine();

            switch (opcao) {
                case 1:
                    carregarArquivo();
                    break;

                case 2:
                    mostrarDados();
                    break;

                case 3:
                    controller.bubbleSort();
                    mostrarDados("\nDados ordenados com Bubble Sort:");
                    break;

                case 4:
                    controller.quickSort();
                    mostrarDados("\nDados ordenados com Quick Sort:");
                    break;
                
                case 5:
                    buscarLinear();
                    break;
                
                case 6:
                    buscarBinaria();
                    break;

                case 7:
                    System.out.println("Encerrando...");
                    break;

                default:
                    System.out.println("Opção inválida!");

            }

        } while (opcao != 7);

    }

    
    private void exibirMenu() {
        System.out.println("--- MENU ---");
        System.out.println("1 - Carregar arquivo");
        System.out.println("2 - Mostrar dados");
        System.out.println("3 - Ordenar (Bubble Sort)");
        System.out.println("4 - Ordenar (Quick Sort)");
        System.out.println("5 - Buscar (Linear)");
        System.out.println("6 - Buscar (Binária)");
        System.out.println("7 - Sair");
        System.out.print("Escolha uma opção: ");

    }

    /**
     * carrega os dados de um arquivo de texto e armazena na lista de dados
     */
    private void carregarArquivo() {
        System.out.print("Informe o caminho do arquivo: ");
        String caminho = scanner.nextLine();

        if (controller.carregarArquivo(caminho)) {
            System.out.println("Arquivo carregado com sucesso!");
        } else {
            System.out.println("Erro ao ler o arquivo!");
        }

    }

    /**
     * mostra os dados carregados na tela
     */
    private void mostrarDados() {
        mostrarDados("\nDados carregados:");
    }

    private void mostrarDados(String titulo) {

        List<Dado> dados = controller.listarDados();

        if (dados.isEmpty()) {

            System.out.println("\nNenhum dado carregado");
            return;

        }

        System.out.println(titulo);

        for (Dado dado : dados) {
            System.out.println(dado);
        }

    }


    /**
     * método para buscar um valor na lista de dados utilizando busca linear
     */
    private void buscarLinear() {

    System.out.print("Informe o valor para busca linear: ");
    String valor = scanner.nextLine();

    Dado resultado = controller.buscaLinear(valor);

        if (resultado != null) {
            System.out.println("Valor encontrado: " + resultado.getValor());
        } else {
            System.out.println("Valor não encontrado");
        }

    }

    /**
     * método para buscar um valor na lista de dados utilizando busca binária
     */
    private void buscarBinaria() {

    System.out.print("Informe o valor para busca binária: ");
    String valor = scanner.nextLine();

    Dado resultado = controller.buscaBinaria(valor);

        if (resultado != null) {
            System.out.println("Valor encontrado: " + resultado.getValor());
        } else {
            System.out.println("Valor não encontrado");
        }

    }
}