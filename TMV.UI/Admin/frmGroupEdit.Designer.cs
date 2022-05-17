
namespace TMV.UI.Admin
{
  partial class frmGroupEdit
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupEdit));
      this.txtGROUP_TEXT = new DevExpress.XtraEditors.TextEdit();
      this.btnSave = new DevExpress.XtraEditors.SimpleButton();
      this.imglImporterEdit = new System.Windows.Forms.ImageList(this.components);
      this.btnClose = new DevExpress.XtraEditors.SimpleButton();
      this.grpGroupInfo = new DevExpress.XtraEditors.GroupControl();
      this.lblImporter = new DevExpress.XtraEditors.LabelControl();
      this.imgList = new System.Windows.Forms.ImageList(this.components);
      this.PanelControl1 = new DevExpress.XtraEditors.PanelControl();
      ((System.ComponentModel.ISupportInitialize)(this.txtGROUP_TEXT.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpGroupInfo)).BeginInit();
      this.grpGroupInfo.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).BeginInit();
      this.PanelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtGROUP_TEXT
      // 
      this.txtGROUP_TEXT.Location = new System.Drawing.Point(178, 85);
      this.txtGROUP_TEXT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.txtGROUP_TEXT.Name = "txtGROUP_TEXT";
      this.txtGROUP_TEXT.Size = new System.Drawing.Size(510, 26);
      this.txtGROUP_TEXT.TabIndex = 1;
      // 
      // btnSave
      // 
      this.btnSave.ImageOptions.ImageIndex = 3;
      this.btnSave.ImageOptions.ImageList = this.imglImporterEdit;
      this.btnSave.Location = new System.Drawing.Point(234, 8);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(124, 45);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "&Save";
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // imglImporterEdit
      // 
      this.imglImporterEdit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglImporterEdit.ImageStream")));
      this.imglImporterEdit.TransparentColor = System.Drawing.Color.Transparent;
      this.imglImporterEdit.Images.SetKeyName(0, "Add.bmp");
      this.imglImporterEdit.Images.SetKeyName(1, "pcCloseButton.png");
      this.imglImporterEdit.Images.SetKeyName(2, "ButtonRefresh.png");
      this.imglImporterEdit.Images.SetKeyName(3, "ButtonSave.png");
      // 
      // btnClose
      // 
      this.btnClose.ImageOptions.ImageIndex = 1;
      this.btnClose.ImageOptions.ImageList = this.imglImporterEdit;
      this.btnClose.Location = new System.Drawing.Point(369, 8);
      this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(124, 45);
      this.btnClose.TabIndex = 2;
      this.btnClose.Text = "&Close";
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // grpGroupInfo
      // 
      this.grpGroupInfo.Controls.Add(this.lblImporter);
      this.grpGroupInfo.Controls.Add(this.txtGROUP_TEXT);
      this.grpGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.grpGroupInfo.Location = new System.Drawing.Point(0, 0);
      this.grpGroupInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.grpGroupInfo.Name = "grpGroupInfo";
      this.grpGroupInfo.Size = new System.Drawing.Size(801, 182);
      this.grpGroupInfo.TabIndex = 4;
      this.grpGroupInfo.Text = "Information";
      // 
      // lblImporter
      // 
      this.lblImporter.Location = new System.Drawing.Point(72, 91);
      this.lblImporter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.lblImporter.Name = "lblImporter";
      this.lblImporter.Size = new System.Drawing.Size(80, 19);
      this.lblImporter.TabIndex = 0;
      this.lblImporter.Text = "Group Text";
      // 
      // imgList
      // 
      this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
      this.imgList.TransparentColor = System.Drawing.Color.Transparent;
      this.imgList.Images.SetKeyName(0, "pcCloseButton.png");
      this.imgList.Images.SetKeyName(1, "BtnSave.png");
      this.imgList.Images.SetKeyName(2, "ButtonSaveAndClose.png");
      this.imgList.Images.SetKeyName(3, "find_selection.png");
      this.imgList.Images.SetKeyName(4, "Copy of save-32x32.png");
      this.imgList.Images.SetKeyName(5, "document_delete.png");
      this.imgList.Images.SetKeyName(6, "document_edit.png");
      this.imgList.Images.SetKeyName(7, "selection.png");
      this.imgList.Images.SetKeyName(8, "copy.png");
      this.imgList.Images.SetKeyName(9, "document_add.png");
      this.imgList.Images.SetKeyName(10, "export1.png");
      this.imgList.Images.SetKeyName(11, "cashier.png");
      this.imgList.Images.SetKeyName(12, "printer.png");
      this.imgList.Images.SetKeyName(13, "EDITITEM.GIF");
      this.imgList.Images.SetKeyName(14, "icon-excel-16x16.gif");
      this.imgList.Images.SetKeyName(15, "cubes_yellow.png");
      this.imgList.Images.SetKeyName(16, "cubes.png");
      this.imgList.Images.SetKeyName(17, "cubes_blue.png");
      this.imgList.Images.SetKeyName(18, "cubes_green.png");
      this.imgList.Images.SetKeyName(19, "cube_blue.png");
      this.imgList.Images.SetKeyName(20, "cube_green.png");
      this.imgList.Images.SetKeyName(21, "cube_yellow.png");
      // 
      // PanelControl1
      // 
      this.PanelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
      this.PanelControl1.Appearance.Options.UseForeColor = true;
      this.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
      this.PanelControl1.Controls.Add(this.btnClose);
      this.PanelControl1.Controls.Add(this.btnSave);
      this.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PanelControl1.Location = new System.Drawing.Point(0, 182);
      this.PanelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.PanelControl1.Name = "PanelControl1";
      this.PanelControl1.Size = new System.Drawing.Size(801, 58);
      this.PanelControl1.TabIndex = 5;
      // 
      // frmGroupEdit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(801, 240);
      this.Controls.Add(this.grpGroupInfo);
      this.Controls.Add(this.PanelControl1);
      this.Name = "frmGroupEdit";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Group Edit";
      ((System.ComponentModel.ISupportInitialize)(this.txtGROUP_TEXT.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.grpGroupInfo)).EndInit();
      this.grpGroupInfo.ResumeLayout(false);
      this.grpGroupInfo.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PanelControl1)).EndInit();
      this.PanelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    internal DevExpress.XtraEditors.TextEdit txtGROUP_TEXT;
    internal DevExpress.XtraEditors.SimpleButton btnSave;
    internal System.Windows.Forms.ImageList imglImporterEdit;
    internal DevExpress.XtraEditors.SimpleButton btnClose;
    internal DevExpress.XtraEditors.GroupControl grpGroupInfo;
    internal DevExpress.XtraEditors.LabelControl lblImporter;
    internal System.Windows.Forms.ImageList imgList;
    internal DevExpress.XtraEditors.PanelControl PanelControl1;
  }
}