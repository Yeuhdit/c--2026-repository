// נתיב: c#-2026-repository/Entities/DetectedCharacter.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace c__repository_2026.Models
{
    public class DetectedCharacter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int CharacterId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "אחוז הזיהוי חייב להיות בין 0 ל-100")]
        public double Confidence { get; set; }

        public string FaceCoordinates { get; set; } = string.Empty;

        public DateTime DetectionDate { get; set; }

        [MaxLength(50)]
        public string ModelUsed { get; set; } = string.Empty;

        // קשרי גומלין (Navigation Properties) - מקשרים חזרה לתמונה ולדמות
        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }
    }
}
/*
 * מטרת העמוד:
 * מחלקה המייצגת זיהוי ספציפי של פרצוף בתוך תמונה.
 * הוספנו כאן [ForeignKey] כדי להדגיש את החיבור ההדוק לטבלת התמונות ולטבלת הדמויות.
 * כמו כן, ישנה בדיקת תקינות ([Range]) שמוודאת שרמת הביטחון (Confidence) תמיד תהיה ערך הגיוני של אחוזים.
 */