using FormPage.Entity;

namespace FormPage
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonInfo>> GetAll();
        Task<PersonInfo> GetById(int PersonInfoId);
        Task Add(PersonInfo PersonInfo);
        Task Update(PersonInfo PersonInfo);
        Task Delete(int PersonInfoId);
    }

}
