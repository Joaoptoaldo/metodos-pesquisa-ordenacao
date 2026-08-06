using System;
using System.Collections.Generic;

namespace Projeto.View;

public class ExibicaoView
{
    public static void ExibirLista(List<int> lista, string frase)
    {
        Console.WriteLine(frase);

        foreach (int item in lista)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine($"Total de registros: {lista.Count}");
    }

    public static void ExibirTempoExecucao(int rotina, long tempoMs)
    {
        Console.WriteLine($"Tempo (ms) rotina {rotina}: {tempoMs}");
    }
}