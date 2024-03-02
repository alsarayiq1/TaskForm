using FormPage.Data;
using FormPage.Entity;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Repository
{
    public class ExperienceRepository
    {
        private readonly Datacontext _context;

        public ExperienceRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Experience>> GetAll()
        {
            return await _context.Experience.ToListAsync();
        }

        public async Task<Experience> GetById(int id)
        {
            return await _context.Experience.FindAsync(id);
        }

        public async Task Add(Experience Experience)
        {
            _context.Experience.Add(Experience);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Experience Experience)
        {
            _context.Entry(Experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Experience = await _context.Experience.FindAsync(id);
            if (Experience == null)
            {
                throw new ArgumentException("Courses not found");
            }

            _context.Experience.Remove(Experience);
            await _context.SaveChangesAsync();
        }
    }
}

