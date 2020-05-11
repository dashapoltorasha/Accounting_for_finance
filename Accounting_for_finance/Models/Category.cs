using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Models
{
    [Table("Category")]
    public class Category
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; }
    }
}
