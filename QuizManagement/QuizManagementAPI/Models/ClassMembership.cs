namespace QuizManagementAPI.Models
{
    public class ClassMembership
    {
        public int ClassID { get; set; }
        public int StudentID { get; set; }

        public Class Class { get; set; }
        public User Student { get; set; }
    }
}
