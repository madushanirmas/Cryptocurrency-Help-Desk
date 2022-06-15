using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bitcoin.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name = MyContextDB") { }
        public virtual DbSet<Bituser> Bitusers { get; set; }

        public System.Data.Entity.DbSet<Bitcoin.Models.Event> Events { get; set; }
        public System.Data.Entity.DbSet<Bitcoin.Models.Forum> Forums { get; set; }
        public System.Data.Entity.DbSet<Bitcoin.Models.Feed> Feeds { get; set; }
    }
}