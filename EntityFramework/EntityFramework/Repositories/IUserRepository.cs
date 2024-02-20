using EntityFramework.Models;

namespace EntityFramework.Repositories
{
    public interface IUserRepository
    {
        User FindById(int id);

        public List<User> FindAll();

        void Add(User user);

        void Delete(User user);

        void UpdateNameById(int id, string value);

        public void UpdateEmailById(int id, string value);

    }
}