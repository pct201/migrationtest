using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using ERIMS.DAL;


public partial class Administrator_LU_Executive_Risk_Defense_Attorney : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Executive_Risk_Defense_Attorney
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Executive_Risk_Defense_Attorney"]);
        }
        set { ViewState["PK_LU_Executive_Risk_Defense_Attorney"] = value; }
    }

    #endregion

    #region Main Events
    /// <summary>
    /// Handles Page Load Event
    /// </summary>    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Bind Admin Grid
            BindGrid();
            divViewAttorneyList.Style.Add("display", "");
            divModifyAttorney.Style.Add("display", "none");

            //Bind Region Dropdown
            ComboHelper.FillState(new DropDownList[] { drpState }, 1,true);
        }
    }


    /// <summary>
    /// Add new User
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        divViewAttorneyList.Style.Add("display", "none");
        divModifyAttorney.Style.Add("display", "");

        PK_LU_Executive_Risk_Defense_Attorney = 0;
        ClearControl();
        btnSave.Visible = true;
      
    }

    /// <summary>
    /// Handles Cancel Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        divViewAttorneyList.Style.Add("display", "");
        divModifyAttorney.Style.Add("display", "none");
        ClearControl();
        
    }

    /// <summary>drpState
    /// Handles Save Button click Event - Save User Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {

        clsLU_Executive_Risk_Defense_Attorney objAttorney = new clsLU_Executive_Risk_Defense_Attorney(PK_LU_Executive_Risk_Defense_Attorney);
        // set key values
        objAttorney.PK_LU_Executive_Risk_Defense_Attorney = PK_LU_Executive_Risk_Defense_Attorney;
       
        // set values from page controls
        objAttorney.Firm = txtFirm.Text.Trim();
        objAttorney.Name = txtName.Text.Trim();
        objAttorney.Address_1 = txtAddress1.Text.Trim();
        objAttorney.Address_2 = txtAddress2.Text.Trim();
        objAttorney.City = txtCity.Text.Trim();
        if (drpState.SelectedIndex > 0)
            objAttorney.FK_State = Convert.ToDecimal(drpState.SelectedValue);
        objAttorney.Zip_Code = txtZipcode.Text.Trim();
        objAttorney.Telephone = txtTelephone.Text.Trim();
        objAttorney.E_Mail = txtEmail.Text.Trim();
        objAttorney.Panel = rdoPanel.SelectedValue;
        objAttorney.Notes = txtNotes.Text.Trim();
        objAttorney.Active = rdoActive.SelectedValue;

        // insert or update the record depending on Primary key
        if (PK_LU_Executive_Risk_Defense_Attorney > 0)
            objAttorney.Update();
        else
            PK_LU_Executive_Risk_Defense_Attorney = objAttorney.Insert();

        BindGrid();
        btnCancel_Click(sender, e);
    }

    #endregion

    #region Methods
   
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid()
    {
        DataSet dsAttorney = clsLU_Executive_Risk_Defense_Attorney.SelectAll();
        DataTable dtAttorneyData = dsAttorney.Tables[0];

        // bind the grid.
        gvDefenseAttorney.DataSource = dtAttorneyData;
        gvDefenseAttorney.DataBind();
    }

    /// <summary>
    /// Used to Populate values to controls for Editing
    /// </summary>
    private void EditRecord()
    {
        btnSave.Enabled = true;
        btnSave.Visible = true;
        // Create an Object
        // create object
        clsLU_Executive_Risk_Defense_Attorney objAttorney = new clsLU_Executive_Risk_Defense_Attorney(PK_LU_Executive_Risk_Defense_Attorney);

        // set values in page controls
        txtFirm.Text = objAttorney.Firm;
        txtName.Text = objAttorney.Name;
        txtAddress1.Text = objAttorney.Address_1;
        txtAddress2.Text = objAttorney.Address_2;
        txtCity.Text = objAttorney.City;
        clsGeneral.SetDropdownValue(drpState,objAttorney.FK_State,true);
        txtZipcode.Text = objAttorney.Zip_Code;
        txtTelephone.Text = objAttorney.Telephone;
        txtEmail.Text = objAttorney.E_Mail;
        rdoPanel.SelectedValue = objAttorney.Panel;
        txtNotes.Text = objAttorney.Notes;
        rdoActive.SelectedValue = objAttorney.Active;
        
    }

    protected void ClearControl()
    {
        // set values from page controls
        txtFirm.Text = "";
        txtName.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        drpState.SelectedIndex = -1;
        txtZipcode.Text = "";
        txtTelephone.Text = "";
        txtEmail.Text = "";
        rdoPanel.SelectedIndex = 1;
        txtNotes.Text = "";
        rdoActive.SelectedIndex = 1;
    }

    #endregion

    #region Grid Events

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDefenseAttorney.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Handles Edit/View Row Command Event of Attorney Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            divViewAttorneyList.Style.Add("display", "none");
            divModifyAttorney.Style.Add("display", "block");
            PK_LU_Executive_Risk_Defense_Attorney = Convert.ToInt32(e.CommandArgument.ToString());
            EditRecord();
        }
    }

    /// <summary>
    /// Handles Row Data Bound Event of Attorney Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Data row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRole;
            lblRole = (Label)e.Row.FindControl("lblActive");
            //check label is not null
            if (lblRole != null)
            {
                //check label Role value if it is 1 than display Full Access
                //else if it is 2 than display View Only.
                if (lblRole.Text == "Y")
                {
                    lblRole.Text = "Yes";
                }
                else if (lblRole.Text == "N")
                {
                    lblRole.Text = "No";
                }
            }

        }
    }
    #endregion

}