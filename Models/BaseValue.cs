namespace Planner.App.Models;
public class BaseValue
{
    public BaseValue(string name) 
    {
        Name = name;
        IsActive = true;
        Transactions = [];
    }

    protected BaseValue(string name, bool isActive, Dictionary<DateTime, decimal> transactions)
    {
        Name = name;
        IsActive = isActive;
        Transactions = transactions;
    }

    public string Name { get; protected set; }
    public bool IsActive { get; protected set; }
    public Dictionary<DateTime, decimal> Transactions { get; protected set; }

    public void Deactivate() => IsActive = false;

    public void AddTransaction(DateTime dueDay, decimal amount)  => Transactions.Add(dueDay, amount);

    public void AddTransactions(Dictionary<DateTime, decimal> transactions)
    {
        foreach (var t in Transactions)
        {
            Transactions.Add(t.Key, t.Value);
        }
    }
}
