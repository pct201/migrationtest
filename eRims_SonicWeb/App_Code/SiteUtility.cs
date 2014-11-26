using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net.Mail;
/// <summary>
/// Summary description for SiteUtility
/// </summary>
public class SiteUtility
{
    #region "Variables"
    
    /*Pls. do not modify this code else no user would be able to login*/
    private static byte[] m_Key = new byte[8];
    private static byte[] m_IV = new byte[8];
    private static string encdecKey = "C5F1433A-AC99-4650-ABE8-34B6D65447A0";
    /*Pls. do not modify this code else no user would be able to login*/
    #endregion

    public SiteUtility(){}

    
    #region "Encryption / Decryption"
    /// <summary>
    /// Used to Encrypt a data
    /// </summary>
    /// <param name="strData">Data that re requie to  encrypt</param>
    /// <returns></returns>
    public static string EncryptData(String strData)
    {
        String strKey = encdecKey;

        string strResult;		//Return Result

        //1. String Length cannot exceed 90Kb. Otherwise, buffer will overflow. See point 3 for reasons
        if (strData.Length > 92160)
        {
            strResult = "Error. Data String too large. Keep within 90Kb.";
            return strResult;
        }

        //2. Generate the Keys
        if (!InitKey(strKey))
        {
            strResult = "Error. Fail to generate key for encryption";
            return strResult;
        }

        //3. Prepare the String
        //	The first 5 character of the string is formatted to store the actual length of the data.
        //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
        //	If anyone figure a good way to 'remember' the original length to facilite the decryption without having to use additional function parameters, pls let me know.
        strData = String.Format("{0,5:00000}" + strData, strData.Length);


        //4. Encrypt the Data
        byte[] rbData = new byte[strData.Length];
        ASCIIEncoding aEnc = new ASCIIEncoding();
        aEnc.GetBytes(strData, 0, strData.Length, rbData, 0);

        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

        ICryptoTransform desEncrypt = descsp.CreateEncryptor(m_Key, m_IV);


        //5. Perpare the streams:
        //	mOut is the output stream. 
        //	mStream is the input stream.
        //	cs is the transformation stream.
        MemoryStream mStream = new MemoryStream(rbData);
        CryptoStream cs = new CryptoStream(mStream, desEncrypt, CryptoStreamMode.Read);
        MemoryStream mOut = new MemoryStream();

        //6. Start performing the encryption
        int bytesRead;
        byte[] output = new byte[1024];
        do
        {
            bytesRead = cs.Read(output, 0, 1024);
            if (bytesRead != 0)
                mOut.Write(output, 0, bytesRead);
        } while (bytesRead > 0);

        //7. Returns the encrypted result after it is base64 encoded
        //	In this case, the actual result is converted to base64 so that it can be transported over the HTTP protocol without deformation.
        if (mOut.Length == 0)
            strResult = "";
        else
            strResult = Convert.ToBase64String(mOut.GetBuffer(), 0, (int)mOut.Length);

        return strResult;
    }
    /// <summary>
    /// used to decrypt the data tha are encrypted
    /// </summary>
    /// <param name="strData">encrypted data</param>
    /// <returns></returns>
    public static string DecryptData(String strData)
    {
        String strKey = encdecKey;
        string strResult;

        //1. Generate the Key used for decrypting
        if (!InitKey(strKey))
        {
            strResult = "Error. Fail to generate key for decryption";
            return strResult;
        }

        //2. Initialize the service provider
        int nReturn = 0;
        DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
        ICryptoTransform desDecrypt = descsp.CreateDecryptor(m_Key, m_IV);

        //3. Prepare the streams:
        //	mOut is the output stream. 
        //	cs is the transformation stream.
        MemoryStream mOut = new MemoryStream();
        CryptoStream cs = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write);

        //4. Remember to revert the base64 encoding into a byte array to restore the original encrypted data stream
        byte[] bPlain = new byte[strData.Length];
        try
        {
            bPlain = Convert.FromBase64CharArray(strData.ToCharArray(), 0, strData.Length);
        }
        catch (Exception)
        {
            strResult = "Error. Input Data is not base64 encoded.";
            return strResult;
        }

        long lRead = 0;
        long lTotal = strData.Length;

        try
        {
            //5. Perform the actual decryption
            while (lTotal >= lRead)
            {
                cs.Write(bPlain, 0, (int)bPlain.Length);
                //descsp.BlockSize=64
                lRead = mOut.Length + Convert.ToUInt32(((bPlain.Length / descsp.BlockSize) * descsp.BlockSize));
            };

            ASCIIEncoding aEnc = new ASCIIEncoding();
            strResult = aEnc.GetString(mOut.GetBuffer(), 0, (int)mOut.Length);

            //6. Trim the string to return only the meaningful data
            //	Remember that in the encrypt function, the first 5 character holds the length of the actual data
            //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
            String strLen = strResult.Substring(0, 5);
            int nLen = Convert.ToInt32(strLen);
            strResult = strResult.Substring(5, nLen);
            nReturn = (int)mOut.Length;

            return strResult;
        }
        catch (Exception)
        {
            strResult = "Error. Decryption Failed. Possibly due to incorrect Key or corrputed data";
            return strResult;
        }
    }
    /// <summary>
    /// Initialize Key
    /// </summary>
    /// <param name="strKey"></param>
    /// <returns></returns>
    static private bool InitKey(String strKey)
    {
        try
        {
            // Convert Key to byte array
            byte[] bp = new byte[strKey.Length];
            ASCIIEncoding aEnc = new ASCIIEncoding();
            aEnc.GetBytes(strKey, 0, strKey.Length, bp, 0);

            //Hash the key using SHA1
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] bpHash = sha.ComputeHash(bp);

            int i;
            // use the low 64-bits for the key value
            for (i = 0; i < 8; i++)
                m_Key[i] = bpHash[i];

            for (i = 8; i < 16; i++)
                m_IV[i - 8] = bpHash[i];
            return true;
        }
        catch (Exception)
        {
            //Error Performing Operations
            return false;
        }
    }

    #endregion

    #region "Login"
    /// <summary>
    /// Used while login functionality.set session values according to fetched value
    /// </summary>
    /// <param name="UserName"></param>
    /// <param name="UserRole"></param>
    public static void UserLoggedIn(string UserName, string UserRole)
    {
        string[] roles = new string[2];
        roles[0] = "guests";
        roles[1] = UserRole.ToLower();

        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                        1, // Ticket version
                                        UserName, // Username associated with ticket
                                        DateTime.Now, // Date/time issued
                                        DateTime.Now.AddMinutes(double.Parse(ConfigurationManager.AppSettings["sessionTimeOut"])), // Date/time to expire
                                        false, // "true" for a persistent user cookie
                                        UserRole, // User-data, in this case the roles
                                        FormsAuthentication.FormsCookiePath);// Path cookie valid for

        // Encrypt the cookie using the machine key for secure transport
        string hash = FormsAuthentication.Encrypt(ticket);
        HttpCookie cookie = new HttpCookie(
           FormsAuthentication.FormsCookieName, // Name of auth cookie
           hash); // Hashed ticket
        HttpContext.Current.Response.Cookies.Add(cookie);
    }
    /// <summary>
    /// used to logged out.clear all sesssion
    /// </summary>
    /// <param name="UserName"></param>
    public static void UserLoggedOut(string UserName)
    {
        HttpContext.Current.Session.Abandon();               
        FormsAuthentication.SignOut();            
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }
    #endregion

    

}
