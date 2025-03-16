namespace QuizManagementAPI.Models
{
    public class RoomParticipant
    {
        public int RoomID { get; set; }
        public int StudentID { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public User Student { get; set; }
    }
}
