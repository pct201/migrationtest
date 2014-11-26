using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for LU_Executive_Risk_Defense_Attorney table.
	/// </summary>
	public sealed class clsLU_Executive_Risk_Defense_Attorney
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Executive_Risk_Defense_Attorney;
		private string _Firm;
		private string _Name;
		private string _Address_1;
		private string _Address_2;
		private string _City;
		private decimal? _FK_State;
		private string _Zip_Code;
		private string _Telephone;
		private string _E_Mail;
		private string _Panel;
		private string _Notes;
		private string _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Executive_Risk_Defense_Attorney value.
		/// </summary>
		public decimal? PK_LU_Executive_Risk_Defense_Attorney
		{
			get { return _PK_LU_Executive_Risk_Defense_Attorney; }
			set { _PK_LU_Executive_Risk_Defense_Attorney = value; }
		}

		/// <summary>
		/// Gets or sets the Firm value.
		/// </summary>
		public string Firm
		{
			get { return _Firm; }
			set { _Firm = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Gets or sets the Address_1 value.
		/// </summary>
		public string Address_1
		{
			get { return _Address_1; }
			set { _Address_1 = value; }
		}

		/// <summary>
		/// Gets or sets the Address_2 value.
		/// </summary>
		public string Address_2
		{
			get { return _Address_2; }
			set { _Address_2 = value; }
		}

		/// <summary>
		/// Gets or sets the City value.
		/// </summary>
		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		/// <summary>
		/// Gets or sets the FK_State value.
		/// </summary>
		public decimal? FK_State
		{
			get { return _FK_State; }
			set { _FK_State = value; }
		}

		/// <summary>
		/// Gets or sets the Zip_Code value.
		/// </summary>
		public string Zip_Code
		{
			get { return _Zip_Code; }
			set { _Zip_Code = value; }
		}

		/// <summary>
		/// Gets or sets the Telephone value.
		/// </summary>
		public string Telephone
		{
			get { return _Telephone; }
			set { _Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the E_Mail value.
		/// </summary>
		public string E_Mail
		{
			get { return _E_Mail; }
			set { _E_Mail = value; }
		}

		/// <summary>
		/// Gets or sets the Panel value.
		/// </summary>
		public string Panel
		{
			get { return _Panel; }
			set { _Panel = value; }
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
		/// Initializes a new instance of the clsLU_Executive_Risk_Defense_Attorney class with default value.
		/// </summary>
		public clsLU_Executive_Risk_Defense_Attorney() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLU_Executive_Risk_Defense_Attorney class based on Primary Key.
		/// </summary>
		public clsLU_Executive_Risk_Defense_Attorney(decimal pK_LU_Executive_Risk_Defense_Attorney) 
		{
			DataTable dtLU_Executive_Risk_Defense_Attorney = SelectByPK(pK_LU_Executive_Risk_Defense_Attorney).Tables[0];

			if (dtLU_Executive_Risk_Defense_Attorney.Rows.Count == 1)
			{
				 SetValue(dtLU_Executive_Risk_Defense_Attorney.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLU_Executive_Risk_Defense_Attorney class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Executive_Risk_Defense_Attorney) 
		{
				if (drLU_Executive_Risk_Defense_Attorney["PK_LU_Executive_Risk_Defense_Attorney"] == DBNull.Value)
					this._PK_LU_Executive_Risk_Defense_Attorney = null;
				else
					this._PK_LU_Executive_Risk_Defense_Attorney = (decimal?)drLU_Executive_Risk_Defense_Attorney["PK_LU_Executive_Risk_Defense_Attorney"];

				if (drLU_Executive_Risk_Defense_Attorney["Firm"] == DBNull.Value)
					this._Firm = null;
				else
					this._Firm = (string)drLU_Executive_Risk_Defense_Attorney["Firm"];

				if (drLU_Executive_Risk_Defense_Attorney["Name"] == DBNull.Value)
					this._Name = null;
				else
					this._Name = (string)drLU_Executive_Risk_Defense_Attorney["Name"];

				if (drLU_Executive_Risk_Defense_Attorney["Address_1"] == DBNull.Value)
					this._Address_1 = null;
				else
					this._Address_1 = (string)drLU_Executive_Risk_Defense_Attorney["Address_1"];

				if (drLU_Executive_Risk_Defense_Attorney["Address_2"] == DBNull.Value)
					this._Address_2 = null;
				else
					this._Address_2 = (string)drLU_Executive_Risk_Defense_Attorney["Address_2"];

				if (drLU_Executive_Risk_Defense_Attorney["City"] == DBNull.Value)
					this._City = null;
				else
					this._City = (string)drLU_Executive_Risk_Defense_Attorney["City"];

				if (drLU_Executive_Risk_Defense_Attorney["FK_State"] == DBNull.Value)
					this._FK_State = null;
				else
					this._FK_State = (decimal?)drLU_Executive_Risk_Defense_Attorney["FK_State"];

				if (drLU_Executive_Risk_Defense_Attorney["Zip_Code"] == DBNull.Value)
					this._Zip_Code = null;
				else
					this._Zip_Code = (string)drLU_Executive_Risk_Defense_Attorney["Zip_Code"];

				if (drLU_Executive_Risk_Defense_Attorney["Telephone"] == DBNull.Value)
					this._Telephone = null;
				else
					this._Telephone = (string)drLU_Executive_Risk_Defense_Attorney["Telephone"];

				if (drLU_Executive_Risk_Defense_Attorney["E_Mail"] == DBNull.Value)
					this._E_Mail = null;
				else
					this._E_Mail = (string)drLU_Executive_Risk_Defense_Attorney["E_Mail"];

				if (drLU_Executive_Risk_Defense_Attorney["Panel"] == DBNull.Value)
					this._Panel = null;
				else
					this._Panel = (string)drLU_Executive_Risk_Defense_Attorney["Panel"];

				if (drLU_Executive_Risk_Defense_Attorney["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drLU_Executive_Risk_Defense_Attorney["Notes"];

				if (drLU_Executive_Risk_Defense_Attorney["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drLU_Executive_Risk_Defense_Attorney["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Executive_Risk_Defense_Attorney table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Executive_Risk_Defense_AttorneyInsert");

			
			if (string.IsNullOrEmpty(this._Firm))
				db.AddInParameter(dbCommand, "Firm", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Firm", DbType.String, this._Firm);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			if (string.IsNullOrEmpty(this._E_Mail))
				db.AddInParameter(dbCommand, "E_Mail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "E_Mail", DbType.String, this._E_Mail);
			
			if (string.IsNullOrEmpty(this._Panel))
				db.AddInParameter(dbCommand, "Panel", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Panel", DbType.String, this._Panel);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Executive_Risk_Defense_Attorney table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_LU_Executive_Risk_Defense_Attorney)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Executive_Risk_Defense_AttorneySelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Executive_Risk_Defense_Attorney", DbType.Decimal, pK_LU_Executive_Risk_Defense_Attorney);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Executive_Risk_Defense_Attorney table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Executive_Risk_Defense_AttorneySelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Executive_Risk_Defense_Attorney table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Executive_Risk_Defense_AttorneyUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_Executive_Risk_Defense_Attorney", DbType.Decimal, this._PK_LU_Executive_Risk_Defense_Attorney);
			
			if (string.IsNullOrEmpty(this._Firm))
				db.AddInParameter(dbCommand, "Firm", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Firm", DbType.String, this._Firm);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);
			
			if (string.IsNullOrEmpty(this._Address_1))
				db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);
			
			if (string.IsNullOrEmpty(this._Address_2))
				db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);
			
			if (string.IsNullOrEmpty(this._City))
				db.AddInParameter(dbCommand, "City", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "City", DbType.String, this._City);
			
			db.AddInParameter(dbCommand, "FK_State", DbType.Decimal, this._FK_State);
			
			if (string.IsNullOrEmpty(this._Zip_Code))
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Zip_Code", DbType.String, this._Zip_Code);
			
			if (string.IsNullOrEmpty(this._Telephone))
				db.AddInParameter(dbCommand, "Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Telephone", DbType.String, this._Telephone);
			
			if (string.IsNullOrEmpty(this._E_Mail))
				db.AddInParameter(dbCommand, "E_Mail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "E_Mail", DbType.String, this._E_Mail);
			
			if (string.IsNullOrEmpty(this._Panel))
				db.AddInParameter(dbCommand, "Panel", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Panel", DbType.String, this._Panel);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Executive_Risk_Defense_Attorney table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_LU_Executive_Risk_Defense_Attorney)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Executive_Risk_Defense_AttorneyDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Executive_Risk_Defense_Attorney", DbType.Decimal, pK_LU_Executive_Risk_Defense_Attorney);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
