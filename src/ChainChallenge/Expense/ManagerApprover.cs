namespace ChainChallenge.Expense;

public class ManagerApprover : ExpenseApprovalMiddleware
{
    protected override string Role => "Gerente";

    protected override bool CanApprove(ExpenseRequest request) => request.Amount <= 500m;

    protected override bool Validate(ExpenseRequest request) =>
        ValidateReceipt(request)
        && CheckBudget(request.Department, request.Amount)
        && CheckPolicy(request);

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
}
