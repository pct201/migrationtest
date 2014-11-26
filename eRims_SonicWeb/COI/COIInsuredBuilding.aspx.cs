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

public partial class COI_COIInsuredBuilding : clsBasePage
{
    #region "Properties"
    string _strOperation = "";
    /// <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string StrOperation
    {
        get
        {
            return _strOperation;
        }
    }
    // FK to indicate COI Insured Building is for which COI
    public int FK_COI
    {
        get
        {
            return clsGeneral.GetInt(ViewState["COI"]);
        }
        set { ViewState["COI"] = value; }

    }

    /// <summary>
    /// Encrypted primary key for str_Buildings_Number
    /// </summary>
    public string str_Buildings_Number
    {
        get
        {
            if (!clsGeneral.IsNull(ViewState["str_Buildings_Number"]))
                return (Convert.ToString(ViewState["str_Buildings_Number"]));
            else
                return "";
        }
        set { ViewState["str_Buildings_Number"] = value; }
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        // if page is loaded first time.
        if (!IsPostBack)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);

            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if COI's FK is not passed redirect to default page.
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                {
                    // set FK Coi.
                    FK_COI = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));
                    //bind dropdowns
                    BindDropdowns();

                    if (FK_COI > 0)
                    {
                        ucCtrlCOIInfo.PK_COIs = FK_COI;
                        ucCtrlCOIInfo.BindrCOIInfo();
                    }
                    else
                    {
                        ucCtrlCOIInfo.Visible = false;
                    }

                    // if operations(view or edit) is passed in query string.
                    if (!clsGeneral.IsNull(Request.QueryString["op"]))
                    {
                        // if id is passed set primary key.
                        if (!clsGeneral.IsNull(Request.QueryString["id"]))
                        {
                            str_Buildings_Number = Encryption.Decrypt(Convert.ToString(Request.QueryString["id"]));
                        }
                        _strOperation = Request.QueryString["op"].ToString();
                        if (_strOperation == "view")
                        {
                            dvView.Style["Display"] = "block";
                            BindDetailsForView();
                        }
                        else
                        {
                            if (App_Access == AccessType.Administrative_Access)
                                BindDetailsForEdit();
                            else
                                Response.Redirect(Request.Url.ToString().Replace("edit", "view"));
                        }
                        //if (FK_COI > 0)
                        //{
                        //    ucCtrlCOIInfo.PK_COIs = FK_COI;
                        //    ucCtrlCOIInfo.BindrCOIInfo();
                        //}
                    }
                    else
                    {
                         if (App_Access != AccessType.Administrative_Access)
                            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
                if (Request.QueryString["op"] != "view")
                    SetValidations();
            }
            txtBuildingNumber.Focus();
        }
    }

    #endregion

    # region " Private Methods "

    /// <summary>
    /// Binds Dropdown for State 
    /// </summary>
    private void BindDropdowns()
    {
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");
    }

    #endregion

    #region "Bind Details for Edit or View"

    /// <summary>
    /// Displays the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["Display"] = "None";
        if (Session["dt_Building"] != null)
        {
            DataTable dtSeesion = (DataTable)Session["dt_Building"];
            //DataRow[] drArr = null;
            //drArr = dtSeesion.Select("[Building_Number]='" + Convert.ToString(str_Buildings_Number) + "'");
            DataRow[] drDetails = dtSeesion.Select("[Building_Number]='" + Convert.ToString(str_Buildings_Number) + "'");
            if (drDetails.Length > 0)
            {
                foreach (DataRow drDetail in drDetails)
                {
                    txtBuildingNumber.Text = Convert.ToString(drDetail["Building_Number"]);
                    txtAddress1.Text = Convert.ToString(drDetail["Address_1"]);
                    txtAddress2.Text = Convert.ToString(drDetail["Address_2"]);
                    txtCity.Text = Convert.ToString(drDetail["City"]);
                    drpState.SelectedValue = Convert.ToString(drDetail["FK_State"]);
                    txtZipCode.Text = Convert.ToString(drDetail["Zip"]);
                }
            }
        }
    }

    /// <summary>
    ///Dispalys the page in view mode 
    /// </summary>
    private void BindDetailsForView()
    {
        dvEdit.Style["Display"] = "None";
        // create object for curernt COI Insured Building
        if (str_Buildings_Number == "")
            str_Buildings_Number = "0";
        clsCOI_Insureds_Buildings objclsCOI_Insureds_Buildings = new clsCOI_Insureds_Buildings(Convert.ToDecimal(str_Buildings_Number));
        // set values       
        lblBuildingNumber.Text = objclsCOI_Insureds_Buildings.Building_Number;
        lblAddress1.Text = objclsCOI_Insureds_Buildings.Address_1;
        lblAddress2.Text = objclsCOI_Insureds_Buildings.Address_2;
        lblCity.Text = objclsCOI_Insureds_Buildings.City;
        if (objclsCOI_Insureds_Buildings.FK_State != null)
            lblState.Text = new COI_State((decimal)objclsCOI_Insureds_Buildings.FK_State).FLD_state;
        lblZipCode.Text = objclsCOI_Insureds_Buildings.Zip;

    }
    #endregion

    #region "Control Events"

    /// <summary>
    /// Handle Save Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // check page is valid or not.        
        if (Page.IsValid)
        {
            GetDataTableValues();
            btnReturn_Click(sender, e);
        }
    }

    /// <summary>
    /// Handle Return Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        // redirect to coi page without changes done to Insured band       
        if (!clsGeneral.IsNull(Request.QueryString["op"]))
            Response.Redirect("COIAddEdit.aspx?op=" + Request.QueryString["op"] + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=1&sv=1");
        else
            Response.Redirect("COIAddEdit.aspx?op=edit" + "&coi=" + Request.QueryString["coi"] + "&id=" + Encryption.Encrypt(FK_COI.ToString()) + "&pnl=1&sv=1");
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

        #region "Insureds"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(96).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {

                case "Building Number":
                    strCtrlsIDs += txtBuildingNumber.ClientID + ",";
                    strMessages += "Please enter Building Number" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress1.ClientID + ",";
                    strMessages += "Please enter Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress2.ClientID + ",";
                    strMessages += "Please enter Address 2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpState.ClientID + ",";
                    strMessages += "Please select State" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZipCode.ClientID + ",";
                    strMessages += "Please enter Zip Code" + ",";
                    Span9.Style["display"] = "inline-block";
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
    /// Stores the user entered value in session that can be used in next page for searching
    /// </summary>
    private void GetDataTableValues()
    {
        //create datatable for storing all values
        DataTable dtBuilding = new DataTable();

        //add columns for each value in data table
        DataColumn dcAutoID = new DataColumn("PK_COI_Insureds_Buildings");
        dcAutoID.DataType = Type.GetType("System.Int32");
        dtBuilding.Columns.Add(dcAutoID);
        dcAutoID.AutoIncrement = true;
        dcAutoID.AutoIncrementSeed = 1;
        dcAutoID.ReadOnly = true;


        DataColumn dcBuildingNumber = new DataColumn("Building_Number");
        dcBuildingNumber.DataType = Type.GetType("System.String");
        dtBuilding.Columns.Add(dcBuildingNumber);

        DataColumn dcAddress1 = new DataColumn("Address_1");
        dcAddress1.DataType = Type.GetType("System.String");
        dtBuilding.Columns.Add(dcAddress1);

        DataColumn dcAddress2 = new DataColumn("Address_2");
        dcAddress2.DataType = Type.GetType("System.String");
        dtBuilding.Columns.Add(dcAddress2);

        DataColumn dcCity = new DataColumn("City");
        dcCity.DataType = Type.GetType("System.String");
        dtBuilding.Columns.Add(dcCity);

        DataColumn dcState = new DataColumn("FK_State");
        dcState.DataType = Type.GetType("System.Int32");
        dtBuilding.Columns.Add(dcState);

        DataColumn dcZip = new DataColumn("Zip");
        dcZip.DataType = Type.GetType("System.String");
        dtBuilding.Columns.Add(dcZip);

        // add a row in data table
        DataRow drBuilding = dtBuilding.NewRow();

        // store values in each column from the page controls
        drBuilding["Building_Number"] = txtBuildingNumber.Text.Trim().Replace("'", "");
        drBuilding["Address_1"] = txtAddress1.Text.Trim().Replace("'", "");
        drBuilding["Address_2"] = txtAddress2.Text.Trim().Replace("'", "");
        drBuilding["City"] = txtCity.Text.Trim().Replace("'", "");
        drBuilding["FK_State"] = (drpState.SelectedIndex == 0) ? 0 : Convert.ToInt32(drpState.SelectedValue);
        drBuilding["Zip"] = txtZipCode.Text.Trim().Replace("'", "");
        dtBuilding.Rows.Add(drBuilding);

        //Check Edit Mode
        if (str_Buildings_Number != "")
        {
            DataTable dtSeesion = (DataTable)Session["dt_Building"];
            //Check Dublicate Building Number in Previous Building Grid Data
            for (int i = 0; i < dtSeesion.Rows.Count; i++)
            {

                if (Convert.ToString(dtSeesion.Rows[i]["Building_Number"]) == Convert.ToString(txtBuildingNumber.Text.Trim().Replace("'", "")))
                {
                    lblError.Text = "The  Building Number that you are trying to add already exists.";
                    dvSave.Style["display"] = "block";
                    if (str_Buildings_Number != Convert.ToString(txtBuildingNumber.Text.Trim().Replace("'", "")))
                        return;
                }
            }
            //Find Building Number in DataTable
            DataRow[] drDetails = dtSeesion.Select("[Building_Number]='" + Convert.ToString(str_Buildings_Number) + "'");
            if (drDetails.Length > 0)
            {
                //First Remove Building Number Row in DataTable and After Import in Pageing Data
                dtSeesion.Rows.Remove(drDetails[0]); // Remove Building Number Row in DataTable
                dtSeesion.AcceptChanges();
                dtSeesion.ImportRow(dtBuilding.Rows[0]); //Add New Row Import in DataTable
                Session["dt_Building"] = dtSeesion;
            }
        }
        else
        {
            //Check Seesion Data Store in Add Mode
            if (Session["dt_Building"] != null)
            {
                DataTable dtSeesion = (DataTable)Session["dt_Building"];
                for (int i = 0; i < dtSeesion.Rows.Count; i++)
                {
                    //Check Dublicate Building Number in Previous Building Grid Data
                    if (Convert.ToString(dtSeesion.Rows[i]["Building_Number"]) == Convert.ToString(txtBuildingNumber.Text.Trim().Replace("'", "")))
                    {
                        lblError.Text = "The  Building Number that you are trying to add already exists.";
                        dvSave.Style["display"] = "block";
                        return;
                    }
                }
                //Paging Data Import in Tempory Table
                dtSeesion.ImportRow(dtBuilding.Rows[0]);
                Session["dt_Building"] = dtSeesion; // //Temporary Table Data Store in Session
            }
            else
            {
                Session["dt_Building"] = dtBuilding; //store the whole data table in a session             
            }
        }
    }

    #endregion
}