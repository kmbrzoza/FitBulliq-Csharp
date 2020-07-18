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
    public partial class AddProductForm : Form
    {
        private Service service;
        private Meal selectedMeal; //its selected meal from Form1
        public AddProductForm()
        {
            InitializeComponent();
        }

        public AddProductForm(Service service, Meal selectedMeal)
        {
            InitializeComponent();

            this.service = service;
            this.selectedMeal = selectedMeal;
        }

        private void UpdateListViewOfProducts()
        {
            listBoxListProducts.Items.Clear(); //at first, have to clear a listBox

            string text = textBox1.Text;
            service.SetListProductsByText(text);

            for (int i = 0; i < service.listProducts.Count; i++)
            {
                listBoxListProducts.Items.Add(service.listProducts[i].ToStringWithoutGrams());
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        //SEARCH BOX - when user write name of product then update listView
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateListViewOfProducts();
        }

        //Adding product to selected meal
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedProduct = listBoxListProducts.SelectedIndex;
            int grams = (int)numericUpDownGrams.Value;
            try
            {
                if(indexOfSelectedProduct<0)
                {
                    throw new Exception("Musisz wybrać produkt!");
                }

                Product selectedProduct = service.listProducts[indexOfSelectedProduct];
                service.AddMealProduct(selectedMeal, selectedProduct, grams);

                this.Close(); //closing window
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //SETTING GRAMS of Product
        private void numericUpDownGrams_ValueChanged(object sender, EventArgs e)
        {
            int indexOfSelectedProduct = listBoxListProducts.SelectedIndex;
            uint grams = (uint)numericUpDownGrams.Value;

            try
            {
                if (indexOfSelectedProduct<0)
                {
                    throw new Exception("Musisz wybrać produkt!");
                }
                Product selectedProduct = service.listProducts[indexOfSelectedProduct];

                labelKcal.Text = $"{(selectedProduct.Kcal) * (grams * 0.01)}";
                labelProtein.Text = $"{(selectedProduct.Protein) * (grams * 0.01)}";
                labelFats.Text = $"{(selectedProduct.Fats) * (grams * 0.01)}";
                labelCarbohydrates.Text = $"{(selectedProduct.Carbohydrates) * (grams * 0.01)}";

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //ADD OWN PRODUCT
        private void buttonAddOwnProduct_Click(object sender, EventArgs e)
        {
            AddOwnProductForm addOwnProductForm = new AddOwnProductForm(service);
            addOwnProductForm.ShowDialog();

            UpdateListViewOfProducts();
        }

        //REMOVE PRODUCT
        private void buttonRemoveProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedProduct = listBoxListProducts.SelectedIndex;
            try
            {
                if(indexOfSelectedProduct<0)
                {
                    throw new Exception("Musisz wybrać produkt!");
                }

                Product productToRemove = service.listProducts[indexOfSelectedProduct];
                service.RemoveProduct(productToRemove);

                UpdateListViewOfProducts();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //EDIT PRODUCT
        private void buttonEditProduct_Click(object sender, EventArgs e)
        {
            int indexOfSelectedProduct = listBoxListProducts.SelectedIndex;
            try
            {
                if(indexOfSelectedProduct<0)
                {
                    throw new Exception("Musisz wybrać produkt!");
                }

                Product productSelected = service.listProducts[indexOfSelectedProduct];
                EditProductForm editProductForm = new EditProductForm(service, productSelected);
                editProductForm.ShowDialog();

                UpdateListViewOfProducts();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
