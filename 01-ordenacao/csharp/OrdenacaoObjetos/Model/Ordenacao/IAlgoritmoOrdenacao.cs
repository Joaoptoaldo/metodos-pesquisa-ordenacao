namespace OrdenacaoObjetos.Model.Ordenacao;

/// <summary>
/// contrato comum aos algoritmos de ordenacao de Processos
/// </summary>
public interface IAlgoritmoOrdenacao
{
    /// <summary>
    /// nome exibido no menu da aplicacao
    /// </summary>
    string Nome { get; }

    /// <summary>
    /// ordena a lista de Processos pelo campo Id (in-place)
    /// </summary>
    void Ordenar(List<Processo> lista);
}
