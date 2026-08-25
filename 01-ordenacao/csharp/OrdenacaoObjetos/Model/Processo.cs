namespace OrdenacaoObjetos.Model;

/// <summary>
/// representa um processo com id e descricao
/// </summary>
public class Processo : IComparable<Processo>
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Processo(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }

    /// <summary>
    /// compara dois Processos pelo campo Id
    /// </summary>
    public int CompareTo(Processo? outro)
    {
        if (outro is null)
            return 1; // objetos nulos vao para o final

        return Id.CompareTo(outro.Id);
    }

    public override string ToString()
    {
        return $"Processo [id={Id}, descricao={Descricao}]";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Processo other)
            return Id == other.Id;
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
