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
using ERIMS.DAL;

public partial class SONIC_Purchasing_Asset : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes primary key for Purchasing Asset record
    /// </summary>
    private decimal PK_Purchasing_SC_Asset
    {
        get
        {
            return (ViewState["PK_Purchasing_SC_Asset"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_SC_Asset"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_SC_Asset"] = value;
        }
    }
    #endregion

    #region " Page Event "
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // if service contract ID > 0 and page is in edit mode
            if (clsSession.Current_Purchasing_Service_Contract_ID > 0 && clsSession.Str_ServiceContract_Operation == "edit")
            {
                // check whether user has access rights or not
                CheckUserRights();
                PK_Purchasing_SC_Asset = 0;

                // set PK for asset
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_SC_Asset = index;
                    }
                }

                // if asset ID is available
                if (PK_Purchasing_SC_Asset > 0)
                    setControls();
                else
                    bindDropDown(0);
            }
            else
            {
                // if service contract ID is available then redierct to that page
                if (clsSession.Current_Purchasing_Service_Contract_ID > 0)
                    Response.Redirect("ServiceContract.aspx?id=" + clsSession.Current_Purchasing_Service_Contract_ID, true);
                else
                    Response.Redirect("ServiceContract.aspx?op=add");
            }
            Purchasing_SearchTAB.StrRedirectTo = "";
            SetValidations();
        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Bind the Asset Dropdown 
    /// </summary>
    /// <param name="FK_Purchasing_Asset"></param>
    private void bindDropDown(decimal FK_Purchasing_Asset)
    {
        drpAsset.DataSource = Purchasing_Asset.SelectAll_SC_Assets(FK_Purchasing_Asset, clsSession.Current_Purchasing_Service_Contract_ID);
        drpAsset.DataTextField = "Purchasing_SC_Assets";
        drpAsset.DataValueField = "PK_Purchasing_Asset";
        drpAsset.DataBind();

        drpAsset.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// set properties for add/edit data
    /// </summary>
    /// <param name="objAssets"></param>
    private void setProperties(Purchasing_SC_Asset objAssets)
    {
        objAssets.PK_Purchasing_SC_Asset = PK_Purchasing_SC_Asset;
        objAssets.FK_Purchasing_Service_Contract = clsSession.Current_Purchasing_Service_Contract_ID;
        objAssets.FK_Purchasing_Asset = Convert.ToDecimal(drpAsset.SelectedValue);
        objAssets.Update_Date = DateTime.Now;
        objAssets.Updated_By = "";
    }

    /// <summary>
    /// set controls from data by PK
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_SC_Asset.SelectByPK(PK_Purchasing_SC_Asset);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["FK_Purchasing_Asset"] != null)
            {
                decimal FK_Purchasing_Asset = Convert.ToDecimal(ds.Tables[0].Rows[0]["FK_Purchasing_Asset"].ToString());
                bindDropDown(FK_Purchasing_Asset);
                drpAsset.SelectedValue = FK_Purchasing_Asset.ToString();
            }
            else
            {
                drpAsset.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
        }
        else
        {
            if (App_Access == AccessType.Purchasing_Edit)
            {
                PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
                objServiceContract.View(clsSession.Current_Purchasing_Service_Contract_ID);
                if (objServiceContract.Legal_Confidential.ToLower().Trim() == "y")
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
            }
        }
    }

    #endregion

    #region "Events"
    /// <summary>
    /// Handle Save Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_SC_Asset objAssets = new Purchasing_SC_Asset();
            setProperties(objAssets);

            if (PK_Purchasing_SC_Asset > 0)
            {
                objAssets.Update();
            }
            else
            {
                objAssets.Insert();
            }
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()), true);
        }
    }

    /// <summary>
    /// Handle Back button event - back to Service Contract page 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()), true);
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Lease/Rental Agreement - Applicable Assets Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(92).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 92").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Applicable Assets Grid  - Asset":
                    strCtrlsIDs += drpAsset.ClientID + ",";
                    strMessages += "Please select Asset" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}
