using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Windows.Forms;
///For DB
//using System.Data.SqlClient; ///For DB - already exists

namespace FitBulliq_csharp
{
    class Repository
    {
        private string connectionString;
        private SqlConnection connection;

        public Repository()
        {
            //setting connectionString
            connectionString = ConfigurationManager.ConnectionStrings["FitBulliq_csharp.Properties.Settings.DatabaseConnectionString"].ConnectionString;
        }

        //These 2 function are using to open and close connection
        //Always using when want do smth with database
        private void ConnectionOpen()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        private void ConnectionClose()
        {
            connection.Close();
        }

        //ZMIENIĆ WYJĄTKI W METODACH

        #region Meals
        //MEALS

        //Returning list of Meals by date
        public List<Meal> GetMealsByDate(DateTime date)
        {
            ConnectionOpen();

            List<Meal> listMeals = new List<Meal>();

            string query = "SELECT Id, Name, Date FROM Meals WHERE Date=@Date";
            SqlCommand command = new SqlCommand(query, connection);
            string dateToString = $"{date.Day}.{date.Month}.{date.Year}";
            command.Parameters.AddWithValue("@Date", dateToString);

            SqlDataReader reader;
            Meal meal;

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    uint id = uint.Parse(reader.GetValue(0).ToString());
                    string name = reader.GetValue(1).ToString();
                    //3rd parametr is date, because is the same date 
                    //which we take from DB
                    meal = new Meal(id, name, date);
                    listMeals.Add(meal);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd odczytu posiłków z bazy danych! \nRepo - GetMealsByDate()", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
            return listMeals;
        }

