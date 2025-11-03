using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Qly_Khohang
{
    public partial class FormPhieuXuat : Form
    {
        public FormPhieuXuat() { InitializeComponent(); }

        private void FormPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadHangHoa();
        }

        private void LoadHangHoa()
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT id, tenhang, maloai, soluong, donvi FROM mathang";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbHang.DisplayMember = "TenHienThi";
                    cbHang.ValueMember = "id";

                    // Thêm cột ảo TenHienThi = tên hàng + mã loại + số lượng
                    dt.Columns.Add("TenHienThi", typeof(string), "tenhang + ' (' + maloai + ') - SL:' + soluong");
                    cbHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách hàng: " + ex.Message);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (cbHang.SelectedValue == null || string.IsNullOrWhiteSpace(txtSoLuongXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn hàng và nhập số lượng xuất!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(cbHang.SelectedValue);
                int soLuongXuat = Convert.ToInt32(txtSoLuongXuat.Text);

                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra số lượng tồn kho
                    string checkSql = "SELECT soluong FROM mathang WHERE id=@id";
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int soLuongTon = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (soLuongXuat > soLuongTon)
                    {
                        MessageBox.Show($"Số lượng xuất vượt quá tồn kho ({soLuongTon})!");
                        return;
                    }

                    // Cập nhật số lượng
                    string sql = "UPDATE mathang SET soluong=soluong-@xuat WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@xuat", soLuongXuat);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xuất hàng thành công!");
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng xuất phải là số hợp lệ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hàng: " + ex.Message);
            }
        }
    }
}
