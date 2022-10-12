using MoneyControl.Business.Models;

namespace MoneyControl.Business.Interfaces;

public interface ITransactionService
{
    Task Add(Transaction transaction);
    Task Update(Transaction transaction);
    Task Remove(Guid id);
}
