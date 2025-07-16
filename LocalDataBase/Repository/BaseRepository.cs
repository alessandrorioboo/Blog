using LocalDataBase.Context;
using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Classe Base de Repositórios de Modelos de Dados
    /// </summary>
    /// <typeparam name="T">O Tipo do Modelo de Dados</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public virtual async Task Add(T model)
        {
            using (var context = new BlogContext())
            {
                context.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task AddAll(IList<T> listModel)
        {
            using (var context = new BlogContext())
            {
                context.AddRange(listModel);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task AddOrUpdate(T model)
        {
            using (var context = new BlogContext())
            {
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

        }

        public virtual async Task AddOrUpdateAll(List<T> listModel)
        {
            using (var context = new BlogContext())
            {
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
        }


        public virtual async Task<List<T>> GetAll()
        {
            using (var context = new BlogContext())
            {
                return await context.Set<T>().ToListAsync<T>();
            }
        }

        public virtual async Task<List<T>> GetAllPostsPaged(int items, int page)
        {
            using (var context = new BlogContext())
            {
                return await context.Set<T>().OrderByDescending(p => p.Id).Skip((page - 1) * items).Take(items).ToListAsync();
            }
        }

        public virtual async Task<int> GetQttRows()
        {
            using (var context = new BlogContext())
            {
                return await context.Set<T>().CountAsync();
            }
        }

        public virtual async Task RemoveAll()
        {
            using (var context = new BlogContext())
            {
                await context.Set<T>().ExecuteDeleteAsync();
            }
        }


    }
}
