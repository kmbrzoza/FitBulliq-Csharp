using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBulliq_csharp
{
    public class Product
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int Kcal { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public int Grams { get; set; }


        //CTORS
        public Product()
        {

        }
        public Product(string name, int kcal, double protein, double fats, double carbohydrates)
        {
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
        public Product(int id, string name, int kcal, double protein, double fats, double carbohydrates) : this(name, kcal, protein, fats, carbohydrates)
        {
            Id = id;
        }
        public Product(int id, string name, int kcal, double protein, double fats, double carbohydrates, int grams) : this(id, name, kcal, protein, fats, carbohydrates)
        {
            Grams = grams;
        }
        //////////
        
        //GETTERS BY GRAMS
        public int GetKcalByGrams()
        {
            double temp = Kcal * (Grams * 0.01);
            return (int)temp;
        }
        public double GetProteinByGrams()
        {
            return (Protein * (Grams * 0.01));
        }
        public double GetFatsByGrams()
        {
            return (Fats * (Grams * 0.01));
        }
        public double GetCarbohydratesByGrams()
        {
            return (Carbohydrates * (Grams * 0.01));
        }
        ///////////////



        public string ToStringWithoutGrams()
        {
            return ($"{Name} | {Kcal} (kcal) | {Protein} (g) | {Fats} (g) | {Carbohydrates} (g)");
        }

        //OVERRIDE
        public override string ToString()
        {
            return ($"{Name} | {Grams} (g) | {Kcal * (Grams * 0.01)} (kcal) | {Protein * (Grams * 0.01)} (g) | {Fats * (Grams * 0.01)} (g) | {Carbohydrates * (Grams * 0.01)} (g)");
        }
        public override bool Equals(object obj)
        {
            if (Name == ((Product)obj).Name && Grams == ((Product)obj).Grams && Id == ((Product)obj).Id)
                return true;
            else
                return false;
        }
        public override int GetHashCode() //just for no warning
        {
            return base.GetHashCode();
        }
        ///////////

    }
}
