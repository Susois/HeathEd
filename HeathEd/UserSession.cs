namespace HeathEd
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Email { get; set; }
        public static string Role { get; set; } // "Student" hoặc "Lecturer"

        public static bool IsStudent => Role == "Student";
        public static bool IsLecturer => Role == "Lecturer";

        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            FullName = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
        }
    }
}