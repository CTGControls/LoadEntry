using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.DB
{
    public class CustomField : Base
    {
        ///<summary>
        /// User IP Address of the user who created the record 
        ///</summary>
        [Column("Name", TypeName = "nvarchar", Order = 100)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public String Name { get; set; }
    }
}
