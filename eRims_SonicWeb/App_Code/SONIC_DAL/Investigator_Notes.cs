using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Investigator_Notes table.
	/// </summary>
	public sealed class Investigator_Notes
	{
        #region Fields

        private DateTime _Date_Of_Note;
        private decimal _FK_Executive_Risk;
        private string _Investigator_Name;
        private string _Note_Subject;
        private string _Notes;
        private decimal _PK_Investigator_Notes;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the Date_Of_Note value.
        /// </summary>
        public DateTime Date_Of_Note
        {
            get { return _Date_Of_Note; }
            set { _Date_Of_Note = value; }
        }
        
        /// <summary> 
        /// Gets or sets the FK_Executive_Risk value.
        /// </summary>
        public decimal FK_Executive_Risk
        {
            get { return _FK_Executive_Risk; }
            set { _FK_Executive_Risk = value; }
        }

        /// <summary> 
        /// Gets or sets the Investigator_Name value.
        /// </summary>
        public string Investigator_Name
        {
            get { return _Investigator_Name; }
            set { _Investigator_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Note_Subject value.
        /// </summary>
        public string Note_Subject
        {
            get { return _Note_Subject; }
            set { _Note_Subject = value; }
        }


        /// <summary> 
        /// Gets or sets the Notes value.
        /// </summary>
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }


        /// <summary> 
        /// Gets or sets the PK_Investigator_Notes value.
        /// </summary>
        public decimal PK_Investigator_Notes
        {
            get { return _PK_Investigator_Notes; }
            set { _PK_Investigator_Notes = value; }
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
        #endregion


        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Investigator_Notes class. with the default value.
        /// </summary>
        public Investigator_Notes()
        {
            this._Date_Of_Note = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_Executive_Risk = -1;
            this._Investigator_Name = "";
            this._Note_Subject = "";
            this._Notes = "";
            this._PK_Investigator_Notes = -1;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }



        /// <summary> 
        /// Initializes a new instance of the Investigator_Notes class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Investigator_Notes(decimal PK)
        {

            DataTable dtInvestigator_Notes = SelectByPK(PK).Tables[0];

            if (dtInvestigator_Notes.Rows.Count > 0)
            {

                DataRow drInvestigator_Notes = dtInvestigator_Notes.Rows[0];

                this._Date_Of_Note = drInvestigator_Notes["Date_Of_Note"] != DBNull.Value ? Convert.ToDateTime(drInvestigator_Notes["Date_Of_Note"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Executive_Risk = drInvestigator_Notes["FK_Executive_Risk"] != DBNull.Value ? Convert.ToDecimal(drInvestigator_Notes["FK_Executive_Risk"]) : 0;
                this._Investigator_Name = Convert.ToString(drInvestigator_Notes["Investigator_Name"]);
                this._Note_Subject = Convert.ToString(drInvestigator_Notes["Note_Subject"]);
                this._Notes = Convert.ToString(drInvestigator_Notes["Notes"]);
                this._PK_Investigator_Notes = drInvestigator_Notes["PK_Investigator_Notes"] != DBNull.Value ? Convert.ToDecimal(drInvestigator_Notes["PK_Investigator_Notes"]) : 0;
                this._Updated_By = drInvestigator_Notes["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drInvestigator_Notes["Updated_By"]) : 0;
                this._Updated_Date = drInvestigator_Notes["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drInvestigator_Notes["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

            else
            {

                this._Date_Of_Note = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_Executive_Risk = -1;
                this._Investigator_Name = "";
                this._Note_Subject = "";
                this._Notes = "";
                this._PK_Investigator_Notes = -1;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }

        }
        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Investigator_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesInsert");

			db.AddInParameter(dbCommand, "Date_Of_Note", DbType.DateTime, this._Date_Of_Note);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, this._Investigator_Name);
			db.AddInParameter(dbCommand, "Note_Subject", DbType.String, this._Note_Subject);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Investigator_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(decimal pK_Investigator_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Investigator_Notes", DbType.Decimal, pK_Investigator_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Investigator_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Investigator_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesUpdate");

			db.AddInParameter(dbCommand, "Date_Of_Note", DbType.DateTime, this._Date_Of_Note);
			db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, this._FK_Executive_Risk);
			db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, this._Investigator_Name);
			db.AddInParameter(dbCommand, "Note_Subject", DbType.String, this._Note_Subject);
			db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			db.AddInParameter(dbCommand, "PK_Investigator_Notes", DbType.Decimal, this._PK_Investigator_Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Investigator_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Investigator_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Investigator_Notes", DbType.Decimal, pK_Investigator_Notes);

			db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(decimal fK_Executive_Risk)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigator_NotesSelectByFK");

            db.AddInParameter(dbCommand, "FK_Executive_Risk", DbType.Decimal, fK_Executive_Risk);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
