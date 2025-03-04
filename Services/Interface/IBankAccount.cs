using MoneyTransfer.Models;

namespace MoneyTransfer.Services.Interface
{
    public interface IBankAccount:IRepository<BankAccount>
    {
        Task<bool> Update(BankAccount bankaccount);
    }
}
