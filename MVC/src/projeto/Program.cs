using Projeto.Controller;

namespace Projeto;

public class Program
{
    public static void Main(string[] args)
    {
        var controller = new ListaController();

        controller.ExecutarProcessamento();
    }
}