using Dtos_With_AutoMappers.Models;
using Microsoft.EntityFrameworkCore;

namespace Dtos_With_AutoMappers.Data
{
    public class PrescriptionDataContext:DbContext
    {
        public PrescriptionDataContext(DbContextOptions<PrescriptionDataContext> options)
            : base(options)
        {

        }

        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
