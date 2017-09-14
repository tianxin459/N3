using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class ItemColor
    {
        [Key]
        public int ItemColorId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string Color { get; set; }
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
