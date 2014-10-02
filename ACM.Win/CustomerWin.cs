using System.Windows.Forms;
using System;
using ACM.Library;
using System.Linq;
using System.Text;
using ACM.BL;

namespace ACM.Win
{
    /// <summary>
    /// Main User Interface for the application.
    /// </summary>
	public partial class CustomerWin : Form
	{
		public CustomerWin()
		{
			InitializeComponent();
		}

		private void CustomerWin_Load(object sender, EventArgs e)
		{
		}

        private void CustomersButton_Click(object sender, EventArgs e)
        {
            DetailDataGridView.DataSource = CustomerRepository.Retrieve(); ;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			DetailDataGridView.DataSource = InvoiceRepository.Retrieve();
		}

		private void ToolStripButton2_Click(object sender, EventArgs e)
		{
			DetailDataGridView.DataSource = InvoiceRepository.GroupAndSum();
		}

		private void FindButton_Click(object sender, EventArgs e)
		{
			using (CustomerFindWin FindForm = new CustomerFindWin())
			{
				DialogResult result = FindForm.ShowDialog();

				if (result == DialogResult.OK )
				{
					try 
					{
                        var custList = CustomerRepository.Retrieve();
						DetailDataGridView.DataSource = custList.FindCustomers(FindForm.NameToFind);
					}
					catch (ArgumentOutOfRangeException)
					{
						MessageBox.Show("No text was entered for the find.");
					}
				}
			}
		}

        private void NewCustomerButton_Click(object sender, EventArgs e)
        {
            Customer customerInstance = Customer.Create();
        }

	}
}
