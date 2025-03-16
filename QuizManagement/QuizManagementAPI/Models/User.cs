using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace QuizManagementAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }

        public Role Role { get; set; }
        public ICollection<Class> CreatedClasses { get; set; } = new List<Class>();
        public ICollection<Question> CreatedQuestions { get; set; } = new List<Question>();
        public ICollection<Quiz> CreatedQuizzes { get; set; } = new List<Quiz>();
        public ICollection<Room> CreatedRooms { get; set; } = new List<Room>();
        public ICollection<ClassMembership> ClassMemberships { get; set; } = new List<ClassMembership>();
        public ICollection<RoomParticipant> RoomParticipations { get; set; } = new List<RoomParticipant>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}
