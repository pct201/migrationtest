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
using System.Collections.Generic;
using System.IO;

public partial class Employee_PropertyDriver : System.Web.UI.Page
{
    #region
    int m_intRetval = -1;

    int m_intEmployeeId = 0;

    public int m_intPreventAdd = 0;
    string strSortExp = string.Empty;
    public RIMS_Base.Biz.CPropertyDriver m_objPropertyDriver;
    List<RIMS_Base.CPropertyDriver> lstPropertyDriver = null;
    public RIMS_Base.Biz.CGeneral m_objState;
    List<RIMS_Base.CGeneral> lstState = null;
    public RIMS_Base.Biz.CGeneral m_objDState;
    List<RIMS_Base.CGeneral> lstDState = null;

    public RIMS_Base.Biz.CGeneral m_objEntity;
    List<RIMS_Base.CGeneral> lstEntity = null;

    public RIMS_Base.Biz.CGeneral m_objGender;
    List<RIMS_Base.CGeneral> lstGender = null;

    public RIMS_Base.Biz.CGeneral m_objStatus;
    List<RIMS_Base.CGeneral> lstStatus = null;


    public RIMS_Base.Biz.cEmployee m_objLicType;
    List<RIMS_Base.cEmployee> lstLicType = null;
            
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    ListItem m_lstCommon;

    public string m_strPath = string.Empty;
    public string m_strFolderName = "Property_Drivers";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Property_Drivers/");
        dvSearch.Visible = true;
        dvAttachDetails.Visible = false;

        //((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyUp", "return ZipMasking(event,this.value,this);");
        //((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyPress", "return CheckNum(this);");


