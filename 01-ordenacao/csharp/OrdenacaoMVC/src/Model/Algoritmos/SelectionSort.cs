using System.Diagnostics;

namespace OrdenacaoMVC.Model.Algoritmos;

/// <summary>
/// Implementação do Selection Sort (ordenação por seleção)
/// A cada iteração seleciona o menor elemento do trecho restante e o coloca na posição correta
///</summary>
public class SelectionSort : IAlgoritmoOrdenacao
{
    public string Nome => "Selection Sort";

    public ResultadoOrdenacao Ordenar(List<int> lista)
    {
        long comparacoes = 0;
        long trocas = 0;
        int posMenor;
        int tmp;

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < lista.Count - 1; i++)
        {
            posMenor = i;
            for (int j = i + 1; j < lista.Count; j++)
            {
                comparacoes++;
                if (lista[j] < lista[posMenor])
                {
                    posMenor = j;
                }
            }
            if (i != posMenor)
            {
                trocas++;
                tmp = lista[i];
                lista[i] = lista[posMenor];
                lista[posMenor] = tmp;
            }
        }

        sw.Stop();

        return new ResultadoOrdenacao(
            Comparacoes: comparacoes,
            Trocas: trocas,
            Movimentacoes: 0,
            TempoMs: sw.ElapsedMilliseconds,
            TamanhoLista: lista.Count);
    }
}
