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
