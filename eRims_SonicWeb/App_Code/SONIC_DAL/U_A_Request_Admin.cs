using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for U_A_Request_Admin table.
	/// </summary>
	public sealed class U_A_Request_Admin
	{

		#region Private variables used to hold the property values

		private decimal? _PK_U_A_Request_Admin;
		private string _Admin_EMail;
		private string _Name;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_U_A_Request_Admin value.
		/// </summary>
		public decimal? PK_U_A_Request_Admin
		{
			get { return _PK_U_A_Request_Admin; }
			set { _PK_U_A_Request_Admin = value; }
		}

		/// <summary>
		/// Gets or sets the Admin_EMail value.
		/// </summary>
		public string Admin_EMail
		{
			get { return _Admin_EMail; }
			set { _Admin_EMail = value; }
		}

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request_Admin class with default value.
		/// </summary>
		public U_A_Request_Admin() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the U_A_Request_Admin class based on Primary Key.
		/// </summary>
		public U_A_Request_Admin(decimal pK_U_A_Request_Admin) 
		{
			DataTable dtU_A_Request_Admin = SelectByPK(pK_U_A_Request_Admin).Tables[0];

			if (dtU_A_Request_Admin.Rows.Count == 1)
			{
				 SetValue(dtU_A_Request_Admin.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the U_A_Request_Admin class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drU_A_Request_Admin) 
		{
				if (drU_A_Request_Admin["PK_U_A_Request_Admin"] == DBNull.Value)
					this._PK_U_A_Request_Admin = null;
				else
					this._PK_U_A_Request_Admin = (decimal?)drU_A_Request_Admin["PK_U_A_Request_Admin"];

				if (drU_A_Request_Admin["Admin_EMail"] == DBNull.Value)
					this._Admin_EMail = null;
				else
					this._Admin_EMail = (string)drU_A_Request_Admin["Admin_EMail"];

				if (drU_A_Request_Admin["Name"] == DBNull.Value)
					this._Name = null;
				else
					this._Name = (string)drU_A_Request_Admin["Name"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the U_A_Request_Admin table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_AdminInsert");

			
			if (string.IsNullOrEmpty(this._Admin_EMail))
				db.AddInParameter(dbCommand, "Admin_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Admin_EMail", DbType.String, this._Admin_EMail);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the U_A_Request_Admin table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_U_A_Request_Admin)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_AdminSelectByPK");

			db.AddInParameter(dbCommand, "PK_U_A_Request_Admin", DbType.Decimal, pK_U_A_Request_Admin);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the U_A_Request_Admin table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_AdminSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the U_A_Request_Admin table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_AdminUpdate");

			
			db.AddInParameter(dbCommand, "PK_U_A_Request_Admin", DbType.Decimal, this._PK_U_A_Request_Admin);
			
			if (string.IsNullOrEmpty(this._Admin_EMail))
				db.AddInParameter(dbCommand, "Admin_EMail", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Admin_EMail", DbType.String, this._Admin_EMail);
			
			if (string.IsNullOrEmpty(this._Name))
				db.AddInParameter(dbCommand, "Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Name", DbType.String, this._Name);

            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Deletes a record from the U_A_Request_Admin table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_U_A_Request_Admin)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("U_A_Request_AdminDeleteByPK");

			db.AddInParameter(dbCommand, "PK_U_A_Request_Admin", DbType.Decimal, pK_U_A_Request_Admin);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
