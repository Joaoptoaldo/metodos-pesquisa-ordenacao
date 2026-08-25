using OrdenacaoObjetos.Model;
using OrdenacaoObjetos.Model.Ordenacao;

namespace OrdenacaoObjetos.Controller;

/// <summary>
/// media a interacao entre a View e o Model
/// </summary>
public class OrdenacaoController
{
    private List<Processo> lista = new();
    private readonly IAlgoritmoOrdenacao algoritmo;

    public OrdenacaoController()
    {
        algoritmo = new BubbleSort();
    }

    /// <summary>
    /// substitui a lista em memoria por uma nova lista de Processos aleatorios
    /// </summary>
    public void GerarLista(int quantidade)
    {
        lista = GeradorLista.Gerar(quantidade);
    }

    /// <summary>
    /// retorna a lista atual como somente-leitura
    /// </summary>
    public IReadOnlyList<Processo> ObterLista() => lista;

    /// <summary>
    /// rrdena a lista atual usando Bubble Sort
    /// </summary>
    public void Ordenar()
    {
        algoritmo.Ordenar(lista);
    }
}
