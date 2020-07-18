namespace FitBulliq_csharp
{
    partial class AddMealForm
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
            this.buttonAddMeal = new System.Windows.Forms.Button();
            this.textBoxNameMeal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddMeal);
            this.panel1.Controls.Add(this.textBoxNameMeal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 303);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddMeal
            // 
            this.buttonAddMeal.Location = new System.Drawing.Point(174, 171);
            this.buttonAddMeal.Name = "buttonAddMeal";
            this.buttonAddMeal.Size = new System.Drawing.Size(116, 37);
            this.buttonAddMeal.TabIndex = 3;
            this.buttonAddMeal.Text = "Dodaj posiłek";
            this.buttonAddMeal.UseVisualStyleBackColor = true;
            this.buttonAddMeal.Click += new System.EventHandler(this.buttonAddMeal_Click);
            // 
            // textBoxNameMeal
            // 
            this.textBoxNameMeal.Location = new System.Drawing.Point(95, 122);
            this.textBoxNameMeal.Name = "textBoxNameMeal";
            this.textBoxNameMeal.Size = new System.Drawing.Size(268, 24);
            this.textBoxNameMeal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj nazwę posiłku:";
            // 
            // AddMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 303);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximumSize = new System.Drawing.Size(500, 350);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "AddMealForm";
            this.Text = "FitBulliq - Dodawanie posiłku";
            this.Load += new System.EventHandler(this.AddMealForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAddMeal;
        private System.Windows.Forms.TextBox textBoxNameMeal;
        private System.Windows.Forms.Label label1;
    }
}