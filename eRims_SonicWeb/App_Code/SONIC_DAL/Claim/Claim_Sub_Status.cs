using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Claim_Sub_Status table.
	/// </summary>
	public sealed class Claim_Sub_Status
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Claim_Sub_Status;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Claim_Sub_Status value.
		/// </summary>
		public decimal? PK_Claim_Sub_Status
		{
			get { return _PK_Claim_Sub_Status; }
			set { _PK_Claim_Sub_Status = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Code value.
		/// </summary>
		public string Fld_Code
		{
			get { return _Fld_Code; }
			set { _Fld_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Fld_Desc value.
		/// </summary>
		public string Fld_Desc
		{
			get { return _Fld_Desc; }
			set { _Fld_Desc = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsClaim_Sub_Status class with default value.
		/// </summary>
		public Claim_Sub_Status() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsClaim_Sub_Status class based on Primary Key.
		/// </summary>
		public Claim_Sub_Status(decimal pK_Claim_Sub_Status) 
		{
			DataTable dtClaim_Sub_Status = SelectByPK(pK_Claim_Sub_Status).Tables[0];

			if (dtClaim_Sub_Status.Rows.Count == 1)
			{
				 SetValue(dtClaim_Sub_Status.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsClaim_Sub_Status class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drClaim_Sub_Status) 
		{
				if (drClaim_Sub_Status["PK_Claim_Sub_Status"] == DBNull.Value)
					this._PK_Claim_Sub_Status = null;
				else
					this._PK_Claim_Sub_Status = (decimal?)drClaim_Sub_Status["PK_Claim_Sub_Status"];

				if (drClaim_Sub_Status["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drClaim_Sub_Status["Fld_Code"];

				if (drClaim_Sub_Status["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drClaim_Sub_Status["Fld_Desc"];

				if (drClaim_Sub_Status["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drClaim_Sub_Status["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Claim_Sub_Status table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_Sub_StatusInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Claim_Sub_Status table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Claim_Sub_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_Sub_StatusSelectByPK");

			db.AddInParameter(dbCommand, "PK_Claim_Sub_Status", DbType.Decimal, pK_Claim_Sub_Status);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Claim_Sub_Status table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_Sub_StatusSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Claim_Sub_Status table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_Sub_StatusUpdate");

			
			db.AddInParameter(dbCommand, "PK_Claim_Sub_Status", DbType.Decimal, this._PK_Claim_Sub_Status);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Claim_Sub_Status table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Claim_Sub_Status)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Claim_Sub_StatusDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Claim_Sub_Status", DbType.Decimal, pK_Claim_Sub_Status);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
