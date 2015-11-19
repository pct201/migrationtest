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


public partial class Administrator_Contractor_Firm : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Contractor_Firm
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Contractor_Firm"]);
        }
        set { ViewState["PK_Contractor_Firm"] = value; }
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
            SortBy = "Contractor_Firm_Name";
            SortOrder = "Asc";
            //Bind Admin Grid
            BindGrid(1, 10);
            FillDropDown();

            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvContractorFirm','Delete');");
            //check for page operation and set operation
            if (Request.QueryString["op"] != null)
                StrOperation = Request.QueryString["op"];
            if (StrOperation != string.Empty)
            {
                // get PK
                if (Request.QueryString["id"] != null && Convert.ToString(Request.QueryString["id"]).Trim() != "")
                    PK_Contractor_Firm = clsGeneral.GetQueryStringID(Request.QueryString["id"]);

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
            else
            {
                divViewContractorFirmList.Style.Add("display", "block");
                divModifyAdmin.Style.Add("display", "none");
                DivEditContractorFirm.Style.Add("display", "none");
                DivViewSecurity.Style.Add("display", "none");
            }

        }
    }

    /// <summary>
    /// Add new Contractor Firm
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        divViewContractorFirmList.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivEditContractorFirm.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        btnEdit.Visible = false;
        btnSave.Visible = true;
        PK_Contractor_Firm = 0;
        txtContractorFirmName.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtCity.Text = "";
        txtZipCode.Text = "";
        txtOfficeTelephone.Text = "";
        txtCellPhone.Text = "";
        txtPager.Text = "";
        txtEmail.Text = "";
    }

    /// <summary>
    /// Delete Contractor Firm Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strSelected = Request.Form["chkItem"].ToString();
        foreach (GridViewRow gRow in gvContractorFirm.Rows)
        {
            if (((Button)gRow.FindControl("btnEdit")).Enabled == false)
            {
                strSelected = strSelected.Replace(gvContractorFirm.DataKeys[gRow.RowIndex].Value.ToString(), "");
                strSelected = strSelected.Replace(",,", "");
                strSelected = strSelected.TrimStart(',');
                strSelected = strSelected.TrimEnd(',');
            }
        }
        if (strSelected.Length > 0)
            Contractor_Firm.DeleteByPK(strSelected);

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
    /// Handles Edit Button click Event - Edit Contractor Firm Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_Contractor_Firm > 0)
            Response.Redirect("Contractor_Firm.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_Contractor_Firm)));
    }

    /// <summary>
    /// Handles Save Button click Event - Save Contractor Firm Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Contractor_Firm objContractorFirm = new Contractor_Firm(PK_Contractor_Firm);
        // set value of Security object
        objContractorFirm.PK_Contractor_Firm = PK_Contractor_Firm;
        objContractorFirm.Contractor_Firm_Name = txtContractorFirmName.Text.Trim().Replace("'", "\'");
        objContractorFirm.Address_1 = txtAddress1.Text.Trim().Replace("'", "\'");
        objContractorFirm.Address_2 = txtAddress2.Text.Trim().Replace("'", "\'");
        objContractorFirm.City = txtCity.Text.Trim().Replace("'", "\'");
        objContractorFirm.FK_State = Convert.ToDecimal(ddlState.SelectedValue);
        objContractorFirm.FK_LU_Firm_type = Convert.ToDecimal(ddlFirmType.SelectedValue);
        objContractorFirm.Zip_Code = Convert.ToString(txtZipCode.Text);

        objContractorFirm.Office_Telephone = Convert.ToString(txtOfficeTelephone.Text);
        objContractorFirm.Cell_Telephone = Convert.ToString(txtCellPhone.Text);
        objContractorFirm.Pager = Convert.ToString(txtPager.Text);

        objContractorFirm.Email = txtEmail.Text.Trim().Replace("'", "\'");
        objContractorFirm.Updated_By = clsSession.UserID;
        objContractorFirm.Update_Date = DateTime.Now;
        objContractorFirm.Contact_Name = Convert.ToString(txtContactName.Text);
        objContractorFirm.Facsimile_Number = Convert.ToString(txtFacsimile_Number.Text);

        if (PK_Contractor_Firm > 0)
        {
            int RtnVal = objContractorFirm.Update();
            // Used to Check Duplicate user ID?
            if (RtnVal == -2)
            {
                lblError.Text = "Contractor Firm Name already exists.";
                return;
            }

        }
        else
        {

            PK_Contractor_Firm = objContractorFirm.Insert();
            // Used to Check Duplicate User ID?
            if (PK_Contractor_Firm == -2)
            {
                lblError.Text = "Contractor Firm Name already exists.";
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
        divViewContractorFirmList.Style.Add("display", "block");
        divModifyAdmin.Style.Add("display", "none");
        Response.Redirect("Contractor_Firm.aspx");
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
    protected void gvContractorFirm_RowCreated(object sender, GridViewRowEventArgs e)
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
    protected void gvContractorFirm_Sorting(object sender, GridViewSortEventArgs e)
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
    protected void gvContractorFirm_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Data row type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal Pk = Convert.ToDecimal(gvContractorFirm.DataKeys[e.Row.RowIndex].Value);
        }
    }

    /// <summary>
    /// Handles Edit/View Row Command Event of Security Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContractorFirm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            divViewContractorFirmList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            PK_Contractor_Firm = Convert.ToInt32(e.CommandArgument.ToString());
            EditRecords();
        }
        else if (e.CommandName == "View")
        {
            divViewContractorFirmList.Style.Add("display", "none");
            divModifyAdmin.Style.Add("display", "block");
            PK_Contractor_Firm = Convert.ToInt32(e.CommandArgument.ToString());
            ViewRecords();
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
        ComboHelper.FillFirmType(new DropDownList[] { ddlFirmType }, 0, true);
    }
    /// <summary>
    /// Binds the grid by page number and page size
    /// </summary>
    /// <param name="PageNumber">Current page number</param>
    /// <param name="PageSize">Number of records to be displayed on a page</param>
    private void BindGrid(int PageNumber, int PageSize)
    {
        DataSet dsAdmin = Contractor_Firm.SelectAll(txtSearch.Text.Trim().Replace("'", "''"), SortBy, SortOrder, PageNumber, PageSize);
        DataTable dtAdminData = dsAdmin.Tables[0];

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsAdmin.Tables.Count >= 3) ? Convert.ToInt32(dsAdmin.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        // bind the grid.
        gvContractorFirm.DataSource = dtAdminData;
        gvContractorFirm.DataBind();
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
        foreach (DataControlField field in gvContractorFirm.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvContractorFirm.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Used to Populate values to controls for Editing
    /// </summary>
    private void EditRecords()
    {
        divViewContractorFirmList.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivEditContractorFirm.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "none");
        //trPassword.Style.Add("diplay", "none");
        btnSave.Visible = true;
        btnEdit.Visible = false;
        Contractor_Firm objContractorFirm = new Contractor_Firm(PK_Contractor_Firm);
        HdnPK_Contractor_Firm.Value = Convert.ToString(objContractorFirm.PK_Contractor_Firm);
        PK_Contractor_Firm = Convert.ToInt32(objContractorFirm.PK_Contractor_Firm);
        txtContractorFirmName.Text = Convert.ToString(objContractorFirm.Contractor_Firm_Name);
        txtAddress1.Text = Convert.ToString(objContractorFirm.Address_1);
        txtAddress2.Text = Convert.ToString(objContractorFirm.Address_2);

        txtCity.Text = Convert.ToString(objContractorFirm.City);
        if (objContractorFirm.FK_State != null)
            ddlState.SelectedValue = objContractorFirm.FK_State.ToString();

        txtZipCode.Text = Convert.ToString(objContractorFirm.Zip_Code);
        txtOfficeTelephone.Text = Convert.ToString(objContractorFirm.Office_Telephone);
        txtCellPhone.Text = Convert.ToString(objContractorFirm.Cell_Telephone);
        txtPager.Text = Convert.ToString(objContractorFirm.Pager);
        txtEmail.Text = Convert.ToString(objContractorFirm.Email);
        txtFacsimile_Number.Text = Convert.ToString(objContractorFirm.Facsimile_Number);
        txtContactName.Text = Convert.ToString(objContractorFirm.Contact_Name);
        if (objContractorFirm.FK_LU_Firm_type != null)
            ddlFirmType.SelectedValue = objContractorFirm.FK_LU_Firm_type.ToString();
    }

    /// <summary>
    /// Used to Populate values to controls for View
    /// </summary>
    private void ViewRecords()
    {
        ///PopupPassword.Style.Add("display", "none");
        divModifyAdmin.Style.Add("display", "block");
        DivViewSecurity.Style.Add("display", "block");
        divViewContractorFirmList.Style.Add("display", "none");
        DivEditContractorFirm.Style.Add("display", "none");
        btnSave.Visible = false;
        btnEdit.Visible = true;
        Contractor_Firm objContractorFirm = new Contractor_Firm(PK_Contractor_Firm);
        lblContractorFirmName.Text = Convert.ToString(objContractorFirm.Contractor_Firm_Name);
        lblAddress1.Text = Convert.ToString(objContractorFirm.Address_1);
        lblAddress2.Text = Convert.ToString(objContractorFirm.Address_2);
        lblCity.Text = Convert.ToString(objContractorFirm.City);
        if (objContractorFirm.FK_State != null)
            lblState.Text = new State(Convert.ToDecimal(objContractorFirm.FK_State)).FLD_state;

        lblZipCode.Text = Convert.ToString(objContractorFirm.Zip_Code);
        lblOfficeTelephone.Text = Convert.ToString(objContractorFirm.Office_Telephone);
        lblCellPhone.Text = Convert.ToString(objContractorFirm.Cell_Telephone);
        lblPager.Text = Convert.ToString(objContractorFirm.Pager);
        lblEmail.Text = Convert.ToString(objContractorFirm.Email);
        lblContactName.Text = Convert.ToString(objContractorFirm.Contact_Name);
        lblFacsimileNumber.Text = Convert.ToString(objContractorFirm.Facsimile_Number);
        if (objContractorFirm.FK_LU_Firm_type != null)
            lblFirmType.Text = new LU_Construction_Firm_Type(Convert.ToDecimal(objContractorFirm.FK_LU_Firm_type)).CFT_Desc;   //please change

    }

    public string CheckState(object myValue)
    {
        DataSet ds = State.SelectByPK((decimal)myValue);

        if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            return Convert.ToString(dt.Rows[0][1]);
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Combines two addresses
    /// </summary>
    /// <param name="objAddress1"></param>
    /// <param name="objAddress2"></param>
    /// <returns></returns>
    public static string FormatAddress(object objAddress1, object objAddress2)
    {
        string strAddress = string.Empty;
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress1)))
            strAddress = objAddress1.ToString().Trim();
        if (!string.IsNullOrEmpty(Convert.ToString(objAddress2)))
            strAddress = (strAddress != string.Empty) ? string.Concat(strAddress, ",&nbsp;", objAddress2.ToString().Trim()) : objAddress2.ToString().Trim();

        return strAddress;
    }

    #endregion
}