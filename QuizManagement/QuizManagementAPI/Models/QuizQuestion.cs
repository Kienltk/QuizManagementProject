namespace QuizManagementAPI.Models
{
    public class QuizQuestion
    {
        public int QuizID { get; set; }
        public int QuestionID { get; set; }
        public int OrderNumber { get; set; }

        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
    }
}
