using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public partial class Invoice
    {
        /// <summary>
        /// Gets or sets the total amount of the invoice with the associated discount.
        /// </summary>
        public decimal TotalAmount
        {
            get
            {
                // Forgot to divide by 100
                return this.InvoiceAmount - (this.InvoiceAmount * this.DiscountPercent);
            }
        }
    }
}
