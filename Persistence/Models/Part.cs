using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    [Table("Part")]
    public class Part : Base
    {
        ///<summary>
        /// The name or part number of the part 
        ///</summary>
        [Column("Name", TypeName = "nvarchar", Order = 100)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public String Name { get; set; }

        public virtual IList<PartCustomField> PartCustomField { get; set; }
    }
}
