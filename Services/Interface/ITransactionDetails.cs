using MoneyTransfer.Models;

namespace MoneyTransfer.Services.Interface
{
    public interface ITransactionDetails:IRepository<TransactionDetails>
    {
        Task<bool> Update(TransactionDetails transactionDetails);
    }
}
