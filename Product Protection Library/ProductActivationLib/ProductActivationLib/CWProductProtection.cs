using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace CWActivationLibrary
{
    static public class CWProductProtection
    {
		static			private				String				m_FileName;
        static			private				CWActivation		cwActivation;
		static			private				String				m_enck;
		static			private				String				m_enckiv;
		static			private				GCHandle			gcHandleenck;
		static			private				GCHandle			gcHandleenckiv;
		static			private				CWSteganography		cwStegan;
		static			private				bool				m_IsStegan;
	    				public		const	string				ACTIVATION_SUCCESS = "Your product has been successfully activated."; 
						public		const	string				ACTIVATION_FAILURE = "Activation of your product has failed. Ensure all information your provided is entered exactly as your provided it during registration and try again.  If activation continues to fail please contact customer support."; 		
		static			private				bool				m_ControlsLocked;
		//static private String       m_RandomNumberSeedValue
		//To Do
		[System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint="RtlZeroMemory")]
		private static extern bool ZeroMemory(ref string Destination, int Length);
		
		/// <summary>
		/// Because we are using encryption be sure to flush memory afterwards.
		/// </summary>
		static public void Flush()
		{
			ZeroMemory(ref m_enck, m_enck.Length * 2);
			gcHandleenck.Free();

			ZeroMemory(ref m_enckiv, m_enckiv.Length * 2);
			gcHandleenckiv.Free();
			
		}

		static CWProductProtection()
		{
			gcHandleenck   = GCHandle.Alloc( m_enck,GCHandleType.Pinned );
			gcHandleenckiv = GCHandle.Alloc( m_enckiv,GCHandleType.Pinned );
			cwStegan	   = new CWSteganography();
			m_FileName = "";
			//m_enck = "7#;t^:SY]-k VFV=1t/;6LjCa*D'H";
			m_enck   = "X<cK%3 &";//A:'H4$~U"; //"X<cK%3 &A:'H4$~U]^";
			//m_enckiv = "7#;t^:SY"; //]-k VFV=1t/;6LjC";
			cwActivation = new CWActivation();
			m_IsStegan = false;
			m_ControlsLocked = false;
		}

		/// <summary>
		/// The two InitActivationObject methods are to be used
		/// once the object has previously been persisted.
		/// In reallity this will be every time
		/// Since the product will ship with an
		/// already persisted object. ---True Statement.  The Only Object that will need to me updated
		/// will be the TrialBegin Time.
		/// ---
		/// Future modification TO DO: Make The File Consistantly Logo.jpg which
		/// will contain the companies LOGO with the persisted object hidden encrypted inside.
		/// Steganography.
		/// i.e. See CWSteganography Library.
		/// </summary>
		/// <returns></returns>
		static public bool Initilize(String privateFileName)
		{
		   m_FileName = privateFileName;
		   return InitActivationObject();
		}

		static public void AddControlledObject(String objectName)
		{
			cwActivation.AddControlledObject(objectName);
		}

		static public bool IsObjectControlled(String objectName)
		{
			return cwActivation.IsObjectControlled(objectName);
		}

		/// <summary>
		/// The two InitActivationObject methods are to be used
		/// once the object has previously been persisted.
		/// In reallity this will be every time
		/// Since the product will ship with an
		/// already persisted object. ---True Statement.  The Only Object that will need to me updated
		/// will be the TrialBegin Time.
		/// ---
		/// Future modification TO DO: Make The File Consistantly Logo.jpg which
		/// will contain the companies LOGO with the persisted object hidden encrypted inside.
		/// Steganography.
		/// i.e. See CWSteganography Library.
		/// ***Stegan Version***
		/// </summary>
		/// <requirement>Must have a file named LOGO.jpg</requirement>
		/// <returns></returns>
		static public bool Initilize()
		{
		   m_IsStegan = true;
		   m_FileName = @".\Logo.jpg";
		   return InitSteganActivationObject();
		}

		/// <summary>
		/// Secures or unsecures a forms controls based off of
		/// whether or not the product is activated.
		/// </summary>
		/// <param name="formToSecure"></param>
		static public void IntelligentSecureControls(System.Windows.Forms.Form formToSecure)
		{
			if (cwActivation.IsProductActivated)
			{
				UnSecureControls(formToSecure);
			}
			else
			{
				SecureControls(formToSecure);
			}
		}
		/// <summary>
		/// Secure all controlled controls.
		/// It is left up to the user to determine when
		/// to call this method.
		/// </summary>
		/// <param name="formToSecure"></param>
		static public void SecureControls(System.Windows.Forms.Form formToSecure)
		{
			SecureControls(formToSecure,false);
			m_ControlsLocked = true;
		}

		/// <summary>
		/// Secure all controlled controls.
		/// It is left up to the user to determine when
		/// to call this method.
		/// </summary>
		/// <param name="formToSecure"></param>
		static public void UnSecureControls(System.Windows.Forms.Form formToSecure)
		{
			SecureControls(formToSecure,true);
			m_ControlsLocked = false;
		}
		/// <summary>
		/// Secure all controlled controls.
		/// It is left up to the user to determine when
		/// to call this method.
		/// </summary>
		/// <param name="formToSecure"></param>
		static private void SecureControls(System.Windows.Forms.Form formToSecure, bool securityState)
		{
			foreach(Control control in formToSecure.Controls)
			{
				if (CWProductProtection.IsObjectControlled(control.Name))
				{
					control.Enabled = securityState;
				}
				
				
				if (control.Enabled && control.GetType() == typeof(System.Windows.Forms.MenuStrip))
				{

					foreach(ToolStripMenuItem menuItem in ((MenuStrip)control).Items)
					{
					
						SecureMenuStrip(menuItem,securityState);
					}
				}
			}
		}

		#region "Secure Menu Strips And Sub Items"
		static private void SecureMenuStrip(System.Windows.Forms.ToolStripMenuItem menuStrip,bool securityState)
		{
			foreach(ToolStripMenuItem item in menuStrip.DropDownItems)
			{
				if (item.HasDropDownItems)
				{
					SecureToolStripDropDownItems(item,securityState);
				}
				if (CWProductProtection.IsObjectControlled(item.Name))
				{
					item.Enabled = securityState;
				}
			}
		}

		static private void SecureToolStripDropDownItems(System.Windows.Forms.ToolStripMenuItem menuStrip, bool securityState)
		{
			foreach(ToolStripMenuItem item in menuStrip.DropDownItems)
			{
				if (item.HasDropDownItems)
				{
					SecureToolStripDropDownItems(item,securityState);
				}
				if (CWProductProtection.IsObjectControlled(item.Name))
				{
					item.Enabled = securityState;
				}
			}
		}
		#endregion

		static public Int32 GetNumberOfActivations()
		{
			return cwActivation.ActivationCount;
		}
		/// <summary>
		/// Initilize the cwactivation object.  This overload includes a list of object to control.
		/// </summary>
		/// <param name="privateFileName"></param>
		/// <param name="activationCount"></param>
		/// <param name="packageName"></param>
		/// <param name="trialBegin"></param>
		/// <param name="trialPeriod"></param>
		/// <param name="periodType"></param>
		/// <param name="objectsToSecure"></param>
		/// <returns>Does not return any value</returns>
		static public void Initilize(String privateFileName,
									 Int32 activationCount,
									 String packageName,
									 DateTime trialBegin,
									 Int32 trialPeriod,
									 PeriodType periodType,
									 List<String> objectsToSecure)
		{
			m_FileName = privateFileName;

			if (!InitActivationObject())
			{
				InitCommonDataMembers(activationCount, packageName, trialBegin, trialPeriod, periodType);
				foreach(String obj in objectsToSecure)
				{
					CWProductProtection.cwActivation.AddControlledObject(obj);
				}
				CWProductProtection.Persist(); //Save it.
			}
		}

		/// <summary>
		/// Initilize the cwactivation object.  This overload does no includes a list of object to control.
		/// </summary>
		/// <param name="privateFileName"></param>
		/// <param name="activationCount"></param>
		/// <param name="packageName"></param>
		/// <param name="trialBegin"></param>
		/// <param name="trialPeriod"></param>
		/// <param name="periodType"></param>
		/// <param name="objectsToSecure"></param>
		/// <returns></returns>
		static public void Initilize(String privateFileName,
					 Int32 activationCount,
					 String packageName,
					 DateTime trialBegin,
					 Int32 trialPeriod,
					 PeriodType periodType)
		{
			m_FileName = privateFileName;

			if (!InitActivationObject())
			{
				InitCommonDataMembers(activationCount, packageName, trialBegin, trialPeriod, periodType);
				CWProductProtection.Persist(); //Save it.
			}
		}

		/// <summary>
		/// Common functionality between initilization methods.
		/// </summary>
		/// <param name="activationCount"></param>
		/// <param name="packageName"></param>
		/// <param name="trialBegin"></param>
		/// <param name="trialPeriod"></param>
		/// <param name="periodType"></param>
		private static void InitCommonDataMembers(Int32 activationCount, String packageName, DateTime trialBegin, Int32 trialPeriod, PeriodType periodType)
		{
			CWProductProtection.cwActivation.ActivationCount = activationCount;
			CWProductProtection.cwActivation.PackageName = packageName;
			//CWProductProtection.cwActivation.ProductActivationCode = "";
			CWProductProtection.cwActivation.TrialBeginDate = trialBegin;
			CWProductProtection.cwActivation.TrialPeriod = trialPeriod;
			CWProductProtection.cwActivation.TrialPeriodType = periodType;
			CWProductProtection.cwActivation.MachineName     = "";
		}


		/// <summary>
		/// First Try To Load The Persisted Object.
		/// If It Does Not Exist, Or The FileName Of The Object Has Not Yet Been Set
		/// Generate A New CWActivation Object.
		/// </summary>
		/// <returns></returns>
		static private bool InitActivationObject()
		{
			if (m_FileName.Length > 0)
			{
				return Load();
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// First Try To Load The Persisted Object.
		/// If It Does Not Exist, Or The FileName Of The Object Has Not Yet Been Set
		/// Generate A New CWActivation Object.
		/// Stegan Version
		/// </summary>
		/// <returns></returns>
		static private bool InitSteganActivationObject()
		{
			if (m_FileName.Length > 0)
			{
				return LoadStegan();
			}
			else
			{
				return false;
			}
		}

		static public bool HasEvaluationPeriodExpired
		{
			get
			{
				return cwActivation.HasTrialPeriodElapsed();
			}
		}

		static public bool IsProductActivated
		{
			get
			{
				return cwActivation.IsProductActivated;
			}
		}

		/// <summary>
		/// Used ToAttempt To Activate The Product.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="sActivationCode"></param>
		/// <returns></returns>
		static public bool Activate(String data,String sActivationCode)
		{
			bool   retVal = false;

			cwActivation.ProductActivationCode = sActivationCode;
			retVal = cwActivation.VerifyActivationCode(data);
			if (retVal)
			{
				if (m_IsStegan)
				{
					PersistStegan();
				}
				else
				{
					Persist();
				}
			}
			return retVal;
		}



		/// <summary>
		/// Set the name for the persisted file.
		/// </summary>
		/// <param name="privateFileName"></param>
		static public void SetPrivateFileName(String privateFileName)
		{
			m_FileName = privateFileName;
		}

		
		/// <summary>
		/// Load The Encrypted Persisted cwActivation Object
		/// </summary>
		/// <returns></returns>
		static private bool LoadStegan()
		{

			bool retValue = false;
			int i = 0;
			//byte[] fileContents;
			byte[]	fileContents;
					fileContents	= cwStegan.LoadSteganonographedFile(m_FileName);
			try
			{
				//FileStream						inputStream		= File.Open(m_FileName, FileMode.Open,FileAccess.Read);

				BinaryFormatter					binaryFormatter = new BinaryFormatter();
				DESCryptoServiceProvider		DES				= new DESCryptoServiceProvider();
				StreamReader					sr;

				//A 64 bit key and IV is required for this provider.
				//Set secret key For DES algorithm.
				DES.Key = ASCIIEncoding.ASCII.GetBytes(m_enck);
				//Set initialization vector.

				DES.IV = ASCIIEncoding.ASCII.GetBytes(m_enck);

				//Create a DES decryptor from the DES instance.
				ICryptoTransform desdecrypt = DES.CreateDecryptor();
				//Create crypto stream set to read and do a 
				//DES decryption transform on incoming bytes.
	
				//Print the contents of the decrypted file.
				//fileContents = new byte[iobjectStream.Length];
				//iobjectStream.Read(fileContents,0,(int)iobjectStream.Length);
				MemoryStream objectStream = new MemoryStream((int)fileContents.Length);
				CryptoStream cryptostreamDecr = new CryptoStream(objectStream, 
				                                 desdecrypt,
				                                 CryptoStreamMode.Write);

				cryptostreamDecr.Write(fileContents,0,(int)fileContents.Length);
				cryptostreamDecr.FlushFinalBlock();

				objectStream.Position = 0; //Rewind the memory stream.
				cwActivation = (CWActivation)binaryFormatter.Deserialize(objectStream);
				//Clean Up;
				cryptostreamDecr.Close();
				objectStream.Close();
				//Clear Input Stream.
				//inputStream.Flush();
				//objectStream.Close();
				retValue = true;
				PersistStegan();
			}
			catch(Exception exe)
			{
				String temp = exe.Message;
			}
			finally
			{
			}
			return retValue;
		}

		/// <summary>
		/// Load The Encrypted Persisted cwActivation Object
		/// </summary>
		/// <returns></returns>
		static private bool Load()
		{

			bool retValue = false;
			int i = 0;
			byte[] fileContents;
			try
			{
				FileStream						inputStream		= File.Open(m_FileName, FileMode.Open,FileAccess.Read);
				MemoryStream					objectStream    =  new MemoryStream();
				BinaryFormatter					binaryFormatter = new BinaryFormatter();
				DESCryptoServiceProvider		DES				= new DESCryptoServiceProvider();
				StreamReader					sr;

				//A 64 bit key and IV is required for this provider.
				//Set secret key For DES algorithm.
				DES.Key = ASCIIEncoding.ASCII.GetBytes(m_enck);
				//Set initialization vector.

				DES.IV = ASCIIEncoding.ASCII.GetBytes(m_enck);

				//Create a DES decryptor from the DES instance.
				ICryptoTransform desdecrypt = DES.CreateDecryptor();
				//Create crypto stream set to read and do a 
				//DES decryption transform on incoming bytes.
	
				//Print the contents of the decrypted file.
				fileContents = new byte[inputStream.Length];
				inputStream.Read(fileContents,0,(int)inputStream.Length);
				objectStream = new MemoryStream((int)inputStream.Length);
				CryptoStream cryptostreamDecr = new CryptoStream(objectStream, 
												 desdecrypt,
												 CryptoStreamMode.Write);

				cryptostreamDecr.Write(fileContents,0,(int)fileContents.Length);
				cryptostreamDecr.FlushFinalBlock();

				objectStream.Position = 0; //Rewind the memory stream.
				cwActivation = (CWActivation)binaryFormatter.Deserialize(objectStream);
				//Clean Up;
				cryptostreamDecr.Close();
				objectStream.Close();
				//Clear Input Stream.
				inputStream.Flush();
				inputStream.Close();
				retValue = true;
				Persist();
			}
			catch(Exception exe)
			{
				String temp = exe.Message;
			}
			finally
			{
			}
			return retValue;
		}

				/// <summary>
		/// Persist in an Encrypted fashion the cwActivation Object.
		/// </summary>
        static private void PersistStegan()
        {
			try
			{
			DESCryptoServiceProvider  DES						= new DESCryptoServiceProvider();
			MemoryStream			  interStream				= new MemoryStream();
			MemoryStream			  encStream					= new MemoryStream();
			DES.Key = ASCIIEncoding.ASCII.GetBytes(m_enck);
			DES.IV  = ASCIIEncoding.ASCII.GetBytes(m_enck);

			//Stream outputStream = File.Open(m_FileName, FileMode.Create);
			//Serialize to a memory stream.
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(interStream, cwActivation);

			//Encrypt the object
			ICryptoTransform desencrypt = DES.CreateEncryptor();
			CryptoStream cryptostream = new CryptoStream(encStream, 
			                                            desencrypt, 
			                                            CryptoStreamMode.Write);
			
			byte[] bytearray = new byte[interStream.Length];

			Buffer.BlockCopy(interStream.GetBuffer(),0,bytearray,0,(int)interStream.Length);
			

			cryptostream.Write(bytearray, 0, bytearray.Length);
			cryptostream.FlushFinalBlock();


			encStream.Position = 0;
			bytearray = new byte[(int)encStream.Length];
			encStream.Read(bytearray,0,bytearray.Length);
			cwStegan.SteganPersist(bytearray,m_FileName);

			//Clean Up.
			cryptostream.Close();
			//outputStream.Close();
			}
			catch(Exception ex)
			{
				int i = 0;
			}
        }

		/// <summary>
		/// Persist in an Encrypted fashion the cwActivation Object.
		/// </summary>
        static private void Persist()
        {
			DESCryptoServiceProvider  DES						= new DESCryptoServiceProvider();
			MemoryStream			  interStream				= new MemoryStream();

			DES.Key = ASCIIEncoding.ASCII.GetBytes(m_enck);
			DES.IV  = ASCIIEncoding.ASCII.GetBytes(m_enck);

			Stream outputStream = File.Open(m_FileName, FileMode.Create);
			//Serialize to a memory stream.
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			binaryFormatter.Serialize(interStream, cwActivation);

			//Encrypt the object
			ICryptoTransform desencrypt = DES.CreateEncryptor();
			CryptoStream cryptostream = new CryptoStream(outputStream, 
														desencrypt, 
														CryptoStreamMode.Write);
			
			byte[] bytearray = new byte[interStream.Length];

			Buffer.BlockCopy(interStream.GetBuffer(),0,bytearray,0,(int)interStream.Length);
			

			cryptostream.Write(bytearray, 0, bytearray.Length);
			cryptostream.FlushFinalBlock();

			//Clean Up.
			cryptostream.Close();
			outputStream.Close();

        }
    }
}
