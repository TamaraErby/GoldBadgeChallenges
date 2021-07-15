using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RepositoryClaim
{
    public class ClaimRepository
    {
        public List<Claims> _claimRepo = new List<Claims>();
        public List<Claims> GetList()
        {
            return _claimRepo;
        }

        public void AddClaim(Claims content)
        {
            _claimRepo.Add(content);
        }

        public void RemoveClaim(Claims content)
        {
            _claimRepo.Remove(content);
        }

        public void IsValid(Claims claim)
        {
            if (claim.ClaimDate < claim.IncidentDate)
                claim.ClaimDate = claim.IncidentDate;

            TimeSpan difference = claim.ClaimDate - claim.IncidentDate;

            if (difference.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;
        }

        public void Remove()
        {
        }
    }
}
