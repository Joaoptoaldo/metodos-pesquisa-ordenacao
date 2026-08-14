import controller.OrdenacaoController;
import view.MenuView;

public class Main {
    public static void main(String[] args) {
        OrdenacaoController controller = new OrdenacaoController();
        MenuView view = new MenuView(controller);

        view.iniciar();
    }
}
