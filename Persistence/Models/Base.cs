using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Base
    {
        ///<summary>
        /// The ID of your object with the name of the Contacts
        ///</summary>
        [Key]
        [Column("ID", TypeName = "uniqueidentifier", Order = 1)]
        public Guid ID { get; set; }

        ///<summary>
        /// A Bool with the name of the bitRecordActive
        /// Used to disable a Recipient
        ///</summary>
        [Column("IsActive", TypeName = "bit", Order = 2)]
        [Display(Name = "Is Active")]
        public Boolean? IsActive { get; set; } = true;
    }
}
