using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace AspNetCoreWebApp.DbModels.CalculatorDbModels
{
    public partial class CalculatorContext : DbContext
    {
        public CalculatorContext()
        {
        }

        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

        // Unable to generate entity type for table 'dbo.ImportedAdData'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DropShipImportedData'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.eBayCategory'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.QSCategory'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.WaitForInsertDropShipData'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DropshipInventory'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DropShipSKUList'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SKUCategory'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RevisePriceSKU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AutoPostAdPostDataBackup'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-B2Q8INJ\\SQL2012;Initial Catalog=AutoPostAdDealSplash;User ID=sa;Password=Shishiliu-0310;MultipleActiveResultSets=True");
//                //optionsBuilder.UseMySql("server=127.0.0.1;database=AutoPostAdDealSplash;user=root;password=Shishiliu-0310");
//            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

        }
    }
}
