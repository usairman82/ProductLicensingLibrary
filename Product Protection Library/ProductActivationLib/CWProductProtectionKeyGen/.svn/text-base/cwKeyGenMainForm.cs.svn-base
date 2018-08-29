using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CWActivationLibrary;
using CWAuxillaryMethods;
namespace CWProductProtectionKeyGen
{
	public partial class cwKeyGenMainForm : Form
	{
		public cwKeyGenMainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//Data must be formatted in the same manner as it is 
			//in the key generator.
			AUXMethods tAux = new AUXMethods();

			String data = tAux.CodifyData(txtFName.Text,txtLName.Text,txtPhone.Text,txtEmail.Text);
			CWActivationKeyGenerator temp = new CWActivationKeyGenerator();
			txtKey.Text = temp.GenerateActivationKey(data);
		}

		private void cwKeyGenMainForm_Load(object sender, EventArgs e)
		{

		}
	}
}