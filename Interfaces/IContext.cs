//C#-nRepository-2026/Interfaces/IContext.cs
using c__nRepository_2026.Entities;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Interfaces
{
    public interface IContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<DetectedCharacter> DetectedCharacters { get; set; }
        DbSet<Gallery> Galleries { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<User> Users { get; set; } 

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
/*
 * מטרת הקובץ (Interface - IContext):
 * הגדרת חוזה (Contract) המייצג את מסד הנתונים. 
 * המטרה היא ששכבת ה-Repository תעבוד מול הממשק
 * הזה ולא מול ה-DbContext האמיתי ישירות.
 * זה מאפשר "הזרקת תלויות" (DI - סעיף 4) ומקל מאוד
 * על כתיבת בדיקות יחידה (Unit Tests) אם נצטרך בעתיד.
 */