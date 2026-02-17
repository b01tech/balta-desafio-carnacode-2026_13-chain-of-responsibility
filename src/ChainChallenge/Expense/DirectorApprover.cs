namespace ChainChallenge.Expense;

public class DirectorApprover : ExpenseApprovalMiddleware
{
    protected override string Role => "Diretor";

    protected override bool CanApprove(ExpenseRequest request) => request.Amount <= 5000m;

    protected override bool Validate(ExpenseRequest request) =>
        ValidateReceipt(request)
        && CheckBudget(request.Department, request.Amount)
        && CheckPolicy(request)
        && CheckStrategicAlignment(request);

    private bool ValidateReceipt(ExpenseRequest request)
    {
        Console.WriteLine("  → Validando nota fiscal...");
        return true;
    }

    private bool CheckBudget(string department, decimal amount)
    {
        Console.WriteLine($"  → Verificando orçamento do departamento {department}...");
        return true;
    }

    private bool CheckPolicy(ExpenseRequest request)
    {
        Console.WriteLine("  → Verificando conformidade com política...");
        return true;
    }

    private bool CheckStrategicAlignment(ExpenseRequest request)
    {
        Console.WriteLine("  → Verificando alinhamento estratégico...");
        return true;
    }
}
