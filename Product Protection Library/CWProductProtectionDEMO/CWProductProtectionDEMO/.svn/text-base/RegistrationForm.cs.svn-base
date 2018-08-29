using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CWActivationLibrary;
using CWAuxillaryMethods;
namespace CWProductProtectionDEMO
{
	public partial class RegistrationForm : Form
	{
		public RegistrationForm()
		{
			InitializeComponent();
			if (CWProductProtection.IsProductActivated)
			{
				this.cmdGenKey.Enabled	= false;
				this.txtKey.Enabled		= false;
				this.txtFName.Enabled	= false;
				this.txtLName.Enabled	= false;
				this.txtPhone.Enabled	= false;
				this.txtEmail.Enabled	= false;
				this.txtKey.Text		= "Product Activated.";
			}
		}

		private void cmdGenKey_Click(object sender, EventArgs e)
		{
			if (!CWProductProtection.IsProductActivated)
			{
				AUXMethods tAux = new AUXMethods();

				String data = tAux.CodifyData(txtFName.Text,txtLName.Text,txtPhone.Text,txtEmail.Text);
				CWProductProtection.Activate(data,txtKey.Text);
				if (CWProductProtection.IsProductActivated)
				{
					MessageBox.Show(CWProductProtection.ACTIVATION_SUCCESS,"Activation Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
					
				}
				else
				{
					MessageBox.Show(CWProductProtection.ACTIVATION_FAILURE,"Activation Failure",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				CWProductProtection.IntelligentSecureControls(this.MdiParent);
			}

			
		}
	}
}