using System;
using System.Collections.Generic;

class TabelaHash
{
    public static int CalcularEndereco(string nome, int n)
    {
        return nome.Length % n;
    }
    
    public static void Inicializar(List<string>[] tabela, int n)
    {
        for (int i = 0; i < n; i++)
        {
            tabela[i] = new List<string>();
        }        
    }
    
    public static void Inserir(string nome, List<string>[] tabela)
    {
        int endereco = CalcularEndereco(nome, tabela.Length);
        tabela[endereco].Add(nome);
        Console.WriteLine($"{nome} inserido na tabela no endereco {endereco}");        
    }
    
    public static void Exibir(List<string>[] tabela)
    {
        for (int i = 0; i < tabela.Length; i++)
        {
            foreach (var item in tabela[i])
            {
                Console.WriteLine(item);                
            }
        }        
    }
    
    public static int Pesquisar(string nome, List<string>[] tabela)
    {
        int endereco = CalcularEndereco(nome, tabela.Length);
        
        if (tabela[endereco].Contains(nome))
        {
            return endereco;
        }
        return -1;
    }
}

public class Principal
{
    public static void Main(string[] args)
    {
        const int TAMANHO = 10;               
        List<string>[] tabelaHash = new List<string>[TAMANHO];
        TabelaHash.Inicializar(tabelaHash, TAMANHO);
        string nome;
        
        // Loop de Inserção
        do
        {
            Console.Write("Informe um nome (ou digite 'SAIR'): ");
            nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome)) continue;

            // Equals com StringComparison equivalente ao equalsIgnoreCase do Java
            if (nome.Equals("SAIR", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            TabelaHash.Inserir(nome, tabelaHash);            
        } while (true);
        
        Console.WriteLine("\n--- Exibindo Tabela ---");
        TabelaHash.Exibir(tabelaHash);
        Console.WriteLine("-----------------------\n");
        
        // Loop de Pesquisa
        do
        {
            Console.Write("Informe um nome para pesquisa (ou digite 'SAIR'): ");
            nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome)) continue;

            if (nome.Equals("SAIR", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            
            int endereco = TabelaHash.Pesquisar(nome, tabelaHash);
            if (endereco != -1)
            {
                Console.WriteLine($"Nome localizado no endereco {endereco}");
            }
            else
            {
                Console.WriteLine("Nome nao localizado");
            }            
        } while (true);
    }
}
