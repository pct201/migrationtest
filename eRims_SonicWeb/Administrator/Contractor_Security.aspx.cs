﻿using System;
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


public partial class Administrator_Contractor_Security : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Contactor_Security
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Contactor_Security"]);
        }
        set { ViewState["PK_Contactor_Security"] = value; }
    }
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
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
            // set the default sort field and sort order
            SortBy = "User_Name";
            SortOrder = "Asc";
            //Bind Admin Grid
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);            
            FillDropDown();

            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvContractorSecurity','Delete');");
            //check for page operation and set operation
            if (Request.QueryString["op"] != null)
                StrOperation = Request.QueryString["op"];
            if (StrOperation != string.Empty)
            {
                // get PK
                if (Request.QueryString["id"] != null && Convert.ToString(Request.QueryString["id"]).Trim() != "")
                    PK_Contactor_Security = clsGeneral.GetQueryStringID(Request.QueryString["id"]);

                if (StrOperation == "view")
                {
                    // Bind Controls
                    ViewRecords();
                }
                else
                {
                    EditRecords();
                }
            }
            else {
                PopupPassword.Style.Add("display", "none");
                divViewContractSecurityList.Style.Add("display", "block");
                divModifyAdmin.Style.Add("display", "none");
                DivEditContractorSecuirty.Style.Add("display", "none");
                DivViewSecurity.Style.Add("display", "none");
            }

        }
    }

    /// <summary>
    /// Add new Contractor Security
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        divViewContractSecurityList.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivEditContractorSecuirty.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        trPassword.Style.Add("display", "block");
        btnEdit.Visible = false;
        btnSave.Visible = true;
        BindLocationProjectAccessGridsView();
        lnkAddLocationProjectAccessGrid.Style.Add("display", "none");
        PK_Contactor_Security = 0;
        txtLoginUserName.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtContractorCompany.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        //ddlState.SelectedValue = ;
        txtZipCode.Text = "";
        txtOfficeTelephone.Text = "";
        txtCellPhone.Text = "";
        txtPager.Text = "";
        txtEmail.Text = "";
    }

    /// <summary>
    /// Delete Contractor Security Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {        
            string strSelected = Request.Form["chkItem"].ToString();
            foreach (GridViewRow gRow in gvContractorSecurity.Rows)
            {
                if (((Button)gRow.FindControl("btnEdit")).Enabled == false)
                {
                    strSelected = strSelected.Replace(gvContractorSecurity.DataKeys[gRow.RowIndex].Value.ToString(), "");
                    strSelected = strSelected.Replace(",,", "");
                    strSelected = strSelected.TrimStart(',');
                    strSelected = strSelected.TrimEnd(',');
                }
            }
            if (strSelected.Length > 0)
                Contractor_Security.DeleteByPKs(strSelected);
        
        //Bind Grid
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Search Button Click Event (Bind Grid with Search Criteria)
    /// </summary>    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Edit Button click Event - Edit Contractor Security Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_Contactor_Security > 0)
            Response.Redirect("Contractor_Security.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_Contactor_Security))) ;
    }

    /// <summary>
    /// Handles Save Button click Event - Save Contractor Security Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Contractor_Security objContractorSecurity = new Contractor_Security(PK_Contactor_Security);
        // set value of Security object
        objContractorSecurity.PK_Contactor_Security = PK_Contactor_Security;
        objContractorSecurity.User_Name = txtLoginUserName.Text.Trim().Replace("'", "\'");
        objContractorSecurity.First_Name = txtFirstName.Text.Trim().Replace("'", "\'");
        objContractorSecurity.Last_Name = txtLastName.Text.Trim().Replace("'", "\'");
        objContractorSecurity.Password = Encryption.Encrypt(txtPassword.Text.Trim().Replace("'", "\'").ToString());
        objContractorSecurity.Contractor_Company_Name = txtContractorCompany.Text.Trim().Replace("'", "\'");
        objContractorSecurity.Address_1 = txtAddress1.Text.Trim().Replace("'", "\'");
        objContractorSecurity.Address_2 = txtAddress2.Text.Trim().Replace("'", "\'");
        objContractorSecurity.City = txtAddress2.Text.Trim().Replace("'", "\'");

        //
        objContractorSecurity.Previous_Password_1 = "";
        objContractorSecurity.Previous_Password_2 = "";
        objContractorSecurity.Previous_Password_3 = "";
        objContractorSecurity.Texting_Address = "";
        objContractorSecurity.FL_LU_FACILITY_CONSTRUCTION_ALERT_METHOD = 0;


        if (ddlState.SelectedIndex > 0)
            objContractorSecurity.FK_State = Convert.ToDecimal(ddlState.SelectedValue);
        objContractorSecurity.Zip_Code = Convert.ToString(txtZipCode.Text);

        objContractorSecurity.Office_Telephone = Convert.ToString(txtOfficeTelephone.Text);
        objContractorSecurity.Cell_Telephone = Convert.ToString(txtCellPhone.Text);
        objContractorSecurity.Pager = Convert.ToString(txtPager.Text);

        objContractorSecurity.Email = txtEmail.Text.Trim().Replace("'", "\'");
        objContractorSecurity.Updated_By = clsSession.UserID;
        objContractorSecurity.Update_Date = DateTime.Now;

        if (PK_Contactor_Security > 0)
        {
            int RtnVal = objContractorSecurity.Update();
            // Used to Check Duplicate user ID?
            if (RtnVal == -2)
            {
                lblError.Text = "Contractor Security already exists.";
                return;
            }

        }
        else
        {
            if (clsGeneral.CheckPassword(txtPassword.Text) == false)
            {
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", "alert('Password must have at least 7 characters, one character, one digit and one special character!')", true);
                return;
            }
            PK_Contactor_Security = objContractorSecurity.Insert();
            // Used to Check Duplicate User ID?
            if (PK_Contactor_Security == -2)
            {
                lblError.Text = "Contractor Security already exists.";
                return;
            }
        }
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        ViewRecords();
    }


    /// <summary>
    /// Handles Cancel Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //PopupPassword.Style.Add("display", "none");
        divViewContractSecurityList.Style.Add("display", "block");
        divModifyAdmin.Style.Add("display", "none");
        //System.Web.UI.HtmlControls.HtmlTableRow trpass = (System.Web.UI.HtmlControls.HtmlTableRow)DivEditContractorSecuirty.FindControl("trPassword");
        //trpass.Style.Add("display", "");

    }

    /// <summary>
    /// Handles event when Add link is clicked for grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddLocationProjectAccessGrid_Click(object sender, EventArgs e)
    {
        if (PK_Contactor_Security > 0)
        {
            string strURL = "";
            strURL = "Contractor_Job_Security.aspx?";
            strURL = strURL + "fid=" + Encryption.Encrypt(PK_Contactor_Security.ToString()) + "&op=Add";
            Response.Redirect(strURL);
        }

    }


    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    #endregion

    #region Grid Events
    /// <summary>
    /// Handles Row Created Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContractorSecurity_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
            {
                // update sort image beside the column header
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[3].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Handles Sorting Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContractorSecurity_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Handles Row Data Bound Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContractorSecurity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Data row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Pk = Convert.ToDecimal(gvContractorSecurity.DataKeys[e.Row.RowIndex].Value);
        }
    }

    /// <summary>
    /// Handles Edit/View Row Command Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContractorSecurity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            divViewContractSecurityList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            // Hide password controls while editing.
            //System.Web.UI.HtmlControls.HtmlTableRow trpass = (System.Web.UI.HtmlControls.HtmlTableRow)DivEditSecuirty.FindControl("trPassword");
            //trpass.Style.Add("display", "");
            PK_Contactor_Security = Convert.ToInt32(e.CommandArgument.ToString());
            EditRecords();
        }
        else if (e.CommandName == "View")
        {
            divViewContractSecurityList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            PK_Contactor_Security = Convert.ToInt32(e.CommandArgument.ToString());
            ViewRecords();
        }
    }

    /// <summary>
    /// Handles Edit Row Command Event of Location Project Access Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLocationProjectAccess_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditDetails" || e.CommandName == "ViewDetails")
        {
            string strURL = "";
            strURL = "Contractor_Job_Security.aspx?";
            //strURL = strURL + "fid=" + Encryption.Encrypt(PK_Contactor_Security.ToString()) + "&op=Add";
            strURL = strURL + "id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=" + (e.CommandName == "EditDetails" ? "edit" : "view") + "&fid=" + Encryption.Encrypt(PK_Contactor_Security.ToString());
            Response.Redirect(strURL);
        }
        else if (e.CommandName == "RemoveDetails")
        {
            Contractor_Job_Security.Delete(Convert.ToDecimal(e.CommandArgument));
            BindLocationProjectAccessGridsView();
        }
    }

    /// <summary>
    /// Handles View Row Command Event of Location Project Access Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvViewLocationProjectAccess_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ViewDetails")
        {
            string strURL = "";
            strURL = "Contractor_Job_Security.aspx?";
            //strURL = strURL + "fid=" + Encryption.Encrypt(PK_Contactor_Security.ToString()) + "&op=Add";
            strURL = strURL + "id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&op=view&fid=" + Encryption.Encrypt(PK_Contactor_Security.ToString());
            Response.Redirect(strURL);
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Used to Bind Dropdown Control
    /// </summary>
    private void FillDropDown()
    {
        ComboHelper.FillState(new DropDownList[] { ddlState }, 0, true);
    }
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        DataSet dsAdmin = Contractor_Security.SelectAll(txtSearch.Text.Trim().Replace("'", "''"), SortBy, SortOrder, PageNumber, PageSize);
        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvContractorSecurity.DataSource = dtAdminData;
        gvContractorSecurity.DataBind();
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }
        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);

    }
    /// <summary>
    /// Returns the index of the column which contains particular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvContractorSecurity.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvContractorSecurity.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Used to Populate values to controls for Editing
    /// </summary>
    private void EditRecords()
    {
        divViewContractSecurityList.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivEditContractorSecuirty.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        PopupPassword.Style.Add("display", "block");
        //trPassword.Style.Add("diplay", "none");
        btnSave.Visible = true;
        btnEdit.Visible = false;
        BindLocationProjectAccessGridsView();
        Contractor_Security objContractorSecurity = new Contractor_Security(PK_Contactor_Security);
        HdnPK_Contactor_Security.Value = Convert.ToString(objContractorSecurity.PK_Contactor_Security);
        PK_Contactor_Security = Convert.ToInt32(objContractorSecurity.PK_Contactor_Security);
        txtLoginUserName.Text = Convert.ToString(objContractorSecurity.User_Name);
        txtPassword.Text = Encryption.Decrypt(objContractorSecurity.Password.ToString());
        txtPassword.Attributes.Add("value", txtPassword.Text);
        txtConfirmPassword.Attributes.Add("value", txtPassword.Text);
        txtFirstName.Text = Convert.ToString(objContractorSecurity.First_Name);
        txtLastName.Text = Convert.ToString(objContractorSecurity.Last_Name);
        txtContractorCompany.Text = Convert.ToString(objContractorSecurity.Contractor_Company_Name);
        txtAddress1.Text = Convert.ToString(objContractorSecurity.Address_1);   
        txtAddress2.Text = Convert.ToString(objContractorSecurity.Address_2);
        txtCity.Text = Convert.ToString(objContractorSecurity.City);
        if (objContractorSecurity.FK_State != null)
            ddlState.SelectedValue = objContractorSecurity.FK_State.ToString();

        txtZipCode.Text = Convert.ToString(objContractorSecurity.Zip_Code);
        txtOfficeTelephone.Text = Convert.ToString(objContractorSecurity.Office_Telephone);
        txtCellPhone.Text = Convert.ToString(objContractorSecurity.Cell_Telephone);
        txtPager.Text = Convert.ToString(objContractorSecurity.Pager);
        txtEmail.Text = Convert.ToString(objContractorSecurity.Email);

    }

    /// <summary>
    /// Used to Populate values to controls for View
    /// </summary>
    private void ViewRecords()
    {
        ///PopupPassword.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "block");
        divViewContractSecurityList.Style.Add("display", "none");
        DivEditContractorSecuirty.Style.Add("display", "none");
        PopupPassword.Style.Add("display", "none");
        trPassword.Style.Add("display", "none");
        btnSave.Visible = false;
        btnEdit.Visible = true;
        BindLocationProjectAccessGridsView();
        Contractor_Security objContractorSecurity = new Contractor_Security(PK_Contactor_Security);
        lblLoginUserName.Text = Convert.ToString(objContractorSecurity.User_Name);
        lblFirstName.Text = Convert.ToString(objContractorSecurity.First_Name);
        lblLastName.Text =Convert.ToString(objContractorSecurity.Last_Name);
        lblContractorCompany.Text = Convert.ToString(objContractorSecurity.Contractor_Company_Name);
        lblAddress1.Text = Convert.ToString(objContractorSecurity.Address_1);
        lblAddress2.Text = Convert.ToString(objContractorSecurity.Address_2);
        lblCity.Text = Convert.ToString(objContractorSecurity.City);
        if (objContractorSecurity.FK_State != null)
            lblState.Text = new State(Convert.ToDecimal(objContractorSecurity.FK_State)).FLD_state;
        lblZipCode.Text =  Convert.ToString(objContractorSecurity.Zip_Code);
        lblOfficeTelephone.Text = Convert.ToString(objContractorSecurity.Office_Telephone);
        lblCellPhone.Text = Convert.ToString(objContractorSecurity.Cell_Telephone);
        lblPager.Text = Convert.ToString(objContractorSecurity.Pager);
        lblEmail.Text = Convert.ToString(objContractorSecurity.Email);
            
    }

    /// <summary>
    /// Binds all grids on the page
    /// </summary>
    private void BindLocationProjectAccessGridsView()
    {
        DataSet dsGrids = Contractor_Job_Security.SelectByFKContactorSecurity(PK_Contactor_Security);
        gvLocationProjectAccess.DataSource = dsGrids;
        gvViewLocationProjectAccess.DataSource = dsGrids;
        gvLocationProjectAccess.DataBind();
        gvViewLocationProjectAccess.DataBind();
    }

    #endregion
    
}