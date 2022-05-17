
namespace TMV.Common.Forms
{
  partial class frmProgress
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.cmdCancel = new System.Windows.Forms.Button();
      this.lbDescription = new System.Windows.Forms.Label();
      this.LoadingCircle = new FAMP.LoadingCircle();
      this.Timer_Event = new System.Windows.Forms.Timer(this.components);
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.cmdCancel);
      this.panel1.Controls.Add(this.lbDescription);
      this.panel1.Controls.Add(this.LoadingCircle);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(292, 36);
      this.panel1.TabIndex = 0;
      // 
      // cmdCancel
      // 
      this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cmdCancel.Location = new System.Drawing.Point(212, 5);
      this.cmdCancel.Name = "cmdCancel";
      this.cmdCancel.Size = new System.Drawing.Size(75, 23);
      this.cmdCancel.TabIndex = 9;
      this.cmdCancel.Text = "Cancel";
      this.cmdCancel.UseVisualStyleBackColor = true;
      this.cmdCancel.Visible = false;
      this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
      // 
      // lbDescription
      // 
      this.lbDescription.AutoSize = true;
      this.lbDescription.Location = new System.Drawing.Point(39, 12);
      this.lbDescription.Name = "lbDescription";
      this.lbDescription.Size = new System.Drawing.Size(82, 20);
      this.lbDescription.TabIndex = 8;
      this.lbDescription.Text = "Loading ...";
      // 
      // LoadingCircle
      // 
      this.LoadingCircle.Active = false;
      this.LoadingCircle.Color = System.Drawing.Color.Green;
      this.LoadingCircle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LoadingCircle.InnerCircleRadius = 5;
      this.LoadingCircle.Location = new System.Drawing.Point(3, 0);
      this.LoadingCircle.Name = "LoadingCircle";
      this.LoadingCircle.NumberSpoke = 12;
      this.LoadingCircle.OuterCircleRadius = 11;
      this.LoadingCircle.RotationSpeed = 150;
      this.LoadingCircle.Size = new System.Drawing.Size(38, 35);
      this.LoadingCircle.SpokeThickness = 2;
      this.LoadingCircle.StylePreset = FAMP.LoadingCircle.StylePresets.MacOSX;
      this.LoadingCircle.TabIndex = 7;
      // 
      // Timer_Event
      // 
      this.Timer_Event.Interval = 50;
      this.Timer_Event.Tick += new System.EventHandler(this.Timer_Event_Tick);
      // 
      // frmProgress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 36);
      this.ControlBox = false;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "frmProgress";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmProgress";
      this.Activated += new System.EventHandler(this.frmProgress_Activated);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    internal System.Windows.Forms.Button cmdCancel;
    public System.Windows.Forms.Label lbDescription;
    internal FAMP.LoadingCircle LoadingCircle;
    private System.Windows.Forms.Timer Timer_Event;
  }
}