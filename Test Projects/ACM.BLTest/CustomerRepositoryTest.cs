﻿using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ACM.BLCSharpTest
{
    
    /// <summary>
    ///This is a test class for Customers and is intended
    ///to contain all Customers Unit Tests
    ///</summary>
    [TestClass()]
    public class CustomerRepositoryTest
    {

        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        [TestCategory("Valid")]
        public void FindCustomersTestValidString()
        {
            // Arrange
            CustomerRepository target = new CustomerRepository
                {new Customer() 
                      { CustomerId = 1, 
                        FirstName="Rosie", 
                        LastName = "Cotton", 
                        EmailAddress = "Rosie@hob.me"}, 
                new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            string searchString = "agg";
            List<Customer> expected = new List<Customer>
                {new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            // Act
            var actual = target.FindCustomers(searchString);

            // Assert
            TestContext.WriteLine(searchString);
            Debug.WriteLine("Using Debug: " + searchString);
            Assert.AreEqual(expected.Count, actual.Count);

            foreach (Customer item in actual)
            {
                TestContext.WriteLine(item.ToString());

                // Find the item in the expected list
                Customer expectedItem = expected.FirstOrDefault(c => c.CustomerId == item.CustomerId);

                Assert.AreEqual(expectedItem.LastName, item.LastName);
                Assert.AreEqual(expectedItem.FirstName, item.FirstName);
                Assert.AreEqual(expectedItem.EmailAddress, item.EmailAddress);
            }
        }

        /// <summary>
        ///A test for FindCustomers
        ///</summary>
        [TestMethod()]
        [TestCategory("Invalid")]
        public void FindCustomersTestNotFoundString()
        {
            // Arrange
            CustomerRepository target = new CustomerRepository
                {new Customer() 
                      { CustomerId = 1, 
                        FirstName="Rosie", 
                        LastName = "Cotton", 
                        EmailAddress = "Rosie@hob.me"}, 
                new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            string customerName = "qzz";
            List<Customer> expected = new List<Customer>();

            // Act
            var actual = target.FindCustomers(customerName);

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);

        }

        /// <summary>
        ///A test for FindCustomers
        ///</summary>
        [TestMethod()]
        [TestCategory("Invalid")]
        public void FindCustomersTestEmptyString()
        {
            // Arrange
            CustomerRepository target = new CustomerRepository
                {new Customer() 
                      { CustomerId = 1, 
                        FirstName="Rosie", 
                        LastName = "Cotton", 
                        EmailAddress = "Rosie@hob.me"}, 
                new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            string customerName = string.Empty;
            List<Customer> expected = null;

            // Act
            var actual = target.FindCustomers(customerName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindCustomers
        ///</summary>
        [TestMethod()]
        [TestCategory("Invalid")]
        [TestCategory("NullTest")]
        public void FindCustomersTestNullString()
        {
            // Arrange
            CustomerRepository target = new CustomerRepository
                {new Customer() 
                      { CustomerId = 1, 
                        FirstName="Rosie", 
                        LastName = "Cotton", 
                        EmailAddress = "Rosie@hob.me"}, 
                new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            string customerName = null;
            List<Customer> expected = null;

            // Act
            var actual = target.FindCustomers(customerName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FindCustomers
        ///</summary>
        [TestMethod()]
        [TestCategory("Invalid")]
        public void FindCustomersTestBlankString()
        {
            // Arrange
            CustomerRepository target = new CustomerRepository
                {new Customer() 
                      { CustomerId = 1, 
                        FirstName="Rosie", 
                        LastName = "Cotton", 
                        EmailAddress = "Rosie@hob.me"}, 
                new Customer() 
                      { CustomerId = 2, 
                        FirstName="Bilbo", 
                        LastName = "Baggins", 
                        EmailAddress = "bb@hob.me"}, 
                new Customer() 
                      { CustomerId = 3, 
                        FirstName="Frodo", 
                        LastName = "Baggins", 
                        EmailAddress = "fb@hob.me"}};

            string customerName = "   ";
            List<Customer> expected = null;

            // Act
            var actual = target.FindCustomers(customerName);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Retrieve
        ///</summary>
        [TestMethod()]
        [TestCategory("Invalid")]
        public void RetrieveTest()
        {
            // Act / Assert
            Assert.AreEqual(5, CustomerRepository.Retrieve().Count);
        }

    }

}
