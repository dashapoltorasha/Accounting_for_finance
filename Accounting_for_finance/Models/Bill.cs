using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Accounting_for_finance.Models
{
    [Table("Bills")]
    public class Bill
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public bool Type { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public uint Balance { get; set; }
        public string Number { get; set; }
    }
}

