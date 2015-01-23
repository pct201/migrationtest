using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class PurchasingServiceContract
    {
        #region Fields
        private decimal pK_Purchasing_Service_Contract;
        private string supplier;
        private string service_Type;
        private Nullable<DateTime> start_Date;
        private Nullable<DateTime> end_Date;
        private decimal term_In_Months;
        private string service_Frequency;
        private decimal monthly_Cost;
        private decimal annual_Cost;
        private decimal fK_LU_Service_Contract;
        private decimal total_Committed;
        private string legal_Confidential;
        private string customer_contract_number;
        private decimal fK_LU_Auto_Renew;
        private string auto_Renew_Other;
        private decimal notification_Method;
        private Nullable<DateTime> notification_Date;
        private string notification_Content;
        private string renewal_Terms;
        private string notification_Terms;
        private string applicable_Dealers;
        private string updated_By;
        private DateTime update_Date;
        private string status;
        private string _COI_Needed;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_Service_Contract value.
        /// </summary>
        public decimal PK_Purchasing_Service_Contract
        {
            get { return pK_Purchasing_Service_Contract; }
            set { pK_Purchasing_Service_Contract = value; }
        }

        /// <summary>
        /// Gets or sets the Supplier value.
        /// </summary>
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Type value.
        /// </summary>
        public string Service_Type
        {
            get { return service_Type; }
            set { service_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Type value.
        /// </summary>
        public string COI_Needed
        {
            get { return _COI_Needed; }
            set { _COI_Needed = value; }
        }

        /// <summary>
        /// Gets or sets the Start_Date value.
        /// </summary>
        public Nullable<DateTime> Start_Date
        {
            get { return start_Date; }
            set { start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the End_Date value.
        /// </summary>
        public Nullable<DateTime> End_Date
        {
            get { return end_Date; }
            set { end_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Term_In_Months value.
        /// </summary>
        public decimal Term_In_Months
        {
            get { return term_In_Months; }
            set { term_In_Months = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Frequency value.
        /// </summary>
        public string Service_Frequency
        {
            get { return service_Frequency; }
            set { service_Frequency = value; }
        }

        /// <summary>
        /// Gets or sets the Monthly_Cost value.
        /// </summary>
        public decimal Monthly_Cost
        {
            get { return monthly_Cost; }
            set { monthly_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Annual_Cost value.
        /// </summary>
        public decimal Annual_Cost
        {
            get { return annual_Cost; }
            set { annual_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Service_Contract value.
        /// </summary>
        public decimal FK_LU_Service_Contract
        {
            get { return fK_LU_Service_Contract; }
            set { fK_LU_Service_Contract = value; }
        }

        /// <summary>
        /// Gets or sets the Total_Committed value.
        /// </summary>
        public decimal Total_Committed
        {
            get { return total_Committed; }
            set { total_Committed = value; }
        }

        /// <summary>
        /// Gets or sets the Legal_Confidential value.
        /// </summary>
        public string Legal_Confidential
        {
            get { return legal_Confidential; }
            set { legal_Confidential = value; }
        }

        /// <summary>
        /// Gets or sets the Auto_Renew_Other value.
        /// </summary>
        public string Customer_Contract_Number
        {
            get { return customer_contract_number; }
            set { customer_contract_number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Auto_Renew value.
        /// </summary>
        public decimal FK_LU_Auto_Renew
        {
            get { return fK_LU_Auto_Renew; }
            set { fK_LU_Auto_Renew = value; }
        }

        /// <summary>
        /// Gets or sets the Auto_Renew_Other value.
        /// </summary>
        public string Auto_Renew_Other
        {
            get { return auto_Renew_Other; }
            set { auto_Renew_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Method value.
        /// </summary>
        public decimal Notification_Method
        {
            get { return notification_Method; }
            set { notification_Method = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Date value.
        /// </summary>
        public Nullable<DateTime> Notification_Date
        {
            get { return notification_Date; }
            set { notification_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Content value.
        /// </summary>
        public string Notification_Content
        {
            get { return notification_Content; }
            set { notification_Content = value; }
        }

        /// <summary>
        /// Gets or sets the Renewal_Terms value.
        /// </summary>
        public string Renewal_Terms
        {
            get { return renewal_Terms; }
            set { renewal_Terms = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Terms value.
        /// </summary>
        public string Notification_Terms
        {
            get { return notification_Terms; }
            set { notification_Terms = value; }
        }

        /// <summary>
        /// Gets or sets the Applicable_Dealers value.
        /// </summary>
        public string Applicable_Dealers
        {
            get { return applicable_Dealers; }
            set { applicable_Dealers = value; }
        }

        ///// <summary>
        ///// Gets or sets the Supplier_Contact_Name value.
        ///// </summary>
        //public string Supplier_Contact_Name
        //{
        //    get { return supplier_Contact_Name; }
        //    set { supplier_Contact_Name = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Title value.
        ///// </summary>
        //public string Supplier_Title
        //{
        //    get { return supplier_Title; }
        //    set { supplier_Title = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Address_1 value.
        ///// </summary>
        //public string Supplier_Address_1
        //{
        //    get { return supplier_Address_1; }
        //    set { supplier_Address_1 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Address_2 value.
        ///// </summary>
        //public string Supplier_Address_2
        //{
        //    get { return supplier_Address_2; }
        //    set { supplier_Address_2 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_City value.
        ///// </summary>
        //public string Supplier_City
        //{
        //    get { return supplier_City; }
        //    set { supplier_City = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_State_Supplier value.
        ///// </summary>
        //public decimal FK_State_Supplier
        //{
        //    get { return fK_State_Supplier; }
        //    set { fK_State_Supplier = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_ZIP_Code value.
        ///// </summary>
        //public string Supplier_ZIP_Code
        //{
        //    get { return supplier_ZIP_Code; }
        //    set { supplier_ZIP_Code = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Work_Telephone value.
        ///// </summary>
        //public string Supplier_Work_Telephone
        //{
        //    get { return supplier_Work_Telephone; }
        //    set { supplier_Work_Telephone = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Cell_Telephone value.
        ///// </summary>
        //public string Supplier_Cell_Telephone
        //{
        //    get { return supplier_Cell_Telephone; }
        //    set { supplier_Cell_Telephone = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Facsimile value.
        ///// </summary>
        //public string Supplier_Facsimile
        //{
        //    get { return supplier_Facsimile; }
        //    set { supplier_Facsimile = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Email value.
        ///// </summary>
        //public string Supplier_Email
        //{
        //    get { return supplier_Email; }
        //    set { supplier_Email = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Supplier_Notes value.
        ///// </summary>
        //public string Supplier_Notes
        //{
        //    get { return supplier_Notes; }
        //    set { supplier_Notes = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Contact_Name value.
        ///// </summary>
        //public string Sonic_Contact_Name
        //{
        //    get { return sonic_Contact_Name; }
        //    set { sonic_Contact_Name = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Title value.
        ///// </summary>
        //public string Sonic_Title
        //{
        //    get { return sonic_Title; }
        //    set { sonic_Title = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Address_1 value.
        ///// </summary>
        //public string Sonic_Address_1
        //{
        //    get { return sonic_Address_1; }
        //    set { sonic_Address_1 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Address_2 value.
        ///// </summary>
        //public string Sonic_Address_2
        //{
        //    get { return sonic_Address_2; }
        //    set { sonic_Address_2 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_City value.
        ///// </summary>
        //public string Sonic_City
        //{
        //    get { return sonic_City; }
        //    set { sonic_City = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_State_Sonic value.
        ///// </summary>
        //public decimal FK_State_Sonic
        //{
        //    get { return fK_State_Sonic; }
        //    set { fK_State_Sonic = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_ZIP_Code value.
        ///// </summary>
        //public string Sonic_ZIP_Code
        //{
        //    get { return sonic_ZIP_Code; }
        //    set { sonic_ZIP_Code = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Work_Telephone value.
        ///// </summary>
        //public string Sonic_Work_Telephone
        //{
        //    get { return sonic_Work_Telephone; }
        //    set { sonic_Work_Telephone = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Cell_Telephone value.
        ///// </summary>
        //public string Sonic_Cell_Telephone
        //{
        //    get { return sonic_Cell_Telephone; }
        //    set { sonic_Cell_Telephone = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Facsimile value.
        ///// </summary>
        //public string Sonic_Facsimile
        //{
        //    get { return sonic_Facsimile; }
        //    set { sonic_Facsimile = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Email value.
        ///// </summary>
        //public string Sonic_Email
        //{
        //    get { return sonic_Email; }
        //    set { sonic_Email = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Sonic_Notes value.
        ///// </summary>
        //public string Sonic_Notes
        //{
        //    get { return sonic_Notes; }
        //    set { sonic_Notes = value; }
        //}

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return updated_By; }
            set { updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return update_Date; }
            set { update_Date = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        #endregion

        #region "Methods"

        /// <summary>
        /// set properties
        /// </summary>
        /// <param name="_pK_Purchasing_Service_Contract"></param>
        /// <returns></returns>
        public bool View(int _pK_Purchasing_Service_Contract)
        {
            try
            {
                DataTable dt = Purchasing_ServiceContractSelect(_pK_Purchasing_Service_Contract);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    clsGeneral.SetDefaultValuesForDBNull(dr);

                    pK_Purchasing_Service_Contract = _pK_Purchasing_Service_Contract;
                    supplier = dr["supplier"].ToString();
                    service_Type = dr["service_Type"].ToString();
                    start_Date = Convert.ToDateTime(dr["start_Date"].ToString());
                    end_Date = Convert.ToDateTime(dr["end_Date"].ToString());
                    term_In_Months = Convert.ToDecimal(dr["term_In_Months"].ToString());
                    service_Frequency = dr["service_Frequency"].ToString();
                    monthly_Cost = Convert.ToDecimal(dr["monthly_Cost"].ToString());
                    annual_Cost = Convert.ToDecimal(dr["annual_Cost"].ToString());
                    fK_LU_Service_Contract = Convert.ToDecimal(dr["fK_LU_Service_Contract"].ToString());
                    total_Committed = Convert.ToDecimal(dr["total_Committed"].ToString());
                    legal_Confidential = dr["legal_Confidential"].ToString();
                    fK_LU_Auto_Renew = Convert.ToDecimal(dr["fK_LU_Auto_Renew"].ToString());
                    auto_Renew_Other = dr["auto_Renew_Other"].ToString();
                    notification_Method = Convert.ToDecimal(dr["notification_Method"].ToString());
                    notification_Date = Convert.ToDateTime(dr["notification_Date"].ToString());
                    notification_Content = dr["notification_Content"].ToString();
                    renewal_Terms = dr["renewal_Terms"].ToString();
                    notification_Terms = dr["notification_Terms"].ToString();
                    applicable_Dealers = dr["applicable_Dealers"].ToString();
                    customer_contract_number = Convert.ToString(dr["customer_contract_number"]);
                    status = dr["Status"].ToString();

                    if (string.IsNullOrEmpty(Convert.ToString(dr["COI_Needed"])))
                        _COI_Needed = "N";
                    else
                        _COI_Needed = Convert.ToString(dr["COI_Needed"]);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_ServiceContractSelect(int pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractSelect");

            db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, pK_Purchasing_Service_Contract);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }
        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_ServiceContractSelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataSet Purchasing_ServiceContractSearch(Nullable<DateTime> dtStartDateFrom, Nullable<DateTime> dtStartDateTo, Nullable<DateTime> dtEndDateFrom, Nullable<DateTime> dtEndDateTo,
            string Region, string Market, decimal FK_LU_Location_Id, decimal FK_LU_Service_Contract, decimal FK_LU_Dealership_Department, string Supplier, string ServiceType, string strOrderBy, string strOrder, int intPageNo, int intPageSize, string strIsCorporateUser)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_Contract_Search");
            db.AddInParameter(dbCommand, "dtStartDateFrom", DbType.DateTime, dtStartDateFrom);
            db.AddInParameter(dbCommand, "dtStartDateTo", DbType.DateTime, dtStartDateTo);
            db.AddInParameter(dbCommand, "dtEndDateFrom", DbType.DateTime, dtEndDateFrom);
            db.AddInParameter(dbCommand, "dtEndDateTo", DbType.DateTime, dtEndDateTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "Market", DbType.String, Market);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "FK_LU_Service_Contract", DbType.Decimal, FK_LU_Service_Contract);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, Supplier);
            db.AddInParameter(dbCommand, "ServiceType", DbType.String, ServiceType);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "bIsCorporateUser", DbType.String, strIsCorporateUser);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Inserts a record into the Purchasing_Service_Contract table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractInsert");

            db.AddInParameter(dbCommand, "Supplier", DbType.String, this.supplier);
            db.AddInParameter(dbCommand, "Service_Type", DbType.String, this.service_Type);
            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this.start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this.end_Date);
            db.AddInParameter(dbCommand, "Term_In_Months", DbType.Decimal, this.term_In_Months);
            db.AddInParameter(dbCommand, "Service_Frequency", DbType.String, this.service_Frequency);
            db.AddInParameter(dbCommand, "Monthly_Cost", DbType.Decimal, this.monthly_Cost);
            db.AddInParameter(dbCommand, "Annual_Cost", DbType.Decimal, this.annual_Cost);
            db.AddInParameter(dbCommand, "FK_LU_Service_Contract", DbType.Decimal, this.fK_LU_Service_Contract);
            db.AddInParameter(dbCommand, "Total_Committed", DbType.Decimal, this.total_Committed);
            db.AddInParameter(dbCommand, "Legal_Confidential", DbType.String, this.legal_Confidential);
            db.AddInParameter(dbCommand, "customer_contract_number", DbType.String, this.customer_contract_number);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Renew", DbType.Decimal, this.fK_LU_Auto_Renew);
            db.AddInParameter(dbCommand, "Auto_Renew_Other", DbType.String, this.auto_Renew_Other);
            db.AddInParameter(dbCommand, "Notification_Method", DbType.Decimal, this.notification_Method);
            db.AddInParameter(dbCommand, "Notification_Date", DbType.DateTime, this.notification_Date);
            db.AddInParameter(dbCommand, "Notification_Content", DbType.String, this.notification_Content);
            db.AddInParameter(dbCommand, "Renewal_Terms", DbType.String, this.renewal_Terms);
            db.AddInParameter(dbCommand, "Notification_Terms", DbType.String, this.notification_Terms);
            db.AddInParameter(dbCommand, "Applicable_Dealers", DbType.String, this.applicable_Dealers);            
           
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this.updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this.update_Date);
            db.AddInParameter(dbCommand, "Status", DbType.String, status);
            db.AddInParameter(dbCommand, "COI_Needed", DbType.String, _COI_Needed);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Inserts a record into the Purchasing_Service_Contract table.
        /// </summary>
        /// <returns></returns>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, this.pK_Purchasing_Service_Contract);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, this.supplier);
            db.AddInParameter(dbCommand, "Service_Type", DbType.String, this.service_Type);
            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this.start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, this.end_Date);
            db.AddInParameter(dbCommand, "Term_In_Months", DbType.Decimal, this.term_In_Months);
            db.AddInParameter(dbCommand, "Service_Frequency", DbType.String, this.service_Frequency);
            db.AddInParameter(dbCommand, "Monthly_Cost", DbType.Decimal, this.monthly_Cost);
            db.AddInParameter(dbCommand, "Annual_Cost", DbType.Decimal, this.annual_Cost);
            db.AddInParameter(dbCommand, "FK_LU_Service_Contract", DbType.Decimal, this.fK_LU_Service_Contract);
            db.AddInParameter(dbCommand, "Total_Committed", DbType.Decimal, this.total_Committed);
            db.AddInParameter(dbCommand, "Legal_Confidential", DbType.String, this.legal_Confidential);
            db.AddInParameter(dbCommand, "customer_contract_number", DbType.String, this.customer_contract_number);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Renew", DbType.Decimal, this.fK_LU_Auto_Renew);
            db.AddInParameter(dbCommand, "Auto_Renew_Other", DbType.String, this.auto_Renew_Other);
            db.AddInParameter(dbCommand, "Notification_Method", DbType.Decimal, this.notification_Method);
            db.AddInParameter(dbCommand, "Notification_Date", DbType.DateTime, this.notification_Date);
            db.AddInParameter(dbCommand, "Notification_Content", DbType.String, this.notification_Content);
            db.AddInParameter(dbCommand, "Renewal_Terms", DbType.String, this.renewal_Terms);
            db.AddInParameter(dbCommand, "Notification_Terms", DbType.String, this.notification_Terms);
            db.AddInParameter(dbCommand, "Applicable_Dealers", DbType.String, this.applicable_Dealers);           
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, this.updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this.update_Date);
            db.AddInParameter(dbCommand, "Status", DbType.String, status);
            db.AddInParameter(dbCommand, "COI_Needed", DbType.String, _COI_Needed);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select Unique Contact information of Supplier
        /// </summary>
        /// <returns></returns>
        public static DataTable SupplierContactSelect()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PSC_Supplier_Contact_Select");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select Unique Contact information of Supplier
        /// </summary>
        /// <returns></returns>
        public static DataTable SonicContactSelect()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PSC_Sonic_Contact_Select");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select Contact information of Supplier by selected value
        /// </summary>
        /// <returns></returns>
        public static DataSet SupplierContactSelectByValue(string strSupplierContactInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PSC_Supplier_Contact_Select_By_Value");
            db.AddInParameter(dbCommand, "Supplier_Contact_Info", DbType.String, strSupplierContactInfo);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Contact information of Sonic by selected value
        /// </summary>
        /// <returns></returns>
        public static DataSet SonicContactSelectByValue(string strSonicContactInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PSC_Sonic_Contact_Select_By_Value");
            db.AddInParameter(dbCommand, "Sonic_Contact_Info", DbType.String, strSonicContactInfo);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_Service_Contract table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_ContractDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, pK_Purchasing_Service_Contract);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select Contact information of Sonic by selected value
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectAllServiceType()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PSC_ServiceType");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// select contact information for Generate Abstract Report
        /// </summary>
        /// <param name="pK_Purchasing_Service_Contract"></param>
        /// <returns></returns>
        public static DataSet GetServiceContractAbstract(decimal pK_Purchasing_Service_Contract)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_Contract_GetAbstract");

            db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, pK_Purchasing_Service_Contract);

            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
