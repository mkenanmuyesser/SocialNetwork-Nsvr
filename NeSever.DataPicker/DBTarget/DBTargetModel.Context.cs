//Important note : Being a running and alive project, some codes were removed by me. If you want some detail, please just inform me

namespace DataPickerProject.DBTarget
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBTargetEntities : DbContext
    {
        public DBTargetEntities()
            : base("name=DBTargetEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Nitelik> Nitelik { get; set; }
        public virtual DbSet<UrunKategori> UrunKategori { get; set; }
        public virtual DbSet<UrunNitelik> UrunNitelik { get; set; }
        public virtual DbSet<UrunResim> UrunResim { get; set; }

    }
}