        //Returning products of meal
        public List<Product> GetProductsToMeal(Meal meal)
        {
            ConnectionOpen();

            List<Product> listProduct = new List<Product>();

            //this command need for getting Id and Grams For one product in meal
            string queryForIdProduct = "SELECT mp.IdProduct, mp.Grams FROM MealsProducts mp INNER JOIN Products p on mp.idProduct = p.id INNER JOIN meals m on mp.idMeal = m.id WHERE m.id = @Id";
            SqlCommand commandForIdProduct = new SqlCommand(queryForIdProduct, connection);
            commandForIdProduct.Parameters.AddWithValue("@Id", meal.Id);

            //this command need for getting specs of Product, to get it, need Id from previous command
            string queryForProductSpecs = "SELECT Name, Kcal, Protein, Fats, Carbohydrates FROM Products WHERE Id=@Id";
            SqlCommand commandForProductSpecs = new SqlCommand(queryForProductSpecs, connection);

            SqlDataReader readerForIdProduct;
            SqlDataReader readerForProductSpecs;

            try
            {
                readerForIdProduct = commandForIdProduct.ExecuteReader();
                while (readerForIdProduct.Read())
                {
                    uint id = uint.Parse(readerForIdProduct.GetValue(0).ToString());
                    uint grams = uint.Parse(readerForIdProduct.GetValue(1).ToString());

                    commandForProductSpecs.Parameters.AddWithValue("@Id", id);
                    readerForProductSpecs = commandForProductSpecs.ExecuteReader();

                    if(readerForProductSpecs.Read())//Dont need loop becase its only one product per ID
                    {
                        //Getting specs to variables, id and grams got before
                        string name = readerForProductSpecs.GetValue(0).ToString();
                        uint kcal = uint.Parse(readerForProductSpecs.GetValue(1).ToString());
                        double protein = double.Parse(readerForProductSpecs.GetValue(3).ToString());
                        double fats = double.Parse(readerForProductSpecs.GetValue(4).ToString());
                        double carbohydrates = double.Parse(readerForProductSpecs.GetValue(5).ToString());
                        
                        listProduct.Add(new Product(id, name, kcal, protein, fats, carbohydrates, grams));
                    }
                    else
                    {
                        throw new System.Exception("Błąd w odczycie informacji o danym produkcie!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd odczytu produktów z bazy danych! \nRepo - GetProductsToMeal()", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
            return listProduct;
        }

        //Adding meal
        public void AddMeal(Meal meal)
        {
            ConnectionOpen();

            string date = $"{meal.Date.Year}-{meal.Date.Month}-{meal.Date.Day}";

            //INSERT INTO Meals (Name, Date) VALUES('Kolacja', '2020-04-06')
            string query = "INSERT INTO Meals (Name, Date) VALUES (@Name, @Date)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", meal.Name);
            command.Parameters.AddWithValue("@Date", date);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBład dodawania posiłku! \nRepo - AddMeal()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        //Removing meal
        public void RemoveMeal(Meal meal)
        {
            ConnectionOpen();

            //At first, have to remove from MealsProducts (because of FK)
            string queryDeleteMealsProducts = "DELETE FROM MealsProducts WHERE IdMeal = @IdMeal";
            SqlCommand commandDeleteMealsProducts = new SqlCommand(queryDeleteMealsProducts, connection);
            commandDeleteMealsProducts.Parameters.AddWithValue("@IdMeal", meal.Id);

            //Next, have to remove from Meals
            string queryDeleteMeals = "DELETE FROM Meals where Id = @Id";
            SqlCommand commandDeleteMeals = new SqlCommand(queryDeleteMeals, connection);
            commandDeleteMeals.Parameters.AddWithValue("@Id", meal.Id);

            try
            {
                commandDeleteMealsProducts.ExecuteNonQuery();//1
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania posiłku! \nRepo - RemoveMeal() - DB MealsProducts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                commandDeleteMeals.ExecuteNonQuery();//2
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania posiłku! \nRepo - RemoveMeal() - DB Meals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }
        #endregion

        #region Products
        //PRODUCTS

        //Adding product
        public void AddProduct(Product product)
        {
            ConnectionOpen();

            string query = "INSERT INTO Products (Name, Kcal, Protein, Fats, Carbohydrates) " +
                "VALUES(@NameProduct, @KcalProduct, @ProteinProduct, @FatsProduct, @CarbohydratesProduct)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NameProduct", product.Name);
            command.Parameters.AddWithValue("@KcalProduct", product.Kcal);
            command.Parameters.AddWithValue("@ProteinProduct", product.Protein);
            command.Parameters.AddWithValue("@FatsProduct", product.Fats);
            command.Parameters.AddWithValue("@CarbohydratesProduct", product.Carbohydrates);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd dodawania produktu! \nRepo - AddProduct()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        //Returning list of products by text
        public List<Product> GetProductsByText(string text)
        {
            ConnectionOpen();

            List<Product> listProducts = new List<Product>();

            string query = "SELECT * FROM Products WHERE NAME LIKE '%@NameProduct%'";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NameProduct", text);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd odczytu produktów po nazwie! \nRepo - GetProductsByText()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
            return listProducts;
        }

        //Removing product
        public void RemoveProduct(Product product)
        {
            ConnectionOpen();

            //At first, have to remove from MealsProducts, because of FK
            string queryDeleteFromMealsProducts = "DELETE FROM MealsProducts WHERE IdProduct=@IdProduct";
            SqlCommand commandDeleteFromMealsProducts = new SqlCommand(queryDeleteFromMealsProducts, connection);
            commandDeleteFromMealsProducts.Parameters.AddWithValue("@IdProduct", product.Id);

            //Next, have to remove from Products
            string queryDeleteFromProducts = "DELETE FROM Products WHERE Id=@IdProduct";
            SqlCommand commandDeleteFromProducts = new SqlCommand(queryDeleteFromProducts, connection);
            commandDeleteFromProducts.Parameters.AddWithValue("@IdProduct", product.Id);

            try
            {
                commandDeleteFromMealsProducts.ExecuteNonQuery(); //1
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania produktu! \nRepo - RemoveProduct() - DB MealsProducts", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                commandDeleteFromProducts.ExecuteNonQuery(); //2
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania produktu! \nRepo - RemoveProduct() - DB Products", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        //Editing product
        public void EditProduct(Product product, Product productEdited)
        {
            ConnectionOpen();

            string query = "UPDATE Products SET Name=@NameProductE, Kcal=@KcalProductE, Protein=@ProteinProductE, Fats=@FatsProductE," +
                "Carbohydrates=@CarbohydratesProductE WHERE Id=@IdProduct";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NameProductE", productEdited.Name);
            command.Parameters.AddWithValue("@KcalProducEt", productEdited.Kcal);
            command.Parameters.AddWithValue("@ProteinProductE", productEdited.Protein);
            command.Parameters.AddWithValue("@FatsProductE", productEdited.Fats);
            command.Parameters.AddWithValue("@CarbohydratesProductE", productEdited.Carbohydrates);

            command.Parameters.AddWithValue("@IdProduct", product.Id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd edytowania produktu! \nRepo - EditProduct()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            ConnectionClose();
        }
        ////////////
        #endregion

        #region MealsProducts
        //MEALSPRODUCTS

        //Adding product to meal
        public void AddMealProduct(Meal meal, Product product, uint grams)
        {
            ConnectionOpen();

            string query = "INSERT INTO MealsProducts (IdMeal, IdProduct, Grams) VALUES (@IdMeal, @IdProduct, @Grams)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdMeal", meal.Id);
            command.Parameters.AddWithValue("@IdProduct", product.Id);
            command.Parameters.AddWithValue("@Grams", grams);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd dodawania produktu do posiłku! \nRepo - AddMealProduct()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        //Removing product from meal
        public void RemoveMealProduct(Meal meal, Product productToRemove)
        {
            ConnectionOpen();

            string query = "DELETE FROM MealsProducts WHERE IdMeal=@IdMeal AND IdProduct=@IdProduct AND Grams=@Grams";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdMeal", meal.Id);
            command.Parameters.AddWithValue("@IdProduct", productToRemove.Id);
            command.Parameters.AddWithValue("@Grams", productToRemove.Grams);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania produktu z posiłku! \nRepo - RemoveMealProduct()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        //Editing product in meal
        public void EditMealProduct(Meal meal, Product productToEdit, uint gramsToEdit)
        {
            ConnectionOpen();

            string query = "UPDATE MealsProducts SET Grams=@GramsToEdit WHERE IdMeal=@IdMeal AND IdProduct=@IdProduct AND Grams=@Grams";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdMeal", meal.Id);
            command.Parameters.AddWithValue("@IdProduct", productToEdit.Id);
            command.Parameters.AddWithValue("@Grams", productToEdit.Grams);

            command.Parameters.AddWithValue("@GramsToEdit", gramsToEdit);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message} \nBłąd usuwania produktu z posiłku! \nRepo - RemoveMealProduct()", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ConnectionClose();
        }

        ///////////
        #endregion


        //////////
    }
}
