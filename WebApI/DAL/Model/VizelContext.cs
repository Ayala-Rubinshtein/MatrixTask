using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Model
{
    public partial class VizelContext : DbContext
    {
        public VizelContext()
        {
        }

        public VizelContext(DbContextOptions<VizelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AnswerOfStudent> AnswerOfStudents { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Magid> Magids { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestOfStudent> TestOfStudents { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<_11> _11s { get; set; }
        public virtual DbSet<גיליון1> גיליון1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ravcevel.database.windows.net;Database=Vizel;persist security info=True;user id=voicesystem;password=Sari-30020010;multipleactiveresultsets=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Idadress);

                entity.ToTable("Address");

                entity.Property(e => e.Idadress).HasColumnName("IDAdress");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Address_City");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK_Address_Street");
            });

            modelBuilder.Entity<AnswerOfStudent>(entity =>
            {
                entity.HasKey(e => e.IdanswerOfStudent);

                entity.ToTable("AnswerOfStudent");

                entity.Property(e => e.IdanswerOfStudent).HasColumnName("IDAnswerOfStudent");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.Idquestion).HasColumnName("IDQuestion");

                entity.Property(e => e.IdtestOfStudent).HasColumnName("IDTestOfStudent");

                entity.HasOne(d => d.IdquestionNavigation)
                    .WithMany(p => p.AnswerOfStudents)
                    .HasForeignKey(d => d.Idquestion)
                    .HasConstraintName("FK_AnswerOfStudent_Question");

                entity.HasOne(d => d.IdtestOfStudentNavigation)
                    .WithMany(p => p.AnswerOfStudents)
                    .HasForeignKey(d => d.IdtestOfStudent)
                    .HasConstraintName("FK_AnswerOfStudent_TestOfStudent");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Idcity);

                entity.ToTable("City");

                entity.Property(e => e.Idcity).HasColumnName("IDCity");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient);

                entity.ToTable("Client");

                entity.Property(e => e.Idclient).HasColumnName("IDClient");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.ContactMail).HasMaxLength(50);

                entity.Property(e => e.ContactTel).HasMaxLength(50);

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.IdcontactAdress).HasColumnName("IDContactAdress");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.HasOne(d => d.IdaddressNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.Idaddress)
                    .HasConstraintName("FK_Client_Address");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.HasKey(e => e.Idlesson);

                entity.ToTable("Lesson");

                entity.Property(e => e.Idlesson).HasColumnName("IDLesson");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.Idmagid).HasColumnName("IDMagid");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Idmag)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.Idmagid)
                    .HasConstraintName("FK_Lesson_Magid");

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK_Lesson_School");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.Idlevel);

                entity.ToTable("Level");

                entity.Property(e => e.Idlevel).HasColumnName("IDLevel");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Magid>(entity =>
            {
                entity.HasKey(e => e.Idmagid);

                entity.ToTable("Magid");

                entity.Property(e => e.Idmagid).HasColumnName("IDMagid");

                entity.Property(e => e.Id)
                    .HasMaxLength(11)
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Idquestion);

                entity.ToTable("Question");

                entity.Property(e => e.Idquestion).HasColumnName("IDQuestion");

                entity.Property(e => e.Idtest).HasColumnName("IDTest");

                entity.HasOne(d => d.IdtestNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Idtest)
                    .HasConstraintName("FK_Question_Test");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Idschool);

                entity.ToTable("School");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.ContactMail).HasMaxLength(50);

                entity.Property(e => e.ContactName).HasMaxLength(50);

                entity.Property(e => e.ContactTel).HasMaxLength(50);

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.Idcontact).HasColumnName("IDContact");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.HasOne(d => d.IdaddressNavigation)
                    .WithMany(p => p.Schools)
                    .HasForeignKey(d => d.Idaddress)
                    .HasConstraintName("FK_School_Address1");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.Idstreet);

                entity.ToTable("Street");

                entity.Property(e => e.Idstreet).HasColumnName("IDStreet");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Idstudent);

                entity.ToTable("Student");

                entity.Property(e => e.Idstudent).HasColumnName("IDStudent");

                entity.Property(e => e.DateCreate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.Idcreater).HasColumnName("IDCreater");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.IdaddressNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Idaddress)
                    .HasConstraintName("FK_Student_Address");

                entity.HasOne(d => d.IdcreaterNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Idcreater)
                    .HasConstraintName("FK_Student_User");

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK_Student_School");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.Idtest);

                entity.ToTable("Test");

                entity.Property(e => e.Idtest).HasColumnName("IDTest");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.Folder).HasMaxLength(50);

                entity.Property(e => e.Idcreater).HasColumnName("IDCreater");

                entity.Property(e => e.Idlevel).HasColumnName("IDLevel");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.VoiceSystemPhone).HasMaxLength(10);

                entity.HasOne(d => d.IdcreaterNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.Idcreater)
                    .HasConstraintName("FK_Test_User");

                entity.HasOne(d => d.IdlevelNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.Idlevel)
                    .HasConstraintName("FK_Test_Level");

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK_Test_School");
            });

            modelBuilder.Entity<TestOfStudent>(entity =>
            {
                entity.HasKey(e => e.IdtestToStudent);

                entity.ToTable("TestOfStudent");

                entity.Property(e => e.IdtestToStudent).HasColumnName("IDTestToStudent");

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.Folder).HasMaxLength(50);

                entity.Property(e => e.VoiceSystem).HasMaxLength(10);

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.TestOfStudents)
                    .HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_TestOfStudent_Student1");

                entity.HasOne(d => d.IdTestNavigation)
                    .WithMany(p => p.TestOfStudents)
                    .HasForeignKey(d => d.IdTest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestOfStudent_Test");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("User");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Tz).HasColumnName("TZ");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.VoiceSystemPassword).HasMaxLength(50);

                entity.Property(e => e.VoiceSystemPhone).HasMaxLength(50);

                entity.HasOne(d => d.IdaddressNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idaddress)
                    .HasConstraintName("FK_User_Address");
            });

            modelBuilder.Entity<_11>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("11");

                entity.Property(e => e.כתה).HasMaxLength(255);

                entity.Property(e => e.משפחה).HasMaxLength(255);

                entity.Property(e => e.עיר).HasMaxLength(255);

                entity.Property(e => e.פרטי).HasMaxLength(255);

                entity.Property(e => e.תז).HasColumnName("ת#ז#");

                entity.Property(e => e.תת).HasMaxLength(255);
            });

            modelBuilder.Entity<גיליון1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("גיליון1$");

                entity.Property(e => e.כתה).HasMaxLength(255);

                entity.Property(e => e.משפחה).HasMaxLength(255);

                entity.Property(e => e.עיר).HasMaxLength(255);

                entity.Property(e => e.פרטי).HasMaxLength(255);

                entity.Property(e => e.תז).HasColumnName("ת#ז#");

                entity.Property(e => e.תת).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
