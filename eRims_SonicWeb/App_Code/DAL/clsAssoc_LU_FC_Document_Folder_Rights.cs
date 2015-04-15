using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Assoc_LU_FC_Document_Folder_Rights table.
	/// </summary>
	public sealed class clsAssoc_LU_FC_Document_Folder_Rights
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Assoc_LU_FC_Document_Folder_Rights;
		private decimal? _FK_User_ID;
		private decimal? _FK_LU_FC_Document_Folder_Rights;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Assoc_LU_FC_Document_Folder_Rights value.
		/// </summary>
		public decimal? PK_Assoc_LU_FC_Document_Folder_Rights
		{
			get { return _PK_Assoc_LU_FC_Document_Folder_Rights; }
			set { _PK_Assoc_LU_FC_Document_Folder_Rights = value; }
		}

		/// <summary>
		/// Gets or sets the FK_User_ID value.
		/// </summary>
		public decimal? FK_User_ID
		{
			get { return _FK_User_ID; }
			set { _FK_User_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_FC_Document_Folder_Rights value.
		/// </summary>
		public decimal? FK_LU_FC_Document_Folder_Rights
		{
			get { return _FK_LU_FC_Document_Folder_Rights; }
			set { _FK_LU_FC_Document_Folder_Rights = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_LU_FC_Document_Folder_Rights class with default value.
		/// </summary>
		public clsAssoc_LU_FC_Document_Folder_Rights() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsAssoc_LU_FC_Document_Folder_Rights class based on Primary Key.
		/// </summary>
		public clsAssoc_LU_FC_Document_Folder_Rights(decimal pK_Assoc_LU_FC_Document_Folder_Rights) 
		{
			DataTable dtAssoc_LU_FC_Document_Folder_Rights = SelectByPK(pK_Assoc_LU_FC_Document_Folder_Rights).Tables[0];

			if (dtAssoc_LU_FC_Document_Folder_Rights.Rows.Count == 1)
			{
				 SetValue(dtAssoc_LU_FC_Document_Folder_Rights.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the clsAssoc_LU_FC_Document_Folder_Rights class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drAssoc_LU_FC_Document_Folder_Rights) 
		{
				if (drAssoc_LU_FC_Document_Folder_Rights["PK_Assoc_LU_FC_Document_Folder_Rights"] == DBNull.Value)
					this._PK_Assoc_LU_FC_Document_Folder_Rights = null;
				else
					this._PK_Assoc_LU_FC_Document_Folder_Rights = (decimal?)drAssoc_LU_FC_Document_Folder_Rights["PK_Assoc_LU_FC_Document_Folder_Rights"];

				if (drAssoc_LU_FC_Document_Folder_Rights["FK_User_ID"] == DBNull.Value)
					this._FK_User_ID = null;
				else
					this._FK_User_ID = (decimal?)drAssoc_LU_FC_Document_Folder_Rights["FK_User_ID"];

				if (drAssoc_LU_FC_Document_Folder_Rights["FK_LU_FC_Document_Folder_Rights"] == DBNull.Value)
					this._FK_LU_FC_Document_Folder_Rights = null;
				else
					this._FK_LU_FC_Document_Folder_Rights = (decimal?)drAssoc_LU_FC_Document_Folder_Rights["FK_LU_FC_Document_Folder_Rights"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Assoc_LU_FC_Document_Folder_Rights table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsInsert");

			
			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, this._FK_User_ID);
			
			db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder_Rights", DbType.Decimal, this._FK_LU_FC_Document_Folder_Rights);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Assoc_LU_FC_Document_Folder_Rights table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Assoc_LU_FC_Document_Folder_Rights)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_LU_FC_Document_Folder_Rights", DbType.Decimal, pK_Assoc_LU_FC_Document_Folder_Rights);

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Assoc_LU_FC_Document_Folder_Rights table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByUserId(decimal fK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsSelectByUserId");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, fK_User_ID);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Assoc_LU_FC_Document_Folder_Rights table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Assoc_LU_FC_Document_Folder_Rights table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Assoc_LU_FC_Document_Folder_Rights", DbType.Decimal, this._PK_Assoc_LU_FC_Document_Folder_Rights);
			
			db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, this._FK_User_ID);
			
			db.AddInParameter(dbCommand, "FK_LU_FC_Document_Folder_Rights", DbType.Decimal, this._FK_LU_FC_Document_Folder_Rights);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Assoc_LU_FC_Document_Folder_Rights table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Assoc_LU_FC_Document_Folder_Rights)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Assoc_LU_FC_Document_Folder_Rights", DbType.Decimal, pK_Assoc_LU_FC_Document_Folder_Rights);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Deletes a record from the Assoc_LU_FC_Document_Folder_Rights table by a composite Foreign key as User Id.
        /// </summary>
        public static void DeleteByUserId(decimal fK_User_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Assoc_LU_FC_Document_Folder_RightsDeleteByUserId");

            db.AddInParameter(dbCommand, "FK_User_ID", DbType.Decimal, fK_User_ID);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}
