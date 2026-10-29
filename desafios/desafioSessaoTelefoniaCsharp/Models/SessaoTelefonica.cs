namespace DesafioSessaoTelefoniaCsharp.Models;

public class SessaoTelefonica
{
    public string NumeroCelular { get; set; }
    public string DadosSessao { get; set; }

    public SessaoTelefonica(string numeroCelular, string dadosSessao)
    {
        NumeroCelular = numeroCelular;
        DadosSessao = dadosSessao;
    }

    public override string ToString()
    {
        return $"Sessao [numeroCelular={NumeroCelular}, dadosSessao={DadosSessao}]";
    }
}
