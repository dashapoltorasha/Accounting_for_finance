using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting_for_finance.Models
{
    [Table("Operation")]
    public class Operation
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public DateTime date { get; set; }
        public Bill bill { get; set; }
        public Category category { get; set; }
        public uint amount { get; set; }
        public string Comments { get; set; }
    }
}
