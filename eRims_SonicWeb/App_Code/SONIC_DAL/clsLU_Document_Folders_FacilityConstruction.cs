//using System;
//using System.Collections.Generic;
//using System.Web;

///// <summary>
///// Summary description for clsLU_Document_Folders_FacilityConstruction
///// </summary>
//public class clsLU_Document_Folders_FacilityConstruction
//{
//    public clsLU_Document_Folders_FacilityConstruction()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
//}


using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_FC_Document_Folder
	/// </summary>
	public sealed class clsLU_Document_Folders_FacilityConstruction
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_FC_Document_Folder;
		private string _Folder_Name;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_LU_FC_Document_Folder value.
		/// </summary>
		public decimal? PK_LU_FC_Document_Folder
		{
			get { return _PK_LU_FC_Document_Folder; }
			set { _PK_LU_FC_Document_Folder = value; }
		}

		/// <summary>
		/// Gets or sets the Folder_Name value.
		/// </summary>
		public string Folder_Name
		{
			get { return _Folder_Name; }
			set { _Folder_Name = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_FC_Document_Folder class with default value.
		/// </summary>
		public clsLU_Document_Folders_FacilityConstruction() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_FC_Document_Folder class based on Primary Key.
		/// </summary>
        public clsLU_Document_Folders_FacilityConstruction(decimal pK_LU_FC_Document_Folder) 
		{
			DataTable dtLU_FC_Document_Folder = Select(pK_LU_FC_Document_Folder).Tables[0];

			if (dtLU_FC_Document_Folder.Rows.Count == 1)
			{
				 SetValue(dtLU_FC_Document_Folder.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_FC_Document_Folder class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_FC_Document_Folder) 
		{
				if (drLU_FC_Document_Folder["PK_LU_FC_Document_Folder"] == DBNull.Value)
					this._PK_LU_FC_Document_Folder = null;
				else
					this._PK_LU_FC_Document_Folder = (decimal?)drLU_FC_Document_Folder["PK_LU_FC_Document_Folder"];

				if (drLU_FC_Document_Folder["Folder_Name"] == DBNull.Value)
					this._Folder_Name = null;
				else
					this._Folder_Name = (string)drLU_FC_Document_Folder["Folder_Name"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_FC_Document_Folder table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderInsert");

			
			if (string.IsNullOrEmpty(this._Folder_Name))
				db.AddInParameter(dbCommand, "Folder_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_FC_Document_Folder table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_LU_FC_Document_Folder)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderSelect");

			db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder", DbType.Decimal, pK_LU_FC_Document_Folder);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_FC_Document_Folder table.
		/// </summary>
		/// <returns>DataSet</returns>
        public static DataSet SelectAll(string strOrderBy, string strOrder, int intPageNo, int intPageSize)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderSelectAll");
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_FC_Document_Folder table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderUpdate");

			
			db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder", DbType.Decimal, this._PK_LU_FC_Document_Folder);
			
			if (string.IsNullOrEmpty(this._Folder_Name))
				db.AddInParameter(dbCommand, "Folder_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Folder_Name", DbType.String, this._Folder_Name);

			decimal ret = db.ExecuteNonQuery(dbCommand);

            return ret;
		}

		/// <summary>
		/// Deletes a record from the LU_FC_Document_Folder table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_LU_FC_Document_Folder)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderDelete");

			db.AddInParameter(dbCommand, "PK_LU_FC_Document_Folder", DbType.Decimal, pK_LU_FC_Document_Folder);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the LU_FC_Document_Folder table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllRecords()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderSelectAllRecords");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_FC_Document_Folder table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllRecords_BySecurityID(decimal SecurityID, string RightType_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_FC_Document_FolderSelectAllRecords_BySecurityID");
            db.AddInParameter(dbCommand, "SecurityID", DbType.Decimal, SecurityID);
            db.AddInParameter(dbCommand, "RightType_ID", DbType.String, RightType_ID);


            return db.ExecuteDataSet(dbCommand);
        }
	}
}
