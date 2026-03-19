//C#-nRepository-2026/Interfaces/IRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__nRepository_2026.Interfaces
{
    // הממשק הוגדר כגנרי (T) כדי לחסוך כפל קוד ולאפשר עבודה אחידה מול כל הטבלאות
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id); // סימן שאלה מציין שהאובייקט יכול להיות null
        Task<T> AddItemAsync(T item);
        Task DeleteItemAsync(int id);
        Task UpdateItemAsync(int id, T item);
    }
}
/*
 * מטרת הקובץ (Interface - IRepository):
 * זהו ממשק גנרי המגדיר את הפעולות הבסיסיות (CRUD) מול מסד הנתונים לכל טבלה (T).
 * תיקון קריטי: שמות המתודות שונו ונוסף להם הסיומת Async, והן מחזירות Task. 
 * זה מבטיח עמידה בדרישת הפרויקט (סעיף 22) שהגישה ל-DB תהיה א-סינכרונית כדי לא לחסום את 
 * התהליך הראשי (Thread).
 * הממשק משתמש ב-Generics כדי להגדיר חוזה אחיד לכל ה-Repositories בפרויקט.
 * הוספתי T? ב-GetById כדי לטפל במצב שבו מזהה (ID) לא קיים במערכת,
 * מה שמונע שגיאות ריצה (Null Reference Exception).
 */