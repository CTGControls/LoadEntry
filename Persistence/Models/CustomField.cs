using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class CustomField : Base
    {
        ///<summary>
        /// The name of the custom Field
        ///</summary>
        [Column("Name", TypeName = "nvarchar", Order = 100)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}
