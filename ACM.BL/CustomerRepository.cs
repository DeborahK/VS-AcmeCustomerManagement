using ACM.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ACM.BL
{
    /// <summary>
    /// Manages the repository for customers.
    /// </summary>
    public class CustomerRepository : BoListBase<Customer>
    {
        #region FindCustomers
        /// <summary>
        /// Find customers by a portion of the name.
        /// </summary>
        /// <param name="customerName">Portion of the last or first name.</param>
        /// <returns></returns>
        public List<Customer> FindCustomers(string customerName)
        {
            List<Customer> foundCustomers = null;

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                foundCustomers = this.Where(c => c.LastName.Contains(customerName) ||
                                            c.FirstName.Contains(customerName)).ToList();
            }

            return foundCustomers;
        }

        /// <summary>
        /// Find customers by Id.
        /// </summary>
        /// <param name="customerId">Id of the customer.</param>
        /// <returns></returns>
        public List<Customer> FindCustomers(int customerId)
        {
            List<Customer> foundCustomers;
            foundCustomers = this.Where(c => c.CustomerId == customerId).ToList();
            return foundCustomers;
        }
        #endregion

        #region Retrieve
        /// <summary>
        /// Retrieves a list from the database and gets a set of results.
        /// </summary>
        /// <remarks>
        /// Use this one if you want to use the actual database
        /// NOTE: You must first build the database using the provided scripts.
        /// See the Database project for the scripts.
        /// </remarks>
        /// <returns></returns>
        public static CustomerRepository  Retrieve()
        {
            CustomerRepository customerList = new CustomerRepository();

            DataTable dt = Dac.ExecuteDataTable("CustomerRetrieve");
            //TODO: Bing Developer Assistant ("DataTable")

            // Process each customer row
            foreach (DataRow dr in dt.Rows)
            {
                Customer customerInstance = new Customer {
                    CustomerId = (int)dr["CustomerId"],
                    LastName = dr["LastName"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    EmailAddress = dr["EmailAddress"].ToString(),
                    CustomerType = (CustomerTypeOption)dr["CustomerType"]};

                // Populate the associated invoices
                //TODO: Go to Definition vs Peek Definition
                customerInstance.InvoiceList = InvoiceRepository.Retrieve(customerInstance.CustomerId);

                customerList.Add(customerInstance);
            }

           return customerList;
        }
        #endregion
    }
}
