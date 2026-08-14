namespace OrdenacaoMVC.Model.Algoritmos;

/// <summary>
/// Contrato comum aos algoritmos de ordenação. Permite que o Controller
/// trate diferentes algoritmos de forma polimórfica
///</summary>
public interface IAlgoritmoOrdenacao
{
    /// <summary>
    /// Nome exibido no menu da aplicação
    ///</summary>
    string Nome { get; }

    /// <summary>
    /// Ordena a lista in-place e retorna as métricas da execução
    ///</summary>
    ResultadoOrdenacao Ordenar(List<int> lista);
}
