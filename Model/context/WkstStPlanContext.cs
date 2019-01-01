using HtlWeiz.WkstPlaner.Model.tables;
using Microsoft.EntityFrameworkCore;

namespace HtlWeiz.WkstPlaner.Model.context
{
    public partial class WkstStPlanContext : DbContext
    {
        private readonly string _connectionString;
        public WkstStPlanContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public WkstStPlanContext(DbContextOptions<WkstStPlanContext> options, string connectionString)
            : base(options)
        {
            this._connectionString = connectionString;
        }

        public virtual DbSet<TblFahrgemeinschaften> TblFahrgemeinschaften { get; set; }
        public virtual DbSet<TblFreieTage> TblFreieTage { get; set; }
        public virtual DbSet<TblKlassen> TblKlassen { get; set; }
        public virtual DbSet<TblKlassenGruppenReihenfolge> TblKlassenGruppenReihenfolge { get; set; }
        public virtual DbSet<TblKlassenLehrfachgruppen> TblKlassenLehrfachgruppen { get; set; }
        public virtual DbSet<TblKlassenLehrfaecher> TblKlassenLehrfaecher { get; set; }
        public virtual DbSet<TblKlassenSchueler> TblKlassenSchueler { get; set; }
        public virtual DbSet<TblLehreinheiten> TblLehreinheiten { get; set; }
        public virtual DbSet<TblLehrer> TblLehrer { get; set; }
        public virtual DbSet<TblLehrfachLehrkraft> TblLehrfachLehrkraft { get; set; }
        public virtual DbSet<TblLehrfachSchuelerNoten> TblLehrfachSchuelerNoten { get; set; }
        public virtual DbSet<TblLehrfachgruppeSchuelerNoten> TblLehrfachgruppeSchuelerNoten { get; set; }
        public virtual DbSet<TblLehrfachgruppen> TblLehrfachgruppen { get; set; }
        public virtual DbSet<TblLehrfachgruppenFaecher> TblLehrfachgruppenFaecher { get; set; }
        public virtual DbSet<TblLehrfachwertigkeiten> TblLehrfachwertigkeiten { get; set; }
        public virtual DbSet<TblLehrfaecher> TblLehrfaecher { get; set; }
        public virtual DbSet<TblPersonen> TblPersonen { get; set; }
        public virtual DbSet<TblRaeume> TblRaeume { get; set; }
        public virtual DbSet<TblRaumLehrfaecher> TblRaumLehrfaecher { get; set; }
        public virtual DbSet<TblSchueler> TblSchueler { get; set; }
        public virtual DbSet<TblSchuelerAbgangszeiten> TblSchuelerAbgangszeiten { get; set; }
        public virtual DbSet<TblSchuljahre> TblSchuljahre { get; set; }
        public virtual DbSet<TblStundenDaten> TblStundenDaten { get; set; }
        public virtual DbSet<TblStundenTabellen> TblStundenTabellen { get; set; }
        public virtual DbSet<TblStundenZuordnung> TblStundenZuordnung { get; set; }
        public virtual DbSet<TblTurnusParameter> TblTurnusParameter { get; set; }
        public virtual DbSet<TblTurnusParameterWerte> TblTurnusParameterWerte { get; set; }
        public virtual DbSet<TblTurnusParameterwertezuordnungen> TblTurnusParameterwertezuordnungen { get; set; }
        public virtual DbSet<TblTurnuskonfigurationen> TblTurnuskonfigurationen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
                // "Server=HQDATABASES01\\MSSQL2016_DEV; Database=WkstStPlan;Trusted_Connection=True;MultipleActiveResultsets=True;"
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<TblFahrgemeinschaften>(entity =>
            {
                entity.ToTable("tblFahrgemeinschaften");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblFreieTage>(entity =>
            {
                entity.HasKey(e => new { e.SchuljahrId, e.Id })
                    .HasName("pkFreieTage");

                entity.ToTable("tblFreieTage");

                entity.Property(e => e.SchuljahrId).HasColumnName("schuljahrId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anfang)
                    .HasColumnName("anfang")
                    .HasColumnType("date");

                entity.Property(e => e.Bezeichnung)
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ende)
                    .HasColumnName("ende")
                    .HasColumnType("date");

                entity.HasOne(d => d.Schuljahr)
                    .WithMany(p => p.TblFreieTage)
                    .HasForeignKey(d => d.SchuljahrId)
                    .HasConstraintName("fkFreieTageSchuljahr");
            });

            modelBuilder.Entity<TblKlassen>(entity =>
            {
                entity.ToTable("tblKlassen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fachbereich)
                    .HasColumnName("fachbereich")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gruppen)
                    .HasColumnName("gruppen")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Jahrgang).HasColumnName("jahrgang");

                entity.Property(e => e.Klassenvorstand)
                    .HasColumnName("klassenvorstand")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.SchuljahrId).HasColumnName("schuljahrId");

                entity.Property(e => e.TurnusKonfigurationId).HasColumnName("turnusKonfigurationId");

                entity.Property(e => e.WkstKlassenlehrer)
                    .HasColumnName("wkstKlassenlehrer")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.KlassenvorstandNavigation)
                    .WithMany(p => p.TblKlassenKlassenvorstandNavigation)
                    .HasForeignKey(d => d.Klassenvorstand)
                    .HasConstraintName("fkKlassevorstand");

                entity.HasOne(d => d.Schuljahr)
                    .WithMany(p => p.TblKlassen)
                    .HasForeignKey(d => d.SchuljahrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkKlasseSchuljahr");

                entity.HasOne(d => d.TurnusKonfiguration)
                    .WithMany(p => p.TblKlassen)
                    .HasForeignKey(d => d.TurnusKonfigurationId)
                    .HasConstraintName("fkKlasseTurnus");

                entity.HasOne(d => d.WkstKlassenlehrerNavigation)
                    .WithMany(p => p.TblKlassenWkstKlassenlehrerNavigation)
                    .HasForeignKey(d => d.WkstKlassenlehrer)
                    .HasConstraintName("fkKlasselehrer");
            });

