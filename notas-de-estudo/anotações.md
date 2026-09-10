Aula 01 (30/07/2026)

## Conceito de busca e ordenação

Busca e ordenação são técnicas fundamentais de programação para localizar e organizar dados. Os principais métodos são a ⁠Busca & Ordenação linear, a busca binária e algoritmos como o Bubble Sort e o Quick Sort, que ajudam a gerenciar listas de forma rápida e eficiente.

---

- Algoritmos de busca:
- A busca serve para encontrar um item específico dentro de uma estrutura de dados.

  - Busca Linear: Olha cada elemento da lista um por um, do início ao fim. É simples, mas lenta para listas grandes.
  - Busca Binária: Corta a lista ao meio repetidas vezes para achar o valor. Só funciona se os dados já estiverem organizados, sendo muito mais rápida.

  - complexidade computacional: é a quantidade de esforço computacional (tarefas, rotinas, métodos) envolvido no algoritmo
      - Na ordenação a complexidade dos algoritmos é medida pela quantidade de:
          - comparações
          - trocas

         Categorias:

            Complexidade fatorial       - O(n!)         - menos eficiente
            Complexidade polinomial     - O(n^k) 
            Complexidade Exponencial    - O(n^2)
            Complexidade Linear         - O(n)
            Complexidade Logaritmica    - O(log n)      - mais eficaz

- Ordenar = otimizar busca de dados
- Buscar/pesquisar = encontrar dados
- Encontrar dados != recuperar dados
- Complexidade = esforço computacional para resolver um problema
  - Complexidade baixa = esforço computacional baixo
  - Complexidade alta = esforço computacional alto

---

- Algoritmos de ordenação:

- A ordenação coloca os elementos em uma ordem lógica, como do menor para o maior.

  - Bubble Sort: Compara elementos adjacentes e troca-os se estiverem na ordem errada. É fácil de entender, mas não é eficiente para listas grandes.
  - Quick Sort: Escolhe um "pivô" e organiza os elementos menores à esquerda e os maiores à direita, repetindo o processo. É muito rápido para listas grandes.


---

Aula 02 (06/08/2026)

## Nota 002 - Padrão MVC

O que é MVC?

  - O **MVC (Model-View-Controller)** é um padrão de arquitetura que organiza o código separando as responsabilidades da aplicação.

Essa divisão facilita a manutenção, organização e reutilização do código.

---

### Model

Responsável pelos **dados** e pela **lógica relacionada aos modelos**

---

### View

Responsável pela **interação com o usuário**

---

### Controller

Responsável por **controlar o fluxo da aplicação**

---

### Program (Main)

É o ponto de entrada da aplicação

---

### Fluxo da aplicação

```text
Program
   │
   ▼
Controller
   │
   ├──► Model (processa os dados)
   │
   └──► View (exibe os resultados)
```

---

### Vantagens do MVC

- Organização do código
- Separação de responsabilidades
- Facilidade de manutenção
- Maior reutilização de código
- Melhor escalabilidade para projetos maiores


---

Aula 03 - 06 



# ORDENAR E PESQUISAR
    - ordenar agiliza a pesquisa
    - classificações de ordenação
        - quanto complexidade (esforço/quantidade de processamento): quantidade de comparações e quantidade de trocas
        - quanto ocupação de memória: principal ou secundária
        - quanto a estabilidade: estáveis e instáveis


## MÉTODOS DE ORDENAÇÃO SIMPLES

### 1) BOLHA - Bubble Sort
    - Estável
    - Memória Interna
    - Alta complexidade (muito esforço) - O(n^2)

    A estrutura possui 2 partes/porções (1a é a desordenada; 2a parte é a ordenada)
    Adequado para listaes e listas

    0   1   2   3   4   5   6
    7   1   4   2   3   9   8
    1   4   2   3   7   8   9
    1   2   3   4   7   8   9
    1   2   3   4   7   8   9


