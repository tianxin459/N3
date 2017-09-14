using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class AdPicture
    {
        [Key]
        public int AdPictureId { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Url { get; set; }
        public string link { get; set; }
        public string type { get; set; }
        //common columns
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
    }
}
