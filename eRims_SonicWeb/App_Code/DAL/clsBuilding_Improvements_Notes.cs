using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Building_Improvements_Notes table.
	/// </summary>
	public sealed class clsBuilding_Improvements_Notes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Building_Improvement_Notes;
		private DateTime? _Date_Of_Note;
		private DateTime? _Update_Date;
		private string _Note;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Building_Improvement_Notes value.
		/// </summary>
		public decimal? PK_Building_Improvement_Notes
		{
			get { return _PK_Building_Improvement_Notes; }
			set { _PK_Building_Improvement_Notes = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Of_Note value.
		/// </summary>
		public DateTime? Date_Of_Note
		{
			get { return _Date_Of_Note; }
			set { _Date_Of_Note = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Note value.
		/// </summary>
		public string Note
		{
			get { return _Note; }
			set { _Note = value; }
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
		/// Initializes a new instance of the clsBuilding_Improvements_Notes class with default value.
		/// </summary>
		public clsBuilding_Improvements_Notes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsBuilding_Improvements_Notes class based on Primary Key.
		/// </summary>
		public clsBuilding_Improvements_Notes(decimal pK_Building_Improvement_Notes) 
		{
			DataTable dtBuilding_Improvements_Notes = SelectByPK(pK_Building_Improvement_Notes).Tables[0];

			if (dtBuilding_Improvements_Notes.Rows.Count == 1)
			{
				 SetValue(dtBuilding_Improvements_Notes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsBuilding_Improvements_Notes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drBuilding_Improvements_Notes) 
		{
				if (drBuilding_Improvements_Notes["PK_Building_Improvement_Notes"] == DBNull.Value)
					this._PK_Building_Improvement_Notes = null;
				else
					this._PK_Building_Improvement_Notes = (decimal?)drBuilding_Improvements_Notes["PK_Building_Improvement_Notes"];

				if (drBuilding_Improvements_Notes["Date_Of_Note"] == DBNull.Value)
					this._Date_Of_Note = null;
				else
					this._Date_Of_Note = (DateTime?)drBuilding_Improvements_Notes["Date_Of_Note"];

				if (drBuilding_Improvements_Notes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drBuilding_Improvements_Notes["Update_Date"];

				if (drBuilding_Improvements_Notes["Note"] == DBNull.Value)
					this._Note = null;
				else
					this._Note = (string)drBuilding_Improvements_Notes["Note"];

				if (drBuilding_Improvements_Notes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drBuilding_Improvements_Notes["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Building_Improvements_Notes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_NotesInsert");

			
			db.AddInParameter(dbCommand, "Date_Of_Note", DbType.DateTime, this._Date_Of_Note);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_Improvements_Notes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Building_Improvement_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_NotesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_Improvement_Notes", DbType.Decimal, pK_Building_Improvement_Notes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Building_Improvements_Notes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_NotesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_Improvements_Notes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_NotesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Building_Improvement_Notes", DbType.Decimal, this._PK_Building_Improvement_Notes);
			
			db.AddInParameter(dbCommand, "Date_Of_Note", DbType.DateTime, this._Date_Of_Note);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Note))
				db.AddInParameter(dbCommand, "Note", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Note", DbType.String, this._Note);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_Improvements_Notes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Building_Improvement_Notes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_NotesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_Improvement_Notes", DbType.Decimal, pK_Building_Improvement_Notes);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
