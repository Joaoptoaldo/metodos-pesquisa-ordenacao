using DesafioSessaoTelefoniaCsharp.Models;
using DesafioSessaoTelefoniaCsharp.Repositories;

namespace DesafioSessaoTelefoniaCsharp.Services;

public class LeitorSessoes
{
    // método que carrega sessoes de telefonia de um arquivo .txt para uma tabela hash
    public int Carregar(string caminho, TabelaSessoes tabela)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(caminho);
        ArgumentNullException.ThrowIfNull(tabela);

        tabela.Limpar();
        var quantidadeLinhasValidas = 0;
        var numeroLinha = 0;

        foreach (var linha in File.ReadLines(caminho))
        {
            numeroLinha++;

            if (string.IsNullOrWhiteSpace(linha))
            {
                continue;
            }

            var partes = linha.Split(';', 2, StringSplitOptions.None);
            if (partes.Length < 2 || string.IsNullOrWhiteSpace(partes[0]))
            {
                Console.Error.WriteLine(
                    $"Aviso: linha {numeroLinha} ignorada por formato invalido. " +
                    "Esperado: numeroCelular;dadosSessao");
                continue;
            }

            var sessao = new SessaoTelefonica(
                partes[0].Trim(),
                partes[1]);
            tabela.Adicionar(sessao);
            quantidadeLinhasValidas++;
        }

        return quantidadeLinhasValidas;
    }
}
