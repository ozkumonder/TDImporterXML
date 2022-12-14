using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

  
    public partial class MBI_DocumentType : IEntity
    {
        [Key]
        public int DocumentTypeId { get; set; }

        public int DataTypeId { get; set; }

        [StringLength(75)]
        public string DataTypeName { get; set; }
        [StringLength(50)]
        public string XmlTag { get; set; }

        public bool IsActive { get; set; }
    }
}
