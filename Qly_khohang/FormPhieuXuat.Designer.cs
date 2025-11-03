namespace Qly_Khohang
{
    partial class FormPhieuXuat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.Label lblSoLuongXuat;
        private System.Windows.Forms.ComboBox cbHang;
        private System.Windows.Forms.TextBox txtSoLuongXuat;
        private System.Windows.Forms.Button btnXuat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHang = new System.Windows.Forms.Label();
            this.lblSoLuongXuat = new System.Windows.Forms.Label();
            this.cbHang = new System.Windows.Forms.ComboBox();
            this.txtSoLuongXuat = new System.Windows.Forms.TextBox();
            this.btnXuat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels
            lblHang.Text = "Chọn hàng:"; lblHang.Location = new System.Drawing.Point(30, 30); lblHang.AutoSize = true;
            lblSoLuongXuat.Text = "Số lượng xuất:"; lblSoLuongXuat.Location = new System.Drawing.Point(30, 70); lblSoLuongXuat.AutoSize = true;

            // ComboBox
            cbHang.Location = new System.Drawing.Point(140, 27); cbHang.Size = new System.Drawing.Size(200, 22);
            cbHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // TextBox
            txtSoLuongXuat.Location = new System.Drawing.Point(140, 67); txtSoLuongXuat.Size = new System.Drawing.Size(200, 22);

            // Button
            btnXuat.Text = "Xuất hàng"; btnXuat.Location = new System.Drawing.Point(140, 110); btnXuat.Size = new System.Drawing.Size(100, 35);
            btnXuat.Click += new System.EventHandler(this.btnXuat_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(380, 170);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblHang, cbHang, lblSoLuongXuat, txtSoLuongXuat, btnXuat });
            this.Name = "FormPhieuXuat";
            this.Text = "Xuất hàng hóa";
            this.Load += new System.EventHandler(this.FormPhieuXuat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
