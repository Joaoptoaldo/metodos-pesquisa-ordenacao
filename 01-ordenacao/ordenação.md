# Ordenação

Processo de organizar elementos em ordem crescente ou decrescente. Os algoritmos clássicos diferem em complexidade, estabilidade e uso de memória.

## Algoritmos implementados

- **Bubble Sort**: compara pares adjacentes e troca quando estão fora de ordem. Implementação com flag `houveTroca`, então percorre a lista uma única vez quando já está ordenada.
- **Selection Sort**: a cada passada, coloca o menor elemento restante na posição correta.
- **Insertion Sort**: insere cada elemento na posição certa do trecho já ordenado à esquerda. Usa **shifts** (deslocamentos) em vez de trocas tradicionais o contador `movimentações` reflete isso.
- **Sort nativo**: delega à API da linguagem.
    - **C#** `List<T>.Sort()` usa **Introsort** (híbrido QuickSort + HeapSort + InsertionSort).
    - **Java** `Collections.sort(List<T>)` usa **TimSort** (híbrido MergeSort + InsertionSort).

## Comparação

| Algoritmo             | Melhor      | Médio        | Pior         | Estável | Extra     |
|-----------------------|-------------|--------------|--------------|---------|-----------|
| Bubble Sort           | O(n)*       | O(n²)        | O(n²)        | Sim     | O(1)      |
| Selection Sort        | O(n²)       | O(n²)        | O(n²)        | Não     | O(1)      |
| Insertion Sort        | O(n)        | O(n²)        | O(n²)        | Sim     | O(1)      |
| Sort nativo (C#)      | O(n log n)  | O(n log n)   | O(n log n)   | Não     | O(log n)  |
| Sort nativo (Java)    | O(n)        | O(n log n)   | O(n log n)   | Sim     | O(n)      |

\* O(n) no melhor caso vale apenas para a versão otimizada com flag de parada, que é a que está implementada. A versão clássica sem flag é O(n²) mesmo em lista já ordenada.

## Sobre o "Sort nativo"

Internamente o `List.Sort()` do C# e o `Collections.sort()` do Java fazem milhares de comparações e movimentações, mas as APIs **não expõem** esses contadores. O código retorna `comparações=0` e `trocas=0` e `movimentações=0` para o Sort nativo não porque ele não faça, mas porque não há como instrumentar essas métricas sem reescrever o algoritmo. Por isso **as métricas de comparações, trocas e movimentações só são significativas para os três algoritmos implementados à mão**.

## Métricas instrumentadas

Cada execução mede:
- **Comparações**: quantas vezes dois elementos foram comparados
- **Trocas**: swaps reais de dois elementos (Bubble, Selection)
- **Movimentações**: shifts/deslocamentos (Insertion Sort) cada vez que um elemento é arrastar para a direita
- **Tempo**: milissegundos via `Stopwatch` (C#) / `System.nanoTime()` (Java)

No Insertion Sort, o contador de **movimentações** conta os shifts (arrastar o maior para a direita) + a reinserção final do elemento guardado. Não há "trocas" tradicionais nesse algoritmo; por isso `Trocas=0` e `Movimentações>0`.

## Modos de execução

### Execução individual (menu opções 4-7)

O algoritmo roda **sobre a lista atual em memória**. A lista fica ordenada para a próxima execução. Útil para testar um algoritmo específico e ver o estado da lista depois dele.

### Comparação experimental (menu opção 3)

Executa **todos os algoritmos em sequência**, cada um recebendo uma **cópia independente** da mesma lista original. Isso garante comparação justa: todos partem da mesma entrada desordenada, sem que um algoritmo "aproveite" o trabalho do anterior. A lista em memória **não é modificada** após a comparação.

## O que o código mostra

Ambos os projetos (C# e Java) seguem o padrão MVC. Para cada execução o programa mede **comparações**, **trocas**, **movimentações** e **tempo em ms**, permitindo comparar empiricamente os algoritmos na mesma entrada.

## Código

- [Ordenação MVC em C#](csharp/OrdenacaoMVC/)
- [Ordenação MVC em Java](java/OrdenacaoMVC/)