        if (!IsPostBack)
        {
            btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvPropertyDriver','Delete');");
            btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
            mvPropertyDriver.ActiveViewIndex = 0;

            gvPropertyDriver.PageSize = 10;
            btnRemove.Visible = false;
            btnMail.Visible = false;
            gvPropertyDriver.DataSource = BindPropertyDrivers();
            gvPropertyDriver.DataBind();

            ddlPage.DataBind();
            ddlPage.SelectedValue = "10";

            if (gvPropertyDriver.PageCount == 0)
            { lblPageInfo.Text = "Page 0 of 0"; }
            else
            {
                lblPageInfo.Text = "Page 1 of " + gvPropertyDriver.PageCount.ToString();
            }
            txtPageNo.Text = "1";
            ViewState["PreventAdd"] = "N";

        }
        
    }

    private List<RIMS_Base.CPropertyDriver> BindPropertyDrivers()
    {
        try
        {
            m_objPropertyDriver = new RIMS_Base.Biz.CPropertyDriver();
            lstPropertyDriver = new List<RIMS_Base.CPropertyDriver>();
            lstPropertyDriver = null;
            if (txtSearch.Text != string.Empty)
            {
                lstPropertyDriver = m_objPropertyDriver.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstPropertyDriver = m_objPropertyDriver.GetAll();
            }
            lblPropertyDriversTotal.Text = "Total Property Drivers : " + lstPropertyDriver.Count.ToString();
            return lstPropertyDriver;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvPropertyDriver.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvPropertyDriver.PageCount)
            {
                gvPropertyDriver.PageIndex = gvPropertyDriver.PageCount;
                txtPageNo.Text = gvPropertyDriver.PageCount.ToString();
            }
            else
            {
                gvPropertyDriver.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvPropertyDriver.PageCount.ToString();
            gvPropertyDriver.DataSource = BindPropertyDrivers();
            gvPropertyDriver.DataBind();
            lblPropertyDriversTotal.Text = "Total Employee : " + lstPropertyDriver.Count.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvPropertyDriver.PageIndex <= gvPropertyDriver.PageCount)
            {
                gvPropertyDriver.PageIndex = gvPropertyDriver.PageIndex + 1;
                GeneralSorting();

                lblPageInfo.Text = "Page " + Convert.ToString(gvPropertyDriver.PageIndex + 1) + " of " + gvPropertyDriver.PageCount.ToString();
                lblPropertyDriversTotal.Text = "Total Property Drivers : " + lstPropertyDriver.Count.ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvPropertyDriver.PageIndex <= gvPropertyDriver.PageCount)
            {
                gvPropertyDriver.PageIndex = gvPropertyDriver.PageIndex - 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvPropertyDriver.PageIndex + 1) + " of " + gvPropertyDriver.PageCount.ToString();
                lblPropertyDriversTotal.Text = "Total Property Drivers : " + lstPropertyDriver.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objPropertyDriver = new RIMS_Base.Biz.CPropertyDriver();
            m_intRetval = m_objPropertyDriver.PropertyDriver_Delete(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvPropertyDriver.ActiveViewIndex = 0;
                gvPropertyDriver.DataSource = BindPropertyDrivers();
                gvPropertyDriver.DataBind();
            }
            lblPropertyDriversTotal.Text = "Total Property Drivers : " + lstPropertyDriver.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            mvPropertyDriver.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void Bindfv(FormViewMode fvMode)
    {
        try
        {

            if (fvMode == FormViewMode.Insert)
                fvPropertyDriver.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvPropertyDriver.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvPropertyDriver.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objPropertyDriver = new RIMS_Base.Biz.CPropertyDriver();
                lstPropertyDriver = new List<RIMS_Base.CPropertyDriver>();
                lstPropertyDriver = m_objPropertyDriver.GetPropertyDriverByID(m_intEmployeeId);
                fvPropertyDriver.DataSource = lstPropertyDriver;

            }            
            fvPropertyDriver.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    m_objEmployee = new RIMS_Base.Biz.cEmployee();
        //    lstEmployee = new List<RIMS_Base.cEmployee>();
        //    lstEmployee = m_objEmployee.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
        //    gvEmployee.DataSource = lstEmployee;
        //    gvEmployee.DataBind();
        //    if (gvEmployee.PageCount == 0)
        //    { lblPageInfo.Text = "Page 0 of 0"; }
        //    else
        //    {
        //        lblPageInfo.Text = "Page 1 of " + gvEmployee.PageCount.ToString();
        //    }
        //    lblEmployeeTotal.Text = "Total Employee : " + lstEmployee.Count.ToString();
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objPropertyDriver = new RIMS_Base.Biz.CPropertyDriver();
                if (fvPropertyDriver.CurrentMode == FormViewMode.Insert)
                {
                    m_objPropertyDriver.PK_Property_Drivers = 0;
                }
                else
                {
                    m_objPropertyDriver.PK_Property_Drivers = Convert.ToInt32(((Label)fvPropertyDriver.FindControl("lblPkEmployeeId")).Text);
                }

                if ((((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).SelectedValue) != "0")
                    m_objPropertyDriver.PK_Driver_Status = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).SelectedValue.ToString());

                if ((((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).SelectedValue) != "0")
                    m_objPropertyDriver.PK_Entity = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).SelectedValue.ToString());

                m_objPropertyDriver.Last_Name = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtLastName")).Text);
                m_objPropertyDriver.Middle_Name = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtMiddleName")).Text);
                m_objPropertyDriver.Management = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rdlManagement")).SelectedValue);
                m_objPropertyDriver.Interstate = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rdlInterstate")).SelectedValue);
               
                if (((TextBox)fvPropertyDriver.FindControl("txtLastMVR")).Text != string.Empty)
                    m_objPropertyDriver.Last_MVR = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtLastMVR")).Text);
               

                if (((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text != string.Empty)
                    m_objPropertyDriver.Status_As_Of = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text);
               
                //m_objPropertyDriver.Status_As_Of = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text);
                m_objPropertyDriver.Work_Telephone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtWorkTeleNo")).Text);
                m_objPropertyDriver.First_Name =((TextBox)fvPropertyDriver.FindControl("txtFirstName")).Text.Replace("'","''");
                m_objPropertyDriver.GVW = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rblGrossVehWeight")).SelectedValue);
                m_objPropertyDriver.Address_1 = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAddress1")).Text.Replace("'", "''"));
                m_objPropertyDriver.Address_2 = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAddress2")).Text.Replace("'", "''"));
                m_objPropertyDriver.Zip_Code = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Text);

                m_objPropertyDriver.City = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtCity")).Text.Replace("'", "''"));

                if ((((DropDownList)fvPropertyDriver.FindControl("ddlState")).SelectedValue) != "0")
                    m_objPropertyDriver.State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlState")).SelectedValue.ToString());


                if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue) != "0")
                    m_objPropertyDriver.FK_DL_State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue.ToString());

                m_objPropertyDriver.Social_Security_Number = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSSN")).Text);

                if (((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text != string.Empty)
                    m_objPropertyDriver.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text);
               

               // m_objPropertyDriver.Date_Of_Birth = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text);
                m_objPropertyDriver.Home_Telephone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtHomeTeleNo")).Text);

                m_objPropertyDriver.Cell_Phone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtCellTeleNo")).Text);
                m_objPropertyDriver.Pager = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtPagerTeleNo")).Text);
                m_objPropertyDriver.Email = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtEmail")).Text);
                if ((((DropDownList)fvPropertyDriver.FindControl("ddlGender")).SelectedValue) != "0")
                    m_objPropertyDriver.FK_Gender = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlGender")).SelectedValue.ToString());

                if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue) != "0")
                    m_objPropertyDriver.FK_DL_State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue.ToString());

                if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue) != "0")
                    m_objPropertyDriver.FK_Drivers_License_Class = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue.ToString());



                //if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue) != "0")
                //    m_objPropertyDriver.FK_Drivers_License_Class = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue.ToString());

                m_objPropertyDriver.Restrictions = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicRestrictions")).Text.Replace("'", "''"));

                if (((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text != string.Empty)
                    m_objPropertyDriver.DL_Begin_Date = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text);
               

               // m_objPropertyDriver.DL_Begin_Date = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text);
                m_objPropertyDriver.Drivers_License_Number = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicNo")).Text.Replace("'", "''"));

                m_objPropertyDriver.Drivers_License_Class = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicClass")).Text.Replace("'", "''"));
                m_objPropertyDriver.Endorsements = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicEndorsement")).Text.Replace("'", "''"));

                if (((TextBox)fvPropertyDriver.FindControl("txtDrLicExpireDate")).Text != string.Empty)
                    m_objPropertyDriver.DL_End_Date = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDrLicExpireDate")).Text);



                m_objPropertyDriver.Supervisor_Last = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorLname")).Text.Replace("'", "''"));
                m_objPropertyDriver.Supervisor_Title = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorTitle")).Text.Replace("'", "''"));
                m_objPropertyDriver.Supervisor_First = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorFname")).Text.Replace("'", "''"));
                m_objPropertyDriver.Supervisor_Phone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorTeleNo")).Text);

                m_objPropertyDriver.Notes = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtNotes")).Text.Replace("'", "''"));
                
                m_intRetval = m_objPropertyDriver.PropertyDriver_InsertUpdate(m_objPropertyDriver);
                if (m_intRetval >= 0)
                {
                    mvPropertyDriver.ActiveViewIndex = 0;
                    gvPropertyDriver.DataSource = BindPropertyDrivers();
                    gvPropertyDriver.DataBind();
                }

           }
           else
           {
               ViewState["PreventAdd"] = "N";
               mvPropertyDriver.ActiveViewIndex = 0;
               gvPropertyDriver.DataSource = BindPropertyDrivers();
               gvPropertyDriver.DataBind();
           }
           dvSearch.Visible = true;

       }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            mvPropertyDriver.ActiveViewIndex = 0;
            gvPropertyDriver.DataSource = BindPropertyDrivers();
            gvPropertyDriver.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gvPropertyDriver_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvPropertyDriver.ActiveViewIndex = 1;
                m_intEmployeeId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                    gvAttachmentDetails.Columns[0].Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }
            else if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                btnRemove.Visible = false;
                btnMail.Visible = false;
                gvAttachmentDetails.Columns[0].Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvPropertyDriver_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstPropertyDriver = new List<RIMS_Base.CPropertyDriver>();
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = e.SortExpression;

            lstPropertyDriver = BindPropertyDrivers();
            if (ViewState["SortExp"] != null)
                lstPropertyDriver.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CPropertyDriver>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvPropertyDriver.DataSource = lstPropertyDriver;
            gvPropertyDriver.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvPropertyDriver_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvPropertyDriver.CurrentMode != FormViewMode.ReadOnly)
            {
               ((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyUp", "return ZipMasking(event,this.value,this);");
               ((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyPress", "return CheckNum(this);");


                ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).DataSource = GetGender();
                ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).DataTextField = "FLD_Gender_Desc";
                ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).DataValueField = "PK_Gender_ID";
                ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).DataBind();
                m_lstCommon = new ListItem("--Select Gender--", "0");
                ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).DataSource = GetStatus();
                ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).DataTextField = "FLD_Status_Desc";
                ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).DataValueField = "PK_Status_ID";
                ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).DataBind();
                m_lstCommon = new ListItem("--Select Status--", "0");
                ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).DataSource = GetState();
                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).DataTextField = "FLD_state";
                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).DataValueField = "PK_ID";
                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).DataBind();
                 m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).DataSource = GetState();
                ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).DataTextField = "FLD_state";
                ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).DataValueField = "PK_ID";
                ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).DataBind();
                 m_lstCommon = new ListItem("--Select State--", "0");
                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).Items.Insert(0, m_lstCommon);

                 ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).DataSource = GetEntity();
                 ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).DataTextField = "Entity_Description";
                 ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).DataValueField = "PK_Entity";
                 ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).DataBind();
                 m_lstCommon = new ListItem("--Select Entity --", "0");
                 ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).Items.Insert(0, m_lstCommon);

                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).DataSource = GetLicenseType();
                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).DataTextField = "LicenseType";
                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).DataValueField = "PK_ID";
                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).DataBind();
                 m_lstCommon = new ListItem("--Select License Type--", "0");
                 ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).Items.Insert(0, m_lstCommon);

                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).DataBind();
                 m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);
                ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).SelectedValue = "1";


            }

            if (fvPropertyDriver.CurrentMode == FormViewMode.Edit)
             {
                 ((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyUp", "return ZipMasking(event,this.value,this);");
                 ((TextBox)fvPropertyDriver.FindControl("txtZipCode")).Attributes.Add("onKeyPress", "return CheckNum(this);");



                if (lstPropertyDriver[0].State.ToString() != string.Empty)
                ((DropDownList)fvPropertyDriver.FindControl("ddlState")).SelectedValue = lstPropertyDriver[0].State.ToString();

                if (lstPropertyDriver[0].FK_DL_State.ToString() != string.Empty)
                ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue = lstPropertyDriver[0].FK_DL_State.ToString();

                if (lstPropertyDriver[0].FK_Drivers_License_Class.ToString() != string.Empty)
                    ((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue = lstPropertyDriver[0].FK_Drivers_License_Class.ToString();

                if (lstPropertyDriver[0].FK_Gender.ToString() != string.Empty)
                    ((DropDownList)fvPropertyDriver.FindControl("ddlGender")).SelectedValue = lstPropertyDriver[0].FK_Gender.ToString();

                if (lstPropertyDriver[0].PK_Driver_Status.ToString() != string.Empty)
                    ((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).SelectedValue = lstPropertyDriver[0].PK_Driver_Status.ToString();

                if (lstPropertyDriver[0].PK_Entity.ToString() != string.Empty)
                    ((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).SelectedValue = lstPropertyDriver[0].PK_Entity.ToString();
                
                  ((RadioButtonList)fvPropertyDriver.FindControl("rdlManagement")).SelectedValue = lstPropertyDriver[0].Management;

                  ((RadioButtonList)fvPropertyDriver.FindControl("rdlInterstate")).SelectedValue = lstPropertyDriver[0].Interstate;

                //  ((RadioButtonList)fvPropertyDriver.FindControl("rblGrossVehWeight")).SelectedValue = lstPropertyDriver[0].GVW;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }   
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvPropertyDriver.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvPropertyDriver.DataSource = BindPropertyDrivers();
            gvPropertyDriver.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvPropertyDriver.PageCount.ToString();
            txtPageNo.Text = "1";
            lblPropertyDriversTotal.Text = "Total Property Drivers :" + lstPropertyDriver.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {

       
            dvSearch.Visible = false;
            if (fvPropertyDriver.CurrentMode == FormViewMode.Insert)
           {
               if (ViewState["PreventAdd"].ToString() == "N")
               {
                   m_objPropertyDriver = new RIMS_Base.Biz.CPropertyDriver();
                   if (fvPropertyDriver.CurrentMode == FormViewMode.Insert)
                   {
                       m_objPropertyDriver.PK_Property_Drivers = 0;
                   }
                   else
                   {
                       m_objPropertyDriver.PK_Property_Drivers = Convert.ToInt32(((Label)fvPropertyDriver.FindControl("lblPkEmployeeId")).Text);
                   }

                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).SelectedValue) != "0")
                       m_objPropertyDriver.PK_Driver_Status = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlStatus")).SelectedValue.ToString());

                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).SelectedValue) != "0")
                       m_objPropertyDriver.PK_Entity = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlEntity")).SelectedValue.ToString());

                   m_objPropertyDriver.Last_Name = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtLastName")).Text);
                   m_objPropertyDriver.Middle_Name = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtMiddleName")).Text);
                   m_objPropertyDriver.Management = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rdlManagement")).SelectedValue);
                   m_objPropertyDriver.Interstate = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rdlInterstate")).SelectedValue);
                   // m_objPropertyDriver.Last_MVR = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtLastMVR")).Text);

                   if (((TextBox)fvPropertyDriver.FindControl("txtLastMVR")).Text != string.Empty)
                       m_objPropertyDriver.Last_MVR = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtLastMVR")).Text);


                   if (((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text != string.Empty)
                       m_objPropertyDriver.Status_As_Of = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text);



                   //m_objPropertyDriver.Status_As_Of = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAsof")).Text);
                   m_objPropertyDriver.Work_Telephone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtWorkTeleNo")).Text);
                   m_objPropertyDriver.First_Name = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtFirstName")).Text);
                   m_objPropertyDriver.GVW = Convert.ToString(((RadioButtonList)fvPropertyDriver.FindControl("rblGrossVehWeight")).SelectedValue);
                   m_objPropertyDriver.Address_1 = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAddress1")).Text);
                   m_objPropertyDriver.Address_2 = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtAddress2")).Text);

                   m_objPropertyDriver.City = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtCity")).Text);

                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlState")).SelectedValue) != "0")
                       m_objPropertyDriver.State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlState")).SelectedValue.ToString());


                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue) != "0")
                       m_objPropertyDriver.FK_DL_State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue.ToString());

                   m_objPropertyDriver.Social_Security_Number = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSSN")).Text);

                   if (((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text != string.Empty)
                       m_objPropertyDriver.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text);


                   // m_objPropertyDriver.Date_Of_Birth = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDOB")).Text);
                   m_objPropertyDriver.Home_Telephone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtHomeTeleNo")).Text);

                   m_objPropertyDriver.Cell_Phone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtCellTeleNo")).Text);
                   m_objPropertyDriver.Pager = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtPagerTeleNo")).Text);
                   m_objPropertyDriver.Email = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtEmail")).Text);
                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlGender")).SelectedValue) != "0")
                       m_objPropertyDriver.FK_Gender = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlGender")).SelectedValue.ToString());

                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue) != "0")
                       m_objPropertyDriver.FK_DL_State = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicState")).SelectedValue.ToString());

                   if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue) != "0")
                       m_objPropertyDriver.FK_Drivers_License_Class = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue.ToString());



                   //if ((((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue) != "0")
                   //    m_objPropertyDriver.FK_Drivers_License_Class = Convert.ToDecimal(((DropDownList)fvPropertyDriver.FindControl("ddlDrLicType")).SelectedValue.ToString());

                   m_objPropertyDriver.Restrictions = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicRestrictions")).Text);

                   if (((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text != string.Empty)
                       m_objPropertyDriver.DL_Begin_Date = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text);


                   // m_objPropertyDriver.DL_Begin_Date = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicIssueDate")).Text);
                   m_objPropertyDriver.Drivers_License_Number = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicNo")).Text);

                   m_objPropertyDriver.Drivers_License_Class = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicClass")).Text);
                   m_objPropertyDriver.Endorsements = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicEndorsement")).Text);

                   if (((TextBox)fvPropertyDriver.FindControl("txtDrLicExpireDate")).Text != string.Empty)
                       m_objPropertyDriver.DL_End_Date = Convert.ToDateTime(((TextBox)fvPropertyDriver.FindControl("txtDrLicExpireDate")).Text);


                   // m_objPropertyDriver.DL_End_Date = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtDrLicExpireDate")).Text);

                   m_objPropertyDriver.Supervisor_Last = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorLname")).Text);
                   m_objPropertyDriver.Supervisor_Title = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorTitle")).Text);
                   m_objPropertyDriver.Supervisor_First = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorFname")).Text);
                   m_objPropertyDriver.Supervisor_Phone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorTeleNo")).Text);

                   m_objPropertyDriver.Notes = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtNotes")).Text);
                   m_objPropertyDriver.Supervisor_Phone = Convert.ToString(((TextBox)fvPropertyDriver.FindControl("txtSupervisorTeleNo")).Text);


                   //        m_objEmployee.Update_Date = System.DateTime.Now;
                   //        m_objEmployee.Updated_By = "1";

                   m_intRetval = m_objPropertyDriver.PropertyDriver_InsertUpdate(m_objPropertyDriver);

                   ((Label)fvPropertyDriver.FindControl("lblPkEmployeeId")).Text = m_intRetval.ToString();
                   ViewState["PreventAdd"] = "Y";
               }
                    if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();
                    if (lstAttachment.Count > 0)
                    {
                        btnRemove.Visible = true;
                        btnMail.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                    }
                }
            }
        }
        else
        {
            dvAttachDetails.Visible = true;
            AddAttachment();
            if (m_intRetval >= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                    gvAttachmentDetails.Columns[0].Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
        }











        //dvSearch.Visible = false;
        //if (fvEmployee.CurrentMode == FormViewMode.Insert)
        //{
        //    if (ViewState["PreventAdd"].ToString() == "N")
        //    {
        //        m_objEmployee = new RIMS_Base.Biz.cEmployee();
        //        if (fvEmployee.CurrentMode == FormViewMode.Insert)
        //        {
        //            m_objEmployee.PK_Employee_ID = 0;
        //        }
        //        else
        //        {
        //            m_objEmployee.PK_Employee_ID = Convert.ToInt32(((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text);
        //        }
        //        m_objEmployee.Employee_Id = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmployeeId")).Text);
        //        m_objEmployee.First_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtFirstName")).Text);
        //        m_objEmployee.Employee_Address_1 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress1")).Text);
        //        m_objEmployee.Employee_City = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCity")).Text);
        //        m_objEmployee.Employee_Zip_Code = Convert.ToString(((TextBox)fvEmployee.FindControl("txtZip")).Text);
        //        m_objEmployee.Employee_Cell_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtCellTeleNo")).Text);
        //        m_objEmployee.FK_Marital_Status = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlMaritalStatus")).SelectedValue);
        //        if (((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text != string.Empty)
        //            m_objEmployee.Number_Of_Dependents = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtNoOfDependents")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtDeathDate")).Text != string.Empty)
        //            m_objEmployee.Date_Of_Death = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDeathDate")).Text);
        //        m_objEmployee.Last_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtLastName")).Text);
        //        m_objEmployee.Middle_Name = Convert.ToString(((TextBox)fvEmployee.FindControl("txtMiddleName")).Text);
        //        m_objEmployee.Employee_Address_2 = Convert.ToString(((TextBox)fvEmployee.FindControl("txtAddress2")).Text);
        //        m_objEmployee.Employee_State = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlState")).SelectedValue);
        //        m_objEmployee.Employee_Home_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtHomeTeleNo")).Text);
        //        m_objEmployee.Social_Security_Number = Convert.ToString(((TextBox)fvEmployee.FindControl("txtSSN")).Text);
        //        m_objEmployee.Sex = Convert.ToString(((RadioButtonList)fvEmployee.FindControl("rdlSex")).SelectedValue);
        //        if (((TextBox)fvEmployee.FindControl("txtDOB")).Text != string.Empty)
        //            m_objEmployee.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDOB")).Text);
        //        if ((((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedValue) != "0")
        //            m_objEmployee.Drivers_License_State = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLState")).SelectedItem.Text);
        //        if ((((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedValue) != "0")
        //            m_objEmployee.Drivers_License_Type = Convert.ToString(((DropDownList)fvEmployee.FindControl("ddlDLType")).SelectedItem.Text);
        //        m_objEmployee.Drivers_License_Restrictions = Convert.ToString(((TextBox)fvEmployee.FindControl("txtRDS")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtDateIssued")).Text != string.Empty)
        //            m_objEmployee.Drivers_License_Issued = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateIssued")).Text);
        //        m_objEmployee.Drivers_License_Number = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLN")).Text);
        //        m_objEmployee.Drivers_License_Class = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLC")).Text);
        //        m_objEmployee.Drivers_License_Endorsements = Convert.ToString(((TextBox)fvEmployee.FindControl("txtDLE")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtDateExpired")).Text != string.Empty)
        //            m_objEmployee.Drivers_License_Expires = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtDateExpired")).Text);
        //        m_objEmployee.Job_Title = Convert.ToString(((TextBox)fvEmployee.FindControl("txtJobtitle")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtSalary")).Text != string.Empty)
        //            m_objEmployee.Salary = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSalary")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtSupId")).Text != string.Empty)
        //            m_objEmployee.Supervisor = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtSupId")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtHireDate")).Text != string.Empty)
        //            m_objEmployee.Hire_Date = Convert.ToDateTime(((TextBox)fvEmployee.FindControl("txtHireDate")).Text);
        //        m_objEmployee.Inactive = Convert.ToString(((TextBox)fvEmployee.FindControl("txtActive")).Text);
        //        if (((TextBox)fvEmployee.FindControl("txtCCId")).Text != string.Empty)
        //            m_objEmployee.FK_Cost_Center = Convert.ToDecimal(((TextBox)fvEmployee.FindControl("txtCCId")).Text);
        //        m_objEmployee.Occupation_Description = Convert.ToString(((TextBox)fvEmployee.FindControl("txtOccuDesc")).Text);
        //        m_objEmployee.Work_Phone = Convert.ToString(((TextBox)fvEmployee.FindControl("txtWorkTeleNo")).Text);
        //        if ((((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue) != "0")
        //            m_objEmployee.FK_Job_Classification = Convert.ToDecimal(((DropDownList)fvEmployee.FindControl("ddlJobClassification")).SelectedValue);
        //        m_objEmployee.Email = Convert.ToString(((TextBox)fvEmployee.FindControl("txtEmail")).Text);
        //        m_objEmployee.Update_Date = System.DateTime.Now;
        //        m_objEmployee.Updated_By = "1";
        //        m_intRetval = m_objEmployee.Employee_InsertUpdate(m_objEmployee);
        //        ((Label)fvEmployee.FindControl("lblPkEmployeeId")).Text = m_intRetval.ToString();
        //        ViewState["PreventAdd"] = "Y";
        //    }
        //    if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
        //    {
        //        dvAttachDetails.Visible = true;

        //        AddAttachment();
        //        if (m_intRetval >= 0)
        //        {
        //            gvAttachmentDetails.DataSource = BindAttachmentDetails();
        //            gvAttachmentDetails.DataBind();
        //            if (lstAttachment.Count > 0)
        //            {
        //                btnRemove.Visible = true;
        //                btnMail.Visible = true;
        //            }
        //            else
        //            {
        //                btnRemove.Visible = false;
        //                btnMail.Visible = false;
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    dvAttachDetails.Visible = true;
        //    AddAttachment();
        //    if (m_intRetval >= 0)
        //    {
        //        gvAttachmentDetails.DataSource = BindAttachmentDetails();
        //        gvAttachmentDetails.DataBind();
        //        if (lstAttachment.Count > 0)
        //        {
        //            btnRemove.Visible = true;
        //            btnMail.Visible = true;
        //        }
        //        else
        //        {
        //            btnRemove.Visible = false;
        //            btnMail.Visible = false;
        //        }
        //    }
        //}



    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                // ((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Employee&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvPropertyDriver.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvPropertyDriver.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
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
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetState()
    {
        try
        {
            m_objState = new RIMS_Base.Biz.CGeneral();
            lstState = new List<RIMS_Base.CGeneral>();
            lstState = m_objState.GetAllState();
            return lstState;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    private List<RIMS_Base.CGeneral> GetEntity()
    {
        try
        {
            m_objEntity = new RIMS_Base.Biz.CGeneral();
            lstEntity = new List<RIMS_Base.CGeneral>();
            lstEntity = m_objEntity.GetAllEntity();
            return lstEntity;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    private List<RIMS_Base.cEmployee> GetLicenseType()
    {
        try
        {
            m_objLicType = new RIMS_Base.Biz.cEmployee();
            lstLicType = new List<RIMS_Base.cEmployee>();
            lstLicType = m_objLicType.GetLicenseType();
            return lstLicType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private List<RIMS_Base.CGeneral> GetGender()
    {
        try
        {
            m_objGender = new RIMS_Base.Biz.CGeneral();
            lstGender = new List<RIMS_Base.CGeneral>();
            lstGender = m_objGender.GetGender();
            return lstGender;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    private List<RIMS_Base.CGeneral> GetStatus()
    {
        try
        {
            m_objStatus = new RIMS_Base.Biz.CGeneral();
            lstStatus = new List<RIMS_Base.CGeneral>();
            lstStatus = m_objStatus.GetDriverStatus();
            return lstStatus;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }



    /// <summary>
    /// Get All Attachment Type.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetAttachmentType()
    {
        try
        {
            m_objAttachmentType = new RIMS_Base.Biz.CGeneral();
            lstAttachmentType = new List<RIMS_Base.CGeneral>();
            lstAttachmentType = m_objAttachmentType.GetAttachamentType();
            return lstAttachmentType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvPropertyDriver.FindControl("lblPkEmployeeId")).Text), "Property_Drivers");
            return lstAttachment;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            m_strFileName = GetCustomFileName() + ((FileUpload)fvPropertyDriver.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            ((FileUpload)fvPropertyDriver.FindControl("uplCommon")).SaveAs(m_strPath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Custom File Name.
    /// </summary>
    /// <returns></returns>
    private string GetCustomFileName()
    {
        try
        {
            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_strCustomFileName;
    }
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Property_Drivers";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvPropertyDriver.FindControl("lblPkEmployeeId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvPropertyDriver.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvPropertyDriver.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvPropertyDriver.FindControl("ddlAttachType")).SelectedValue = "1";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }
    private void GeneralSorting()
    {
        try
        {
            lstPropertyDriver = new List<RIMS_Base.CPropertyDriver>();
            lstPropertyDriver = BindPropertyDrivers();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstPropertyDriver.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CPropertyDriver>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvPropertyDriver.DataSource = lstPropertyDriver;
            gvPropertyDriver.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
}
