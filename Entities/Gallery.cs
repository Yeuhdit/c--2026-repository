// נתיב: c#-2026-repository/Entities/Gallery.cs
using c__repository_2026.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace c__repository_2026.Entities
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "שם הגלריה הוא שדה חובה")]
        [MaxLength(100, ErrorMessage = "שם הגלריה לא יכול לחרוג מ-100 תווים")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public int CharacterId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        // קשרי גומלין (Navigation Properties)
        [ForeignKey("CharacterId")]
        public virtual Character Character { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
/*
 * מטרת העמוד:
 * מחלקה המייצגת גלריית תמונות במערכת (טבלת Galleries במסד הנתונים).
 * כוללת בדיקות תקינות כפי שנדרש על ידי המורה (Required, MaxLength).
 * קשרי הגומלין מציינים שגלריה יכולה להיות משויכת לדמות מרכזית אחת (Character), 
 * ושהיא מכילה אוסף של תמונות (ICollection של Image - קשר של יחיד לרבים).
 */