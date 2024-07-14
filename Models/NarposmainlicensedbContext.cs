using Microsoft.EntityFrameworkCore;

namespace LicenseManagement.Models;

public partial class NarposmainlicensedbContext : DbContext
{

    readonly IConfiguration _configuration;
    public NarposmainlicensedbContext()
    {
    }

    public NarposmainlicensedbContext(DbContextOptions<NarposmainlicensedbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Bilgisayar> Bilgisayars { get; set; }

    public virtual DbSet<Il> Ils { get; set; }

    public virtual DbSet<Ilce> Ilces { get; set; }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<LicenceKeyList> LicenceKeyLists { get; set; }

    public virtual DbSet<LisansIstek> LisansIsteks { get; set; }

    public virtual DbSet<LisansMail> LisansMails { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Musteri> Musteris { get; set; }

    public virtual DbSet<VergiDairesi> VergiDaireses { get; set; }

    public virtual DbSet<VersionInfo> VersionInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration["connectionString"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bilgisayar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bilgisay__3214EC07D2A400DF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DemoLisansBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.Isim).HasMaxLength(250);
            entity.Property(e => e.LisansBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.LisansTarihi).HasColumnType("datetime");
            entity.Property(e => e.MakinaCpuId).HasMaxLength(250);
            entity.Property(e => e.MakinaPcadi)
                .HasMaxLength(250)
                .HasColumnName("MakinaPCAdi");
            entity.Property(e => e.Pckey)
                .HasMaxLength(500)
                .HasColumnName("PCKey");
        });

        modelBuilder.Entity<Il>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Adi).HasMaxLength(250);
            entity.Property(e => e.PlakaKod).HasColumnName("Plaka_Kod");
            entity.Property(e => e.SiralamaNo).HasColumnName("Siralama_No");
            entity.Property(e => e.TelefonKod).HasColumnName("Telefon_Kod");
        });

        modelBuilder.Entity<Ilce>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Adi).HasMaxLength(250);
            entity.Property(e => e.IlceKodu).HasColumnName("Ilce_Kodu");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Eposta)
                .HasMaxLength(250)
                .HasColumnName("eposta");
            entity.Property(e => e.Isim)
                .HasMaxLength(250)
                .HasColumnName("isim");
            entity.Property(e => e.KullaniciAdi)
                .HasMaxLength(250)
                .HasColumnName("kullaniciAdi");
            entity.Property(e => e.Sifre)
                .HasMaxLength(250)
                .HasColumnName("sifre");
        });

        modelBuilder.Entity<LicenceKeyList>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ChangeDate).HasColumnType("datetime");
            entity.Property(e => e.LicenceKey).HasMaxLength(250);
        });

        modelBuilder.Entity<LisansIstek>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IstekTarihi).HasColumnType("datetime");
            entity.Property(e => e.LisansAlinmaTarihi).HasColumnType("datetime");
            entity.Property(e => e.LisansBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.MakinaKullaniciAdi).HasMaxLength(250);
            entity.Property(e => e.MakinaKullaniciPckey)
                .HasMaxLength(250)
                .HasColumnName("MakinaKullaniciPCKey");
            entity.Property(e => e.OnaylamaTarihi).HasColumnType("datetime");
        });

        modelBuilder.Entity<LisansMail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Tarih).HasColumnType("datetime");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Hostip).HasMaxLength(250);
            entity.Property(e => e.Tarih).HasColumnType("datetime");
        });

        modelBuilder.Entity<Musteri>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
            entity.Property(e => e.LisansBitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.MusteriAdi).HasMaxLength(250);
            entity.Property(e => e.MusteriAdres).HasMaxLength(500);
            entity.Property(e => e.MusteriOzel).HasMaxLength(500);
            entity.Property(e => e.MusteriTelefon).HasMaxLength(250);
            entity.Property(e => e.MusteriVergiNo).HasMaxLength(250);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.YetkiliAdi).HasMaxLength(250);
            entity.Property(e => e.YetkiliTelefon).HasMaxLength(250);
        });

        modelBuilder.Entity<VergiDairesi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VergiDairesis");

            entity.Property(e => e.Adi).HasMaxLength(500);
            entity.Property(e => e.Kodu).HasMaxLength(250);
        });

        modelBuilder.Entity<VersionInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VersionInfo");

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
