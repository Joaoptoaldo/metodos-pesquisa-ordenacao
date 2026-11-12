using Encurtador.Services;
using Encurtador.View;

var servico = new EncurtadorService();
var menu = new MenuView(servico);

menu.Executar();
