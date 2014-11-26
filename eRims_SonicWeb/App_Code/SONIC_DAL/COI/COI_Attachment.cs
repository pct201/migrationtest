using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Attachment table.
	/// </summary>
	public sealed class COI_Attachment
    {
        #region Fields


        private decimal _PK_Attachment_Id;
        private string _Attachment_Table;
        private decimal _Foreign_Key;
        private decimal _FK_Attachment_Type;
        private string _Attachment_Description;
        private string _Attachment_Name;
        private string _Updated_By;
        private DateTime _Update_Date;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Attachment_Id value.
        /// </summary>
        public decimal PK_Attachment_Id
        {
            get { return _PK_Attachment_Id; }
            set { _PK_Attachment_Id = value; }
        }


        /// <summary> 
        /// Gets or sets the Attachment_Table value.
        /// </summary>
        public string Attachment_Table
        {
            get { return _Attachment_Table; }
            set { _Attachment_Table = value; }
        }


        /// <summary> 
        /// Gets or sets the Foreign_Key value.
        /// </summary>
        public decimal Foreign_Key
        {
            get { return _Foreign_Key; }
            set { _Foreign_Key = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Attachment_Type value.
        /// </summary>
        public decimal FK_Attachment_Type
        {
            get { return _FK_Attachment_Type; }
            set { _FK_Attachment_Type = value; }
        }


        /// <summary> 
        /// Gets or sets the Attachment_Description value.
        /// </summary>
        public string Attachment_Description
        {
            get { return _Attachment_Description; }
            set { _Attachment_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Attachment_Name value.
        /// </summary>
        public string Attachment_Name
        {
            get { return _Attachment_Name; }
            set { _Attachment_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }



        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Attachment class. with the default value.

        /// </summary>
        public COI_Attachment()
        {

            this._PK_Attachment_Id = -1;
            this._Attachment_Table = "";
            this._Foreign_Key = -1;
            this._FK_Attachment_Type = -1;
            this._Attachment_Description = "";
            this._Attachment_Name = "";
            this._Updated_By = "";
            this._Update_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

        }



        /// <summary> 

        /// Initializes a new instance of the Attachment class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Attachment(decimal PK)
        {
            DataTable dtAttachment = Select(PK).Tables[0];

            if (dtAttachment.Rows.Count > 0)
            {

                DataRow drAttachment = dtAttachment.Rows[0];

                this._PK_Attachment_Id = drAttachment["PK_Attachment_Id"] != DBNull.Value ? Convert.ToDecimal(drAttachment["PK_Attachment_Id"]) : 0;
                this._Attachment_Table = Convert.ToString(drAttachment["Attachment_Table"]);
                this._Foreign_Key = drAttachment["Foreign_Key"] != DBNull.Value ? Convert.ToDecimal(drAttachment["Foreign_Key"]) : 0;
                this._FK_Attachment_Type = drAttachment["FK_Attachment_Type"] != DBNull.Value ? Convert.ToDecimal(drAttachment["FK_Attachment_Type"]) : 0;
                this._Attachment_Description = Convert.ToString(drAttachment["Attachment_Description"]);
                this._Attachment_Name = Convert.ToString(drAttachment["Attachment_Name"]);
                this._Updated_By = Convert.ToString(drAttachment["Updated_By"]);
                this._Update_Date = drAttachment["Update_Date"] != DBNull.Value ? Convert.ToDateTime(drAttachment["Update_Date"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;;

            }

            else
            {

                new COI_Attachment();
            }

        }



        #endregion

        #region "Methods"
        /// <summary>
		/// Inserts a record into the Attachment table.
		/// <summary>
		/// <param name="attachment_Table"></param>
		/// <param name="foreign_Key"></param>
		/// <param name="fK_Attachment_Type"></param>
		/// <param name="attachment_Description"></param>
		/// <param name="attachment_Name"></param>
		/// <param name="updated_By"></param>
		/// <param name="update_Date"></param>
		/// <returns></returns>
		public static int Insert(string attachment_Table, decimal foreign_Key, decimal fK_Attachment_Type, string attachment_Description, string attachment_Name, string updated_By, DateTime update_Date)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_AttachmentInsert");

			db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, attachment_Table);
			db.AddInParameter(dbCommand, "Foreign_Key", DbType.Decimal, foreign_Key);
			db.AddInParameter(dbCommand, "FK_Attachment_Type", DbType.Decimal, fK_Attachment_Type);
			db.AddInParameter(dbCommand, "Attachment_Description", DbType.String, attachment_Description);
			db.AddInParameter(dbCommand, "Attachment_Name", DbType.String, attachment_Name);
			db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

        /// <summary>
        /// Selects a single record from the Attachment table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_Attachment_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AttachmentSelect");

            db.AddInParameter(dbCommand, "PK_Attachment_Id", DbType.Decimal, pK_Attachment_Id);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects all records from the Attachment table.
		/// <summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("COI_AttachmentSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a record depending on table name and related foreign key for the table
        /// </summary>
        /// <param name="Attachment_Table">Table name for which to store the record</param>
        /// <param name="Foreign_Key">Primary key value of the table</param>
        /// <returns></returns>
        public static DataSet SelectByTableName(string Attachment_Table, int Foreign_Key)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AttachmentSelectByTableName");

            db.AddInParameter(dbCommand, "Attachment_Table", DbType.String, Attachment_Table);
            db.AddInParameter(dbCommand, "Foreign_Key", DbType.Int32, Foreign_Key);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes records using comma seperated primary key values
        /// </summary>
        /// <param name="strIDs"></param>
        public static void DeleteByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_AttachmentDeleteByIDs");
            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);            

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        public void Insert()
        {
            Insert(_Attachment_Table, _Foreign_Key, _FK_Attachment_Type, _Attachment_Description, _Attachment_Name, _Updated_By, _Update_Date);
        }
        #endregion
    }
}
