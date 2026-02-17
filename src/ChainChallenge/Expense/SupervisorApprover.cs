namespace ChainChallenge.Expense;

public class SupervisorApprover : ExpenseApprovalMiddleware
{
    protected override string Role => "Supervisor";

    protected override bool CanApprove(ExpenseRequest request) => request.Amount <= 100m;

    protected override bool Validate(ExpenseRequest request) =>
        ValidateReceipt(request) && CheckBudget(request.Department, request.Amount);

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
}
