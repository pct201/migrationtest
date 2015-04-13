using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_Document_Folders_FacilityConstruction : System.Web.UI.Page
{

    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_FC_Document_Folder
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_FC_Document_Folder"]);
        }
        set { ViewState["PK_LU_FC_Document_Folder"] = value; }
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
    
    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SortBy = "Folder_Name";
            SortOrder = "Asc";
            //Bind Grid Function
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
            BindContractTypeList(false);
        }
    }
    #endregion

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Save";
        PK_LU_FC_Document_Folder = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        grid.Style.Add("display", "none");
        txtDescription.Text = "";
        BindContractTypeList(false);
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        grid.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "none");
        txtDescription.Text = "";
        
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_Document_Folders_FacilityConstruction objDocument_Folders = new clsLU_Document_Folders_FacilityConstruction();
        objDocument_Folders.Folder_Name = txtDescription.Text.Trim();

        if (PK_LU_FC_Document_Folder > 0)
        {
            _retVal = objDocument_Folders.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Folder Name that you are trying to add already exists in the Document Folder Type table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Save";
        }
        else
        {
            _retVal = objDocument_Folders.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Folder Name that you are trying to add already exists in the Document Folder table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            PK_LU_FC_Document_Folder = _retVal;
        }

        //delete Document Type
        LU_FC_Document_Folder_ContractorType.Delete(PK_LU_FC_Document_Folder);
        foreach (ListItem Li in lstAllowAccessCT.Items)
        {
            LU_FC_Document_Folder_ContractorType objDocument_Folder_CT = new LU_FC_Document_Folder_ContractorType();
            objDocument_Folder_CT.FK_LU_FC_Document_Folder = PK_LU_FC_Document_Folder;
            objDocument_Folder_CT.FK_LU_Contractor_Type = Convert.ToInt32(Li.Value);
            objDocument_Folder_CT.Insert();
        }


        //clear Control
        ClearControls();
        //Bind Grid Function
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        //Cancel CLick
        lnkCancel_Click(null, null);
        BindContractTypeList(false);
    }


    protected void btnSelectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstContractorType, lstAllowAccessCT, true, true, false);
    }

    protected void btnSelectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstContractorType, lstAllowAccessCT, false, true, false);
    }
    protected void btnDeselectFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstAllowAccessCT, lstContractorType, true, false, true);
    }
    protected void btnDeselectAllFields_Click(object sender, EventArgs e)
    {
        MoveListBoxItems(lstAllowAccessCT, lstContractorType, false, false, true);
    }
    #endregion

    #region "Grid Event"

    protected void gvInspection_Area_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInspection_Area.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }
    protected void gvInspection_Area_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_FC_Document_Folder = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            grid.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Document_Folders_FacilityConstruction objStatus = new clsLU_Document_Folders_FacilityConstruction(PK_LU_FC_Document_Folder);
            txtDescription.Text = objStatus.Folder_Name.ToString();
            BindContractTypeList(true);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            PK_LU_FC_Document_Folder = Convert.ToDecimal(e.CommandArgument);
            //delete from parent table //[LU_FC_Document_Folder]
            clsLU_Document_Folders_FacilityConstruction.Delete(PK_LU_FC_Document_Folder);
            //delete Document Type  from table [LU_FC_Document_Folder_ContractorType]
            LU_FC_Document_Folder_ContractorType.Delete(PK_LU_FC_Document_Folder);
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Contractor Type Grid
    /// </summary>
    private void BindGrid(int PageNumber, int PageSize)
    {
        //Get Record into Dataset
        DataSet dsGroup = clsLU_Document_Folders_FacilityConstruction.SelectAll(SortBy, SortOrder, PageNumber, PageSize);
        DataTable dtAdminData = dsGroup.Tables[0];

        //Apply Dataset to Grid
        gvInspection_Area.DataSource = dsGroup;
        gvInspection_Area.DataBind();

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (dsGroup.Tables.Count >= 3) ? Convert.ToInt32(dsGroup.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (dsGroup.Tables.Count >= 3) ? Convert.ToInt32(dsGroup.Tables[2].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = dtAdminData.Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        //Total records Count
        lblNumber.Text = (dsGroup.Tables.Count >= 3) ? Convert.ToString(dsGroup.Tables[1].Rows[0][0]) : "0";
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_FC_Document_Folder = 0;
    }


    /// <summary>
    /// Bind contractor Type List
    /// </summary>
    private void BindContractTypeList(bool _EditFlag)
    {
        //clear list box
        lstContractorType.Items.Clear();
        lstAllowAccessCT.Items.Clear();

        DataSet dsData = clsLU_Contractor_Type.SelectAll();
        dsData.Tables[0].DefaultView.Sort = "CT_Desc asc";
        // Bind List lstFROIeMailRecipients
        lstContractorType.DataSource = dsData.Tables[0].DefaultView;
        lstContractorType.DataTextField = "CT_Desc";
        lstContractorType.DataValueField = "PK_LU_Contractor_Type";
        lstContractorType.DataBind();
        //if opened in Edit mode, Move Selected data to right (From lstContractorType to lstAllowAccessCT)
        if (_EditFlag)
        {
            DataSet dsSelectedData = LU_FC_Document_Folder_ContractorType.SelectByFK_LU_FC_Document_Folder(PK_LU_FC_Document_Folder);
            foreach (DataRow dr in dsSelectedData.Tables[0].Rows)
            {
                if (lstContractorType.Items.FindByValue(dr["FK_LU_Contractor_Type"].ToString().Trim()) != null)
                {
                    lstContractorType.Items.Remove(new ListItem(dr["ContractorType"].ToString().Trim(), dr["FK_LU_Contractor_Type"].ToString().Trim()));
                    lstAllowAccessCT.Items.Add(new ListItem(dr["ContractorType"].ToString().Trim(), dr["FK_LU_Contractor_Type"].ToString().Trim()));
                }
            }
        }
        //Enable/Disable buttons
        btnDeselectFields.Enabled = btnDeselectAllFields.Enabled = lstAllowAccessCT.Items.Count > 0; //imgUp.Enabled = imgDown.Enabled = 
        btnSelectAllFields.Enabled = btnSelectFields.Enabled = lstContractorType.Items.Count > 0;
        clsGeneral.SetListBoxToolTip(new ListBox[] { lstContractorType, lstAllowAccessCT });
    }


    /// <summary>
    /// Move Output Fields from One List to Another List and add/Remove From Sort and group by DropDown
    /// </summary>
    /// <param name="lstFrom"></param>
    /// <param name="lstTo"></param>
    /// <param name="OnlySelected"></param>
    /// <param name="IsSelect"></param>
    private void MoveListBoxItems(ListBox lstFrom, ListBox lstTo, bool OnlySelected, bool IsSelect, bool bSort)
    {
        List<ListItem> lstSelected = new List<ListItem>();
        foreach (ListItem liSelcted in lstFrom.Items)
        {
            // If List item is selected then move it to Selected Output field list and add to list objects
            if ((OnlySelected && liSelcted.Selected) || (!OnlySelected))
            {
                liSelcted.Selected = false;
                lstTo.Items.Add(liSelcted);
                lstSelected.Add(liSelcted);
            }
        }

        // remove all selected list items from output fields
        for (int i = 0; i < lstSelected.Count; i++)
        {
            lstFrom.Items.Remove(lstSelected[i] as ListItem);
        }
        // sort FROI E-Mail Recipients Field
        if (bSort == true && lstContractorType.Items.Count > 0)
        {
            DataTable dtFields = new DataTable();
            dtFields.Columns.Add(new DataColumn("PK_LU_Location_ID", typeof(decimal)));
            dtFields.Columns.Add(new DataColumn("dba", typeof(string)));

            foreach (ListItem itmField in lstContractorType.Items)
            {
                DataRow drField = dtFields.NewRow();
                drField["PK_LU_Location_ID"] = itmField.Value;
                drField["dba"] = itmField.Text;
                dtFields.Rows.Add(drField);
            }
            dtFields.DefaultView.Sort = "dba ASC";
            lstContractorType.Items.Clear();
            lstContractorType.DataSource = dtFields.DefaultView;
            lstContractorType.DataTextField = "dba";
            lstContractorType.DataValueField = "PK_LU_Location_ID";
            lstContractorType.DataBind();
        }
        // If Selected output list is empty then Disable Moving buttons and Up-Down images
        if (lstAllowAccessCT.Items.Count <= 0)
        {
            btnDeselectFields.Enabled = false;
            btnDeselectAllFields.Enabled = false;//imgUp.Enabled = imgDown.Enabled = 
        }
        else
        {
            btnDeselectFields.Enabled = true;
            btnDeselectAllFields.Enabled = true;//imgUp.Enabled = imgDown.Enabled = 
        }
        // IF output Fields is Empty
        if (lstContractorType.Items.Count <= 0)
        {
            btnSelectFields.Enabled = false;
            btnSelectAllFields.Enabled = false;
        }
        else
        {
            btnSelectFields.Enabled = true;
            btnSelectAllFields.Enabled = true;
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

}