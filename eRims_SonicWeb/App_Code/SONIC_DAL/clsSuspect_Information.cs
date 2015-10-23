using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Suspect_Information table.
	/// </summary>
	public sealed class clsSuspect_Information
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Suspect_Information;
		private string _Sex;
		private string _Description;
		private decimal? _FK_Event;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Suspect_Information value.
		/// </summary>
		public decimal? PK_Suspect_Information
		{
			get { return _PK_Suspect_Information; }
			set { _PK_Suspect_Information = value; }
		}

		/// <summary>
		/// Gets or sets the Sex value.
		/// </summary>
		public string Sex
		{
			get { return _Sex; }
			set { _Sex = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Event value.
		/// </summary>
		public decimal? FK_Event
		{
			get { return _FK_Event; }
			set { _FK_Event = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsSuspect_Information class with default value.
		/// </summary>
		public clsSuspect_Information() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsSuspect_Information class based on Primary Key.
		/// </summary>
		public clsSuspect_Information(decimal pK_Suspect_Information) 
		{
			DataTable dtSuspect_Information = SelectByPK(pK_Suspect_Information).Tables[0];

			if (dtSuspect_Information.Rows.Count == 1)
			{
				 SetValue(dtSuspect_Information.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsSuspect_Information class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSuspect_Information) 
		{
				if (drSuspect_Information["PK_Suspect_Information"] == DBNull.Value)
					this._PK_Suspect_Information = null;
				else
					this._PK_Suspect_Information = (decimal?)drSuspect_Information["PK_Suspect_Information"];

				if (drSuspect_Information["Sex"] == DBNull.Value)
					this._Sex = null;
				else
					this._Sex = (string)drSuspect_Information["Sex"];

				if (drSuspect_Information["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drSuspect_Information["Description"];

				if (drSuspect_Information["FK_Event"] == DBNull.Value)
					this._FK_Event = null;
				else
					this._FK_Event = (decimal?)drSuspect_Information["FK_Event"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Suspect_Information table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationInsert");

			
			if (string.IsNullOrEmpty(this._Sex))
				db.AddInParameter(dbCommand, "Sex", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sex", DbType.String, this._Sex);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Suspect_Information table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Suspect_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationSelectByPK");

			db.AddInParameter(dbCommand, "PK_Suspect_Information", DbType.Decimal, pK_Suspect_Information);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Suspect_Information table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Suspect_Information table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationUpdate");

			
			db.AddInParameter(dbCommand, "PK_Suspect_Information", DbType.Decimal, this._PK_Suspect_Information);
			
			if (string.IsNullOrEmpty(this._Sex))
				db.AddInParameter(dbCommand, "Sex", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Sex", DbType.String, this._Sex);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Suspect_Information table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Suspect_Information)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Suspect_Information", DbType.Decimal, pK_Suspect_Information);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects record from the Suspect_Information table by FK_Event.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByFK_Event(decimal FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Suspect_InformationSelectByFK_Event");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
