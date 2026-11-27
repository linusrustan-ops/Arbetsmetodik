
using System.Collections.Generic;
using System.Linq;

namespace Grupparbete_Bibliotek
{
    public class LoanRepository : ILoanRepository
    {
        private readonly Dictionary<string, List<loansByUserId>> loans = new();

        public void Add(string userId, loansByUserId loan)
        {
            if (!loans.ContainsKey(userId))
            {
                loans[userId] = new List<loansByUserId>();
            }

            loans[userId].Add(loan);
        }

        public List<loansByUserId> GetByUserId(string userId)
        {
            if (loans.TryGetValue(userId, out List<loansByUserId>? userLoans))
            {
                return userLoans;
            }

            return new List<loansByUserId>();
        }

        public List<loansByUserId> GetAll()
        {
            return loans.Values
                .SelectMany(userLoans => userLoans)
                .ToList();
        }
    }
}
