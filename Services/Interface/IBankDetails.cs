using MoneyTransfer.Models;

namespace MoneyTransfer.Services.Interface
{
    public interface IBankDetails:IRepository<BankDetails>
    {
        Task<bool> Update(BankDetails bankdetails);
    }
}
