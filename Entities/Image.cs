// נתיב: c#-2026-repository/Entities/Image.cs
using c__repository_2026.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace c__repository_2026.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "כתובת התמונה (Url) היא שדה חובה")]
        public string Url { get; set; } = string.Empty;

        [Required]
        public int GalleryId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime UploadedDate { get; set; }

        public bool IsProcessed { get; set; }

        // קשרי גומלין (Navigation Properties)
        [ForeignKey("GalleryId")]
        public virtual Gallery Gallery { get; set; }

        public virtual ICollection<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
    }
}
/*
 * מטרת העמוד:
 * מחלקה המייצגת תמונה בודדת שהועלתה למערכת (טבלת Images ב-DB).
 * כוללת בדיקות תקינות (כמו [Required] על ה-Url).
 * מוגדרים כאן קשרי גומלין: תמונה שייכת לגלריה אחת (GalleryId כ-ForeignKey ומצביע לאובייקט Gallery), 
 * ויכולה להכיל מספר רב של זיהויי פרצופים (ICollection של DetectedCharacter).
 */