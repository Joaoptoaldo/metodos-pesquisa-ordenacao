using BuscaOrdenacaoMVC_CSharp.Controller;
using BuscaOrdenacaoMVC_CSharp.View;

DadoController controller = new DadoController();

MenuView view = new MenuView(controller);

view.Iniciar();
