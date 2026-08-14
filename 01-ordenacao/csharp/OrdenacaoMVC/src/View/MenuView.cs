using OrdenacaoMVC.Controller;
using OrdenacaoMVC.Model;

namespace OrdenacaoMVC.View;

/// <summary>
/// Exibe o menu e interage com o usuário via console
/// Toda a leitura/escrita do programa passa por aqui
///</summary>
public class MenuView
{
    private const int OpcaoGerar = 1;
    private const int OpcaoMostrar = 2;
    private const int OpcaoCompararTodos = 3;
    private const int PrimeiraOpcaoAlgoritmo = 4;

    private readonly OrdenacaoController controller;

    public MenuView(OrdenacaoController controller)
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
                Console.WriteLine("Entrada inválida! Digite um número.");
                continue;
            }

            if (opcao == OpcaoGerar)
            {
                GerarLista();
            }
            else if (opcao == OpcaoMostrar)
            {
                MostrarLista();
            }
            else if (opcao == OpcaoCompararTodos)
            {
                CompararTodos();
            }
            else if (opcao >= PrimeiraOpcaoAlgoritmo &&
                     opcao < PrimeiraOpcaoAlgoritmo + controller.Algoritmos.Count)
            {
                ExecutarAlgoritmo(opcao - PrimeiraOpcaoAlgoritmo + 1);
            }
            else if (opcao == OpcaoSair())
            {
                Console.WriteLine("Encerrando...");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

        } while (opcao != OpcaoSair());
    }

    private int OpcaoSair() => PrimeiraOpcaoAlgoritmo + controller.Algoritmos.Count;

    private void ExibirMenu()
    {
        Console.WriteLine("--- MENU ---");
        Console.WriteLine($"{OpcaoGerar} - Gerar nova lista");
        Console.WriteLine($"{OpcaoMostrar} - Mostrar lista atual");
        Console.WriteLine($"{OpcaoCompararTodos} - Comparar todos os algoritmos (cópia independente)");
        Console.WriteLine($"{PrimeiraOpcaoAlgoritmo} - Ordenar por {controller.Algoritmos[0].Nome}");

        for (int i = 1; i < controller.Algoritmos.Count; i++)
        {
            Console.WriteLine($"{PrimeiraOpcaoAlgoritmo + i} - Ordenar por {controller.Algoritmos[i].Nome}");
        }

        Console.WriteLine($"{OpcaoSair()} - Sair");
        Console.Write("Escolha uma opção: ");
    }

    private void GerarLista()
    {
        Console.Write("Quantos números deseja gerar? ");
        string? entrada = Console.ReadLine();

        if (!int.TryParse(entrada, out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida!");
            return;
        }

        controller.GerarLista(quantidade, 0, 100000);
        Console.WriteLine($"Lista gerada com {quantidade} números.");
    }

    private void MostrarLista()
    {
        IReadOnlyList<int> lista = controller.ObterLista();

        if (lista.Count == 0)
        {
            Console.WriteLine("\nNenhuma lista carregada. Gere uma primeiro.");
            return;
        }

        Console.WriteLine($"\nLista atual ({lista.Count} itens):");

        foreach (int item in lista)
        {
            Console.WriteLine(item);
        }
    }

    private void ExecutarAlgoritmo(int indice1Based)
    {
        ResultadoOrdenacao? resultado = controller.ExecutarAlgoritmo(indice1Based);

        if (resultado is null)
        {
            Console.WriteLine("Falha ao executar o algoritmo.");
            return;
        }

        string nomeAlgoritmo = controller.Algoritmos[indice1Based - 1].Nome;

        Console.WriteLine($"\n{nomeAlgoritmo}:");
        Console.WriteLine($"  Comparações:   {resultado.Comparacoes}");
        Console.WriteLine($"  Trocas:        {resultado.Trocas}");
        Console.WriteLine($"  Movimentações: {resultado.Movimentacoes}");
        Console.WriteLine($"  Tempo (ms):    {resultado.TempoMs}");
        Console.WriteLine($"  Tamanho:       {resultado.TamanhoLista}");
    }

    private void CompararTodos()
    {
        var resultados = controller.ExecutarTodosAlgoritmos();

        if (resultados.Count == 0)
        {
            Console.WriteLine("\nNenhuma lista carregada. Gere uma primeiro.");
            return;
        }

        Console.WriteLine("\n=== COMPARAÇÃO EXPERIMENTAL (cópia independente) ===");
        Console.WriteLine("Algoritmo                    Comparações   Trocas  Movimentações  Tempo (ms)");
        Console.WriteLine("--------------------------------------------------------------------------------");

        var algoritmos = controller.Algoritmos;
        for (int i = 0; i < algoritmos.Count; i++)
        {
            string nome = algoritmos[i].Nome;
            var r = resultados[i];

            Console.WriteLine($"{nome,-30} {r.Comparacoes,12} {r.Trocas,7} {r.Movimentacoes,13} {r.TempoMs,10}");
        }
    }
}
