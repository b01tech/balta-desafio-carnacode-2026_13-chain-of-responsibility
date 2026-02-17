![CO-1](https://github.com/user-attachments/assets/7b600675-587d-4e1a-9786-2ea50e35d8a7)

## 🥁 CarnaCode 2026 - Desafio 13 - Chain of Responsibility

Oi, eu sou o Bruno e este é o espaço onde compartilho minha jornada de aprendizado durante o desafio **CarnaCode 2026**, realizado pelo [balta.io](https://balta.io). 👻

Aqui você vai encontrar projetos, exercícios e códigos que estou desenvolvendo durante o desafio. O objetivo é colocar a mão na massa, testar ideias e registrar minha evolução no mundo da tecnologia.

### Sobre este desafio

No desafio **Chain of Responsibility** eu tive que resolver um problema real implementando o **Design Pattern** em questão.
Neste processo eu aprendi:

- ✅ Boas Práticas de Software
- ✅ Código Limpo
- ✅ SOLID
- ✅ Design Patterns (Padrões de Projeto)

## Problema

Uma empresa precisa processar pedidos de reembolso com diferentes níveis de aprovação baseados no valor.
O código atual usa condicionais gigantes e está difícil de manter quando novos níveis de aprovação são adicionados.

# Solução

Implementei o padrão Chain of Responsibility para desacoplar os níveis de aprovação e permitir composição dinâmica da cadeia.

- Contrato e base da cadeia: `ExpenseApprovalMiddleware.cs`
- Níveis concretos:
  - `SupervisorApprover.cs`
  - `ManagerApprover.cs`
  - `DirectorApprover.cs`
  - `CeoApprover.cs`
- Montagem da cadeia: `ExpenseApprovalChain.cs`

Fluxo:

- Cada aprovador declara seu limite (CanApprove) e validações (Validate).
- Se o nível não puder aprovar, encaminha automaticamente para o próximo.
- Aprovação registrada no próprio nível, mantendo responsabilidades únicas.

Como executar:

```bash
cd src/ChainChallenge
dotnet build
dotnet run
```

Saída:

```
[Supervisor] Analisando pedido...
✅ [Supervisor] Despesa de R$ 50,00 APROVADA

[Supervisor] Valor acima do meu limite, encaminhando...
[Gerente] Analisando pedido...
✅ [Gerente] Despesa de R$ 350,00 APROVADA

[Supervisor] Valor acima do meu limite, encaminhando...
[Gerente] Valor acima do meu limite, encaminhando...
[Diretor] Analisando pedido...
✅ [Diretor] Despesa de R$ 2.500,00 APROVADA

[Supervisor] Valor acima do meu limite, encaminhando...
[Gerente] Valor acima do meu limite, encaminhando...
[Diretor] Valor acima do meu limite, encaminhando...
[CEO] Analisando pedido...
✅ [CEO] Despesa de R$ 15.000,00 APROVADA
```

Extensibilidade:

- Para adicionar um novo nível, crie uma classe herdando de ExpenseApprovalMiddleware.
- Implemente CanApprove e Validate de acordo com o novo papel.
- Conecte o novo nível na montagem em ExpenseApprovalChain.

Comparativo:

- Antes: condicionais aninhadas e repetição de lógica de encaminhamento.
- Depois: níveis isolados, encaminhamento centralizado e composição flexível.

## Sobre o CarnaCode 2026

O desafio **CarnaCode 2026** consiste em implementar todos os 23 padrões de projeto (Design Patterns) em cenários reais. Durante os 23 desafios desta jornada, os participantes são submetidos ao aprendizado e prática na idetinficação de códigos não escaláveis e na solução de problemas utilizando padrões de mercado.

### eBook - Fundamentos dos Design Patterns

Minha principal fonte de conhecimento durante o desafio foi o eBook gratuito [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns).

### Veja meu progresso no desafio

[Repositório Central do Desafio](https://github.com/b01tech/desafio-carnacode-2026-design-patterns.git)
