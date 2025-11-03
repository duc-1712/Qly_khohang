using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;

namespace Qly_Khohang
{
    public partial class FormKhoHang : Form
    {
        private DataTable dtKho; // Lưu dữ liệu gốc để filter

        public FormKhoHang()
        {
            InitializeComponent();

            // Gán sự kiện cho các nút
            btnNhap.Click += btnNhap_Click;
            btnXuat.Click += btnXuat_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            // Gán sự kiện tìm kiếm
            txtSearch.TextChanged += TxtSearch_TextChanged;

            // Khởi tạo ComboBox tìm kiếm
            cbSearchBy.Items.Clear();
            cbSearchBy.Items.AddRange(new string[] { "Tên hàng", "Mã Loại", "Loại hàng" });
            cbSearchBy.SelectedIndex = 0;
        }

        private void FormKhoHang_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                string query = @"
        SELECT 
            m.id,
            m.tenhang AS 'Tên hàng',
            m.maloai AS 'Mã Loại',
            l.tenloai AS 'Loại hàng',
            m.soluong AS 'Số lượng',
            m.donvi AS 'Đơn Vị',
            m.dongia AS 'Đơn Giá'
        FROM mathang m
        LEFT JOIN loaihang l ON m.maloai = l.id";

                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtKho = new DataTable();
                    da.Fill(dtKho);

                    dgvKho.DataSource = dtKho;
                    dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    HighlightLowStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void HighlightLowStock()
        {
            if (dgvKho.Rows.Count == 0) return;

            int lowStockThreshold = 5;
            bool hasLowStock = false;

            foreach (DataGridViewRow row in dgvKho.Rows)
            {
                if (row.Cells["Số lượng"].Value != null &&
                    int.TryParse(row.Cells["Số lượng"].Value.ToString(), out int qty))
                {
                    if (qty <= lowStockThreshold)
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        hasLowStock = true;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
            }

            if (hasLowStock)
                MessageBox.Show("Có mặt hàng sắp hết! Vui lòng nhập thêm.", "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadProducts();
            txtSearch.Text = "";
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            FormPhieuNhap f = new FormPhieuNhap();
            f.FormClosed += (s, args) => LoadProducts();
            f.ShowDialog();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            FormPhieuXuat f = new FormPhieuXuat();
            f.FormClosed += (s, args) => LoadProducts();
            f.ShowDialog();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvKho.SelectedRows.Count == 0) { MessageBox.Show("Vui lòng chọn hàng để sửa."); return; }

            int id = Convert.ToInt32(dgvKho.SelectedRows[0].Cells["id"].Value);
            string tenhang = dgvKho.SelectedRows[0].Cells["Tên hàng"].Value.ToString();
            string maloai = dgvKho.SelectedRows[0].Cells["Mã Loại"].Value.ToString();
            int soluong = Convert.ToInt32(dgvKho.SelectedRows[0].Cells["Số lượng"].Value);
            string donvi = dgvKho.SelectedRows[0].Cells["Đơn Vị"].Value.ToString();
            decimal dongia = Convert.ToDecimal(dgvKho.SelectedRows[0].Cells["Đơn Giá"].Value);

            FormSuaHang f = new FormSuaHang(id, tenhang, maloai, soluong, donvi, dongia);
            f.FormClosed += (s, args) => LoadProducts();
            f.ShowDialog();
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKho.SelectedRows.Count == 0) { MessageBox.Show("Vui lòng chọn hàng để xóa."); return; }

            int id = Convert.ToInt32(dgvKho.SelectedRows[0].Cells["id"].Value);
            if (MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = Database.GetConnection())
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM mathang WHERE id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công.");
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvKho.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất!"); return; }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Chọn nơi lưu file Excel";
                sfd.FileName = "DanhSachKho.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("KhoHang");

                            // Header
                            for (int i = 0; i < dgvKho.Columns.Count; i++)
                                ws.Cell(1, i + 1).Value = dgvKho.Columns[i].HeaderText;

                            // Data
                            for (int i = 0; i < dgvKho.Rows.Count; i++)
                                for (int j = 0; j < dgvKho.Columns.Count; j++)
                                    ws.Cell(i + 2, j + 1).Value = dgvKho.Rows[i].Cells[j].Value?.ToString();

                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất Excel thành công: " + sfd.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                    }
                }
            }
        }

        // ===================== Tìm kiếm / Lọc động =====================
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dtKho == null) return;

            string keyword = txtSearch.Text.Trim().ToLower();
            string filterColumn = cbSearchBy.SelectedItem?.ToString() ?? "Tên hàng";

            if (string.IsNullOrEmpty(keyword))
            {
                dgvKho.DataSource = dtKho;
                HighlightLowStock();
                return;
            }

            var filteredRows = dtKho.AsEnumerable()
                .Where(r => r[filterColumn] != null && r[filterColumn].ToString().ToLower().Contains(keyword));

            if (filteredRows.Any())
                dgvKho.DataSource = filteredRows.CopyToDataTable();
            else
                dgvKho.DataSource = dtKho.Clone(); // Hiển thị rỗng nếu không có kết quả

            HighlightLowStock();
        }
    }
}
