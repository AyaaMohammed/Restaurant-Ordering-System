using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IEntity<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(int id);
    }
}
