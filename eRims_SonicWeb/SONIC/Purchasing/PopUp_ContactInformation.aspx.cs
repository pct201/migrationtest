using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;
public partial class SONIC_Purchasing_PopUp_ContactInformation : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return Convert.ToString(ViewState["SortBy"]); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return Convert.ToString(ViewState["SortOrder"]); }
        set { ViewState["SortOrder"] = value; }
    }

    private int _PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    private int _PageNum
    {
        get { return Convert.ToInt32(ViewState["PageNum"]); }
        set { ViewState["PageNum"] = value; }
    }

    private string ContactType
    {
        get { return Convert.ToString(ViewState["type"]); }
        set { ViewState["type"] = value; }
    }
    private decimal FK_Table_Name
    {
        get { return Convert.ToDecimal(ViewState["FK_Table_Name"]); }
        set { ViewState["FK_Table_Name"] = value; }
    }
    private decimal PK_Purchasing_Contacts_Link
    {
        get { return Convert.ToDecimal(ViewState["PK_Purchasing_Contacts_Link"]); }
        set { ViewState["PK_Purchasing_Contacts_Link"] = value; }
    }
    private decimal PK_Purchasing_Contacts
    {
        get { return Convert.ToDecimal(ViewState["PK_Purchasing_Contacts"]); }
        set { ViewState["PK_Purchasing_Contacts"] = value; }
    }
    private string _StrTableName
    {
        get { return Convert.ToString(ViewState["StrTableName"]); }
        set { ViewState["StrTableName"] = value; }
    }

    #endregion

    #region " Page Events "
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // fill state dropdown           
            lstState.DataSource = State.SelectAll();
            lstState.DataTextField = "FLD_state";
            lstState.DataValueField = "PK_ID";
            lstState.DataBind();
            txtContactName.Focus();
            if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                ContactType = Convert.ToString(Request.QueryString["Type"]);

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                FK_Table_Name = Convert.ToDecimal(Request.QueryString["id"]);

            if (!string.IsNullOrEmpty(Request.QueryString["PkID"]))
                PK_Purchasing_Contacts_Link = Convert.ToDecimal(Request.QueryString["PkID"]);

            if (!string.IsNullOrEmpty(Request.QueryString["TN"]))
                _StrTableName = Convert.ToString(Request.QueryString["TN"]);
            _SortBy = "Contact_Name";
            _SortOrder = "asc";
            _PageNum = 1;
            _PageSize = 50;

            if (ContactType == "2")
                SetValidationsSupplier();
            else
                SetValidationsSonic();

            BindGrid();
        }


    }
    #endregion

    #region " Controls Events "

    /// <summary>
    /// Handles Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    /// <summary>
    /// Handles Clear button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtContactName.Text = "";
        txtTitle.Text = "";
        txtAddress1.Text = "";
        txtCity.Text = "";
        lstState.SelectedIndex = -1;
        BindGrid();

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        dvContact.Visible = false;
        dvAddButton.Visible = true;
        BindDropDown();
        if (ContactType == "2")
        {
            divSupplier.Visible = true;
        }
        else
        {
            divsonic.Visible = true;
        }
        ClearData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        BindGrid();
        dvContact.Visible = true;
        dvAddButton.Visible = false;
        divSupplier.Visible = false;
        divsonic.Visible = false;
        PK_Purchasing_Contacts = 0;
    }
    protected void btnContactClear_Click(object sender, EventArgs e)
    {
        ClearData();
    }
    protected void btnContactSearch_Click(object sender, EventArgs e)
    {
        dvContact.Visible = true;
        dvAddButton.Visible = false;
        divSupplier.Visible = false;
        divsonic.Visible = false;
    }


    /// <summary>
    /// Handles event when page number link in grid is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPage_Click(object sender, EventArgs e)
    {
        // set page number passed by the link button
        _PageNum = Convert.ToInt32(((LinkButton)sender).CommandArgument);

        // bind the grid for selected page
        BindGrid();
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Performs search and binds the grid
    /// </summary>
    private void BindGrid()
    {
        // get search criteria

        string strContactName = txtContactName.Text.Trim().Replace("'", "''");
        string strTitle = txtTitle.Text.Trim().Replace("'", "''");
        string strAddress1 = txtAddress1.Text.Trim().Replace("'", "''");
        string strCity = txtCity.Text.Trim().Replace("'", "''");
        string strState = "";
        foreach (ListItem itmST in lstState.Items)
        {
            if (itmST.Selected)
                strState = strState + "'" + itmST.Value + "',";
        }
        strState = strState.TrimEnd(',');

        // get result records matching search criteria
        DataSet dsContactInformation = Purchasing_LR_Agreement.SearchByPaging(strContactName, strTitle, strAddress1, strCity, strState, ContactType, _SortBy, _SortOrder, _PageNum, _PageSize);

        // bind grid
        gvContact.DataSource = dsContactInformation.Tables[0];
        gvContact.DataBind();

        // bind the datalist for paging if datatable for that avaialble
        if (dsContactInformation.Tables.Count > 1)
        {
            if (dsContactInformation.Tables[1].Rows.Count > 0)
            {
                BindPageList(Convert.ToInt32(dsContactInformation.Tables[1].Rows[0][0]));
            }
        }
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvContact.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvContact.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
    /// Binds the page numbers to the grid footer
    /// </summary>
    /// <param name="intTotalRecords"></param>
    private void BindPageList(int intTotalRecords)
    {
        // calculate and show total pages.
        int intDivision = intTotalRecords / _PageSize;
        int intReminder = intTotalRecords % _PageSize;
        int intTotalPages = (intDivision > 0) ? (intDivision + ((intReminder > 0) ? 1 : 0)) : 1;

        // if total pages count is > 1 then        
        if (intTotalPages > 1)
        {
            // create array with the length of page numbers
            int[] intPageNums = new int[intTotalPages];

            // bind the datalist to list page numbers
            dlPages.DataSource = intPageNums;
            dlPages.DataBind();
            tblPaging.Style["display"] = "block";
            ((LinkButton)dlPages.Items[_PageNum - 1].FindControl("lnkPage")).Font.Underline = false;
        }
        else
            tblPaging.Style["display"] = "none"; // hide page number table

    }

    private void BindDropDown()
    {

        ComboHelper.FillState(new DropDownList[] { drpState, drpSonicState }, 0, true);
    }

    private void SaveData()
    {
        // create object for the executive risk record
        Purchasing_Contacts objServiceContract = new Purchasing_Contacts();
        if (_StrTableName == "SC")
        {
            if (ContactType == "2")
            {
                objServiceContract.FK_Contact_Type = 2;
                objServiceContract.Contact_Name = txtAddContactName.Text.Trim();
                objServiceContract.Title = txtAddTitle.Text.Trim();
                objServiceContract.Address_1 = txtAddAddress1.Text.Trim();
                objServiceContract.Address_2 = txtAddAddress2.Text.Trim();
                objServiceContract.City = txtAddCity.Text.Trim();
                objServiceContract.FK_State = Convert.ToDecimal(drpState.SelectedValue);
                objServiceContract.ZIP_Code = txtZipCode.Text.Trim();
                objServiceContract.Work_Telephone = txtWorkPhone.Text.Trim();
                objServiceContract.Cell_Telephone = txtCellPhone.Text.Trim();
                objServiceContract.Facsimile = txtFacsimile.Text.Trim();
                objServiceContract.Email = txtEmail.Text.Trim();
                objServiceContract.Notes = txtSupplierNotes.Text.Trim();

            }
            else
            {
                objServiceContract.FK_Contact_Type = 1;
                objServiceContract.Contact_Name = txtSonicContactName.Text.Trim();
                objServiceContract.Title = txtSonicTitle.Text.Trim();
                objServiceContract.Address_1 = txtSonicAddress1.Text.Trim();
                objServiceContract.Address_2 = txtSonicAddress2.Text.Trim();
                objServiceContract.City = txtSonicCity.Text.Trim();
                objServiceContract.FK_State = Convert.ToDecimal(drpSonicState.SelectedValue);
                objServiceContract.ZIP_Code = txtSonicZipCode.Text.Trim();
                objServiceContract.Work_Telephone = txtSonicWorkPhone.Text.Trim();
                objServiceContract.Cell_Telephone = txtSonicCellPhone.Text.Trim();
                objServiceContract.Facsimile = txtSonicFscsimile.Text.Trim();
                objServiceContract.Email = txtSonicEmail.Text.Trim();
                objServiceContract.Notes = txtSonicNotes.Text.Trim();

            }
        }
        else
        {
            if (ContactType == "2")
            {
                objServiceContract.FK_Contact_Type = 2;
                objServiceContract.Contact_Name = txtAddContactName.Text.Trim();
                objServiceContract.Title = txtAddTitle.Text.Trim();
                objServiceContract.Address_1 = txtAddAddress1.Text.Trim();
                objServiceContract.Address_2 = txtAddAddress2.Text.Trim();
                objServiceContract.City = txtAddCity.Text.Trim();
                objServiceContract.FK_State = Convert.ToDecimal(drpState.SelectedValue);
                objServiceContract.ZIP_Code = txtZipCode.Text.Trim();
                objServiceContract.Work_Telephone = txtWorkPhone.Text.Trim();
                objServiceContract.Cell_Telephone = txtCellPhone.Text.Trim();
                objServiceContract.Facsimile = txtFacsimile.Text.Trim();
                objServiceContract.Email = txtEmail.Text.Trim();
                objServiceContract.Notes = txtSupplierNotes.Text.Trim();
            }
            else
            {
                objServiceContract.FK_Contact_Type = 1;
                objServiceContract.Contact_Name = txtSonicContactName.Text.Trim();
                objServiceContract.Title = txtSonicTitle.Text.Trim();
                objServiceContract.Address_1 = txtSonicAddress1.Text.Trim();
                objServiceContract.Address_2 = txtSonicAddress2.Text.Trim();
                objServiceContract.City = txtSonicCity.Text.Trim();
                objServiceContract.FK_State = Convert.ToDecimal(drpSonicState.SelectedValue);
                objServiceContract.ZIP_Code = txtSonicZipCode.Text.Trim();
                objServiceContract.Work_Telephone = txtSonicWorkPhone.Text.Trim();
                objServiceContract.Cell_Telephone = txtSonicCellPhone.Text.Trim();
                objServiceContract.Facsimile = txtSonicFscsimile.Text.Trim();
                objServiceContract.Email = txtSonicEmail.Text.Trim();
                objServiceContract.Notes = txtSonicNotes.Text.Trim();

            }
        }
        objServiceContract.Update_Date = DateTime.Now;
        objServiceContract.Updated_By = clsSession.UserID.ToString();
        // update or insert the data according to the primary key
        if (PK_Purchasing_Contacts > 0)
        {
            objServiceContract.PK_Purchasing_Contacts = PK_Purchasing_Contacts;
            objServiceContract.Update();
        }
        else
        {
            PK_Purchasing_Contacts = objServiceContract.Insert();
        }
    }
    private void ClearData()
    {
        txtAddContactName.Text = "";
        txtAddTitle.Text = "";
        txtAddAddress1.Text = "";
        txtAddAddress2.Text = "";
        txtAddCity.Text = "";
        drpState.SelectedIndex = 0;
        txtZipCode.Text = "";
        txtWorkPhone.Text = "";
        txtCellPhone.Text = "";
        txtFacsimile.Text = "";
        txtEmail.Text = "";
        txtSupplierNotes.Text = "";
        txtSonicContactName.Text = "";
        txtSonicTitle.Text = "";
        txtSonicAddress1.Text = "";
        txtSonicAddress2.Text = "";
        txtSonicCity.Text = "";
        drpSonicState.SelectedIndex = 0;
        txtSonicZipCode.Text = "";
        txtSonicWorkPhone.Text = "";
        txtSonicCellPhone.Text = "";
        txtSonicFscsimile.Text = "";
        txtSonicEmail.Text = "";
        txtSonicNotes.Text = "";

    }
    /// <summary>
    /// save data add or update
    /// </summary>

    #endregion

    #region " GridView Events "

    /// <summary>
    /// Handles event when grid header link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_Sorting(object sender, GridViewSortEventArgs e)
    {
        // set the sort order and sort column
        _SortBy = e.SortExpression;
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";

        // binds the grid
        BindGrid();
    }

    protected void gvContact_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
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
                e.Row.Cells[6].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Handles event when grid page link is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // set new page index
        gvContact.PageIndex = e.NewPageIndex;

        // bind the grid
        BindGrid();
    }
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.ToString() == "edititem")
        {
            // create object for the executive risk record
            Purchasing_Contacts_Link objCON = new Purchasing_Contacts_Link();

            // get the values from the page controls
            GridViewRow row = null;
            int rowIndex = 0;
            row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            rowIndex = row.RowIndex;
            int intFK_Table_Name = 0;
            if (gvContact.DataKeys[rowIndex].Values["PK_Purchasing_Contacts"] != DBNull.Value)
                intFK_Table_Name = Convert.ToInt32(gvContact.DataKeys[rowIndex].Values["PK_Purchasing_Contacts"]);

            DateTime dtContact_Link_Date;
            dtContact_Link_Date = DateTime.Now;
            if (_StrTableName == "SC")
                objCON.Table_Name = "Purchasing_Service_Contract";
            else
                objCON.Table_Name = "Purchasing_LR_Agreement";

            objCON.FK_Table_Name = FK_Table_Name;
            objCON.FK_Purchasing_Contacts = intFK_Table_Name;
            objCON.Contact_Link_Date = dtContact_Link_Date;
            if (PK_Purchasing_Contacts_Link > 0)
            {
                objCON.PK_Purchasing_Contacts_Link = PK_Purchasing_Contacts_Link;
                objCON.Update();
            }
            else
            {
                PK_Purchasing_Contacts_Link = objCON.Insert();
            }

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SelectValue();", true);
        }

    }

    protected void gvContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkAddress = (LinkButton)e.Row.FindControl("lnkAddress");
            string strAddress1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
            string strAddress2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
            string strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
            string strState = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FLD_abbreviation"));
            string strZipcode = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ZIP_Code"));

            string strAddress = strAddress1;
            if (strAddress2 != "")
                strAddress = strAddress + ((strAddress != "") ? ("</br>" + strAddress2) : strAddress2);
            if (strCity != "")
                strAddress = strAddress + ((strAddress != "") ? ("</br>" + strCity) : strCity);
            if (strState != "")
                strAddress = strAddress + ((strAddress != "") ? (", " + strState) : strState);
            if (strZipcode != "")
                strAddress = strAddress + ((strAddress != "") ? (" " + strZipcode) : strZipcode);

            lnkAddress.Text = strAddress;

        }
    }


    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations-Supplier
    /// </summary>
    private void SetValidationsSupplier()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Manage Contacts"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(130).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Contact Name":
                    strCtrlsIDs += txtAddContactName.ClientID + ",";
                    strMessages += "Please enter Contact Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Title":
                    strCtrlsIDs += txtAddTitle.ClientID + ",";
                    strMessages += "Please enter Title" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address1":
                    strCtrlsIDs += txtAddAddress1.ClientID + ",";
                    strMessages += "Please enter Address1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address2":
                    strCtrlsIDs += txtAddAddress2.ClientID + ",";
                    strMessages += "Please enter Address2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtAddCity.ClientID + ",";
                    strMessages += "Please enter City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select State" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter Zip Code" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtWorkPhone.ClientID + ",";
                    strMessages += "Please enter Work Telephone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtCellPhone.ClientID + ",";
                    strMessages += "Please enter Cell Telephone" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Facsimile":
                    strCtrlsIDs += txtFacsimile.ClientID + ",";
                    strMessages += "Please enter Facsimile" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "E-Mail":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter E-Mail" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtSupplierNotes.ClientID + ",";
                    strMessages += "Please enter Notes" + ",";
                    Span12.Style["display"] = "inline-block";
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

    /// <summary>
    /// Set all Validations-Sonic
    /// </summary>
    private void SetValidationsSonic()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Manage Contacts"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(130).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Contact Name":
                    strCtrlsIDs += txtSonicContactName.ClientID + ",";
                    strMessages += "Please enter Contact Name" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Title":
                    strCtrlsIDs += txtSonicTitle.ClientID + ",";
                    strMessages += "Please enter Title" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Address1":
                    strCtrlsIDs += txtSonicAddress1.ClientID + ",";
                    strMessages += "Please enter Address1" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Address2":
                    strCtrlsIDs += txtSonicAddress2.ClientID + ",";
                    strMessages += "Please enter Address2" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtSonicCity.ClientID + ",";
                    strMessages += "Please enter City" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpSonicState.ClientID + ",";
                    strMessages += "Please select State" + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtSonicZipCode.ClientID + ",";
                    strMessages += "Please enter Zip Code" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtSonicWorkPhone.ClientID + ",";
                    strMessages += "Please enter Work Telephone" + ",";
                    Span20.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtSonicCellPhone.ClientID + ",";
                    strMessages += "Please enter Cell Telephone" + ",";
                    Span21.Style["display"] = "inline-block";
                    break;
                case "Facsimile":
                    strCtrlsIDs += txtSonicFscsimile.ClientID + ",";
                    strMessages += "Please enter Facsimile" + ",";
                    Span22.Style["display"] = "inline-block";
                    break;
                case "E-Mail":
                    strCtrlsIDs += txtSonicEmail.ClientID + ",";
                    strMessages += "Please enter E-Mail" + ",";
                    Span23.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtSonicNotes.ClientID + ",";
                    strMessages += "Please enter Notes" + ",";
                    Span24.Style["display"] = "inline-block";
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
