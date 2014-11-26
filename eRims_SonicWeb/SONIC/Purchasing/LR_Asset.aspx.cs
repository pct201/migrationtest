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

public partial class SONIC_Purchasing_LR_Asset : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// PK_Purchasing_LR_Asset
    /// </summary>
    private decimal PK_Purchasing_LR_Asset
    {
        get
        {
            return (ViewState["PK_Purchasing_LR_Asset"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_LR_Asset"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_LR_Asset"] = value;
        }
    }
    #endregion

    #region "Page Events"

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
            // if LR Agreement ID > 0 and page is in edit mode
            if (clsSession.Current_LR_Agreement_ID > 0 && clsSession.Str_LR_Agreement_Operation == "edit")
            {
                CheckUserRights();
                PK_Purchasing_LR_Asset = 0;
                // set purchasing LR Asset ID
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                        PK_Purchasing_LR_Asset = index;
                }

                // if LR_Asset ID > 0
                if (PK_Purchasing_LR_Asset > 0)
                    setControls();
                else
                    bindDropDown(0);
            }
            else
            {
                // if agreement ID > 0 then redirect to LR Agreement page
                if (clsSession.Current_LR_Agreement_ID > 0)
                    Response.Redirect("LeaseRentalAgreement.aspx?id=" + clsSession.Current_LR_Agreement_ID , true);
                else
                    Response.Redirect("LeaseRentalAgreement.aspx?op=add");
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
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only && clsSession.Str_LR_Agreement_Operation != "view")
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);

    }

    /// <summary>
    /// Bind dropdown data
    /// </summary>
    /// <param name="FK_Purchasing_LR_Asset"></param>
    private void bindDropDown(decimal FK_Purchasing_LR_Asset)
    {
        drpAsset.DataSource = Purchasing_Asset.SelectAll_LR_Assets(FK_Purchasing_LR_Asset, clsSession.Current_LR_Agreement_ID);
        drpAsset.DataTextField = "Purchasing_LR_Assets";
        drpAsset.DataValueField = "PK_Purchasing_Asset";
        drpAsset.DataBind();

        drpAsset.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //set properties from controls to save data
    private void setProperties(Purchasing_LR_Asset objAssets)
    {
        // objAssets.PK_Purchasing_LR_Asset = PK_Purchasing_SC_Asset;
        objAssets.FK_Purchasing_LR_Agreement = clsSession.Current_LR_Agreement_ID;
        objAssets.FK_Purchasing_Asset = Convert.ToDecimal(drpAsset.SelectedValue);
        objAssets.Update_Date = DateTime.Now;
        objAssets.Updated_By = "";
    }

    /// <summary>
    /// set controls from properties to view data
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_LR_Asset.SelectByPK(PK_Purchasing_LR_Asset);
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

    #endregion

    #region "Events"

    /// <summary>
    /// Handle Save data event -button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_LR_Asset objAssets = new Purchasing_LR_Asset();
            setProperties(objAssets);

            if (PK_Purchasing_LR_Asset > 0)
            {
                objAssets.Update();
            }
            else
            {
                objAssets.Insert();
            }
            Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(clsSession.Current_LR_Agreement_ID.ToString()), true);
        }
    }

    /// <summary>
    /// Handle Back button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("LeaseRentalAgreement.aspx?id=" + Encryption.Encrypt(clsSession.Current_LR_Agreement_ID.ToString()), true);
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(89).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 89").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Applicable Assets Grid - Asset":
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
