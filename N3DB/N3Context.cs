using N3DB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB
{
    public class N3Context:DbContext
    {
        public N3Context() : base("name=DefaultConnection") {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<AdPicture> AdPictures { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemColor> ItemColors { get; set; }
        public DbSet<ItemImg> ItemImgs { get; set; }
        public DbSet<ItemSize> ItemSizes { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties()
                .Where(x => x.GetType() == typeof(string))
                .Configure(x => x.HasColumnType("varchar"));
        }
    }
}
