using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
using RIMS_Base.Biz;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for ComboHelper
/// </summary>
public class ComboHelper
{
    public ComboHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    const string SELECT_STRING = "-- Select --";
    /// <summary>
    /// Used to Bind SONIC Location Number DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillSonicLocationNumber(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataSet dsData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "RM_Location_Number";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Fill Location
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLocationdbaFranchiseReport(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.DealershipDBAEntity(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "dba";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Location
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLocationLocationCodeFranchiseReport(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SonicLocationCode(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Sonic_Location_Code";
            ddlToFill.DataValueField = "Sonic_Location_Code";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdba(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// used to bind market by region
    /// </summary>
    /// <param name="listboxes"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    /// <param name="Regional"></param>
    public static void FillMarketByRegion(ListBox[] listboxes, int intID, bool booladdSelectAsFirstElement, string Regional)
    {
        DataTable dtData = ERIMS.DAL.clsLU_Market.SelectByRegion( Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Market";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in listboxes)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Market";
            ddlToFill.DataValueField = "PK_LU_Market";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillActiveLocationByRegionMarket(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement, string Regional, string MarketPKs)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectByRegionandMarket(Regional.ToString().TrimEnd(Convert.ToChar(",")), MarketPKs.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }


    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="Regional">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaByRegion(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement, string Regional)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        //string Regional = string.Empty;
        //DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        //if (dsRegion.Tables[0].Rows.Count > 0)
        //{
        //    foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
        //    {
        //        Regional += drRegion["Region"].ToString() + ",";
        //    }
        //    //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        //}
        //else
        //    Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectByRegion(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }


    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdba(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdba(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement, bool IsExposure)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (Convert.ToString(CurrentEmployee) == null)
            CurrentEmployee = 0;

        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += Convert.ToString(drRegion["Region"]) + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }

        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllForExposures(CurrentEmployee, Regional.TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="lstdba">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaList(ListBox[] lstdba, int intID)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllForExposures(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox lst in lstdba)
        {
            lst.Items.Clear();
            lst.DataTextField = "dba1";
            lst.DataValueField = "PK_LU_Location_ID";
            lst.DataSource = dtData;
            lst.DataBind();

            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lstitem = new ListItem();
                lstitem = lst.Items.FindByValue(intID.ToString());
                if (lstitem != null)
                {
                    lstitem.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaForView(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        //dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaOnly(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "dba";
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaOnly(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement, bool IsExposure)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (Convert.ToString(CurrentEmployee) == null)
            CurrentEmployee = 0;

        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += Convert.ToString(drRegion["Region"]) + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }

        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllForExposures(CurrentEmployee, Regional.TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "dba";
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaOnlyListBox(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement, bool IsSonicLocationCodeValueMemeber)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "dba";
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            if (IsSonicLocationCodeValueMemeber == true)
                ddlToFill.DataValueField = "sonic_location_code";
            else
                ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationdbaOnlyForView(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "dba";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillLocationDBA_All(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllDBA().Tables[0];
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillLocationDBA_All(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllDBA().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillLocationDBA_AllCRMAdHoc(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllDBA().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "dba";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Fill  Inspection Department List
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void Fill_DepartmentAdHoc(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        // DataTable dtData = ERIMS.DAL.Inspection_Responses.SelectAllDBA().Tables[0];
        DataTable dtData = ERIMS.DAL.LU_Department.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Description not in ('General Manager', 'Controller')";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Department_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Fill  Inspection FocusArea 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void Fill_FocusAreaAdHoc(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = Inspection_Questions.SelectAllFocusAreas().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Item_Number_Focus_Area";
            ddlToFill.DataValueField = "Item_Number_Focus_Area";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Fill  Inspection Question Text 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void Fill_QuestionTextAdHoc(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = Inspection_Questions.SelectAllQuestion().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Question_Text";
            ddlToFill.DataValueField = "Question_Text";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }
    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillSonicLocationNumberOnly(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Sonic_Location_Code";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillSonicLocationNumberOnlyForView(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Sonic_Location_Code";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationLegal_Entity(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationLegal_Entity(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement, bool IsExposure)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (Convert.ToString(CurrentEmployee) == null)
            CurrentEmployee = 0;

        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += Convert.ToString(drRegion["Region"]) + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }

        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllForExposures(CurrentEmployee, Regional.TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationLegal_EntityForView(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.Sort = "legal_entity";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Bind dropdown to receipientlist
    /// </summary>
    /// <param name="drpDown"></param>
    public static void GetRecipientList(DropDownList drpDown)
    {
        DataSet ds = ERIMS.DAL.Report.GetRecipientList();
        ds.Tables[0].DefaultView.Sort = "ListName";
        drpDown.DataValueField = "pk_RecipientList_ID";
        drpDown.DataTextField = "ListName";
        drpDown.DataSource = ds.Tables[0].DefaultView;
        drpDown.DataBind();
        drpDown.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
    }

    /// <summary>
    /// Used to Bind SONIC Distinct Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillDistinctLocationLegal_Entity(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.LegalEntity().Tables[0];

        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "legal_entity";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity";
            ddlToFill.DataValueField = "legal_entity";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC Distinct Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillDistinctLocationLegal_EntityList(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.LegalEntityForFranchiseReport(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity";
            ddlToFill.DataValueField = "legal_entity";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Used to Bind SONIC Distinct Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillDistinctLocationLegal_EntityByPK_Location(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.LegalEntityForFranchiseReportByPK_Location(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "legal_entity";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC fka DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationfka(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location_FKA.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "fka";
            ddlToFill.DataValueField = "FK_LU_Location_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillLocationfkaList(ListBox[] Lst, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location_FKA.SelectAll();
        foreach (ListBox ddlToFill in Lst)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "fka";
            ddlToFill.DataValueField = "FK_LU_Location_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void IncedentTypeList(ListBox[] Lst, int intID, bool booladdSelectAsFirstElement)
    {

    }

    /// <summary>
    /// Used to Bind Associate Name DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillAssociateName(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Employee.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "EmployeeName";
            ddlToFill.DataValueField = "PK_Employee_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, "-- Select --");
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Associate Name DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillAssociateName_ClaimInfo(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.WC_ClaimInfo.SelectEmployee_Name();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Employee_Name";
            ddlToFill.DataValueField = "Employee_Name";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, "-- Select --");
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind TPA Claim Number DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillTPA_Claim_Number(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.WC_ClaimInfo.SelectTPA_Claim_Number();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Origin_Claim_Number";
            ddlToFill.DataValueField = "Origin_Claim_Number";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, "-- Select --");
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillState(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.State.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_state";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown present in LU_location table
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillStateFromLU_Location(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.State.SelectAllFromLU_Location();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_state";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Fill Auto Liability Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillAuto_Liability_Type(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Auto_Liability_Type.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Auto_Liability_Type";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillStateList(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.State.SelectAll();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_state";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillStateByDesc(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.State.SelectAll();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_state";
            ddlToFill.DataValueField = "FLD_state";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillBuildingOwnerShip(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Building.SelectAllOwnership();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Ownership";
            ddlToFill.DataValueField = "Ownership";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillBuildingLocationStatus(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Building.SelectAllLocationStatus();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Location_Status";
            ddlToFill.DataValueField = "Location_Status";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Marital Status DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillMaritalStatus(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Marital_Status.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_desc";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Nature of Injury DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillNatureofInjury(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Nature_of_Injury.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Nature_of_Injury_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Department DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillDepartment(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Department.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Department_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Body Part Affected DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillBodyPartAffected(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Part_Of_Body.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Description";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Part_Of_Body_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Body Part Affected DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillBodyPartAffectedByFirstReport(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement, string code)
    {
        DataTable dtData = ERIMS.DAL.LU_Part_Of_Body.SelectByFirstReport(code).Tables[0];
        dtData.DefaultView.Sort = "Description";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Part_Of_Body_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Vehicle Type DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillVehicleType(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Vehicle_Type.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_Vehicle_Type";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Report List to Dropdown of SONIC INfo User control
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillReportType_ByWizardID(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, int WizardID)
    {
        DataSet dsData = ERIMS.DAL.Constituent_First_Report.SelectConstituentReportList_byFirstReportID(WizardID);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "PK_FR_Number";
            ddlToFill.DataValueField = "PK_FR_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Report List to Dropdown of Claim Header
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillCompanionClaimReportType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal Fk_First_Report_ID, string First_Report_Table)
    {
        DataSet dsData = ERIMS.DAL.Constituent_First_Report.SelectConstituentReportList_byFirstReportID_Claim(Fk_First_Report_ID, First_Report_Table);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "ClaimNumber";
            ddlToFill.DataValueField = "PK_FR_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Vehicle Type DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    /// <param name="FKCostCenter">FK Cost Center ID</param>
    public static void FillAssociateByContact(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, int Sonic_Location_Code)
    {
        DataSet dsData = ERIMS.DAL.Employee.SelectByEmployee_CostCenter(Sonic_Location_Code);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "EmployeeName";
            ddlToFill.DataValueField = "PK_Employee_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillFolderName(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsFolderName;
        dsFolderName = ERIMS.DAL.Enviro_Attachments_Folder.SelectAll();

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataSource = dsFolderName;
            ddlToFill.DataValueField = "PK_Enviro_Attachments_Folder_ID";
            ddlToFill.DataTextField = "Folder_Name";
            ddlToFill.DataBind();

            if (booladdSelectAsFirstElement)
                ddlToFill.Items.Insert(0, new ListItem("---Select----", "0"));

        }

    }

    /// <summary>
    /// Used tp bind Module Name
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillModuleName(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Module.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "ModuleName";
            ddlToFill.DataValueField = "ModuleId";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used tp bind Right Type
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillRightType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.RightType.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "RightType";
            ddlToFill.DataValueField = "RightTypeId";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used tp bind Region from Lu_Location Table
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillRegion(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location.GetRegionList();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "region";
            ddlToFill.DataValueField = "region";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Region from Lu_Location Table
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillRegionListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location.GetRegionList();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "region";
            lstToFill.DataValueField = "region";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Region which are active and show on dashboard from Lu_Location Table
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillActiveRegionListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location.GetActiveRegionList();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "region";
            lstToFill.DataValueField = "region";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Market Dropdowns
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillMarket(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        string SELECT_STRING = "--All Markets--";
        DataSet dsData = clsLU_Market.SelectActiveMarkets();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Market";
            ddlToFill.DataValueField = "PK_LU_Market";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillMarket(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, bool isAll)
    {
        string SELECT_STRING = string.Empty;
        if (isAll)
            SELECT_STRING = "--All Markets--";
        else
            SELECT_STRING = "-- Select --";
        DataSet dsData = clsLU_Market.SelectActiveMarkets();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Market";
            ddlToFill.DataValueField = "PK_LU_Market";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used tp bind Market from LU_Market Table
    /// </summary>
    /// <param name="ListBox">ListBox Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillMarketListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Market.SelectActiveMarkets();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Market";
            lstToFill.DataValueField = "PK_LU_Market";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillRlcmListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location.GetAllRlcm();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Name";
            lstToFill.DataValueField = "FK_Employee_Id";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }

    }

    public static void FillRlcmDropDownList(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Location.GetAllRlcm();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Name";
            ddlToFill.DataValueField = "FK_Employee_Id";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }

    }

    /// <summary>
    /// Used to bind Distinct Year for workers_comp_charges
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillDistinctYear_Worker_Comp_Charge(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Workers_comp_charges.GetDistinctYear();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "year";
            ddlToFill.DataValueField = "year";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Distinct Year for workers_comp_charges
    /// </summary>
    /// <param name="ListBox">lst</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of ListBox</param>
    public static void FillListBoxforAllEmilIDfromSecurity(ListBox[] lst, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Security.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Email";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox lstToFill in lst)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Email";
            lstToFill.DataValueField = "PK_Security_ID";
            lstToFill.DataSource = dtData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    protected void lnkEmailALL_OnClick(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        lnk.OnClientClick = "OpenWizardPopup()";
    }

    /// <summary>
    /// Used to bind Program
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillProgram(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Tatva_Program.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Program
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillPolicyType(DropDownList[] dropDowns, decimal ProgramID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Policy_Type.SelectAll();
        DataView dvData = dsData.Tables[0].DefaultView;
        dvData.RowFilter = " Program_ID = " + ProgramID.ToString() + " And Active = 'Y'";
        DataTable dt = dvData.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_ID";
            ddlToFill.DataSource = dt;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Claimant Name
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillClaimantName(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dt = ERIMS.DAL.AL_ClaimInfo.GetClaimant().Tables[0];
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Claimant";
            ddlToFill.DataValueField = "Claimant";
            ddlToFill.DataSource = dt;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Lease Type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLeaseType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Lease_Type.SelectAll();

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Lease_Type";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }



    /// <summary>
    /// Fill Lease Type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLeaseTypeListBox(ListBox[] lstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Lease_Type.SelectAll();

        foreach (ListBox lstToFill in lstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Lease_Type";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Cost Center Drop Down
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCostCenter(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectCost_Center().Tables[0];

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "ADP_DMS";
            ddlToFill.DataValueField = "ADP_DMS";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Payroll codes listbox
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillPayrollCodesListbox(ListBox[] lstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Employee.SelectPayrollCodes();

        foreach (ListBox lstToFill in lstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "FK_Cost_Center";
            lstToFill.DataValueField = "FK_Cost_Center";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Cost Center Drop Down
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillBank_Detail(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Bank_Details.SelectAll().Tables[0];

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Bank_Name";
            ddlToFill.DataValueField = "PK_Bank_Details_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Claim Sub Status Drop Down
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillClaim_Sub_Status(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Claim_Sub_Status.SelectAll().Tables[0];

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_Claim_Sub_Status";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    #region " Franchise "

    public enum LU_Franchise
    {
        LU_Franchise_Additional_Brand_Image = 1,
        LU_Franchise_Additional_Land = 2,
        LU_Franchise_Brand = 3,
        LU_Franchise_Option = 4,
        LU_Franchise_Permit_Secured = 5,
        LU_Franchise_Plans_Submitted = 6
    }

    public static void Fill_LU_Franchise(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, LU_Franchise objLU_Franchise)
    {
        DataTable dtData = null;
        string strPKField = "";

        switch (objLU_Franchise)
        {
            case LU_Franchise.LU_Franchise_Additional_Brand_Image:
                dtData = ERIMS.DAL.LU_Franchise_Additional_Brand_Image.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Brand_Image";
                break;
            case LU_Franchise.LU_Franchise_Additional_Land:
                dtData = ERIMS.DAL.LU_Franchise_Additional_Land.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Additional_Land";
                break;
            case LU_Franchise.LU_Franchise_Brand:
                dtData = ERIMS.DAL.LU_Franchise_Brand.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Brand";
                break;
            case LU_Franchise.LU_Franchise_Option:
                dtData = ERIMS.DAL.LU_Franchise_Option.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Option";
                break;
            case LU_Franchise.LU_Franchise_Permit_Secured:
                dtData = ERIMS.DAL.LU_Franchise_Permit_Secured.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Permit_Secured";
                break;
            case LU_Franchise.LU_Franchise_Plans_Submitted:
                dtData = ERIMS.DAL.LU_Franchise_Plans_Submitted.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Plans_Submitted";
                break;
        }
        if (dtData != null)
        {
            dtData.DefaultView.RowFilter = "Active = 'Y'";
            dtData.DefaultView.Sort = "Fld_Desc ASC";

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                ddlToFill.DataTextField = "Fld_Desc";
                ddlToFill.DataValueField = strPKField;
                ddlToFill.DataSource = dtData;
                ddlToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void Fill_LU_Franchise(ListBox[] dropDowns, bool booladdSelectAsFirstElement, LU_Franchise objLU_Franchise)
    {
        DataTable dtData = null;
        string strPKField = "";

        switch (objLU_Franchise)
        {
            case LU_Franchise.LU_Franchise_Additional_Brand_Image:
                dtData = ERIMS.DAL.LU_Franchise_Additional_Brand_Image.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Brand_Image";
                break;
            case LU_Franchise.LU_Franchise_Additional_Land:
                dtData = ERIMS.DAL.LU_Franchise_Additional_Land.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Additional_Land";
                break;
            case LU_Franchise.LU_Franchise_Brand:
                dtData = ERIMS.DAL.LU_Franchise_Brand.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Brand";
                break;
            case LU_Franchise.LU_Franchise_Option:
                dtData = ERIMS.DAL.LU_Franchise_Option.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Option";
                break;
            case LU_Franchise.LU_Franchise_Permit_Secured:
                dtData = ERIMS.DAL.LU_Franchise_Permit_Secured.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Permit_Secured";
                break;
            case LU_Franchise.LU_Franchise_Plans_Submitted:
                dtData = ERIMS.DAL.LU_Franchise_Plans_Submitted.SelectAll().Tables[0];
                strPKField = "PK_LU_Franchise_Plans_Submitted";
                break;
        }
        if (dtData != null)
        {
            dtData.DefaultView.RowFilter = "Active = 'Y'";
            dtData.DefaultView.Sort = "Fld_Desc ASC";

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                ddlToFill.DataTextField = "Fld_Desc";
                ddlToFill.DataValueField = strPKField;
                ddlToFill.DataSource = dtData;
                ddlToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    #endregion

    #region " CRM "

    /// <summary>
    /// Fill CRM Source 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCRM_Source(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Source.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Source";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill CRM Department
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCRM_Department(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Department.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Department";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill CRM Catagory
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCRM_Category(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Category.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Category";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill CRM Department
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCRM_Department_Desc_Detail(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Dept_Desc_Detail.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Dept_Desc_Detail";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    /// <summary>
    /// Fill CRM Brand
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCRM_Brand(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Brand.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Brand";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillCRM_Contacted_Resolution(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Contacted_Resolution.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Contacted_Resolution";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillCRM_RVP(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_RVP.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_RVP";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillCRM_DFOD(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_DFOD.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_DFOD";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillCRM_Legal_Email(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Legal_Email.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Subject ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Subject";
            ddlToFill.DataValueField = "PK_LU_CRM_Legal_Email";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillCRM_Response_Method(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Response_Method.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Response_Method";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    public static void FillCRM_Letter_NA_Reason(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_CRM_Letter_NA_Reason.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_CRM_Letter_NA_Reason";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    #endregion

    #region FillLookUp
    /// <summary>
    /// Fill DropDowns from the given input
    /// </summary>
    /// <param name="drpDownList"></param>
    /// <param name="strTableName"></param>
    /// <param name="strDataValueField"></param>
    /// <param name="strDataTextField"></param>
    /// <param name="strAdditionalField"></param>
    /// <param name="strWhereCondition"></param>
    /// <param name="strOrderBy"></param>
    public static void FillLookUp(DropDownList[] drpDownList, string strTableName, string strDataValueField, string strDataTextField, string strAdditionalField, string strWhereCondition, string strOrderBy)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("GetLookUpValues");

        db.AddInParameter(dbCommand, "Table_Name", DbType.String, strTableName);
        db.AddInParameter(dbCommand, "DataValueField", DbType.String, strDataValueField);
        db.AddInParameter(dbCommand, "DataTextField", DbType.String, strDataTextField);
        if (!string.IsNullOrEmpty(strAdditionalField))
            db.AddInParameter(dbCommand, "AdditionalField", DbType.String, strAdditionalField);
        else
            db.AddInParameter(dbCommand, "AdditionalField", DbType.String, DBNull.Value);
        db.AddInParameter(dbCommand, "WhereCondition", DbType.String, strWhereCondition);
        db.AddInParameter(dbCommand, "OrderBy", DbType.String, strOrderBy);

        DataSet ds = db.ExecuteDataSet(dbCommand);

        if (ds.Tables.Count > 0)
        {
            DataTable dt = ds.Tables[0];
            foreach (DropDownList drp in drpDownList)
            {
                drp.DataSource = dt;
                drp.DataTextField = strDataTextField;
                drp.DataValueField = strDataValueField;
                drp.DataBind();
                drp.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
    }
    #endregion

    #region Pollution
    public static void FillPermitType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_Permit_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Fld_Desc";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Permit_Type";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillLU_Units(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Units.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Fld_Desc";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Units";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Utility Type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillUtilityType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Utility_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Utility_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Utility Type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillUtilityType(ListBox[] dropDowns)
    {
        DataSet dsData = ERIMS.DAL.LU_Utility_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (ListBox lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Utility_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
        }
    }

    /// <summary>
    /// Fill Media List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillMedia(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Media.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Media";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Media List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillMedia(ListBox[] dropDowns)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Media.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (ListBox lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Media";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
        }
    }

    /// <summary>
    /// Fill Agency List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillAgency(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Agency.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Agency";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Agency List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillAgency(ListBox[] dropDowns)
    {
        DataSet dsData = ERIMS.DAL.LU_Agency.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (ListBox lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Agency";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
        }
    }

    /// <summary>
    /// Fill Paint type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillPaintType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Paint_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Paint_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Chemical Family List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillChemicalFamily(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Chemical_Family.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Chemical_Family";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Storage Type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillStorageType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Storage_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Storage_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Storage Location List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillStorageLocation(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Storage_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Storage_Location";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Chemical Type
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillChemicalType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Chemical_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Chemical_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Hazard Type 
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillHazardType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Hazard_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Hazard_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Waste type List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillWastetype(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Waste_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Waste_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Facility Generator Status List Box
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillFacilityGeneratorStatus(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Facility_Generator_Status.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";

        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Facility_Generator_Status";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Chemical Type
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillPollutionEquiptmentType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Equipment_Type_Pollution.SelectAll();
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Equipment_Type_Pollution";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Tank Contents
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillTankContents(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Tank_Contents.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Tank_Contents";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Tank Material
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillTankMaterial(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Tank_Material.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Tank_Material";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill Tank Construction
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillTankConstruction(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Tank_Construction.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Tank_Construction";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_Secondary_Containment_Type
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSecondaryContainmentType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Secondary_Containment_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Secondary_Containment_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_PM_Remediation_Type
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillRemediationType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_PM_Remediation_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_PM_Remediation_Type";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_EPA_Assessor
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPAAssesor(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_EPA_Assessor.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_EPA_Assessor";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_EPA_Assessor
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillResultOf(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Result_Of.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Fld_Desc";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Result_Of";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_EPA_Assessor
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillViolation(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal fK_PM_Site_Information)
    {
        DataSet dsData = ERIMS.DAL.PM_Remediation_Grid.GetViolations(fK_PM_Site_Information);
        //dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        dsData.Tables[0].DefaultView.Sort = "Violation";
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Violation";
            lstToFill.DataValueField = "PK_PM_Violation";
            lstToFill.DataSource = dsData.Tables[0].DefaultView.ToTable();
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    #endregion

    #region "SLT"
    /// <summary>
    /// Fill Explain
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillExplain(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Explain.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Explain";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill LU_Importance
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillImportance(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Importance.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Importance";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_Incident_Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillIncident_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Lu_Incident_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_Lu_Incident_Type";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    /// <summary>
    /// Fill LU_Item_status
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillItem_status(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Item_Status.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Item_Status";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_Procedure_Source
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillProcedure_Source(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Procedure_Source.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Procedure_Source";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_SLT_Role
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSLT_Role(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_SLT_Role.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_SLT_Role";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_Suggetion_Source
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSuggetion_Source(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Suggetion_Source.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Suggetion_Source";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill LU_Work_Status
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillWork_Status(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Work_Status.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 1";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Work_Status";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    #endregion

    #region "Project Managenet(EPM)"

    /// <summary>
    /// Fill EPM Project Type 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_Project_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Project_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Project_Type";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Requesting Agency
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_Requesting_Agency(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Requesting_Agency.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Requesting_Agency";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM TargetArea
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_TargetArea(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_TargetArea.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_TargetArea";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Purpose Of Project
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_PurposeOfProject(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_EPM_PurposeOfProject.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_PurposeOfProject";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Existing Documents
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_ExistingDocuments(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_EPM_ExistingDocuments.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_ExistingDocuments";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillEPM_Milestone_Email_List(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsEPM_MilestoneRecipients.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Name ASC";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Name";
            ddlToFill.DataValueField = "PK_EPM_MilestoneRecipients";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Project Phase
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_Project_Phase(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Project_Phase.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Project_Phase";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Milestone
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_EPM_Milestone(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Milestone.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Milestone";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Milestone
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillMailList_Milestone(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal PK_EPM_Milestone, decimal FK_LU_Location_Id, decimal FK_EPM_Identification)
    {
        DataTable dtData = ERIMS.DAL.clsEPM_Milestone.SelectByPkForDropdown(PK_EPM_Milestone, FK_LU_Location_Id, FK_EPM_Identification).Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Milestone";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Required Activity
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_EPM_Required_Activity(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Required_Activity.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Required_Activity";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill EPM Outcome
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_EPM_Outcome(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Outcome.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Outcome";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Attachment Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_EPM_Attachment_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Attachment_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Attachment_Type";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Attachment Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_FCP_Attachment_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = clsLU_Document_Folders_FacilityConstruction.SelectAllRecords().Tables[0];
        //dtData.DefaultView.RowFilter = "Active = 'Y'";
        //dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Folder_Name";
            ddlToFill.DataValueField = "PK_LU_FC_Document_Folder";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Attachment Type By User
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_FCP_Attachment_Type_User(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string RightType_ID)
    {
        DataTable dtData = clsLU_Document_Folders_FacilityConstruction.SelectAllRecords_BySecurityID(Convert.ToDecimal(clsSession.UserID), RightType_ID).Tables[0];
        //dtData.DefaultView.RowFilter = "Active = 'Y'";
        //dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Folder_Name";
            ddlToFill.DataValueField = "PK_LU_FC_Document_Folder";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    /// <summary>
    /// Fill Attachment Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_AM_Attachment_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_AM_Attachment_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_AM_Attachment_Type";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillLU_EPM_Attachment_TypeForEnvironmental(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Attachment_Type.SelectForEnvironmental().Tables[0];
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Attachment_Type";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill region Combo in Scheduler
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillRegionByLocationID(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string PK_LU_Location_ID)
    {
        DataTable dtData = ERIMS.DAL.clsEPM_Schedule.GetRegionByLocationID(PK_LU_Location_ID).Tables[0];
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Region";
            //ddlToFill.DataValueField = "0";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Location By Region in Scheduler
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FilldbaByRegion(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string Region, decimal PK_Security_ID)
    {
        DataTable dtData = ERIMS.DAL.clsEPM_Schedule.GetdbaByRegion(Region, PK_Security_ID).Tables[0];
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    #endregion

    public static void FillContributing_Factor(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Contributing_Factor.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Field_Description";
            ddlToFill.DataValueField = "PK_LU_Contributing_Factor";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fills Companion to Project Dropdown By Location ID
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCompanionToProject(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal FK_Location_ID, decimal PK_EPM_Identification)
    {
        DataSet dsData = ERIMS.DAL.clsEPM_Identification.SelectCompanionToProject(FK_Location_ID, PK_EPM_Identification);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Companion_Project";
            ddlToFill.DataValueField = "PK_EPM_Identification";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Nature of Injury ListBox
    /// </summary>
    public static void FillNatureofInjury(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Nature_of_Injury.SelectAll();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Description";
            lstToFill.DataValueField = "PK_LU_Nature_of_Injury_ID";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Body part affected ListBox
    /// </summary>
    public static void FillBodyPartAffected(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_Part_Of_Body.SelectAll().Tables[0];
        dtData.DefaultView.Sort = "Description";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Description";
            lstToFill.DataValueField = "PK_LU_Part_Of_Body_ID";
            lstToFill.DataSource = dtData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillContributing_Factor(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Contributing_Factor.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Field_Description";
            lstToFill.DataValueField = "PK_LU_Contributing_Factor";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Status
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillBusinessRulesModules(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsBusiness_Rules_Modules.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'True'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Module";
            ddlToFill.DataValueField = "PK_Business_Rules_Modules";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillDairyModule(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        Diary objDiary = new Diary();
        DataSet dsData = objDiary.GetDiaryModule();

        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Module_Name";
            ddlToFill.DataValueField = "PK_Diary_Module";
            ddlToFill.DataSource = dsData.Tables[0];
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }

        objDiary = null;
        if (dsData != null)
            dsData = null;
    }

    public static void FillDairyIdentificationField(DropDownList[] dropDowns, int PK_Diary_Module, int PK_LU_Location_ID, bool booladdSelectAsFirstElement)
    {
        Diary objDiary = new Diary();
        DataSet dsData = objDiary.GetDiaryIdentificationField(PK_Diary_Module, PK_LU_Location_ID, 0);

        foreach (DropDownList ddlToFill in dropDowns)
        {
            if (dsData != null && dsData.Tables.Count > 0)
            {
                dsData.Tables[0].DefaultView.Sort = "TextField";
                ddlToFill.Items.Clear();
                ddlToFill.DataTextField = "TextField";
                ddlToFill.DataValueField = "ValueField";
                ddlToFill.DataSource = dsData.Tables[0];
                ddlToFill.DataBind();
            }
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }

        objDiary = null;
        if (dsData != null)
            dsData = null;
    }


    public static void FillSonicLocationNumberList(ListBox[] LstBox, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataSet dsData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")));

        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "RM_Location_Number";
            lstToFill.DataValueField = "PK_LU_Location_ID";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = lstToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillSoincLocationCodeBusinessRule(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Sonic_Location_Code";
            lstToFill.DataValueField = "PK_LU_Location_ID";
            lstToFill.DataSource = dtData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillStateDropdownByDesc(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.State.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "FLD_state";
            ddlToFill.DataValueField = "FLD_state";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillDairyTaskType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = new DataSet();
        dsData = clsLU_Task_Type.SelectActiveAll();

        if (dsData != null && dsData.Tables.Count > 0)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                ddlToFill.DataTextField = "TaskType";
                ddlToFill.DataValueField = "PK_LU_Task_Type";
                ddlToFill.DataSource = dsData.Tables[0];
                ddlToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }

        if (dsData != null)
            dsData = null;
    }

    public static void FillTransactionType(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {

        DataSet dsData = new DataSet();
        dsData = clsLU_Transaction_Type.SelectAll();
        if (dsData != null && dsData.Tables.Count > 0)
        {
            foreach (ListBox lstToFill in LstBox)
            {
                lstToFill.Items.Clear();
                lstToFill.DataTextField = "Fld_Desc";
                lstToFill.DataValueField = "PK_LU_Transaction_Type";
                lstToFill.DataSource = dsData.Tables[0];
                lstToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillTransactionCategory(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {

        DataSet dsData = new DataSet();
        dsData = clsLU_Transaction_Category.SelectAll();
        if (dsData != null && dsData.Tables.Count > 0)
        {
            foreach (ListBox lstToFill in LstBox)
            {
                lstToFill.Items.Clear();
                lstToFill.DataTextField = "Fld_Desc";
                lstToFill.DataValueField = "PK_LU_Transaction_Category";
                lstToFill.DataSource = dsData.Tables[0];
                lstToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillEventType(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {

        DataSet dsData = new DataSet();
        dsData = clsLU_Event_Type.SelectAll();
        if (dsData != null && dsData.Tables.Count > 0)
        {
            foreach (ListBox lstToFill in LstBox)
            {
                lstToFill.Items.Clear();
                lstToFill.DataTextField = "Fld_Desc";
                lstToFill.DataValueField = "PK_LU_Event_Type";
                lstToFill.DataSource = dsData.Tables[0];
                lstToFill.DataBind();
                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillEventType(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = LU_Hearing_Conservation_Test_Type.SelectAllActive();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Hearing_Conservation_Test_Type";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }
    public static void FillEventByStaus(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        foreach (ListBox li in LstBox)
        {
            li.Items.Clear();
            li.Items.Add(new ListItem("Open", "O"));
            li.Items.Add(new ListItem("Closed", "C"));

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                li.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillWeekDays(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Days_Of_Week.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Days_Of_Week";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    public static void FillCap_Index_Risk_Category(DropDownList[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_AP_Cap_Index_Risk_Category.SelectAll(1);
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Cap_Index_Risk_Category";
            lstToFill.DataValueField = "PK_LU_AP_Cap_Index_Risk_Category";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
    public static void FillCap_Index_Risk_Category(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_AP_Cap_Index_Risk_Category.SelectAll(1);
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Cap_Index_Risk_Category";
            lstToFill.DataValueField = "PK_LU_AP_Cap_Index_Risk_Category";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    /// <summary>
    /// Used to Bind SONIC Legal Entity DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FIllLocationdba_LegalEntity(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();

        foreach (DropDownList ddlToFill in dropDowns)
        {

            ddlToFill.Items.Clear();
            if (ddlToFill.ID == "ddlLegalEntity")
            {
                dtData.DefaultView.RowFilter = " Active = 'Y' ";
                dtData.DefaultView.Sort = "Sonic_Location_Code";
                ddlToFill.DataTextField = "legal_entity1";
                ddlToFill.DataValueField = "PK_LU_Location_ID";
            }
            else if (ddlToFill.ID == "ddlLocationdba")
            {
                dtData.DefaultView.RowFilter = " Active = 'Y' ";
                dtData.DefaultView.Sort = "dba";
                ddlToFill.DataTextField = "dba";
                ddlToFill.DataValueField = "PK_LU_Location_ID";
                ddlToFill.Style.Add("font-size", "x-small");
            }
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Filter Employee and client by location
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FilterEmployeeClientNamebyLocationNumber(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, Decimal pk_location)
    {
        DataSet ds = ERIMS.DAL.AL_ClaimInfo.FilterEmployeeClientNamebyLocationNumber(pk_location);
        if (ds.Tables.Count > 0)
        {
            DataTable dtEmployeeName = ds.Tables[0];
            //DataTable dtClaimant = ds.Tables[1];
            //DataTable dtClaimNumber = ds.Tables[2];
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                if (ddlToFill.ID == "ddlAssociateName")
                {
                    ddlToFill.DataTextField = "Employee_Name";
                    ddlToFill.DataValueField = "Employee_Name";
                    ddlToFill.DataSource = dtEmployeeName;
                    ddlToFill.DataBind();
                }
                //if (ddlToFill.ID == "ddlClaimantName")
                //{
                //    ddlToFill.DataTextField = "Claimant";
                //    ddlToFill.DataValueField = "Claimant";
                //    ddlToFill.DataSource = dtClaimant;
                //    ddlToFill.DataBind();
                //}
                //if (ddlToFill.ID == "ddlClaimNumber")
                //{
                //    ddlToFill.DataTextField = "Origin_Claim_Number";
                //    ddlToFill.DataValueField = "Origin_Claim_Number";
                //    ddlToFill.DataSource = dtClaimNumber;
                //    ddlToFill.DataBind();
                //}

                //check require to add "-- select --" at first item of dropdown.
                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    /// <summary>
    /// Fill Executive Risk Allegation
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillType_Of_ER_Allegation(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Type_Of_ER_Allegation.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_Type_Of_ER_Allegation";
            ddlToFill.DataSource = dtData.DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                //ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillNewLocationForPremiumAllocation(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement, int? Year, string Action)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectNewLocationForPremiumAllocation(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(",")), Year, Action).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba1";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to bind Year for Premium Allocation Add location
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillYearPremiumAllocation(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsPA_Screen_Fields.GetYearPremiumAllocation();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Year";
            ddlToFill.DataValueField = "Year";
            ddlToFill.DataSource = dsData.Tables[0];
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            //if (booladdSelectAsFirstElement)
            //{
            //    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            //}
        }
    }

    public static void FillSedgwickYear(ListBox[] dropDowns)
    {
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            int intMinYear, intMaxYear;
            intMinYear = 2000;
            intMaxYear = DateTime.Now.Year;
            for (int i = intMaxYear; i >= intMinYear; i--)
            {
                ddlToFill.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
    }

    public static void FillSedgwick_Claim_Office(ListBox[] dropDowns)
    {
        DataTable dtYears = BAL.LU_Sedgwick_Field_Office.SelectAll(Convert.ToDecimal(clsSession.UserID)).Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Sedgwick_Field_Office";
            ddlToFill.DataSource = dtYears;
            ddlToFill.DataBind();
        }
    }

    public static void FillSLT_DepartmentObserved(ListBox[] dropDowns)
    {
        DataSet dsDepartment = LU_SLT_Safety_Walk_Department.SelectAll();
        if (dsDepartment != null)
        {
            foreach (ListBox ddlToFill in dropDowns)
            {
                DataTable dtDepartment = dsDepartment.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtDepartment.DefaultView.RowFilter = " Active = 'Y'";
                dtDepartment = dtDepartment.DefaultView.ToTable();
                ddlToFill.DataTextField = "Department";
                ddlToFill.DataValueField = "PK_LU_SLT_Safety_Walk_Department";
                ddlToFill.DataSource = dtDepartment;
                ddlToFill.DataBind();
            }
        }
    }

    public static void FillSLT_BTSecurity_DepartmentObserved(ListBox[] dropDowns)
    {
        DataSet dsDepartment = clsLU_SLT_BT_Security_Walk_Department.SelectAll();
        if (dsDepartment != null)
        {
            foreach (ListBox ddlToFill in dropDowns)
            {
                DataTable dtDepartment = dsDepartment.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtDepartment.DefaultView.RowFilter = " Active = 'Y'";
                dtDepartment = dtDepartment.DefaultView.ToTable();
                ddlToFill.DataTextField = "Department";
                ddlToFill.DataValueField = "PK_LU_SLT_BT_Security_Walk_Department";
                ddlToFill.DataSource = dtDepartment;
                ddlToFill.DataBind();
            }
        }
    }

    public static void FillAssociate(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsAssociate = Workers_Comp_Claims_OH.GetAssociateList();
        if (dsAssociate != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtAssociate = dsAssociate.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtAssociate = dtAssociate.DefaultView.ToTable();
                ddlToFill.DataTextField = "Associate_Name";
                ddlToFill.DataValueField = "Associate_Name";
                ddlToFill.DataSource = dtAssociate;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillGetSonicLocationlegalentityList(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsLegal = Workers_Comp_Claims_OH.GetSonicLocationlegalentityList();
        if (dsLegal != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtLegal = dsLegal.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtLegal = dtLegal.DefaultView.ToTable();
                ddlToFill.DataTextField = "legal_entity";
                ddlToFill.DataValueField = "legal_entity";
                ddlToFill.DataSource = dtLegal;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillGetSonicLocationdbaList(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsdba = Workers_Comp_Claims_OH.GetSonicLocationdbaList();
        if (dsdba != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtdba = dsdba.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtdba = dtdba.DefaultView.ToTable();
                ddlToFill.DataTextField = "dba";
                ddlToFill.DataValueField = "dba";
                ddlToFill.DataSource = dtdba;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillGetClaimStatusList(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsdba = Workers_Comp_Claims_OH.GetClaimStatusList();
        if (dsdba != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtdba = dsdba.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtdba = dtdba.DefaultView.ToTable();
                ddlToFill.DataTextField = "Claim_Status";
                ddlToFill.DataValueField = "Claim_Status";
                ddlToFill.DataSource = dtdba;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }
    }

    public static void FillClaimantNameForOhioWCClaim(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsClaimant = Workers_Comp_Claims_OH.GetClaimantNameList();
        if (dsClaimant != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtClaimant = dsClaimant.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtClaimant = dtClaimant.DefaultView.ToTable();
                ddlToFill.DataTextField = "Associate_Name";
                ddlToFill.DataValueField = "PK_Workers_Comp_Claims_OH";
                ddlToFill.DataSource = dtClaimant;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }

    }

    public static void FillClaimantNumberFormOhioWCClaim(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsClaimInfo = Workers_Comp_Claims_OH.GetClaimantNumberListFromWorkersCompClaimsOH();
        if (dsClaimInfo != null)
        {
            foreach (DropDownList ddlToFill in dropDowns)
            {
                DataTable dtClaimInfo = dsClaimInfo.Tables[0];
                // bind the grid.
                ddlToFill.Items.Clear();
                dtClaimInfo = dtClaimInfo.DefaultView.ToTable();
                ddlToFill.DataTextField = "Origin_Claim_Number";
                ddlToFill.DataValueField = "Origin_Claim_Number";
                ddlToFill.DataSource = dtClaimInfo;
                ddlToFill.DataBind();

                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
                }
            }
        }

    }

    public static void BindMonth(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("January", "1"));
        lst.Items.Add(new ListItem("February", "2"));
        lst.Items.Add(new ListItem("March", "3"));
        lst.Items.Add(new ListItem("April", "4"));
        lst.Items.Add(new ListItem("May", "5"));
        lst.Items.Add(new ListItem("June", "6"));
        lst.Items.Add(new ListItem("July", "7"));
        lst.Items.Add(new ListItem("August", "8"));
        lst.Items.Add(new ListItem("September", "9"));
        lst.Items.Add(new ListItem("October", "10"));
        lst.Items.Add(new ListItem("November", "11"));
        lst.Items.Add(new ListItem("December", "12"));
    }

    public static void BindMonth(DropDownList lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("January", "1"));
        lst.Items.Add(new ListItem("February", "2"));
        lst.Items.Add(new ListItem("March", "3"));
        lst.Items.Add(new ListItem("April", "4"));
        lst.Items.Add(new ListItem("May", "5"));
        lst.Items.Add(new ListItem("June", "6"));
        lst.Items.Add(new ListItem("July", "7"));
        lst.Items.Add(new ListItem("August", "8"));
        lst.Items.Add(new ListItem("September", "9"));
        lst.Items.Add(new ListItem("October", "10"));
        lst.Items.Add(new ListItem("November", "11"));
        lst.Items.Add(new ListItem("December", "12"));
    }

    /// <summary>
    /// Fill Event Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEventType(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = clsLU_Event_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Event_Type";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind ACI Location
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocation(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = clsAci_Lu_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_ACI_LU_Location";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind ACI Location
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationWithCode(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = clsAci_Lu_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Location";
            ddlToFill.DataValueField = "PK_ACI_LU_Location";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind ACI Location
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocation(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = clsAci_Lu_Location.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_ACI_LU_Location";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Event Description
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEventDescription(ListBox[] ListBoxs)
    {
        DataSet dsData = clsLU_Event_Description.SelectAll();
        foreach (ListBox lstToFill in ListBoxs)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Fld_Desc";
            lstToFill.DataValueField = "PK_LU_Event_Description";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
        }
    }

    /// <summary>
    /// Used to bind LU_Camera_Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillLU_Camera_Type(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Camera_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Camera_Type";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind ACI Location
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillWorkToBeCompleted(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = clsLU_Work_Completed.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Work_Completed";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Bind Status of Yes or No (it used for ClientIssue and FacilitiesIssues in management module)
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillStatus(DropDownList dropDowns, bool booladdSelectAsFirstElement)
    {
        dropDowns.Items.Add(new ListItem("Yes", "Y"));
        dropDowns.Items.Add(new ListItem("No", "N"));

        if (booladdSelectAsFirstElement)
            dropDowns.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
    }

    public static void FillLocationByACIUser(DropDownList[] dropDownList, decimal Security_Id, bool p)
    {
        DataSet dsData = clsSecurity_ACI_LU_Location.SelectByUser(Security_Id, false);
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_ACI_LU_Location";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillBuildingForBuildingImprovements(DropDownList[] dropDownList, int fK_LU_Location_ID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Building.SelectBuildingForBuildingImprovements(fK_LU_Location_ID);

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "BuildingName";
            ddlToFill.DataValueField = "PK_Building_ID";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillBuildingImprovementStatus(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_BI_Status.SelectActive();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_BI_Status";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillPropertyContactType(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Property_Contact_Type.SelectActive();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "Fld_Desc";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind ProjectNumber by Locationid for contractorjobsecurity
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillProjectNumberFromLocation(DropDownList[] dropDowns, int FK_Location, bool booladdSelectAsFirstElement)
    {
        //DataSet dsData = null;
        DataSet dsData = ERIMS.DAL.Contractor_Job_Security.SelectByLocationFacility_Construction_Project(FK_Location);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Project_Number";
            ddlToFill.DataValueField = "PK_Facility_construction_Project";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            ////check id greater 0 than find the value in dropdown list. if find than select the item.
            //if (intID > 0)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlToFill.Items.FindByValue(intID.ToString());
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}
        }
    }

    /// <summary>
    /// Used to Bind Contractor Type DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillContractorType(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Contractor_Type.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "CT_Desc";
            ddlToFill.DataValueField = "PK_LU_Contractor_Type";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            //if (intID > 0)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlToFill.Items.FindByValue(intID.ToString());
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}
        }
    }

    /// <summary>
    /// Used to Bind Location For ACI Event DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationByACIUser_New(DropDownList[] dropDownList, decimal Security_Id, bool p)
    {
        DataSet dsData = clsSecurity_ACI_LU_Location_Link.SelectByUser(Security_Id, false);
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void LearningProgramingStatusDescription(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("Withdrawn", "Withdrawn"));
        lst.Items.Add(new ListItem("Enrolled but not started", "Enrolled but not started"));
        lst.Items.Add(new ListItem("Completed", "Completed"));
        lst.Items.Add(new ListItem("Started", "Started"));
    }

    /// <summary>
    /// Used to bind Work to be completed dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillWork_Completed(DropDownList[] dropDownList, bool p)
    {
        DataSet dsData = clsLU_Work_Completed.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Work_Completed";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Record Type dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillRecord_Type(DropDownList[] dropDownList, bool p)
    {
        DataSet dsData = clsLU_Record_Type.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Record_Type";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Approval Submission dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillApproval_Submission(DropDownList[] dropDownList, bool p)
    {
        DataSet dsData = clsLU_Approval_Submission.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Approval_Submission";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Approval Submission dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillApproval_Submission(ListBox[] listBox, bool p)
    {
        DataSet dsData = clsLU_Approval_Submission.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox listToFill in listBox)
        {
            listToFill.Items.Clear();
            listToFill.DataTextField = "Fld_Desc";
            listToFill.DataValueField = "PK_LU_Approval_Submission";
            listToFill.DataSource = dsData.Tables[0].DefaultView;
            listToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                listToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Event Level Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillEventLevel(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Event_Level.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Event_Level";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Focus Area Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillFocusArea(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Cause_Code_Information.SelectFocusArea();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Focus_Area";
            ddlToFill.DataValueField = "Master_Order";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    #region Property


    public static void FillDistanceFromOthers(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("", "--SELECT--"));
        lst.Items.Add(new ListItem("<1 MIles", "<1 MIles"));
        lst.Items.Add(new ListItem("1-5 Miles", "1-5 Miles"));
        lst.Items.Add(new ListItem("5-10 Miles", "5-10 Miles"));
        lst.Items.Add(new ListItem(">10 Miles", ">10 Miles"));

    }
    /// <summary>
    /// fill fire department types-building
    /// </summary>
    /// <param name="lst"></param>
    public static void FillBuildingFireDeptTypes(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("", "--SELECT--"));
        lst.Items.Add(new ListItem("Paid", "Paid"));
        lst.Items.Add(new ListItem("Part Paid", "Part Paid"));
        lst.Items.Add(new ListItem("Volunteer", "Volunteer"));

    }


    /// <summary>
    /// Fill Auto Liability Type
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillBuildingLiability(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("Assigned with Liability", "Assigned with Liability"));
        lst.Items.Add(new ListItem("Assigned without Liability", "Assigned without Liability"));

    }

    public static void FillLosspayeeTypes(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("", "--SELECT--"));
        lst.Items.Add(new ListItem("Mortgagee", "Mortgagee"));
        lst.Items.Add(new ListItem("Landlord", "Landlord"));

    }

    public static void FillPropertyContactTypeForAdhoc(ListBox[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Property_Contact_Type.SelectActive();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "Fld_Desc";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillBuildingImprovementStatusForAdhoc(ListBox[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_BI_Status.SelectActive();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_BI_Status";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillBuildingImprovementBuildingForAdhoc(ListBox[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Building.SelectAll();
        //dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Building_Number";
            ddlToFill.DataValueField = "PK_Building_ID";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillBIRevisedSquareFootage(ListBox lst)
    {
        lst.Items.Clear();
        lst.Items.Add(new ListItem("", "--SELECT--"));
        lst.Items.Add(new ListItem("Add", "A"));
        lst.Items.Add(new ListItem("Reduce", "R"));
        lst.Items.Add(new ListItem("No Change", "N"));

    }

    #endregion


    /// <summary>
    /// 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillWork_Completed(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_Work_Completed.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Work_Completed";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillRecord_Type(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_Record_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Record_Type";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="LstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillManagementByDecision(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        foreach (ListBox li in LstBox)
        {
            li.Items.Clear();
            li.Items.Add(new ListItem("Approve", "1"));
            li.Items.Add(new ListItem("Not Approve", "0"));

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                li.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="intID"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEPM_Project_Phase(ListBox[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.LU_EPM_Project_Phase.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = "Active = 'Y'";
        dtData.DefaultView.Sort = "Fld_Desc ASC";

        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_EPM_Project_Phase";
            ddlToFill.DataSource = dtData.DefaultView;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="LstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillManagementByWorkCompletedBy(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        foreach (ListBox li in LstBox)
        {
            li.Items.Clear();
            li.Items.Add(new ListItem("ACI", "1"));
            li.Items.Add(new ListItem("Sonic", "0"));

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                li.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="LstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillTaskComplete(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        foreach (ListBox li in LstBox)
        {
            li.Items.Clear();
            li.Items.Add(new ListItem("Yes", "1"));
            li.Items.Add(new ListItem("No", "0"));

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                li.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillMaintenanceStatusList(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Maintenance_Status.SelectAll();
        foreach (ListBox lstBox in LstBox)
        {
            lstBox.Items.Clear();
            lstBox.DataTextField = "Fld_Desc";
            lstBox.DataValueField = "PK_LU_Maintenance_Status";
            lstBox.DataSource = dsData;
            lstBox.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstBox.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }


    /// <summary>
    /// Used to Bind Contractor Type DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillContractorFirm(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Contractor_Firm.SelectFirmName();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Contractor_Firm_Name";
            ddlToFill.DataValueField = "PK_Contractor_Firm";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            //if (intID > 0)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlToFill.Items.FindByValue(intID.ToString());
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillFocusAreaCauseCode(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Investigation.SelectAllCauseCodeInformation();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Focus_Area";
            ddlToFill.DataValueField = "Master_Order";
            ddlToFill.DataSource = dsData.Tables[0];
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillFocusAreaCauseCode(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Investigation.SelectAllCauseCodeInformation();
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Focus_Area";
            ddlToFill.DataValueField = "Focus_Area";
            ddlToFill.DataSource = dsData.Tables[0];
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind Firm Type DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillFirmType(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Construction_Firm_Type.SelectAll();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "CFT_Desc";
            ddlToFill.DataValueField = "PK_LU_Construction_Firm_Type";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            //if (intID > 0)
            //{
            //    ListItem lst = new ListItem();
            //    lst = ddlToFill.Items.FindByValue(intID.ToString());
            //    if (lst != null)
            //    {
            //        lst.Selected = true;
            //    }
            //}
        }
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLossCategory(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_PL_Loss_Category.SelectAllActive();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_PL_Loss_Category";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }    

    /// <summary>
    /// Fill Inspection Area Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>

    public static void FillInspectionArea(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Facility_Inspection_Focus_Area.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Facility_Inspection_Focus_Area";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }   

    public static void FillPaintCategory(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_VOC_Category.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData = dtData.DefaultView.ToTable();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Category";
            ddlToFill.DataValueField = "PK_LU_VOC_Category";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillYear(DropDownList[] ddlYear, bool booladdSelectAsFirstElement)
    {
        foreach (DropDownList ddlToFill in ddlYear)
        {
            ddlToFill.Items.Clear();
            int intMinYear, intMaxYear;
            intMinYear = 2000;
            intMaxYear = DateTime.Now.Year;
            for (int i = intMaxYear; i >= intMinYear; i--)
            {
                ddlToFill.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Contract_Type Area Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillContractType(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Contract_Type.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Descr";
            ddlToFill.DataValueField = "PK_LU_Contract_Type";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            clsGeneral.SetDropdownValue(ddlToFill, "General Contractor", false);
        }
    }

    /// <summary>
    /// Fill OSHA Incident Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillOSHA_Incident(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_OSHA_Incident.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_OSHA_Incident";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill OSHA Incident Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillOSHA_Incident(ListBox[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_OSHA_Incident.SelectAll();

        foreach (ListBox ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_OSHA_Incident";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill OSHA Injury Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillOSHA_Injury(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_OSHA_Injury.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_OSHA_Injury";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill OSHA Injury Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillOSHA_Injury(ListBox[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_OSHA_Injury.SelectAll();

        foreach (ListBox ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_OSHA_Injury";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Employee
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillOSHA_Employee(DropDownList[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Employee.SelectEmployee_For_OSHA();
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "NAME";
            lstToFill.DataValueField = "PK_Employee_ID";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Location by RLCM
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillLocationByRLCM(DropDownList[] dropDowns,decimal? fK_Employee_Id, bool booladdSelectAsFirstElement, bool IsShow_On_Dashboard)
    {
        DataTable dtData = ERIMS.DAL.LU_Location.SelectLocation_By_RLCM(fK_Employee_Id).Tables[0];

        if (IsShow_On_Dashboard)
        {
            dtData.DefaultView.Sort = "dba";
            dtData.DefaultView.RowFilter = " Show_On_Dashboard = 'Y' ";
        }

        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "dba";
            ddlToFill.DataValueField = "PK_LU_Location_ID";
            ddlToFill.DataSource = dtData;
            //ddlToFill.Style.Add("font-size", "x-small");
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Inspection Area Drop downs
    /// </summary>
    /// <param name="dropDownList">All dropDownList</param>
    /// <param name="booladdSelectAsFirstElement">Add --select-- to first item in each drop down or not</param>
    public static void FillInspectionFocusArea(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.clsLU_Facility_Inspection_Focus_Area.SelectAll();

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Facility_Inspection_Focus_Area";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Employee by Location for training module.
    /// </summary>
    /// <param name="lstBox"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillEmployeeBY_Loc_Training(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, decimal pK_LU_Location_ID)
    {
        DataSet dsData = ERIMS.DAL.Employee.SelectEmployeeBY_Location_FOR_Training(pK_LU_Location_ID);
        foreach (DropDownList lstToFill in dropDowns)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "NAME";
            lstToFill.DataValueField = "PK_Employee_ID";
            lstToFill.DataSource = dsData.Tables[0].DefaultView;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                lstToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Contractor Security Dropdown Users
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillContractorSecurityUser(DropDownList[] dropDownList, int FK_Contractor_Security, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Contractor_Security.SelectAllExceptCurrentUser(FK_Contractor_Security);

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Recipient_Name";
            ddlToFill.DataValueField = "PK_Contactor_Security";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Code Dropdown Users
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillCode(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllCode().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Code";
            ddlToFill.DataValueField = "PK_Sonic_U_Training";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Dealership Dropdown Users
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillDealershipName(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllDealershipName().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "DealshipName";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Dealership";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Sonic U Training Department  Dropdown 
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSonicUTrainDepartment(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllDepartment().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "DepartmentName";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Department";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    ///  Fill Sonic U Train Learning Program Dropdown
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSonicUTrainLearningProgram(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllLearningProgram().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "LearningProgramTitle";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Learning_Program";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    ///  Fill Sonic U Train Learning Asset Dropdown
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSonicUTrainLearningAsset(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllAsset().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Asset_Title";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Learning_Asset";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Sonic U Train Learning Program Status Dropdown
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSonicUTrainLearningProgramStatus(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllLearningProgramStatus().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "StatusDescription";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Learning_Program_Status";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Sonic U Train Learning Asset Status Dropdown
    /// </summary>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillSonicUTrainLearningProgramAssetStatus(ListBox[] dropDowns, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.Sonic_U_Training.SelectAllAssetStatus().Tables[0];
        foreach (ListBox ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "AssetStatusDescription";
            ddlToFill.DataValueField = "PK_Sonic_U_Training_Learning_Asset_Status";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();

            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to Bind SONIC dba DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillSonicLocationCode(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAllForExposures(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Sonic_Location_Code";
            ddlToFill.DataValueField = "Sonic_Location_Code";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
            //check id greater 0 than find the value in dropdown list. if find than select the item.
            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Used to Bind Report List to Dropdown of Claim Header
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public static void FillAuto_Loss_Companion_Claims(DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string origin_Claim_Number)
    {
        DataSet dsData = ERIMS.DAL.AL_ClaimInfo.SelectCompanionClaim_byClaim_Number(origin_Claim_Number);
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Origin_Claim_Number";
            ddlToFill.DataValueField = "PK_Auto_Loss_Claims_ID";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Fill Responsible Party Dropdown Users
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    public static void FillResponsibleParty(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = LU_Responsible_Party.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Description";
            ddlToFill.DataValueField = "PK_LU_Responsible_Party";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    public static void FillRespiratorype(DropDownList[] dropDownList, bool booladdSelectAsFirstElement)
    {
        DataTable dtData = ERIMS.DAL.clsLU_Respirator_Type.SelectAll().Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' ";

        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Respirator_Type";
            ddlToFill.DataSource = dtData;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Approval Submission dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillMaintenanceStatus(DropDownList[] dropDownList, bool p)
    {
        DataSet dsData = LU_Maintenance_Status.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Maintenance_Status";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }

    /// <summary>
    /// Used to bind Work to be completed By dropdown of ACI Management screen
    /// </summary>
    /// <param name="dropDownList"></param>
    /// <param name="p"></param>
    public static void FillWork_To_Be_Completed(DropDownList[] dropDownList, bool p)
    {
        DataSet dsData = LU_Work_To_Be_Completed_By.SelectAll();
        dsData.Tables[0].DefaultView.RowFilter = "Active = 'Y'";
        foreach (DropDownList ddlToFill in dropDownList)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Fld_Desc";
            ddlToFill.DataValueField = "PK_LU_Work_To_Be_Completed_By";
            ddlToFill.DataSource = dsData.Tables[0].DefaultView;
            ddlToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            if (p)
            {
                ddlToFill.Items.Insert(0, new ListItem(SELECT_STRING, "0"));
            }
        }
    }
}
