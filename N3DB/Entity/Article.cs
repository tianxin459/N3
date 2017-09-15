using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace N3DB.Entity
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string MimeUrl { get; set; }
        public string Mimetype { get; set; }
        //go to corresponding item
        public string LinkUrl { get; set; }
        public int? ItemId { get; set; }
        //common columns
        public DateTime CreateDate { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;

        //navigation
        [IgnoreDataMember]
        public virtual Item Item { get; set; }
    }
}
