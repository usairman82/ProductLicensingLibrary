using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CWActivationLibrary;
namespace CWProductProtectionDEMO
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CWProductProtection.Initilize();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmCWProtectionTestMain());
		}
	}
}