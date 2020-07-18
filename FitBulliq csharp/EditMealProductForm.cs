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
    public partial class EditMealProductForm : Form
    {
        Service service;
        Meal meal;
        Product productToEdit;
        public EditMealProductForm()
        {
            InitializeComponent();
        }

        public EditMealProductForm(Service service, Meal meal, Product productToEdit)
        {
            InitializeComponent();

            this.service = service;
            this.meal = meal;
            this.productToEdit = productToEdit;
        }

        private void EditMealProductForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int gramsToEdit = (int)numericUpDownGrams.Value;

            service.EditMealProduct(meal, productToEdit, gramsToEdit);
            this.Close();
        }
    }
}
