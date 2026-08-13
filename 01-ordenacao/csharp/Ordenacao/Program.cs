using System;
using System.Diagnostics;
using System.Collections.Generic;   


class Ordenacao
{
    public static void Bolha(List<int> lista)
    {        
        bool houveTroca;
        int tmp;
        long qtdComparacoes = 0, qtdTrocas = 0;

        do
        {
            houveTroca = false;
            for (int i = 0; i < lista.Count() - 1; i++)
            {
                qtdComparacoes++;
                if (lista[i] > lista[i + 1])
                {
                    qtdTrocas++;
                    houveTroca = true;
                    tmp = lista[i];
                    lista[i] = lista[i + 1];
                    lista[i + 1] = tmp;
                }
            }
        } 
        while (houveTroca);

        Console.WriteLine("Quantidades comparações: " + qtdComparacoes);
        Console.WriteLine("Quantidade trocas: " + qtdTrocas);
    }

    public static void Selecao(List<int> lista)
    {
        int posMenor;
        int tmp;
        long qtdComparacoes = 0, qtdTrocas = 0;

        for (int i = 0; i < lista.Count() - 1; i++)
        {
            posMenor = i;
            for (int j = i + 1; j < lista.Count(); j++)
            {
                qtdComparacoes++;
                if (lista[j] < lista[posMenor])
                {
                    posMenor = j;
                }
            }
            if (i != posMenor)
            {
                qtdTrocas++;
                tmp = lista[i];
                lista[i] = lista[posMenor];
                lista[posMenor] = tmp;
            }
        }

        Console.WriteLine("Quantidades comparações: " + qtdComparacoes);
        Console.WriteLine("Quantidade trocas: " + qtdTrocas);
    }

    public static void Insercao(List<int> lista)
    {
        int i, j;
        int tmp;
        long qtdComparacoes = 0, qtdTrocas = 0;

        for (i = 1; i < lista.Count(); i++)
        {
            tmp = lista[i];
            for (j = i - 1; j >= 0; j--)
            {
                qtdComparacoes++;
                if (tmp < lista[j])
                {
                    lista[j + 1] = lista[j]; //shift eh trocar para o lado
                    qtdTrocas++;
                }
                else break;
            }
            lista[j + 1] = tmp;
            qtdTrocas++;
        }

        Console.WriteLine("Quantidades comparações: " + qtdComparacoes);
        Console.WriteLine("Quantidade trocas: " + qtdTrocas);
    }
}

class Util
{

    public static void PopularLista(List<int> lista, int quantidade)
    {
        Random gerador = new Random();
        for (int i = 0; i < quantidade; i++)
        {
            lista.Add(gerador.Next(100000));
        }
    }

    public static void ExibirLista(List<int> lista)
    {
        foreach (int item in lista)
        {
            Console.WriteLine(item);
        }
    }

    public static void ExibirTempo(Stopwatch sw, string frase)
    {
        Console.WriteLine(frase + " (ms): " + sw.ElapsedMilliseconds);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<int> listaSort = new List<int>();
        List<int> listaBolha = new List<int>();
        List<int> listaSelecao = new List<int>();
        List<int> listaInsercao = new List<int>();

        Stopwatch sw = new Stopwatch();

        int quantidade;

        try
        {
            Console.Write("Quantos números deseja trabalhar? ");
            quantidade = int.Parse(Console.ReadLine());

            Util.PopularLista(listaBolha, quantidade);
            Util.PopularLista(listaSelecao, quantidade);
            Util.PopularLista(listaInsercao, quantidade);
            Util.PopularLista(listaSort, quantidade);

            sw.Start();
            listaSort.Sort();
            sw.Stop();
            Util.ExibirTempo(sw, "Ordenando por sort nativo");
            sw.Reset();

            sw.Start();
            Ordenacao.Bolha(listaBolha);
            sw.Stop();
            Util.ExibirTempo(sw, "Ordenando por bolha");
            sw.Reset();

            sw.Start();
            Ordenacao.Selecao(listaSelecao);
            sw.Stop();
            Util.ExibirTempo(sw, "Ordenando por seleção");
            sw.Reset();

            sw.Start();
            Ordenacao.Insercao(listaInsercao);
            sw.Stop();
            Util.ExibirTempo(sw, "Ordenando por inserção");
            sw.Reset();
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
