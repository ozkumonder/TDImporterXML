using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MBI_BrachPairing : IEntity
    {
        [Key]
        public int BranchPairingId { get; set; }

        [StringLength(50)]
        public string RobotposBranchNr { get; set; }

        [StringLength(50)]
        public string LogoBranchNr { get; set; }
        [StringLength(150)]
        public string BranchName { get; set; }
    }
}
