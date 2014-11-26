using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class SONIC_ClaimInfo_ImportOhioWCClaim : System.Web.UI.Page
{
    #region "Page Events"
    
    /// <summary>
    /// Page Load events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    #endregion

    #region "Events"
    
   

    /// <summary>
    /// Import Excel record into table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fupFile.HasFile == true)
        {
            if (System.IO.Path.GetExtension(fupFile.PostedFile.FileName).ToLower() == ".xls" || System.IO.Path.GetExtension(fupFile.PostedFile.FileName) == ".xlsx")
            {
                string strPostedFilePath = AppConfig.WCClaimDocPath + "OhioWCImport_" + DateTime.Now.ToString("ddMMyyHHmmss") + System.IO.Path.GetExtension(fupFile.PostedFile.FileName);
                if (System.IO.Directory.Exists(AppConfig.WCClaimDocPath) == false)
                {
                    System.IO.Directory.CreateDirectory(AppConfig.WCClaimDocPath);
                }
                fupFile.SaveAs(strPostedFilePath);
                Workers_Comp_Claims_OH.ImportOhioWCClaimRecord(strPostedFilePath);
                string csname1 = "PopupScript";
                string cstext1 = "<script type=\"text/javascript\">" +
                 "alert('Ohio Workers Compensation data imported successfully.');</" + "script>";
                ClientScript.RegisterStartupScript(this.GetType(), csname1, cstext1);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "FileInvalidMsg", "alert('Please select proper file.');", true);
                return;
            }
        }
    }

    /// <summary>
    /// Clear control
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        fupFile.Attributes.Clear();
    }

    #endregion
}