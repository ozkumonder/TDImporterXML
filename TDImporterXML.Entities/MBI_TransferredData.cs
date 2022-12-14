using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MBI_TransferredData : IEntity
    {
        [Key]
        public int TransferId { get; set; }
        
        public int? TransFicheref { get; set; }

        public string TransData { get; set; }

        [StringLength(50)]
        public string TransBranchNumber { get; set; }

        public string TransactionDate { get; set; }

        [StringLength(50)]
        public string FicheNo { get; set; }

        public double? NetTotal { get; set; }

        public double? TotalDiscounts { get; set; }
        public string Description { get; set; }
    }
}
