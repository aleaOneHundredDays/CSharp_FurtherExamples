using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionDecryption
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter text that needs to be encrypted..");
			string data = Console.ReadLine();
			EncryptAesManaged(data);
			Console.ReadLine();
		}
		static void EncryptAesManaged(string raw)
		{
			try
			{
				// Create Aes that generates a new key and initialization vector (IV).    
				// Same key must be used in encryption and decryption    
				using (AesManaged aes = new AesManaged())
				{
					// Encrypt string    
					byte[] encrypted = Encrypt(raw, aes.Key, aes.IV);
					// Print encrypted string    
					Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
					// Decrypt the bytes to a string.    
					string decrypted = Decrypt(encrypted, aes.Key, aes.IV);
					// Print decrypted string. It should be same as raw data    
					Console.WriteLine($"Decrypted data: {decrypted}");
				}
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}
			Console.ReadKey();
		}
		static byte[] Encrypt(string plainText, byte[] Key, byte[] IV)
		{
			byte[] encrypted;
			// Create a new AesManaged.    
			using (AesManaged aes = new AesManaged())
			{
				// Create encryptor    
				ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
				// Create MemoryStream    
				using (MemoryStream ms = new MemoryStream())
				{
					// Create crypto stream using the CryptoStream class. This class is the key to encryption    
					// and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
					// to encrypt    
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						// Create StreamWriter and write data to a stream    
						using (StreamWriter sw = new StreamWriter(cs))
							sw.Write(plainText);
						encrypted = ms.ToArray();
					}
				}
			}
			// Return encrypted data    
			return encrypted;
		}
		static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
		{
			string plaintext = null;
			// Create AesManaged    
			using (AesManaged aes = new AesManaged())
			{
				// Create a decryptor    
				ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
				// Create the streams used for decryption.    
				using (MemoryStream ms = new MemoryStream(cipherText))
				{
					// Create crypto stream    
					using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						// Read crypto stream    
						using (StreamReader reader = new StreamReader(cs))
							plaintext = reader.ReadToEnd();
					}
				}
			}
			return plaintext;
		}
		//// declaring key
		//var key = "b14ca5898a4e4133bbce2ea2315a1916";

		//// encrypt parameters
		//var input = string.Concat("https://myDomain.in/", "Encrypt.aspx?query=", EncryptString(key, string.Format("emailID={0}", "myemail@gmail.com")));

		//Console.WriteLine("Encrypted Input: " + input);

		//// decrypt parameters
		//var decrptedInput = DecryptString(key, input.Substring(input.IndexOf("=") + 1));
		//Console.WriteLine("Decrypted Input: " + decrptedInput);
	}

		//public static string EncryptString(string key, string plainInput)
		//{
		//	byte[] iv = new byte[16];
		//	byte[] array;
		//	using (Aes aes = Aes.Create())
		//	{
		//		aes.Key = Encoding.UTF8.GetBytes(key);
		//		aes.IV = iv;
		//		ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
		//		using (MemoryStream memoryStream = new MemoryStream())
		//		{
		//			using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
		//			{
		//				using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
		//				{
		//					streamWriter.Write(plainInput);
		//				}

		//				array = memoryStream.ToArray();
		//			}
		//		}
		//	}

		//	return Convert.ToBase64String(array);
		//}

		//public static string DecryptString(string key, string cipherText)
		//{
		//	byte[] iv = new byte[16];
		//	byte[] buffer = Convert.FromBase64String(cipherText);
		//	using (Aes aes = Aes.Create())
		//	{
		//		aes.Key = Encoding.UTF8.GetBytes(key);
		//		aes.IV = iv;
		//		ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
		//		using (MemoryStream memoryStream = new MemoryStream(buffer))
		//		{
		//			using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
		//			{
		//				using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
		//				{
		//					return streamReader.ReadToEnd();
		//				}
		//			}
		//		}
		//	}
		//}
	}







		//    try
		//    {
		//        //Create a TCP connection to a listening TCP process.  
		//        //Use "localhost" to specify the current computer or  
		//        //replace "localhost" with the IP address of the   
		//        //listening process.    
		//        TcpClient tcp = new TcpClient("localhost", 11000);

		//        //Create a network stream from the TCP connection.   
		//        NetworkStream netStream = tcp.GetStream();

		//        //Create a new instance of the RijndaelManaged class  
		//        // and encrypt the stream.  
		//        RijndaelManaged rmCrypto = new RijndaelManaged();

		//        byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
		//        byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

		//        //Create a CryptoStream, pass it the NetworkStream, and encrypt   
		//        //it with the Rijndael class.  
		//        CryptoStream cryptStream = new CryptoStream(netStream,
		//        rmCrypto.CreateEncryptor(key, iv),
		//        CryptoStreamMode.Write);

		//        //Create a StreamWriter for easy writing to the   
		//        //network stream.  
		//        StreamWriter sWriter = new StreamWriter(cryptStream);

		//        //Write to the stream.  
		//        sWriter.WriteLine("Hello World!");

		//        //Inform the user that the message was written  
		//        //to the stream.  
		//        Console.WriteLine("The message was sent.");

		//        //Close all the connections.  
		//        sWriter.Close();
		//        cryptStream.Close();
		//        netStream.Close();
		//        tcp.Close();
		//    }

		//    catch
		//    {
		//        //Inform the user that an exception was raised.  
		//        Console.WriteLine("The connection failed.");
		//    }
	
    

