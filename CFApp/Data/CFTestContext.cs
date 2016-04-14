using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CFApp.Data
{
    public class CFTestContext : DbContext
    {
        public CFTestContext()
            : base("name=DefaultConnection")  // web config de connection ismi var 
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)  // ? 
        {
            
        }

        public DbSet<TestEntity> TestEntities { get; set; } // database ile bağlantılıyoruz
    //    public DbSet<TestEntity> TestEntity { get; set;  }
    }
}