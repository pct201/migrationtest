using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Configuration;

namespace SonicInspectioniPhone
{
	/// <summary>
	/// Data access class for Inspection table.
	/// </summary>
	public sealed class Inspection
    {
        #region Fields

        public string strConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["SonicConnection"].ConnectionString);
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
        }      

        #endregion

        #region Methods

        /// <summary>
		/// Inserts a record into the Inspection table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
            		
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionInsert");

			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this.date != null &&  this.date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
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
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}
		
		/// <summary>
		/// Updates a record in the Inspection table.
		/// </summary>
		public void Update()
		{
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnectionString, factory);
			DbCommand dbCommand = db.GetStoredProcCommand("InspectionUpdate");

			db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Int32, this._PK_Inspection_ID);
			db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);

            if (this.date != null && this.date != (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
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
			db.ExecuteNonQuery(dbCommand);
		}		
        
        #endregion
    }
}
