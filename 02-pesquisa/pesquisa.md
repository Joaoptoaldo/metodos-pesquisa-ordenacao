# Pesquisa/Busca

Pesquisa ou busca é o processo de localizar um elemento específico dentro de uma coleção de dados. Existem diferentes métodos de pesquisa, cada um com suas próprias características e eficiências. A escolha do método de pesquisa adequado depende do tipo de dados, da estrutura da coleção e dos requisitos de desempenho.

Exemplos de métodos de pesquisa incluem:

- **Pesquisa Linear (Busca Sequencial)**: Examina cada elemento da coleção, um por um, até encontrar o elemento desejado ou chegar ao final da coleção. É simples, mas pode ser ineficiente para grandes conjuntos de dados.

- **Pesquisa Binária**: Requer que a coleção esteja ordenada. Divide repetidamente a coleção ao meio, comparando o elemento do meio com o elemento desejado, até encontrar o elemento ou determinar que ele não está presente. É muito eficiente para grandes conjuntos de dados ordenados.

- **Pesquisa por Interpolação**: Semelhante à pesquisa binária, mas estima a posição do elemento desejado com base em uma função de interpolação. Pode ser mais eficiente que a pesquisa binária em certas distribuições de dados.

- **Pesquisa em Árvores**: Utiliza estruturas de dados em árvore, como árvores binárias de busca, para localizar elementos. A eficiência depende da altura da árvore e da distribuição dos elementos.

- **Pesquisa em Hashing**: Utiliza funções de hash para mapear elementos a índices em uma tabela de hash, permitindo acesso rápido aos elementos. A eficiência depende da qualidade da função de hash e da gestão de colisões.

- **Pesquisa em Grafos**: Utiliza algoritmos específicos para explorar grafos, como busca em largura (BFS) e busca em profundidade (DFS), para localizar elementos ou caminhos dentro de uma estrutura de grafo.
