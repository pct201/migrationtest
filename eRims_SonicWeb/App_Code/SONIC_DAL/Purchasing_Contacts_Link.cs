using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;


/// <summary>
/// Summary description for Purchasing_Contacts_Link
/// </summary>
/// 
namespace ERIMS.DAL
{
public sealed class Purchasing_Contacts_Link
{
    #region Fields
    private decimal pK_Purchasing_Contacts_Link;
    private string table_Name;
    private decimal fK_Table_Name;
    private decimal fK_Purchasing_Contacts;
    private DateTime contact_Link_Date;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the Purchasing_SC_Dealer class.
        /// </summary>
        public Purchasing_Contacts_Link()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Dealer value.
        /// </summary>
        public decimal PK_Purchasing_Contacts_Link
        {
            get { return pK_Purchasing_Contacts_Link; }
            set { pK_Purchasing_Contacts_Link = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Purchasing_Service_Contract value.
        /// </summary>
        public string Table_Name
        {
            get { return table_Name; }
            set { table_Name = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_Id value.
        /// </summary>
        public decimal FK_Table_Name
        {
            get { return fK_Table_Name; }
            set { fK_Table_Name = value; }
        }

        /// <summary>
        /// Gets or sets the PK_Purchasing_SC_Dealer value.
        /// </summary>
        public decimal FK_Purchasing_Contacts
        {
            get { return fK_Purchasing_Contacts; }
            set { fK_Purchasing_Contacts = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Contact_Link_Date
        {
            get { return contact_Link_Date; }
            set { contact_Link_Date = value; }
        }
        #endregion

        #region "Method"

        /// <summary>
        /// Inserts a record into the Purchasing_SC_Dealer table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contacts_LinkInsert");

            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "FK_Purchasing_Contacts", DbType.Decimal, fK_Purchasing_Contacts);
            db.AddInParameter(dbCommand, "Contact_Link_Date", DbType.DateTime, contact_Link_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

       

        /// <summary>
        /// Selects a single record from the Purchasing_SC_Dealer table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_Purchasing_Contacts_Link)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contacts_LinkSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts_Link", DbType.Decimal, pK_Purchasing_Contacts_Link);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Purchasing_SC_Dealer table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contacts_LinkUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts_Link", DbType.Decimal, pK_Purchasing_Contacts_Link);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, table_Name);
            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, fK_Table_Name);
            db.AddInParameter(dbCommand, "FK_Purchasing_Contacts", DbType.Decimal, fK_Purchasing_Contacts);
            db.AddInParameter(dbCommand, "Contact_Link_Date", DbType.DateTime, contact_Link_Date);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Deletes a record from the Purchasing_SC_Dealer table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_Contacts_Link)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Contacts_LinkDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_Contacts_Link", DbType.Decimal, pK_Purchasing_Contacts_Link);

            db.ExecuteNonQuery(dbCommand);
        }
        #endregion
}
}