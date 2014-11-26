using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Lu_Incident_Type table.
	/// </summary>
	public sealed class Lu_Incident_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Lu_Incident_Type;
		private string _Fld_Code;
		private string _Fld_Desc;
		private bool? _Active;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Lu_Incident_Type value.
		/// </summary>
		public decimal? PK_Lu_Incident_Type
		{
			get { return _PK_Lu_Incident_Type; }
			set { _PK_Lu_Incident_Type = value; }
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
		public bool? Active
		{
			get { return _Active; }
			set { _Active = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsLu_Incident_Type class with default value.
		/// </summary>
		public Lu_Incident_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsLu_Incident_Type class based on Primary Key.
		/// </summary>
		public Lu_Incident_Type(decimal pK_Lu_Incident_Type) 
		{
			DataTable dtLu_Incident_Type = SelectByPK(pK_Lu_Incident_Type).Tables[0];

			if (dtLu_Incident_Type.Rows.Count == 1)
			{
				 SetValue(dtLu_Incident_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsLu_Incident_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLu_Incident_Type) 
		{
				if (drLu_Incident_Type["PK_Lu_Incident_Type"] == DBNull.Value)
					this._PK_Lu_Incident_Type = null;
				else
					this._PK_Lu_Incident_Type = (decimal?)drLu_Incident_Type["PK_Lu_Incident_Type"];

				if (drLu_Incident_Type["Fld_Code"] == DBNull.Value)
					this._Fld_Code = null;
				else
					this._Fld_Code = (string)drLu_Incident_Type["Fld_Code"];

				if (drLu_Incident_Type["Fld_Desc"] == DBNull.Value)
					this._Fld_Desc = null;
				else
					this._Fld_Desc = (string)drLu_Incident_Type["Fld_Desc"];

				if (drLu_Incident_Type["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (bool?)drLu_Incident_Type["Active"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Lu_Incident_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Lu_Incident_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Lu_Incident_Type table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Lu_Incident_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Lu_Incident_TypeSelectByPK");

			db.AddInParameter(dbCommand, "PK_Lu_Incident_Type", DbType.Decimal, pK_Lu_Incident_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Lu_Incident_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Lu_Incident_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Lu_Incident_Type table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Lu_Incident_TypeUpdate");

			
			db.AddInParameter(dbCommand, "PK_Lu_Incident_Type", DbType.Decimal, this._PK_Lu_Incident_Type);
			
			if (string.IsNullOrEmpty(this._Fld_Code))
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Code", DbType.String, this._Fld_Code);
			
			if (string.IsNullOrEmpty(this._Fld_Desc))
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, this._Fld_Desc);
			
			db.AddInParameter(dbCommand, "Active", DbType.Boolean, this._Active);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Lu_Incident_Type table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Lu_Incident_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Lu_Incident_TypeDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Lu_Incident_Type", DbType.Decimal, pK_Lu_Incident_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
