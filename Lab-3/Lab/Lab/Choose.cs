using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Lab
{
    [Table("Choose")]
    public class Choose
    {
        public string typeProduct { get; set; }
        public string vendor { get; set; }
        public string dateAdded { get; set; }

    }
}
