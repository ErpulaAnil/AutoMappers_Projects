using AutoMappers_Project.Entities;

namespace AutoMappers_Project.Services
{
    public interface IUserRepository
    {
        User CreateUser(User user);   
        List<User> GetAllUsers();
        User GetUserById(Guid guid);
    }
}
