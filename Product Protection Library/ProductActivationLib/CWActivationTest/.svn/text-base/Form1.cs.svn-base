using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CWActivationLibrary;
using CWAuxillaryMethods;

namespace CWActivationTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
			//CWProductProtection.Initilize();
			if (CWProductProtection.IsProductActivated)
			{
				this.Text = this.Text + "::Registered::";
			}
			else
			{
				this.Text = this.Text + "::UNRegistered::";
			}
        }

		private void button1_Click(object sender, EventArgs e)
		{
			//CWActivationLibrary.CWActivationKeyGenerator temp = new CWActivationKeyGenerator();
			//temp.GenKey();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//Data must be formatted in the same manner as it is 
			//in the key generator.
			AUXMethods tAux  = new AUXMethods();

			String data = tAux.CodifyData(txtFName.Text,txtLName.Text,txtPhone.Text,txtEmail.Text);
			CWActivationLibrary.CWActivationKeyGenerator temp = new CWActivationKeyGenerator();
			txtKey.Text = temp.GenerateActivationKey(data);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			AUXMethods tAux  = new AUXMethods();

			if (CWProductProtection.Activate(tAux.CodifyData(txtFName.Text,txtLName.Text,txtPhone.Text,txtEmail.Text),txtActivation.Text))
			{
				MessageBox.Show("Activation Successful!","Activation Successful!",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
					MessageBox.Show("Activation Failed!","Activation Failes!",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			CWSteganography temp = new CWSteganography();

			temp.AppendBinaryFileToBinaryFile(@".\Persist.fl",@".\IEEE.logosm.jpg");
		}
    }
}