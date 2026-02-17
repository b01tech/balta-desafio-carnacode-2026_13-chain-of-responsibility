namespace ChainChallenge.Expense;

public static class ExpenseApprovalChain
{
    public static IExpenseApprover CreateDefault()
    {
        var supervisor = new SupervisorApprover();
        var manager = new ManagerApprover();
        var director = new DirectorApprover();
        var ceo = new CeoApprover();
        supervisor.SetNext(manager).SetNext(director).SetNext(ceo);
        return supervisor;
    }
}
