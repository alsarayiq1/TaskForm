using FormPage.Entity;
using Microsoft.AspNetCore.Mvc;

namespace FormPage.Controllers
{
    public interface IPersonRepository<T>
    {
        Task Delete(int personInfoId);
        Task<object?> GetAll();
        Task<ActionResult<PersonInfo>> GetById(int personInfoId);
        IEnumerable<object> GetById();
        IEnumerable<object> GetById(object id);
        bool PersonCreate(PersonInfo categoryMap);
        Task Update(PersonInfo person);
    }
}