```c#
void bolha(List<> lista) {
    bool houveTroca;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;

    do {
        houveTroca = False;
        for (int i = 0; i < lista.Count()-1; i++){
            qtdComparacoes++;
            if (lista[i] > lista[i+1]) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista[i];
                lista[i] = lista[i+1];
                lista[i+1] = tmp;
            }
        }
    } while (houveTroca);
}
````

```java
void bolha(List<> lista) {
    boolean houveTroca;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;

    do {
        houveTroca = False;
        for (int i = 0; i < lista.size()-1; i++){
            qtdComparacoes++;
            if (lista.get(i) > lista.get(i+1)) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista.get(i);
                lista.set(i, lista.get(i+1));
                lista.set(i+1, tmp);
            }
        }
    } while (houveTroca);
}
```

```python
def bolha(lista):
    houve_troca = true
    qtd_comparacoes = 0
    qtd_trocas = 0
    while (houve_troca):    
        houveTroca = false
        for i in range (len(lista) - 1):
            qtd_comparacoes+=1
            if (lista[i] > lista[i+1]):
                qtd_trocas+=1
                houve_troca = true
                tmp = lista[i]
                lista[i] = lista[i+1]
                lista[i+1] = tmp
```

Trabalha com o conceito de trocas, ou seja, enquanto houver trocas, o algoritmo não para.
É considerado bolha, porque 'leva' os maiores para o final da estrutura

Observação: se a estrutura estiver ordenada ou quase, o bolha terá excelente desempenho

### 2) SELEÇÃO - Selection Sort
    - Instável
    - Memória Interna
    - Alta complexidade (muito esforço) - O(n^2)

    A estrutura possui 2 partes/porções (1a é a ordenada; 2a parte é a desordenada)
    Adequado para listaes e listas

    Trabalha com conceito de trocas não contíguas. É considerado seleção porque ele seleciona os menores para
    o início da estrutura

    Observação: se a estrutura estiver ordenada, o método vai funcionar/processar como se a estrutura estivesse desordenada

    0   1   2   3   4   5   6    posMenor = 1
    7   1   4   2   3   9   8
    1   7   4   2   3   9   8
    1   2   4   7   3   9   8
    1   2   3   7   4   9   8
    1   2   3   4   7   9   8
    1   2   3   4   7   9   8
    1   2   3   4   7   8   9
    1   2   3   4   7   8   9  


```c#
void selecao(List<> lista) {
    int posMenor;
    int qtd_comparacoes = 0, qtd_trocas = 0;
    for (int i = 0; i < lista.Count()-1; i++) {
        posMenor = i;
        for (int j = i+1; j < lista.Count(); j++) {
            qtd_comparacoes++;
            if (lista[j] < lista[posMenor]) {
                posMenor = j;
            }
        }
        if (i != posMenor) {
            qtd_trocas++;
            tmp = lista[i];
            lista[i] = lista[posMenor];
            lista[posMenor] = tmp;
        }
    }
}
```

```java
void selecao(List<> lista) {
    int posMenor;
    int qtd_comparacoes = 0, qtd_trocas = 0;
    for (int i = 0; i < lista.size()-1; i++) {
        posMenor = i;
        for (int j = i+1; j < lista.size(); j++) {
            qtd_comparacoes++;
            if (lista.get(j) < lista.get(posMenor)) {
                posMenor = j;
            }
        }
        if (i != posMenor) {
            qtd_trocas++;
            tmp = lista.get(i);
            lista.set(i, lista.get(posMenor));
            lista.set(posMenor, tmp);
        }
    }
}
```

```python
def selecao(lista):
    qtd_comparacoes = 0
    qtd_trocas = 0
    for i in range(len(lista) - 1):
        posMenor = i
        for j in range(i+1, len(lista)):
            qtd_comparacoes+=1
            if (lista[j] < lista[posMenor]):
                posMenor = j
            
        if (i != posMenor):
            qtd_trocas+=1
            tmp = lista[i]
            lista[i] = lista[posMenor]
            lista[posMenor] = tmp        
