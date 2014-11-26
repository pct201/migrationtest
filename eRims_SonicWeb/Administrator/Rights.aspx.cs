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
/// <summary>
/// By : Ravi Gupta
/// 
/// Purpose: 
/// To Add, update and remove the User Rights information
/// 
/// Functionality:
/// Lists the Rights.
/// 
/// By selecting the record related information is opend for view only. and clicking on Remove link delete the record.
/// Clicking on Add New Button add new Right Information
/// </summary>
public partial class SONIC_Exposures_Administrator_Rights : clsBasePage
{
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_Right_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Right_ID"]);
        }
        set { ViewState["PK_Right_ID"] = value; }
    }
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
            //fill Module Dropdown
            ComboHelper.FillModuleName(new DropDownList[] { ddlModuleName }, true);

            //fill Right Type Dropdown
            ComboHelper.FillRightType(new DropDownList[] { ddlRightType }, true);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Use to Clear Page Controls
    /// </summary>
    private void ClearControl()
    {
        //clear all control
        txtRightName.Text = "";
        ddlModuleName.ClearSelection();
        ddlRightType.ClearSelection();
        lnkCancel_Click(null, null);
    }
    /// <summary>
    /// Used to Bind a All Rights Data into Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsRight = Right.SelectAll();

        //Apply Dataset to Grid
        gvRights.DataSource = dsRight;
        gvRights.DataBind();
    }
    #endregion
    #region Add Right Button Event
    /// <summary>
    /// Add Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Right objRight = new Right();
        objRight.Right_Name = txtRightName.Text;
        objRight.Module_ID = (ddlModuleName.SelectedIndex > 0) ? Convert.ToDecimal(ddlModuleName.SelectedValue) : 0;
        objRight.RightType_ID = (ddlRightType.SelectedIndex > 0) ? Convert.ToDecimal(ddlRightType.SelectedValue) : 0;
        PK_Right_ID = objRight.Insert();
        if (PK_Right_ID == -2)
        {
            lblError.Text = "Right Name already exist.";
            //claer Controls
            ClearControl();
            return;
        }
        if (PK_Right_ID == -3)
        {
            lblError.Text = "Right with Module Name and Right Type is already exists.";
            //claer Controls
            ClearControl();
            return;
        }
        //claer Controls
        ClearControl();
        //Bind Grid for RIGHT
        BindGrid();
    }
    /// <summary>
    /// Cancel Link Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trRightAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtRightName.Text = "";
        trRightView.Style.Add("display", "none");
        //chkRights.ClearSelection();
    }
    #endregion
    #region Rights Grid View Events
    protected void gvRights_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Check Command Name
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvRights.DataKeys[Index].Values["PK_Right_ID"] != null) ? Convert.ToInt32(gvRights.DataKeys[Index].Values["PK_Right_ID"]) : 0;
            //used to check PK id. if greater than 0 than delete record
            if (PK_ID > 0)
            {
                Right.DeleteByPK(PK_ID);
            }
            //Bind Grid
            BindGrid();
        }
        if (e.CommandName == "View")
        {
            trRightAdd.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "Inline");
            trRightView.Style.Add("display", "Inline");
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvRights.DataKeys[Index].Values["PK_Right_ID"] != null) ? Convert.ToInt32(gvRights.DataKeys[Index].Values["PK_Right_ID"]) : 0;
            DataSet dsRights = Right.SelectByPK(PK_ID);
            if (dsRights.Tables.Count > 0)
            {
                DataRow dr = dsRights.Tables[0].Rows[0];
                lblRightName.Text = dr["Right_Name"].ToString();
                lblModuleName.Text = new Module(dr["Module_ID"].ToString() == string.Empty ? 0 : Convert.ToDecimal(dr["Module_ID"].ToString())).ModuleName;
                lblRightType.Text = new RightType(dr["RightType_ID"].ToString() == string.Empty ? 0 : Convert.ToDecimal(dr["RightType_ID"].ToString())).RightTypeName;
            }
        }
    }
    protected void gvRights_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Row Type if it is Datarow than find link button and Assign CommandArgument to it
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            LinkButton LnkView = (LinkButton)e.Row.FindControl("lnkView");
            //check Link Button Found or Not
            if (LnkRemove != null)
            {
                LnkRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
            //check Link Button Found or not
            if (LnkView != null)
            {
                LnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }
    }
    #endregion
    /// <summary>
    /// Module selected Index changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlModuleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModuleName.SelectedIndex > 0)
        {
            //fill Right Type Dropdown
            ComboHelper.FillRightType(new DropDownList[] { ddlRightType }, true);

            //check if the Module is Clim Info than Read Only rights are available for this Module.           
            if (ddlModuleName.SelectedValue == "2")
            {
                ddlRightType.Items.Remove(ddlRightType.Items[7]);
                ddlRightType.Items.Remove(ddlRightType.Items[6]);
                ddlRightType.Items.Remove(ddlRightType.Items[5]);
                ddlRightType.Items.Remove(ddlRightType.Items[4]);
                ddlRightType.Items.Remove(ddlRightType.Items[3]);
                ddlRightType.Items.Remove(ddlRightType.Items[1]);
            }
            else
            {
                if (ddlModuleName.SelectedItem.Text.Trim().ToUpper() != "ClaimInfo")
                {
                    ddlRightType.Items.Remove(ddlRightType.Items[8]);
                }
                if (ddlModuleName.SelectedItem.Text.Trim().ToUpper() != "CRM")
                {
                    ddlRightType.Items.Remove(ddlRightType.Items[7]);
                    ddlRightType.Items.Remove(ddlRightType.Items[6]);
                }
                if (ddlModuleName.SelectedItem.Text.Trim().ToUpper() != "RealEstate".ToUpper())
                {
                    ddlRightType.Items.Remove(ddlRightType.Items[5]);
                }
                if (ddlModuleName.SelectedItem.Text.Trim() != "Purchasing")
                {
                    ddlRightType.Items.Remove(ddlRightType.Items[4]);
                    ddlRightType.Items.Remove(ddlRightType.Items[3]);
                }
            }
        }
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:AddNewRight();", true);
    }
}
