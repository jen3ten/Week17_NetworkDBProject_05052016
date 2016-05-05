using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Week17_NetworkDBProject_05052016.Models
{
    public class Week17_NetworkDBProject_05052016Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Week17_NetworkDBProject_05052016Context() : base("name=Week17_NetworkDBProject_05052016Context")
        {
        }

        public System.Data.Entity.DbSet<Week17_NetworkDBProject_05052016.Models.Network> Networks { get; set; }

        public System.Data.Entity.DbSet<Week17_NetworkDBProject_05052016.Models.Show> Shows { get; set; }
    }
}
