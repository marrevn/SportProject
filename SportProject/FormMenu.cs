using SportProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SportProject
{
    public partial class FormMenu : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormMenu(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.Fio;

            btnOrders.Visible = !IsGuest;
        }


        private void BtnProducts_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (var formProducts = new FormProducts(CurrentUser, IsGuest))
            {
                formProducts.ShowDialog();
                this.Show();
            }
        }

        private void BtnOrders_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (var formOrders = new FormOrders(CurrentUser))
            {
                formOrders.ShowDialog();
                this.Show();
            }
        }

        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}