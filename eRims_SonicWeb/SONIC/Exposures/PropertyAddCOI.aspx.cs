using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Date : 20 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To add COI attachment document for a specific owner of property
/// 
/// Functionality:
/// Provides file browser and date textbox to enter COI information 
/// Validates data and returns back to the property page with entered information
/// 
/// </summary>
public partial class SONIC_Exposures_PropertyAddCOI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Handles Continue button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        // get the filename
        string strFileName = fpFile.PostedFile.FileName.Substring(fpFile.PostedFile.FileName.LastIndexOf("\\") + 1);

        // upload the file and get the uploaded file name
        string strUploadedFileName = clsGeneral.UploadFile(fpFile, AppConfig.PropertyCOIDocPath , false, false);
        strUploadedFileName = strUploadedFileName.Substring(strUploadedFileName.LastIndexOf("\\") + 1);

        // call javascript function to set the filenames and other details in property page
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:SelectCOIFile('" + strFileName + "','" + strUploadedFileName + "');", true);
    }
}
