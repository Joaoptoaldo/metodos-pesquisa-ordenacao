using System.Globalization;
using System.Text;

namespace PesquisaLib;

/// <summary>
/// Disponibiliza métodos de pesquisa para serem utilizados por outros projetos.
/// </summary>
public sealed class MetodosPesquisa
{
    private readonly NoTrie raiz = new();
    private readonly HashSet<string> chavesIndexadas = new(StringComparer.Ordinal);

    /// <summary>
    /// Procura um nome na lista usando pesquisa sequencial.
    /// Retorna o índice encontrado ou -1 quando o nome não existe.
    /// </summary>
    public int PesquisaSequencial(IReadOnlyList<string> nomes, string nomeProcurado)
    {
        ArgumentNullException.ThrowIfNull(nomes);

        string chaveProcurada = NormalizarChave(nomeProcurado);

        if (chaveProcurada.Length == 0)
        {
            return -1;
        }

        for (int i = 0; i < nomes.Count; i++)
        {
            if (NormalizarChave(nomes[i]) == chaveProcurada)
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Adiciona um nome ao índice digital usado para pesquisa por prefixo.
    /// Retorna false se o nome estiver vazio ou já estiver indexado.
    /// </summary>
    public bool AdicionarNomeNoIndiceDigital(string nome)
    {
        string nomeExibicao = PrepararNome(nome);
        string chave = NormalizarChave(nomeExibicao);

        if (chave.Length == 0 || !chavesIndexadas.Add(chave))
        {
            return false;
        }

        NoTrie atual = raiz;

        foreach (char caractere in chave)
        {
            if (!atual.Filhos.TryGetValue(caractere, out NoTrie? proximo))
            {
                proximo = new NoTrie();
                atual.Filhos.Add(caractere, proximo);
            }

            atual = proximo;
            atual.Nomes.Add(nomeExibicao);
        }

        return true;
    }

    /// <summary>
    /// Retorna os nomes cujo início corresponde ao prefixo informado.
    /// A busca não diferencia maiúsculas, minúsculas ou acentos.
    /// </summary>
    public IReadOnlyList<string> PesquisaDigital(string prefixo)
    {
        string chave = NormalizarChave(prefixo);

        if (chave.Length == 0)
        {
            return Array.Empty<string>();
        }

        NoTrie atual = raiz;

        foreach (char caractere in chave)
        {
            if (!atual.Filhos.TryGetValue(caractere, out NoTrie? proximo))
            {
                return Array.Empty<string>();
            }

            atual = proximo;
        }

        return atual.Nomes.ToArray();
    }

    private static string PrepararNome(string? nome)
    {
        return string.Join(' ', (nome ?? string.Empty)
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
    }


    private static string NormalizarChave(string? texto)
    {
        string preparado = PrepararNome(texto).Normalize(NormalizationForm.FormD);
        var resultado = new StringBuilder(preparado.Length);

        foreach (char caractere in preparado)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(caractere) != UnicodeCategory.NonSpacingMark)
            {
                resultado.Append(char.ToUpperInvariant(caractere));
            }
        }

        return resultado.ToString().Normalize(NormalizationForm.FormC);
    }

    private sealed class NoTrie
    {
        public Dictionary<char, NoTrie> Filhos { get; } = new();
        public List<string> Nomes { get; } = new();
    }
}