            modelBuilder.Entity<TblKlassenGruppenReihenfolge>(entity =>
            {
                entity.HasKey(e => new { e.KlasseId, e.Gruppe })
                    .HasName("pkKlassenGruppenReihenfolge");

                entity.ToTable("tblKlassenGruppenReihenfolge");

                entity.Property(e => e.KlasseId).HasColumnName("klasseID");

                entity.Property(e => e.Gruppe).HasColumnName("gruppe");

                entity.Property(e => e.Turnus).HasColumnName("turnus");

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.TblKlassenGruppenReihenfolge)
                    .HasForeignKey(d => d.KlasseId)
                    .HasConstraintName("fkKlassenGruppenReihenfolgeKlasse");
            });

            modelBuilder.Entity<TblKlassenLehrfachgruppen>(entity =>
            {
                entity.ToTable("tblKlassenLehrfachgruppen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KlasseId).HasColumnName("klasseId");

                entity.Property(e => e.LehrerKurzzeichen)
                    .HasColumnName("lehrerKurzzeichen")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LehrfachgrupppenId).HasColumnName("lehrfachgrupppenId");

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.TblKlassenLehrfachgruppen)
                    .HasForeignKey(d => d.KlasseId)
                    .HasConstraintName("fkKlassenLehrfaechgruppenKlasse");

                entity.HasOne(d => d.LehrerKurzzeichenNavigation)
                    .WithMany(p => p.TblKlassenLehrfachgruppen)
                    .HasForeignKey(d => d.LehrerKurzzeichen)
                    .HasConstraintName("fkKlassenLehrfachgruppeLehrer");

                entity.HasOne(d => d.Lehrfachgrupppen)
                    .WithMany(p => p.TblKlassenLehrfachgruppen)
                    .HasForeignKey(d => d.LehrfachgrupppenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkKlassenLehrfaechgruppenLehrfachgruppe");
            });

