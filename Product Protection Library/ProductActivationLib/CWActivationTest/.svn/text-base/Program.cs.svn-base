using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CWActivationLibrary;

namespace CWActivationTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String mFileName = @".\Persist.fl";

			//First Type To Load The Persisted Object
			//If That Fails, Create A New One With Default Values.
			CWProductProtection.Initilize(); //(mFileName,0,"TestPackage",DateTime.Now,5,PeriodType.ACTIVATIONS);
			

			

            if (CWProductProtection.HasEvaluationPeriodExpired && !CWProductProtection.IsProductActivated)
            {
                MessageBox.Show("Your Trial Period Has Ended.  Please Register Your Product.To Continue Use.");
            }

            Application.Run(new Form1());
        }
    }
}