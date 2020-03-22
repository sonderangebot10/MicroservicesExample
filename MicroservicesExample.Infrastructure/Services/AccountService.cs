using MicroservicesExample.Infrastructure.Domain;
using System.Threading.Tasks;

namespace MicroservicesExample.Infrastructure
{
    public class AccountService
    {
        private Balance balance;

        public AccountService()
        {
            balance = new Balance();
        }

        public async Task<bool> SetBalanceAsync(double value)
        {
            balance.amount = value;
            return true;
        }

        public async Task<double> GetBalanceAsync()
        {
            return balance.amount;
        }
    }
}
