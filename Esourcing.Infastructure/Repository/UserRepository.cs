using Esourcing.Infastructure.Data;
using Esourcing.Infastructure.Repository.Base;
using ESourcing.Core.Entities;
using ESourcing.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esourcing.Infastructure.Repository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly WebAppContext _dbContext;

        public UserRepository(WebAppContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
