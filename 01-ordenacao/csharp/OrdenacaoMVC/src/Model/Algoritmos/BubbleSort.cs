using System.Diagnostics;

namespace OrdenacaoMVC.Model.Algoritmos;

/// <summary>
/// Implementação do Bubble Sort (ordenação por bolha)
/// Percorre a lista comparando pares adjacentes e trocando quando estão fora de ordem
///</summary>
public class BubbleSort : IAlgoritmoOrdenacao
{
    public string Nome => "Bubble Sort";

    public ResultadoOrdenacao Ordenar(List<int> lista)
    {
        long comparacoes = 0;
        long trocas = 0;
        bool houveTroca;
        int tmp;

        Stopwatch sw = Stopwatch.StartNew();

        do
        {
            houveTroca = false;
            for (int i = 0; i < lista.Count - 1; i++)
            {
                comparacoes++;
                if (lista[i] > lista[i + 1])
                {
                    trocas++;
                    houveTroca = true;
                    tmp = lista[i];
                    lista[i] = lista[i + 1];
                    lista[i + 1] = tmp;
                }
            }
        }
        while (houveTroca);

        sw.Stop();

        return new ResultadoOrdenacao(
            Comparacoes: comparacoes,
            Trocas: trocas,
            Movimentacoes: 0,
            TempoMs: sw.ElapsedMilliseconds,
            TamanhoLista: lista.Count);
    }
}
