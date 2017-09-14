using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        public int? ItemSizeId { get; set; }
        public int? ItemColorId { get; set; }
        public int Number { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;

        //navigate
        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
        public virtual ItemSize ItemSize { get; set; }
        public virtual ItemColor ItemColor { get; set; }
    }
}
