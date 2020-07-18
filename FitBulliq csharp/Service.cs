using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBulliq_csharp
{
    public class Service
    {
        private Repository repo = new Repository();

        public List<Meal> currentMeals = new List<Meal>(); //It is actual list of meals
        public List<Product> listProducts = new List<Product>(); //It is list of products, updated for example by setListProductsByText()
        public DateTime Date { get; set; }

        public Service()
        {

        }

        //Getting meals by date from repo and setting on currentMeals
        public void SetMealsByDate(DateTime date)
        {
            try
            {
                currentMeals = repo.GetMealsByDate(date);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //setting products (from DB) to currentMeals
        public void SetProductsToMeals()
        {
            try
            {
                //*At first, have to remove everything from listProducts*
                RemoveProductsFromCurrentMeals();

                //Next, for every meal have to set products to listProduct
                foreach (Meal meal in currentMeals)
                {
                    meal.listProduct = repo.GetProductsToMeal(meal);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Adding meal to DB and to currentMeals
        public void AddMeal(Meal meal)
        {
            try
            {
                meal.Id=repo.AddMeal(meal);
                currentMeals.Add(meal);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Removing meal from DB and currentMeals
        public void RemoveMeal(Meal meal)
        {
            try
            {
                repo.RemoveMeal(meal);
                for (int i = 0; i < currentMeals.Count; i++)
                {
                    if(meal.Equals(currentMeals[i]))
                    {
                        currentMeals.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            SetMealsByDate(Date);
            SetProductsToMeals();
        }

        //Setting to listProducts products where name is *text*
        public void SetListProductsByText(string text)
        {
            try
            {
                listProducts = repo.GetProductsByText(text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Adding product to DB
        public void AddProduct(Product product)
        {
            try
            {
                repo.AddProduct(product);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Removing product from DB 
        //Have to update currentMeals if there was this product
        public void RemoveProduct(Product product)
        {
            try
            {
                repo.RemoveProduct(product);
                //*Updating meals
                SetProductsToMeals();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Editing product in DB
        //Have to update currentMeals if there was this product
        public void EditProduct(Product product, Product productEdited)
        {
            try
            {
                repo.EditProduct(product, productEdited);
                //*Updating meals
                SetProductsToMeals();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Adding product to meal, product has grams
        public void AddMealProduct(Meal meal, Product product, int grams)
        {
            try
            {
                product.Grams = grams;
                repo.AddMealProduct(meal, product);
                
                //Check all currentMeals, when is the same
                //add product to listProducts
                foreach  (Meal m in currentMeals)
                {
                    if (m.Equals(meal))
                    {
                        m.listProduct.Add(product);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Removing product from meal (from DB and currentMeals)
        public void RemoveMealProduct(Meal meal, Product product)
        {
            try
            {
                repo.RemoveMealProduct(meal, product);

                //In currentMeals find a meal *1
                //if found, find in listProduct a product *2
                //if found, remove it and break *3
                foreach (Meal m in currentMeals)
                {
                    if(m.Equals(meal)) //*1
                    {
                        for (int i = 0; i < m.listProduct.Count; i++) //*2
                        {
                            if(m.listProduct[i].Equals(product)) //*3
                            {
                                m.listProduct.RemoveAt(i);
                                break;
                            }
                        }

                        break;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //
        public void EditMealProduct(Meal meal, Product productToEdit, int gramsToEdit)
        {
            try
            {
                repo.EditMealProduct(meal, productToEdit, gramsToEdit);

                //In currentMeals find a meal *1
                //if found, find in listProduct a product *2
                //if found, edit it and break *3
                foreach (Meal m in currentMeals)
                {
                    if (m.Equals(meal)) //*1
                    {
                        for (int i = 0; i < m.listProduct.Count; i++) //*2
                        {
                            if (m.listProduct[i].Equals(productToEdit)) //*3
                            {
                                m.listProduct[i].Grams=gramsToEdit;
                                break;
                            }
                        }

                        break;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METHODS
        private void RemoveProductsFromCurrentMeals()
        {
            for (int i = 0; i < currentMeals.Count(); i++)
            {
                //In every meal have to remove in list product
                //first product from list
                while (currentMeals[i].listProduct.Count() > 0)
                    currentMeals[i].listProduct.RemoveAt(0);
            }
        }


        //MACROS FOR DAY
        //Returns Kcal for day
        public int GetKcalDay()
        {
            int sum = 0;
            foreach (Meal meal in currentMeals)
            {
                sum = sum + meal.GetKcalMeal();
            }
            return sum;
        }

        //Returns Protein for day
        public double GetProteinDay()
        {
            double sum = 0;
            foreach (Meal meal in currentMeals)
            {
                sum = sum + meal.GetProteinMeal();
            }
            return sum;
        }

        //Returns Fats for day
        public double GetFatsDay()
        {
            double sum = 0;
            foreach (Meal meal in currentMeals)
            {
                sum = sum + meal.GetFatsMeal();
            }
            return sum;
        }

        //Returns Carbohydrates for day
        public double GetCarbohydratesDay()
        {
            double sum = 0;
            foreach (Meal meal in currentMeals)
            {
                sum = sum + meal.GetCarbohydratesMeal();
            }
            return sum;
        }

        public string ToStringMacrosDay()
        {
            return $"{GetKcalDay()} kcal | {GetProteinDay()} (g) | {GetFatsDay()} (g) | {GetCarbohydratesDay()} (g)";
        }

        public string ToStringMacrosMeal(Meal meal)
        {
            return $"{meal.GetKcalMeal()} kcal | {meal.GetProteinMeal()} (g) | {meal.GetFatsMeal()} (g) | {meal.GetCarbohydratesMeal()} (g)";
        }



    }
}
