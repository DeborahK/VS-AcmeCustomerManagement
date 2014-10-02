using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ACM.Library;

namespace ACM.BL
{
    /// <summary>
    /// Manages a set of invoices
    /// </summary>
    public class Invoices
    {

        #region GetLargeInvoices
        /// <summary>
        /// Gets all invoices with an amount greater than a defined amount
        /// </summary>
        /// <param name="minAmount"></param>
        /// <returns></returns>
        public static List<Invoice> GetLargeInvoices(decimal minAmount) 
        {
            // Get the invoices
            var invoiceList = Retrieve();

            var filteredList = invoiceList.Where(inv =>
                {
                    Debug.WriteLine(inv.InvoiceAmount);
                    return inv.InvoiceAmount > minAmount;
                });

            return filteredList.ToList();
        }
        #endregion

        #region GroupAndSum
        /// <summary>
        /// Groups and sums a set of invoices.
        /// </summary>
        /// <returns></returns>
        public static object GroupAndSum()
        {
            var invoiceList = Retrieve();

            if (invoiceList != null)
            {
                var query = invoiceList
                            .GroupBy(g => new
                            {
                                g.InvoiceDate,
                                g.InvoiceType
                            })
                            .Select(group => new
                            {
                                InvoiceDate = group.Key.InvoiceDate,
                                InvoiceType = group.Key.InvoiceType,
                                InvoiceAmount = group.Select(a => a.InvoiceAmount.ToString()).Where(a => !string.IsNullOrWhiteSpace(a)).
                                                    Distinct().OrderBy(a=>a).Aggregate((current,a)=> current + "/" + a),
                                TotalAmount = group.Sum(a => a.InvoiceAmount),
                                TotalCount = group.Sum(c => c.NumberOfItems)
                            });

                return query.ToList();
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Retrieve
        /// <summary>
        /// Retrieves the set of invoices.
        /// </summary>
        /// <returns></returns>
        public static List<Invoice> Retrieve()
        {
            Logging.DebugMessage("Retrieving Data");

            List<Invoice> invoiceList = new List<Invoice>();

            invoiceList = new List<Invoice> 
                {new Invoice() 
                      { 
                        InvoiceDate=new DateTimeOffset(2010,4,30,0,0,0,new TimeSpan(-7,0,0)), 
                        InvoiceType = 1, 
                        InvoiceAmount = 150, 
                        NumberOfItems = 8}, 
                new Invoice() 
                      { 
                        InvoiceDate=new DateTimeOffset(2010,4,29,0,0,0,new TimeSpan(-7,0,0)), 
                        InvoiceType = 2, 
                        InvoiceAmount = 215, 
                        NumberOfItems = 7}, 
                new Invoice() 
                      { 
                        InvoiceDate=new DateTimeOffset(2010,4,30,0,0,0,new TimeSpan(-7,0,0)), 
                        InvoiceType = 1, 
                        InvoiceAmount = 50, 
                        NumberOfItems = 2}, 
                new Invoice() 
                      { 
                        InvoiceDate=new DateTime(2010,4,29), 
                        InvoiceType = 2, 
                        InvoiceAmount = 550, 
                        NumberOfItems = 5}};

            Logging.DebugMessage(string.Format("{0} invoices retrieved", invoiceList.Count));

            return invoiceList;
        }
        #endregion

        #region  Private Methods
        // Lots of functions with similar names,
        private List<Invoice> SumAndGroupAndSum() 
        {
            var invoiceList = Retrieve();
            return null;
        }

        private List<Invoice> GroupAndSumThenGroup() 
        {
            var invoiceList = Retrieve();
            return null;
        }

        private List<Invoice> JustGroup() 
        {
            var invoiceList = Retrieve();
            return null;
        }

        private List<Invoice> JustSum() 
        {
            var invoiceList = Retrieve();
            return null;
        }
        #endregion

    }
}
