using DesafioSessaoTelefoniaCsharp.Models;

namespace DesafioSessaoTelefoniaCsharp.Repositories;

public class TabelaSessoes
{
    private readonly Dictionary<string, SessaoTelefonica> sessoes =
        new(StringComparer.Ordinal);

    public int Quantidade => sessoes.Count;

    public void Limpar()
    {
        sessoes.Clear();
    }

    public void Adicionar(SessaoTelefonica sessao)
    {
        ArgumentNullException.ThrowIfNull(sessao);

        // A atribuicao por chave usa a tabela hash nativa e preserva o
        // comportamento de put do HashMap Java: a ultima duplicata vence
        sessoes[sessao.NumeroCelular] = sessao;
    }

    public bool TentarPesquisar(string numeroCelular, out SessaoTelefonica? sessao)
    {
        // TryGetValue faz a busca diretamente no Dictionary sem varredura linear
        return sessoes.TryGetValue(numeroCelular, out sessao);
    }
    
}
