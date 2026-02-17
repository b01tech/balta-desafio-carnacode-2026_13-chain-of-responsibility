using ChainChallenge.Expense;

Console.WriteLine("=== Sistema de Aprovação de Despesas (Chain of Responsibility) ===");

var chain = ExpenseApprovalChain.CreateDefault();

var expenses = new[]
{
    new ExpenseRequest("João Silva", 50.00m, "Material de escritório", "TI"),
    new ExpenseRequest("Maria Santos", 350.00m, "Curso de capacitação", "RH"),
    new ExpenseRequest("Pedro Oliveira", 2500.00m, "Notebook", "TI"),
    new ExpenseRequest("Ana Costa", 15000.00m, "Servidor para datacenter", "TI")
};

foreach (var e in expenses)
{
    Console.WriteLine("\n=== Processando Despesa ===");
    Console.WriteLine($"Funcionário: {e.EmployeeName}");
    Console.WriteLine($"Valor: R$ {e.Amount:N2}");
    Console.WriteLine($"Propósito: {e.Purpose}");
    Console.WriteLine($"Departamento: {e.Department}\n");
    chain.Handle(e);
}
