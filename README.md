# InventorySystemConsole

Sistema de controle de estoque em console desenvolvido em C# — inspirado em gaps de visibilidade e rastreabilidade identificados em sistemas de almoxarifado reais.

O projeto serve como laboratório prático de engenharia de software: cada decisão de design foi tomada com propósito, não apenas para funcionar.

---

## Funcionalidades

- Login por matrícula com controle de acesso por cargo
- Cadastro de produtos com validação de código duplicado
- Movimentação de estoque (entrada e saída de mercadoria)
- Manutenção de produtos (alteração de nome e exclusão)
- Tratamento de erros com exceções de domínio personalizadas

---

## Controle de Acesso

| Ação                        | Operador | Gestor |
|-----------------------------|----------|--------|
| Movimentar estoque          | ✅        | ✅      |
| Listar e buscar produtos    | ✅        | ✅      |
| Cadastrar produto           | ❌        | ✅      |
| Alterar nome de produto     | ❌        | ✅      |
| Excluir produto             | ❌        | ✅      |
| Estornar produto            | ❌        | ✅      |

---

## Tecnologias

- C# / .NET
- Git / GitHub

---

## Estrutura do Projeto

```
InventorySystemConsole/
├── Interfaces/
│   └── IFuncionario.cs
├── Models/
│   ├── Cargo.cs
│   ├── Estoque.cs
│   ├── Funcionario.cs
│   ├── GestaoEstoque.cs
│   ├── GestaoFuncionarios.cs
│   ├── Gestor.cs
│   ├── Locacao.cs
│   ├── Operador.cs
│   ├── Produto.cs
│   └── TipoUnidade.cs
├── Exceptions/
│   └── EstoqueException.cs
├── UI/
│   ├── ConsoleInput.cs
│   └── Menus.cs
└── Program.cs
```

---

## Conceitos Aplicados

- **Herança:** `Funcionario` (abstrata) → `Operador` → `Gestor` (sealed)
- **Encapsulamento:** propriedades com `private set` em todas as classes
- **Composição:** `Estoque` contém `Produto` e `Locacao`
- **Responsabilidade única:** cada classe com domínio claro e separado
- **Exceções de domínio:** `EstoqueException` substitui retorno de strings de erro
- **Interface:** `IFuncionario` define contrato de operações por cargo
- **Separação de camadas:** `Models`, `UI`, `Interfaces` e `Exceptions` isolados
- **Persistência de Dados:** persistencia de dados usando arquivo JSON

---

## Como Rodar

```bash
git clone https://github.com/gabriel-biagi/InventorySystemConsole
cd InventorySystemConsole
dotnet run
```

Credenciais de teste:
- Matrícula `1000` → Operador
- Matrícula `9999` → Gestor

---

## Próximos Passos

- Tratamento de erros com exceções tipadas por operação
- Histórico de movimentações com `DateTime`
- Testes unitários com xUnit
- Migração para ASP.NET Web API
