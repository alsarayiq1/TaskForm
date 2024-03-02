using FormPage.Entity;

namespace FormPage
{
    public interface IcoursesRepository
    {
        Task<IEnumerable<Courses>> GetAll();
        Task<Courses> GetById(int id);
        Task Add(Courses Courses);
        Task Update(Courses Courses);
        Task Delete(int id);
        bool CoursesCreate(Courses coursesMap);
    }

}
