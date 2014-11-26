using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Aci_Lu_Location table.
	/// </summary>
	public sealed class clsAci_Lu_Location
	{

		#region Private variables used to hold the property values

		private decimal? _PK_ACI_LU_Location;
		private string _Fld_Code;
		private string _Fld_Desc;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_ACI_LU_Location value.
		/// </summary>
		public decimal? PK_ACI_LU_Location
		{
			get { return _PK_ACI_LU_Location; }
			set { _PK_ACI_LU_Location = value; }
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
		/// Initializes a new instance of the clsAci_Lu_Location class with default value.
		/// </summary>
		public clsAci_Lu_Location() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAci_Lu_Location class based on Primary Key.
		/// </summary>
		public clsAci_Lu_Location(decimal PK_ACI_LU_Location) 
		{
			DataTable dtAci_Lu_Location = SelectByPK(PK_ACI_LU_Location).Tables[0];

			if (dtAci_Lu_Location.Rows.Count == 1)
			{
				 SetValue(dtAci_Lu_Location.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAci_Lu_Location class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAci_Lu_Location) 
		{
				if (drAci_Lu_Location["PK_ACI_LU_Location"] == DBNull.Value)
					this._PK_ACI_LU_Location = null;
				else
					this._PK_ACI_LU_Location = (decimal?)drAci_Lu_Location["PK_ACI_LU_Location"];

				if (drAci_Lu_Location["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drAci_Lu_Location["Fld_Code"];

				if (drAci_Lu_Location["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drAci_Lu_Location["Fld_Desc"];

				if (drAci_Lu_Location["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drAci_Lu_Location["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Aci_Lu_Location table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Aci_Lu_LocationInsert");

			
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
		/// Selects a single record from the Aci_Lu_Location table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal PK_ACI_LU_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Aci_Lu_LocationSelectByPK");

			db.AddInParameter(dbCommand, "PK_ACI_LU_Location", DbType.Decimal, PK_ACI_LU_Location);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Aci_Lu_Location table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Aci_Lu_LocationSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Aci_Lu_Location table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Aci_Lu_LocationUpdate");

			
			db.AddInParameter(dbCommand, "PK_ACI_LU_Location", DbType.Decimal, this._PK_ACI_LU_Location);
			
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
		/// Deletes a record from the Aci_Lu_Location table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal PK_ACI_LU_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Aci_Lu_LocationDeleteByPK");

			db.AddInParameter(dbCommand, "PK_ACI_LU_Location", DbType.Decimal, PK_ACI_LU_Location);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
