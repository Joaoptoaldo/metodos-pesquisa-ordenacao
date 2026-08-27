using BuscaOrdenacaoMVC_CSharp.Model;

namespace BuscaOrdenacaoMVC_CSharp.Controller;

public class DadoController
{
    private List<Dado> dados;

    public DadoController()
    {
        dados = new List<Dado>();
    }

    /// <summary>
    /// carrega os dados de um arquivo, criando objetos Dado a partir de 
    /// cada linha não vazia e adicionando-os à lista de dados
    /// </summary>
    /// <param name="caminho">caminho do arquivo</param>
    /// <returns>
    /// retorna true se o arquivo foi carregado com sucesso, 
    /// ou false se ocorreu algum erro de leitura
    /// </returns>
    public bool CarregarArquivo(string caminho)
    {
        dados.Clear();

        try
        {
            if (!File.Exists(caminho))
            {
                string nome = Path.HasExtension(caminho) ? caminho : caminho + ".txt";
                string[] tentativas = {
                    Path.Combine(Directory.GetCurrentDirectory(), "..", "Data", nome),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Data", nome)
                };

                foreach (var t in tentativas)
                {
                    if (File.Exists(t))
                    {
                        caminho = t;
                        break;
                    }
                }
            }

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string linha in linhas)
            {
                if (!string.IsNullOrWhiteSpace(linha))
                {
                    dados.Add(new Dado(linha));
                }
            }

            return true;
        }
        
        catch (IOException)
        {
            return false;
        }
    }

    /// <summary>
    /// retorna a lista de dados carregada do arquivo
    /// </summary>
    /// <returns>lista de dados</returns>
    public List<Dado> ListarDados()
    {
        return dados;
    }



    // --- métodos auxiliares de comparação ---

    private static bool EhNumero(string valor)
    {
        // verifica se o valor é um número
        return int.TryParse(valor, out _);
    }

    /// <summary>
    /// método que compara dois valores, tratando números e strings de forma diferente
    /// se ambos forem números, compara numericamente; caso contrário, compara como strings
    /// </summary>
    /// <param name="valor1">primeiro valor a ser comparado</param>
    /// <param name="valor2">segundo valor a ser comparado</param>
    /// <returns>
    /// retorna um valor negativo se valor1 for menor que valor2, zero se forem iguais, 
    /// e um valor positivo se valor1 for maior que valor2
    /// </returns>
    private static int Comparar(string valor1, string valor2)
    { 
        if (EhNumero(valor1) && EhNumero(valor2))
        {
            return int.Parse(valor1).CompareTo(int.Parse(valor2));
        }

        return string.Compare(valor1, valor2, StringComparison.OrdinalIgnoreCase);
    }

    // ---  métodos de ordenação e busca ---

    // bubble sort

    /// <summary>
    /// ordena a lista de dados usando o algoritmo bubble sort, 
    /// comparando os valores dos dados e trocando-os de posição se estiverem fora de ordem
    /// </summary>
    public void BubbleSort()
    {
        // obtém o número de elementos na lista
        int n = dados.Count;

        // percorre todos os elementos da lista
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                string atual = dados[j].Valor;
                string proximo = dados[j + 1].Valor;

                // compara os elementos e troca se estiverem fora de ordem
                if (Comparar(atual, proximo) > 0)
                {
                 
                    // troca os elementos de posição usando uma variável auxiliar
                    Dado aux = dados[j];
                    dados[j] = dados[j + 1];
                    dados[j + 1] = aux;
                }
            }
        }
    }

    // busca linear

    /// <summary>
    /// busca um valor na lista de dados usando o algoritmo de busca linear, 
    /// percorrendo a lista do início ao fim e comparando cada elemento com o valor buscado
    /// </summary>
    /// <param name="valor">valor a ser buscado</param>
    /// <returns>o Dado correspondente ao valor buscado, ou null se não encontrado</returns>
    public Dado? BuscaLinear(string valor)
    {
        foreach (Dado dado in dados)
        {
            if (Comparar(dado.Valor, valor) == 0)
            {
                return dado;
            }
        }

        return null;
    }

    // quick sort

    /// <summary>
    /// ordena a lista usando o algoritmo quick sort, chamando o método recursivo QuickSortRecursivo 
    /// para dividir e conquistar a lista em torno de um pivô
    /// </summary>
    public void QuickSort()
    {
        // chama o método recursivo para ordenar a lista (passando os índices inicial e final)
        QuickSortRecursivo(0, dados.Count - 1);
    }

    /// <summary>
    /// método recursivo do quick sort que particiona a lista em torno de um pivô 
    /// e chama a si mesmo para ordenar as sublistas à esquerda e à direita do pivô
    /// </summary>
    /// <param name="inicio">posição inicial da sublista a ser ordenada</param>
    /// <param name="fim">posição final da sublista a ser ordenada</param>
    private void QuickSortRecursivo(int inicio, int fim)
    {
        if (inicio < fim)
        {

            int pivo = Particionar(inicio, fim);

            QuickSortRecursivo(inicio, pivo - 1);

            QuickSortRecursivo(pivo + 1, fim);
        }
    }

    /// <summary>
    /// particiona a lista em torno de um pivô, escolhendo o último elemento como pivô 
    /// e rearranjando os elementos menores à esquerda e os maiores à direita do pivô
    /// </summary>
    /// <param name="inicio">posição inicial da sublista a ser particionada</param>
    /// <param name="fim">posição final da sublista a ser particionada</param>
    /// <returns> a posição do pivô após a partição</returns>
    private int Particionar(int inicio, int fim)
    {
        // escolhe o último elemento como pivô
        string pivo = dados[fim].Valor;

        int i = inicio - 1;

        // percorre a lista do início ao fim
        for (int j = inicio; j < fim; j++)
        {
            // compara o valor atual com o pivô
            if (Comparar(dados[j].Valor, pivo) <= 0)
            {
                i++;

                Dado aux = dados[i];
                dados[i] = dados[j];
                dados[j] = aux;
            }
        }

        Dado temp = dados[i + 1];
        dados[i + 1] = dados[fim];
        dados[fim] = temp;

        return i + 1;
    }

    // busca binária


    /// <summary>
    /// busca um valor na lista de dados usando o algoritmo de busca binária, assumindo que a lista está ordenada, 
    /// dividindo repetidamente a lista ao meio e comparando o valor do meio com o valor buscado
    /// </summary>
    /// <param name="valor">valor a ser buscado</param>
    /// <returns>o Dado correspondente ao valor buscado, ou null se não encontrado</returns>
    public Dado? BuscaBinaria(string valor)
    {
        int inicio = 0;

        int fim = dados.Count - 1;

        while (inicio <= fim)
        {
            // calcula o índice do meio da lista
            int meio = (inicio + fim) / 2;

            // compara o valor do meio com o valor buscado
            int comparacao = Comparar(dados[meio].Valor, valor);

            if (comparacao == 0)
            {
                return dados[meio];
            }

            if (comparacao < 0)
            {
                inicio = meio + 1;
            }
            else
            {
                fim = meio - 1;
            }
        }

        return null;
    }
}
