namespace FitBulliq_csharp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMacroMeal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMacroDay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRemoveMeal = new System.Windows.Forms.Button();
            this.buttonAddMeal = new System.Windows.Forms.Button();
            this.comboBoxMeals = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEditProduct = new System.Windows.Forms.Button();
            this.buttonRemoveProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.panelMeals = new System.Windows.Forms.Panel();
            this.listBoxMealProduct = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMeals.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelMacroMeal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelMacroDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonRemoveMeal);
            this.panel1.Controls.Add(this.buttonAddMeal);
            this.panel1.Controls.Add(this.comboBoxMeals);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 168);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kcal | Białka | Tłuszcze | Węglowodany";
            // 
            // labelMacroMeal
            // 
            this.labelMacroMeal.AutoSize = true;
            this.labelMacroMeal.Location = new System.Drawing.Point(244, 108);
            this.labelMacroMeal.Name = "labelMacroMeal";
            this.labelMacroMeal.Size = new System.Drawing.Size(16, 18);
            this.labelMacroMeal.TabIndex = 7;
            this.labelMacroMeal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Posiłek";
            // 
            // labelMacroDay
            // 
            this.labelMacroDay.AutoSize = true;
            this.labelMacroDay.Location = new System.Drawing.Point(244, 62);
            this.labelMacroDay.Name = "labelMacroDay";
            this.labelMacroDay.Size = new System.Drawing.Size(16, 18);
            this.labelMacroDay.TabIndex = 5;
            this.labelMacroDay.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dzień:";
            // 
            // buttonRemoveMeal
            // 
            this.buttonRemoveMeal.Location = new System.Drawing.Point(13, 125);
            this.buttonRemoveMeal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveMeal.Name = "buttonRemoveMeal";
            this.buttonRemoveMeal.Size = new System.Drawing.Size(141, 38);
            this.buttonRemoveMeal.TabIndex = 3;
            this.buttonRemoveMeal.Text = "Usuń posiłek";
            this.buttonRemoveMeal.UseVisualStyleBackColor = true;
            this.buttonRemoveMeal.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAddMeal
            // 
            this.buttonAddMeal.Location = new System.Drawing.Point(13, 79);
            this.buttonAddMeal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddMeal.Name = "buttonAddMeal";
            this.buttonAddMeal.Size = new System.Drawing.Size(141, 38);
            this.buttonAddMeal.TabIndex = 2;
            this.buttonAddMeal.Text = "Dodaj posiłek";
            this.buttonAddMeal.UseVisualStyleBackColor = true;
            this.buttonAddMeal.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxMeals
            // 
            this.comboBoxMeals.FormattingEnabled = true;
            this.comboBoxMeals.Location = new System.Drawing.Point(13, 45);
            this.comboBoxMeals.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxMeals.Name = "comboBoxMeals";
            this.comboBoxMeals.Size = new System.Drawing.Size(173, 26);
            this.comboBoxMeals.TabIndex = 1;
            this.comboBoxMeals.SelectedIndexChanged += new System.EventHandler(this.comboBoxMeals_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(13, 13);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(286, 24);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonEditProduct);
            this.panel2.Controls.Add(this.buttonRemoveProduct);
            this.panel2.Controls.Add(this.buttonAddProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 168);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 76);
            this.panel2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(524, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nazwa produktu | Ilość (g) | Kcal | Białko (g) | Tłuszcze (g) | Węglowodany (g)";
            // 
            // buttonEditProduct
            // 
            this.buttonEditProduct.Location = new System.Drawing.Point(297, 8);
            this.buttonEditProduct.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEditProduct.Name = "buttonEditProduct";
            this.buttonEditProduct.Size = new System.Drawing.Size(134, 37);
            this.buttonEditProduct.TabIndex = 11;
            this.buttonEditProduct.Text = "Edytuj produkt";
            this.buttonEditProduct.UseVisualStyleBackColor = true;
            this.buttonEditProduct.Click += new System.EventHandler(this.buttonEditProduct_Click);
            // 
            // buttonRemoveProduct
            // 
            this.buttonRemoveProduct.Location = new System.Drawing.Point(155, 8);
            this.buttonRemoveProduct.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveProduct.Name = "buttonRemoveProduct";
            this.buttonRemoveProduct.Size = new System.Drawing.Size(134, 37);
            this.buttonRemoveProduct.TabIndex = 10;
            this.buttonRemoveProduct.Text = "Usuń produkt";
            this.buttonRemoveProduct.UseVisualStyleBackColor = true;
            this.buttonRemoveProduct.Click += new System.EventHandler(this.buttonRemoveProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(13, 8);
            this.buttonAddProduct.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(134, 37);
            this.buttonAddProduct.TabIndex = 9;
            this.buttonAddProduct.Text = "Dodaj produkt";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // panelMeals
            // 
            this.panelMeals.AutoScroll = true;
            this.panelMeals.Controls.Add(this.listBoxMealProduct);
            this.panelMeals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMeals.Location = new System.Drawing.Point(0, 244);
            this.panelMeals.Margin = new System.Windows.Forms.Padding(4);
            this.panelMeals.Name = "panelMeals";
            this.panelMeals.Size = new System.Drawing.Size(482, 309);
            this.panelMeals.TabIndex = 2;
            // 
            // listBoxMealProduct
            // 
            this.listBoxMealProduct.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxMealProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMealProduct.FormattingEnabled = true;
            this.listBoxMealProduct.ItemHeight = 18;
            this.listBoxMealProduct.Location = new System.Drawing.Point(0, 0);
            this.listBoxMealProduct.Name = "listBoxMealProduct";
            this.listBoxMealProduct.Size = new System.Drawing.Size(482, 309);
            this.listBoxMealProduct.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 553);
            this.Controls.Add(this.panelMeals);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "Form1";
            this.Text = "FitBulliq";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelMeals.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonRemoveMeal;
        private System.Windows.Forms.Button buttonAddMeal;
        private System.Windows.Forms.ComboBox comboBoxMeals;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMeals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMacroMeal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMacroDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEditProduct;
        private System.Windows.Forms.Button buttonRemoveProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.ListBox listBoxMealProduct;
    }
}

