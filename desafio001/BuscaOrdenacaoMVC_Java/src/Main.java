import controller.DadoController;
import view.MenuView;

public class Main {
    public static void main(String[] args) throws Exception {
       DadoController controller = new DadoController();

        MenuView view = new MenuView(controller);

        view.iniciar();
    }
}
