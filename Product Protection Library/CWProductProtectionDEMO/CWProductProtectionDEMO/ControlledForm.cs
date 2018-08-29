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
	public partial class ControlledForm : Form
	{
		public ControlledForm()
		{
			InitializeComponent();
		}

		private void ControlledForm_Load(object sender, EventArgs e)
		{
			CWProductProtection.IntelligentSecureControls(this);
		}
	}
}