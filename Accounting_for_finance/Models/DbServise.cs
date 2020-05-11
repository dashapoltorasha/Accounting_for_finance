using Accounting_for_finance.Data;
using Accounting_for_finance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accounting_for_finance.Models
{
    public static class DbService
    {
        private static ApplicationContext db = new ApplicationContext();

        public static void RefrashDb()
        {
            // Удаляем бд, если она существуеты
           //db.Database.EnsureDeleted();
            // Создаем бд, если она отсутствует
           db.Database.EnsureCreated();
        }
        public static void SaveDb()
        {
            db.SaveChanges();
        }

        public static void LoadAll()
        {
            CategoryData.Categorys = DbService.LoadAllCategory();
            BillData.Bills = DbService.LoadAllBills();
            OperationData.Operations = DbService.LoadAllOperations();
        }

        public static void ClearAll()
        {
            db.Bills.RemoveRange(db.Bills.ToArray());
            db.Categoryes.RemoveRange(db.Categoryes.ToArray());
            db.Operations.RemoveRange(db.Operations.ToArray());
            db.SaveChanges();
        }

        #region Bills

        public static void AddBill(Bill bill)
        {
            if (bill == null) return;
            db.Bills.Add(bill);
            db.SaveChanges();
        }

        public static void RemoveBill(Bill bill)
        {
            if (bill == null) return;
            db.Bills.Remove(bill);
            db.SaveChanges();
        }

        public static void UpdateBill(Bill bill)
        {
            if (bill == null) return;
            db.Bills.Update(bill);
            db.SaveChanges();
        }

        public static Bill FindBill(int id)
        {
            if (db.Bills.Find(id) == null || db.Bills == null) return null;
            return db.Bills.Where(s =>s.Id == id).First();
        }

        public static List<Bill> LoadAllBills()
        {
            return db.Bills.ToList();
        }

        #endregion

        #region Operation

        public static void AddOperation(Operation Operation)
        {
            if (Operation == null) return;
            db.Operations.Add(Operation);
            db.SaveChanges();
        }

        public static List<Operation> LoadAllOperations()
        {
            return db.Operations.ToList();
        }

        public static List<Operation> LoadAllOper(int b, DateTime d1, DateTime d2)
        {
            List <Operation> op = new List<Operation>();
            for (int i = 1; i <= db.Operations.Count(); i++)
            {
                if (b != 0)
                {
                    if (FindOperation(i).bill.Id == b && FindOperation(i).date >= d1 && FindOperation(i).date <= d2)
                        op.Add(FindOperation(i));
                }
                else
                {
                    if (FindOperation(i).date >= d1 && FindOperation(i).date <= d2)
                        op.Add(FindOperation(i));
                }
            }
            return op.ToList();
        }

        public static Operation FindOperation(int id)
        {
            if (db.Operations.Find(id) == null) return null;
            return db.Operations.Where(s => s.Id == id).First();
        }

        public static void RemoveOperation(Operation operation)
        {
            if (operation == null) return;
            db.Operations.Remove(operation);
            db.SaveChanges();
        }

        public static void UpdateOperation(Operation Operation)
        {
            if (Operation == null) return;
            db.Operations.Update(Operation);
            db.SaveChanges();
        }

        public static int FindAmount(DateTime d, Category cat, int k)
        {
            int am = 0;
            for(int i=0;i< OperationData.Operations.Count;i++)
            {
                if (k == 0)
                {
                    if ((OperationData.Operations[i].date == d) && (cat == OperationData.Operations[i].category)) am += Convert.ToInt32(OperationData.Operations[i].amount);
                }
                else
                {
                    if ((OperationData.Operations[i].date == d) && (cat == OperationData.Operations[i].category) && (k == OperationData.Operations[i].bill.Id)) am += Convert.ToInt32(OperationData.Operations[i].amount);
                }
            }
            return am;
        }

        public static List<int> LoadAmountForData(DateTime d, int k)
        {
            List<int> am = new List<int>();
            for (int i=0;i<LoadAllCategory().Count;i++)
            {
                am.Add(FindAmount(d, FindCategory(i+1), k));
            }
            return am;
        }

        #endregion

        #region Categorys

        public static void AddCategory(Category Category)
        {
            if (Category == null) return;
            db.Categoryes.Add(Category);
            db.SaveChanges();
        }

        public static List<Category> LoadAllCategory()
        {
            return db.Categoryes.ToList();
        }

        public static Category FindCategory(int id)
        {
            if (db.Categoryes.Find(id) == null) return null;
            return db.Categoryes.Where(s => s.Id == id).First();
        }

        public static void UpdateCategory(Category category)
        {
            if (category == null) return;
            db.Categoryes.Update(category);
            db.SaveChanges();
        }

        public static void RemoveCategory(Category category)
        {
            if (category == null) return;
            db.Categoryes.Remove(category);
            db.SaveChanges();
        }

        #endregion

        #region Sample

        public static void LoadTestSample()
        {
            //LoadCategorys();
            CategoryData.Categorys = DbService.LoadAllCategory();
            //LoadBills();
            BillData.Bills = DbService.LoadAllBills();
            //LoadOperations();
            OperationData.Operations = DbService.LoadAllOperations();

            SaveDb();

        }

        public static void LoadBills()
        {
            AddBill(new Bill
            {
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            });
            AddBill(new Bill
            {
                Type = true,
                Text = "VTB",
                Description = "Card",
                Balance = 15000,
                Number = "5484"
            });
            AddBill(new Bill
            {
                Type = false,
                Text = "Cash",
                Description = "",
                Balance = 5000,
                Number = ""
            });
        }

        public static void LoadCategorys()
        {
            AddCategory(new Category
            {
                Name = "Покупка",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Продукты",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Транспорт",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Досуг",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Здоровье",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Подарки",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Гигиена",
                Type = true
            });
            AddCategory(new Category
            {
                Name = "Зарплата",
                Type = false
            });
            AddCategory(new Category
            {
                Name = "Перевод",
                Type = true
            });
        }

        public static void LoadOperations()
        {
            AddOperation(new Operation
            {
                date = new DateTime(2020, 3, 20),
                bill = FindBill(0),
                category = FindCategory(2),
                amount = 300,
                Comments = ""
            }); 
            AddOperation(new Operation
            {
                date = new DateTime(2020, 3, 21),
                bill = FindBill(0),
                category = FindCategory(3),
                amount = 500,
                Comments = ""
            });
        }

        #endregion
    }
}
