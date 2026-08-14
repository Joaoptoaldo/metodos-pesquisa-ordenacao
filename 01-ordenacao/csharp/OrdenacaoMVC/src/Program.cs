using OrdenacaoMVC.Controller;
using OrdenacaoMVC.View;

namespace OrdenacaoMVC;

public class Program
{
    public static void Main(string[] args)
    {
        OrdenacaoController controller = new();
        MenuView view = new(controller);

        view.Iniciar();
    }
}
