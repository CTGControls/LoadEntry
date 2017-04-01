using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;

namespace Service.Models.DB
{
    //EF6 How to us a link table 
    //http://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table
    [Table("PartCustomField")]
    public class PartCustomField : Base
    {
        ///<summary>
        /// ID of the Category this Recipient is added to
        ///</summary>
        [Key, Column("PartRefId", TypeName = "uniqueidentifier", Order = 100)]
        [ForeignKey("Part")]
        [Display(Name = "")]
        public Guid PartRefId { get; set; }
        public virtual Part Part { get; set; }

        ///<summary>
        /// ID of the AzureStorgeFiles that this recipient is connected to
        ///</summary>
        [Key, Column("CustomFieldRefId", TypeName = "uniqueidentifier", Order = 101)]
        [ForeignKey("CustomField")]
        [Display(Name = "")]
        public Guid CustomFieldRefId { get; set; }
        public virtual CustomField CustomField { get; set; }


    }
}