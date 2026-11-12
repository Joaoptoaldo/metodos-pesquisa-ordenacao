using DesafioSessaoTelefoniaCsharp.Repositories;
using DesafioSessaoTelefoniaCsharp.Services;
using DesafioSessaoTelefoniaCsharp.View;

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

        var menu = new MenuView(tabela);
        menu.Executar();
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
}
