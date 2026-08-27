# BuscaOrdenacaoMVC - Java

## Objetivo

Desafio da disciplina de Métodos de Pesquisa e Ordenação, aplicando conceitos de:

- Padrão MVC
- Leitura de arquivos
- Manipulação de listas
- Algoritmos de busca
- Algoritmos de ordenação

## Algoritmos implementados

- Busca Linear
- Busca Binária
- Bubble Sort
- Quick Sort

## Como executar

Compile o projeto:
```bash
javac -d bin src/Main.java src/controller/*.java src/model/*.java src/view/*.java
```

Execute a aplicação:

```bash
java -cp bin Main
```

Ao carregar um arquivo, você pode informar apenas o nome do arquivo localizado na pasta `Data` (com ou sem extensão), por exemplo:

```
pessoas.txt
```
ou
```
pessoas
```

---

[Versão equivalente desenvolvida em C#](../BuscaOrdenacaoMVC_CSharp/README.md), mantendo a mesma arquitetura MVC e os mesmos algoritmos implementados.