```


### 3) INSERÇÃO - Insertion Sort - O(n^2)
    - Estável
    - Memória Interna
    - Alta complexidade - O(n^2)

    A estrutura possui 2 partes/porções (1a é a ordenada; 2a parte é a desordenada)
    Adequado para listaes e listas

    Trabalha com o conceito de inserção na porção inicial, com isso, pode diminuir o número de comparações

    Observação: i) se a estrutura estiver ordenada ou quase, o inserção terá excelente desempenho

    Qual o melhor método de ordenação?
    Depende: tamanho da estrutura; de como a estrutura já está previamente ordenada;

    0   1   2   3   4   5   6
    7   1   4   2   3   9   8
    1   7   4   2   3   9   8
    1   4   7   2   3   9   8
    1   2   4   7   3   9   8
    1   2   3   4   7   9   8
    1   2   3   4   7   9   8
    1   2   3   4   7   8   9   

```c#
void insercao(Lista<> lista) {
    int i, j;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;

    for (i = 1; i < lista.Count(); i++) {
        tmp = lista[i];
        for (j = i - 1; j >= 0; j--) {
            qtdComparacoes++;
            if (tmp < lista[j]) {
                lista[j + 1] = lista[j]; //shift eh trocar para o lado
                qtdTrocas++;
            } else break;
        }
        lista[j + 1] = tmp;
        qtdTrocas++;
    }
}
```

```java
void insercao(Lista<> lista) {
    int i, j;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;

    for (i = 1; i < n; i++) {
        tmp = lista.get(i);
        for (j = i - 1; j >= 0; j--) {
            qtdComparacoes++;
            if (tmp < lista.get(j)) {
                lista.set(j + 1, lista.get(j));
                qtdTrocas++;
            } else break;
        }
        lista.set(j + 1, tmp);
        qtdTrocas++;
    }
}
```

```python
def insercao(lista):
    qtd_comparacoes = 0
    qtd_trocas = 0

    for i in range(1, len(lista)):
        tmp = lista[i]
        for j in range(i - 1, -2, -1):
            qtd_comparacoes+=1
            if (tmp < lista[j]):
                lista[j + 1] = lista[j]
                qtd_trocas+=1
            else:
                break

        lista[j + 1] = tmp
        qtd_trocas+=1
```


### 4) AGITAÇÃO - Shake Sort ou Cocktail
    - É baseado no Bolha, ou seja, é uma tentantiva de melhorar o Bolha.
    - Estável
    - Memória Interna
    
    A estrutura possui 3 partes/porções (1a é a ordenada pelos menores; 2a é a desordenada; 3a é a ordenada pelos maiores)

    De fato é a aplicação do bolha da esquerda para direita e depois da direita para esquerda

    Há os índices/ponteiros ini e fim que marcam o início e o final da estrutura. E que vão diminuindo (fim) e aumentando (inicio) conforme as passadas dos fores

    Observação: 
        i) se a estrutura estiver ordenada ou quase, o agitação terá excelente desempenho, como o bolha
        ii) atenção a lista deve ser duplamente encadeada  

    ini = 1
    fim = 4

    0   1   2   3   4   5   6
    7   1   4   2   3   9   8
    1   4   2   3   7   8   9
    1   2   4   3   7   8   9
    1   2   3   4   7   8   9
    1   2   3   4   7   8   9


```c#
void agitacao(List<> lista) {
    bool houveTroca;
    int tmp;
    int ini = 0;
    int fim = lista.Count;
    int qtdComparacoes = 0, qtdTrocas = 0;  //avalia a complexidade ou o esforço

    do {
        houveTroca = False;
        for (int i = ini; i < fim-1; i++){
            qtdComparacoes++;
            if (lista[i] > lista[i+1]) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista[i];
                lista[i] = lista[i+1];
                lista[i+1] = tmp;
            }
        }

        if (!houveTroca) {
            break;
        }
        fim--;

        houveTroca = False;
        for (int i = fim; i > ini+1; i--){
            qtdComparacoes++;
            if (lista[i] < lista[i-1]) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista[i];
                lista[i] = lista[i-1];
                lista[i-1] = tmp;
            }
        }
        ini++;

    } while (houveTroca);
}
````

```java
void agitacao(List<> lista) {
    boolean houveTroca;
    int tmp;
    int ini = 0;
    int fim = lista.size();
    int qtdComparacoes = 0, qtdTrocas = 0;

    do {
        houveTroca = false;
        for (int i = ini; i < fim-1; i++){
            qtdComparacoes++;
            if (lista.get(i) > lista.get(i+1)) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista.get(i);
                lista.set(i, lista.get(i+1));
                lista.set(i+1, tmp);
            }
        }

        if (!houveTroca) {
            break;
        }
        fim--;

        houveTroca = False;
        for (int i = fim; i > ini+1; i--){
            qtdComparacoes++;
            if (lista.get(i) < lista.get(i-1)) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista.get(i);
                lista.set(i, lista.get(i-1);
                lista.set(i-1, tmp);
            }
        }
        ini++;

    } while (houveTroca);
}
````

```python
def agitacao(lista):
    ini = 0
    fim = len(lista)
    qtd_comparacoes = 0
    qtd_trocas = 0

    while(True):
        houveTroca = False
        for i in range(ini, fim-1):
            qtd_comparacoes+=1
            if (lista[i] > lista[i+1]):
                qtd_trocas+=1
                houveTroca = True
                tmp = lista[i]
                lista[i] = lista[i+1]
                lista[i+1] = tmp
            
        if (not houveTroca):
            break
        
        fim-=1

        houveTroca = False
        for i in range(fim, ini, -1):
            qtd_comparacoes+=1
            if (lista[i] < lista[i-1]):
                qtd_trocas+=1
                houveTroca = True
                tmp = lista[i]  
                lista[i] = lista[i-1]
                lista[i-1] = tmp
            
        ini+=1

        if (not houveTroca):
            break
