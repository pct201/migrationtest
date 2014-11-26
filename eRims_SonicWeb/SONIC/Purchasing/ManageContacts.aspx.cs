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

public partial class SONIC_Purchasing_ManageContacts : clsBasePage
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

    /// <summary>
    /// Denotes page size 
    /// </summary>
    private int _PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    /// <summary>
    /// Denotes page number 
    /// </summary>
    private int _PageNum
    {
        get { return Convert.ToInt32(ViewState["PageNum"]); }
        set { ViewState["PageNum"] = value; }
    }

    /// <summary>
    /// Denotes Contact type
    /// </summary>
    private int ContactType
    {
        get { return Convert.ToInt32(ViewState["type"]); }
        set { ViewState["type"] = value; }
    }

    /// <summary>
    /// Denotes purchasing contacts PK
    /// </summary>
    private decimal PK_Purchasing_Contacts
    {
        get { return Convert.ToDecimal(ViewState["PK_Purchasing_Contacts"]); }
        set { ViewState["PK_Purchasing_Contacts"] = value; }
    }  
    #endregion

    #region " Page Events "
    /// <summary>
    /// Handles Page events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!Page.IsPostBack)
        {
             BindDropDown(); //Bind DropDown List Data
             _SortBy = "Contact_Type,Contact_Name";
            _SortOrder = "asc";
            _PageNum = 1;
            _PageSize = 20;
            SetValidations();
        }
    }
    #endregion

    #region "Control Event"
    /// <summary>
    /// Handle Search Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {            
        BindSearchResult(1, ctrlPurchasingSearch.PageSize); //Bind Grid 
       //Set Div Visible true or false 
        dvSearchResult.Visible = true;
        dvManageSearch.Visible = false;
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;
    }
    /// <summary>
    /// Handel Add new Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        PK_Purchasing_Contacts = 0;
        ClearData();
        dvAddContact.Visible = true;
        dvAddButton.Visible = true;
        dvManageSearch.Visible = false;
        dvSearchResult.Visible = false;
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;       
    }   
    /// <summary>
    /// Handle Back Search Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dvAddContact.Visible = false;
        dvAddButton.Visible = false;                
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;
        //dvManageSearch.Visible = false;
        //dvSearchResult.Visible = true;
        if (gvContact.Rows.Count > 0)
        {
            dvManageSearch.Visible = false;
            dvSearchResult.Visible = true;
        }
        else
        {           
            dvManageSearch.Visible = true;
            dvSearchResult.Visible = false;
        }       
    }
    
    /// <summary>
    /// Handle Search Again Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchAgain_Click(object sender, EventArgs e)
    {
        dvAddContact.Visible = false;
        dvAddButton.Visible = false;
        dvSearchResult.Visible = false;
        dvManageSearch.Visible = true;
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;       
        ClearData();
    }

    /// <summary>
    /// Handel Save Data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
        ClearData();       
        //BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
        BindViewData();
        dvAddContact.Visible = false;
        dvAddButton.Visible = false;
        dvManageSearch.Visible = false;
        dvSearchResult.Visible = false;
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;
        dvAddContactView.Visible = true;
        dvButtonView.Visible = true;        
    }

    /// <summary>
    /// Handel Clear Button Click Event
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
        drpManageContactType.SelectedIndex = 0;
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }
    /// <summary>
    /// Handle Edit Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        dvAddButton.Visible = true;
        dvAddContact.Visible = true;
        dvManageSearch.Visible = false;
        dvSearchResult.Visible = false;
        dvAddContactView.Visible = false;
        dvButtonView.Visible = false;
        BindEditData();
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Function Clear Data
    /// </summary>
    private void ClearData()
    {
        drpContactType.SelectedIndex = 0;
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
        txtContactName.Text = "";
        txtCity.Text = "";
        txtAddress1.Text = "";
        txtTitle.Text = "";
        lstState.SelectedIndex = -1;
        drpManageContactType.SelectedIndex = 0;

    }
    /// <summary>
    /// Save Data in Page Control
    /// </summary>
    private void SaveData()
    {
        Purchasing_Contacts objServiceContract = new Purchasing_Contacts();
        objServiceContract.FK_Contact_Type = Convert.ToDecimal(drpContactType.SelectedValue); ;
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
        objServiceContract.Update_Date = DateTime.Now;
        objServiceContract.Updated_By = clsSession.UserID.ToString();
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
    /// <summary>
    /// Bind DropDown List and List Box Data
    /// </summary>
    private void BindDropDown()
    {
        // fill state dropdown           
        lstState.DataSource = State.SelectAll();
        lstState.DataTextField = "FLD_state";
        lstState.DataValueField = "PK_ID";
        lstState.DataBind();
             
        //Seach Contact Type 
        drpManageContactType.DataSource = Purchasing_Contact_Type.SelectAll();
        drpManageContactType.DataTextField = "FLD_desc";
        drpManageContactType.DataValueField = "PK_ID";
        drpManageContactType.DataBind();
        drpManageContactType.Items.Insert(0,new ListItem("---All---",""));

        //Add New Manage Contact Type
        drpContactType.DataSource = Purchasing_Contact_Type.SelectAll();
        drpContactType.DataTextField = "FLD_desc";
        drpContactType.DataValueField = "PK_ID";
        drpContactType.DataBind();
        drpContactType.Items.Insert(0, new ListItem("--Select--", "0"));

        ComboHelper.FillState(new DropDownList[] { drpState }, 0, true);
    }
    /// <summary>
    /// Bind Edit Data
    /// </summary>
    private void BindEditData()
    {
        Purchasing_Contacts objServiceContract = new Purchasing_Contacts(PK_Purchasing_Contacts);
        drpContactType.SelectedValue = Convert.ToString(objServiceContract.FK_Contact_Type);
        txtAddContactName.Text = objServiceContract.Contact_Name;
        txtAddTitle.Text = objServiceContract.Title;
        txtAddAddress1.Text = objServiceContract.Address_1;
        txtAddAddress2.Text = objServiceContract.Address_2;
        txtAddCity.Text = objServiceContract.City;
        drpState.SelectedValue = Convert.ToString(objServiceContract.FK_State);
        txtZipCode.Text = objServiceContract.ZIP_Code;
        txtWorkPhone.Text = objServiceContract.Work_Telephone;
        txtCellPhone.Text = objServiceContract.Cell_Telephone;
        txtFacsimile.Text = objServiceContract.Facsimile;
        txtEmail.Text = objServiceContract.Email;
        txtSupplierNotes.Text = objServiceContract.Notes;
    }
    /// <summary>
    /// Bind View Data
    /// </summary>
    private void BindViewData()
    {
        Purchasing_Contacts objServiceContract = new Purchasing_Contacts(PK_Purchasing_Contacts);
        lblAddContactName.Text = objServiceContract.Contact_Name;
        lblAddTitle.Text = objServiceContract.Title;
        lblAddAddress1.Text = objServiceContract.Address_1;
        lblAddAddress2.Text = objServiceContract.Address_2;
        lblAddCity.Text = objServiceContract.City;        
        lblZipCode.Text = objServiceContract.ZIP_Code;
        lblWorkPhone.Text = objServiceContract.Work_Telephone;
        lblCellPhone.Text = objServiceContract.Cell_Telephone;
        lblFacsimile.Text = objServiceContract.Facsimile;
        lblEmail.Text = objServiceContract.Email;
        lblSupplierNotes.Text = objServiceContract.Notes;
        lblContactType.Text = new Purchasing_Contact_Type((decimal)objServiceContract.FK_Contact_Type).FLD_desc;
        lblState.Text = new State((decimal)objServiceContract.FK_State).FLD_state;
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
    /// get page number for paging
    /// </summary>
    protected void GetPage()
    {
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }
    /// <summary>
    /// Bind Search result Grid
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindSearchResult(int PageNumber, int PageSize)
    {
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

        string strContactType = "";
       
        strContactType = Convert.ToString(drpManageContactType.SelectedValue); 
        // get result records matching search criteria
        DataSet dsContactInformation = Purchasing_LR_Agreement.SearchByContactMangePaging(strContactName, strTitle, strAddress1, strCity, strState, strContactType, _SortBy, _SortOrder, PageNumber, PageSize);

        // bind grid
        gvContact.DataSource = dsContactInformation.Tables[0];
        gvContact.DataBind();

        lblSearchHeader.Text = "Manage Contacts Search";
        lblNumber.Text = " Manage Contacts Records Found";

        //// set values for paging control,so it shows values as needed.
        ctrlPurchasingSearch.TotalRecords = (dsContactInformation.Tables.Count >= 2) ? Convert.ToInt32(dsContactInformation.Tables[1].Rows[0][0]) : 0;
        ctrlPurchasingSearch.CurrentPage = (dsContactInformation.Tables.Count >= 2) ? Convert.ToInt32(dsContactInformation.Tables[1].Rows[0][2]) : 0;
        ctrlPurchasingSearch.RecordsToBeDisplayed = dsContactInformation.Tables[0].Rows.Count;
        ctrlPurchasingSearch.SetPageNumbers();
        // set record numbers retrieved
        lblNumber.Text = ((dsContactInformation.Tables.Count >= 2) ? Convert.ToString(dsContactInformation.Tables[1].Rows[0][0]) : "0") + lblNumber.Text;

        if (App_Access == AccessType.View_Only)
        {
            foreach (GridViewRow gRow in gvContact.Rows)
            {
                ((Button)gRow.FindControl("lnkEdit")).Visible = false;
                ((Button)gRow.FindControl("lnkDelete")).Visible = false;
            }
        }

    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp, GridView gvResult)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvResult.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvResult.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

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
        //BindGrid();
        BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
    }
    /// <summary>
    /// Grid Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// Grid View Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {      
        // if command is for edit
        if (e.CommandName.ToString() == "EditItem")
        {
            dvAddButton.Visible = true;
            dvAddContact.Visible = true;
            dvManageSearch.Visible = false;
            dvSearchResult.Visible = false;
            dvAddContactView.Visible = false;
            dvButtonView.Visible = false;

            PK_Purchasing_Contacts = Convert.ToDecimal(e.CommandArgument);
            BindEditData();
        }
        else if (e.CommandName.ToString() == "DeleteItem")  // if command is for delete
        {
            decimal intPKID = Convert.ToDecimal(e.CommandArgument);

            // if contact is referred then give message else delete the record and bind the grid
            if (intPKID > 0)
            {
                if (Purchasing_Contacts.CheckManageContact_IDExists(intPKID))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Manage Contact is already referred by another record(s)');", true);
                    return;
                }
                BindSearchResult(ctrlPurchasingSearch.CurrentPage, ctrlPurchasingSearch.PageSize);
            }
        }
        else if (e.CommandName.ToString() == "ViewItem")    // if command is for view
        {
            dvAddButton.Visible = false;
            dvAddContact.Visible = false;
            dvManageSearch.Visible = false;
            dvSearchResult.Visible = false;
            dvAddContactView.Visible = true;
            dvButtonView.Visible = true;
            PK_Purchasing_Contacts = Convert.ToDecimal(e.CommandArgument);
            BindViewData();
        }
    }

    /// <summary>
    /// Handles event when contact grid rowdata is bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvContact_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lnkAddress = (Label)e.Row.FindControl("lnkAddress");
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
    /// Set all Validations
    /// </summary>
    private void SetValidations()
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
                case "Contact Type":
                    strCtrlsIDs += drpContactType.ClientID + ",";
                    strMessages += "Please enter Contact Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Contact Name":
                    strCtrlsIDs += txtAddContactName.ClientID + ",";
                    strMessages += "Please enter Contact Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Title":
                    strCtrlsIDs += txtAddTitle.ClientID + ",";
                    strMessages += "Please enter Title" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address1":
                    strCtrlsIDs += txtAddAddress1.ClientID + ",";
                    strMessages += "Please enter Address1" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Address2":
                    strCtrlsIDs += txtAddAddress2.ClientID + ",";
                    strMessages += "Please enter Address2" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtAddCity.ClientID + ",";
                    strMessages += "Please enter City" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter Zip Code" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtWorkPhone.ClientID + ",";
                    strMessages += "Please enter Work Telephone" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtCellPhone.ClientID + ",";
                    strMessages += "Please enter Cell Telephone" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Facsimile":
                    strCtrlsIDs += txtFacsimile.ClientID + ",";
                    strMessages += "Please enter Facsimile" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "E-Mail":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter E-Mail" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += "ctl00_ContentPlaceHolder1_txtSupplierNotes_txtNote,";
                    strMessages += "Please enter Notes" + ",";
                    Span13.Style["display"] = "inline-block";
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
