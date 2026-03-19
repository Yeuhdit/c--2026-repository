//////C#-nRepository-2026/Repositories/GalleryRepository.cs

//using c__nRepository_2026.Interfaces;
//using c__nRepository_2026.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace c__nRepository_2026.Repositories
//{
//    public class GalleryRepository : IRepository<Gallery>
//    {
//        private readonly IContext _context;

//        public GalleryRepository(IContext context) { _context = context; }

//        public async Task<Gallery> AddItemAsync(Gallery item)
//        {
//            item.CreatedDate = DateTime.Now;
//            await _context.Galleries.AddAsync(item);
//            await _context.SaveChangesAsync();
//            return item;
//        }

//        public async Task DeleteItemAsync(int id)
//        {
//            var gallery = await GetByIdAsync(id);
//            if (gallery != null)
//            {
//                _context.Galleries.Remove(gallery);
//                await _context.SaveChangesAsync();
//            }
//        }

//        public async Task<Gallery?> GetByIdAsync(int id)
//        {
//            return await _context.Galleries
//                .AsNoTracking()
//                .Include(g => g.Images) // טעינת התמונות בתוך הגלריה
//                .FirstOrDefaultAsync(g => g.Id == id);
//        }

//        public async Task<List<Gallery>> GetAllAsync()
//        {
//            return await _context.Galleries
//                .AsNoTracking()
//                .OrderByDescending(g => g.CreatedDate)
//                .ToListAsync();
//        }

//        public async Task UpdateItemAsync(int id, Gallery item)
//        {
//            if (id != item.Id) return;
//            await _context.SaveChangesAsync();
//        }

//        public async Task<List<Gallery>> GetGalleriesByUserIdAsync(int userId)
//        {
//            return await _context.Galleries
//                .AsNoTracking()
//                .Where(g => g.UserId == userId)
//                .ToListAsync();
//        }
//    }
//}
///*
// * מטרת הקובץ (GalleryRepository):
// * מחלקה זו אחראית על כל פעולות המסד (CRUD) עבור ישות 'גלריה'.
// * שינויים שבוצעו:
// * 1. הוספת Using ל-Microsoft.EntityFrameworkCore ו-System.Threading.Tasks.
// * 2. כל הפונקציות הפכו ל-async ומחזירות Task כדי לעמוד בדרישת המורה לגישה א-סינכרונית ל-DB (סעיף 22).
// * 3. החלפת פקודות LINQ רגילות בפקודות הא-סינכרוניות של Entity Framework (כמו ToListAsync ו-FirstOrDefaultAsync).
// * 4. שדרוג מקצועי: בפונקציה GetGalleryWithImagesAsync הוספתי את הפקודה Include(g => g.Images). זה הכרחי, כי אחרת Entity Framework לא ישלוף את התמונות הקשורות לגלריה, והרשימה תהיה ריקה.
// */
// הנתיב המלא: C#-nRepository-2026/Repositories/GalleryRepository.cs
using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace c__nRepository_2026.Repositories
{
    public class GalleryRepository : IRepository<Gallery>
    {
        private readonly IContext _context;

        public GalleryRepository(IContext context) { _context = context; }

        public async Task<Gallery> AddItemAsync(Gallery item)
        {
            item.CreatedDate = DateTime.Now;
            await _context.Galleries.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var gallery = await GetByIdAsync(id);
            if (gallery != null)
            {
                _context.Galleries.Remove(gallery);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Gallery?> GetByIdAsync(int id)
        {
            return await _context.Galleries
                .AsNoTracking()
                .Include(g => g.Images)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Gallery>> GetAllAsync()
        {
            return await _context.Galleries
                .AsNoTracking()
                .OrderByDescending(g => g.CreatedDate)
                .ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Gallery item)
        {
            var existing = await _context.Galleries.FirstOrDefaultAsync(g => g.Id == id);
            if (existing != null)
            {
                item.Id = id;
                _context.Galleries.Entry(existing).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Gallery>> GetGalleriesByUserIdAsync(int userId)
        {
            return await _context.Galleries
                .AsNoTracking()
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<Gallery>> GetGalleriesByCharacterIdAsync(int characterId)
        {
            return await _context.Galleries
                .AsNoTracking()
                .Where(g => g.CharacterId == characterId)
                .ToListAsync();
        }
    }
}
/*
 * מטרת הקובץ (GalleryRepository):
 * ניהול גלריות. מתעדכן בצורה בטוחה לפי ה-ID.
 * כולל Include כדי לשלוף את התמונות יחד עם הגלריה, וכן מימוש לשליפת גלריות לפי משתמש או דמות.
 */