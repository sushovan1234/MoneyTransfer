using MoneyTransfer.Models;
using MoneyTransfer.Services.Interface;

namespace MoneyTransfer.Services.Service
{
    public class BankDetails : Repository<MoneyTransfer.Models.BankDetails>, IBankDetails
    {
        private readonly Data_Access.AppContext appContext;
        public BankDetails(Data_Access.AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }
        public async Task<bool> Update(MoneyTransfer.Models.BankDetails bankDetails)
        {
            try
            {
                appContext.BankDetails.Update(bankDetails);
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
