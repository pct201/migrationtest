using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for UserHelp table.
	/// </summary>
	public sealed class UserHelp
	{

		#region Private variables used to hold the property values

		private decimal? _PK_UserHelp;
		private string _Type;
		private string _Description;
		private string _URL;
		private string _Active;
		private string _Updated_By;
		private DateTime? _Update_Date;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_UserHelp value.
		/// </summary>
		public decimal? PK_UserHelp
		{
			get { return _PK_UserHelp; }
			set { _PK_UserHelp = value; }
		}

		/// <summary>
		/// Gets or sets the Type value.
		/// </summary>
		public string Type
		{
			get { return _Type; }
			set { _Type = value; }
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
		/// Gets or sets the URL value.
		/// </summary>
		public string URL
		{
			get { return _URL; }
			set { _URL = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the UserHelp class with default value.
		/// </summary>
		public UserHelp() 
		{

			this._PK_UserHelp = null;
			this._Type = null;
			this._Description = null;
			this._URL = null;
			this._Active = null;
			this._Updated_By = null;
			this._Update_Date = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the UserHelp class based on Primary Key.
		/// </summary>
		public UserHelp(decimal pK_UserHelp) 
		{
			DataTable dtUserHelp = SelectByPK(pK_UserHelp).Tables[0];

			if (dtUserHelp.Rows.Count == 1)
			{
				DataRow drUserHelp = dtUserHelp.Rows[0];
				if (drUserHelp["PK_UserHelp"] == DBNull.Value)
					this._PK_UserHelp = null;
				else
					this._PK_UserHelp = (decimal?)drUserHelp["PK_UserHelp"];

				if (drUserHelp["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drUserHelp["Type"];

				if (drUserHelp["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drUserHelp["Description"];

				if (drUserHelp["URL"] == DBNull.Value)
					this._URL = null;
				else
					this._URL = (string)drUserHelp["URL"];

				if (drUserHelp["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drUserHelp["Active"];

				if (drUserHelp["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drUserHelp["Updated_By"];

				if (drUserHelp["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drUserHelp["Update_Date"];

			}
			else
			{
				this._PK_UserHelp = null;
				this._Type = null;
				this._Description = null;
				this._URL = null;
				this._Active = null;
				this._Updated_By = null;
				this._Update_Date = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the UserHelp table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserHelpInsert");

			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._URL))
				db.AddInParameter(dbCommand, "URL", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "URL", DbType.String, this._URL);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the UserHelp table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_UserHelp)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserHelpSelectByPK");

			db.AddInParameter(dbCommand, "PK_UserHelp", DbType.Decimal, pK_UserHelp);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the UserHelp table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserHelpSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the UserHelp table.
		/// </summary>
        public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UserHelpUpdate");

			
			db.AddInParameter(dbCommand, "PK_UserHelp", DbType.Decimal, this._PK_UserHelp);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._URL))
				db.AddInParameter(dbCommand, "URL", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "URL", DbType.String, this._URL);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}
	}
}
