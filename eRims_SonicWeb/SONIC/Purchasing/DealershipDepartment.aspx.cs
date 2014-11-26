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

public partial class SONIC_Purchasing_DealershipDepartment : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// PK_Purchasing_SC_Department
    /// </summary>
    private decimal PK_Purchasing_SC_Department
    {
        get
        {
            return (ViewState["PK_Purchasing_SC_Department"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_SC_Department"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_SC_Department"] = value;
        }
    }
    #endregion

    #region "Page Event"
    /// <summary>
    /// Handle Page Laod Event
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
                PK_Purchasing_SC_Department = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_SC_Department = index;
                    }
                }
                if (PK_Purchasing_SC_Department > 0)
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
            if (clsSession.Str_ServiceContract_Operation != "view")
               SetValidations();
        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Fill (bind) drop down list with data
    /// </summary>
    /// <param name="FK_LU_Dealership_Department"></param>
    private void bindDropDown(decimal FK_LU_Dealership_Department)
    {
        drpDealerDepartment.DataSource = LU_Department.SelectAll_SC_Department(FK_LU_Dealership_Department, clsSession.Current_Purchasing_Service_Contract_ID);
        drpDealerDepartment.DataTextField = "Fld_Desc";
        drpDealerDepartment.DataValueField = "PK_LU_Dealership_Department";
        drpDealerDepartment.DataBind();

        drpDealerDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    /// <summary>
    /// set properties from controls to save data
    /// </summary>
    /// <param name="objDepartment"></param>
    private void setProperties(Purchasing_SC_Department objDepartment)
    {
        objDepartment.PK_Purchasing_SC_Department = PK_Purchasing_SC_Department;
        objDepartment.FK_Purchasing_Service_Contract = clsSession.Current_Purchasing_Service_Contract_ID;
        objDepartment.FK_LU_Dealership_Department = Convert.ToDecimal(drpDealerDepartment.SelectedValue);
        objDepartment.Update_Date = DateTime.Now;
        objDepartment.Updated_By = "";
    }
    /// <summary>
    /// set controls from properties to view data
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_SC_Department.SelectByPK(PK_Purchasing_SC_Department);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["FK_LU_Dealership_Department"] != null)
            {
                decimal FK_Purchasing_Department = Convert.ToDecimal(ds.Tables[0].Rows[0]["FK_LU_Dealership_Department"].ToString());
                bindDropDown(FK_Purchasing_Department);
                drpDealerDepartment.SelectedValue = FK_Purchasing_Department.ToString();
            }
            else
            {
                drpDealerDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
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
    /// Handle Save button click- save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_SC_Department objDepartment = new Purchasing_SC_Department();
            setProperties(objDepartment);
            if (PK_Purchasing_SC_Department > 0)
            {
                objDepartment.Update();
            }
            else
            {
                objDepartment.Insert();
            }
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()), true);
        }
    }

    /// <summary>
    /// Handle back button click
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

        #region "Lease/Rental Agreement - Dealership Department Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(92).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 92").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Dealership Department Grid - Dealership Department":
                    strCtrlsIDs += drpDealerDepartment.ClientID + ",";
                    strMessages += "Please select Dealership Department" + ",";
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
