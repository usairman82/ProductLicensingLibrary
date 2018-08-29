namespace CWProductProtectionDEMO
{
	partial class RegistrationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblKey = new System.Windows.Forms.Label();
			this.lblEMail = new System.Windows.Forms.Label();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblLast = new System.Windows.Forms.Label();
			this.lblFirst = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtLName = new System.Windows.Forms.TextBox();
			this.txtFName = new System.Windows.Forms.TextBox();
			this.cmdGenKey = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pictureBox1.Image = global::CWProductProtectionDEMO.Properties.Resources.logo;
			this.pictureBox1.Location = new System.Drawing.Point(269, 26);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(120, 107);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 20;
			this.pictureBox1.TabStop = false;
			// 
			// lblKey
			// 
			this.lblKey.AutoSize = true;
			this.lblKey.Location = new System.Drawing.Point(9, 165);
			this.lblKey.Name = "lblKey";
			this.lblKey.Size = new System.Drawing.Size(78, 13);
			this.lblKey.TabIndex = 16;
			this.lblKey.Text = "Activation Key:";
			// 
			// lblEMail
			// 
			this.lblEMail.AutoSize = true;
			this.lblEMail.Location = new System.Drawing.Point(9, 126);
			this.lblEMail.Name = "lblEMail";
			this.lblEMail.Size = new System.Drawing.Size(80, 13);
			this.lblEMail.TabIndex = 15;
			this.lblEMail.Text = "E-Mail Address:";
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new System.Drawing.Point(8, 88);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(81, 13);
			this.lblPhone.TabIndex = 17;
			this.lblPhone.Text = "Phone Number:";
			// 
			// lblLast
			// 
			this.lblLast.AutoSize = true;
			this.lblLast.Location = new System.Drawing.Point(8, 49);
			this.lblLast.Name = "lblLast";
			this.lblLast.Size = new System.Drawing.Size(61, 13);
			this.lblLast.TabIndex = 19;
			this.lblLast.Text = "Last Name:";
			// 
			// lblFirst
			// 
			this.lblFirst.AutoSize = true;
			this.lblFirst.Location = new System.Drawing.Point(9, 10);
			this.lblFirst.Name = "lblFirst";
			this.lblFirst.Size = new System.Drawing.Size(60, 13);
			this.lblFirst.TabIndex = 18;
			this.lblFirst.Text = "First Name:";
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(11, 181);
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(378, 20);
			this.txtKey.TabIndex = 14;
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(12, 142);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(249, 20);
			this.txtEmail.TabIndex = 12;
			this.txtEmail.Text = "cessnuncaseyb@casewarecomputers.com";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(12, 104);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(249, 20);
			this.txtPhone.TabIndex = 13;
			this.txtPhone.Text = "1(541)740-3888";
			// 
			// txtLName
			// 
			this.txtLName.Location = new System.Drawing.Point(12, 65);
			this.txtLName.Name = "txtLName";
			this.txtLName.Size = new System.Drawing.Size(249, 20);
			this.txtLName.TabIndex = 10;
			this.txtLName.Text = "Cessnun";
			// 
			// txtFName
			// 
			this.txtFName.Location = new System.Drawing.Point(12, 26);
			this.txtFName.Name = "txtFName";
			this.txtFName.Size = new System.Drawing.Size(249, 20);
			this.txtFName.TabIndex = 11;
			this.txtFName.Text = "Casey";
			// 
			// cmdGenKey
			// 
			this.cmdGenKey.Location = new System.Drawing.Point(267, 139);
			this.cmdGenKey.Name = "cmdGenKey";
			this.cmdGenKey.Size = new System.Drawing.Size(122, 23);
			this.cmdGenKey.TabIndex = 9;
			this.cmdGenKey.Text = "Activate";
			this.cmdGenKey.UseVisualStyleBackColor = true;
			this.cmdGenKey.Click += new System.EventHandler(this.cmdGenKey_Click);
			// 
			// RegistrationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 214);
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
			this.Name = "RegistrationForm";
			this.Text = "RegistrationForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblKey;
		private System.Windows.Forms.Label lblEMail;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label lblLast;
		private System.Windows.Forms.Label lblFirst;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtLName;
		private System.Windows.Forms.TextBox txtFName;
		private System.Windows.Forms.Button cmdGenKey;
	}
}