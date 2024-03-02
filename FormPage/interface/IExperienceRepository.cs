using FormPage.Entity;

namespace FormPage
{
    public interface IExperienceRepository 
    {
        Task<IEnumerable<Experience>> GetAll();
        Task<Experience> GetById(int id);
        Task Add(Experience experience);
        Task Update(Experience experience);
        Task Delete(int id);
        bool ExpCreate(object expMap);
    }

}
