using MoneyControl.Business.Models;

namespace MoneyControl.Business.Interfaces;

public interface ITransactionService : IDisposable
{
    Task<Transaction?> Add(Transaction transaction);
    Task<Transaction?> Update(Transaction transaction);
    Task Remove(Guid id);
}
