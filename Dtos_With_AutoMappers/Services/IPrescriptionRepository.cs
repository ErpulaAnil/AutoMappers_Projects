using Dtos_With_AutoMappers.Models;

namespace Dtos_With_AutoMappers.Services
{
    public interface IPrescriptionRepository
    {
        IEnumerable<Prescription> GetAll();
        Prescription Get(int id);
        void Delete(int id);
        void Update(Prescription prescription);
        void Create(Prescription prescription);
        bool SaveChanges();
    }
}
