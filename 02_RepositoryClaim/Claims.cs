using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RepositoryClaim
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home, 
        Theft
    }
    public class Claims
    {
        public int ClaimID { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime ClaimDate { get; set; }
        public bool IsValid { get; set; }

        public Claims(int claimID, TypeOfClaim claimType, string description, decimal amount, DateTime incidentDate, DateTime claimDate, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            Amount = amount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            IsValid = isValid;
        }

        public Claims()
        {
        }
    }
}
