namespace Qly_Khohang
{
    partial class FormKhoHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearchBy;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearchBy = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.SuspendLayout();

            // ================= DataGridView =================
            this.dgvKho.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                 | System.Windows.Forms.AnchorStyles.Left
                                 | System.Windows.Forms.AnchorStyles.Right);
            this.dgvKho.Location = new System.Drawing.Point(12, 50);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.Size = new System.Drawing.Size(760, 380);
            this.dgvKho.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKho.MultiSelect = false;
            this.dgvKho.ReadOnly = true;
            this.dgvKho.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvKho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // ================= Thanh tìm kiếm =================
            // Label
            this.lblSearch.Text = "Tìm kiếm:";
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.AutoSize = true;

            // ComboBox (lọc theo)
            this.cbSearchBy.Items.AddRange(new string[] { "Tên hàng", "ID", "Mã Loại" });
            this.cbSearchBy.SelectedIndex = 0;
            this.cbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchBy.Location = new System.Drawing.Point(80, 12);
            this.cbSearchBy.Size = new System.Drawing.Size(120, 24);

            // TextBox (nhập từ khóa)
            this.txtSearch.Location = new System.Drawing.Point(210, 12);
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // ================= Nút =================
            void StyleButton(System.Windows.Forms.Button btn, string text, int x, int y, System.Drawing.Color color)
            {
                btn.Text = text;
                btn.Size = new System.Drawing.Size(100, 35);
                btn.Location = new System.Drawing.Point(x, y);
                btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                btn.BackColor = color;
                btn.ForeColor = System.Drawing.Color.White;
                btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }

            int btnY = 440;
            StyleButton(btnNhap, "Nhập hàng", 12, btnY, System.Drawing.Color.MediumSeaGreen);
            StyleButton(btnXuat, "Xuất hàng", 120, btnY, System.Drawing.Color.CornflowerBlue);
            StyleButton(btnSua, "Sửa hàng", 230, btnY, System.Drawing.Color.Orange);
            StyleButton(btnXoa, "Xóa hàng", 340, btnY, System.Drawing.Color.IndianRed);
            StyleButton(btnXuatExcel, "Xuất Excel", 450, btnY, System.Drawing.Color.Goldenrod);
            StyleButton(btnLamMoi, "Làm mới", 670, btnY, System.Drawing.Color.SlateGray);
            btnLamMoi.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // ================= Form =================
            this.ClientSize = new System.Drawing.Size(784, 491);
            this.Controls.Add(this.dgvKho);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cbSearchBy);
            this.Controls.Add(this.txtSearch);

            this.Name = "FormKhoHang";
            this.Text = "Quản lý kho hàng";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FormKhoHang_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
