using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitBulliq_csharp
{
    public partial class Form1 : Form
    {
        Service service = new Service();

        public Form1()
        {
            InitializeComponent();

            //Setting meals to comboBoxMeals
            service.Date = dateTimePicker.Value;

            service.SetMealsByDate(service.Date);
            service.SetProductsToMeals();

            UpdateComboBoxMeals();
            UpdateListBoxMealProducts();
            UpdateMacros();
        }

        //UPDATE Meals in ComboBox
        public void UpdateComboBoxMeals()
        {
            comboBoxMeals.Items.Clear();

            foreach (Meal meal in service.currentMeals)
            {
                comboBoxMeals.Items.Add(meal.Name);
            }
        }

        //UPDATE Products in ListBox
        public void UpdateListBoxMealProducts()
        {
            listBoxMealProduct.Items.Clear();

            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex; //starting from 0

            try
            {
                if (indexOfSelectedMeal < 0)
                {
                    //NOTHING
                }
                else
                {
                    foreach (Product product in service.currentMeals[indexOfSelectedMeal].listProduct)
                    {
                        listBoxMealProduct.Items.Add(product.ToString());
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //UPDATE Macros in labels
        public void UpdateMacros()
        {
            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex;

            try
            {
                labelMacroDay.Text = service.ToStringMacrosDay();
                if (indexOfSelectedMeal < 0)
                {
                    labelMacroMeal.Text = $"0 kcal | 0 (g) | 0 (g) | 0 (g)";
                }
                else
                {
                    labelMacroMeal.Text = service.ToStringMacrosMeal(service.currentMeals[indexOfSelectedMeal]);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //REMOVE Meal
        private void button2_Click(object sender, EventArgs e)
        {
            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex; //starting from 0
            try
            {
                if(indexOfSelectedMeal<0)
                {
                    throw new Exception("Musisz wybrać posiłek!");
                }

                service.RemoveMeal(service.currentMeals[indexOfSelectedMeal]);

                comboBoxMeals.Text = "";

                UpdateComboBoxMeals();
                UpdateListBoxMealProducts();
                UpdateMacros();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ADD Meal
        private void button1_Click(object sender, EventArgs e)
        {
            service.Date = dateTimePicker.Value;
            AddMealForm addMealForm = new AddMealForm(service);
            
            addMealForm.ShowDialog();

            UpdateComboBoxMeals();
            UpdateListBoxMealProducts();
            UpdateMacros();
        }

        //SET DATE
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            service.Date = dateTimePicker.Value;

            service.SetMealsByDate(service.Date);
            service.SetProductsToMeals();

            UpdateComboBoxMeals();
            UpdateListBoxMealProducts();
            UpdateMacros();

            comboBoxMeals.Text = "";
        }

        //ADD PRODUCT to Meal
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex;
            try
            {
                if (indexOfSelectedMeal<0)
                {
                    throw new Exception("Musisz najpierw wybrać posiłek!");
                }
                AddProductForm addProductForm = new AddProductForm(service, service.currentMeals[indexOfSelectedMeal]);
                addProductForm.ShowDialog();

                UpdateListBoxMealProducts();
                UpdateMacros();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //COMBOBOX Selected Meal
        private void comboBoxMeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBoxMealProducts();
            UpdateMacros();
        }

        //REMOVE Product from Meal
        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex;
            int indexOfSelectedProduct = listBoxMealProduct.SelectedIndex;

            try
            {
                if(indexOfSelectedMeal<0)
                {
                    throw new Exception("Musisz wybrać posiłek aby usunąć produkt!");
                }
                if(indexOfSelectedProduct<0)
                {
                    throw new Exception("Musisz wybrać produkt aby go usunąć!");
                }

                Meal mealSelected = service.currentMeals[indexOfSelectedMeal];
                Product productSelected = service.currentMeals[indexOfSelectedMeal].listProduct[indexOfSelectedProduct];

                service.RemoveMealProduct(mealSelected, productSelected);

                UpdateListBoxMealProducts();
                UpdateMacros();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //EDIT Product in meal
        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedMeal = comboBoxMeals.SelectedIndex;
            int indexOfSelectedProduct = listBoxMealProduct.SelectedIndex;

            try
            {
                if (indexOfSelectedMeal < 0)
                {
                    throw new Exception("Musisz wybrać posiłek aby edytować produkt!");
                }
                if (indexOfSelectedProduct < 0)
                {
                    throw new Exception("Musisz wybrać produkt aby go edytować!");
                }

                Meal meal = service.currentMeals[indexOfSelectedMeal];
                Product productToEdit = service.currentMeals[indexOfSelectedMeal].listProduct[indexOfSelectedProduct];

                EditMealProductForm editMealProductForm = new EditMealProductForm(service, meal, productToEdit);
                editMealProductForm.ShowDialog();

                UpdateListBoxMealProducts();
                UpdateMacros();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
