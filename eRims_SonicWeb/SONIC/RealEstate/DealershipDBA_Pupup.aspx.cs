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

public partial class SONIC_RealEstate_DealershipDBA_Pupup : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : "dba"); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : "asc"); }
        set { ViewState["SortOrder"] = value; }
    }

    private decimal PK_LU_Location
    {
        get { return (!clsGeneral.IsNull(ViewState["PK_LU_Location"]) ? Convert.ToDecimal(ViewState["PK_LU_Location"]) : 0); }
        set
        {
            ViewState["PK_LU_Location"] = value;
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PK_LU_Location = 0;
            rdbActive.SelectedIndex = 0;
            BinDropDownList();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        _SortBy = "dba";
        _SortOrder = "asc";
        BindGrid();
    }

    private void BindGrid()
    {
        gvDealerShip.DataSource = LU_Location.SelectDealershipDBA(txtSearchDBA.Text.Trim().Replace("'", "''"), txtSearchCity.Text.Trim().Replace("'", "''"), txtSearchState.Text.Trim().Replace("'", "''"), _SortBy, _SortOrder);
        gvDealerShip.DataBind();
    }

    private void BinDropDownList()
    {
        ///States
        drpState.DataSource = State.SelectAll();
        drpState.DataTextField = "Fld_State";
        drpState.DataValueField = "PK_ID";
        drpState.DataBind();

        drpState.Items.Insert(0, new ListItem("--Select--", "0"));

        drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void gvDealerShip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDealerShip.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    protected void gvDealerShip_Sorting(object sender, GridViewSortEventArgs e)
    {
        // update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        //rebind grid
        BindGrid();
    }

    /// <summary>
    /// Handle Grid Row Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDealerShip_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row, gvDealerShip);
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

    protected void gvDealerShip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            PK_LU_Location = Convert.ToDecimal(e.CommandArgument);
            dvSearch.Style["display"] = "none";
            dvAddEdit.Style["display"] = "Block";
            BindDealershipDetail();
        }
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow, GridView gvSearch)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy, gvSearch);
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
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp, GridView gvSearch)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvSearch.Columns)
        {
            //check Sort Expression value
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvSearch.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        PK_LU_Location = 0;
        ClearControls();
        dvSearch.Style["display"] = "none";
        dvAddEdit.Style["display"] = "Block";
    }

    private void BindDealershipDetail()
    {
        LU_Location objLocation = new LU_Location(PK_LU_Location);

        txtDba.Text = objLocation.dba;
        txtLegalEntity.Text = objLocation.legal_entity;
        txtAddress1.Text = objLocation.Address_1;
        txtAddress2.Text = objLocation.Address_2;
        txtCity.Text = objLocation.City;
        drpState.SelectedValue = objLocation.State;
        txtZipCode.Text = objLocation.Zip_Code;
        BindCounty(drpState.SelectedItem.Text);
        drpCounty.SelectedValue = objLocation.County == string.Empty ? "0" : objLocation.County;
        txtTelePhone.Text = objLocation.Dealership_Telephone;
        txtYearofAquisition.Text = objLocation.Year_of_Acquisition;
        txtWebSite.Text = objLocation.Web_site;
        txtRIMNumber.Text = objLocation.RM_Location_Number;
        txtRegion.Text = objLocation.Region;
        txtAdpDms.Text = objLocation.ADP_DMS;
        txtLocationDesc.Text = objLocation.Location_Description;
        txtSonicLocationCode.Text = Convert.ToString(objLocation.Sonic_Location_Code);
        rdbActive.SelectedValue = objLocation.Active;
    }

    private void ClearControls()
    {
        foreach (Control ctrl in dvAddEdit.Controls)
        {
            if (ctrl.GetType() == typeof(System.Web.UI.WebControls.TextBox))
            {
                ((TextBox)ctrl).Text = "";
            }
        }
        drpCounty.SelectedIndex = 0;
        drpState.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dvSearch.Style["display"] = "Block";
        dvAddEdit.Style["display"] = "none";
        txtSearchState.Text = "";
        txtSearchDBA.Text = "";
        txtSearchCity.Text = "";
        gvDealerShip.DataSource = null;
        gvDealerShip.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            return;
        }

        LU_Location objLocation = new LU_Location();
        setProperties(objLocation);

        if (PK_LU_Location > 0)
        {
            objLocation.Update();
        }
        else
        {
            objLocation.Insert();
        }
        dvSearch.Style["display"] = "Block";
        dvAddEdit.Style["display"] = "none";
        txtSearchDBA.Text = txtDba.Text;
        BindGrid();
        ClearControls();
    }

    private void setProperties(LU_Location objLocation)
    {
        objLocation.PK_LU_Location_ID = PK_LU_Location;
        objLocation.dba = Convert.ToString(txtDba.Text);
        objLocation.legal_entity = Convert.ToString(txtLegalEntity.Text);
        objLocation.Address_1 = Convert.ToString(txtAddress1.Text);
        objLocation.Address_2 = Convert.ToString(txtAddress2.Text);
        objLocation.City = Convert.ToString(txtCity.Text);
        objLocation.State = drpState.SelectedValue;
        objLocation.Zip_Code = Convert.ToString(txtZipCode.Text);
        objLocation.County = drpCounty.SelectedValue;
        objLocation.Dealership_Telephone = Convert.ToString(txtTelePhone.Text);
        objLocation.Year_of_Acquisition = Convert.ToString(txtYearofAquisition.Text);
        objLocation.Web_site = Convert.ToString(txtWebSite.Text);
        objLocation.RM_Location_Number = Convert.ToString(txtRIMNumber.Text);
        objLocation.Region = Convert.ToString(txtRegion.Text);
        objLocation.ADP_DMS = Convert.ToString(txtAdpDms.Text.Replace(",", ""));
        objLocation.Location_Description = Convert.ToString(txtLocationDesc.Text);
        objLocation.Sonic_Location_Code = Convert.ToInt32(txtSonicLocationCode.Text);
        objLocation.Active = rdbActive.SelectedValue;
    }

    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpState.SelectedIndex > 0)
        {
            BindCounty(drpState.SelectedItem.Text);
        }
        else
        {
            drpCounty.Items.Clear();
            drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    private void BindCounty(string strState)
    {
        drpCounty.DataSource = County.SelectAllByState(strState);
        drpCounty.DataValueField = "PK_ID";
        drpCounty.DataTextField = "FLD_county";
        drpCounty.DataBind();

        drpCounty.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}
