using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.DB
{
    [Table("Part")]
    public class Part : Base
    {
        ///<summary>
        /// User IP Address of the user who created the record 
        ///</summary>
        [Column("Name", TypeName = "nvarchar", Order = 100)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public String Name { get; set; }

        public virtual List<CustomField> CustomFields { get; set; }

        //public static explicit operator Part(Persistence.Part v)
        //{
        //    ID = v.ID;
        //    return (PartCustomField)v;
        //    //throw new NotImplementedException();
        //}
    }
}
