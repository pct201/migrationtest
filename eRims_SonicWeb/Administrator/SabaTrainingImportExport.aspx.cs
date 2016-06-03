using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using ERIMS.DAL;
using System.Data.OleDb;

public partial class Administrator_SabaTrainingImportExport : clsBasePage
{

    #region " Variables "
    private string strExceptionsLogFilePath = AppConfig.SabaTrainingDocPath + "SabaTrainingExceptionsLog.txt";
    private string strExceptionsLogFileURL = AppConfig.SabaTrainingDocURL + "SabaTrainingExceptionsLog.txt";
    private DataTable dtSabaTrainingNotImported;
    #endregion

    #region " Enums "
    private enum Saba_Training_Exceptions
    {
        Blank_PK_Property_COPE_Id = 0,
        Blank_Location = 1,
        Blank_Number_of_Employees = 2,
        Blank_Employee_Trained = 3,
        Blank_Date = 4,
        No_Match_PK_Property_COPE_Id = 5,
        NO_Match_Location = 6,
        Invalid_Date = 7,
        Invalid_PK_Property_COPE_Id = 8,
        Invalid_Location = 9,
        Invalid_Number_of_Employees = 10,
        Invalid_Trained_Employees = 11,
        No_Combination_Location_Property_Cope = 12,
        Greater_Value = 13,
        Blank_Year = 15,
        Invalid_Year = 16,
        Blank_Quarter = 17,
        Invalid_Quarter = 18,
        Duplicate_Record = 19,
        None = 20
    }
    #endregion

