namespace SportProject
{
    partial class FormMenu
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
            panelTop = new Panel();
            btnBack = new Button();
            lblUserName = new Label();
            btnLogut = new Button();
            panel1 = new Panel();
            btnProducts = new Button();
            btnOrders = new Button();
            panelTop.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnBack);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogut);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 0, 10, 10);
            panelTop.Size = new Size(536, 40);
            panelTop.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(67, 97, 238);
            btnBack.Dock = DockStyle.Left;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(10, 0);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 30);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click_1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(331, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 6;
            lblUserName.Text = "label1";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogut
            // 
            btnLogut.BackColor = Color.FromArgb(67, 97, 238);
            btnLogut.Dock = DockStyle.Right;
            btnLogut.FlatStyle = FlatStyle.Flat;
            btnLogut.ForeColor = Color.White;
            btnLogut.Location = new Point(376, 0);
            btnLogut.Name = "btnLogut";
            btnLogut.Size = new Size(150, 30);
            btnLogut.TabIndex = 5;
            btnLogut.Text = "Выход";
            btnLogut.UseVisualStyleBackColor = false;
            btnLogut.Click += BtnLogut_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnProducts);
            panel1.Controls.Add(btnOrders);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(536, 384);
            panel1.TabIndex = 2;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.FromArgb(67, 97, 238);
            btnProducts.Dock = DockStyle.Top;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.Font = new Font("Times New Roman", 12F);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(10, 60);
            btnProducts.Margin = new Padding(4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(516, 50);
            btnProducts.TabIndex = 5;
            btnProducts.Text = "ТОВАРЫ";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += BtnProducts_Click_1;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.FromArgb(67, 97, 238);
            btnOrders.Dock = DockStyle.Top;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Times New Roman", 12F);
            btnOrders.ForeColor = Color.White;
            btnOrders.Location = new Point(10, 10);
            btnOrders.Margin = new Padding(13);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(516, 50);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "ЗАКАЗЫ";
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += BtnOrders_Click_1;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 424);
            Controls.Add(panel1);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormMenu";
            Text = "Меню";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Button btnBack;
        private Label lblUserName;
        private Button btnLogut;
        private Panel panel1;
        private Button btnProducts;
        private Button btnOrders;
    }
}