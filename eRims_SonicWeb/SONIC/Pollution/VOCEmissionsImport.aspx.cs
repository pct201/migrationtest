using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_VOCEmissionsImport : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Permits
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Permits"]);
        }
        set { ViewState["PK_PM_Permits"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_LU_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_LU_Location"]);
        }
        set { ViewState["FK_LU_Location"] = value; }
    }

    /// <summary>
    /// Denotes primary key for Permits VOC Emissions record
    /// </summary>
    public decimal PK_PM_Permits_VOC_Emissions
    {
        get { return Convert.ToDecimal(ViewState["PK_PM_Permits_VOC_Emissions"]); }
        set { ViewState["PK_PM_Permits_VOC_Emissions"] = value; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropdowns();
            decimal FK_PM_Site_Information;
            PK_PM_Permits = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            ddlLocation.SelectedValue = Convert.ToString(FK_LU_Location);
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Submit Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string filename, path;
        filename = string.Empty;
        path = string.Empty;
        try
        {
            DataSet ds = null;

            //string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.strGeneralDocument, Session.SessionID, false, false);

            if (fpFile.HasFile)
            {
                //filename = AppConfig.strGeneralDocument + strUploadedFile;
                filename = fpFile.PostedFile.FileName;
                clsPM_Permits_VOC_Emissions objVOCEmission = new clsPM_Permits_VOC_Emissions();
                ds = objVOCEmission.InsertData(filename);
                DataTable dt = ds.Tables[0];
                string paintCategory = string.Empty, subTotalText = string.Empty, strFinal, strFinalUpdate, subtotalTextUpdate = string.Empty, fkCategoryIds = string.Empty;
                int month, year, retValue, FK_LU_VOC_Category = 0;
                month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                year = Convert.ToInt32(ddlYear.SelectedItem.Value);
                retValue = 0;
                strFinal = strFinalUpdate = "<ImportXML>";
                decimal subTotal = 0, subtotalUpdate = 0;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Paint_Category"])) && paintCategory.ToUpper() != (Convert.ToString(dr["Paint_Category"])).ToUpper())
                        {
                            paintCategory = Convert.ToString(dr["Paint_Category"]);
                            paintCategory=paintCategory.Replace("\"","");
                         //   paintCategory = paintCategory.Replace("", "");
                            FK_LU_VOC_Category = clsLU_VOC_Category.SelectByCategory(paintCategory);

                            fkCategoryIds += FK_LU_VOC_Category + ",";

                            subTotalText = subtotalTextUpdate = string.Empty;
                            subTotal = subtotalUpdate = 0;
                        }

                        string part_Number = Convert.ToString(dr["Part_Number"]);

                        if (FK_LU_VOC_Category == 0)
                        {
                            retValue = 0;
                        }
                        else if ((FK_LU_VOC_Category > 0) && !string.IsNullOrEmpty(part_Number))
                        {
                            retValue = clsPM_Permits_VOC_Emissions.CheckRecord(month, year, FK_LU_VOC_Category, FK_LU_Location, PK_PM_Permits, part_Number);
                        }
                        else
                        {
                            retValue = 0;
                        }

                        if (retValue == 1 && !string.IsNullOrEmpty(part_Number))
                        {
                            subTotal = subTotal + clsGeneral.GetDecimal(dr["Gallons"]) * clsGeneral.GetDecimal(dr["Quantity"]);

                            if (!string.IsNullOrEmpty(subTotalText))
                            {
                                strFinal = strFinal.Replace(">" + subTotalText + "<", ">" + paintCategory + subTotal + "<");
                            }

                            subTotalText = paintCategory + subTotal;
                            strFinal = strFinal + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + FK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part_Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"","") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Quantity"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC_Total"]) + "</VOC_Emissions><SubTotal_Text>" + subTotalText + "</SubTotal_Text><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                            clsPM_Permits_VOC_Emissions.UpdateSubTotal(subTotalText, FK_LU_VOC_Category, PK_PM_Permits, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID));
                        }

                        if (retValue == 2 && !string.IsNullOrEmpty(part_Number))
                        {
                            subtotalUpdate = subtotalUpdate + clsGeneral.GetDecimal(dr["Gallons"]) * clsGeneral.GetDecimal(dr["Quantity"]);

                            if (!string.IsNullOrEmpty(subtotalTextUpdate))
                            {
                                strFinalUpdate = strFinalUpdate.Replace(">" + subtotalTextUpdate + "<", ">" + paintCategory + subtotalUpdate + "<");
                            }

                            subtotalTextUpdate = paintCategory + subtotalUpdate;
                            strFinalUpdate = strFinalUpdate + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + FK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part_Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"","") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Quantity"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC_Total"]) + "</VOC_Emissions><SubTotal_Text>" + subtotalTextUpdate + "</SubTotal_Text><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                            clsPM_Permits_VOC_Emissions.UpdateSubTotal(subtotalTextUpdate, FK_LU_VOC_Category, PK_PM_Permits, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID));
                        }
                    }

                    strFinal = strFinal + "</ImportXML>";
                    strFinalUpdate += "</ImportXML>";

                    clsPM_Permits_VOC_Emissions.ImportXML(strFinal, strFinalUpdate);

                    if (!string.IsNullOrEmpty(fkCategoryIds))
                    {
                        string[] splitCategories = fkCategoryIds.Split(',');

                        foreach (string categoryId in splitCategories)
                        {
                            if (!string.IsNullOrEmpty(categoryId) && categoryId != "0")
                            {
                                clsPM_Permits_VOC_Emissions objPM_Permits_VOC_Emissions = new clsPM_Permits_VOC_Emissions();

                                objPM_Permits_VOC_Emissions.PK_PM_Permits_VOC_Emissions = PK_PM_Permits_VOC_Emissions;
                                objPM_Permits_VOC_Emissions.FK_LU_VOC_Category = Convert.ToDecimal(categoryId);
                                objPM_Permits_VOC_Emissions.Month = month;
                                objPM_Permits_VOC_Emissions.Year = year;

                                DataTable dtVOC = objPM_Permits_VOC_Emissions.SelectByFK(PK_PM_Permits).Tables[0];
                                subTotalText = subtotalTextUpdate = new clsLU_VOC_Category((decimal)objPM_Permits_VOC_Emissions.FK_LU_VOC_Category).Category + (GetSubTotal(dtVOC)).ToString();
                                clsPM_Permits_VOC_Emissions.UpdateSubTotal(subTotalText, objPM_Permits_VOC_Emissions.FK_LU_VOC_Category.Value, PK_PM_Permits, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID));
                            }
                        }
                    }
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('File Imported Successfully');", true);
                }
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.BindMonth(ddlMonth);
        ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        ComboHelper.FillYear(new DropDownList[] { ddlYear }, true);
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocation }, 0, true, true);
        ddlLocation.Enabled = false;
    }

    /// <summary>
    /// Calculate the SubTotal 
    /// </summary>
    /// <param name="dtVOC"></param>
    /// <returns></returns>
    public decimal GetSubTotal(DataTable dtVOC)
    {
        decimal subtotalCalculate = 0;
        foreach (DataRow drField in dtVOC.Rows)
        {
            if (drField["Quantity"] != null)
            {
                subtotalCalculate += clsGeneral.GetDecimal(drField["Quantity"]) * clsGeneral.GetDecimal(drField["Gallons"]);
            }
        }

        return subtotalCalculate;
    }

    #endregion

    protected void btnCancel_Click(object sender, EventArgs e)
    {
         Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(PK_PM_Permits.ToString()) + "&op=edit" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location)));
    }
}