namespace OrdenacaoMVC.Model;

/// <summary>
/// Métricas de uma execução de ordenação
///</summary>
/// <param name="Comparacoes">Quantidade de comparações entre elementos</param>
/// <param name="Trocas">Quantidade de trocas (swap de dois elementos)</param>
/// <param name="Movimentacoes">Quantidade de movimentações/deslocamentos (Insertion Sort shifts)</param>
/// <param name="TempoMs">Tempo de execução em milissegundos</param>
/// <param name="TamanhoLista">Tamanho da lista ordenada</param>
public record ResultadoOrdenacao(
    long Comparacoes,
    long Trocas,
    long Movimentacoes,
    long TempoMs,
    int TamanhoLista);
