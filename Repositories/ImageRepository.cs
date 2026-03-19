//C#-nRepository-2026/Repositories/ImageRepository.cs

using c__nRepository_2026.Interfaces;
using c__nRepository_2026.Entities;
using Microsoft.EntityFrameworkCore;

namespace c__nRepository_2026.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private readonly IContext _context;

        public ImageRepository(IContext context) { _context = context; }

        public async Task<Image> AddItemAsync(Image item)
        {
            await _context.Images.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItemAsync(int id)
        {
            var image = await GetByIdAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Image?> GetByIdAsync(int id)
        {
            return await _context.Images
                .AsNoTracking()
                .Include(i => i.DetectedCharacters)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Image>> GetAllAsync()
        {
            return await _context.Images.AsNoTracking().ToListAsync();
        }

        public async Task UpdateItemAsync(int id, Image item)
        {
            if (id != item.Id) return;
            await _context.SaveChangesAsync();
        }
    }
}
/*
 * מטרת הקובץ (ImageRepository):
 * מנהל את הגישה לנתונים עבור טבלת ה'תמונות'. 
 * בדומה ל-GalleryRepository, הכל הומר לעבודה א-סינכרונית (Task, async/await, ToListAsync).
 * בפונקציה GetImageWithDetectionsAsync הוסף שימוש ב-Include. המטרה היא כשאנחנו שולפים תמונה, 
 * נשלוף יחד איתה (Eager Loading) את כל אובייקטי ה-DetectedCharacters המקושרים אליה, כדי שנוכל להציג למשתמש מי הדמויות שזוהו בה.
 */