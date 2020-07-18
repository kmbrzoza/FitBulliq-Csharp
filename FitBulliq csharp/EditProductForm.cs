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
    public partial class EditProductForm : Form
    {
        Service service;
        Product productSelected;
        public EditProductForm()
        {
            InitializeComponent();
        }

        public EditProductForm(Service service, Product productSelected)
        {
            InitializeComponent();

            this.service = service;
            this.productSelected = productSelected;

            textBoxProductName.Text = productSelected.Name;
            numericUpDownKcal.Value = productSelected.Kcal;
            numericUpDownProtein.Value = (decimal)productSelected.Protein;
            numericUpDownFats.Value = (decimal)productSelected.Fats;
            numericUpDownCarbohydrates.Value = (decimal)productSelected.Carbohydrates;
        }

        private void EditProductForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;

            try
            {
                if(productName=="")
                {
                    throw new Exception("Musisz podać nazwę produktu!");
                }

                Product productEdited = new Product(productName, (int)numericUpDownKcal.Value,
                                        (double)numericUpDownProtein.Value, (double)numericUpDownFats.Value,
                                        (double)numericUpDownCarbohydrates.Value);
                
                service.EditProduct(productSelected, productEdited);
                this.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
