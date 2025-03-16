namespace QuizManagementAPI.DTOs.Request
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
    }
}
