﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Desc { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        //common columns
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;

        //navigation
        [IgnoreDataMember]
        public virtual ICollection<ItemImg> ItemImgs { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<ItemSize> ItemSizes { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<ItemColor> ItemColors { get; set; }
        [IgnoreDataMember]
        public virtual ICollection<Storage> Storage { get; set; }
    }
}
