using FormPage.Data;
using FormPage.Entity;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Repository
{
    public class CoursesRepository: IcoursesRepository
    {
        private readonly Datacontext _context;

        public CoursesRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task Add(Courses Courses)
        {
            _context.Courses.Add(Courses);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Courses Courses)
        {
            _context.Entry(Courses).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Courses = await _context.Courses.FindAsync(id);
            if (Courses == null)
            {
                throw new ArgumentException("Courses not found");
            }

            _context.Courses.Remove(Courses);
            await _context.SaveChangesAsync();
        }

        public bool CoursesCreate(Courses coursesMap)
        {
            throw new NotImplementedException();
        }
    }
}
