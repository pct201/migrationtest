using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Building_Attachments table.
	/// </summary>
	public sealed class Building_Attachments
    {
        #region Fields


        private int _PK_Building_Attachments_ID;
        private int _FK_Building_ID;
        private string _Type;
        private string _Filename;
        private string _path;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Building_Attachments_ID value.
        /// </summary>
        public int PK_Building_Attachments_ID
        {
            get { return _PK_Building_Attachments_ID; }
            set { _PK_Building_Attachments_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public int FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
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
        /// Gets or sets the Filename value.
        /// </summary>
        public string Filename
        {
            get { return _Filename; }
            set { _Filename = value; }
        }


        /// <summary> 
        /// Gets or sets the path value.
        /// </summary>
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Building_Attachments class. with the default value.

        /// </summary>
        public Building_Attachments()
        {

            this._PK_Building_Attachments_ID = -1;
            this._FK_Building_ID = -1;
            this._Type = "";
            this._Filename = "";
            this._path = "";

        }



        /// <summary> 

        /// Initializes a new instance of the Building_Attachments class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Building_Attachments(int PK)
        {

            DataTable dtBuilding_Attachments = SelectByPK(PK).Tables[0];

            if (dtBuilding_Attachments.Rows.Count > 0)
            {

                DataRow drBuilding_Attachments = dtBuilding_Attachments.Rows[0];

                this._PK_Building_Attachments_ID = drBuilding_Attachments["PK_Building_Attachments_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Attachments["PK_Building_Attachments_ID"]) : 0;
                this._FK_Building_ID = drBuilding_Attachments["FK_Building_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Attachments["FK_Building_ID"]) : 0;
                this._Type = Convert.ToString(drBuilding_Attachments["Type"]);
                this._Filename = Convert.ToString(drBuilding_Attachments["Filename"]);
                this._path = Convert.ToString(drBuilding_Attachments["path"]);

            }

            else
            {

                this._PK_Building_Attachments_ID = -1;
                this._FK_Building_ID = -1;
                this._Type = "";
                this._Filename = "";
                this._path = "";

            }

        }



        #endregion

        #region Methods
        /// <summary>
		/// Inserts a record into the Building_Attachments table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsInsert");

			db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
			db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
			db.AddInParameter(dbCommand, "path", DbType.String, this._path);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Building_Attachments table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectByPK(int pK_Building_Attachments_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsSelectByPK");

			db.AddInParameter(dbCommand, "PK_Building_Attachments_ID", DbType.Int32, pK_Building_Attachments_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Building_Attachments table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Building_Attachments table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsUpdate");

			db.AddInParameter(dbCommand, "PK_Building_Attachments_ID", DbType.Int32, this._PK_Building_Attachments_ID);
			db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
			db.AddInParameter(dbCommand, "Type", DbType.String, this._Type);
			db.AddInParameter(dbCommand, "Filename", DbType.String, this._Filename);
			db.AddInParameter(dbCommand, "path", DbType.String, this._path);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Building_Attachments table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(int pK_Building_Attachments_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Building_Attachments_ID", DbType.Int32, pK_Building_Attachments_ID);

			db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_AttachmentsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}
