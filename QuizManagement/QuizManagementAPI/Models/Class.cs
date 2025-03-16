using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizManagementAPI.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }

        public User CreatedByUser { get; set; }
        public ICollection<ClassMembership> ClassMemberships { get; set; } = new List<ClassMembership>();
        public ICollection<ClassQuiz> ClassQuizzes { get; set; } = new List<ClassQuiz>();
    }
}
