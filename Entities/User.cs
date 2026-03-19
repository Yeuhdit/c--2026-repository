//C#-nRepository-2026/Entities/User.cs
using System.ComponentModel.DataAnnotations;

namespace c__nRepository_2026.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
//ישות המשתמש הכרחית
//למימוש דרישות האבטחה (סעיף 21). השתמשתי בקישוט [EmailAddress]
//כדי שהמערכת תבדוק אוטומטית שפורמט האימייל תקין כבר ברמת המודל.