using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Lu_Lease_Instance table.
	/// </summary>
	public sealed class LU_Lease_Instance
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Lease_Instance_ID;
		private string _Lease_Instance_Item;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_Lease_Instance_ID value.
		/// </summary>
		public decimal? PK_LU_Lease_Instance_ID
		{
			get { return _PK_LU_Lease_Instance_ID; }
			set { _PK_LU_Lease_Instance_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Lease_Instance_Item value.
		/// </summary>
		public string Lease_Instance_Item
		{
			get { return _Lease_Instance_Item; }
			set { _Lease_Instance_Item = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Lease_Instance class with default value.
		/// </summary>
		public LU_Lease_Instance() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Lease_Instance class based on Primary Key.
		/// </summary>
		public LU_Lease_Instance(decimal pk_Lease_Instance_Id) 
		{
			DataTable dtLu_Lease_Instance = SelectByPK(pk_Lease_Instance_Id).Tables[0];

			if (dtLu_Lease_Instance.Rows.Count == 1)
			{
				 SetValue(dtLu_Lease_Instance.Rows[0]);

			}

		}

		/// <summary>
		/// Initializes a new instance of the LU_Lease_Instance class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLu_Lease_Instance) 
		{
            if (drLu_Lease_Instance["PK_LU_Lease_Instance_ID"] == DBNull.Value)
					this._PK_LU_Lease_Instance_ID = null;
				else
					this._PK_LU_Lease_Instance_ID = (decimal?)drLu_Lease_Instance["PK_LU_Lease_Instance_ID"];

				if (drLu_Lease_Instance["Lease_Instance_Item"] == DBNull.Value)
					this._Lease_Instance_Item = null;
				else
					this._Lease_Instance_Item = (string)drLu_Lease_Instance["Lease_Instance_Item"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the Lu_Lease_Instance table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_InstanceInsert");
			
			if (string.IsNullOrEmpty(this._Lease_Instance_Item))
				db.AddInParameter(dbCommand, "Lease_Instance_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Lease_Instance_Item", DbType.String, this._Lease_Instance_Item);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Lu_Lease_Instance table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pk_Lease_Instance_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_InstanceSelectByPK");

			db.AddInParameter(dbCommand, "PK_LU_Lease_Instance_ID", DbType.Decimal, pk_Lease_Instance_Id);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Lu_Lease_Instance table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_InstanceSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Lu_Lease_Instance table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_InstanceUpdate");

			db.AddInParameter(dbCommand, "PK_LU_Lease_Instance_ID", DbType.Decimal, this._PK_LU_Lease_Instance_ID);
			
			if (string.IsNullOrEmpty(this._Lease_Instance_Item))
				db.AddInParameter(dbCommand, "Lease_Instance_Item", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Lease_Instance_Item", DbType.String, this._Lease_Instance_Item);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Lu_Lease_Instance table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pk_Lease_Instance_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Lease_InstanceDeleteByPK");

			db.AddInParameter(dbCommand, "PK_LU_Lease_Instance_ID", DbType.Decimal, pk_Lease_Instance_Id);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}
