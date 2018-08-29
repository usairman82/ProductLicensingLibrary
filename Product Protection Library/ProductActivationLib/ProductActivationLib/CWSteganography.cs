using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace CWActivationLibrary
{
	public class CWSteganography
	{

		/// <summary>
		/// Store a binary file in the end of another binary file. 
		/// Appends the length of the embedded object as a series of 4 bytes
		/// at the very end.
		/// </summary>
		/// <param name="sourceFile"></param>
		/// <param name="destFile"></param>
		public void SteganPersist(byte[] data,String destFile)
		{
		
			FileInfo  destFileInfo = new FileInfo(destFile);
			DateTime  destFileLastMod = destFileInfo.LastWriteTime;
			DateTime  destFileCreated= destFileInfo.CreationTime;

			MemoryStream	objStream		 = new MemoryStream();
			Stream			sourceStream	 = File.Open(destFile,FileMode.Open,FileAccess.ReadWrite);
			Int32			objectSize       = 0;
			Int32			originalSize     = 0;
			byte[]			objectSizeBuffer = new byte[4];
			byte[]          objectBuffer;
			byte[]			buffer;
			String			sObjectSize		 = "";

			//Read The Four Byte Object Size
			sourceStream.Position = sourceStream.Length - 4;
			
			sourceStream.Read(objectSizeBuffer,0,4);

			sObjectSize = Encoding.ASCII.GetString(objectSizeBuffer);

			//If the string starts with a 0 the object is less than a KB
			if (sObjectSize.StartsWith("0"))
			{
				//Strip off the 0 to leave us with the size in bytes.
				sObjectSize = sObjectSize.Substring(1,sObjectSize.Length -1);
			}

			//Convert to an integer.
			objectSize			  =	 Convert.ToInt32(sObjectSize);
			originalSize          = (Int32)((sourceStream.Length - 4)-objectSize);
			//sourceStream.Position = (long)((sourceStream.Length - 4)-objectSize);
			
			sourceStream.Position = 0; //Set to beginning of file.

			buffer = new byte[originalSize+data.Length+4]; //Get a Buffer Large Enough To Hold The Original File Data.
			
			sourceStream.Read(buffer,0,originalSize);

			Buffer.BlockCopy(data,0,buffer,originalSize,data.Length);
			
			//Prepare the new size data to be stored in the tail end of the file.
			if (data.Length < 1024)
			{
				objectSizeBuffer =  Encoding.ASCII.GetBytes("0"+data.Length.ToString());
			}
			else
			{
				objectSizeBuffer =  Encoding.ASCII.GetBytes(data.Length.ToString());
			}
			
			//By this point the buffer should be complete and ready to be written.
			Buffer.BlockCopy(objectSizeBuffer,0,buffer,originalSize+data.Length,objectSizeBuffer.Length);

			//objectBuffer = new byte[objectSize];
			//sourceStream.Read(objectBuffer,0,objectSize);
			//objStream.Write(objectBuffer,0,objectSize);
			
			sourceStream.Close();
			//Eradicate the old file.
			File.Delete(destFile);

			//Rebuild it a new.
			sourceStream = File.Open(destFile,FileMode.Create,FileAccess.Write);
			sourceStream.Write(buffer,0,buffer.Length);
			sourceStream.Close();

			//Make it look like nothing every happened.
			//destFileInfo = new FileInfo(destFile);
			destFileInfo.LastWriteTime = destFileLastMod;
			destFileInfo.CreationTime  = destFileCreated;
			//return objectBuffer;

		}

		/// <summary>
		/// Load the object that was hidden in the tail of the other binary file.
		/// </summary>
		/// <param name="sourceFile"></param>
		/// <returns></returns>
		public byte[] LoadSteganonographedFile(String sourceFile)
		{

			MemoryStream	objStream		 = new MemoryStream();
			Stream			sourceStream	 = File.Open(sourceFile,FileMode.Open);
			Int32			objectSize       = 0;
			byte[]			objectSizeBuffer = new byte[4];
			byte[]          objectBuffer;
			String			sObjectSize		 = "";

			//Read The Four Byte Object Size
			sourceStream.Position = sourceStream.Length - 4;
			
			sourceStream.Read(objectSizeBuffer,0,4);

			sObjectSize = Encoding.ASCII.GetString(objectSizeBuffer);

			if (sObjectSize.StartsWith("0"))
			{
				sObjectSize = sObjectSize.Substring(1,sObjectSize.Length -1);
			}
			objectSize			  = Convert.ToInt32(sObjectSize);
			sourceStream.Position = (long)((sourceStream.Length - 4)-objectSize);
			
			objectBuffer = new byte[objectSize];
			sourceStream.Read(objectBuffer,0,objectSize);
			objStream.Write(objectBuffer,0,objectSize);
			sourceStream.Close();
			return objectBuffer;

		}

		/// <summary>
		/// Store a binary file in the end of another binary file.
		/// Appends the length of the embedded object as a series of 4 bytes
		/// at the very end.
		/// </summary>
		/// <param name="sourceFile"></param>
		/// <param name="destFile"></param>
		public void AppendBinaryFileToBinaryFile(String sourceFile,String destFile)
		{
			byte[] buffer;

			FileInfo  destFileInfo = new FileInfo(destFile);
			DateTime  destFileLastMod = destFileInfo.LastWriteTime;
			Stream inputFile = File.Open(sourceFile,FileMode.Open,FileAccess.Read);
			Stream outputFile = File.Open(destFile,FileMode.Append,FileAccess.Write);
			
			buffer = new byte[inputFile.Length];
			inputFile.Read(buffer,0,(int)inputFile.Length);
			try
			{
				outputFile.Write(buffer,0,(int)buffer.Length);
			}
			catch(Exception ex)
			{
				int i = 0;
			}
			
			byte[] objectSize;
			if (buffer.Length < 1024)
			{
				objectSize =  Encoding.ASCII.GetBytes("0"+buffer.Length.ToString());
			}
			else
			{
				objectSize =  Encoding.ASCII.GetBytes(buffer.Length.ToString());
			}
			outputFile.Write(objectSize,0,(int)objectSize.Length);

			outputFile.Close();
			inputFile.Close();
			destFileInfo.LastWriteTime = destFileLastMod;

		}

	}
}
