namespace CWProductProtectionCP
{
	partial class frmControlPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlPanel));
			this.pbLogo = new System.Windows.Forms.PictureBox();
			this.bntFindLogoFile = new System.Windows.Forms.Button();
			this.findLogoFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnEmbedPersistedObject = new System.Windows.Forms.Button();
			this.gbObjectProperties = new System.Windows.Forms.GroupBox();
			this.cbPeriodType = new System.Windows.Forms.ComboBox();
			this.lblPeriodType = new System.Windows.Forms.Label();
			this.lblPeriod = new System.Windows.Forms.Label();
			this.lblPackageName = new System.Windows.Forms.Label();
			this.txtTrialPeriod = new System.Windows.Forms.TextBox();
			this.txtPackageName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
			this.gbObjectProperties.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbLogo
			// 
			this.pbLogo.Location = new System.Drawing.Point(256, 12);
			this.pbLogo.Name = "pbLogo";
			this.pbLogo.Size = new System.Drawing.Size(113, 112);
			this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbLogo.TabIndex = 0;
			this.pbLogo.TabStop = false;
			// 
			// bntFindLogoFile
			// 
			this.bntFindLogoFile.Location = new System.Drawing.Point(256, 131);
			this.bntFindLogoFile.Name = "bntFindLogoFile";
			this.bntFindLogoFile.Size = new System.Drawing.Size(113, 27);
			this.bntFindLogoFile.TabIndex = 3;
			this.bntFindLogoFile.Text = "Find Logo";
			this.bntFindLogoFile.UseVisualStyleBackColor = true;
			this.bntFindLogoFile.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnEmbedPersistedObject
			// 
			this.btnEmbedPersistedObject.Location = new System.Drawing.Point(256, 165);
			this.btnEmbedPersistedObject.Name = "btnEmbedPersistedObject";
			this.btnEmbedPersistedObject.Size = new System.Drawing.Size(113, 27);
			this.btnEmbedPersistedObject.TabIndex = 4;
			this.btnEmbedPersistedObject.Text = "Embed Object";
			this.btnEmbedPersistedObject.UseVisualStyleBackColor = true;
			this.btnEmbedPersistedObject.Click += new System.EventHandler(this.btnEmbedPersistedObject_Click);
			// 
			// gbObjectProperties
			// 
			this.gbObjectProperties.Controls.Add(this.cbPeriodType);
			this.gbObjectProperties.Controls.Add(this.lblPeriodType);
			this.gbObjectProperties.Controls.Add(this.lblPeriod);
			this.gbObjectProperties.Controls.Add(this.lblPackageName);
			this.gbObjectProperties.Controls.Add(this.txtTrialPeriod);
			this.gbObjectProperties.Controls.Add(this.txtPackageName);
			this.gbObjectProperties.Location = new System.Drawing.Point(12, 12);
			this.gbObjectProperties.Name = "gbObjectProperties";
			this.gbObjectProperties.Size = new System.Drawing.Size(200, 180);
			this.gbObjectProperties.TabIndex = 3;
			this.gbObjectProperties.TabStop = false;
			this.gbObjectProperties.Text = "Object Properties:";
			// 
			// cbPeriodType
			// 
			this.cbPeriodType.FormattingEnabled = true;
			this.cbPeriodType.Items.AddRange(new object[] {
            "HOURS",
            "DAYS",
            "MONTHS",
            "ACTIVATIONS"});
			this.cbPeriodType.Location = new System.Drawing.Point(7, 124);
			this.cbPeriodType.Name = "cbPeriodType";
			this.cbPeriodType.Size = new System.Drawing.Size(121, 21);
			this.cbPeriodType.TabIndex = 2;
			// 
			// lblPeriodType
			// 
			this.lblPeriodType.AutoSize = true;
			this.lblPeriodType.Location = new System.Drawing.Point(7, 108);
			this.lblPeriodType.Name = "lblPeriodType";
			this.lblPeriodType.Size = new System.Drawing.Size(90, 13);
			this.lblPeriodType.TabIndex = 1;
			this.lblPeriodType.Text = "Trial Period Type:";
			// 
			// lblPeriod
			// 
			this.lblPeriod.AutoSize = true;
			this.lblPeriod.Location = new System.Drawing.Point(7, 63);
			this.lblPeriod.Name = "lblPeriod";
			this.lblPeriod.Size = new System.Drawing.Size(63, 13);
			this.lblPeriod.TabIndex = 1;
			this.lblPeriod.Text = "Trial Period:";
			// 
			// lblPackageName
			// 
			this.lblPackageName.AutoSize = true;
			this.lblPackageName.Location = new System.Drawing.Point(7, 17);
			this.lblPackageName.Name = "lblPackageName";
			this.lblPackageName.Size = new System.Drawing.Size(84, 13);
			this.lblPackageName.TabIndex = 1;
			this.lblPackageName.Text = "Package Name:";
			// 
			// txtTrialPeriod
			// 
			this.txtTrialPeriod.Location = new System.Drawing.Point(6, 82);
			this.txtTrialPeriod.Name = "txtTrialPeriod";
			this.txtTrialPeriod.Size = new System.Drawing.Size(188, 20);
			this.txtTrialPeriod.TabIndex = 1;
			this.txtTrialPeriod.Text = "30";
			// 
			// txtPackageName
			// 
			this.txtPackageName.Location = new System.Drawing.Point(6, 36);
			this.txtPackageName.Name = "txtPackageName";
			this.txtPackageName.Size = new System.Drawing.Size(188, 20);
			this.txtPackageName.TabIndex = 0;
			// 
			// frmControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(381, 206);
			this.Controls.Add(this.gbObjectProperties);
			this.Controls.Add(this.btnEmbedPersistedObject);
			this.Controls.Add(this.bntFindLogoFile);
			this.Controls.Add(this.pbLogo);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmControlPanel";
			this.Text = "CW Product Protection Control Panel";
			this.Load += new System.EventHandler(this.frmControlPanel_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
			this.gbObjectProperties.ResumeLayout(false);
			this.gbObjectProperties.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbLogo;
		private System.Windows.Forms.Button bntFindLogoFile;
		private System.Windows.Forms.OpenFileDialog findLogoFileDialog;
		private System.Windows.Forms.Button btnEmbedPersistedObject;
		private System.Windows.Forms.GroupBox gbObjectProperties;
		private System.Windows.Forms.Label lblPackageName;
		private System.Windows.Forms.TextBox txtPackageName;
		private System.Windows.Forms.ComboBox cbPeriodType;
		private System.Windows.Forms.Label lblPeriodType;
		private System.Windows.Forms.Label lblPeriod;
		private System.Windows.Forms.TextBox txtTrialPeriod;
	}
}

