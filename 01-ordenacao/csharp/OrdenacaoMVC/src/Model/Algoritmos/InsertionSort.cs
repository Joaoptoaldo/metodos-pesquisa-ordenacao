using System.Diagnostics;

namespace OrdenacaoMVC.Model.Algoritmos;

/// <summary>
/// Implementação do Insertion Sort (ordenação por inserção)
/// Insere cada elemento na posição correta do trecho já ordenado à sua esquerda
///</summary>
public class InsertionSort : IAlgoritmoOrdenacao
{
    public string Nome => "Insertion Sort";

    public ResultadoOrdenacao Ordenar(List<int> lista)
    {
        long comparacoes = 0;
        long movimentacoes = 0;
        int i, j;
        int tmp;

        Stopwatch sw = Stopwatch.StartNew();

        for (i = 1; i < lista.Count; i++)
        {
            tmp = lista[i];
            for (j = i - 1; j >= 0; j--)
            {
                comparacoes++;
                if (tmp < lista[j])
                {
                    lista[j + 1] = lista[j]; // shift: arrastar maior para a direita
                    movimentacoes++;
                }
                else break; // posição correta encontrada, para de deslocar
            }
            lista[j + 1] = tmp;
            movimentacoes++; // conta a reinserção do tmp como mais um deslocamento
        }

        sw.Stop();

        return new ResultadoOrdenacao(
            Comparacoes: comparacoes,
            Trocas: 0,
            Movimentacoes: movimentacoes,
            TempoMs: sw.ElapsedMilliseconds,
            TamanhoLista: lista.Count);
    }
}
