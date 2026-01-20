using SportProject.Models;
using System.Data;

namespace SportProject
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }
        public bool isGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var db = new SportDbContext())
            {
                var user = db.Users
                    .Where(w => w.Login == txtLogin.Text && w.PasswordUser == txtPassword.Text)
                    .FirstOrDefault();
                if (user != null)
                {
                    CurrentUser = user;
                    isGuest = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            isGuest = true;
            this.DialogResult=DialogResult.OK;
            this.Close();

        }
    }
}
