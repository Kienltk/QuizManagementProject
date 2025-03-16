using Microsoft.EntityFrameworkCore;
using QuizManagementAPI.Models;

namespace QuizManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassMembership> ClassMemberships { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<ClassQuiz> ClassQuizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomParticipant> RoomParticipants { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }
        public DbSet<AttemptAnswer> AttemptAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình khóa chính tổng hợp và mối quan hệ

            // ClassMembership: Khóa chính tổng hợp và xử lý cascade
            modelBuilder.Entity<ClassMembership>()
                .HasKey(cm => new { cm.ClassID, cm.StudentID });
            modelBuilder.Entity<ClassMembership>()
                .HasOne(cm => cm.Class)
                .WithMany(c => c.ClassMemberships)
                .HasForeignKey(cm => cm.ClassID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClassMembership>()
                .HasOne(cm => cm.Student)
                .WithMany(u => u.ClassMemberships)
                .HasForeignKey(cm => cm.StudentID)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths

            // ClassQuiz: Khóa chính tổng hợp
            modelBuilder.Entity<ClassQuiz>()
                .HasKey(cq => new { cq.ClassID, cq.QuizID });
            modelBuilder.Entity<ClassQuiz>()
                .HasOne(cq => cq.Class)
                .WithMany(c => c.ClassQuizzes)
                .HasForeignKey(cq => cq.ClassID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClassQuiz>()
                .HasOne(cq => cq.Quiz)
                .WithMany(q => q.ClassQuizzes)
                .HasForeignKey(cq => cq.QuizID)
                .OnDelete(DeleteBehavior.Cascade);

            // QuizQuestion: Khóa chính tổng hợp
            modelBuilder.Entity<QuizQuestion>()
                .HasKey(qq => new { qq.QuizID, qq.QuestionID });
            modelBuilder.Entity<QuizQuestion>()
                .HasOne(qq => qq.Quiz)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuizID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<QuizQuestion>()
                .HasOne(qq => qq.Question)
                .WithMany(q => q.QuizQuestions)
                .HasForeignKey(qq => qq.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            // RoomParticipant: Khóa chính tổng hợp
            modelBuilder.Entity<RoomParticipant>()
                .HasKey(rp => new { rp.RoomID, rp.StudentID });
            modelBuilder.Entity<RoomParticipant>()
                .HasOne(rp => rp.Room)
                .WithMany(r => r.RoomParticipants)
                .HasForeignKey(rp => rp.RoomID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RoomParticipant>()
                .HasOne(rp => rp.Student)
                .WithMany(u => u.RoomParticipations)
                .HasForeignKey(rp => rp.StudentID)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths

            // AttemptAnswer: Khóa chính tổng hợp
            modelBuilder.Entity<AttemptAnswer>()
                .HasKey(aa => new { aa.AttemptID, aa.QuestionID });
            modelBuilder.Entity<AttemptAnswer>()
                .HasOne(aa => aa.Attempt)
                .WithMany(qa => qa.AttemptAnswers)
                .HasForeignKey(aa => aa.AttemptID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AttemptAnswer>()
                .HasOne(aa => aa.Question)
                .WithMany(q => q.AttemptAnswers)
                .HasForeignKey(aa => aa.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<AttemptAnswer>()
                .HasOne(aa => aa.SelectedOption)
                .WithMany()
                .HasForeignKey(aa => aa.SelectedOptionID)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false); // SelectedOptionID có thể NULL

            // Các mối quan hệ khác
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.CreatedByUser)
                .WithMany(u => u.CreatedClasses)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths

            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedByUser)
                .WithMany(u => u.CreatedQuestions)
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths

            modelBuilder.Entity<QuestionOption>()
                .HasOne(qo => qo.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(qo => qo.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.CreatedByUser)
                .WithMany(u => u.CreatedQuizzes)
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Quiz)
                .WithMany(q => q.Rooms)
                .HasForeignKey(r => r.QuizID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Room>()
                .HasOne(r => r.CreatedByUser)
                .WithMany(u => u.CreatedRooms)
                .HasForeignKey(r => r.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Class)
                .WithMany()
                .HasForeignKey(r => r.ClassID)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false); // ClassID có thể NULL

            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Quiz)
                .WithMany(q => q.QuizAttempts)
                .HasForeignKey(qa => qa.QuizID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Student)
                .WithMany(u => u.QuizAttempts)
                .HasForeignKey(qa => qa.StudentID)
                .OnDelete(DeleteBehavior.NoAction); // Tránh multiple cascade paths
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.Room)
                .WithMany(r => r.QuizAttempts)
                .HasForeignKey(qa => qa.RoomID)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false); // RoomID có thể NULL
        }
    }
}