    #region "Page Events"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (UserAccessType != AccessType.Administrative_Access)
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            clsSession.Tbl_SabaTraining_Not_Imported = null;
        }
    }

    #endregion

    #region "Control Events"

    /// <summary>
    /// Export Policy data in Proper Format
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ///get all location to export into Excel
        DataTable dtLocation = LU_Location.SelectAllLocationOnPropertyCope().Tables[0];

        DataTable dtExport = new DataTable();
        dtExport.Columns.Add(new DataColumn("PK_Property_COPE_Id", typeof(string)));
        dtExport.Columns.Add(new DataColumn("Location", typeof(string)));
        dtExport.Columns.Add(new DataColumn("Year", typeof(Int32)));
        dtExport.Columns.Add(new DataColumn("Quarter", typeof(Int32)));
        dtExport.Columns.Add(new DataColumn("Number Of Associates To Be Trained In Quarter", typeof(string)));
        dtExport.Columns.Add(new DataColumn("Number of Associates Trained In Quarter", typeof(string)));
        //dtExport.Rows.Add(dtExport.NewRow());

        //Add Rows to datatable with location values
        foreach (DataRow drLoc in dtLocation.Rows)
        {
            DataRow dr = dtExport.NewRow();
            dr["Location"] = drLoc["DBA"];
            dr["PK_Property_COPE_Id"] = drLoc["PK_Property_COPE_Id"];
            dtExport.Rows.Add(dr);
        }
        //Export grid with location to excel
        gvSabaTraining.DataSource = dtExport;
        gvSabaTraining.DataBind();
        GridViewExportUtil.ExportGrid("Saba_Training_Spreadsheet.xlsx", gvSabaTraining, true);
    }

    /// <summary>
    /// Handles Import button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnImport_Click(object sender, EventArgs e)
    {
        // upload the file using session id and get the uploaded file name
        string strUploadedFile = clsGeneral.UploadFile(fldImport, AppConfig.SabaTrainingDocPath, Session.SessionID, false, false);

        DataTable dt = null; // denotes datatable to get the data in to import

        // pass exported file name and get datatable to import values
        dt = GetDataToImport(AppConfig.SabaTrainingDocPath + strUploadedFile);

        if (dt != null)
        {
            //if data is available to import 
            if (dt.Rows.Count > 0)
            {
                try
                {
                    #region " Settings for storing information abount Saba Training would not be imported "
                    dtSabaTrainingNotImported = dt.Clone();
                    dtSabaTrainingNotImported.Clear();

                    // create log file for writing exceptions
                    if (File.Exists(strExceptionsLogFilePath))
                    {
                        File.Delete(strExceptionsLogFilePath);
                    }
                    FileStream fs = File.Create(strExceptionsLogFilePath);
                    fs.Close();

                    StreamWriter sw = File.AppendText(strExceptionsLogFilePath);
                    sw.Write("\r\n");
                    sw.WriteLine("The following Saba Training could not be imported");
                    sw.WriteLine("==============================================================================================================");
                    sw.Flush();
                    sw.Close();
                    #endregion

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strLocation = Convert.ToString(dt.Rows[i]["Location"]);
                        string strPK_Property_COPE_Id = Convert.ToString(dt.Rows[i]["PK_Property_COPE_Id"]);

                        if (strPK_Property_COPE_Id != "")
                        {
                            if (strLocation != "")
                            {
                                strLocation = strLocation.Replace("'", "''");
                                DataRow[] drArr = dt.Select("[Location]='" + strLocation + "' AND [PK_Property_COPE_Id] = '" + strPK_Property_COPE_Id + "'");
                                foreach (DataRow dr in drArr)
                                {
                                    Property_COPE_Saba_Training objSabaTraining = new Property_COPE_Saba_Training();

                                    if (SetDataFromXLS(dr, objSabaTraining))
                                    {
                                        //Property_COPE.SelectPKByLocation();
                                        Saba_Training_Exceptions objException = Saba_Training_Exceptions.None;
                                        #region "Check for Exceptions"

                                        if (objSabaTraining.FK_Property_COPE.HasValue)
                                        {
                                            Property_COPE objPropCope = new Property_COPE(objSabaTraining.FK_Property_COPE.Value);
                                            if (objSabaTraining.FK_Property_COPE != null && objPropCope.PK_Property_Cope_ID <= 0)
                                            {
                                                objException = Saba_Training_Exceptions.No_Match_PK_Property_COPE_Id;
                                                AppendLogPolicyException(dr, objException);
                                            }
                                            else
                                            {
                                                DataTable dtLo = LU_Location.SelectAllLocation().Tables[0];
                                                dtLo.DefaultView.RowFilter = "trim(DBA) = '" + strLocation + "' ";
                                                dtLo = dtLo.DefaultView.ToTable();

                                                LU_Location objLocation = new LU_Location(objPropCope.FK_LU_Location_ID);
                                                if (dtLo.Rows.Count == 0)
                                                {
                                                    objException = Saba_Training_Exceptions.Invalid_Location;
                                                    AppendLogPolicyException(dr, objException);
                                                }
                                                else if (!strLocation.Trim().ToLower().Equals(objLocation.dba.Replace("'", "''").Trim().ToLower()))
                                                {
                                                    objException = Saba_Training_Exceptions.No_Combination_Location_Property_Cope;
                                                    AppendLogPolicyException(dr, objException);
                                                }

                                                if (objSabaTraining.Number_of_Employees == null && Convert.ToString(dr["Number Of Associates To Be Trained In Quarter"]) == "")
                                                {
                                                    objException = Saba_Training_Exceptions.Blank_Number_of_Employees;
                                                    AppendLogPolicyException(dr, objException);
                                                }
                                                else if (objSabaTraining.Number_of_Employees == null && Convert.ToString(dr["Number Of Associates To Be Trained In Quarter"]) != "")
                                                {
                                                    objException = Saba_Training_Exceptions.Invalid_Number_of_Employees;
                                                    AppendLogPolicyException(dr, objException);
                                                }
                                                if (objSabaTraining.Number_Trained == null && Convert.ToString(dr["Number of Associates Trained In Quarter"]) == "")
                                                {
                                                    objException = Saba_Training_Exceptions.Blank_Employee_Trained;
                                                    AppendLogPolicyException(dr, objException);
                                                }
                                                else if (objSabaTraining.Number_Trained == null && Convert.ToString(dr["Number of Associates Trained In Quarter"]) != "")
                                                {
                                                    objException = Saba_Training_Exceptions.Invalid_Trained_Employees;
                                                    AppendLogPolicyException(dr, objException);
                                                }

                                                if (objSabaTraining.Year == null && Convert.ToString(dr["Year"]) == "")
                                                {
                                                    objException = Saba_Training_Exceptions.Blank_Year;
                                                    AppendLogPolicyException(dr, objException);
                                                }

                                                if (objSabaTraining.Year == null && Convert.ToString(dr["Quarter"]) == "")
                                                {
                                                    objException = Saba_Training_Exceptions.Blank_Quarter;
                                                    AppendLogPolicyException(dr, objException);
                                                }

                                                if (objSabaTraining.Number_of_Employees != null && objSabaTraining.Number_Trained != null && (objSabaTraining.Number_of_Employees < objSabaTraining.Number_Trained))
                                                {
                                                    objException = Saba_Training_Exceptions.Greater_Value;
                                                    AppendLogPolicyException(dr, objException);
                                                }

                                                //if (objSabaTraining.Date == null && Convert.ToString(dr["Date"]) == "")
                                                //{
                                                //    objException = Saba_Training_Exceptions.Blank_Date;
                                                //    AppendLogPolicyException(dr, objException);
                                                //}
                                                //else if (objSabaTraining.Date == null && Convert.ToString(dr["Date"]) != "")
                                                //{
                                                //    objException = Saba_Training_Exceptions.Invalid_Date;
                                                //    AppendLogPolicyException(dr, objException);
                                                //}

                                            }
                                        }
                                        else
                                        {
                                            objException = Saba_Training_Exceptions.Invalid_PK_Property_COPE_Id;
                                            AppendLogPolicyException(dr, objException);
                                        }

                                        #endregion

                                        // if no exception found
                                        if (objException == Saba_Training_Exceptions.None)
                                        {
                                            decimal PK_Property_COPE_Saba_Training = objSabaTraining.IsDateDuplicate();

                                            objSabaTraining.Update_Date = System.DateTime.Now;
                                            objSabaTraining.Updated_By = clsSession.UserName;

                                            if (PK_Property_COPE_Saba_Training > 0)
                                            {
                                                objSabaTraining.PK_Property_COPE_Saba_Training = PK_Property_COPE_Saba_Training;
                                                objSabaTraining.Update();
                                            }
                                            else
                                            {
                                                objSabaTraining.Insert();
                                            }
                                        }
                                        else
                                        {
                                            // keep track of the Policy row that is not imported
                                            dtSabaTrainingNotImported.ImportRow(dr);
                                        }
                                    }
                                    else
                                    {
                                        // keep track of the Policy row that is not imported
                                        dtSabaTrainingNotImported.ImportRow(dr);
                                    }
                                }
                                i = i + (drArr.Length - 1);
                            }
                            else
                            {
                                AppendLogPolicyException(dt.Rows[i], Saba_Training_Exceptions.Blank_Location);
                                dtSabaTrainingNotImported.ImportRow(dt.Rows[i]);
                            }
                        }
                        else
                        {
                            AppendLogPolicyException(dt.Rows[i], Saba_Training_Exceptions.Blank_PK_Property_COPE_Id);
                            dtSabaTrainingNotImported.ImportRow(dt.Rows[i]);
                        }
                    }

                    // delete uploaded file 
                    DeleteUploadedFile(strUploadedFile);

                    clsSession.Tbl_SabaTraining_Not_Imported = dtSabaTrainingNotImported;

                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "OpenPopup(" + dt.Rows.Count + ",'" +
                              Encryption.Encrypt(strExceptionsLogFilePath) + "','" + Encryption.Encrypt(strExceptionsLogFileURL) + "');", true);
                }
                catch (Exception ex)
                {
                    DeleteUploadedFile(strUploadedFile);
                    // show message for data imported
                    Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('" + ex.Message.Replace("'", "") + "');", true);
                }
            }
            else
            {
                // delete uploaded file
                DeleteUploadedFile(strUploadedFile);

                // show message for no data available
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('No data available to imort');", true);
            }
        }
        else
        {
            // delete uploaded file
            DeleteUploadedFile(strUploadedFile);

            // show message for file can not be imported
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "alert('Selected file can not be imported');", true);
        }
    }

    private bool SetDataFromXLS(DataRow dr, Property_COPE_Saba_Training objSabaTraining)
    {
        bool bValidData = true;
        #region "Add Saba Training Property Cope data "
        objSabaTraining.PK_Property_COPE_Saba_Training = 0;
        objSabaTraining.FK_Property_COPE = Convert.ToDecimal(dr["PK_Property_COPE_Id"]);

        if (Convert.ToString(dr["Number Of Associates To Be Trained In Quarter"]) != "")
        {
            int NumberEmp;
            int.TryParse(Convert.ToString(dr["Number Of Associates To Be Trained In Quarter"]), out NumberEmp);
            if (NumberEmp >= 0)
                objSabaTraining.Number_of_Employees = NumberEmp;
            else
            {
                bValidData = false;
                WriteDataError(dr, "Number Of Associates To Be Trained is invalid");
            }
        }

        if (Convert.ToString(dr["Number of Associates Trained In Quarter"]) != "")
        {
            int NumberEmp;
            int.TryParse(Convert.ToString(dr["Number of Associates Trained In Quarter"]), out NumberEmp);

            if (NumberEmp >= 0)
                objSabaTraining.Number_Trained = NumberEmp;
            else
            {
                bValidData = false;
                WriteDataError(dr, "Number of Associates Trained In Quarter is invalid");
            }
        }

        if (Convert.ToString(dr["Year"]) != "")
        {
            string strDate = "1/1/" + Convert.ToString(dr["Year"]);
            DateTime dt;
            if (DateTime.TryParse(strDate, out dt))
                objSabaTraining.Year = Convert.ToInt32(dr["Year"]);
            else
            {
                bValidData = false;
                WriteDataError(dr, "Year is invalid");
            }
        }

        if (Convert.ToString(dr["Quarter"]) != "")
        {
            int intQuarter;
            if (int.TryParse(Convert.ToString(dr["Quarter"]), out intQuarter))
            {
                if (intQuarter > 0 && intQuarter < 5)
                    objSabaTraining.Quarter = Convert.ToInt32(dr["Quarter"]);
                else
                {
                    bValidData = false;
                    WriteDataError(dr, "Quarter value must be between 1 and 4");
                }
            }
            else
            {
                bValidData = false;
                WriteDataError(dr, "Quarter is invalid");
            }
        }

        if (objSabaTraining.Number_of_Employees > 0)
        {
            objSabaTraining.Percent_Trained = (objSabaTraining.Number_Trained / objSabaTraining.Number_of_Employees) * 100.0M;
        }
        else if (objSabaTraining.Number_of_Employees == 0)
        {
            objSabaTraining.Percent_Trained = 100.0M;
        }
        #endregion
        return bValidData;
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
            if (File.Exists(AppConfig.SabaTrainingDocPath + strFile))
            {
                // delete the file
                File.Delete(AppConfig.SabaTrainingDocPath + strFile);
            }
        }
    }


    private void AppendLogPolicyException(DataRow drSabaTraining, Saba_Training_Exceptions exc)
    {
        string strErrorDesc = "";

        #region "Set Error Message for exception"

        if (exc == Saba_Training_Exceptions.Blank_Location)
            strErrorDesc = "Location is Missing";
        else if (exc == Saba_Training_Exceptions.Blank_PK_Property_COPE_Id)
            strErrorDesc = "PK_Property_COPE_ID is missing";
        else if (exc == Saba_Training_Exceptions.Blank_Date)
            strErrorDesc = "Date is missing";
        else if (exc == Saba_Training_Exceptions.Blank_Employee_Trained)
            strErrorDesc = "Number of Employees Trained to Date is missing";
        else if (exc == Saba_Training_Exceptions.Blank_Number_of_Employees)
            strErrorDesc = "Number Of Associates To Be Trained In Quarter is missing";
        else if (exc == Saba_Training_Exceptions.Greater_Value)
            strErrorDesc = "Number Of Associates To Be Trained In Quarter should be greater than or equal to Number of Associates Trained In Quarter";
        else if (exc == Saba_Training_Exceptions.Invalid_Location)
            strErrorDesc = "Invalid Location";
        else if (exc == Saba_Training_Exceptions.Invalid_PK_Property_COPE_Id)
            strErrorDesc = "Invalid PK_Property_COPE_ID";
        else if (exc == Saba_Training_Exceptions.Invalid_Trained_Employees)
            strErrorDesc = "Invalid Number of Associates Trained In Quarter";
        else if (exc == Saba_Training_Exceptions.Invalid_Number_of_Employees)
            strErrorDesc = "Invalid Number Of Associates To Be Trained In Quarter";
        else if (exc == Saba_Training_Exceptions.Invalid_Date)
            strErrorDesc = "Invalid Date";
        else if (exc == Saba_Training_Exceptions.No_Match_PK_Property_COPE_Id)
            strErrorDesc = "PK_Property_COPE_ID does not match with existing Property Cope";
        else if (exc == Saba_Training_Exceptions.NO_Match_Location)
            strErrorDesc = "Location does not match with existing Locations";
        else if (exc == Saba_Training_Exceptions.No_Combination_Location_Property_Cope)
            strErrorDesc = "Location does not match with existing Location of Property Cope";
        else if (exc == Saba_Training_Exceptions.Blank_Year)
            strErrorDesc = "Year is missing";
        else if (exc == Saba_Training_Exceptions.Invalid_Year)
            strErrorDesc = "Invalid Year";
        else if (exc == Saba_Training_Exceptions.Blank_Quarter)
            strErrorDesc = "Quarter is missing";
        else if (exc == Saba_Training_Exceptions.Invalid_Quarter)
            strErrorDesc = "Invalid Quarter";
        else if (exc == Saba_Training_Exceptions.Duplicate_Record)
            strErrorDesc = "Record for the specified Year and Quarter already exists";
        else if (exc == Saba_Training_Exceptions.None)
            strErrorDesc = "";
        else
            strErrorDesc = "";

        #endregion

        //print PK_Property_COPE_Id,Location and description of exception for the record.
        StreamWriter sw = File.AppendText(strExceptionsLogFilePath);
        sw.Write("\r\n");
        string strPK_Property_COPE_Id, strLocation;
        strPK_Property_COPE_Id = strLocation = "";
        strPK_Property_COPE_Id = Convert.ToString(drSabaTraining["PK_Property_COPE_Id"]);
        strLocation = Convert.ToString(drSabaTraining["Location"]);

        sw.WriteLine(strPK_Property_COPE_Id + ", " + strLocation + ", " + strErrorDesc);
        sw.Flush();
        sw.Close();
    }

    private void WriteDataError(DataRow drSabaTraining, string strError)
    {
        //print PK_Property_COPE_Id,Location and description of exception for the record.
        StreamWriter sw = File.AppendText(strExceptionsLogFilePath);
        sw.Write("\r\n");
        string strPK_Property_COPE_Id, strLocation;
        strPK_Property_COPE_Id = strLocation = "";
        strPK_Property_COPE_Id = Convert.ToString(drSabaTraining["PK_Property_COPE_Id"]);
        strLocation = Convert.ToString(drSabaTraining["Location"]);

        sw.WriteLine(strPK_Property_COPE_Id + ", " + strLocation + ", " + strError);
        sw.Flush();
        sw.Close();
    }

    public static DataTable GetDataToImport(string strFileName)
    {
        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""";

        OleDbConnection objConn = new OleDbConnection(strConn);
        try
        {
            objConn.Open();

            DataTable dtSheets = objConn.GetSchema("Tables");

            OleDbCommand objCommand = new OleDbCommand("Select * from [" + dtSheets.Rows[0]["Table_name"] + "]", objConn);

            OleDbDataAdapter da = new OleDbDataAdapter(objCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (objConn.State == ConnectionState.Open) objConn.Close();
            objConn.Dispose();

            return ds.Tables[0];
        }
        catch
        {
            if (objConn.State == ConnectionState.Open) objConn.Close();
            objConn.Dispose();
            return null;
        }
    }

    #endregion

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
