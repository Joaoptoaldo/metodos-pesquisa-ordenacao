# Pesquisa de Nomes

Projeto didático em C# com Windows Forms e dois projetos:

- **PesquisaLib**: contém a pesquisa sequencial e a pesquisa digital por prefixo, usando uma Trie.
- **PesquisaView**: permite cadastrar nomes, bloquear duplicados e pesquisar enquanto o usuário digita.

## Requisitos

- Windows
- .NET SDK 10

## Como funciona

- A View guarda os nomes em uma `List<string>` durante a execução.
- A pesquisa sequencial verifica se um nome já foi cadastrado.
- A pesquisa digital encontra nomes pelo início digitado, como `jo` para `João`.
- As buscas ignoram maiúsculas/minúsculas e acentos, e simplificam espaços excedentes.


## Separação dos projetos

A View cuida da tela e do cadastro. A biblioteca contém os algoritmos e a Trie. A View referencia `PesquisaLib.csproj`, mantendo os projetos separados, sem copiar a implementação dos algoritmos para o código da interface.

## Usar a DLL compilada no lugar do projeto-fonte

Estes passos fazem a View usar somente a biblioteca compilada (`PesquisaLib.dll`), sem referenciar diretamente `PesquisaLib.csproj`.

### 1. Compilar a biblioteca

No diretório `PesquisaAlgoritmos`, execute:

```powershell
dotnet build .\PesquisaLib\PesquisaLib.csproj -c Release
```

A DLL será criada em:

```text
PesquisaLib/bin/Release/net10.0/PesquisaLib.dll
```

### 2. Copiar a DLL para a View

Crie a pasta `libs` dentro de `PesquisaView` e copie a DLL para ela:

```powershell
New-Item -ItemType Directory -Force .\PesquisaView\libs
Copy-Item .\PesquisaLib\bin\Release\net10.0\PesquisaLib.dll .\PesquisaView\libs\PesquisaLib.dll -Force
```

A View agora referencia a DLL compilada.

### 4. Compilar e executar a View

Execute:

```powershell
dotnet build .\PesquisaView\PesquisaView.csproj
dotnet run --project .\PesquisaView\PesquisaView.csproj
```

Para testar a View de forma independente, use esses comandos no projeto `PesquisaView`. Se compilar a solução inteira (`.sln`), o Visual Studio Code/.NET ainda poderá compilar o projeto `PesquisaLib` caso ele continue listado na solução.
