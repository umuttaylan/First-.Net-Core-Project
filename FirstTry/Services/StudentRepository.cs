using FirstTry.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTry.Services
{
    public class StudentRepository : AppRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
