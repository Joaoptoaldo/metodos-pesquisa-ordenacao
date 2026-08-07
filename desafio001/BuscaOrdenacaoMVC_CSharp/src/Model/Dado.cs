namespace BuscaOrdenacaoMVC_CSharp.Model;

public class Dado
{
    public string Valor { get; set; }

    public Dado(string valor)
    {
        Valor = valor;
    }

    public override string ToString()
    {
        return Valor;
    }
}
