using MoneyControl.Business.Interfaces;
using MoneyControl.Business.Models;
using MoneyControl.Data.Context;

namespace MoneyControl.Data.Repository;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(MoneyControlDbContext context) : base(context)
    {

    }
}