```


### 5) PENTE - Comb Sort
    - É baseado no Bolha, ou seja, é uma tentantiva de melhorar o Bolha.

    ATENÇÃO: a partir deste método, há COMPARAÇÕES a uma distância X. Isso gera uma pré-organização da estrutura, diminuindo número de comparações e trocas.

    - Instável
    - Memória Interna
    
    A estrutura possui 2 porções/partes (1a é a ordenada; 2a é a desordenada)

    Há as variáveis clássicas do bolha: i, houveTroca, tmp.
    Há a variável distancia que é calculada pelo tamanho da estrutura dividido por 1.3

    Adequado somente para listas ou estruturas prontas tipo lista de uma linguagem de programação

    n = 7
    0   1   2   3   4   5   6   
    7   1   4   2   3   9   8       distancia = (int)n / 1.3 = 5
    7   1   4   2   3   9   8       distancia = (int)distancia / 1.3 = 3
    2   1   4   7   3   9   8       distancia = (int)n / 1.3 = 2
    2   1   3   7   4   9   8       distancia = (int)n / 1.3 = 1
    1   2   3   4   7   8   9       distancia = (int)n / 1.3 = 1
    1   2   3   4   7   8   9




```c#
void pente(List<> lista) {
    bool houveTroca;
    int tmp;
    int distancia = lista.Count;
    int qtdComparacoes = 0, qtdTrocas = 0;

    do {
        distancia = (int)distancia / 1.3;
        if (distancia < 1) {
            distancia = 1;
        }
        houveTroca = false;
        for (int i = 0; i < lista.Count - distancia; i++){
            qtdComparacoes++;
            if (lista[i] > lista[i+distancia]) {
                qtdTrocas++;
                houveTroca = true;
                tmp = lista[i];
                lista[i] = lista[i+distancia];
                lista[i+distancia] = tmp;
            }
        }
    } while (houveTroca || distancia > 1);
}
````


