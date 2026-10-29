# Desafio Sessao Telefonia em C#

Aplicacao Console em .NET que reproduz o desafio `problemaSessaoTelefonia`.

## Formato do arquivo

Cada linha do arquivo de entrada tem o seguinte formato:

```text
numeroCelular;dadosSessao
```

Linhas vazias sao ignoradas. Linhas invalidas geram um aviso e nao sao
adicionadas. Quando o mesmo numero aparece mais de uma vez, o ultimo registro
substitui o anterior, como no `HashMap.put` original.

A busca usa `Dictionary<string, SessaoTelefonica>.TryGetValue`, evitando uma
varredura linear dos registros.
