﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class ItemSize
    {
        [Key]
        public int ItemSizeId { get; set; }
        public int ItemId { get; set; }
        public string Size { get; set; }
        public string Desc { get; set; }


        //common columns
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;

        //navigation
        public virtual Item Item { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}