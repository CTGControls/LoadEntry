using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public ApplicationDbContext()
            : base("Data Source=.;Initial Catalog=LoadEnrtyTest;User ID=ssiUser;Password=ssississi;")
            {
            }

        public virtual System.Data.Entity.DbSet<Part> Parts { get; set; }
        public virtual System.Data.Entity.DbSet<CustomField> CustomField { get; set; }
        public virtual System.Data.Entity.DbSet<PartCustomField> PartCustomField { get; set; }
    }

}
