using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.SONIC_DAL
{
	/// <summary>
	/// Data access class for Mortage_informaiton table.
	/// </summary>
	public sealed class Mortage_informaiton  
	{

        #region Private variables used to hold the property values

        private int? _Pk_Mortgage_Information_ID;
        private int? _FK_RE_Information;
        private int? _FK_LU_Location;
        private DateTime? _Date_of_Note;
        private int? _SRE_ID;
        private string _Letter_Name;
        private DateTime? _Loan_Origination_Date;
        private DateTime? _Loan_Maturity_Date;
        private string _Loan_Status;
        private DateTime? _Mortgage_Commencement_Date;
        private DateTime? _Mortgage_Expiration_Date;
        private string _Loan_Type;
        private string _Loan_Term;
        private decimal? _Orgination_Loan_Amount;
        private string _Spread;
        private decimal? _Payment_Amount;
        private decimal? _Estimated_P_And_I;
        private string _Other;
        private string _Comments;    
        #endregion

        #region Public Property

            public int? Pk_Mortgage_Information_ID
            {
              get { return _Pk_Mortgage_Information_ID; }
              set { _Pk_Mortgage_Information_ID = value; }
            }
      
            public int? FK_RE_Information
            {
              get { return _FK_RE_Information; }
              set { _FK_RE_Information = value; }
            }

            public int? FK_LU_Location
            {
              get { return _FK_LU_Location; }
              set { _FK_LU_Location = value; }
            }

            public DateTime? Date_of_Note
            {
              get { return _Date_of_Note; }
              set { _Date_of_Note = value; }
            }

            public int? SRE_ID
            {
              get { return _SRE_ID; }
              set { _SRE_ID = value; }
            }

            public string Letter_Name
            {
              get { return _Letter_Name; }
              set { _Letter_Name = value; }
            }

            public DateTime? Loan_Origination_Date
            {
              get { return _Loan_Origination_Date; }
              set { _Loan_Origination_Date = value; }
            }

            public DateTime? Loan_Maturity_Date
            {
              get { return _Loan_Maturity_Date; }
              set { _Loan_Maturity_Date = value; }
            }

            public string Loan_Status
            {
              get { return _Loan_Status; }
              set { _Loan_Status = value; }
            }

            public DateTime? Mortgage_Commencement_Date
            {
              get { return _Mortgage_Commencement_Date; }
              set { _Mortgage_Commencement_Date = value; }
            }

            public DateTime? Mortgage_Expiration_Date
            {
              get { return _Mortgage_Expiration_Date; }
              set { _Mortgage_Expiration_Date = value; }
            }

            public string Loan_Type
            {
              get { return _Loan_Type; }
              set { _Loan_Type = value; }
            }

            public string Loan_Term
            {
              get { return _Loan_Term; }
              set { _Loan_Term = value; }
            }

            public decimal? Orgination_Loan_Amount
            {
              get { return _Orgination_Loan_Amount; }
              set { _Orgination_Loan_Amount = value; }
            }

            public string Spread
            {
              get { return _Spread; }
              set { _Spread = value; }
            }

            public decimal? Payment_Amount
            {
              get { return _Payment_Amount; }
              set { _Payment_Amount = value; }
            }

            public decimal? Estimated_P_And_I
            {
              get { return _Estimated_P_And_I; }
              set { _Estimated_P_And_I = value; }
            }

            public string Other
            {
              get { return _Other; }
              set { _Other = value; }
            }

            public string Comments
            {
              get { return _Comments; }
              set { _Comments = value; }
            }    

        #endregion

        #region Default Constructors

        /// <summary>
            /// Initializes a new instance of the Mortage_informaiton class with default value.
        /// </summary>
        public Mortage_informaiton()
        {
            setDefaultValues();
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Mortage_informaiton class based on Primary Key.
        /// </summary>
        public Mortage_informaiton(int Pk_Mortgage_Information_ID)
        {
            DataTable dtMortage_informaiton = SelectByPK(Pk_Mortgage_Information_ID).Tables[0];

            if (dtMortage_informaiton.Rows.Count == 1)
            {
                DataRow drMortage_informaiton = dtMortage_informaiton.Rows[0];

                if (drMortage_informaiton["Pk_Mortgage_Information_ID"] == DBNull.Value)
                    this._Pk_Mortgage_Information_ID = null;
                else
                    this._Pk_Mortgage_Information_ID = (int?)drMortage_informaiton["Pk_Mortgage_Information_ID"];

                if (drMortage_informaiton["FK_RE_Information"] == DBNull.Value)
                    this._FK_RE_Information = null;
                else
                    this._FK_RE_Information = (int?)drMortage_informaiton["FK_RE_Information"];

                if (drMortage_informaiton["FK_LU_Location"] == DBNull.Value)
                    this._FK_LU_Location = null;
                else
                    this._FK_LU_Location = (int?)drMortage_informaiton["FK_LU_Location"];

                if (drMortage_informaiton["Date_of_Note"] == DBNull.Value)
                    this._Date_of_Note = null;
                else
                    this._Date_of_Note = (DateTime?)drMortage_informaiton["Date_of_Note"];

                if (drMortage_informaiton["SRE_ID"] == DBNull.Value)
                    this._SRE_ID = null;
                else
                    this._SRE_ID = (int?)drMortage_informaiton["SRE_ID"];

                if (drMortage_informaiton["Letter_Name"] == DBNull.Value)
                    this._Letter_Name = null;
                else
                    this._Letter_Name = (string)drMortage_informaiton["Letter_Name"];

                if (drMortage_informaiton["Loan_Origination_Date"] == DBNull.Value)
                    this._Loan_Origination_Date = null;
                else
                    this._Loan_Origination_Date = (DateTime?)drMortage_informaiton["Loan_Origination_Date"];

                if (drMortage_informaiton["Loan_Maturity_Date"] == DBNull.Value)
                    this._Loan_Maturity_Date = null;
                else
                    this._Loan_Maturity_Date = (DateTime?)drMortage_informaiton["Loan_Maturity_Date"];

                if (drMortage_informaiton["Loan_Status"] == DBNull.Value)
                    this._Loan_Status = null;
                else
                    this._Loan_Status = (string)drMortage_informaiton["Loan_Status"];

                if (drMortage_informaiton["Mortgage_Commencement_Date"] == DBNull.Value)
                    this._Mortgage_Commencement_Date = null;
                else
                    this._Mortgage_Commencement_Date = (DateTime?)drMortage_informaiton["Mortgage_Commencement_Date"];

                if (drMortage_informaiton["Mortgage_Expiration_Date"] == DBNull.Value)
                    this._Mortgage_Expiration_Date = null;
                else
                    this._Mortgage_Expiration_Date = (DateTime?)drMortage_informaiton["Mortgage_Expiration_Date"];

                if (drMortage_informaiton["Loan_Type"] == DBNull.Value)
                    this._Loan_Type = null;
                else
                    this._Loan_Type = (string)drMortage_informaiton["Loan_Type"];

                if (drMortage_informaiton["Loan_Term"] == DBNull.Value)
                    this._Loan_Term = null;
                else
                    this._Loan_Term = (string)drMortage_informaiton["Loan_Term"];
                
                if (drMortage_informaiton["Orgination_Loan_Amount"] == DBNull.Value)
                    this._Orgination_Loan_Amount = null;
                else
                    this._Orgination_Loan_Amount = (decimal?)drMortage_informaiton["Orgination_Loan_Amount"];

                if (drMortage_informaiton["Spread"] == DBNull.Value)
                    this._Spread = null;
                else
                    this._Spread = (string)drMortage_informaiton["Spread"];

                if (drMortage_informaiton["Payment_Amount"] == DBNull.Value)
                    this._Payment_Amount = null;
                else
                    this._Payment_Amount = (decimal?)drMortage_informaiton["Payment_Amount"];

                if (drMortage_informaiton["Estimated_P_And_I"] == DBNull.Value)
                    this._Estimated_P_And_I = null;
                else
                    this._Estimated_P_And_I = (decimal?)drMortage_informaiton["Estimated_P_And_I"];

                if (drMortage_informaiton["Other"] == DBNull.Value)
                    this._Other = null;
                else
                    this._Other = (string)drMortage_informaiton["Other"];
                if (drMortage_informaiton["Comments"] == DBNull.Value)
                    this._Comments = null;
                else
                    this._Comments = (string)drMortage_informaiton["Comments"];
       
            }
            else
            {
                setDefaultValues();
            }

        }
      
        private void setDefaultValues()
        {
            this._Pk_Mortgage_Information_ID = null;
            this._FK_RE_Information = null;
            this._FK_LU_Location = null;
            this._Date_of_Note = null;
            this._SRE_ID = null;
            this._Letter_Name = null;
            this._Loan_Origination_Date = null;
            this._Loan_Maturity_Date = null;
            this._Loan_Status = null;
            this._Mortgage_Commencement_Date = null;
            this._Mortgage_Expiration_Date = null;
            this._Loan_Type = null;
            this._Loan_Term = null;
            this._Orgination_Loan_Amount = null;
            this._Spread = null;
            this._Payment_Amount = null;
            this._Estimated_P_And_I = null;
            this._Other = null;
            this._Comments = null;
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Mortage_Informaiton table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Mortage_Informaiton_Insert");
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Int32, this._FK_RE_Information);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Int32, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Date_of_Note", DbType.DateTime, this._Date_of_Note);
            db.AddInParameter(dbCommand, "SRE_ID", DbType.Int32, this.SRE_ID);
            if (string.IsNullOrEmpty(this._Letter_Name))
                db.AddInParameter(dbCommand, "Letter_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_Name", DbType.String, this._Letter_Name);
            db.AddInParameter(dbCommand, "Loan_Origination_Date", DbType.DateTime, this.Loan_Origination_Date);
            db.AddInParameter(dbCommand, "Loan_Maturity_Date", DbType.DateTime, this.Loan_Maturity_Date);
            if (string.IsNullOrEmpty(this._Loan_Status))
                db.AddInParameter(dbCommand, "Loan_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Status", DbType.String, this._Loan_Status);
            db.AddInParameter(dbCommand, "Mortgage_Commencement_Date", DbType.DateTime, this._Mortgage_Commencement_Date);
            db.AddInParameter(dbCommand, "Mortgage_Expiration_Date", DbType.DateTime, this._Mortgage_Expiration_Date);
            if (string.IsNullOrEmpty(this._Loan_Type))
                db.AddInParameter(dbCommand, "Loan_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Type", DbType.String, this._Loan_Type);
            if (string.IsNullOrEmpty(this._Loan_Term))
                db.AddInParameter(dbCommand, "Loan_Term", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Term", DbType.String, this._Loan_Term);
            db.AddInParameter(dbCommand, "Orgination_Loan_Amount", DbType.Decimal, this._Orgination_Loan_Amount);
            if (string.IsNullOrEmpty(this._Spread))
                db.AddInParameter(dbCommand, "Spread", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Spread", DbType.String, this._Spread);
            db.AddInParameter(dbCommand, "Payment_Amount", DbType.Decimal, this._Payment_Amount);
            db.AddInParameter(dbCommand, "Estimated_P_And_I", DbType.Decimal, this._Estimated_P_And_I);
            if (string.IsNullOrEmpty(this._Other))
                db.AddInParameter(dbCommand, "Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other", DbType.String, this._Other);
            if (string.IsNullOrEmpty(this._Spread))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Mortage_Informaiton table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(int Pk_Mortgage_Information_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Mortage_Informaiton_SelectByPK");

            db.AddInParameter(dbCommand, "Pk_Mortgage_Information_ID", DbType.Int32, Pk_Mortgage_Information_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Abstract Detail
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public DataSet GetLoanSummarySelectByPK(int Pk_Mortgage_Information_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Mortage_InformaitonLoan_SelectByPK");

            db.AddInParameter(dbCommand, "Pk_Mortgage_Information_ID", DbType.Int32, Pk_Mortgage_Information_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Mortage_informaiton table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Mortage_InformaitonUpdate");

            db.AddInParameter(dbCommand, "Pk_Mortgage_Information_ID", DbType.Decimal, this._Pk_Mortgage_Information_ID);
            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Int32, this._FK_RE_Information);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Int32, this._FK_LU_Location);
            db.AddInParameter(dbCommand, "Date_of_Note", DbType.DateTime, this._Date_of_Note);
            db.AddInParameter(dbCommand, "SRE_ID", DbType.Int32, this.SRE_ID);
            if (string.IsNullOrEmpty(this._Letter_Name))
                db.AddInParameter(dbCommand, "Letter_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Letter_Name", DbType.String, this._Letter_Name);
            db.AddInParameter(dbCommand, "Loan_Origination_Date", DbType.DateTime, this.Loan_Origination_Date);
            db.AddInParameter(dbCommand, "Loan_Maturity_Date", DbType.DateTime, this.Loan_Maturity_Date);
            if (string.IsNullOrEmpty(this._Loan_Status))
                db.AddInParameter(dbCommand, "Loan_Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Status", DbType.String, this._Loan_Status);
            db.AddInParameter(dbCommand, "Mortgage_Commencement_Date", DbType.DateTime, this._Mortgage_Commencement_Date);
            db.AddInParameter(dbCommand, "Mortgage_Expiration_Date", DbType.DateTime, this._Mortgage_Expiration_Date);
            if (string.IsNullOrEmpty(this._Loan_Type))
                db.AddInParameter(dbCommand, "Loan_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Type", DbType.String, this._Loan_Type);
            if (string.IsNullOrEmpty(this._Loan_Term))
                db.AddInParameter(dbCommand, "Loan_Term", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Loan_Term", DbType.String, this._Loan_Term);
            db.AddInParameter(dbCommand, "Orgination_Loan_Amount", DbType.Decimal, this._Orgination_Loan_Amount);
            if (string.IsNullOrEmpty(this._Spread))
                db.AddInParameter(dbCommand, "Spread", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Spread", DbType.String, this._Spread);
            db.AddInParameter(dbCommand, "Payment_Amount", DbType.Decimal, this._Payment_Amount);
            db.AddInParameter(dbCommand, "Estimated_P_And_I", DbType.Decimal, this._Estimated_P_And_I);
            if (string.IsNullOrEmpty(this._Other))
                db.AddInParameter(dbCommand, "Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other", DbType.String, this._Other);
            if (string.IsNullOrEmpty(this._Spread))
                db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);

           
            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByMortgageLoanInformationID(int FK_RE_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Mortage_Informaiton_SelectByFK");

            db.AddInParameter(dbCommand, "FK_RE_Information", DbType.Int32, FK_RE_Information);

            return db.ExecuteDataSet(dbCommand);
        }

	}
}
