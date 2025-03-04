using MoneyTransfer.Services.Interface;
using System.Linq.Expressions;

namespace MoneyTransfer.Services.Service
{
    public class TransactionDetails : Repository<MoneyTransfer.Models.TransactionDetails>,ITransactionDetails
    {
        private readonly Data_Access.AppContext appContext;
        public TransactionDetails(Data_Access.AppContext appContext) : base(appContext)
        {
            this.appContext = appContext;
        }


        public async Task<bool> Update(MoneyTransfer.Models.TransactionDetails transactionDetails)
        {
            try
            {
                appContext.TransactionDetails.Update(transactionDetails);
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
