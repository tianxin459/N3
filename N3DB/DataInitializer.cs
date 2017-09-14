﻿using N3DB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DB
{
    public static class N3DataInitializer{
        public static List<Article> articles { get; set;} = new List<Article>();
        public static void Seed(N3Context context)
        {
            #region Users
            var users = new List<User>() {
                new User() { UserName="ellis2", Password="123"},
                new User() { UserName="william",Password="123"}
            };
            users.ForEach(x => context.Users.Add(x));
            #endregion


            #region Items
            var items = new List<Item>() {
                new Item() { Title="item1", Desc="desc1"},
                new Item() { Title="item2", Desc="desc2"}
            };
            items.ForEach(x => context.Items.Add(x));


            var itemColors = new List<ItemColor>() {
                new ItemColor() { Color="Red", Desc="desc1", Item = items[0]},
                new ItemColor() { Color="White", Desc="desc2", Item = items[0]}
            };
            itemColors.ForEach(x => context.ItemColors.Add(x));
            #endregion


            #region Articles
            articles.ForEach(x => context.Articles.Add(x));
            #endregion


            context.SaveChanges();
        }
    }

    public class DataInitializer : DropCreateDatabaseIfModelChanges<N3Context>
    {
        protected override void Seed(N3Context context)
        {
            N3DataInitializer.Seed(context);

            base.Seed(context);
        }
    }

    public class DataInitializerForce : DropCreateDatabaseAlways<N3Context>
    {
        protected override void Seed(N3Context context)
        {
            N3DataInitializer.Seed(context);
            base.Seed(context);
        }
    }
}
