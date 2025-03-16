using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizManagementAPI.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizID { get; set; }
        public string QuizCode { get; set; }
        public string QuizTitle { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreationDate { get; set; }

        public User CreatedByUser { get; set; }
        public ICollection<ClassQuiz> ClassQuizzes { get; set; } = new List<ClassQuiz>();
        public ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}
