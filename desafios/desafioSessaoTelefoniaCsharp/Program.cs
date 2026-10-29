using DesafioSessaoTelefoniaCsharp.Repositories;
using DesafioSessaoTelefoniaCsharp.Services;

namespace DesafioSessaoTelefoniaCsharp;

public static class Program
{
    public static void Main(string[] args)
    {
        var caminhoArquivo = ObterCaminhoArquivo(args);
        var tabela = new TabelaSessoes();
        var leitor = new LeitorSessoes();

        try
        {
            var quantidadeCarregada = leitor.Carregar(caminhoArquivo, tabela);
            Console.WriteLine(
                $"{quantidadeCarregada} linha(s) valida(s) carregada(s). " +
                $"{tabela.Quantidade} sessao(oes) indexada(s).");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine($"Erro: arquivo nao encontrado: {caminhoArquivo}");
            return;
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine($"Erro: diretorio nao encontrado: {caminhoArquivo}");
            return;
        }
        catch (IOException erro)
        {
            Console.Error.WriteLine($"Erro ao ler o arquivo: {erro.Message}");
            return;
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"Erro: sem permissao para ler: {caminhoArquivo}");
            return;
        }

        ExecutarMenu(tabela);
    }

    private static string ObterCaminhoArquivo(string[] args)
    {
        if (args.Length > 0)
        {
            return args[0];
        }

        const string nomeArquivo = "telephony_sessions.txt";
        if (File.Exists(nomeArquivo))
        {
            return nomeArquivo;
        }

        return Path.Combine(AppContext.BaseDirectory, nomeArquivo);
    }

    private static void ExecutarMenu(TabelaSessoes tabela)
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

            if (tabela.TentarPesquisar(numeroCelular, out var sessao))
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
