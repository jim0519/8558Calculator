using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace AspNetCoreWebApp.DbModels
{
    public partial class AutoPostAdDealSplashContext : DbContext
    {
        public AutoPostAdDealSplashContext()
        {
        }

        public AutoPostAdDealSplashContext(DbContextOptions<AutoPostAdDealSplashContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<AutoPostAdHeader> AutoPostAdHeader { get; set; }
        public virtual DbSet<AutoPostAdLine> AutoPostAdLine { get; set; }
        public virtual DbSet<AutoPostAdPostData> AutoPostAdPostData { get; set; }
        public virtual DbSet<AutoPostAdResult> AutoPostAdResult { get; set; }
        public virtual DbSet<CustomFieldGroup> CustomFieldGroup { get; set; }
        public virtual DbSet<CustomFieldLine> CustomFieldLine { get; set; }
        public virtual DbSet<DataField> DataField { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ScheduleRule> ScheduleRule { get; set; }
        public virtual DbSet<ScheduleRuleLine> ScheduleRuleLine { get; set; }
        public virtual DbSet<ScheduleTask> ScheduleTask { get; set; }
        public virtual DbSet<Skumapping> Skumapping { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TemplateField> TemplateField { get; set; }

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
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cookie)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Gateway)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Netmask)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeoLatitude)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GeoLongitude)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AutoPostAdHeader>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AutoPostAdLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasColumnName("ExternalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderId).HasColumnName("HeaderID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Header)
                    .WithMany(p => p.AutoPostAdLine)
                    .HasForeignKey(d => d.HeaderId)
                    .HasConstraintName("FK_AutoPostAdLine_AutoPostAdHeader");
            });

            modelBuilder.Entity<AutoPostAdPostData>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AdTypeId).HasColumnName("AdTypeID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BusinessLogoPath)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CustomFieldGroupId).HasColumnName("CustomFieldGroupID");

                entity.Property(e => e.CustomId)
                    .IsRequired()
                    .HasColumnName("CustomID")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ImagesPath)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleRuleId).HasColumnName("ScheduleRuleID");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AutoPostAdPostData)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoPostAdPostData_Account");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AutoPostAdPostData)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoPostAdPostData_Address");

                entity.HasOne(d => d.CustomFieldGroup)
                    .WithMany(p => p.AutoPostAdPostData)
                    .HasForeignKey(d => d.CustomFieldGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoPostAdPostData_CustomFieldGroup");

                entity.HasOne(d => d.ScheduleRule)
                    .WithMany(p => p.AutoPostAdPostData)
                    .HasForeignKey(d => d.ScheduleRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AutoPostAdPostData_ScheduleRule");
            });

            modelBuilder.Entity<AutoPostAdResult>(entity =>
            {
                entity.HasIndex(e => e.AutoPostAdDataId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdId)
                    .IsRequired()
                    .HasColumnName("AdID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AutoPostAdDataId).HasColumnName("AutoPostAdDataID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.HasOne(d => d.AutoPostAdData)
                    .WithMany(p => p.AutoPostAdResult)
                    .HasForeignKey(d => d.AutoPostAdDataId)
                    .HasConstraintName("FK_AutoPostAdResult_AutoPostAdPostData");
            });

            modelBuilder.Entity<CustomFieldGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomFieldLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomFieldGroupId).HasColumnName("CustomFieldGroupID");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomFieldGroup)
                    .WithMany(p => p.CustomFieldLine)
                    .HasForeignKey(d => d.CustomFieldGroupId)
                    .HasConstraintName("FK_CustomFieldLine_CustomFieldGroup");
            });

            modelBuilder.Entity<DataField>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataFieldName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.ParentCategoryId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("CategoryID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");

                entity.Property(e => e.ParentCategoryId)
                    .IsRequired()
                    .HasColumnName("ParentCategoryID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Template");
            });

            modelBuilder.Entity<ScheduleRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.LastSuccessTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduleRuleLine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EditBy)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.Property(e => e.ScheduleRuleId).HasColumnName("ScheduleRuleID");

                entity.Property(e => e.TimeRangeFrom).HasColumnType("datetime");

                entity.Property(e => e.TimeRangeTo).HasColumnType("datetime");

                entity.HasOne(d => d.ScheduleRule)
                    .WithMany(p => p.ScheduleRuleLine)
                    .HasForeignKey(d => d.ScheduleRuleId)
                    .HasConstraintName("FK_ScheduleRuleLine_ScheduleRule");
            });

            modelBuilder.Entity<ScheduleTask>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastEndTime).HasColumnType("datetime");

                entity.Property(e => e.LastStartTime).HasColumnType("datetime");

                entity.Property(e => e.LastSuccessTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<Skumapping>(entity =>
            {
                entity.ToTable("SKUMapping");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NewSku)
                    .HasColumnName("NewSKU")
                    .HasMaxLength(500);

                entity.Property(e => e.OldSku)
                    .HasColumnName("OldSKU")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TemplateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemplateField>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataFieldId).HasColumnName("DataFieldID");

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateFieldName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TemplateId).HasColumnName("TemplateID");

                entity.HasOne(d => d.DataField)
                    .WithMany(p => p.TemplateField)
                    .HasForeignKey(d => d.DataFieldId)
                    .HasConstraintName("FK_TemplateField_DataField");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateField)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("FK_TemplateField_Template");
            });
        }
    }
}
