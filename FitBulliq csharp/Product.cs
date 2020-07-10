using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitBulliq_csharp
{
    class Product
    {
        public uint Id{ get; set; }
        public string Name { get; set; }
        public uint Kcal { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public uint Grams { get; set; }


        //CTORS
        public Product()
        {

        }
        public Product(string name, uint kcal, double protein, double fats, double carbohydrates)
        {
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
        public Product(uint id, string name, uint kcal, double protein, double fats, double carbohydrates)
        {
            Id = id;
            Name = name;
            Kcal = kcal;
            Protein = protein;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
        public Product(uint id, string name, uint kcal, double protein, double fats, double carbohydrates, uint grams) : this(id, name, kcal, protein, fats, carbohydrates)
        {
            Grams = grams;
        }
        //////////
        
        //GETTERS BY GRAMS
        public uint GetKcalByGrams()
        {
            double temp = Kcal * (Grams * 0.01);
            return (uint)temp;
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

        //OVERRIDE
        public override string ToString()
        {
            return (Name + " | " + Grams + " (g) | " + Kcal + " (g) | " + Protein + " (g) | " + Fats + " (g) | " + Carbohydrates + " (g)");
        }
        public override bool Equals(object obj)
        {
            if (Name == ((Product)obj).Name && Grams == ((Product)obj).Grams)
                return true;
            else
                return false;
        }
        ///////////

    }
}
