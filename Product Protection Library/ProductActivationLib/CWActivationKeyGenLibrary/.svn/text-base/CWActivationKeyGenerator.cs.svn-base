using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Data;
using System.Runtime.Remoting;
using System.Reflection;
using System.IO;


namespace CWActivationLibrary
{
	public class CWActivationKeyGenerator:MarshalByRefObject
	{

		/// <summary>
		/// Generate an activation key.
		/// </summary>
		/// <param name="pData"></param>
		/// <returns></returns>
		public String GenerateActivationKey(String pData)
		{
			
			String returnData = "";
			byte[] data = Encoding.ASCII.GetBytes(pData);
			byte[] result;
			SHA1 shaM = new SHA1Managed();
			result = shaM.ComputeHash(data);
			returnData = Convert.ToBase64String(result);
			returnData = returnData.ToUpper();
			return EncodeASCIIValues(returnData);
		}

		/// <summary>
		/// Convert all non alpha numeric characters to alpha numeric characters.
		/// </summary>
		/// <param name="pData"></param>
		/// <returns></returns>
		private String EncodeASCIIValues(String pData)
		{
			String intermediateKeyValue = "";
			String finalKeyValue = "";
			Int32 blockSize = 5; //(retValue.Length % 6);
			Int32 maxKeySize = 30;

			foreach (char c in Encoding.ASCII.GetChars(Encoding.ASCII.GetBytes(pData)))
			{
				if (Char.IsSymbol(c) || Char.IsPunctuation(c) || Char.IsControl(c))
				{
					intermediateKeyValue += Convert.ToString(c + 32); 
				}
				else
				{
					intermediateKeyValue += Convert.ToString(c);
				}
			}
			
			if (intermediateKeyValue.Length < maxKeySize)
			{
				for (int i = 0; i < maxKeySize-intermediateKeyValue.Length;i++)
				{
					intermediateKeyValue+= intermediateKeyValue[i];
				}
			}
			else if (intermediateKeyValue.Length > maxKeySize)
			{
				intermediateKeyValue = intermediateKeyValue.Substring(0,maxKeySize);
			}

	
			for(int i = 0; intermediateKeyValue.Length - i >=blockSize  ;i+=blockSize)
			{
				if (i <=intermediateKeyValue.Length)
				{
					if (finalKeyValue.Length > 0)
					{
						finalKeyValue += "-";
					}
					finalKeyValue += intermediateKeyValue.Substring(i,blockSize);
				}
			}

			return finalKeyValue;
		}

		/// <summary>
		/// Generate Public Key Encryption Public And Private Key Pair.
		/// </summary>
		/// <returns></returns>
		[Obsolete]
		public String GenKey()
		{
			CspParameters cspp = new CspParameters();
			RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

			//cspp.KeyContainerName = "MyKeyPair";
			//rsa = new RSACryptoServiceProvider(cspp);
			//rsa.PersistKeyInCsp = true;
			if (rsa.PublicOnly == true)
			{
				 //label1.Text = "Key: " + cspp.KeyContainerName + " - Public Only";
			}
			else
			{
			   //label1.Text = "Key: " + cspp.KeyContainerName + " - Full Key Pair";
			}

			    Directory.CreateDirectory(@".\EncrKey");
				StreamWriter sw = new StreamWriter(@".\EncrKey\PubKey.xml", false);
				sw.Write(rsa.ToXmlString(false));
				sw.Close();
				sw = new StreamWriter(@".\EncrKey\PubPrivKey.xml", false);
				sw.Write(rsa.ToXmlString(true));
				sw.Close();
			return "";
		}
	}
}
