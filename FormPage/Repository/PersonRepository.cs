using FormPage.Data;
using FormPage.Entity;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly Datacontext _context;

        public PersonRepository(Datacontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonInfo>> GetAll()
        {
            return await _context.PersonInfo.ToListAsync();
        }

        public async Task<PersonInfo> GetById(int id)
        {
            return await _context.PersonInfo.FindAsync(id);
        }

        public async Task Add(PersonInfo person)
        {
            _context.PersonInfo.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task Update(PersonInfo person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _context.PersonInfo.FindAsync(id);
            if (person == null)
            {
                throw new ArgumentException("Person not found");
            }

            _context.PersonInfo.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}