```java
void pente(List<> lista) {
    bool houveTroca;
    int tmp;
    int distancia = lista.size();
    int qtdComparacoes = 0, qtdTrocas = 0;

    do {
        distancia = (int)distancia / 1.3;
        if (distancia < 1) {
            distancia = 1;
        }
        houveTroca = false;
        for (int i = 0; i+distancia < lista.size(); i++){
            qtdComparacoes++;
            if (lista.get(i) > lista.get(i+distancia)) {
                qtdTrocas++;
                houveTroca = True;
                tmp = lista[i];
                lista.set(i, lista[i+distancia]);
                lista.set(i+distancia, tmp);
            }
        }
    } while (houveTroca || distancia > 1);
}
````

### 6) SHELLSORT 
    É baseado no Inserção, ou seja, é uma tentativa de melhoria via o uso da ANÁLISE A DISTÂNCIA (tipo pente)

    - Instável 
    - Memória Interna

    Não é adequado para listas encadeadas

    n = 7
    0   1   2   3   4   5   6   
    7   1   4   2   3   9   8       distancia = 4


```c#
void shell(Lista<> lista) {
    int i, j;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;
    int distancia = 1;

    int referenciaTamanho = 3;

    do {
        distancia = referenciaTamanho * distancia + 1;
    } while (distancia < n);
    
    do {
        distancia = (int)(distancia / referenciaTamanho);
        
        for (i = distancia; i < n; i++) {
            tmp = vetor[i];
            for (j = i - distancia; j >= 0; j = j - distancia) {
                qtdComparacoes++;
                if (tmp < vetor[j]) {
                    vetor[j + distancia] = vetor[j];
                    qtdTrocas++;
                } else break;
            }
            vetor[j + distancia] = tmp;
            qtdTrocas++;
        }
    } while (distancia > 1);
}
```

```java
void shell(Lista<> lista) {
    int i, j;
    int tmp;
    int qtdComparacoes = 0, qtdTrocas = 0;
    int distancia = 1;

    int referenciaTamanho = 3;

    do {
        distancia = referenciaTamanho * distancia + 1;
    } while (distancia < n);
    
    do {
        distancia = (int)(distancia / referenciaTamanho);
        
        for (i = distancia; i < n; i++) {
            tmp = vetor[i];
            for (j = i - distancia; j >= 0; j = j - distancia) {
                qtdComparacoes++;
                if (tmp < vetor[j]) {
                    vetor[j + distancia] = vetor[j];
                    qtdTrocas++;
                } else break;
            }
            vetor[j + distancia] = tmp;
            qtdTrocas++;
        }
    } while (distancia > 1);
}
```


### 7) QUICKSORT (USA O CONCEITO DE DIVIDIR PARA CONQUISTAR)
    Faz parte de uma categoria de métodos de ordenação que utilizam a divisão da estrutura para acelerar a ordenação. Essa divisão é realizada por 
    meio de RECURSÃO.
        - A estrutura possui 2 porções: parte esquerda e parte direita, divididas pelo PIVO. Pensar como se fosse uma ÁRVORE BINÁRIA desbalanceada
        - O método possui duas funções: quick (processo recursivo) e o particiona (posiciona/ordena o pivo)

    0   1   2   3   4   5   6   7   8
    30  90  10  20  80  10  20  40  10      ini = 0  fim = 8   pivo = 0/30
    10  90  10  20  80  10  20  40  30      ini = 1  fim = 8   pivo = 8/30
    10  30  10  20  80  10  20  40  90      ini = 1  fim = 7   pivo = 1/30
    10  20  10  20  80  10  30  40  90      ini = 4  fim = 6   pivo = 6/30
    10  20  10  20  30  10  80  40  90      ini = 4  fim = 5   pivo = 4/30
    10  20  10  20  30  10  80  40  90      ini = 4  fim = 5   pivo = 4/30
    10  20  10  20  10  30  80  40  90      ini = 5  fim = 5   pivo = 5/30
                        30
    10  20  10  20  10      ini = 0  fim = 4   pivo = 0/10
    10
        20  10  20  10      ini = 1  fim = 4    pivo = 1/20
        10  10  20  20      ini = 2  fim = 4    pivo = 4/20
                    20
        10  10  20          ini = 1  fim = 3    pivo = 1/10
                            80  40  90      ini = 6  fim = 8   pivo = 6/80
                            40  80  90      ini = 7  fim = 7   pivo = 7/80

    10  10  10  20  20  30  40  80  90

```c
int particiona(int *vetor, int ini, int fim) {
    int pivo;
    int tmp; //para as trocas

    pivo = ini; //na bibliografia do método, é possível ser o ini, o fim ou uma posição sorteada
    while (fim > ini) {

        //analise da direita para esquerda
        for (; fim > pivo && vetor[fim] > vetor[pivo]; fim--, qtd_comparacoes++); //garantindo que os maiores fiquem na direita

        if (fim > pivo) {
            qtdTrocas++;
            tmp = vetor[pivo];
            vetor[pivo] = vetor[fim];
            vetor[fim] = tmp;
            pivo = fim;
        }

        //analise da esquerda para direita
        for (ini++; ini < pivo && vetor[ini] < vetor[pivo]; ini++, qtdComparacoes++);

        if (ini < pivo) {
            qtdTrocas++;
            tmp = vetor[pivo];
            vetor[pivo] = vetor[ini];
            vetor[ini] = tmp;
            pivo = ini;
        }
    }
    return pivo;
}

void quickSort(int *vetor, int ini, int fim) { //método recurisivo baseado em árvore desbalanceada
    int pivo;

    pivo = particiona(vetor, ini, fim); //no final do particiona, o pivo está ordenado e é retornado a posição do pivo
    
    if (ini < pivo - 1) //tem lado esquerdo com mais de 1 elemento
        quickSort(vetor, ini, pivo - 1); //se existe lado esq do pivo, executa lado esq
    if (pivo + 1 < fim) //tem lado direito com mais de 1 elemento
        quickSort(vetor, pivo + 1, fim); //se existe lado dir do pivo, executa lado dir
}
```


### 8) MERGESORT (como o quicksort, USA O CONCEITO DE DIVIDIR PARA CONQUISTAR)
Faz parte de uma categoria de métodos de ordenação que utilizam a divisão da estrutura para acelerar a ordenação. Essa divisão é realizada por 
meio de RECURSÃO.

Contudo, diferente do QUICKSORT, o MERGESORT sempre divide a estrutura no meio (vai existir uma variável meio)

- A estrutura possui 2 porções: parte esquerda e parte direita, divididas pelo MEIO. Pensar como se fosse uma ÁRVORE BINÁRIA
- O método possui duas funções: merge (processo recursivo) e o intercala (a ordenação vai funcionar no desempilhamento do processo em que intercala e ordena)

```java
public class MergeSort {

