using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace AspNetCoreWebApp.DbModels.CalculatorDbModels
{
    public partial class CalculatorContext : IdentityDbContext<AspNetUsers>
    {
        public CalculatorContext()
        {
        }

        public CalculatorContext(DbContextOptions<CalculatorContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<User> User { get; set; }

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
            
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<User>().ToTable("User");
            //Use your application user class here

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasKey(t => t.Id);

            //    entity.Property(e => e.Id).HasColumnName("Id");

            //    entity.Property(e => e.UserName)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    //entity.Property(e => e.LastName)
            //    //    .IsRequired()
            //    //    .HasMaxLength(100)
            //    //    .IsUnicode(false);


            //    entity.Property(e => e.PasswordHash)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(100)
            //        .IsUnicode(false);

            //    entity.ToTable("User");
            //});

        }
    }
}
