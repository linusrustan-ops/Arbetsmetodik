using System.Collections.Generic;

namespace Grupparbete_Bibliotek
{
    public interface ILoanRepository
    {
        void Add(string userId, Loan loan);

        List<Loan> GetByUserId(string userId);
        List<Loan> GetAll();
    }
}