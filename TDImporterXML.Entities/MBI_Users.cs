using TDImporterXML.Core.Entities;

namespace TDImporterXML.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MBI_Users : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(10)]
        public string RobotposSecurityKey { get; set; }

        [StringLength(50)]
        public string LogoUserName { get; set; }

        [StringLength(50)]
        public string LogoPassword { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
    }
}
