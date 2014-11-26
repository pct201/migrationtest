using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Franchise_Attachments table.
	/// </summary>
	public sealed class Franchise_Attachments
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Franchise_Attachments;
		private decimal? _FK_Franchise;
		private string _Type;
		private string _FileName;
		private string _Path;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Franchise_Attachments value.
		/// </summary>
		public decimal? PK_Franchise_Attachments
		{
			get { return _PK_Franchise_Attachments; }
			set { _PK_Franchise_Attachments = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Franchise value.
		/// </summary>
		public decimal? FK_Franchise
		{
			get { return _FK_Franchise; }
			set { _FK_Franchise = value; }
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
		/// Gets or sets the FileName value.
		/// </summary>
		public string FileName
		{
			get { return _FileName; }
			set { _FileName = value; }
		}

		/// <summary>
		/// Gets or sets the Path value.
		/// </summary>
		public string Path
		{
			get { return _Path; }
			set { _Path = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Franchise_Attachments class with default value.
		/// </summary>
		public Franchise_Attachments() 
		{

			this._PK_Franchise_Attachments = null;
			this._FK_Franchise = null;
			this._Type = null;
			this._FileName = null;
			this._Path = null;

		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Franchise_Attachments class based on Primary Key.
		/// </summary>
		public Franchise_Attachments(decimal pK_Franchise_Attachments) 
		{
			DataTable dtFranchise_Attachments = SelectByPK(pK_Franchise_Attachments).Tables[0];

			if (dtFranchise_Attachments.Rows.Count == 1)
			{
				DataRow drFranchise_Attachments = dtFranchise_Attachments.Rows[0];
				if (drFranchise_Attachments["PK_Franchise_Attachments"] == DBNull.Value)
					this._PK_Franchise_Attachments = null;
				else
					this._PK_Franchise_Attachments = (decimal?)drFranchise_Attachments["PK_Franchise_Attachments"];

				if (drFranchise_Attachments["FK_Franchise"] == DBNull.Value)
					this._FK_Franchise = null;
				else
					this._FK_Franchise = (decimal?)drFranchise_Attachments["FK_Franchise"];

				if (drFranchise_Attachments["Type"] == DBNull.Value)
					this._Type = null;
				else
					this._Type = (string)drFranchise_Attachments["Type"];

				if (drFranchise_Attachments["FileName"] == DBNull.Value)
					this._FileName = null;
				else
					this._FileName = (string)drFranchise_Attachments["FileName"];

				if (drFranchise_Attachments["Path"] == DBNull.Value)
					this._Path = null;
				else
					this._Path = (string)drFranchise_Attachments["Path"];

			}
			else
			{
				this._PK_Franchise_Attachments = null;
				this._FK_Franchise = null;
				this._Type = null;
				this._FileName = null;
				this._Path = null;
			}

		}

		#endregion

		/// <summary>
		/// Inserts a record into the Franchise_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsInsert");

			
			db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, this._FK_Franchise);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._FileName))
				db.AddInParameter(dbCommand, "FileName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FileName", DbType.String, this._FileName);
			
			if (string.IsNullOrEmpty(this._Path))
				db.AddInParameter(dbCommand, "Path", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Franchise_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private static DataSet SelectByPK(decimal pK_Franchise_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Franchise_Attachments", DbType.Decimal, pK_Franchise_Attachments);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Franchise_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Franchise_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Franchise_Attachments", DbType.Decimal, this._PK_Franchise_Attachments);
			
			db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, this._FK_Franchise);
			
			if (string.IsNullOrEmpty(this._Type))
				db.AddInParameter(dbCommand, "Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			
			if (string.IsNullOrEmpty(this._FileName))
				db.AddInParameter(dbCommand, "FileName", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "FileName", DbType.String, this._FileName);
			
			if (string.IsNullOrEmpty(this._Path))
				db.AddInParameter(dbCommand, "Path", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Path", DbType.String, this._Path);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Franchise_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Franchise_Attachments)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Franchise_Attachments", DbType.Decimal, pK_Franchise_Attachments);

			db.ExecuteNonQuery(dbCommand);
		}

        public static void DeleteByIDs(string strPKs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsDeleteByIDs");

            db.AddInParameter(dbCommand, "strPKs", DbType.String, strPKs);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFkFranchise(decimal fK_Franchise)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Franchise", DbType.Decimal, fK_Franchise);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}
