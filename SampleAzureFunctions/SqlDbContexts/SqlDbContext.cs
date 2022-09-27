using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SampleAzureFunctions.Models.Entities;

namespace SampleAzureFunctions.SqlDbContexts
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MGazo> MGazos { get; set; }
        public virtual DbSet<MGazoSite> MGazoSites { get; set; }
        public virtual DbSet<MHanyo> MHanyos { get; set; }
        public virtual DbSet<MHelpText> MHelpTexts { get; set; }
        public virtual DbSet<MHissuGazoKanri> MHissuGazoKanris { get; set; }
        public virtual DbSet<MKizu> MKizus { get; set; }
        public virtual DbSet<MPart> MParts { get; set; }
        public virtual DbSet<MPartsKizu> MPartsKizus { get; set; }
        public virtual DbSet<TCustomerSign> TCustomerSigns { get; set; }
        public virtual DbSet<TEventLog> TEventLogs { get; set; }
        public virtual DbSet<TGazo> TGazos { get; set; }
        public virtual DbSet<TKizu> TKizus { get; set; }
        public virtual DbSet<TKizuGazo> TKizuGazos { get; set; }
        public virtual DbSet<TLoginLog> TLoginLogs { get; set; }
        public virtual DbSet<TTenkaizu> TTenkaizus { get; set; }
        public virtual DbSet<TYuso> TYusos { get; set; }
        public virtual DbSet<TYusoDetail> TYusoDetails { get; set; }
        public virtual DbSet<TYusoRireki> TYusoRirekis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MGazo>(entity =>
            {
                entity.HasKey(e => new { e.GazoCategory, e.GazoType });

                entity.ToTable("m_gazo");

                entity.Property(e => e.GazoCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_category")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoCategoryName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("gazo_category_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoTypeName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("gazo_type_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MGazoSite>(entity =>
            {
                entity.HasKey(e => e.GazoCategory);

                entity.ToTable("m_gazo_site");

                entity.Property(e => e.GazoCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_category")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(0)
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Domain)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("domain")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.RerativePath)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("rerative_path")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(0)
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MHanyo>(entity =>
            {
                entity.HasKey(e => new { e.HanyoCategory, e.HanyoType });

                entity.ToTable("m_hanyo");

                entity.Property(e => e.HanyoCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("hanyo_category")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HanyoType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("hanyo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HanyoCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hanyo_category_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HanyoTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hanyo_type_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HanyoTypeValue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("hanyo_type_value")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MHelpText>(entity =>
            {
                entity.HasKey(e => new { e.Category1st, e.Category2nd, e.Category3rd });

                entity.ToTable("m_help_text");

                entity.Property(e => e.Category1st)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("category_1st")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Category2nd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("category_2nd")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Category3rd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("category_3rd")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HelpText)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("help_text")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MHissuGazoKanri>(entity =>
            {
                entity.HasKey(e => new { e.SagyoType, e.GazoCategory, e.GazoType });

                entity.ToTable("m_hissu_gazo_kanri");

                entity.Property(e => e.SagyoType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sagyo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_category")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasPrecision(0)
                    .HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.IsRequired)
                    .HasColumnName("is_required")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdateDate)
                    .HasPrecision(0)
                    .HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MKizu>(entity =>
            {
                entity.HasKey(e => e.KizuCode);

                entity.ToTable("m_kizu");

                entity.Property(e => e.KizuCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("kizu_code")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HasPosition)
                    .HasColumnName("has_position")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.KizuName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kizu_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MPart>(entity =>
            {
                entity.HasKey(e => new { e.TenkaizuType, e.PartsNo });

                entity.ToTable("m_parts");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.PartsNo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("parts_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.PartsName)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("parts_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TenkaizuTypeName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<MPartsKizu>(entity =>
            {
                entity.HasKey(e => new { e.TenkaizuType, e.PartsNo, e.KyoyoKizuCode });

                entity.ToTable("m_parts_kizu");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.PartsNo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("parts_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.KyoyoKizuCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("kyoyo_kizu_code")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TCustomerSign>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.SignType });

                entity.ToTable("t_customer_sign");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SignType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sign_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HasKyodaku1)
                    .HasColumnName("has_kyodaku_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasKyodaku2)
                    .HasColumnName("has_kyodaku_2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.SignDate).HasColumnName("sign_date");

                entity.Property(e => e.SignGazoFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sign_gazo_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TEventLog>(entity =>
            {
                entity.ToTable("t_event_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.JuchuNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.LogText)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("log_text")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TGazo>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.GazoCategory, e.GazoType });

                entity.ToTable("t_gazo");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoCategory)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_category")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("gazo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gazo_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TKizu>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.TenkaizuType, e.PartsNo, e.KizuCode });

                entity.ToTable("t_kizu");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.PartsNo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("parts_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.KizuCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("kizu_code")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.XZahyo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("x_zahyo");

                entity.Property(e => e.YZahyo)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("y_zahyo");

                entity.Property(e => e.YusoNo).HasColumnName("yuso_no");
            });

            modelBuilder.Entity<TKizuGazo>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.TenkaizuType, e.PartsNo, e.GazoNo });

                entity.ToTable("t_kizu_gazo");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.PartsNo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("parts_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.GazoNo).HasColumnName("gazo_no");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.EditGazoFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("edit_gazo_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.OriginalGazoFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("original_gazo_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.YusoNo).HasColumnName("yuso_no");
            });

            modelBuilder.Entity<TLoginLog>(entity =>
            {
                entity.ToTable("t_login_log");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("login_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TTenkaizu>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.YusoNo });

                entity.ToTable("t_tenkaizu");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.YusoNo).HasColumnName("yuso_no");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.TenkaizuFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TYuso>(entity =>
            {
                entity.HasKey(e => e.JuchuNo);

                entity.ToTable("t_yuso");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CarName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("car_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CarType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("car_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.ChassisNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("chassis_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Color)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("color")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CurrentYusoNo).HasColumnName("current_yuso_no");

                entity.Property(e => e.HasChukei)
                    .HasColumnName("has_chukei")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasJibaiseki)
                    .HasColumnName("has_jibaiseki")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasKanban)
                    .HasColumnName("has_kanban")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasShakensho)
                    .HasColumnName("has_shakensho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HikitoriDateFrom).HasColumnName("hikitori_date_from");

                entity.Property(e => e.HikitoriDateTo).HasColumnName("hikitori_date_to");

                entity.Property(e => e.HikitoriKojintakuType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("hikitori_kojintaku_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitoriTenkaizuFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hikitori_tenkaizu_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiAddress)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_address")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiBukaeiName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_bukaei_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiPrefecture)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_prefecture")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.MeigiHenkoType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("meigi_henko_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Mileage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("mileage");

                entity.Property(e => e.MycarUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mycar_user")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshaDateFrom).HasColumnName("nosha_date_from");

                entity.Property(e => e.NoshaDateTo).HasColumnName("nosha_date_to");

                entity.Property(e => e.NoshaKojintakuType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nosha_kojintaku_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiAddress)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_address")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiBukaeiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_bukaei_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiPrefecture)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_prefecture")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SagyoType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sagyo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SaishinTenkaizuFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("saishin_tenkaizu_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SeikyuNikubunMei)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("seikyu_nikubun_mei")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TorokuNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("toroku_no")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TYusoDetail>(entity =>
            {
                entity.HasKey(e => new { e.JuchuNo, e.YusoNo });

                entity.ToTable("t_yuso_detail");

                entity.Property(e => e.JuchuNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.YusoNo).HasColumnName("yuso_no");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.YusoStartDate).HasColumnName("yuso_start_date");

                entity.Property(e => e.YusoTantoshaId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("yuso_tantosha_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            modelBuilder.Entity<TYusoRireki>(entity =>
            {
                entity.HasKey(e => e.RirekiId);

                entity.ToTable("t_yuso_rireki");

                entity.Property(e => e.RirekiId).HasColumnName("rireki_id");

                entity.Property(e => e.CarName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("car_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CarType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("car_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.ChassisNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("chassis_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Color)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("color")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnName("create_date");

                entity.Property(e => e.CreatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("create_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("create_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.CurrentYusoNo).HasColumnName("current_yuso_no");

                entity.Property(e => e.HasChukei)
                    .HasColumnName("has_chukei")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasJibaiseki)
                    .HasColumnName("has_jibaiseki")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasKanban)
                    .HasColumnName("has_kanban")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HasShakensho)
                    .HasColumnName("has_shakensho")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HikitoriDateFrom).HasColumnName("hikitori_date_from");

                entity.Property(e => e.HikitoriDateTo).HasColumnName("hikitori_date_to");

                entity.Property(e => e.HikitoriKojintakuType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("hikitori_kojintaku_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitoriTenkaizuFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("hikitori_tenkaizu_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiAddress)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_address")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiBukaeiName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_bukaei_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.HikitorisakiPrefecture)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hikitorisaki_prefecture")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.IsDelete).HasColumnName("is_delete");

                entity.Property(e => e.JuchuNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("juchu_no")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.MeigiHenkoType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("meigi_henko_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Mileage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("mileage");

                entity.Property(e => e.MycarUser)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mycar_user")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshaDateFrom).HasColumnName("nosha_date_from");

                entity.Property(e => e.NoshaDateTo).HasColumnName("nosha_date_to");

                entity.Property(e => e.NoshaKojintakuType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("nosha_kojintaku_type")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiAddress)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_address")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiBukaeiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_bukaei_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.NoshasakiPrefecture)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("noshasaki_prefecture")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.RirekiTorokuDate).HasColumnName("rireki_toroku_date");

                entity.Property(e => e.SagyoType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sagyo_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SaishinTenkaizuFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("saishin_tenkaizu_file_name")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.SeikyuNikubunMei)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("seikyu_nikubun_mei")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TenkaizuType)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tenkaizu_type")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.TorokuNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("toroku_no")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnName("update_date");

                entity.Property(e => e.UpdatePg)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("update_pg")
                    .UseCollation("Japanese_CI_AS");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("update_user_id")
                    .IsFixedLength()
                    .UseCollation("Japanese_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
