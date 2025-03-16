using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuizManagementAPI.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        public string RoomCode { get; set; }
        public int QuizID { get; set; }
        public int CreatedBy { get; set; }
        public int? ClassID { get; set; } 
        public DateTime? StartTime { get; set; } 
        public DateTime? EndTime { get; set; } 
        public bool IsPublish { get; set; }

        public Quiz Quiz { get; set; }
        public User CreatedByUser { get; set; }
        public Class Class { get; set; }
        public ICollection<RoomParticipant> RoomParticipants { get; set; } = new List<RoomParticipant>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}
