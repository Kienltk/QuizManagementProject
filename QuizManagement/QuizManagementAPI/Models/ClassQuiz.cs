namespace QuizManagementAPI.Models
{
    public class ClassQuiz
    {
        public int ClassID { get; set; }
        public int QuizID { get; set; }

        public Class Class { get; set; }
        public Quiz Quiz { get; set; }
    }
}
