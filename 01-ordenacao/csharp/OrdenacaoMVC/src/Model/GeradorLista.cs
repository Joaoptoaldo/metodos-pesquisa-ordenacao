namespace OrdenacaoMVC.Model;

/// <summary>
/// Gera listas de inteiros para uso como entrada dos algoritmos de ordenação
///</summary>
public static class GeradorLista
{
    /// <summary>
    /// Cria uma nova lista preenchida com números inteiros aleatórios
    ///</summary>
    /// <param name="quantidade">Quantidade de números a gerar</param>
    /// <param name="minimo">Valor mínimo (inclusivo) do intervalo</param>
    /// <param name="maximo">Valor máximo (exclusivo) do intervalo</param>
    public static List<int> Gerar(int quantidade, int minimo, int maximo)
    {
        List<int> lista = new(quantidade);
        Random gerador = Random.Shared;

        for (int i = 0; i < quantidade; i++)
        {
            lista.Add(gerador.Next(minimo, maximo));
        }

        return lista;
    }
}
