using Projeto.Model;
using Projeto.View;
using System.Collections.Generic;
using System.Diagnostics;

namespace Projeto.Controller;

public class ListaController
{
    public void ExecutarProcessamento()
    {
        List<int> listaAleatoria = new();
        List<int> listaSequencial = new();

        Stopwatch cronometro = Stopwatch.StartNew();

        Utilidades.PopularLista(
            listaAleatoria,
            100000,
            100,
            100000,
            true);

        cronometro.Stop();

        ExibicaoView.ExibirTempoExecucao(1, cronometro.ElapsedMilliseconds);


        cronometro.Restart();

        Utilidades.PopularLista(
            listaSequencial,
            100000,
            1,
            100000,
            false);

        cronometro.Stop();

        ExibicaoView.ExibirTempoExecucao(2, cronometro.ElapsedMilliseconds);
    }
}