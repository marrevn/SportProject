using Microsoft.EntityFrameworkCore;
using SportProject.Models;
using SportProject.Properties;

namespace SportProject
{
    public partial class FormProducts : Form
    {
        public User CurrentUser { get; private set; }
        public bool isGuest { get; private set; }
        public FormProducts(User user, bool guest)
        {
            InitializeComponent();

            var colPhoto = new DataGridViewImageColumn();
            colPhoto.Name = "colPhoto";
            colPhoto.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPhoto.Width = 200;
            colPhoto.FillWeight = 30;

            var colInfo = new DataGridViewTextBoxColumn();
            colInfo.Name = "colInfo";
            colInfo.FillWeight = 60;
            colInfo.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            var colOldPrice = new DataGridViewTextBoxColumn();
            colOldPrice.Name = "colOldPrice";
            colOldPrice.HeaderText = "Цена";
            colOldPrice.FillWeight = 10;

            var colFinalPrice = new DataGridViewTextBoxColumn();
            colFinalPrice.Name = "colFinalPrice";
            colFinalPrice.HeaderText = "Цена со скидкой";
            colFinalPrice.FillWeight = 10;

            var colDiscount = new DataGridViewTextBoxColumn();
            colDiscount.Name = "colDiscount";
            colDiscount.FillWeight = 10;
            colDiscount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProducts.Columns.AddRange(
            [
                colPhoto,colInfo, colOldPrice, colFinalPrice,colDiscount
            ]);

            CurrentUser = user;
            isGuest = guest;

            lblUserName.Text = isGuest ? "Гость" : CurrentUser.Fio;

            LoadProducts();


        }

        private void LoadProducts()
        {
            try
            {

                using (var db = new SportDbContext())
                {
                    var products = db.Tovars
                        .Include(i => i.Category)
                        .Include(i => i.Manufacturer)
                        .Include(i => i.Supplier)
                        .Include(i => i.Measure)
                        .Include(i => i.Good)
                        .ToList();

                    dgvProducts.SuspendLayout();
                    dgvProducts.Rows.Clear();

                    foreach (var product in products)
                    {
                        int rowIndex = dgvProducts.Rows.Add();
                        var row = dgvProducts.Rows[rowIndex];

                        row.Cells["colPhoto"].Value = LoadProductImage(product.PhotoUrl);

                        row.Cells["colInfo"].Value = FormatProductInfo(product);

                        row.Cells["colOldPrice"].Value = product.Price.ToString("C");

                        if (product.Discount > 0)
                        {
                            decimal finalPrice = product.Price * (100 - product.Discount) / 100;
                            row.Cells["colFinalPrice"].Value = finalPrice.ToString("C");
                        }
                        else
                        {
                            row.Cells["colFinalPrice"].Value = "";
                        }

                        row.Cells["colDiscount"].Value = $"{product.Discount}%";

                        row.Cells["colDiscount"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        ApplyRowStyles(row, product);
                    }
                    dgvProducts.ResumeLayout();
                    dgvProducts.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyles(DataGridViewRow row, Tovar product)
        {
            if (product.CountTovars <= 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue;
                row.DefaultCellStyle.ForeColor = Color.Black;
                return;
            }
            if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor =
                    ColorTranslator.FromHtml("#2E8B57");
                row.DefaultCellStyle.ForeColor = Color.White;
            }

            if (product.Discount > 0)
            {
                row.Cells["colOldPrice"].Style.ForeColor = Color.Red;
                row.Cells["colOldPrice"].Style.Font = new Font(
                    row.DataGridView.Font,
                    FontStyle.Strikeout);

                row.Cells["colFinalPrice"].Style.ForeColor = Color.Black;
                row.Cells["colFinalPrice"].Style.Font = row.DataGridView.Font;
            }
        }


        private string FormatProductInfo(Tovar product)
        {
            string priceText;
            if (product.Discount > 0)
            {
                decimal finalPrice = product.Price * (100 - product.Discount) / 100;
                priceText = $"Цена: {product.Price:C} ->  {finalPrice:C}";
            }
            else
            {
                priceText = $"Цена: {product.Price:C}";
            }
            return $"{product.Category.CategoryName} | {product.Good.GoodName}" + Environment.NewLine +
                $"Описание товара: {product.Descreption}" + Environment.NewLine +
                $"Производитель: {product.Manufacturer.ManufacturerName}" + Environment.NewLine +
                $"Поставщик: {product.Supplier.SupplierName}" + Environment.NewLine +
                $"{priceText}" + Environment.NewLine +
                $"Единица измерения: {product.Measure.MeasureName}" + Environment.NewLine +
                $"Количество на складе: {product.CountTovars}";

        }

        private Image LoadProductImage(string photoUrl)
        {
            if (!String.IsNullOrEmpty(photoUrl) && System.IO.File.Exists(photoUrl))
            {
                return Image.FromFile(photoUrl);
            }

            return Resources.picture;

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

        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
