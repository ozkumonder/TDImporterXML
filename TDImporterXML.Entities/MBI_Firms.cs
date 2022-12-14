using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MBI_Firms : IEntity
    {
        [Key]
        public int FirmId { get; set; }

        public short FirmNr { get; set; }

        public bool IsDefault { get; set; }
    }
}
