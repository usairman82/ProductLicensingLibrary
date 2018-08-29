using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CWActivationLibrary;
using System.IO;

namespace CWProductProtectionCP
{
	public partial class frmControlPanel : Form
	{
		public frmControlPanel()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			findLogoFileDialog.ShowDialog();
			pbLogo.Load(findLogoFileDialog.FileName);
		}

		private void btnEmbedPersistedObject_Click(object sender, EventArgs e)
		{
			PeriodType			type = PeriodType.DAYS;
			CWSteganography		cwStegan = new CWSteganography();	
			
		
			switch (cbPeriodType.SelectedItem.ToString())
			{
				case "HOURS":
					type = PeriodType.HOURS;
					break;
				case "DAYS":
					type = PeriodType.DAYS;
					break;
				case "MONTHS":
					type = PeriodType.MONTHS;
					break;
				case "ACTIVATIONS":
					type = PeriodType.ACTIVATIONS;
					break;
				default:
					type = PeriodType.DAYS;
					break;
			}
			//Initilize The Object With Basic Information.
			CWProductProtection.Initilize(@".\Temp.po",0,txtPackageName.Text,DateTime.Now,Convert.ToInt32(txtTrialPeriod.Text),type);
			cwStegan.AppendBinaryFileToBinaryFile(@".\Temp.po",findLogoFileDialog.FileName);
			File.Delete(@".\Temp.po");
		}

		private void frmControlPanel_Load(object sender, EventArgs e)
		{

		}
	}
}