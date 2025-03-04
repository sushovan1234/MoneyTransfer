using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;

namespace MoneyTransfer.Services.Service
{
    public class BankAccount : Repository<MoneyTransfer.Models.BankAccount>, IBankAccount
    {
        private readonly Data_Access.AppContext appContext;
        public BankAccount(Data_Access.AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }

        public async Task<bool> Update(MoneyTransfer.Models.BankAccount bankAccount)
        {
            try
            {
                appContext.BankAccounts.Update(bankAccount);
                await appContext.SaveChangesAsync();
                return false;
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
                return false;
            }
        }

    }
}
