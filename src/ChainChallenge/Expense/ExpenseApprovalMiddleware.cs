namespace ChainChallenge.Expense;

public interface IExpenseApprover
{
    IExpenseApprover SetNext(IExpenseApprover next);
    bool Handle(ExpenseRequest request);
}

public abstract class ExpenseApprovalMiddleware : IExpenseApprover
{
    private IExpenseApprover? _next;

    public IExpenseApprover SetNext(IExpenseApprover next)
    {
        _next = next;
        return next;
    }

    public bool Handle(ExpenseRequest request)
    {
        if (CanApprove(request))
        {
            Console.WriteLine($"[{Role}] Analisando pedido...");
            if (Validate(request))
            {
                Console.WriteLine($"✅ [{Role}] Despesa de R$ {request.Amount:N2} APROVADA");
                RegisterApproval(Role, request);
                return true;
            }
            Console.WriteLine($"❌ [{Role}] Despesa REJEITADA");
            return false;
        }

        Console.WriteLine($"[{Role}] Valor acima do meu limite, encaminhando...");
        if (_next is not null)
        {
            return _next.Handle(request);
        }
        Console.WriteLine("❌ Nenhum nível capaz de aprovar");
        return false;
    }

    protected abstract string Role { get; }
    protected abstract bool CanApprove(ExpenseRequest request);
    protected abstract bool Validate(ExpenseRequest request);

    protected virtual void RegisterApproval(string approver, ExpenseRequest request)
    {
        Console.WriteLine($"  → Registrando aprovação por {approver}...");
    }
}
