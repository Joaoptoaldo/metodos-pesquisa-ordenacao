namespace OrdenacaoObjetos.Model;

/// <summary>
/// gera listas de objetos Processo para uso como entrada dos algoritmos
/// </summary>
public static class GeradorLista
{
    /// <summary>
    /// cria uma lista com Processos de ids e descricoes aleatorias.
    /// </summary>
    /// <param name="quantidade">numero de processos a serem gerados</param>
    /// <returns>lista de processos gerada</returns>
    public static List<Processo> Gerar(int quantidade)
    {
        List<Processo> lista = new(quantidade);
        Random gerador = Random.Shared;

        for (int i = 0; i < quantidade; i++)
        {
            int id = gerador.Next(100, 500);
            string descricao = $"gerando uma string {gerador.Next(quantidade)}";
            lista.Add(new Processo(id, descricao));
        }

        return lista;
    }
}
