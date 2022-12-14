using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MBI_UnTransferredData : IEntity
    {
        [Key]
        public int UnTransDataId { get; set; }

        public int? DataTypeId { get; set; }
        public string DataTypeName { get; set; }

        public string UnTransDate { get; set; }

        [StringLength(50)]
        public string UnTransBranchNumber { get; set; }

        [StringLength(50)]
        public string UnTransError { get; set; }
    }
}
