
using System.Collections.Generic;
using System.Linq;

namespace Grupparbete_Bibliotek
{
    public class LoanRepository : ILoanRepository
    {
        private readonly Dictionary<string, List<Loan>> loans = new();

        public void Add(string userId, Loan loan)
        {
            if (!loans.ContainsKey(userId))
            {
                loans[userId] = new List<Loan>();
            }

            loans[userId].Add(loan);
        }

        public List<Loan> GetByUserId(string userId)
        {
            if (loans.TryGetValue(userId, out List<Loan>? userLoans))
            {
                return userLoans;
            }

            return new List<Loan>();
        }

        public List<Loan> GetAll()
        {
            return loans.Values
                .SelectMany(userLoans => userLoans)
                .ToList();
        }
    }
}
