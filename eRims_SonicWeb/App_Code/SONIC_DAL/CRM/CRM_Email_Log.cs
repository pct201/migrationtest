using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for CRM_Email_Log table.
	/// </summary>
	public sealed class CRM_Email_Log
	{

		#region Private variables used to hold the property values

		private decimal? _PK_CRM_Email_Log;
		private string _Table_Name;
		private decimal? _FK_Table_Name;
		private DateTime? _Date;
		private string _Recipients;
		private string _CCs;
		private string _Subject;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_CRM_Email_Log value.
		/// </summary>
		public decimal? PK_CRM_Email_Log
		{
			get { return _PK_CRM_Email_Log; }
			set { _PK_CRM_Email_Log = value; }
		}

		/// <summary>
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Table_Name value.
		/// </summary>
		public decimal? FK_Table_Name
		{
			get { return _FK_Table_Name; }
			set { _FK_Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Date value.
		/// </summary>
		public DateTime? Date
		{
			get { return _Date; }
			set { _Date = value; }
		}

		/// <summary>
		/// Gets or sets the Recipients value.
		/// </summary>
		public string Recipients
		{
			get { return _Recipients; }
			set { _Recipients = value; }
		}

		/// <summary>
		/// Gets or sets the CCs value.
		/// </summary>
		public string CCs
		{
			get { return _CCs; }
			set { _CCs = value; }
		}

		/// <summary>
		/// Gets or sets the Subject value.
		/// </summary>
		public string Subject
		{
			get { return _Subject; }
			set { _Subject = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Email_Log class with default value.
		/// </summary>
		public CRM_Email_Log() 
		{

			this._PK_CRM_Email_Log = null;
			this._Table_Name = null;
			this._FK_Table_Name = null;
			this._Date = null;
			this._Recipients = null;
			this._CCs = null;
			this._Subject = null;
			this._Updated_By = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the CRM_Email_Log class based on Primary Key.
		/// </summary>
		public CRM_Email_Log(decimal pK_CRM_Email_Log) 
		{
			DataTable dtCRM_Email_Log = SelectByPK(pK_CRM_Email_Log).Tables[0];

			if (dtCRM_Email_Log.Rows.Count == 1)
			{
				DataRow drCRM_Email_Log = dtCRM_Email_Log.Rows[0];
				if (drCRM_Email_Log["PK_CRM_Email_Log"] == DBNull.Value)
					this._PK_CRM_Email_Log = null;
				else
					this._PK_CRM_Email_Log = (decimal?)drCRM_Email_Log["PK_CRM_Email_Log"];

				if (drCRM_Email_Log["Table_Name"] == DBNull.Value)
					this._Table_Name = null;
				else
					this._Table_Name = (string)drCRM_Email_Log["Table_Name"];

				if (drCRM_Email_Log["FK_Table_Name"] == DBNull.Value)
					this._FK_Table_Name = null;
				else
					this._FK_Table_Name = (decimal?)drCRM_Email_Log["FK_Table_Name"];

				if (drCRM_Email_Log["Date"] == DBNull.Value)
					this._Date = null;
				else
					this._Date = (DateTime?)drCRM_Email_Log["Date"];

				if (drCRM_Email_Log["Recipients"] == DBNull.Value)
					this._Recipients = null;
				else
					this._Recipients = (string)drCRM_Email_Log["Recipients"];

				if (drCRM_Email_Log["CCs"] == DBNull.Value)
					this._CCs = null;
				else
					this._CCs = (string)drCRM_Email_Log["CCs"];

				if (drCRM_Email_Log["Subject"] == DBNull.Value)
					this._Subject = null;
				else
					this._Subject = (string)drCRM_Email_Log["Subject"];

				if (drCRM_Email_Log["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drCRM_Email_Log["Updated_By"];

			}
			else
			{
				this._PK_CRM_Email_Log = null;
				this._Table_Name = null;
				this._FK_Table_Name = null;
				this._Date = null;
				this._Recipients = null;
				this._CCs = null;
				this._Subject = null;
				this._Updated_By = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the CRM_Email_Log table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_LogInsert");

			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Recipients))
				db.AddInParameter(dbCommand, "Recipients", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recipients", DbType.String, this._Recipients);
			
			if (string.IsNullOrEmpty(this._CCs))
				db.AddInParameter(dbCommand, "CCs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CCs", DbType.String, this._CCs);
			
			if (string.IsNullOrEmpty(this._Subject))
				db.AddInParameter(dbCommand, "Subject", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subject", DbType.String, this._Subject);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the CRM_Email_Log table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_CRM_Email_Log)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_LogSelectByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Email_Log", DbType.Decimal, pK_CRM_Email_Log);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the CRM_Email_Log table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_LogSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the CRM_Email_Log table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_LogUpdate");

			
			db.AddInParameter(dbCommand, "PK_CRM_Email_Log", DbType.Decimal, this._PK_CRM_Email_Log);
			
			if (string.IsNullOrEmpty(this._Table_Name))
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Table_Name", DbType.String, this._Table_Name);
			
			db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, this._FK_Table_Name);
			
			db.AddInParameter(dbCommand, "Date", DbType.DateTime, this._Date);
			
			if (string.IsNullOrEmpty(this._Recipients))
				db.AddInParameter(dbCommand, "Recipients", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recipients", DbType.String, this._Recipients);
			
			if (string.IsNullOrEmpty(this._CCs))
				db.AddInParameter(dbCommand, "CCs", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "CCs", DbType.String, this._CCs);
			
			if (string.IsNullOrEmpty(this._Subject))
				db.AddInParameter(dbCommand, "Subject", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Subject", DbType.String, this._Subject);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the CRM_Email_Log table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_CRM_Email_Log)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_LogDeleteByPK");

			db.AddInParameter(dbCommand, "PK_CRM_Email_Log", DbType.Decimal, pK_CRM_Email_Log);

			db.ExecuteNonQuery(dbCommand);
		}
        public static DataSet SelectByFK_CRM(decimal fK_Table_Name,string strTabelName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("CRM_Email_Log_SelectBy_FK");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, strTabelName);
          
            return db.ExecuteDataSet(dbCommand);
        }


        public static StringBuilder Customer_AbstractReport(decimal _PK_CRM_Customer)
        {
            CRM_Customer objCRMCustomer = new CRM_Customer(_PK_CRM_Customer);
            FileStream fsMail = null;
            fsMail = new FileStream(AppConfig.SitePath + @"\Sonic\CRM\CRM_Customer_Email.htm", FileMode.Open, FileAccess.Read);
          
            StreamReader rd = new StreamReader(fsMail);
            StringBuilder sbBody = new StringBuilder(rd.ReadToEnd().ToString());
            
            
            rd.Close();
            fsMail.Close();
            string strSource = "", strState = "", strDepartment="",strBand ="",strDeler ="",strDateofServiceEstimated="",StrDepartmentDetail="";
            
            #region "Customer Information"
            sbBody = sbBody.Replace("[ComplaintNumber]", Convert.ToString(objCRMCustomer.PK_CRM_Customer));
            sbBody = sbBody.Replace("[DateofIncident]", clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.Record_Date));
            if (objCRMCustomer.FK_LU_CRM_Source != null)
                strSource = new LU_CRM_Source((decimal)objCRMCustomer.FK_LU_CRM_Source).Fld_Desc;
            sbBody = sbBody.Replace("[Source]", Convert.ToString(strSource));
            sbBody = sbBody.Replace("[LastName]", Convert.ToString(objCRMCustomer.Last_Name));
            sbBody = sbBody.Replace("[FirstName]", Convert.ToString(objCRMCustomer.First_Name));
            sbBody = sbBody.Replace("[LastNameCoBuyer]", Convert.ToString(objCRMCustomer.Last_Name_Co_Buyer));
            sbBody = sbBody.Replace("[FirstNameCoBuyer]", Convert.ToString(objCRMCustomer.First_Name_Co_Buyer));
            sbBody = sbBody.Replace("[Address]", Convert.ToString(objCRMCustomer.Address));
            sbBody = sbBody.Replace("[City]", Convert.ToString(objCRMCustomer.City));
            if (objCRMCustomer.FK_State != null)
                strState = new State((decimal)objCRMCustomer.FK_State).FLD_state;
            sbBody = sbBody.Replace("[State]", Convert.ToString(strState));
            sbBody = sbBody.Replace("[Zip]", Convert.ToString(objCRMCustomer.Zip_Code));
            sbBody = sbBody.Replace("[Email]", objCRMCustomer.Email);
            sbBody = sbBody.Replace("[HomeTelephone]", Convert.ToString(objCRMCustomer.Home_Telephone));
            sbBody = sbBody.Replace("[CellTelephone]", Convert.ToString(objCRMCustomer.Cell_Telephone));
            sbBody = sbBody.Replace("[WorkTelephone]", Convert.ToString(objCRMCustomer.Work_Telephone));
            sbBody = sbBody.Replace("[WorkTelephoneExtension]", Convert.ToString(objCRMCustomer.Work_Telephone_Extension));
            sbBody = sbBody.Replace("[Summary]", objCRMCustomer.Summary);           
            sbBody = sbBody.Replace("[ComplaintGrid]", GetFieldNotes(_PK_CRM_Customer, 1));
            #endregion
            #region "Department Information"
            if (objCRMCustomer.FK_LU_CRM_Department != null)
                strDepartment = new LU_CRM_Department((decimal)objCRMCustomer.FK_LU_CRM_Department).Fld_Desc;
            sbBody = sbBody.Replace("[Department]", Convert.ToString(strDepartment));
            if (objCRMCustomer.FK_LU_CRM_Dept_Desc_Detail != null)
                StrDepartmentDetail = new LU_CRM_Dept_Desc_Detail((decimal)objCRMCustomer.FK_LU_CRM_Dept_Desc_Detail).Fld_Desc;
            sbBody = sbBody.Replace("[DepartmentDetail]", Convert.ToString(StrDepartmentDetail));
            sbBody = sbBody.Replace("[DateofService]",clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.Service_Date));
            strDateofServiceEstimated = objCRMCustomer.Service_Date_Est == "Y" ? "Yes" : "No";
            sbBody = sbBody.Replace("[DateofServiceEstimated]", Convert.ToString(strDateofServiceEstimated));
            if (objCRMCustomer.FK_LU_Location != null)
                strDeler = new LU_Location((decimal)objCRMCustomer.FK_LU_Location).dba;
            sbBody = sbBody.Replace("[Dealer]", Convert.ToString(strDeler));
            if (objCRMCustomer.FK_LU_CRM_Brand != null)
                strBand = new LU_CRM_Brand((decimal)objCRMCustomer.FK_LU_CRM_Brand).Fld_Desc;
            sbBody = sbBody.Replace("[Brand]", Convert.ToString(strBand));
            sbBody = sbBody.Replace("[Model]", Convert.ToString(objCRMCustomer.Model));
            sbBody = sbBody.Replace("[Year]", Convert.ToString(objCRMCustomer.Year));            
            #endregion

            #region "Contacts and Dates"

            string strCRMContacted = "", strCRM_Contacted_Resolution_2 = "", strCRM_Contacted_Resolution_1 = "", strResolutionManager = "", strFK_LU_CRM_RVP = "", strlblFK_LU_CRM_DFOD = "", strCustomer_Contacted_GM = "", strLegal_Attorney_General = "", strFK_LU_CRM_Legal_Email = "", strDemand_Letter="";
            if (objCRMCustomer.FK_LU_CRM_Contacted_Resolution_2 != null)
                strCRM_Contacted_Resolution_2 = new LU_CRM_Contacted_Resolution((decimal)objCRMCustomer.FK_LU_CRM_Contacted_Resolution_2).Fld_Desc;
            if (objCRMCustomer.FK_LU_CRM_Contacted_Resolution_1 != null)
                strCRM_Contacted_Resolution_1 = new LU_CRM_Contacted_Resolution((decimal)objCRMCustomer.FK_LU_CRM_Contacted_Resolution_1).Fld_Desc;
            if (objCRMCustomer.FK_LU_CRM_RVP != null)
                strFK_LU_CRM_RVP = new LU_CRM_RVP((decimal)objCRMCustomer.FK_LU_CRM_RVP).Fld_Desc;
            if (objCRMCustomer.FK_LU_CRM_DFOD != null)
                strlblFK_LU_CRM_DFOD = new LU_CRM_DFOD((decimal)objCRMCustomer.FK_LU_CRM_DFOD).Fld_Desc;
            if (objCRMCustomer.FK_LU_CRM_Legal_Email != null)
                strFK_LU_CRM_Legal_Email = new LU_CRM_Legal_Email((decimal)objCRMCustomer.FK_LU_CRM_Legal_Email).Subject;
            strCustomer_Contacted_GM = objCRMCustomer.Customer_Contacted_GM == "Y" ? "Yes" : "No";
            strLegal_Attorney_General = objCRMCustomer.Legal_Attorney_General == "Y" ? "Yes" : "No";
            strDemand_Letter = objCRMCustomer.Demand_Letter == "Y" ? "Yes" : "No";
            sbBody = sbBody.Replace("[CRMContacted]", Convert.ToString(strCRM_Contacted_Resolution_2));
            sbBody = sbBody.Replace("[ResolutionManager]", Convert.ToString(strCRM_Contacted_Resolution_1));
            sbBody = sbBody.Replace("[ResolutionManagerName]", Convert.ToString(objCRMCustomer.Resolution_Manager));
            sbBody = sbBody.Replace("[ResolutionManagerEmail]", Convert.ToString(objCRMCustomer.Resolution_Manager_Email));
            sbBody = sbBody.Replace("[CustomerContactedGM]", Convert.ToString(strCustomer_Contacted_GM));
            sbBody = sbBody.Replace("[GMName]", Convert.ToString(objCRMCustomer.GM_Name));
            sbBody = sbBody.Replace("[DateofContactRVP]", clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.RVP_Contact_Date));
            sbBody = sbBody.Replace("[DateofContactDFOD]", clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.DFOD_Contact_Date));
            sbBody = sbBody.Replace("[DateofLastUpdate]", clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.User_Update_Date));
            sbBody = sbBody.Replace("[RVPName]", Convert.ToString(strFK_LU_CRM_RVP));
            sbBody = sbBody.Replace("[DFOD]", Convert.ToString(strlblFK_LU_CRM_DFOD));
            sbBody = sbBody.Replace("[OtherContactName]", Convert.ToString(objCRMCustomer.Other_Cotnact_Name));
            sbBody = sbBody.Replace("[LegalAttorneyGeneral]", Convert.ToString(strLegal_Attorney_General));
            sbBody = sbBody.Replace("[LegalEmail]", Convert.ToString(strFK_LU_CRM_Legal_Email));
            sbBody = sbBody.Replace("[DemandLetter]", Convert.ToString(strDemand_Letter));
            sbBody = sbBody.Replace("[LastAction]", Convert.ToString(objCRMCustomer.Last_Action));
            #endregion

            #region "Field Notes"
            sbBody = sbBody.Replace("[Field Notes Grid]", GetFieldNotes(_PK_CRM_Customer,2));
            sbBody = sbBody.Replace("[FieldResolutionInformation]", Convert.ToString(objCRMCustomer.Field_Resolution_Information));            
            #endregion

            #region "Field Notes"
            string strComplete = "", strCallback_After_Resolution ="",strResolution_Letter_To_Customer ="",strSendBy = "",strLetter_NA="",strLetter_NA_Reason="";
            strComplete = objCRMCustomer.Complete == "Y" ? "Yes" : "No";
            strCallback_After_Resolution= objCRMCustomer.Customer_Callback_After_Resolution == "Y" ? "Yes" : "No";
            strResolution_Letter_To_Customer= objCRMCustomer.Resolution_Letter_To_Customer == "Y" ? "Yes" : "No";
            strLetter_NA = objCRMCustomer.Letter_NA == "Y" ? "Yes" : "No";
            if (objCRMCustomer.FK_LU_CRM_Response_Method != null)
              strSendBy = new LU_CRM_Response_Method((decimal)objCRMCustomer.FK_LU_CRM_Response_Method).Fld_Desc;
            if (objCRMCustomer.FK_LU_CRM_Letter_NA_Reason != null)
               strLetter_NA_Reason = new LU_CRM_Letter_NA_Reason((decimal)objCRMCustomer.FK_LU_CRM_Letter_NA_Reason).Fld_Desc;
            
            sbBody = sbBody.Replace("[ResolutionSummary]", Convert.ToString(objCRMCustomer.Resolution_Summary));
            sbBody = sbBody.Replace("[Complete]", Convert.ToString(strComplete));
            sbBody = sbBody.Replace("[CloseDate]", clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.Close_Date));
            sbBody = sbBody.Replace("[DaystoClose]", Convert.ToString(objCRMCustomer.Days_To_Close));
            sbBody = sbBody.Replace("[CustomerCallBackAfterResolved]", Convert.ToString(strCallback_After_Resolution));
            sbBody = sbBody.Replace("[ResolutionLettertoCustomer]", Convert.ToString(strResolution_Letter_To_Customer));
            sbBody = sbBody.Replace("[DateResolutionLetterSent]",  clsGeneral.FormatDBNullDateToDisplay(objCRMCustomer.Date_Resolution_Letter_Sent));    
            sbBody = sbBody.Replace("[SentBy]", Convert.ToString(strSendBy));
            sbBody = sbBody.Replace("[LetterNA]", Convert.ToString(strLetter_NA));          
            sbBody = sbBody.Replace("[LetterNAReason]", Convert.ToString(strLetter_NA_Reason));
            sbBody = sbBody.Replace("[LetterNANote]", Convert.ToString(objCRMCustomer.Letter_NA_Note));
            #endregion

            #region "Email Log"
            sbBody = sbBody.Replace("[EmailLog]", GetEmailLog(_PK_CRM_Customer));
            #endregion
                       

            #region "Attachments"

            sbBody = sbBody.Replace("[Attachments]", GetAttachmentDetails(_PK_CRM_Customer));
            #endregion

            if (!Directory.Exists(AppConfig.SitePath + @"\Documents\CRMCustomer"))
            {
                Directory.CreateDirectory(AppConfig.SitePath + @"\Documents\CRMCustomer");
            }
            FileStream fsMailCreate = null;
            fsMailCreate = new FileStream(AppConfig.SitePath + @"\Documents\CRMCustomer\CRM_Customer_Email.htm", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsMailCreate);
            sw.Write(sbBody);
            sw.Close();
            fsMailCreate.Close();
            return sbBody;
        }

        public static string GetFieldNotes(decimal _PK_CRM_Customer,int intCurType)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            if(intCurType ==1)
                sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;' class='HeaderRow' colspan='6'>Incident Grid Information </td></tr>");
            else
                sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;' class='HeaderRow' colspan='6'>Field Notes Grid Information </td></tr>");

            sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial;' colspan='6'>");

            DataSet dsNotes = CRM_Notes.SelectByFK_CRM(_PK_CRM_Customer, clsGeneral.CRM_Tables.CRM_Customer, intCurType);
            if (dsNotes !=null && dsNotes.Tables.Count> 0 && dsNotes.Tables[0].Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Date </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Note Abstract </td>");               
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dsNotes.Tables[0].Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Note_Date"]));      //dr["Note_Date"]);
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", dr["Note"]);                 
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr valign=top> No Record founds.</tr>");
                sbGrid.Append("</table>");
            }
            clsGeneral.DisposeOf(dsNotes);

            return sbGrid.ToString();
        }

        public static string GetEmailLog(decimal _PK_CRM_Customer)
        {
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
           
            sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;' class='HeaderRow' colspan='6'>Email Log </td></tr>"); 
            sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial;' colspan='6'>");
            DataSet dsEmailLog = CRM_Email_Log.SelectByFK_CRM(_PK_CRM_Customer, Convert.ToString(clsGeneral.CRM_Tables.CRM_Customer));
            if (dsEmailLog != null && dsEmailLog.Tables.Count > 0 && dsEmailLog.Tables[0].Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Date </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Subject </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Recipients </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> CCs </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dsEmailLog.Tables[0].Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", clsGeneral.FormatDBNullDateToDisplay(dr["Date"]));    
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["Subject"]));
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["Recipients"]));
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["CCs"]));
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr valign=top> No Record founds.</tr>");
                sbGrid.Append("</table>");
            }
            clsGeneral.DisposeOf(dsEmailLog);

            return sbGrid.ToString();
        }
        public static string GetAttachmentDetails(decimal _PK_CRM_Customer)
        {
            DataTable dtAttachment = CRM_Attachments.SelectByTableName(clsGeneral.Tables.CRM_Customer.ToString(), (int)_PK_CRM_Customer).Tables[0];
            StringBuilder sbGrid = new StringBuilder(string.Empty);
            sbGrid = new StringBuilder(string.Empty);
            sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; font-weight: bold;' class='HeaderRow' colspan='6'>Attachments</td></tr>");
            sbGrid.Append("<tr><td style='font-size: 12px; font-family: Arial; '  colspan='6'>");

            if (dtAttachment.Rows.Count > 0)
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr style='background-color: #7f7f7f; font-family: Arial; color: white; font-size: 12px; font-weight: bold' valign=top>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> Attachment Description </td>");
                sbGrid.Append("<td  style='font-family: Arial; font-size: 12px;' align='left'> File Name </td>");
                sbGrid.Append("</tr>");

                foreach (DataRow dr in dtAttachment.Rows)
                {
                    sbGrid.Append("<tr valign=top>");
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["Description"]));
                    sbGrid.AppendFormat("<td  style='font-family: Arial; font-size: 12px;' align='left'>  {0} </td>", Convert.ToString(dr["FileName"]).Substring(12));
                    sbGrid.Append("</tr>");
                }
                sbGrid.Append("</table>");
            }
            else
            {
                sbGrid.Append("<table width='100%'>");
                sbGrid.Append("<tr valign=top>No Records found.</tr>");
                sbGrid.Append("</table>");
            }
            clsGeneral.DisposeOf(dtAttachment);
            sbGrid.Append("</td></tr>");
            sbGrid.Append("<tr><td>&nbsp;</td></tr>");
            return sbGrid.ToString();
        }
    
    }
}
