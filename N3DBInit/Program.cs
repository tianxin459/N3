using N3DB;
using N3DB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3DBInit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data initializing");
#if DEBUG
            Database.SetInitializer(new DataInitializerForce());
#else
            Database.SetInitializer(new DataInitializer());
#endif

            var al = new List<Item>();
            using (var ctx = new N3Context())
            {
                al = ctx.Items.ToList();
                al.ForEach(x => x.ItemColors.ToList().ForEach(c => Console.WriteLine(c.Color)));
            }
            Console.WriteLine("Data initializing completed...");
            Console.ReadLine();
        }
    }
}