    // Variáveis de instância para rastreamento (equivalentes às globais do exemplo em C)
    public static int qtdComparacoes = 0;
    public static int qtdTrocas = 0; // Representa as movimentações/cópias de elementos

    // Função que intercala e ordena as metades no desempilhamento
    public static void intercala(int[] vetor, int ini, int meio, int fim) {
        int i = ini;         // Índice da primeira metade
        int j = meio + 1;    // Índice da segunda metade
        int k = 0;           // Índice para o vetor auxiliar
        
        // Cria o vetor temporário para auxiliar na junção
        int[] vetorAux = new int[fim - ini + 1];

        // Compara e intercala os elementos das duas metades
        while (i <= meio && j <= fim) {
            qtdComparacoes++;
            if (vetor[i] <= vetor[j]) {
                vetorAux[k] = vetor[i];
                i++;
            } else {
                vetorAux[k] = vetor[j];
                j++;
            }
            k++;
        }

        // Copia os elementos restantes da primeira metade, se houver
        while (i <= meio) {
            vetorAux[k] = vetor[i];
            i++;
            k++;
        }

        // Copia os elementos restantes da segunda metade, se houver
        while (j <= fim) {
            vetorAux[k] = vetor[j];
            j++;
            k++;
        }

        // Transfere os elementos ordenados do vetor auxiliar de volta para o vetor original
        for (i = ini, k = 0; i <= fim; i++, k++) {
            qtdTrocas++; 
            vetor[i] = vetorAux[k];
        }
    }

    // Função recursiva baseada em árvore binária balanceada
    public static void mergeSort(int[] vetor, int ini, int fim) {
        if (ini < fim) {
            int meio = (ini + fim) / 2; // Divide a estrutura exatamente no meio

            mergeSort(vetor, ini, meio);     // Divide a metade esquerda
            mergeSort(vetor, meio + 1, fim); // Divide a metade direita

            // A ordenação real acontece aqui, no desempilhamento
            intercala(vetor, ini, meio, fim);
        }
    }

    // Método principal para demonstração e testes
    public static void main(String[] args) {
        // Vetor baseado no exemplo do enunciado do QuickSort
        int[] vetor = {30, 90, 10, 20, 80, 10, 20, 40, 10};

        System.out.println("Vetor original:");
        imprimirVetor(vetor);

        // Executa o Merge Sort
        mergeSort(vetor, 0, vetor.length - 1);

        System.out.println("\nVetor ordenado:");
        imprimirVetor(vetor);

        System.out.println("\nEstatísticas:");
        System.out.println("Quantidade de comparações: " + qtdComparacoes);
        System.out.println("Quantidade de cópias/trocas: " + qtdTrocas);
    }

    // Método auxiliar para exibir o vetor na tela
    private static void imprimirVetor(int[] vetor) {
        for (int num : vetor) {
            System.out.print(num + " ");
        }
        System.out.println();
    }
}
```
---

Aula 07 (10/09/2026)

Mergesort 

    - Categoria de codificação complexa
    - Complexidade: O(n * log n)
    - Implementado no ecossistema Java
    - Método recursivo que dividade a estrutura para ordenar
        - primeiro método: recursão
        - segundo método: intercalação (aqui occorre a ordenação; e é o retorno do empilhamento ou da chamada recursiva)
        - SEMPRE divide a estrutura mais ao meio (uniforme)
        - volta da recursão -> intercalação

Quicksort

    - Categoria de codificação complexa
    - Complexidade: O(n * log n)
    - Implementado no ecossistema C#
    - Método recursivo que divide as estrutura para ordenar (princípio de árvore)
        - primeiro método: recursão
        - segundo método: posicionar o pivo na estrutura
        - NUNCA divide a estrutura de forma uniforme (PIVO)
        - recursão: posicionar pivo
        