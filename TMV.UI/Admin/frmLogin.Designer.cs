
namespace TMV.UI.Admin
{
  partial class frmLogin
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
      this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
      this.speRememberPassword = new DevExpress.XtraEditors.CheckEdit();
      this.lblPassword = new DevExpress.XtraEditors.LabelControl();
      this.grpUserInfo = new DevExpress.XtraEditors.GroupControl();
      this.txtUser_Password = new DevExpress.XtraEditors.TextEdit();
      this.lblUserName = new DevExpress.XtraEditors.LabelControl();
      this.txtUser_Name = new DevExpress.XtraEditors.TextEdit();
      this.PanelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.lblDealer = new DevExpress.XtraEditors.LabelControl();
      this.txtDealer = new DevExpress.XtraEditors.TextEdit();
      ((System.ComponentModel.ISupportInitialize)(this.speRememberPassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpUserInfo)).BeginInit();
      this.grpUserInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Password.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Name.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).BeginInit();
      this.PanelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtDealer.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancel
      // 
      this.btnCancel.ImageOptions.ImageIndex = 2;
      this.btnCancel.ImageOptions.ImageList = this.imgList;
      this.btnCancel.Location = new System.Drawing.Point(252, 8);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(124, 45);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "&Cancel";
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Transparent;
      this.imgList.Images.SetKeyName(0, "key1.png");
      this.imgList.Images.SetKeyName(1, "keys.png");
      this.imgList.Images.SetKeyName(2, "delete2.png");
      // 
      // btnLogin
      // 
      this.btnLogin.ImageOptions.ImageIndex = 1;
      this.btnLogin.ImageOptions.ImageList = this.imgList;
      this.btnLogin.Location = new System.Drawing.Point(122, 8);
      this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(124, 45);
      this.btnLogin.TabIndex = 0;
      this.btnLogin.Text = "&Login";
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // speRememberPassword
      // 
      this.speRememberPassword.Location = new System.Drawing.Point(142, 186);
      this.speRememberPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.speRememberPassword.Name = "speRememberPassword";
      this.speRememberPassword.Properties.Caption = "Remember Password";
      this.speRememberPassword.Size = new System.Drawing.Size(234, 27);
      this.speRememberPassword.TabIndex = 7;
      // 
      // lblPassword
      // 
      this.lblPassword.Location = new System.Drawing.Point(50, 139);
      this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(67, 19);
      this.lblPassword.TabIndex = 4;
      this.lblPassword.Text = "Password";
      // 
      // grpUserInfo
      // 
      this.grpUserInfo.Controls.Add(this.lblDealer);
      this.grpUserInfo.Controls.Add(this.txtDealer);
      this.grpUserInfo.Controls.Add(this.speRememberPassword);
      this.grpUserInfo.Controls.Add(this.txtUser_Password);
      this.grpUserInfo.Controls.Add(this.lblPassword);
      this.grpUserInfo.Controls.Add(this.lblUserName);
      this.grpUserInfo.Controls.Add(this.txtUser_Name);
      this.grpUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpUserInfo.Location = new System.Drawing.Point(0, 0);
      this.grpUserInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grpUserInfo.Name = "grpUserInfo";
      this.grpUserInfo.Size = new System.Drawing.Size(508, 239);
      this.grpUserInfo.TabIndex = 4;
      this.grpUserInfo.Text = "User Login Information";
      // 
      // txtUser_Password
      // 
      this.txtUser_Password.Location = new System.Drawing.Point(146, 137);
      this.txtUser_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtUser_Password.Name = "txtUser_Password";
      this.txtUser_Password.Properties.PasswordChar = '*';
      this.txtUser_Password.Size = new System.Drawing.Size(296, 26);
      this.txtUser_Password.TabIndex = 5;
      // 
      // lblUserName
      // 
      this.lblUserName.Location = new System.Drawing.Point(39, 94);
      this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblUserName.Name = "lblUserName";
      this.lblUserName.Size = new System.Drawing.Size(78, 19);
      this.lblUserName.TabIndex = 0;
      this.lblUserName.Text = "User Name";
      // 
      // txtUser_Name
      // 
      this.txtUser_Name.Location = new System.Drawing.Point(146, 92);
      this.txtUser_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtUser_Name.Name = "txtUser_Name";
      this.txtUser_Name.Size = new System.Drawing.Size(296, 26);
      this.txtUser_Name.TabIndex = 1;
      // 
      // PanelControl1
      // 
      this.PanelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
      this.PanelControl1.Appearance.Options.UseForeColor = true;
      this.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.PanelControl1.Controls.Add(this.btnCancel);
      this.PanelControl1.Controls.Add(this.btnLogin);
      this.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelControl1.Location = new System.Drawing.Point(0, 239);
      this.PanelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.PanelControl1.Name = "PanelControl1";
      this.PanelControl1.Size = new System.Drawing.Size(508, 58);
      this.PanelControl1.TabIndex = 5;
      // 
      // lblDealer
      // 
      this.lblDealer.Location = new System.Drawing.Point(72, 53);
      this.lblDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblDealer.Name = "lblDealer";
      this.lblDealer.Size = new System.Drawing.Size(45, 19);
      this.lblDealer.TabIndex = 8;
      this.lblDealer.Text = "Dealer";
      // 
      // txtDealer
      // 
      this.txtDealer.Location = new System.Drawing.Point(146, 50);
      this.txtDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtDealer.Name = "txtDealer";
      this.txtDealer.Size = new System.Drawing.Size(296, 26);
      this.txtDealer.TabIndex = 9;
      // 
      // frmLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(508, 297);
      this.Controls.Add(this.grpUserInfo);
      this.Controls.Add(this.PanelControl1);
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmLogin";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "TMV System Security : Login";
      this.Load += new System.EventHandler(this.frmLogin_Load);
      ((System.ComponentModel.ISupportInitialize)(this.speRememberPassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpUserInfo)).EndInit();
      this.grpUserInfo.ResumeLayout(false);
      this.grpUserInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Password.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUser_Name.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).EndInit();
      this.PanelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.txtDealer.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraEditors.SimpleButton btnCancel;
    internal System.Windows.Forms.ImageList imgList;
    internal DevExpress.XtraEditors.SimpleButton btnLogin;
    internal DevExpress.XtraEditors.CheckEdit speRememberPassword;
    internal DevExpress.XtraEditors.LabelControl lblPassword;
    internal DevExpress.XtraEditors.GroupControl grpUserInfo;
    internal DevExpress.XtraEditors.TextEdit txtUser_Password;
    internal DevExpress.XtraEditors.LabelControl lblUserName;
    internal DevExpress.XtraEditors.TextEdit txtUser_Name;
    internal DevExpress.XtraEditors.PanelControl PanelControl1;
    internal DevExpress.XtraEditors.LabelControl lblDealer;
    internal DevExpress.XtraEditors.TextEdit txtDealer;
  }
}