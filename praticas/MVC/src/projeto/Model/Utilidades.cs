using System;
using System.Collections.Generic;

namespace Projeto.Model;

public class Utilidades
{
    /// <summary>
    /// Popula uma lista com números aleatórios ou sequenciais.
    /// </summary>
    public static void PopularLista(
        List<int> lista,
        long quantidadeNumeros,
        int inicio,
        int fim,
        bool aleatorio)
    {
        Random gerador = new();

        if (aleatorio)
        {
            for (long i = 0; i < quantidadeNumeros; i++)
            {
                lista.Add(gerador.Next(inicio, fim));
            }
        }
        else
        {
            for (long i = 0; i < quantidadeNumeros; i++)
            {
                lista.Add((int)(inicio + i));
            }
        }
    }
}