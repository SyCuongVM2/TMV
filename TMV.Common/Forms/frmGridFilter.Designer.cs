
namespace TMV.Common.Forms
{
  partial class frmGridFilter
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.cmdOK = new System.Windows.Forms.Button();
      this.grdTableSetting = new System.Windows.Forms.DataGridView();
      this.Column_Name = new System.Windows.Forms.DataGridViewComboBoxColumn();
      this.Column_Criteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cmdCancel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.grdTableSetting)).BeginInit();
      this.SuspendLayout();
      // 
      // cmdOK
      // 
      this.cmdOK.Location = new System.Drawing.Point(396, 398);
      this.cmdOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cmdOK.Name = "cmdOK";
      this.cmdOK.Size = new System.Drawing.Size(120, 35);
      this.cmdOK.TabIndex = 10;
      this.cmdOK.Text = "&OK";
      this.cmdOK.UseVisualStyleBackColor = true;
      this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
      // 
      // grdTableSetting
      // 
      this.grdTableSetting.AllowUserToResizeColumns = false;
      this.grdTableSetting.AllowUserToResizeRows = false;
      dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.grdTableSetting.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
      this.grdTableSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.grdTableSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Name,
            this.Column_Criteria});
      this.grdTableSetting.Location = new System.Drawing.Point(22, 19);
      this.grdTableSetting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 12);
      this.grdTableSetting.Name = "grdTableSetting";
      this.grdTableSetting.RowHeadersWidth = 62;
      this.grdTableSetting.Size = new System.Drawing.Size(622, 362);
      this.grdTableSetting.TabIndex = 9;
      // 
      // Column_Name
      // 
      this.Column_Name.DataPropertyName = "Column_Name";
      this.Column_Name.HeaderText = "Column";
      this.Column_Name.MinimumWidth = 8;
      this.Column_Name.Name = "Column_Name";
      this.Column_Name.Width = 150;
      // 
      // Column_Criteria
      // 
      this.Column_Criteria.DataPropertyName = "Column_Criteria";
      this.Column_Criteria.HeaderText = "Criteria";
      this.Column_Criteria.MinimumWidth = 8;
      this.Column_Criteria.Name = "Column_Criteria";
      this.Column_Criteria.Width = 220;
      // 
      // cmdCancel
      // 
      this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cmdCancel.Location = new System.Drawing.Point(524, 398);
      this.cmdCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(120, 35);
      this.cmdCancel.TabIndex = 11;
      this.cmdCancel.Text = "&Cancel";
      this.cmdCancel.UseVisualStyleBackColor = true;
      this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
      // 
      // frmGridFilter
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(666, 452);
      this.Controls.Add(this.cmdOK);
      this.Controls.Add(this.grdTableSetting);
      this.Controls.Add(this.cmdCancel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmGridFilter";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Filter Data";
      ((System.ComponentModel.ISupportInitialize)(this.grdTableSetting)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    internal System.Windows.Forms.Button cmdOK;
    internal System.Windows.Forms.DataGridView grdTableSetting;
    internal System.Windows.Forms.DataGridViewComboBoxColumn Column_Name;
    internal System.Windows.Forms.DataGridViewTextBoxColumn Column_Criteria;
    internal System.Windows.Forms.Button cmdCancel;
  }
}