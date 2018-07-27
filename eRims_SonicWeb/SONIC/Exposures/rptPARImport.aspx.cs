using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ERIMS_DAL;

public partial class SONIC_Exposures_rptPARImport : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnImport_Click(object sender, EventArgs e)
    {
        // upload the file using session id and get the uploaded file name
        string strUploadedFile = clsGeneral.UploadFile(fpFile, AppConfig.PremiumAllocationPath, Session.SessionID, false, false);
        try
        {
            DataTable dt = null; // denotes datatable to get the data in to import
            bool IsBreak = false;

            // pass exported file name and get datatable to import values
            dt = clsPA_Values_Imported.GetDataToImport(AppConfig.PremiumAllocationPath + strUploadedFile);

            if (dt != null)
            {
                //if data is available to import 
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        clsPA_Values_Imported objclsPA_Values_Imported = new clsPA_Values_Imported();

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Sonic_Location_Code"])))
                        {
                            objclsPA_Values_Imported.Sonic_Location_Code = Convert.ToInt32(dt.Rows[i]["Sonic_Location_Code"]);
                        }
                        else
                        {
                            IsBreak = true;
                            break;
                        }

                        if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Year"])))
                        {
                            objclsPA_Values_Imported.Year = Convert.ToInt32(dt.Rows[i]["Year"]);
                        }
                        else
                        {
                            IsBreak = true;
                            break;
                        }
                    
                        objclsPA_Values_Imported.Non_Texas_Payroll = String.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Non_Texas_Payroll"])) ? 0 : Convert.ToDecimal(dt.Rows[i]["Non_Texas_Payroll"]);
                        objclsPA_Values_Imported.Texas_Payroll = string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Texas_Payroll"])) ? 0 : Convert.ToDecimal(dt.Rows[i]["Texas_Payroll"]);
                        objclsPA_Values_Imported.Number_Of_Employees = string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Number_Of_Employees"])) ? 0 : Convert.ToInt32(dt.Rows[i]["Number_Of_Employees"]);
                        objclsPA_Values_Imported.Updated_By = clsSession.UserName;
                        objclsPA_Values_Imported.Insert();

                    }

                    if(IsBreak)
                        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('The imported file contains empty value(s).');", true);
                    else
                    // show message for data imported
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Data has been imported successfully.');", true);
                }
                else
                {
                    // show message for no data available
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('No data available to import');", true);
                }
            }
            else
            {
                // show message for file can not be imported
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
            }
        }
        catch
        {
            // show message for file can not be imported
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
        }
        finally
        {
            // delete uploaded file
            DeleteUploadedFile(strUploadedFile);
        }
    }



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
            if (File.Exists(AppConfig.PremiumAllocationPath + strFile))
            {
                // delete the file
                File.Delete(AppConfig.PremiumAllocationPath + strFile);
            }
        }
    }
}