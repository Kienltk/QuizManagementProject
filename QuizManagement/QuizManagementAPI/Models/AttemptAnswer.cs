using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizManagementAPI.Models
{
    public class AttemptAnswer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttemptID { get; set; }
        public int QuestionID { get; set; }
        public int? SelectedOptionID { get; set; } 
        public bool? IsCorrect { get; set; } 

        public QuizAttempt Attempt { get; set; }
        public Question Question { get; set; }
        public QuestionOption SelectedOption { get; set; }
    }
}
