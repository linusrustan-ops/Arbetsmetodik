using System.Collections.Generic;

namespace Grupparbete_Bibliotek
{
    public interface ILoanRepository
    {
        void Add(string userId, loansByUserId loan);

        List<loansByUserId> GetByUserId(string userId);
        List<loansByUserId> GetAll();
    }
}