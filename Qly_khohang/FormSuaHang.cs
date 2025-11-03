using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Qly_Khohang
{
    public partial class FormSuaHang : Form
    {
        private int productId;

        public FormSuaHang(int id, string tenhang, string maloai, int soluong, string donvi, decimal dongia)
        {
            InitializeComponent();
            productId = id;

            txtTenHang.Text = tenhang;
            txtSoLuong.Text = soluong.ToString();
            txtDonVi.Text = donvi;
            txtDonGia.Text = dongia.ToString();

            LoadLoaiHang(maloai);
        }

        private void LoadLoaiHang(string selectedId)
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, tenloai FROM loaihang", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbLoaiHang.DataSource = dt;
                    cbLoaiHang.DisplayMember = "tenloai";
                    cbLoaiHang.ValueMember = "id";
                    cbLoaiHang.SelectedValue = selectedId; // Chọn loại hiện tại
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
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtDonVi.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try
            {
                int soluong = Convert.ToInt32(txtSoLuong.Text);
                decimal dongia = Convert.ToDecimal(txtDonGia.Text);
                int maloai = Convert.ToInt32(cbLoaiHang.SelectedValue);

                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = @"UPDATE mathang 
                                   SET tenhang=@tenhang, maloai=@maloai, soluong=@soluong, donvi=@donvi, dongia=@dongia 
                                   WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@tenhang", txtTenHang.Text);
                    cmd.Parameters.AddWithValue("@maloai", maloai);
                    cmd.Parameters.AddWithValue("@soluong", soluong);
                    cmd.Parameters.AddWithValue("@donvi", txtDonVi.Text);
                    cmd.Parameters.AddWithValue("@dongia", dongia);
                    cmd.Parameters.AddWithValue("@id", productId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật thành công!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại. Vui lòng thử lại.");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng và đơn giá phải là số hợp lệ.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }
    }
}
