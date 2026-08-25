using OrdenacaoObjetos.Controller;
using OrdenacaoObjetos.Model;

namespace OrdenacaoObjetos.View;

/// <summary>
/// exibe o menu e interage com o usuario
/// </summary>
public class OrdenacaoView
{
    private readonly OrdenacaoController controller;

    public OrdenacaoView(OrdenacaoController controller)
    {
        this.controller = controller;
    }

    /// <summary>
    /// inicia o loop principal do menu
    /// </summary>
    public void Iniciar()
    {
        int opcao;

        do
        {
            ExibirMenu();
            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("Entrada invalida! Digite um numero.\n");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    GerarLista();
                    break;
                case 2:
                    MostrarLista();
                    break;
                case 3:
                    OrdenarLista();
                    break;
                case 4:
                    Console.WriteLine("Encerrando...");
                    break;
                default:
                    Console.WriteLine("Opcao invalida!\n");
                    break;
            }

        } while (opcao != 4);
    }

    private void ExibirMenu()
    {
        Console.WriteLine("--- MENU ---");
        Console.WriteLine("1 - Gerar nova lista");
        Console.WriteLine("2 - Mostrar lista atual");
        Console.WriteLine("3 - Ordenar lista (Bubble Sort por id)");
        Console.WriteLine("4 - Sair");
        Console.Write("Escolha uma opcao: ");
    }


    /// <summary>
    /// gera uma nova lista de processos com a quantidade informada pelo usuario
    /// </summary>
    private void GerarLista()
    {
        Console.Write("Quantos processos deseja gerar? ");
        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade invalida!\n");
            return;
        }

        controller.GerarLista(quantidade);
        Console.WriteLine($"Lista gerada com {quantidade} processos.\n");
    }


    /// <summary>
    /// exibe a lista atual de processos
    /// </summary>
    private void MostrarLista()
    {
        IReadOnlyList<Processo> lista = controller.ObterLista();

        if (lista.Count == 0)
        {
            Console.WriteLine("\nNenhuma lista carregada. Gere uma primeiro.\n");
            return;
        }

        Console.WriteLine($"\nLista atual ({lista.Count} itens):");

        foreach (Processo item in lista)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    /// <summary>
    /// ordena a lista atual de processos e exibe o tempo de execução
    /// </summary>
    private void OrdenarLista()
    {
        IReadOnlyList<Processo> lista = controller.ObterLista();

        if (lista.Count == 0)
        {
            Console.WriteLine("\nNenhuma lista carregada. Gere uma primeiro.\n");
            return;
        }

        Console.WriteLine("\nOrdenando...");

        // medir tempo de execucao
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        controller.Ordenar();
        stopwatch.Stop();

        Console.WriteLine($"Ordenacao concluida em {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine("\nLista ordenada pelo id:");

        foreach (Processo item in controller.ObterLista())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }
}
