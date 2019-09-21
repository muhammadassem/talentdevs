using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadAssem.Models.Repos
{
    interface IDepartmentRepository<TEntity>
    {
        IList<TEntity> List();

        TEntity Find(int id);

        void Add(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(int id);

        void Save();
    }
}
