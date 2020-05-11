using Accounting_for_finance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting_Test
{
    [TestClass]
    public class UpdateBill
    {
        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            DbService.ClearAll();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            DbService.ClearAll();
            DbService.RefrashDb();
        }

        [TestMethod]
        public void UpdateOne()
        {
            Bill bill = new Bill
            {
                Id = 8,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);
  
            bill.Text = "Sberbank";
            DbService.UpdateBill(bill);
            string upstring = DbService.LoadAllBills().First().Text;

            Assert.AreEqual("Sberbank", upstring);
        }

        [TestMethod]
        public void UpdateEmpty()
        {
            Bill bill = new Bill
            {
                Id = 9,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);
            
            bill = null;
            DbService.UpdateBill(bill);
            string upstring = DbService.LoadAllBills().First().Description;

            Assert.AreEqual("Card", upstring);
        }

        [TestMethod]
        public void NonUpdateWoW()
        {
            Bill bill = new Bill
            {
                Id = 10,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);

            bill.Number = "";
            string upstring = DbService.LoadAllBills().First().Number;

            Assert.AreEqual("", upstring);
        }

        [TestMethod]
        public void NonUpdateWoW2()
        {
            Bill bill = new Bill
            {
                Id = 10,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);

            bill.Type = false;
            bool upstring = DbService.LoadAllBills().First().Type;

            Assert.AreEqual(false, upstring);
        }
    }
}
