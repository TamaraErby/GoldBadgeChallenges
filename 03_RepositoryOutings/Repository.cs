using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RepositoryOutings
{
    public class OutingRepository
    {
        private List<Outing> _outingRepo = new List<Outing>();

        public List<Outing> GetList()
        {
            return _outingRepo;
        }

        public void AddOuting(Outing outing)
        {
            _outingRepo.Add(outing);
        }

        public double TotalCost()
        {
            double totalCost = 0.0d;
            foreach (Outing item in _outingRepo)
            {
                totalCost += item.TotalCost;
            }
            return totalCost;
        }

        public double CostByType(TypeOfOuting outingType)
        {
            List<Outing> _outingRepo = OutingByType(outingType);
            double totalCost = 0.0d;
            foreach (Outing outing in _outingRepo)
            {
                totalCost += outing.TotalCost;
            }
            return totalCost;
        }

        private List<Outing> OutingByType(TypeOfOuting outingType)
        {
            List<Outing> outingList = new List<Outing>();
            foreach (Outing item in _outingRepo)
            {
                if (item.OutingType == outingType)
                {
                    outingList.Add(item);
                }
            }
                return (outingList);
        }

        public void SeedOuting()
        {
            Outing Golf = new Outing(TypeOfOuting.Golf, 15, new DateTime(2019, 04, 25), 20d, 300d);
            _outingRepo.Add(Golf);

        }

    }
}
