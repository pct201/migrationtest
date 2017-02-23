using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Administrator_UserHelp : clsBasePage
{
    #region "Property"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_UserHelp
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_UserHelp"]);
        }
        set { ViewState["PK_UserHelp"] = value; }
    }

    #endregion

    #region Page Load Event

    /// <summary>
    /// Page load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
            BindDropDown();
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind User Help Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsUserHelp = UserHelp.SelectAll();

        //Apply Dataset to Grid
        gvUserHelp.DataSource = dsUserHelp;
        gvUserHelp.DataBind();
    }

    /// <summary>
    /// Bind Drop Down
    /// </summary>
    private void BindDropDown()
    {
        drpType.Items.Clear();
        DataSet dsReports = LU_Document_Type.SelectAll();
        DataView dvData = dsReports.Tables[0].DefaultView;
        dvData.RowFilter =  "Active = 'Y'";
        DataTable dt = dvData.ToTable();
        drpType.DataSource = dt;
        drpType.DataTextField = "Document_Type";
        drpType.DataValueField = "Document_Type";
        drpType.DataBind();

        ListItem lstCommon = new ListItem("--Select--", "0");
        drpType.Items.Insert(0, lstCommon);
    }

    /// <summary>
    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        txtDescription.Text = "";
        txtUrl.Text = "";
        drpType.SelectedIndex = 0;
        rdbActiveEdit.SelectedValue = "Y";
    }
    #endregion

    #region "Add New User New"
    /// <summary>
    /// Handle Add new user help record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        ClearControls();
        trEdit.Visible = true;
        trGrid.Visible = false;
        _PK_UserHelp = 0;
    }
    #endregion

    #region Grid Events

    /// <summary>
    /// Handle Row command event of grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserHelp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Check Command Name
        if (e.CommandName == "EditItem")
        {
            trEdit.Visible = true;
            trGrid.Visible = false;

            _PK_UserHelp = Convert.ToDecimal(e.CommandArgument);
            UserHelp objUserHelp = new UserHelp(_PK_UserHelp);

            clsGeneral.SetDropdownValue(drpType, objUserHelp.Type, true);
            //drpType.SelectedValue = objUserHelp.Type;
            txtDescription.Text = objUserHelp.Description;
            txtUrl.Text = objUserHelp.URL;
            rdbActiveEdit.SelectedValue = objUserHelp.Active;
        }
    }

    /// <summary>
    /// Handle Data Row Bound event for User Help grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvUserHelp_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList rdbActive = (RadioButtonList)e.Row.FindControl("rdbActive");
            HiddenField hdnActive = (HiddenField)e.Row.FindControl("hdnActive");
            rdbActive.SelectedValue = Convert.ToString(hdnActive.Value);
        }
    }

    #endregion

    #region Cancel Button
    /// <summary>
    /// button Cancel event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearControls();
        trEdit.Visible = false;
        trGrid.Visible = true;
    }

    /// <summary>
    /// Handle Save button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (IsValid)
        {
            string strUploadURL, strUploadPath;
            UserHelp objUserHelp = new UserHelp();

            objUserHelp.PK_UserHelp = _PK_UserHelp;
            objUserHelp.Type = Convert.ToString(drpType.SelectedValue);
            objUserHelp.Description = txtDescription.Text.Trim();
            strUploadURL = AppConfig.SiteURL + @"User Manual" + "/";
            strUploadPath = AppConfig.SitePath + @"User Manual\";

            if (fpFile.HasFile)
            {
                //upload file
                objUserHelp.URL = (strUploadURL + clsGeneral.UploadFile(fpFile, strUploadPath, false, false)).Replace("http://", "").Replace("https://", "");
            }
            else
            {
                objUserHelp.URL = txtUrl.Text;
            }
            objUserHelp.Active = Convert.ToString(rdbActiveEdit.SelectedValue  );
            objUserHelp.Update_Date = DateTime.Now;
            objUserHelp.Updated_By = clsSession.UserName;

            if (_PK_UserHelp > 0)
                objUserHelp.Update();
            else
                objUserHelp.Insert();

            ClearControls();
            trEdit.Visible = false;
            trGrid.Visible = true;
            BindGrid();
        }
    }

    #endregion
}
