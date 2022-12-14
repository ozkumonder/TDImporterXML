using System.Data.Entity;

namespace TDImporterXML.Entities
{
    public class TDImporterXMLContext : DbContext
    {
        public TDImporterXMLContext()
            : base("name=TDImporterXMLContext")
        {
        }

        public virtual DbSet<MBI_BrachPairing> MBI_BrachPairing { get; set; }
        public virtual DbSet<MBI_DocumentType> MBI_DocumentType { get; set; }
        public virtual DbSet<MBI_Firms> MBI_Firms { get; set; }
        public virtual DbSet<MBI_TransferredData> MBI_TransferredData { get; set; }
        public virtual DbSet<MBI_UnTransferredData> MBI_UnTransferred { get; set; }
        public virtual DbSet<MBI_Users> MBI_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TDImporterXMLContext>(new NullDatabaseInitializer<TDImporterXMLContext>());
        }
    }
}