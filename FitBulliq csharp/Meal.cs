using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBulliq_csharp
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public List<Product> listProduct = new List<Product>();

        //CTORS
        public Meal()
        {

        }
        public Meal(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }
        public Meal(int id, string name, DateTime date)
        {
            this.Id = id;
            this.Name = name;
            this.Date = date;
        }

        //GETTERS BY MEAL (from listProduct)
        public int GetKcalMeal()
        {
            int sum = 0;
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


        //OVERRIDE
        public override bool Equals(object obj)
        {
            if (Name == ((Meal)obj).Name && Id == ((Meal)obj).Id)
                return true;
            else
                return false;
        }
    }
}
