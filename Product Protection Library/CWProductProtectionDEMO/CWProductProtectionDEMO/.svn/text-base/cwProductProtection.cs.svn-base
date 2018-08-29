using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CWActivationLibrary;

namespace CWProductProtectionDEMO
{
	public partial class frmCWProtectionTestMain : Form
	{
		public frmCWProtectionTestMain()
		{
			InitializeComponent();
			CWProductProtection.AddControlledObject("ControlledForm");
			//CWProductProtection.AddControlledObject("controlledFormToolStripMenuItem");
			CWProductProtection.AddControlledObject("controlledItem2ToolStripMenuItem");
			//CWProductProtection.AddControlledObject("controlledDD1ToolStripMenuItem");
			CWProductProtection.AddControlledObject("controlledSubItemToolStripMenuItem");
			CWProductProtection.AddControlledObject("cmdButton1");
			
			this.Text += "Activation Count:"+CWProductProtection.GetNumberOfActivations().ToString();
			if (CWProductProtection.IsProductActivated == false && CWProductProtection.HasEvaluationPeriodExpired)
			{
				CWProductProtection.IntelligentSecureControls(this);				

				MessageBox.Show("Your product trial period has expired!  Please register and activate your product to continue use.","Trial Period Expired.",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}


		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutCwProductProtectionTest aboutForm = new AboutCwProductProtectionTest();
			aboutForm.ShowDialog();
		}

		/// <summary>
		/// Quit The Application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void frmCWProtectionTestMain_Load(object sender, EventArgs e)
		{
		
		}

		private void controlledFormToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void uncontrolledFormToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UncontrolledForm uForm = new UncontrolledForm();
			uForm.MdiParent= this;
			uForm.Show();
		}

		private void controlledItem2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ControlledForm cForm = new ControlledForm();
			cForm.MdiParent= this;
			cForm.Show();
		}

		private void controlledDD1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ControlledForm cForm = new ControlledForm();
			cForm.MdiParent= this;
			cForm.Show();
		}

		private void registerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RegistrationForm tReg = new RegistrationForm();
			tReg.MdiParent = this;
			tReg.Show();
		}
	}
}