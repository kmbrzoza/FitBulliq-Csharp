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
    public partial class AddMealForm : Form
    {
        private Service service;
        public AddMealForm()
        {
            InitializeComponent();
        }
        public AddMealForm(Service service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void buttonAddMeal_Click(object sender, EventArgs e)
        {
            string nameMeal;

            try
            {
                if(textBoxNameMeal.Text=="")
                {
                    throw new Exception("Musisz podać nazwę produktu!");
                }

                nameMeal = textBoxNameMeal.Text;
                Meal meal = new Meal(nameMeal, service.Date);
                service.AddMeal(meal);
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Brak nazwy!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddMealForm_Load(object sender, EventArgs e)
        {

        }
    }
}
