using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security.Cryptography;
using System.Xml;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for Encryption
/// </summary>
public class Encryption
{
    #region Donot Change this variables
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static string EncryptionKey = "!5623a#de";
    #endregion

    public Encryption()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// used to Decrypt the passing String
    /// </summary>
    /// <param name="Input">Encrypted String</param>
    /// <returns></returns>
    public static string Decrypt(string Input)
    {
        Input = Input.Replace("$", "+");
        Byte[] inputByteArray = new Byte[Input.Length];
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(Input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());

        }
        catch (Exception ex)
        {
            return "";
        }

    }
    /// <summary>
    /// Used to Encrypt the Passed String
    /// </summary>
    /// <param name="Input">String for Encryption</param>
    /// <returns></returns>
    public static string Encrypt(string Input)
    {
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray()).Replace("+", "$");
        }
        catch (Exception ex)
        {
            return "";
        }


    }
}
