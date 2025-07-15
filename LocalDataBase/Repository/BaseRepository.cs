using LocalDataBase.Context;
using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LocalDataBase.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        internal BlogContext context;

        public BaseRepository()
        {
            context = new BlogContext();
        }

        public virtual async Task Add(T model)
        {
            context.ChangeTracker.Clear();
            context.Add(model);
            await context.SaveChangesAsync();
        }

        public virtual async Task AddAll(IList<T> listModel)
        {
            context.ChangeTracker.Clear();
            context.AddRange(listModel);
            await context.SaveChangesAsync();
        }

        public virtual async Task AddOrUpdate(T model)
        {
            context.ChangeTracker.Clear();            
            DbSet<T> set = context.Set<T>();

            if (set.Any(x => x.Id == model.Id))
            {
                context.Entry(model).State = EntityState.Modified;
            }
            else
            {
                context.Add(model);
            }

            await context.SaveChangesAsync();

        }

        public virtual async Task AddOrUpdateAll(List<T> listModel)
        {
            context.ChangeTracker.Clear();
            DbSet<T> set = context.Set<T>();

            foreach (T model in listModel)
            {
                if (set.Any(x => x.Id == model.Id))
                {
                    context.Entry(model).State = EntityState.Modified;
                }
                else
                {
                    context.Add(model);
                }
            }

            await context.SaveChangesAsync();

        }


        public virtual async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync<T>();
        }

        public virtual async Task<List<T>> GetAllPostsPaged(int items, int page)
        {
            return await context.Set<T>().OrderByDescending(p => p.Id).Skip((page - 1) * items).Take(items).ToListAsync();
        }

        public virtual async Task<int> GetQttRows()
        {
            return await context.Set<T>().CountAsync();
        }

        public virtual async Task RemoveAll()
        {
            context.ChangeTracker.Clear();
            await context.Set<T>().ExecuteDeleteAsync();
        }


    }
}
