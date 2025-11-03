namespace Qly_Khohang
{
    partial class FormPhieuNhap
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.ComboBox cbLoaiHang;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblLoaiHang;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.cbLoaiHang = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblLoaiHang = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Labels
            this.lblTenHang.Text = "Tên hàng:";
            this.lblTenHang.Location = new System.Drawing.Point(20, 20);
            this.lblTenHang.AutoSize = true;

            this.lblDonVi.Text = "Đơn vị:";
            this.lblDonVi.Location = new System.Drawing.Point(20, 60);
            this.lblDonVi.AutoSize = true;

            this.lblSoLuong.Text = "Số lượng:";
            this.lblSoLuong.Location = new System.Drawing.Point(20, 100);
            this.lblSoLuong.AutoSize = true;

            this.lblDonGia.Text = "Đơn giá:";
            this.lblDonGia.Location = new System.Drawing.Point(20, 140);
            this.lblDonGia.AutoSize = true;

            this.lblLoaiHang.Text = "Loại hàng:";
            this.lblLoaiHang.Location = new System.Drawing.Point(20, 180);
            this.lblLoaiHang.AutoSize = true;

            // TextBoxes
            this.txtTenHang.Location = new System.Drawing.Point(120, 17);
            this.txtTenHang.Size = new System.Drawing.Size(200, 22);

            this.txtDonVi.Location = new System.Drawing.Point(120, 57);
            this.txtDonVi.Size = new System.Drawing.Size(200, 22);

            this.txtSoLuong.Location = new System.Drawing.Point(120, 97);
            this.txtSoLuong.Size = new System.Drawing.Size(200, 22);

            this.txtDonGia.Location = new System.Drawing.Point(120, 137);
            this.txtDonGia.Size = new System.Drawing.Size(200, 22);

            // ComboBox
            this.cbLoaiHang.Location = new System.Drawing.Point(120, 177);
            this.cbLoaiHang.Size = new System.Drawing.Size(200, 24);
            this.cbLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // Buttons
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Location = new System.Drawing.Point(50, 220);
            this.btnLuu.Size = new System.Drawing.Size(100, 35);
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnHuy.Text = "Hủy";
            this.btnHuy.Location = new System.Drawing.Point(180, 220);
            this.btnHuy.Size = new System.Drawing.Size(100, 35);
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // FormPhieuNhap
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Controls.Add(this.lblTenHang);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblLoaiHang);
            this.Controls.Add(this.txtTenHang);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.cbLoaiHang);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Name = "FormPhieuNhap";
            this.Text = "Nhập hàng";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
