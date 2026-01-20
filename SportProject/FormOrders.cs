using Microsoft.EntityFrameworkCore;
using SportProject.Models;
using System.Data;

namespace SportProject
{
    public partial class FormOrders : Form
    {
        public User CurrentUser { get; private set; }
        public FormOrders(User user)
        {
            InitializeComponent();

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 80;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colDelivery = new DataGridViewTextBoxColumn();
            colDelivery.Name = "colDelivery";
            colDelivery.FillWeight = 20;
            colDelivery.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvOrders.Columns.AddRange(
            [
                colInfo, colDelivery
            ]);

            CurrentUser = user;

            lblUserName.Text = CurrentUser.Fio;

            LoadOrders();
        }
        private void LoadOrders()
        {
            try
            {
                using (var db = new Models.SportDbContext())
                {
                    var orders = db.Orders
                        .Include(i => i.OrdersCompositions)
                            .ThenInclude(i => i.Tovar)
                        .Include(i => i.Status)
                        .Include(i => i.PickupPoint)
                        .Where(o => o.IdUser == CurrentUser.Id)
                        .ToList();
                    dgvOrders.SuspendLayout();
                    dgvOrders.Rows.Clear();

                    foreach (var order in orders)
                    {

                        int rowIndex = dgvOrders.Rows.Add();
                        var row = dgvOrders.Rows[rowIndex];

                        row.Cells["colInfo"].Value = FormatOrderInfo(order);
                        row.Cells["colDelivery"].Value = $"{order.DateDelivery}";

                    }
                    dgvOrders.ResumeLayout();
                    dgvOrders.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string FormatOrderInfo(Order order)
        {
            var articleNumbers = order.OrdersCompositions
                .Select(po => po.Tovar.Article)
                .ToArray();
            string articlesString = string.Join(", ", articleNumbers);

            return $"Артикулы: {articlesString}" + Environment.NewLine +
            $"Статус заказа: {order.Status.StatusName}" + Environment.NewLine +
            $"Адрес пункта выдачи: {order.PickupPoint.DeliveryAddress}" + Environment.NewLine +
            $"Дата доставки: {order.DateOrder}";
        }

        private void BtnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public FormOrders()
        {
            InitializeComponent();
        }
    }
}
