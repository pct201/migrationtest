using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.IO;

public partial class Administrator_SignaturePopup : System.Web.UI.Page
{
    #region "Properties"
    private decimal PK_COI_Signature
    {
        get { return Convert.ToDecimal(ViewState["PK_COI_Signature"]); }
        set { ViewState["PK_COI_Signature"] = value; }
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // check if PK is passed or not
            if (Request.QueryString["PK"] != null)
            {
                // set pk
                PK_COI_Signature = Convert.ToDecimal(Request.QueryString["PK"]);
                // get the signature data from PK
                COI_Signature objSignature = new COI_Signature(PK_COI_Signature);

                string strFileName = objSignature.ImageName;
                string strFolderPath = AppConfig.SiteURL + "Documents/Signatures/" + PK_COI_Signature + "/";
                string strFileNameDisplay = strFolderPath + strFileName;

                imgImage.ImageUrl = strFileNameDisplay;

            }
        }
    }
    #endregion
}