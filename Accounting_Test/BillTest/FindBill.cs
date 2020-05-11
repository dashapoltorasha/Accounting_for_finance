using Accounting_for_finance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_Test
{
    [TestClass]
    public class FindBill
    {
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            DbService.ClearAll();
            // DbService.RefrashDb(true);
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestMethod]
        public void FindOne()
        {
            Bill bill = new Bill
            {
                Id = 11,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);

            Bill test = new Bill
            {
                Id = 11,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            Bill result = DbService.FindBill(test.Id);
            Assert.AreEqual(Convert.ToUInt32(15000), result.Balance);
        }

        [TestMethod]
        public void FindOneNonExist()
        {
            Bill bill = new Bill
            {
                Id = 12,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);

            Bill test = new Bill
            {
                Id = 13,
                Type = false,
                Text = "Sber",
                Description = "Card",
                Balance = 15000
            };
            Bill result = DbService.FindBill(test.Id);
            Assert.IsNull(result);
        }
    }
}
