using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;
using System.Xml;
using System.Text;
using System.IO;

namespace SonicInspectioniPhone
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {
        public static string strConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SonicConnection"].ConnectionString);

        #region "Login"
        /// <summary>
        /// Check login details
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetLoginID(string strUserName, string strPassword)
        {
            return clsGeneral.GetLoginID(strUserName, Encryption.Encrypt(strPassword));
        }

        #endregion

        #region "Inspections"

        /// <summary>
        /// Select all Focus Areas
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectAllFocusAreas()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectAllFocusAreas");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Inspection PK by Location FK
        /// </summary>
        /// <param name="fK_LU_Location"></param>
        /// <returns></returns>
        [WebMethod]
        public int SelectPKByFKLoc(int fK_LU_Location)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_Inspection_ID"].Value);
        }

        /// <summary>
        /// Select Inspection PK by Location FK
        /// </summary>
        /// <param name="fK_LU_Location"></param>
        /// <returns></returns>
        [WebMethod]
        public bool IsQuestionsUpdated(DateTime Last_Fetched_Date)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("CHECK_Inspection_Questions_Updated");
            db.AddInParameter(dbCommand, "Last_Fetch_date", DbType.DateTime, Last_Fetched_Date);
           
            return Convert.ToBoolean(db.ExecuteNonQuery(dbCommand));           
        }

        /// <summary>
        /// Select Locations by Primary key
        /// </summary>
        /// <param name="pK_LU_Location_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet LocationSelectByPK(decimal pK_LU_Location_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Questions and Respons/options by selected Focus Area
        /// </summary>
        /// <param name="pK_Inspection_ID"></param>
        /// <param name="Focus_Area"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectQuestionsAndResposnsesByFocusArea(int pK_Inspection_ID, string Focus_Area)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectQuestionsAndResposnsesByFocusArea");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Questions by selected Focus Area and Inspection ID
        /// </summary>
        /// <param name="pK_Inspection_ID"></param>
        /// <param name="Focus_Area"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectQuestionsByFocusAreaAndInspection(int pK_Inspection_ID, string Focus_Area)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("SelectQuestionByFocusAreaAndInspection");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Attachment select by inspection PK
        /// </summary>
        /// <param name="fK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectByFK(int fK_Inspection_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, fK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select attachment by Focus Area
        /// </summary>
        /// <param name="Item_Number_Focus_Area"></param>
        /// <param name="FK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet AttachmentSelectByFocusArea(string Item_Number_Focus_Area, int FK_Inspection_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsSelectByFocusArea");

            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Questions by Focus Area
        /// </summary>
        /// <param name="PK_LU_Location_ID"></param>
        /// <param name="bSelectForAdd"></param>
        /// <param name="Focus_Area"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet QuestionSelectByFocusArea(decimal PK_LU_Location_ID, bool bSelectForAdd, string Focus_Area)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_QuestionsSelectByFocusArea");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, PK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            db.AddInParameter(dbCommand, "bSelectForAdd", DbType.Boolean, bSelectForAdd);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inspection select by Location FK
        /// </summary>
        /// <param name="fK_LU_Location"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectByFKLocation(int fK_LU_Location)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectByFKLocation");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            return db.ExecuteDataSet(dbCommand);


        }

        /// <summary>
        /// Select Departments
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet DepartmentSelectAll()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("LU_DepartmentSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Images by Focus Area
        /// </summary>
        /// <param name="Item_Number_Focus_Area"></param>
        /// <param name="FK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectImagesByFocusArea(string Item_Number_Focus_Area, int FK_Inspection_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsImagesSelectByFocusArea");

            db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, Item_Number_Focus_Area);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Number of deficiencies 
        /// </summary>
        /// <param name="pK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetNumberOfDeficiencies(decimal pK_Inspection_ID)
        {
            int intCnt = 0;
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetSqlStringCommand("select count(R.PK_Inspection_Responses_ID) from Inspection_Responses R inner join Inspection_Questions Q " +
                                                          "on Q.PK_Inspection_Questions_ID = R.FK_Inspection_Question_ID where R.FK_Inspection_ID = " + pK_Inspection_ID +
                                                         "and ISNULL(Convert(varchar(1),Deficiency_Noted),'N') = 'Y' ");

            object obj = db.ExecuteScalar(dbCommand);
            if (obj != DBNull.Value)
            {
                intCnt = Convert.ToInt32(obj);
            }

            return intCnt;
        }

        /// <summary>
        /// Get Number of Repeat Deficiencies
        /// </summary>
        /// <param name="pK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetNumberOfRepeat_Deficiency(decimal pK_Inspection_ID)
        {
            int intCnt = 0;
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetSqlStringCommand("select count(R.PK_Inspection_Responses_ID) from Inspection_Responses R inner join Inspection_Questions Q " +
                                                          "on Q.PK_Inspection_Questions_ID = R.FK_Inspection_Question_ID where R.FK_Inspection_ID = " + pK_Inspection_ID +
                                                         "and ISNULL(Convert(varchar(1),Repeat_Deficiency),'N') = 'Y' ");

            object obj = db.ExecuteScalar(dbCommand);
            if (obj != DBNull.Value)
            {
                intCnt = Convert.ToInt32(obj);
            }

            return intCnt;
        }

        /// <summary>
        /// Select Inspection by PK
        /// </summary>
        /// <param name="pK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet InspectionSelectByPK(int pK_Inspection_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectByPK");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Images by Inspection
        /// </summary>
        /// <param name="FK_Inspection_ID"></param>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectImagesByInspection(int FK_Inspection_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsImagesSelectByInspection");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inserts a record into the Inspection table.
        /// </summary>
        /// <returns></returns>
        /// 
        [WebMethod]
        public int InspectionInsert(int FK_LU_Location_ID, DateTime? iDate, string Inspector_Name, string UniqueVal, string Updated_By, DateTime? Updated_Date, string RLCM_Verified, bool No_Deficiencies, string Overall_Inspection_Comments, int? FK_LU_Inspection_Area)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionInsertiPhone");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, FK_LU_Location_ID);

            if (iDate != null && iDate != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "date", DbType.DateTime, iDate);
            else
                db.AddInParameter(dbCommand, "date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, Inspector_Name);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, Updated_Date);
            if (string.IsNullOrEmpty(RLCM_Verified))
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, RLCM_Verified);

            db.AddInParameter(dbCommand, "No_Deficiencies", DbType.Boolean, No_Deficiencies);
            db.AddInParameter(dbCommand, "Overall_Inspection_Comments", DbType.String, Overall_Inspection_Comments);
            if(FK_LU_Inspection_Area != null)
                db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, FK_LU_Inspection_Area);
            else
                db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, DBNull.Value);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Updates a record in the Inspection table.
        /// </summary>
        /// 
        [WebMethod]
        public void InspectionUpdate(int PK_Inspection_ID, int FK_LU_Location_ID, DateTime? iDate, string Inspector_Name, string UniqueVal, string Updated_By, DateTime? Updated_Date, string RLCM_Verified, bool No_Deficiencies, string Overall_Inspection_Comments, int? FK_LU_Inspection_Area)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionUpdate");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, PK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, FK_LU_Location_ID);

            if (iDate != null && iDate != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "date", DbType.DateTime, iDate);
            else
                db.AddInParameter(dbCommand, "date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, Inspector_Name);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, Updated_Date);
            if (string.IsNullOrEmpty(RLCM_Verified))
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, RLCM_Verified);

            db.AddInParameter(dbCommand, "No_Deficiencies", DbType.Boolean, No_Deficiencies);
            db.AddInParameter(dbCommand, "Overall_Inspection_Comments", DbType.String, Overall_Inspection_Comments);
            if (FK_LU_Inspection_Area != null)
                db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, FK_LU_Inspection_Area);
            else
                db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, DBNull.Value);
            db.ExecuteNonQuery(dbCommand);
        }


        /// <summary>
        /// Updates a record in the Inspection_Responses table.
        /// </summary>
        [WebMethod]
        public void InspectionResponseUpdate(int PK_Inspection_Responses_ID, int FK_Inspection_ID, int FK_Inspection_Question_ID, string Deficiency_Noted, string Department, DateTime? Date_Opened, string Recommended_Action, DateTime? Target_Completion_Date, DateTime? Actual_Completion_Date, string Notes, string UniqueVal, string Updated_By, DateTime? Updated_Date, string Repeat_Deficiency)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesUpdate");

            db.AddInParameter(dbCommand, "PK_Inspection_Responses_ID", DbType.Int32, PK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, Department);

            if (Date_Opened != null && Date_Opened != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, Recommended_Action);

            if (Target_Completion_Date != null && Target_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (Actual_Completion_Date != null && Actual_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, Actual_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, Updated_Date);
            if (string.IsNullOrEmpty(Repeat_Deficiency))
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, Repeat_Deficiency);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Inserts a record into the Inspection_Responses table.
        /// </summary>
        /// <returns></returns>
        /// 
        [WebMethod]
        public int InspectionResponseInsert(int FK_Inspection_ID, int FK_Inspection_Question_ID, string Deficiency_Noted, string Department, DateTime? Date_Opened, string Recommended_Action, DateTime? Target_Completion_Date, DateTime? Actual_Completion_Date, string Notes, string UniqueVal, string Updated_By, DateTime? Updated_Date, string Repeat_Deficiency)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_ResponsesInsert");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, Deficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, Department);

            if (Date_Opened != null && Date_Opened != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, Date_Opened);
            else
                db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, Recommended_Action);

            if (Target_Completion_Date != null && Target_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, Target_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, DBNull.Value);

            if (Actual_Completion_Date != null && Actual_Completion_Date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, Actual_Completion_Date);
            else
                db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Notes", DbType.String, Notes);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, Updated_Date);
            if (string.IsNullOrEmpty(Repeat_Deficiency))
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, Repeat_Deficiency);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Used to Bind SONIC dba DropDown
        /// </summary>
        /// <param name="dropDowns">Dropdown Lists</param>
        /// <param name="intID">used to selected a value using this param</param>
        /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
        [WebMethod]
        public DataTable FillLocationdba(decimal intUserID)
        {
            decimal CurrentEmployee = clsGeneral.Security(intUserID);
            if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
                CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
            else
                CurrentEmployee = 0;
            string Regional = string.Empty;
            DataSet dsRegion = clsGeneral.SelectBySecurityID(Convert.ToInt32(intUserID));
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
            DataTable dtData = clsGeneral.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
            dtData.DefaultView.RowFilter = " Active = 'Y' ";
            dtData.DefaultView.Sort = "Sonic_Location_Code";
            dtData = dtData.DefaultView.ToTable();

            return dtData;
        }

        /// <summary>
        /// Select all the Responses(Answers)
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectResponses()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_SelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all Questions
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectQuestions()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Questions_SelectAll");
            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Select all the Locations 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectLocations()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Location_SelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select all the Users
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectUsers()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Security_ServiceSelectAll");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// If the ReturnValue =0, records have been inserted successfully, else some problem might have occured while insertion
        /// </summary>
        /// <param name="FK_Inspection_ID"></param>
        /// <param name="FK_Inspection_Question_ID"></param>
        /// <param name="Deficiency_Noted"></param>
        /// <param name="Department"></param>
        /// <param name="Recommended_Action"></param>
        /// <param name="Target_Completion_Date"></param>
        /// <param name="Actual_Completion_Date"></param>
        /// <param name="Notes"></param>
        /// <param name="UniqueVal"></param>
        /// <param name="Repeat_Deficiency"></param>
        /// <param name="Updated_By"></param>
        /// <param name="Updated_Date"></param>
        /// <returns></returns>
        [WebMethod]
        public string[] BulkInsertResponse(int FK_Inspection_ID, string[] FK_Inspection_Question_ID, string[] Deficiency_Noted, string[] Department,
            string[] Recommended_Action, string[] Target_Completion_Date, string[] Actual_Completion_Date, string[] Notes, string[] UniqueVal, string[] Repeat_Deficiency,
            int Updated_By, DateTime Updated_Date, string[] Date_Opened)
        {
            string[] resultArr;
            string strFK_Inspection_Question_ID = string.Empty;
            string strDeficiency_Noted = string.Empty;
            string strDepartment = string.Empty;
            string strRecommended_Action = string.Empty;
            string strTarget_Completion_Date = string.Empty;
            string strActual_Completion_Date = string.Empty;
            string strNotes = string.Empty;
            string strUniqueVal = string.Empty;
            string strRepeat_Deficiency = string.Empty;
            string strDate_Opened = string.Empty;

            strFK_Inspection_Question_ID = string.Join(",", FK_Inspection_Question_ID);
            strDeficiency_Noted = string.Join(",", Deficiency_Noted);

            //There are multiple entries for Department so it would be | seperated i.e. 1,2|2,3,4|3,5
            strDepartment = string.Join("|", Department);

            strRecommended_Action = string.Join(",", Recommended_Action);
            strTarget_Completion_Date = string.Join(",", Target_Completion_Date);
            strActual_Completion_Date = string.Join(",", Actual_Completion_Date);
            strDate_Opened = string.Join(",", Date_Opened);
            strNotes = string.Join(",", Notes);
            strUniqueVal = string.Join(",", UniqueVal);
            strRepeat_Deficiency = string.Join(",", Repeat_Deficiency);

            strRepeat_Deficiency = strRepeat_Deficiency.Replace("0", "N");
            strRepeat_Deficiency = strRepeat_Deficiency.Replace("1", "Y");

            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("BulkInsertResponse");
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.String, strFK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Deficiency_Noted", DbType.String, strDeficiency_Noted);
            db.AddInParameter(dbCommand, "Department", DbType.String, strDepartment);
            db.AddInParameter(dbCommand, "Recommended_Action", DbType.String, strRecommended_Action);
            db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.String, strTarget_Completion_Date);
            db.AddInParameter(dbCommand, "Actual_Completion_Date", DbType.String, strActual_Completion_Date);
            db.AddInParameter(dbCommand, "Date_Opened", DbType.String, strDate_Opened);
            db.AddInParameter(dbCommand, "Notes", DbType.String, strNotes);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, strUniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, Updated_Date);
            db.AddInParameter(dbCommand, "Repeat_Deficiency", DbType.String, strRepeat_Deficiency);
            // Execute the query and return the new identity value
            string result = Convert.ToString(db.ExecuteScalar(dbCommand));
            if (result != string.Empty)
                resultArr = result.Split(',');
            else
                resultArr = new string[0];
            return resultArr;
        }

        /// <summary>
        /// Inspection - Attachment Insert
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public int InspectionAttachmentInsert(decimal FK_Inspection_ID, string Type, string Filename, string path)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AttachmentsInsert");

            db.AddInParameter(dbCommand, "Filename", DbType.String, Filename);
            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "path", DbType.String, path);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Focus Area Attachment
        /// </summary>
        /// <param name="FK_Inspection_Responses_ID"></param>
        /// <param name="Type"></param>
        /// <param name="Filename"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [WebMethod]
        public int InspectionResponseAttachmentInsert(decimal FK_Inspection_Responses_ID, string Type, string Filename, string path)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsInsert");

            db.AddInParameter(dbCommand, "FK_Inspection_Responses_ID", DbType.Int32, FK_Inspection_Responses_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);
            db.AddInParameter(dbCommand, "Filename", DbType.String, Filename);
            db.AddInParameter(dbCommand, "path", DbType.String, path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Focus Area Attachment
        /// </summary>
        /// <param name="FK_Inspection_Responses_ID"></param>
        /// <param name="Type"></param>
        /// <param name="Filename"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [WebMethod]
        public int InspectionResponseAttachmentInsertByQuestionID(decimal FK_Inspection_ID, decimal FK_Inspection_Question_ID, string Type, string Filename, string path)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Inspection_Responses_AttachmentsInsert_By_QuestionID");

            db.AddInParameter(dbCommand, "FK_Inspection_ID", DbType.Int32, FK_Inspection_ID);
            db.AddInParameter(dbCommand, "FK_Inspection_Question_ID", DbType.Int32, FK_Inspection_Question_ID);
            db.AddInParameter(dbCommand, "Type", DbType.String, Type);
            db.AddInParameter(dbCommand, "Filename", DbType.String, Filename);
            db.AddInParameter(dbCommand, "path", DbType.String, path);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Save Data Method
        /// </summary>
        [WebMethod]
        public int SaveInspectionAndReponses(int FK_LU_Location_ID, DateTime? iDate, string Inspector_Name, string UniqueVal, string Updated_By, string RLCM_Verified,
            bool No_Deficiencies, string Overall_Inspection_Comments, string[] FK_Inspection_Question_ID, string[] Deficiency_Noted, string[] Department, string[] Recommended_Action,
            string[] Target_Completion_Date, string[] Actual_Completion_Date, string[] Notes, string[] UniqueValRes, string[] Repeat_Deficiency, string[] Date_Opened, int? FK_LU_Inspection_Area)
        {
            #region " SAVE INSPECTION DATA "

            int PK_Inspection_ID = 0;

            // create object for the Inspection 
            Inspection objInspection = new Inspection();

            // get values from page controls            
            objInspection.FK_LU_Location_ID = FK_LU_Location_ID;
            objInspection.date = clsGeneral.FormatDateToStore(iDate);
            objInspection.Inspector_Name = Inspector_Name.Trim();
            objInspection.RLCM_Verified = RLCM_Verified;
            objInspection.No_Deficiencies = No_Deficiencies;
            objInspection.Overall_Inspection_Comments = Overall_Inspection_Comments.Trim();
            objInspection.UniqueVal = UniqueVal;
            objInspection.Updated_By = Convert.ToDecimal(Updated_By);
            objInspection.Updated_Date = DateTime.Now;
            if(FK_LU_Inspection_Area != null)
                objInspection.FK_LU_Inspection_Area = (int)FK_LU_Inspection_Area;

            PK_Inspection_ID = objInspection.Insert();

            #endregion

            #region " SAVE INSPECTION RESPONSE DATA "

             DataTable dtResponses = clsGeneral.InspectionResponseDataTable();

            for (int intI = 0; intI < FK_Inspection_Question_ID.Length; intI++)
            {
                DataRow dr = dtResponses.NewRow();

                dr["FK_Inspection_Question_ID"] = FK_Inspection_Question_ID[intI];
                dr["Deficiency_Noted"] = Deficiency_Noted[intI];
                dr["Repeat_Deficiency"] = Repeat_Deficiency[intI];
                dr["Department"] = Department[intI];
                dr["Recommended_Action"] = Recommended_Action[intI];
                dr["Date_Opened"] = Date_Opened[intI];
                dr["Target_Completion_Date"] = Target_Completion_Date[intI];
                dr["Actual_Completion_Date"] = Actual_Completion_Date[intI];
                dr["Notes"] = Notes[intI];
                dr["UniqueVal"] = UniqueValRes[intI];

                dtResponses.Rows.Add(dr);
            }
                       
            for (int i = 0; i < dtResponses.Rows.Count; i++)
            {               
                // create object for the inspection response 
                Inspection_Responses objResponse = new Inspection_Responses();

                // get values from page controls               
                objResponse.FK_Inspection_ID = PK_Inspection_ID;
                objResponse.FK_Inspection_Question_ID = Convert.ToInt32(dtResponses.Rows[i]["FK_Inspection_Question_ID"]);
                objResponse.Deficiency_Noted = Convert.ToString(dtResponses.Rows[i]["Deficiency_Noted"]);
                
                if (objResponse.Deficiency_Noted == "Y" && No_Deficiencies == false)
                {
                    objResponse.Repeat_Deficiency = Convert.ToString(dtResponses.Rows[i]["Repeat_Deficiency"]).Replace("0", "N").Replace("1", "Y");
                    objResponse.Department = Convert.ToString(dtResponses.Rows[i]["Department"]);
                    objResponse.Recommended_Action = Convert.ToString(dtResponses.Rows[i]["Recommended_Action"]);
                    objResponse.Date_Opened = clsGeneral.FormatDateToStore(dtResponses.Rows[i]["Date_Opened"]);
                    objResponse.Target_Completion_Date = clsGeneral.FormatDateToStore(dtResponses.Rows[i]["Target_Completion_Date"]);
                    objResponse.Actual_Completion_Date = clsGeneral.FormatDateToStore(dtResponses.Rows[i]["Actual_Completion_Date"]);                    
                    objResponse.Notes = Convert.ToString(dtResponses.Rows[i]["Notes"]);
                }
                objResponse.UniqueVal = Convert.ToString(dtResponses.Rows[i]["UniqueVal"]);
                objResponse.Updated_By = Convert.ToDecimal(Updated_By);
                objResponse.Updated_Date = DateTime.Now;

                objResponse.Insert();
            }

            #endregion

            return PK_Inspection_ID;
        }

        /// <summary>
        /// Selects all active Inspection Area
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public DataSet SelectAllActiveInspectionArea()
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaSelectActive");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_Inspection_Area table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        [WebMethod]
        public DataSet LU_Inspection_AreaSelectByPK(decimal pK_LU_Inspection_Area)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Inspection_AreaSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Inspection_Area", DbType.Decimal, pK_LU_Inspection_Area);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }

    /// <summary>
    /// Class General
    /// </summary>
    public class clsGeneral
    {
        public static string strConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SonicConnection"].ConnectionString);

        /// <summary>
        /// Get login details
        /// </summary>
        /// <param name="strUserName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static int GetLoginID(string strUserName, string strPassword)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);

            DbCommand dbCommand = db.GetStoredProcCommand("SecurityGetLoginID");

            db.AddInParameter(dbCommand, "strUserID", DbType.String, strUserName);
            db.AddInParameter(dbCommand, "strPassword", DbType.String, strPassword);
            db.AddOutParameter(dbCommand, "intUserID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["intUserID"].Value);
        }

        /// <summary>
        /// get security
        /// </summary>
        /// <param name="PK"></param>
        /// <returns></returns>
        public static decimal Security(decimal PK)
        {
            DataTable dtSecurity = SelectByPK(PK).Tables[0];
            decimal Employee_Id = 0;
            if (dtSecurity.Rows.Count > 0)
            {
                DataRow drSecurity = dtSecurity.Rows[0];
                if (drSecurity["Employee_Id"] != DBNull.Value)
                    Employee_Id = Convert.ToDecimal(drSecurity["Employee_Id"]);
            }

            return Employee_Id;
        }

        /// <summary>
        /// Selects a single record from the Security table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Security_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("SecuritySelectByPK");

            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, pK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Regional_Access table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectBySecurityID(int FK_Security_ID)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Regional_AccessSelectBySecurity");

            db.AddInParameter(dbCommand, "FK_Security_ID", DbType.Int32, FK_Security_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Location table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll(Nullable<decimal> CurrentEmployee, string Regional)
        {
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectAll");
            db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "Regional", DbType.String, Regional);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// return Date in short date format if it is null then it return minimum value 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime FormatDateToStore(object objDate)
        {
            if (!String.IsNullOrEmpty(objDate.ToString()))
            {
                return Convert.ToDateTime(objDate.ToString());
            }
            else
            {
                return (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }

        /// <summary>
        /// Create Inspection Response Table
        /// </summary>
        /// <returns></returns>
        public static DataTable InspectionResponseDataTable()
        {
            DataTable dtResponse = new DataTable();

            dtResponse.Columns.Add("FK_Inspection_Question_ID");
            dtResponse.Columns.Add("Deficiency_Noted");
            dtResponse.Columns.Add("Department");
            dtResponse.Columns.Add("Recommended_Action");
            dtResponse.Columns.Add("Target_Completion_Date");
            dtResponse.Columns.Add("Actual_Completion_Date");
            dtResponse.Columns.Add("Date_Opened");
            dtResponse.Columns.Add("Notes");
            dtResponse.Columns.Add("UniqueVal");
            dtResponse.Columns.Add("Repeat_Deficiency");

            return dtResponse;
        }


    }

    /// <summary>
    /// Class Encription
    /// </summary>
    public class Encryption
    {
        #region Donot Change this variables
        private static byte[] key = { };
        private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static string EncryptionKey = "!5623a#de";
        #endregion

        public Encryption()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// used to Decrypt the passing String
        /// </summary>
        /// <param name="Input">Encrypted String</param>
        /// <returns></returns>
        public static string Decrypt(string Input)
        {
            Input = Input.Replace("$", "+");
            Byte[] inputByteArray = new Byte[Input.Length];
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(Input);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());

            }
            catch (Exception ex)
            {
                return "";
            }

        }
        /// <summary>
        /// Used to Encrypt the Passed String
        /// </summary>
        /// <param name="Input">String for Encryption</param>
        /// <returns></returns>
        public static string Encrypt(string Input)
        {
            try
            {
                key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray()).Replace("+", "$");
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}