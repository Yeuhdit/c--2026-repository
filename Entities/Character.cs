// נתיב: c#-2026-repository/Entities/Character.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace c__repository_2026.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "שם הדמות הוא שדה חובה")]
        [MaxLength(100, ErrorMessage = "השם לא יכול לחרוג מ-100 תווים")]
        public string CharacterName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public string ProfileImageUrl { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        // קשרי גומלין - דמות יכולה להופיע בהרבה זיהויים, ובהרבה גלריות
        public virtual ICollection<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
        public virtual ICollection<Gallery> Galleries { get; set; } = new List<Gallery>();
    }
}
/*
 * מטרת העמוד:
 * מחלקה זו מייצגת את טבלת Characters במסד הנתונים. 
 * היא כוללת את תכונות הדמות, בדיקות תקינות (Data Annotations) שמונעות הכנסת נתונים שגויים ל-SQL,
 * וכן קשרי גומלין המאפשרים ל-Entity Framework להבין שדמות אחת מקושרת למספר זיהויים וגלריות (קשר של יחיד לרבים).
 */