using System.Diagnostics;

namespace OrdenacaoMVC.Model.Algoritmos;

/// <summary>
/// Encapsula a chamada ao <see cref="List{T}.Sort()"/> do .NET, que internamente
/// usa um algoritmo introspectivo (variação de QuickSort + HeapSort)
/// Comparações e trocas internas não são expostas pela API, portanto as
/// métricas <see cref="ResultadoOrdenacao.Comparacoes"/> e
/// <see cref="ResultadoOrdenacao.Trocas"/> ficam zeradas
///</summary>
public class SortNativo : IAlgoritmoOrdenacao
{
    public string Nome => "Sort nativo (List.Sort)";

    public ResultadoOrdenacao Ordenar(List<int> lista)
    {
        Stopwatch sw = Stopwatch.StartNew();

        lista.Sort();

        sw.Stop();

        return new ResultadoOrdenacao(
            Comparacoes: 0,
            Trocas: 0,
            Movimentacoes: 0,
            TempoMs: sw.ElapsedMilliseconds,
            TamanhoLista: lista.Count);
    }
}
