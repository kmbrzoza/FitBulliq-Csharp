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
    public partial class AddOwnProductForm : Form
    {
        private Service service;
        public AddOwnProductForm()
        {
            InitializeComponent();
        }

        public AddOwnProductForm(Service service)
        {
            InitializeComponent();

            this.service = service;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddOwnProductForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameProduct = textBoxNameProduct.Text;

            try
            {
                if(nameProduct=="")
                {
                    throw new Exception("Musisz podać nazwę produktu!");
                }

                Product productToAdd = new Product(nameProduct, (int)numericUpDownKcal.Value, (double)numericUpDownProtein.Value,
                                                    (double)numericUpDownFats.Value, (double)numericUpDownCarbohydrates.Value);
                service.AddProduct(productToAdd);

                this.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
