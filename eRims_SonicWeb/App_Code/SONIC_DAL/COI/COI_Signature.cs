using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for COI_Signature table.
    /// </summary>
    public sealed class COI_Signature
    {
        #region Fields


        private decimal _PK_COI_Signature;
        private string _Fld_Desc;
        private string _Closing;
        private string _Phone;
        private string _Facsimile;
        private string _Title_Departement;
        private string _EMail;
        private string _ImageName;

        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_COI_Signature value.
        /// </summary>
        public decimal PK_COI_Signature
        {
            get { return _PK_COI_Signature; }
            set { _PK_COI_Signature = value; }
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
        /// Gets or sets the Closing value.
        /// </summary>
        public string Closing
        {
            get { return _Closing; }
            set { _Closing = value; }
        }

        /// <summary> 
        /// Gets or sets the Phone value.
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary> 
        /// Gets or sets the Facsimile value.
        /// </summary>
        public string Facsimile
        {
            get { return _Facsimile; }
            set { _Facsimile = value; }
        }

        /// <summary> 
        /// Gets or sets the Title_Department value.
        /// </summary>
        public string Title_Department
        {
            get { return _Title_Departement ; }
            set { _Title_Departement  = value; }
        }

        /// <summary> 
        /// Gets or sets the EMail value.
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        public string ImageName
        {
            get { return _ImageName; }
            set { _ImageName = value; }
        }

        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the COI_Signature class. with the default value.

        /// </summary>
        public COI_Signature()
        {

            this._PK_COI_Signature = -1;
            this._Fld_Desc = "";            
            this._Closing = "";
            this._Phone = "";
            this._Facsimile = "";
            this._Title_Departement = "";
            this._EMail = "";
            this._ImageName = "";
        }



        /// <summary> 

        /// Initializes a new instance of the COI_Signature class for passed PrimaryKey with the values set from Database.

        /// </summary>
        public COI_Signature(decimal PK)
        {
            DataTable dtCOI_Signature = Select(PK).Tables[0];

            if (dtCOI_Signature.Rows.Count > 0)
            {

                DataRow drCOI_Signature = dtCOI_Signature.Rows[0];

                this._PK_COI_Signature = drCOI_Signature["PK_COI_Signature"] != DBNull.Value ? Convert.ToDecimal(drCOI_Signature["PK_COI_Signature"]) : 0;
                this._Fld_Desc = Convert.ToString(drCOI_Signature["Fld_Desc"]);
                this._Closing = Convert.ToString(drCOI_Signature["Closing"]); 
                this._Phone = Convert.ToString(drCOI_Signature["Phone"]); 
                this._Facsimile = Convert.ToString(drCOI_Signature["Facsimile"]);
                this._Title_Departement = Convert.ToString(drCOI_Signature["Title_Department"]); 
                this._EMail = Convert.ToString(drCOI_Signature["EMail"]);
                this._ImageName = Convert.ToString(drCOI_Signature["ImageName"]);

            }

            else
            {
                this._PK_COI_Signature = -1;
                this._Fld_Desc = "";                
                this._Closing = "";
                this._Phone = "";
                this._Facsimile = "";
                this._Title_Departement = "";
                this._EMail = "";
                this._ImageName = "";
            }

        }



        #endregion

        #region "Methods"

        public static int Insert(string _fld_Desc, string closing, string phone, string facsimile, string title_Departement, string eMail,string imageName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureInsert");
                       
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, _fld_Desc);
            db.AddInParameter(dbCommand, "Closing", DbType.String, closing);
            db.AddInParameter(dbCommand, "Phone", DbType.String, phone);
            db.AddInParameter(dbCommand, "Facsimile", DbType.String, facsimile);
            db.AddInParameter(dbCommand, "Title_Department", DbType.String, title_Departement);
            db.AddInParameter(dbCommand, "EMail", DbType.String, eMail);
            db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        public static int Update(decimal pK_COI_Signature, string _fld_Desc, string closing, string phone, string facsimile, string title_Departement, string eMail,string imageName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureUpdate");

            db.AddInParameter(dbCommand, "PK_COI_Signature", DbType.Decimal, pK_COI_Signature);
            db.AddInParameter(dbCommand, "Fld_Desc", DbType.String, _fld_Desc);
            db.AddInParameter(dbCommand, "Closing", DbType.String, closing);
            db.AddInParameter(dbCommand, "Phone", DbType.String, phone);
            db.AddInParameter(dbCommand, "Facsimile", DbType.String, facsimile);
            db.AddInParameter(dbCommand, "Title_Department", DbType.String, title_Departement);
            db.AddInParameter(dbCommand, "EMail", DbType.String, eMail);
            db.AddInParameter(dbCommand, "ImageName", DbType.String, imageName);


            db.ExecuteNonQuery(dbCommand);

            return (Convert.ToInt32(db.ExecuteScalar(dbCommand)));
        }
        /// <summary>
        /// Selects a single record from the COI_Signature table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet Select(decimal pK_COI_Signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureSelect");

            db.AddInParameter(dbCommand, "PK_COI_Signature", DbType.Decimal, pK_COI_Signature);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the COI_Signature table.
        /// <summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByIDs(string strIDs)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureSelectByIDs");
            db.AddInParameter(dbCommand, "strIDs", DbType.String, strIDs);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByPKCOIs(string strPKCOIs)
        {
            if (strPKCOIs == string.Empty) { strPKCOIs = "0"; }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureSelectByCOIs");
            db.AddInParameter(dbCommand, "strPKCOIs", DbType.String, strPKCOIs);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the COI_Property_Policies table by a composite primary key.
        /// <summary>
        public static void Delete(decimal pK_COI_Signature)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("COI_SignatureDelete");

            db.AddInParameter(dbCommand, "PK_COI_Signature", DbType.Decimal, pK_COI_Signature);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Calls parameterized Insert method to Insert the record
        /// </summary>
        /// <returns>The primary key value for newly Inserted record</returns>
        public int Insert()
        {
            return Insert(_Fld_Desc, _Closing, _Phone, _Facsimile, _Title_Departement, _EMail,_ImageName);
        }

        /// <summary>
        /// Calls parameterized Update method to Update the record
        /// </summary>
        public int Update()
        {
           return  Update(_PK_COI_Signature,_Fld_Desc, _Closing, _Phone, _Facsimile, _Title_Departement, _EMail,_ImageName);
        }
        #endregion
    }
}
