namespace CWProductProtectionKeyGen
{
	partial class cwKeyGenMainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cwKeyGenMainForm));
			this.cmdGenKey = new System.Windows.Forms.Button();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtLName = new System.Windows.Forms.TextBox();
			this.txtFName = new System.Windows.Forms.TextBox();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.lblFirst = new System.Windows.Forms.Label();
			this.lblLast = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblEMail = new System.Windows.Forms.Label();
			this.lblKey = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdGenKey
			// 
			this.cmdGenKey.Location = new System.Drawing.Point(267, 135);
			this.cmdGenKey.Name = "cmdGenKey";
			this.cmdGenKey.Size = new System.Drawing.Size(122, 23);
			this.cmdGenKey.TabIndex = 5;
			this.cmdGenKey.Text = "Generate Key";
			this.cmdGenKey.UseVisualStyleBackColor = true;
			this.cmdGenKey.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(12, 138);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(249, 20);
			this.txtEmail.TabIndex = 4;
			this.txtEmail.Text = "cessnuncaseyb@casewarecomputers.com";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(12, 100);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(249, 20);
			this.txtPhone.TabIndex = 3;
			this.txtPhone.Text = "1(541)740-3888";
			// 
			// txtLName
			// 
			this.txtLName.Location = new System.Drawing.Point(12, 61);
			this.txtLName.Name = "txtLName";
			this.txtLName.Size = new System.Drawing.Size(249, 20);
			this.txtLName.TabIndex = 2;
			this.txtLName.Text = "Cessnun";
			// 
			// txtFName
			// 
			this.txtFName.Location = new System.Drawing.Point(12, 22);
			this.txtFName.Name = "txtFName";
			this.txtFName.Size = new System.Drawing.Size(249, 20);
			this.txtFName.TabIndex = 1;
			this.txtFName.Text = "Casey";
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(11, 177);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(378, 20);
			this.txtKey.TabIndex = 6;
			// 
			// lblFirst
			// 
			this.lblFirst.AutoSize = true;
			this.lblFirst.Location = new System.Drawing.Point(9, 6);
			this.lblFirst.Name = "lblFirst";
			this.lblFirst.Size = new System.Drawing.Size(60, 13);
			this.lblFirst.TabIndex = 0;
			this.lblFirst.Text = "First Name:";
			// 
			// lblLast
			// 
			this.lblLast.AutoSize = true;
			this.lblLast.Location = new System.Drawing.Point(8, 45);
			this.lblLast.Name = "lblLast";
			this.lblLast.Size = new System.Drawing.Size(61, 13);
			this.lblLast.TabIndex = 0;
			this.lblLast.Text = "Last Name:";
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new System.Drawing.Point(8, 84);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(81, 13);
			this.lblPhone.TabIndex = 0;
			this.lblPhone.Text = "Phone Number:";
			// 
			// lblEMail
			// 
			this.lblEMail.AutoSize = true;
			this.lblEMail.Location = new System.Drawing.Point(9, 122);
			this.lblEMail.Name = "lblEMail";
			this.lblEMail.Size = new System.Drawing.Size(80, 13);
			this.lblEMail.TabIndex = 0;
			this.lblEMail.Text = "E-Mail Address:";
			// 
			// lblKey
			// 
			this.lblKey.AutoSize = true;
			this.lblKey.Location = new System.Drawing.Point(9, 161);
			this.lblKey.Name = "lblKey";
			this.lblKey.Size = new System.Drawing.Size(81, 13);
			this.lblKey.TabIndex = 0;
			this.lblKey.Text = "Generated Key:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pictureBox1.Image = global::CWProductProtectionKeyGen.Properties.Resources.logo;
			this.pictureBox1.Location = new System.Drawing.Point(269, 22);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(120, 107);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// cwKeyGenMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 206);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblKey);
			this.Controls.Add(this.lblEMail);
			this.Controls.Add(this.lblPhone);
			this.Controls.Add(this.lblLast);
			this.Controls.Add(this.lblFirst);
			this.Controls.Add(this.txtKey);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtPhone);
			this.Controls.Add(this.txtLName);
			this.Controls.Add(this.txtFName);
			this.Controls.Add(this.cmdGenKey);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "cwKeyGenMainForm";
			this.Text = "Caseware Product Activation DEMO: Key Generator";
			this.Load += new System.EventHandler(this.cwKeyGenMainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cmdGenKey;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Label lblFirst;
		private System.Windows.Forms.Label lblLast;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label lblEMail;
		private System.Windows.Forms.Label lblKey;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