            modelBuilder.Entity<TblKlassenLehrfaecher>(entity =>
            {
                entity.ToTable("tblKlassenLehrfaecher");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KlasseId).HasColumnName("klasseId");

                entity.Property(e => e.LehreinheitId).HasColumnName("lehreinheitId");

                entity.Property(e => e.LehrerKurzzeichen)
                    .HasColumnName("lehrerKurzzeichen")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LehrfachKurzzeichen)
                    .IsRequired()
                    .HasColumnName("lehrfachKurzzeichen")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LehrfachgruppeId).HasColumnName("lehrfachgruppeId");

                entity.Property(e => e.Raumnummer)
                    .HasColumnName("raumnummer")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.KlasseId)
                    .HasConstraintName("fkKlassenLehrfaecherKlasse");

                entity.HasOne(d => d.Lehreinheit)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.LehreinheitId)
                    .HasConstraintName("fktblKlassenLehrfachEinheit");

                entity.HasOne(d => d.LehrerKurzzeichenNavigation)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.LehrerKurzzeichen)
                    .HasConstraintName("fkKlassenLehrfaecherLehrer");

                entity.HasOne(d => d.LehrfachKurzzeichenNavigation)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.LehrfachKurzzeichen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkKlassenLehrfaecherLehrfach");

                entity.HasOne(d => d.Lehrfachgruppe)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.LehrfachgruppeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkKlassenLehrfaecherGruppe");

                entity.HasOne(d => d.RaumnummerNavigation)
                    .WithMany(p => p.TblKlassenLehrfaecher)
                    .HasForeignKey(d => d.Raumnummer)
                    .HasConstraintName("fkKlassenLehrfaecherRaum");
            });

            modelBuilder.Entity<TblKlassenSchueler>(entity =>
            {
                entity.HasKey(e => new { e.KlasseId, e.Schuelerkennzahl })
                    .HasName("pkKlassenSchueler");

                entity.ToTable("tblKlassenSchueler");

                entity.Property(e => e.KlasseId).HasColumnName("klasseId");

                entity.Property(e => e.Schuelerkennzahl)
                    .HasColumnName("schuelerkennzahl")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Klasse)
                    .WithMany(p => p.TblKlassenSchueler)
                    .HasForeignKey(d => d.KlasseId)
                    .HasConstraintName("fkKlassenschuelerKlasse");

                entity.HasOne(d => d.SchuelerkennzahlNavigation)
                    .WithMany(p => p.TblKlassenSchueler)
                    .HasForeignKey(d => d.Schuelerkennzahl)
                    .HasConstraintName("fkKlassenschuelerSchueler");
            });

            modelBuilder.Entity<TblLehreinheiten>(entity =>
            {
                entity.ToTable("tblLehreinheiten");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnzahlStunden).HasColumnName("anzahlStunden");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StundeStart).HasColumnName("stundeStart");

                entity.Property(e => e.StundenTabelleId).HasColumnName("stundenTabelleId");

                entity.Property(e => e.Tag).HasColumnName("tag");

                entity.HasOne(d => d.StundenTabelle)
                    .WithMany(p => p.TblLehreinheiten)
                    .HasForeignKey(d => d.StundenTabelleId)
                    .HasConstraintName("fkLehreinheitenStundentabelle");
            });

            modelBuilder.Entity<TblLehrer>(entity =>
            {
                entity.HasKey(e => e.Kurzzeichen)
                    .HasName("pkLehrer");

                entity.ToTable("tblLehrer");

                entity.Property(e => e.Kurzzeichen)
                    .HasColumnName("kurzzeichen")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Benutzername)
                    .HasColumnName("benutzername")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FahrgemeinschaftId).HasColumnName("fahrgemeinschaftId");

                entity.Property(e => e.Farbe).HasColumnName("farbe");

                entity.Property(e => e.Ordner)
                    .HasColumnName("ordner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.HasOne(d => d.Fahrgemeinschaft)
                    .WithMany(p => p.TblLehrer)
                    .HasForeignKey(d => d.FahrgemeinschaftId)
                    .HasConstraintName("fkLehrerFahrgemeischaft");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblLehrer)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fkLehrerPerson");
            });

            modelBuilder.Entity<TblLehrfachLehrkraft>(entity =>
            {
                entity.HasKey(e => new { e.LehrfachKurzbezeichnung, e.LehrerKurzzeichen })
                    .HasName("pkLehrfachLehrkraft");

                entity.ToTable("tblLehrfachLehrkraft");

                entity.Property(e => e.LehrfachKurzbezeichnung)
                    .HasColumnName("lehrfachKurzbezeichnung")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LehrerKurzzeichen)
                    .HasColumnName("lehrerKurzzeichen")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.LehrerKurzzeichenNavigation)
                    .WithMany(p => p.TblLehrfachLehrkraft)
                    .HasForeignKey(d => d.LehrerKurzzeichen)
                    .HasConstraintName("fkLehrkraftLehrfaecherLehrerKurzzeichen");

                entity.HasOne(d => d.LehrfachKurzbezeichnungNavigation)
                    .WithMany(p => p.TblLehrfachLehrkraft)
                    .HasForeignKey(d => d.LehrfachKurzbezeichnung)
                    .HasConstraintName("fkLehrkraftLehrfaecherFach");
            });

            modelBuilder.Entity<TblLehrfachSchuelerNoten>(entity =>
            {
                entity.HasKey(e => new { e.KlassenLehrfachId, e.Schuelerkennzahl })
                    .HasName("pkLehrfachSchuelerNoten");

                entity.ToTable("tblLehrfachSchuelerNoten");

                entity.Property(e => e.KlassenLehrfachId).HasColumnName("klassenLehrfachId");

                entity.Property(e => e.Schuelerkennzahl)
                    .HasColumnName("schuelerkennzahl")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.KlassenLehrfach)
                    .WithMany(p => p.TblLehrfachSchuelerNoten)
                    .HasForeignKey(d => d.KlassenLehrfachId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLehrfachSchuelerNotenLehrfach");

                entity.HasOne(d => d.SchuelerkennzahlNavigation)
                    .WithMany(p => p.TblLehrfachSchuelerNoten)
                    .HasForeignKey(d => d.Schuelerkennzahl)
                    .HasConstraintName("fkLehrfachSchuelerNotenSchuler");
            });

            modelBuilder.Entity<TblLehrfachgruppeSchuelerNoten>(entity =>
            {
                entity.HasKey(e => new { e.KlassenLehrfachgruppeId, e.Schuelerkennzahl })
                    .HasName("pkLehrfachgruppeSchuelerNoten");

                entity.ToTable("tblLehrfachgruppeSchuelerNoten");

                entity.Property(e => e.KlassenLehrfachgruppeId).HasColumnName("KlassenLehrfachgruppeID");

                entity.Property(e => e.Schuelerkennzahl)
                    .HasColumnName("schuelerkennzahl")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.KlassenLehrfachgruppe)
                    .WithMany(p => p.TblLehrfachgruppeSchuelerNoten)
                    .HasForeignKey(d => d.KlassenLehrfachgruppeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLehrfachgruppeSchuelerNotenLehrfach");

                entity.HasOne(d => d.SchuelerkennzahlNavigation)
                    .WithMany(p => p.TblLehrfachgruppeSchuelerNoten)
                    .HasForeignKey(d => d.Schuelerkennzahl)
                    .HasConstraintName("fkLehrfachgruppeSchuelerNotenSchueler");
            });

            modelBuilder.Entity<TblLehrfachgruppen>(entity =>
            {
                entity.ToTable("tblLehrfachgruppen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLehrfachgruppenFaecher>(entity =>
            {
                entity.HasKey(e => new { e.LehrfachgrupppenId, e.LehrfachKurzzeichen })
                    .HasName("pkLehrfachgruppenFaecher");

                entity.ToTable("tblLehrfachgruppenFaecher");

                entity.Property(e => e.LehrfachgrupppenId).HasColumnName("lehrfachgrupppenId");

                entity.Property(e => e.LehrfachKurzzeichen)
                    .HasColumnName("lehrfachKurzzeichen")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.LehrfachKurzzeichenNavigation)
                    .WithMany(p => p.TblLehrfachgruppenFaecher)
                    .HasForeignKey(d => d.LehrfachKurzzeichen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLehrfaechgruppenFaecherLehrfach");

                entity.HasOne(d => d.Lehrfachgrupppen)
                    .WithMany(p => p.TblLehrfachgruppenFaecher)
                    .HasForeignKey(d => d.LehrfachgrupppenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLehrfaechgruppenFaecherLehrfachgruppe");
            });

            modelBuilder.Entity<TblLehrfachwertigkeiten>(entity =>
            {
                entity.ToTable("tblLehrfachwertigkeiten");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Werteinheit).HasColumnName("werteinheit");
            });

            modelBuilder.Entity<TblLehrfaecher>(entity =>
            {
                entity.HasKey(e => e.Kurzbezeichnung)
                    .HasName("pkLehrfach");

                entity.ToTable("tblLehrfaecher");

                entity.Property(e => e.Kurzbezeichnung)
                    .HasColumnName("kurzbezeichnung")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Farbe).HasColumnName("farbe");

                entity.Property(e => e.Inhalt)
                    .HasColumnName("inhalt")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Kompetenzen)
                    .HasColumnName("kompetenzen")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Langbezeichnung)
                    .HasColumnName("langbezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WertigkeitId).HasColumnName("wertigkeitId");

                entity.HasOne(d => d.Wertigkeit)
                    .WithMany(p => p.TblLehrfaecher)
                    .HasForeignKey(d => d.WertigkeitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkLehrfachWertigkeitenId");
            });

            modelBuilder.Entity<TblPersonen>(entity =>
            {
                entity.ToTable("tblPersonen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Geschlecht)
                    .HasColumnName("geschlecht")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasColumnName("nachname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .HasColumnName("vorname")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRaeume>(entity =>
            {
                entity.HasKey(e => e.Raumnummer)
                    .HasName("pkRaume");

                entity.ToTable("tblRaeume");

                entity.Property(e => e.Raumnummer)
                    .HasColumnName("raumnummer")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BezeichnungKurz)
                    .IsRequired()
                    .HasColumnName("bezeichnungKurz")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BezeichnungLang)
                    .HasColumnName("bezeichnungLang")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Kustos1)
                    .HasColumnName("kustos1")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Kustos2)
                    .HasColumnName("kustos2")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kustos1Navigation)
                    .WithMany(p => p.TblRaeumeKustos1Navigation)
                    .HasForeignKey(d => d.Kustos1)
                    .HasConstraintName("fkRaumKustos1");

                entity.HasOne(d => d.Kustos2Navigation)
                    .WithMany(p => p.TblRaeumeKustos2Navigation)
                    .HasForeignKey(d => d.Kustos2)
                    .HasConstraintName("fkRaumKustos2");
            });

            modelBuilder.Entity<TblRaumLehrfaecher>(entity =>
            {
                entity.HasKey(e => new { e.Raumnummer, e.LehrfachKurzbezeichnung })
                    .HasName("pkRaumLehrfaecher");

                entity.ToTable("tblRaumLehrfaecher");

                entity.Property(e => e.Raumnummer)
                    .HasColumnName("raumnummer")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LehrfachKurzbezeichnung)
                    .HasColumnName("lehrfachKurzbezeichnung")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.LehrfachKurzbezeichnungNavigation)
                    .WithMany(p => p.TblRaumLehrfaecher)
                    .HasForeignKey(d => d.LehrfachKurzbezeichnung)
                    .HasConstraintName("fkLehrfachKurzbezeichnung");

                entity.HasOne(d => d.RaumnummerNavigation)
                    .WithMany(p => p.TblRaumLehrfaecher)
                    .HasForeignKey(d => d.Raumnummer)
                    .HasConstraintName("fkRaumLehrfaecherRaumnummer");
            });

            modelBuilder.Entity<TblSchueler>(entity =>
            {
                entity.HasKey(e => e.Kennzahl)
                    .HasName("pkSchueler");

                entity.ToTable("tblSchueler");

                entity.Property(e => e.Kennzahl)
                    .HasColumnName("kennzahl")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AbgangszeitId).HasColumnName("abgangszeitId");

                entity.Property(e => e.PersonId).HasColumnName("personId");

                entity.HasOne(d => d.Abgangszeit)
                    .WithMany(p => p.TblSchueler)
                    .HasForeignKey(d => d.AbgangszeitId)
                    .HasConstraintName("fkSchuelerAbgangszeit");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblSchueler)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fkSchuelerPerson");
            });

            modelBuilder.Entity<TblSchuelerAbgangszeiten>(entity =>
            {
                entity.ToTable("tblSchuelerAbgangszeiten");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSchuljahre>(entity =>
            {
                entity.ToTable("tblSchuljahre");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ende)
                    .HasColumnName("ende")
                    .HasColumnType("date");

                entity.Property(e => e.EndeMatura)
                    .HasColumnName("endeMatura")
                    .HasColumnType("date");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("date");

                entity.Property(e => e.StartFachschule)
                    .HasColumnName("startFachschule")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<TblStundenDaten>(entity =>
            {
                entity.ToTable("tblStundenDaten");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dauer).HasColumnName("dauer");

                entity.Property(e => e.Start).HasColumnName("start");
            });

            modelBuilder.Entity<TblStundenTabellen>(entity =>
            {
                entity.ToTable("tblStundenTabellen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStundenZuordnung>(entity =>
            {
                entity.HasKey(e => new { e.StundentabelleId, e.StundenDatenId })
                    .HasName("pkTblStundenZurordnung");

                entity.ToTable("tblStundenZuordnung");

                entity.HasOne(d => d.StundenDaten)
                    .WithMany(p => p.TblStundenZuordnung)
                    .HasForeignKey(d => d.StundenDatenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkStundenZuordnungDaten");

                entity.HasOne(d => d.Stundentabelle)
                    .WithMany(p => p.TblStundenZuordnung)
                    .HasForeignKey(d => d.StundentabelleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkStundenZuordnungTabelle");
            });

            modelBuilder.Entity<TblTurnusParameter>(entity =>
            {
                entity.ToTable("tblTurnusParameter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTurnusParameterWerte>(entity =>
            {
                entity.ToTable("tblTurnusParameterWerte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Wert)
                    .IsRequired()
                    .HasColumnName("wert")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTurnusParameterwertezuordnungen>(entity =>
            {
                entity.HasKey(e => new { e.TurnuskonfigurationId, e.TurnusparameterId, e.WertId })
                    .HasName("pkTurnusParameterwertezuordnungen");

                entity.ToTable("tblTurnusParameterwertezuordnungen");

                entity.Property(e => e.TurnuskonfigurationId).HasColumnName("turnuskonfigurationId");

                entity.Property(e => e.TurnusparameterId).HasColumnName("turnusparameterId");

                entity.Property(e => e.WertId).HasColumnName("wertId");

                entity.HasOne(d => d.Turnuskonfiguration)
                    .WithMany(p => p.TblTurnusParameterwertezuordnungen)
                    .HasForeignKey(d => d.TurnuskonfigurationId)
                    .HasConstraintName("fkTurnusParameterwertezuordnungenTurnusId");

                entity.HasOne(d => d.Turnusparameter)
                    .WithMany(p => p.TblTurnusParameterwertezuordnungen)
                    .HasForeignKey(d => d.TurnusparameterId)
                    .HasConstraintName("fkTurnusParameterwertezuordnungenParameterId");

                entity.HasOne(d => d.Wert)
                    .WithMany(p => p.TblTurnusParameterwertezuordnungen)
                    .HasForeignKey(d => d.WertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkfkTurnusParameterwertezuordnungenWertId");
            });

            modelBuilder.Entity<TblTurnuskonfigurationen>(entity =>
            {
                entity.ToTable("tblTurnuskonfigurationen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BerechnungsFunktion)
                    .HasColumnName("berechnungsFunktion")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bezeichnung)
                    .HasColumnName("bezeichnung")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
