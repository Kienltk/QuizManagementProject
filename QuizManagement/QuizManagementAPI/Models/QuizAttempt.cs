using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizManagementAPI.Models
{
    public class QuizAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttemptID { get; set; }
        public int QuizID { get; set; }
        public int StudentID { get; set; }
        public int? RoomID { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } 
        public int? Score { get; set; }

        public Quiz Quiz { get; set; }
        public User Student { get; set; }
        public Room Room { get; set; }
        public ICollection<AttemptAnswer> AttemptAnswers { get; set; } = new List<AttemptAnswer>();
    }
}
