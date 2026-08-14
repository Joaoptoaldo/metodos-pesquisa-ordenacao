using OrdenacaoMVC.Model;
using OrdenacaoMVC.Model.Algoritmos;
using System.Collections.Generic;

namespace OrdenacaoMVC.Controller;

/// <summary>
/// Media a interação entre a View e o Model. Mantém a lista em memória
/// e expõe operações de alto nível (gerar lista, ordenar) que a View invoca
///</summary>
public class OrdenacaoController
{
    private readonly IAlgoritmoOrdenacao[] algoritmos;
    private List<int> lista = new();

    public OrdenacaoController()
    {
        algoritmos = new IAlgoritmoOrdenacao[]
        {
            new SortNativo(),
            new BubbleSort(),
            new SelectionSort(),
            new InsertionSort(),
        };
    }

    /// <summary>
    /// Algoritmos registrados, na ordem em que aparecem no menu
    ///</summary>
    public IReadOnlyList<IAlgoritmoOrdenacao> Algoritmos => algoritmos;

    /// <summary>
    /// Substitui a lista em memória por uma nova lista de números aleatórios
    ///</summary>
    public void GerarLista(int quantidade, int minimo, int maximo)
    {
        lista = GeradorLista.Gerar(quantidade, minimo, maximo);
    }

    /// <summary>
    /// Retorna uma referência somente-leitura da lista atual
    ///</summary>
    public IReadOnlyList<int> ObterLista() => lista;

    /// <summary>
    /// Executa o algoritmo indicado pelo índice (1-based, conforme o menu)
    /// sobre a lista atual e retorna as métricas. Retorna null se o índice for inválido
    ///</summary>
    public ResultadoOrdenacao? ExecutarAlgoritmo(int indice1Based)
    {
        int idx = indice1Based - 1;

        if (idx < 0 || idx >= algoritmos.Length)
        {
            return null;
        }

        var resultado = algoritmos[idx].Ordenar(lista);
        return resultado;
    }

    /// <summary>
    /// Executa todos os algoritmos sobre cópias independentes da lista atual
    /// </summary>
    public IReadOnlyList<ResultadoOrdenacao> ExecutarTodosAlgoritmos()
    {
        if (lista.Count == 0)
        {
            return Array.Empty<ResultadoOrdenacao>();
        }

        var resultados = new List<ResultadoOrdenacao>(algoritmos.Length);
        foreach (var alg in algoritmos)
        {
            var copia = new List<int>(lista);
            resultados.Add(alg.Ordenar(copia));
        }
        return resultados;
    }
}
