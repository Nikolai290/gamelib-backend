using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamelib_backend.Infrastructure.Domain.Repositories {
    public class CompanyRepository : BaseCrudRepository<Company, int>, ICompanyRepository {
        public CompanyRepository(IDbContext dbContext) : base(dbContext) {
        }
    }
}
