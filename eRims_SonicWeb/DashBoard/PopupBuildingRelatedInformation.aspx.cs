using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashBoard_PopupBuildingRelatedInformation : clsBasePage
{
    #region ViewState
    private decimal Pk_Location
    {
        get { return Convert.ToDecimal(ViewState["Pk_Location"]); }
        set { ViewState["Pk_Location"] = value; }
    }

    private decimal Pk_Building
    {
        get { return Convert.ToDecimal(ViewState["Pk_Building"]); }
        set { ViewState["Pk_Building"] = value; }
    }

    private decimal PK_PM_Site_Information
    {
        get { return Convert.ToDecimal(ViewState["PK_PM_Site_Information"]); }
        set { ViewState["PK_PM_Site_Information"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Encryption.Decrypt(Request.QueryString["loc"])))
            {
                Pk_Location = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"]));
            }

            if (!string.IsNullOrEmpty(Encryption.Decrypt(Request.QueryString["id"])))
            {
                Pk_Building = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"]));
            }

            if (!string.IsNullOrEmpty(Encryption.Decrypt(Request.QueryString["SiteInfo"])))
            {
                PK_PM_Site_Information = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["SiteInfo"]));
            }
            
        }
    }
}