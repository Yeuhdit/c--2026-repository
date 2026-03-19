// נתיב: c#-2026-repository/Interfaces/IRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace c__repository_2026.Interfaces
{
    // ממשק גנרי - ה-T מייצג את המחלקה (למשל Character או Image)
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
/*
 * מטרת העמוד:
 * זהו חוזה (Interface) גנרי שמגדיר אילו פעולות כל מחלקת Repository חייבת לממש מול מסד הנתונים.
 * הממשק הוא א-סינכרוני לחלוטין (משתמש ב-Task) בדיוק לפי סעיף 22 בדרישות.
 * ההגבלה 'where T : class' מבטיחה שנוכל להעביר אליו רק מחלקות (ה-Entities שלנו) ולא טיפוסי נתונים פשוטים כמו int.
 */