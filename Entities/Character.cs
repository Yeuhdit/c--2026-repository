//C#-nRepository-2026/Entities/Character.cs
using c__nRepository_2026.Entities;
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
 * 
// */
//איך הקוד עונה על דרישות הפרויקט?

//ייצוג טבלאות ב-Database: המורה הגדירה שתיקיית ה-
//model/data צריכה להכיל
//מחלקות המייצגות טבלאות במסד הנתונים. המחלקה Character עושה בדיוק את זה ובעתיד,
//בעזרת Entity Framework, תהפוך לטבלה בשם זה.


//בדיקות תקינות (Data Validation): המורה דרשה במפורש לכלול
//במחלקות בדיקות תקינות כמו required, id, maxLength. יישמת את זה בצורה מושלמת:

//[Key]: מגדיר את ה - Id כמפתח ראשי (Primary Key).

//[Required]: מבטיח ששם הדמות (ותאריך היצירה) לא יכולים להיות ריקים.
//זה גם יתורגם לשגיאה אוטומטית אם לקוח
//ינסה לשלוח בקשה בלי השדות האלו.

//[MaxLength]: שומר על יעילות מסד הנתונים ומונע הכנסת טקסטים
//ארוכים מדי לשם הדמות והתיאור.


//קשרי גומלין (Relationships): דרישת חובה נוספת של המורה הייתה לכלול קשרי גומלין.
//השורה public virtual ICollection<DetectedCharacter> DetectedCharacters
//מגדירה בדיוק את זה. היא יוצרת קשר של "יחיד לרבים"
//(One-to-Many) – כלומר, דמות אחת בגלריה יכולה להיות מזוהה מספר רב של פעמים
//בתמונות שונות (שיישמרו בטבלת DetectedCharacter).