//C#-nRepository-2026/Repositories/CharacterRepository.cs
using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly IContext _context;
        public CharacterRepository(IContext context) { _context = context; }

        public async Task<Character> AddItemAsync(Character item)
        {
            await _context.Characters.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var character = await GetByIdAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            // שימוש ב-AsNoTracking משפר ביצועים בשליפות לקריאה בלבד
            return await _context.Characters
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Character>> GetAllAsync()
        {
            return await _context.Characters.AsNoTracking().ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Character item)
        {
            // הדרך הנכונה לעדכן ב-Entity Framework:
            if (id != item.Id) return;
            await _context.SaveChangesAsync();
        }
    }
}
/*
 * מטרת הקובץ (Repository - CharacterRepository):
 * מימוש בפועל של גישה לנתונים עבור ישות 'דמות' מתוך מסד הנתונים.
 * המימוש מעודכן להיות א-סינכרוני (async/await) עם פונקציות כמו ToListAsync() השייכות ל-Entity Framework.
 * המחלקה משתמשת בהזרקת תלויות (DI) של ה-IContext בקונסטרקטור, בהתאם לדרישות (סעיף 4).
 */