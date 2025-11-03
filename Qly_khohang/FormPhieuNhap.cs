using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Qly_Khohang
{
    public partial class FormPhieuNhap : Form
    {
        public FormPhieuNhap()
        {
            InitializeComponent();
            LoadLoaiHang();
        }

        private void LoadLoaiHang()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(
                        "SELECT id, tenloai FROM loaihang ORDER BY id", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbLoaiHang.DataSource = dt;
                    cbLoaiHang.DisplayMember = "tenloai"; // Hiển thị tên loại
                    cbLoaiHang.ValueMember = "id";         // Lưu mã loại
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại hàng: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                string.IsNullOrWhiteSpace(txtDonVi.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soluong))
            {
                MessageBox.Show("Số lượng phải là số nguyên.");
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal dongia))
            {
                MessageBox.Show("Đơn giá phải là số hợp lệ.");
                return;
            }

            int maloai = Convert.ToInt32(cbLoaiHang.SelectedValue);
            string tenHang = txtTenHang.Text.Trim();

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra xem hàng đã tồn tại chưa
                    string checkQuery = @"SELECT id, soluong FROM mathang 
                                  WHERE tenhang = @ten AND maloai = @ml";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ten", tenHang);
                    checkCmd.Parameters.AddWithValue("@ml", maloai);

                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Hàng đã tồn tại → cập nhật số lượng
                        string updateQuery = @"UPDATE mathang 
                                       SET soluong = soluong + @sl, dongia = @dg 
                                       WHERE tenhang = @ten AND maloai = @ml";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@sl", soluong);
                        updateCmd.Parameters.AddWithValue("@dg", dongia);
                        updateCmd.Parameters.AddWithValue("@ten", tenHang);
                        updateCmd.Parameters.AddWithValue("@ml", maloai);

                        updateCmd.ExecuteNonQuery();
                        MessageBox.Show("Đã cập nhật thêm số lượng cho mặt hàng tồn tại.");
                    }
                    else
                    {
                        // Hàng chưa tồn tại → thêm mới
                        string insertQuery = @"INSERT INTO mathang (tenhang, donvi, dongia, maloai, soluong)
                                       VALUES (@ten, @dv, @dg, @ml, @sl)";
                        MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@ten", tenHang);
                        insertCmd.Parameters.AddWithValue("@dv", txtDonVi.Text);
                        insertCmd.Parameters.AddWithValue("@dg", dongia);
                        insertCmd.Parameters.AddWithValue("@ml", maloai);
                        insertCmd.Parameters.AddWithValue("@sl", soluong);

                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm hàng mới thành công.");
                    }

                    this.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi nhập hàng: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
