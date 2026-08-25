namespace OrdenacaoObjetos.Model.Ordenacao;

/// <summary>
/// implementacao do Bubble Sort para objetos Processo,
/// percorre a lista comparando pares adjacentes e trocando
/// quando o id do primeiro e maior que o do segundo
/// </summary>
public class BubbleSort : IAlgoritmoOrdenacao
{
    public string Nome => "Bubble Sort";

    public void Ordenar(List<Processo> lista)
    {
        bool houveTroca;

        do
        {
            houveTroca = false;

            for (int i = 0; i < lista.Count - 1; i++)
            {
                if (lista[i].CompareTo(lista[i + 1]) > 0)
                {
                    // troca os elementos
                    Processo tmp = lista[i];
                    lista[i] = lista[i + 1];
                    lista[i + 1] = tmp;
                    houveTroca = true;
                }
            }
        }
        while (houveTroca);
    }
}
