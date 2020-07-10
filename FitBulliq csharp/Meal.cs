using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBulliq_csharp
{
    class Meal
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public List<Product> listProduct = new List<Product>();

        //GETTERS BY MEAL (from listProduct)
        public uint GetKcalMeal()
        {
            uint sum = 0;
            for (int i = 0; i < listProduct.Count; i++)
            {
                sum = sum + listProduct[i].GetKcalByGrams();
            }
            return sum;
        }
        public double GetProteinMeal()
        {
            double sum = 0;
            for (int i = 0; i < listProduct.Count; i++)
            {
                sum = sum + listProduct[i].GetProteinByGrams();
            }
            return sum;
        }
        public double GetFatsMeal()
        {
            double sum = 0;
            for (int i = 0; i < listProduct.Count; i++)
            {
                sum = sum + listProduct[i].GetFatsByGrams();
            }
            return sum;
        }
        public double GetCarbohydratesMeal()
        {
            double sum = 0;
            for (int i = 0; i < listProduct.Count; i++)
            {
                sum = sum + listProduct[i].GetCarbohydratesByGrams();
            }
            return sum;
        }
        //////////
        
    }
}
