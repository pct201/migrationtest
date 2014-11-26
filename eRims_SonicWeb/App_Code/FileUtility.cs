using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Collections;

/// <summary>
/// Summary description for FileUtility
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class FileUtility : System.Web.Services.WebService
{

    public FileUtility()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CheckInvalidFileName(string strName)
    {
        string strErrorMsg = string.Empty;
        bool blnInvalid = true;
        string[] strFiles = Regex.Split(strName, "&~&~&;");
        string[] strFilename = Regex.Split(strFiles[0], "&~&~&");
        string[] strFileUpload = Regex.Split(strFiles[1], "&~&~&");
        for (int i = 0; i < strFilename.Length - 1; i++)
        {
            if (!string.IsNullOrEmpty(strFilename[i]))
            {
                blnInvalid = GetInvalidFileNameChars(strFilename[i]);
                if (!blnInvalid)
                {
                    strErrorMsg = "Please use only letters and numbers when saving attachments.Symbols and other characters are not allowed.";
                    return strErrorMsg;
                }
                blnInvalid = CheckRegExpression(strFilename[i], strFileUpload[i]);
                if (!blnInvalid)
                {
                    strErrorMsg = "One or more Specified file name is not allowed.";
                    return strErrorMsg;
                }
            }
        }

        if (blnInvalid) return strErrorMsg;
        return "";
    }
    private bool GetInvalidFileNameChars(string strName)
    {
        ArrayList Invalid = new ArrayList();
        // Get a list of invalid file characters.
        char[] invalidFileChars = System.IO.Path.GetInvalidFileNameChars();
        //Invalid.Add('%');
        //Invalid.Add('#');
        //Invalid.Add('$');
        //Invalid.Add('&');
        //Invalid.Add('@');
        Invalid.AddRange(invalidFileChars);
        char[] InvalidChars = new char[Invalid.Count];
        Invalid.CopyTo(InvalidChars);
        return (strName.IndexOfAny(InvalidChars) < 0);
    }
    private bool CheckRegExpression(string strFileName, string Ext)
    {
        if (!string.IsNullOrEmpty(Ext))
        {
            string RegExpression = @"((NUL|STX|ETX|EOT|ENQ|ACK|BEL|BS|HT|LF|VT|FF|CR|SO|SI|DLE|DC1|DC2|DC3|DC4|NAK|SYN|ETB|CAN|EM|SUB|ESC|FS|GS|RS|US)\.(.*?))";
            if (strFileName != "")
            {
                //if (!string.IsNullOrEmpty(strName))
                //    strExtension = Attachment1.TextBoxFiletoAttach.Text.Substring(Attachment1.TextBoxFiletoAttach.Text.LastIndexOf("."));
                if (!strFileName.ToLower().EndsWith(Ext.ToLower()))
                {
                    strFileName = string.Concat(strFileName.ToUpper(), Ext);
                }
                if (Regex.IsMatch(strFileName, RegExpression))
                {
                    return false;
                }
            }
        }
        return true;
    }

}
