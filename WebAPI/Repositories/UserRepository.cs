using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.Data.Models;

namespace WebAPI.Repositories
{
    public class UserRepository
    {
        public TMP_DEMOContext context { get; set; }

        public UserRepository(TMP_DEMOContext dbContext)
        {
            context = dbContext;
        }

        public List<ProductEntity> Get()
        {
            throw new NotImplementedException();
        }

        public UserEntity Get(string user, string password)
        {
            var result = context.User.Where(x => x.Active.Value && (x.PersonalIdentification == user || user == x.Email)).Join(context.UserPassword.Where(z => z.Active.Value && z.Password == password),
                      x => x.PkUser,
                      y => y.FkUser,
                      (user, password) => new UserEntity
                      {
                          Id = user.PkUser,
                          Name = user.Name,
                          Email = user.Email,
                          Address = user.Address,
                          PersonalIdentification = user.PersonalIdentification
                      }).FirstOrDefault();
            return result;
        }

        public long Save(ProductEntity data)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductEntity data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
