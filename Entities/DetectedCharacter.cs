//C#-nRepository-2026/Entities/DetectedCharacter.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace c__nRepository_2026.Entities
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
        [Range(0.0, 1.0, ErrorMessage = "רמת הביטחון (Confidence) חייבת להיות בין 0 ל-1")]
        public float Confidence { get; set; }

        [Required]
        public DateTime DetectionDate { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual Image Image { get; set; }

        [ForeignKey(nameof(CharacterId))]
        public virtual Character Character { get; set; }
    }
}
/*
 * מטרת הקובץ (Entity - DetectedCharacter):
 * מחלקה זו מייצגת טבלת 'זיהויים' - קשר רבים-לרבים (או ישות מקשרת) בין תמונה לדמות.
 * היא מתעדת באיזו תמונה (ImageId) זוהתה איזו דמות (CharacterId), ומאיזו רמת ביטחון של האלגוריתם (Confidence).
 * נוספו [ForeignKey] כדי להדגיש את קשרי הגומלין (סעיף 7) ו-[Range] לאימות אחוזי הזיהוי.
 */