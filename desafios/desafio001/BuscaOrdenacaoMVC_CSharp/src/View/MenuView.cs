using BuscaOrdenacaoMVC_CSharp.Controller;
using BuscaOrdenacaoMVC_CSharp.Model;

namespace BuscaOrdenacaoMVC_CSharp.View;

public class MenuView
{
    private DadoController controller;

    public MenuView(DadoController controller)
    {
        this.controller = controller;
    }

    public void Iniciar()
    {
        int opcao;

        do
        {
            ExibirMenu();

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("Entrada inválida! Digite um número");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CarregarArquivo();
                    break;

                case 2:
                    MostrarDados();
                    break;

                case 3:
                    controller.BubbleSort();
                    MostrarDados("\nDados ordenados com Bubble Sort:");
                    break;

                case 4:
                    controller.QuickSort();
                    MostrarDados("\nDados ordenados com Quick Sort:");
                    break;

                case 5:
                    BuscarLinear();
                    break;

                case 6:
                    BuscarBinaria();
                    break;

                case 7:
                    Console.WriteLine("Encerrando...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (opcao != 7);
    }

    private void ExibirMenu()
    {
        Console.WriteLine("--- MENU ---");
        Console.WriteLine("1 - Carregar arquivo");
        Console.WriteLine("2 - Mostrar dados");
        Console.WriteLine("3 - Ordenar (Bubble Sort)");
        Console.WriteLine("4 - Ordenar (Quick Sort)");
        Console.WriteLine("5 - Buscar (Linear)");
        Console.WriteLine("6 - Buscar (Binária)");
        Console.WriteLine("7 - Sair");
        Console.Write("Escolha uma opção: ");
    }


    /// <summary>
    /// método que carrega os dados de um arquivo informado pelo usuário, 
    /// chamando o método CarregarArquivo do controller e exibindo mensagens de sucesso ou erro
    /// </summary>
    private void CarregarArquivo()
    {
        Console.Write("Informe o caminho do arquivo: ");
        string? caminho = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(caminho))
        {
            // chama o método CarregarArquivo do controller, passando o caminho informado pelo usuário
            if (controller.CarregarArquivo(caminho))
            {
                Console.WriteLine("Arquivo carregado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao ler o arquivo!");
            }
        }
        else
        {
            Console.WriteLine("Caminho inválido!");
        }
    }

    /// <summary>
    /// método que exibe os dados carregados
    /// </summary>
    /// <param name="titulo">título a ser exibido antes dos dados</param>
    private void MostrarDados(string titulo = "\nDados carregados:")
    {
        List<Dado> dados = controller.ListarDados();

        if (dados.Count == 0)
        {
            Console.WriteLine("\nNenhum dado carregado");
            return;
        }

        Console.WriteLine(titulo);

        foreach (Dado dado in dados)
        {
            Console.WriteLine(dado);
        }
    }

    /// <summary>
    /// método que realiza uma busca linear por um valor informado pelo usuário
    /// </summary>
    private void BuscarLinear()
    {
        Console.Write("Informe o valor para busca linear: ");
        string? valor = Console.ReadLine();

        // chama o método de busca linear do controller
        Dado? resultado = controller.BuscaLinear(valor ?? "");

        if (resultado != null)
        {
            Console.WriteLine("Valor encontrado: " + resultado.Valor);
        }
        else
        {
            Console.WriteLine("Valor não encontrado");
        }
    }

    /// <summary>
    /// método que realiza uma busca binária por um valor informado pelo usuário, 
    /// assumindo que os dados estão ordenados
    /// </summary>
    private void BuscarBinaria()
    {
        Console.Write("Informe o valor para busca binária: ");
        string? valor = Console.ReadLine();

        Dado? resultado = controller.BuscaBinaria(valor ?? "");

        if (resultado != null)
        {
            Console.WriteLine("Valor encontrado: " + resultado.Valor);
        }
        else
        {
            Console.WriteLine("Valor não encontrado");
        }
    }
}
