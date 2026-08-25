using OrdenacaoObjetos.Controller;
using OrdenacaoObjetos.View;

namespace OrdenacaoObjetos;

public class Program
{
    public static void Main(string[] args)
    {
        OrdenacaoController controller = new();
        OrdenacaoView view = new(controller);

        view.Iniciar();
    }
}
