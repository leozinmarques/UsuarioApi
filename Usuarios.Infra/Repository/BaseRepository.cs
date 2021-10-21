using Domain.Entities;
using Domain.Interfaces;
using Infra.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppSqlContext _appContext;

        public BaseRepository(AppSqlContext appContext)
        {
            _appContext = appContext;
        }

        public void Insert(TEntity obj)
        {
            _appContext.Set<TEntity>().Add(obj);
            _appContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _appContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _appContext.Set<TEntity>().Remove(Select(id));
            _appContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _appContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _appContext.Set<TEntity>().Find(id);

    }
}