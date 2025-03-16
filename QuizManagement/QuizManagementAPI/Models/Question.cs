using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizManagementAPI.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public int CreatedBy { get; set; }
        public bool IsPublic { get; set; }
        public int? Difficulty { get; set; } 
        public string SubjectArea { get; set; }

        public User CreatedByUser { get; set; }
        public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();
        public ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
        public ICollection<AttemptAnswer> AttemptAnswers { get; set; } = new List<AttemptAnswer>();
    }
}
