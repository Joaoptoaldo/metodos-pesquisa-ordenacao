using DesafioSessaoTelefoniaCsharp.Repositories;

namespace DesafioSessaoTelefoniaCsharp.View;

public class MenuView
{
    private readonly TabelaSessoes _tabela;

    public MenuView(TabelaSessoes tabela)
    {
        _tabela = tabela;
    }

    public void Executar()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Pesquisa de sessoes de telefonia");
            Console.WriteLine("1 - Pesquisar por numero de celular");
            Console.WriteLine("0 - Sair");
            Console.Write("Opcao: ");

            var opcao = Console.ReadLine()?.Trim();
            if (opcao == "0")
            {
                return;
            }

            if (opcao != "1")
            {
                Console.WriteLine("Opcao invalida.");
                continue;
            }

            Console.Write("Numero de celular: ");
            var numeroCelular = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(numeroCelular))
            {
                Console.WriteLine("Informe um numero de celular.");
                continue;
            }

            if (_tabela.TentarPesquisar(numeroCelular, out var sessao))
            {
                Console.WriteLine($"Sessao encontrada: {sessao}");
            }
            else
            {
                Console.WriteLine("Nenhuma sessao encontrada para esse numero.");
            }
        }
    }
}
