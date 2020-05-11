using Accounting_for_finance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Accounting_Test
{
    [TestClass]
    public class AddBills
    {
        [ClassInitialize()] 
        public static void MyClassInitialize(TestContext testContext) 
        { 
            DbService.RefrashDb();
            DbService.ClearAll(); 
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            // очистка контекста
            DbService.RefrashDb();
            DbService.ClearAll();

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            // обновить базу данных
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [TestMethod]
        public void AddOneBill()
        {
            Bill bill = new Bill
            {
                Id = 7,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            DbService.AddBill(bill);
            int count = DbService.LoadAllBills().Count;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(count, 1);
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [TestMethod]
        public void AddTwoSame()
        {
            DbService.AddBill(new Bill
            {
                Id=2,
                Type = true,
                Text = "VTB",
                Description = "Card",
                Balance = 15000,
                Number = "5487"
            });
            DbService.AddBill(new Bill
            {
                Id = 3,
                Type = false,
                Text = "Cash",
                Description = "",
                Balance = 5000,
                Number = ""
            });
            int count = DbService.LoadAllBills().Count;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, count);
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [TestMethod]
        public void AddListLinks()
        {
            Bill bill1 = new Bill
            {
                Id = 4,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            };
            Bill bill2 = new Bill
            {
                Id = 5,
                Type = true,
                Text = "VTB",
                Description = "Card",
                Balance = 15000,
                Number = "5487"
            };
            Bill bill3 = new Bill
            {
                Id = 6,
                Type = false,
                Text = "Cash",
                Description = "",
                Balance = 5000,
                Number = ""
            };

            DbService.AddBill(bill1);
            DbService.AddBill(bill2);
            DbService.AddBill(bill3);

            int count = DbService.LoadAllBills().Count;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3, count);
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [TestMethod]
        public void AddEmpty()
        {
            Bill bill = new Bill();
            DbService.AddBill(bill);
            int count = DbService.LoadAllBills().Count;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, count);
            DbService.RefrashDb();
            DbService.ClearAll();
        }

        [TestMethod]
        public void AddNull()
        {
            DbService.ClearAll();
            Bill bill = null;
            DbService.AddBill(bill);
            int count = DbService.LoadAllBills().Count;

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, count);
            DbService.RefrashDb();
            DbService.ClearAll();
        }
    }
}
