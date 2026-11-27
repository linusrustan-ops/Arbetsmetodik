using System;
namespace Grupparbete_Bibliotek
{
    public class loansByUserId
    {
        public required Book Book { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; } = "";

    }
}