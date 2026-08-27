# BuscaOrdenacaoMVC - C#

## Objetivo

Este projeto é uma adaptação da versão Java para C#, mantendo a arquitetura MVC e os algoritmos de busca e ordenação.

## Como executar

```bash
dotnet run
```

Ao carregar um arquivo, basta informar apenas o nome do arquivo, por exemplo:
```
numeros.txt
```
ou
```
numeros
```

## Lógica de comparação (números e textos)

Na versão em C#, foi implementado o método `Comparar()`, que identifica quando os valores são numéricos e realiza a comparação como int. Caso contrário, a comparação é feita como String, permitindo que os algoritmos de busca e ordenação funcionem corretamente tanto para números quanto para textos.

```csharp
private static int Comparar(string valor1, string valor2)
    {
        if (EhNumero(valor1) && EhNumero(valor2))
        {
            return int.Parse(valor1).CompareTo(int.Parse(valor2));
        }
        
        return string.Compare(valor1, valor2, StringComparison.OrdinalIgnoreCase);
    }
```