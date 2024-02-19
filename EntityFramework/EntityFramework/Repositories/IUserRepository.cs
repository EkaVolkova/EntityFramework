using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IUserRepository
    {
        User FindById(int id);

        public List<User> FindAll();

        void Add(User user);

        void Delete(User user);

        void UpdateById(int id, string value);
    }
}