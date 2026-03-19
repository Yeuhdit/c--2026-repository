//C#-nRepository-2026/Entities/Character.cs
using c__repository_2026.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace c__nRepository_2026.Entities
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "שם הדמות הוא שדה חובה")]
        [MaxLength(100, ErrorMessage = "שם הדמות לא יכול להכיל יותר מ-100 תווים")]
        public string CharacterName { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "התיאור ארוך מדי")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<DetectedCharacter> DetectedCharacters { get; set; } = new List<DetectedCharacter>();
    }
}
/*
 * מטרת הקובץ (Entity - Character):
 * מחלקה זו מייצגת את טבלת 'דמויות' במסד הנתונים. 
 * היא מכילה את המידע על הדמות שאנחנו מזהים בתמונות (שם, תיאור).
 * נוספו Data Annotations ([Key], [Required], [MaxLength]) בהתאם לדרישת הפרויקט (סעיף 7) 
 * כדי להבטיח תקינות נתונים ברמת מסד הנתונים וה-API. 
 * המאפיין DetectedCharacters הוא קשר גומלין (One-to-Many) לכל הפעמים שהדמות הזו זוהתה.
 */