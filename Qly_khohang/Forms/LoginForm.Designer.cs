namespace Qly_Khohang
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnThoat;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Text = "Tài khoản:";
            this.label1.Location = new System.Drawing.Point(30, 30);

            // label2
            this.label2.AutoSize = true;
            this.label2.Text = "Mật khẩu:";
            this.label2.Location = new System.Drawing.Point(30, 80);

            // txtUser
            this.txtUser.Location = new System.Drawing.Point(120, 27);
            this.txtUser.Size = new System.Drawing.Size(180, 22);

            // txtPass
            this.txtPass.Location = new System.Drawing.Point(120, 77);
            this.txtPass.Size = new System.Drawing.Size(180, 22);
            this.txtPass.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Location = new System.Drawing.Point(40, 130);
            this.btnLogin.Size = new System.Drawing.Size(120, 35);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnThoat
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new System.Drawing.Point(180, 130);
            this.btnThoat.Size = new System.Drawing.Size(120, 35);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // FormLogin
            this.ClientSize = new System.Drawing.Size(330, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnThoat);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
