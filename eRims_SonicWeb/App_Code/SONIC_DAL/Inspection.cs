using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Inspection table.
	/// </summary>
	public sealed class Inspection
    {
        #region Fields


        private int _PK_Inspection_ID;
        private int _FK_LU_Location_ID;
        private DateTime _date;
        private string _Inspector_Name;
        private string _UniqueVal;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private string _RLCM_Verified;
        private bool _No_Deficiencies;
        private string _Overall_Inspection_Comments;
        private int _FK_LU_Inspection_Area;
        private string _Fld_Desc;
        private DateTime? _Date_Report_Initially_Distibuted;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Inspection_ID value.
        /// </summary>
        public int PK_Inspection_ID
        {
            get { return _PK_Inspection_ID; }
            set { _PK_Inspection_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the date value.
        /// </summary>
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Inspector_Name
        {
            get { return _Inspector_Name; }
            set { _Inspector_Name = value; }
        }
        /// <summary> 
        /// Gets or sets the UniqueVal value.
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Verified value.
        /// </summary>
        public string RLCM_Verified
        {
            get { return _RLCM_Verified; }
            set { _RLCM_Verified = value; }
        }
        // Get or sets the _No_Deficiencies value
        public bool No_Deficiencies
        {
            get { return _No_Deficiencies; }
            set { _No_Deficiencies = value; }
        }

        /// <summary> 
        /// Gets or sets the Lessons_Learned value.
        /// </summary>
        public string Overall_Inspection_Comments
        {
            get { return _Overall_Inspection_Comments; }
            set { _Overall_Inspection_Comments = value; }
        }

        public int FK_LU_Inspection_Area
        {
            get { return _FK_LU_Inspection_Area; }
            set { _FK_LU_Inspection_Area = value; }
        }

        public string Fld_Desc
        {
            get { return _Fld_Desc; }
            set { _Fld_Desc = value; }
        }
        public DateTime? Date_Report_Initially_Distibuted
        {
            get { return _Date_Report_Initially_Distibuted; }
            set { _Date_Report_Initially_Distibuted = value; }
        }
        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Inspection class. with the default value.

        /// </summary>
        public Inspection()
        {

            this._PK_Inspection_ID = -1;
            this._FK_LU_Location_ID = -1;
            this._date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Inspector_Name = "";
            this._UniqueVal = "";
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._RLCM_Verified = null;
            this._No_Deficiencies = false;
            this._Overall_Inspection_Comments = "";
            this._FK_LU_Inspection_Area = -1;
            this._Fld_Desc = "";
            this._Date_Report_Initially_Distibuted = null;
        }



        /// <summary> 

        /// Initializes a new instance of the Inspection class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public Inspection(int PK)
        {

            DataTable dtInspection = SelectByPK(PK).Tables[0];

            if (dtInspection.Rows.Count > 0)
            {

                DataRow drInspection = dtInspection.Rows[0];

                this._PK_Inspection_ID = drInspection["PK_Inspection_ID"] != DBNull.Value ? Convert.ToInt32(drInspection["PK_Inspection_ID"]) : 0;
                this._FK_LU_Location_ID = drInspection["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drInspection["FK_LU_Location_ID"]) : 0;
                this._date = drInspection["date"] != DBNull.Value ? Convert.ToDateTime(drInspection["date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Inspector_Name = drInspection["Inspector_Name"] != DBNull.Value ? Convert.ToString(drInspection["Inspector_Name"]) : "";
                this._UniqueVal = Convert.ToString(drInspection["UniqueVal"]);
                this._Updated_By = drInspection["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drInspection["Updated_By"]) : 0;
                this._Updated_Date = drInspection["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drInspection["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drInspection["RLCM_Verified"] == DBNull.Value)
                    this._RLCM_Verified = null;
                else
                    this._RLCM_Verified = (string)drInspection["RLCM_Verified"];
                this._No_Deficiencies = (drInspection["No_Deficiencies"] != DBNull.Value) ? Convert.ToBoolean(drInspection["No_Deficiencies"]) : false;
                this._Overall_Inspection_Comments = Convert.ToString(drInspection["Overall_Inspection_Comments"]);
                this._FK_LU_Inspection_Area = (drInspection["FK_LU_Inspection_Area"] != DBNull.Value) ? Convert.ToInt32(drInspection["FK_LU_Inspection_Area"]) : 0;
                this._Fld_Desc = Convert.ToString(drInspection["Fld_Desc"]);
                if (drInspection["Date_Report_Initially_Distibuted"] != DBNull.Value)
                {
                    this._Date_Report_Initially_Distibuted = Convert.ToDateTime(drInspection["Date_Report_Initially_Distibuted"]);
                }
                else
                {
                    this._Date_Report_Initially_Distibuted = null;
                }

            }

            else
            {

                this._PK_Inspection_ID = -1;
                this._FK_LU_Location_ID = -1;
                this._date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Inspector_Name = "";
                this._UniqueVal = "";
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._RLCM_Verified = null;
                this._No_Deficiencies = false;
                this._Overall_Inspection_Comments = "";
                this._FK_LU_Inspection_Area = -1;
                this._Fld_Desc = "";
                this._Date_Report_Initially_Distibuted = null;
            }

        }



        #endregion

        #region Methods

        /// <summary>
		/// Inserts a record into the Inspection table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionInsert");

			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this.date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "date", DbType.DateTime, this._date);
            else
                db.AddInParameter(dbCommand, "date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._RLCM_Verified))
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, this._RLCM_Verified);

            db.AddInParameter(dbCommand, "No_Deficiencies", DbType.Boolean, this._No_Deficiencies);
            db.AddInParameter(dbCommand, "Overall_Inspection_Comments", DbType.String, this._Overall_Inspection_Comments);
            db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, this._FK_LU_Inspection_Area);
            db.AddInParameter(dbCommand, "Date_Report_Initially_Distibuted", DbType.DateTime, this._Date_Report_Initially_Distibuted);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Inspection table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Inspection_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectByPK");

			db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Inspection table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Inspection table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionUpdate");

			db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, this._PK_Inspection_ID);
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this.date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "date", DbType.DateTime, this._date);
            else
                db.AddInParameter(dbCommand, "date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Inspector_Name", DbType.String, this._Inspector_Name);
            db.AddInParameter(dbCommand, "UniqueVal", DbType.String, this._UniqueVal);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._RLCM_Verified))
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Verified", DbType.String, this._RLCM_Verified);
            db.AddInParameter(dbCommand, "No_Deficiencies", DbType.Boolean, this._No_Deficiencies);
            db.AddInParameter(dbCommand, "Overall_Inspection_Comments", DbType.String, this._Overall_Inspection_Comments);
            db.AddInParameter(dbCommand, "FK_LU_Inspection_Area", DbType.Int32, this._FK_LU_Inspection_Area);
            db.AddInParameter(dbCommand, "Date_Report_Initially_Distibuted", DbType.DateTime, this._Date_Report_Initially_Distibuted);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Inspection table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Inspection_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        

        public static DataSet SelectQuestionsAndResposnses(int pK_Inspection_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectQuestionsAndResposnses");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        public static int SelectPKByFKLoc(int fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_Inspection_ID"].Value);
        }
        //InspectionSelectByFKLocation

        public static DataSet SelectByFKLocation(int fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectByFKLocation");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);            
            return db.ExecuteDataSet(dbCommand);            
        }

        public static DataSet SelectQuestionsAndResposnsesByFocusArea(int pK_Inspection_ID, string Focus_Area)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectQuestionsAndResposnsesByFocusArea");

            db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, pK_Inspection_ID);
            db.AddInParameter(dbCommand, "Focus_Area", DbType.String, Focus_Area);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectEmailIDs(decimal FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InspectionSelectEmailIDs");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static int GetNumberOfDeficiencies(decimal pK_Inspection_ID)
        {
            int intCnt = 0;
            Database db = DatabaseFactory.CreateDatabase();
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

        public static int GetNumberOfRepeat_Deficiency(decimal pK_Inspection_ID)
        {
            int intCnt = 0;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("select count(R.PK_Inspection_Responses_ID) from Inspection_Responses R inner join Inspection_Questions Q " +
                                                          "on Q.PK_Inspection_Questions_ID = R.FK_Inspection_Question_ID where R.FK_Inspection_ID = " + pK_Inspection_ID +
                                                         "and ISNULL(Convert(varchar(1),Repeat_Deficiency),'N') = 'Y' and Q.Question_Text NOT LIKE 'Misc%'  ");

            object obj = db.ExecuteScalar(dbCommand);
            if (obj != DBNull.Value)
            {
                intCnt = Convert.ToInt32(obj);
            }

            return intCnt;
        }
        
        #endregion
    }
}
