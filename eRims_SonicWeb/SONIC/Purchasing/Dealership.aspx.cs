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

public partial class SONIC_Purchasing_Dealership : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// PK_Purchasing_SC_Dealer
    /// </summary>
    private decimal PK_Purchasing_SC_Dealer
    {
        get
        {
            return (ViewState["PK_Purchasing_SC_Dealer"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_SC_Dealer"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_SC_Dealer"] = value;
        }
    }

    #endregion

    #region " Page Events "

    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_Purchasing_Service_Contract_ID > 0 && clsSession.Str_ServiceContract_Operation == "edit")
            {
                CheckUserRights();
                PK_Purchasing_SC_Dealer = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_SC_Dealer = index;
                    }
                }
                if (PK_Purchasing_SC_Dealer > 0)
                    setControls();
                else
                    bindDropDown(0);
            }
            else
            {
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
    /// Bind Dropdown list
    /// </summary>
    /// <param name="FK_LU_Location_Id"></param>
    private void bindDropDown(decimal FK_LU_Location_Id)
    {
        DataTable dtDealership = LU_Location.SelectAllDealershipByUser(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        dtDealership.DefaultView.RowFilter = "PK_LU_Location_ID <> " + Convert.ToString(FK_LU_Location_Id) + " and Active ='Y'";
        //DataTable dtDealership = LU_Location.SelectAllDealership(FK_LU_Location_Id, clsSession.Current_Purchasing_Service_Contract_ID).Tables[0];
        //dtDealership.DefaultView.RowFilter = " Active ='Y'";
        dtDealership = dtDealership.DefaultView.ToTable();

        lstDealership.DataSource = dtDealership;
        lstDealership.DataTextField = "Dealership";
        lstDealership.DataValueField = "PK_LU_Location_ID";
        lstDealership.DataBind();
    }

    /// <summary>
    /// set properties from controls for save data
    /// </summary>
    /// <param name="objDealer"></param>
    private void setProperties(Purchasing_SC_Dealer objDealer, string strSelectedValue)
    {
        objDealer.PK_Purchasing_SC_Dealer = PK_Purchasing_SC_Dealer;
        objDealer.FK_Purchasing_Service_Contract = clsSession.Current_Purchasing_Service_Contract_ID;
        objDealer.FK_LU_Location_Id = Convert.ToDecimal(strSelectedValue);
        objDealer.Update_Date = DateTime.Now;
        objDealer.Updated_By = "";
    }

    /// <summary>
    /// set controls from properties for view data
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_SC_Dealer.SelectByPK(PK_Purchasing_SC_Dealer);
        lstDealership.SelectionMode = ListSelectionMode.Single;
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["FK_LU_Location_Id"] != null)
            {
                decimal FK_LU_Location_Id = Convert.ToDecimal(ds.Tables[0].Rows[0]["FK_LU_Location_Id"].ToString());
                bindDropDown(FK_LU_Location_Id);
                lstDealership.SelectedValue = FK_LU_Location_Id.ToString();
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
    /// Handle Save Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_SC_Dealer objDealer = new Purchasing_SC_Dealer();
            if (PK_Purchasing_SC_Dealer > 0)
            {
                setProperties(objDealer, lstDealership.SelectedValue);
                objDealer.Update();
            }
            else
            {
                foreach (ListItem lst in lstDealership.Items)
                {
                    if (lst.Selected == true)
                    {
                        setProperties(objDealer, lst.Value);
                        objDealer.Insert();
                    }
                }
            }
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()), true);
        }
    }

    /// <summary>
    /// Handle Back buton event
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

        #region "Lease/Rental Agreement - Dealership Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(92).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 92").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Dealership Grid - Dealership":
                    strCtrlsIDs += lstDealership.ClientID + ",";
                    strMessages += "Please select Dealership" + ",";
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
