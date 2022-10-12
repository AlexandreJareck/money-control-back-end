using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Interfaces.Repository;
using MoneyControl.Business.Models;

namespace MoneyControl.Business.Services;

public class TransactionService : BaseService, ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(INotifier notifier,
                              ITransactionRepository transactionRepository) : base(notifier)
    {
        _transactionRepository = transactionRepository; 
    }

    public async Task<Transaction?> Add(Transaction transaction)
    {
        if (!ExecuteValidation(new TransactionValidation(), transaction))
            return null;

        await _transactionRepository.Add(transaction);

        return transaction;
    }    

    public async Task Remove(Guid id)
    {
        await _transactionRepository.Remove(id);
    }

    public async Task<Transaction?> Update(Transaction transaction)
    {
        if (!ExecuteValidation(new TransactionValidation(), transaction))
            return null;

        await _transactionRepository.Update(transaction);

        return transaction;

    }
    public void Dispose()
    {
        _transactionRepository?.Dispose();
    }
}
