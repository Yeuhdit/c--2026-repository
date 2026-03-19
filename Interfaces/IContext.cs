// נתיב: c#-2026-repository/Interfaces/IContext.cs
using c__repository_2026.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace c__repository_2026.Interfaces
{
    public interface IContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<DetectedCharacter> DetectedCharacters { get; set; }

        // חתימה לפונקציית השמירה הא-סינכרונית של Entity Framework
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
/*
 * מטרת העמוד:
 * ממשק זה משמש כהפשטה (Abstraction) ל-DbContext שלנו (שיושב בפרויקט ה-Data).
 * המטרה היא שמחלקות ה-Repository יכירו רק את הממשק הזה ולא את ה-SQL ישירות, 
 * מה שעוזר ל-Dependency Injection ולהפרדת שכבות נכונה כפי שנדרש.
 */