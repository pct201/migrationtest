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
            if (App_Import != AccessType.VOC_Import && !IsUserSystemAdmin && !Convert.ToBoolean(Convert.ToInt32(clsSession.UserRole)))
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

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
        string filename = string.Empty;
        string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.strGeneralDocument, Session.SessionID, false, false);
        try
        {
            if (fpFile.HasFile)
            {
                filename = AppConfig.strGeneralDocument + "\\" + strUploadedFile;
                clsPM_Permits_VOC_Emissions objVOCEmission = new clsPM_Permits_VOC_Emissions();
                DataTable dt = objVOCEmission.InsertData(filename).Tables[0];
                string paintCategory = string.Empty, subTotalText = string.Empty, subtotalTextUpdate = string.Empty, fkCategoryIds = string.Empty;
                int retValue = 0, fK_LU_VOC_Category = 0;
                int month = Convert.ToInt32(ddlMonth.SelectedItem.Value);
                int year = Convert.ToInt32(ddlYear.SelectedItem.Value);
                string strFinal = "<ImportXML>", strFinalUpdate = "<ImportXML>";
                decimal subTotal = 0, subtotalUpdate = 0;
                string categoriIds = string.Empty;

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Paint_Category"])) && paintCategory.ToUpper() != (Convert.ToString(dr["Paint_Category"])).ToUpper())
                        {
                            paintCategory = Convert.ToString(dr["Paint_Category"]);
                            paintCategory = paintCategory.Replace("\"", "");
                            fK_LU_VOC_Category = clsLU_VOC_Category.SelectByCategory(paintCategory);
                            fkCategoryIds += fK_LU_VOC_Category + ",";
                            subTotal = subtotalUpdate = 0;
                            if(fK_LU_VOC_Category > 0)
                            {
                                categoriIds += fK_LU_VOC_Category + ",";
                            }
                            else
                            {
                                subTotalText += dr["Paint_Category"] + ",";
                            }
                        }

                        string part_Number = Convert.ToString(dr["Part_Number"]);
                       
                        if ((fK_LU_VOC_Category > 0) && !string.IsNullOrEmpty(part_Number))
                        {
                            retValue = clsPM_Permits_VOC_Emissions.CheckRecord(month, year, fK_LU_VOC_Category, FK_LU_Location, PK_PM_Permits, part_Number);
                        }
                        else
                        {
                            retValue = 0;
                        }

                        if (retValue == 1 && !string.IsNullOrEmpty(part_Number))
                        {
                            strFinal = strFinal + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part_Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"", "") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Quantity"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC_Total"]) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                        }

                        if (retValue == 2 && !string.IsNullOrEmpty(part_Number))
                        {
                            strFinalUpdate = strFinalUpdate + "<Section><FK_PM_Permits>" + PK_PM_Permits + "</FK_PM_Permits><Year>" + year + "</Year><Month>" + month + "</Month><Paint_Category>" + fK_LU_VOC_Category + "</Paint_Category><Part_Number>" + Convert.ToString(dr["Part_Number"]) + "</Part_Number><Unit>" + Convert.ToString(dr["Unit"]).Replace("\"", "") + "</Unit><Quantity>" + clsGeneral.GetDecimal(dr["Quantity"]) + "</Quantity><Gallons>" + clsGeneral.GetDecimal(dr["Gallons"]) + "</Gallons><VOC_Emissions>" + clsGeneral.GetDecimal(dr["VOC_Total"]) + "</VOC_Emissions><Updated_By>" + clsSession.UserID + "</Updated_By></Section>";
                        }

                    }

                    strFinal += "</ImportXML>";
                    strFinalUpdate += "</ImportXML>";
                    clsPM_Permits_VOC_Emissions.ImportXML(strFinal, strFinalUpdate);

                    if (!string.IsNullOrEmpty(categoriIds) && categoriIds.Contains(","))
                    {
                        string[] voc_Category = categoriIds.Split(',');
                        string[] subTotalTextData = subTotalText.Split(',');
                        int count = 0;
                        foreach (string voc_categoryId in voc_Category)
                        {
                            if(!string.IsNullOrEmpty(voc_categoryId))
                            {
                                clsPM_Permits_VOC_Emissions.UpdateSubTotal(subTotalTextData[count], Convert.ToInt32(voc_categoryId), PK_PM_Permits, month, year, Convert.ToString(DateTime.Now), Convert.ToString(clsSession.UserID));
                                count++;
                            }
                        }
                    }

                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('File Imported Successfully');", true);
                }
            }
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
        }
        finally
        {
            // delete uploaded file
            DeleteUploadedFile(strUploadedFile);
        }
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// Deletes exported spreadsheet
    /// </summary>
    /// <param name="strFile">Filename along with path which is to be deleted</param>
    private void DeleteUploadedFile(string strFile)
    {
        // check if filename is not blank
        if (strFile != "")
        {
            // check whether file exists or not
            if (File.Exists(AppConfig.BuildingAttachDocPath + strFile))
            {
                // delete the file
                File.Delete(AppConfig.BuildingAttachDocPath + strFile);
            }
        }
    }

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