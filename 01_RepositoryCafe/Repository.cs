using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_RepositoryCafe
{
    public class CafeRepository
    {
        public List<Menu> _cafeRepo = new List<Menu>();
        public void AddItems(Menu order)
        {
            _cafeRepo.Add(order);
        }

        public Menu FindOrderByID(int orderID)
        {
            foreach(Menu Object in _cafeRepo)
            {
                if(Object.MealNumber == orderID)
                {
                    return Object;
                }
            }
            return null;
        }

        public bool RemoveItems(Menu order)
        {
            int initialCount = _cafeRepo.Count;
            _cafeRepo.Remove(order);

            if(initialCount > _cafeRepo.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> ListOrders()
        {
            return _cafeRepo;
        }
    }
}
