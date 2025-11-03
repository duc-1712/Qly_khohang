namespace Qly_Khohang
{
    partial class FormSuaHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.Label lblLoaiHang;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.ComboBox cbLoaiHang; // Thay TextBox bằng ComboBox
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnLuu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTenHang = new System.Windows.Forms.Label();
            this.lblLoaiHang = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.cbLoaiHang = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.Location = new System.Drawing.Point(30, 30);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(70, 17);
            this.lblTenHang.Text = "Tên hàng:";
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(120, 27);
            this.txtTenHang.Size = new System.Drawing.Size(200, 22);
            // 
            // lblLoaiHang
            // 
            this.lblLoaiHang.AutoSize = true;
            this.lblLoaiHang.Location = new System.Drawing.Point(30, 70);
            this.lblLoaiHang.Name = "lblLoaiHang";
            this.lblLoaiHang.Size = new System.Drawing.Size(67, 17);
            this.lblLoaiHang.Text = "Loại hàng:";
            // 
            // cbLoaiHang
            // 
            this.cbLoaiHang.Location = new System.Drawing.Point(120, 67);
            this.cbLoaiHang.Size = new System.Drawing.Size(200, 24);
            this.cbLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(30, 110);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(67, 17);
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(120, 107);
            this.txtSoLuong.Size = new System.Drawing.Size(200, 22);
            // 
            // lblDonVi
            // 
            this.lblDonVi.AutoSize = true;
            this.lblDonVi.Location = new System.Drawing.Point(30, 150);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(51, 17);
            this.lblDonVi.Text = "Đơn vị:";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(120, 147);
            this.txtDonVi.Size = new System.Drawing.Size(200, 22);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(30, 190);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(60, 17);
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(120, 187);
            this.txtDonGia.Size = new System.Drawing.Size(200, 22);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(120, 230);
            this.btnLuu.Size = new System.Drawing.Size(90, 35);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // FormSuaHang
            // 
            this.ClientSize = new System.Drawing.Size(360, 290);
            this.Controls.Add(this.lblTenHang);
            this.Controls.Add(this.txtTenHang);
            this.Controls.Add(this.lblLoaiHang);
            this.Controls.Add(this.cbLoaiHang);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnLuu);
            this.Name = "FormSuaHang";
            this.Text = "Sửa hàng hóa";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
