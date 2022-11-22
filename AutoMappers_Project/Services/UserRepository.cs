using AutoMappers_Project.ApplicationDbContext;
using AutoMappers_Project.Entities;

namespace AutoMappers_Project.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public User CreateUser(User user)
        {
            user.Id=Guid.NewGuid();
            _applicationContext.UserTable.Add(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            var result = _applicationContext.UserTable.ToList();
            return result;
        }

        public User GetUserById(Guid guid)
        {
            var data = _applicationContext.UserTable.Find(guid);
            return data;

            //var user = _applicationContext.UserTable.FirstOrDefault(u => u.Id == guid);
            //return user;
        }
    }
}
