using LocalDataBase.Context;
using LocalDataBase.Model;
using Microsoft.EntityFrameworkCore;

namespace LocalDataBase.Repository
{
    /// <summary>
    /// Classe de Repositórios de Dados de Postagens
    /// </summary>
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private IUserRepository _userRepository;

        public PostRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Método temporário para resolver a falha do EF ao incluir (algumas vezes) o usuário.
        // INVESTIGAR corretamente o problema e refatorar
        public async Task AddOrUpdateAllAlternativo(List<Post> listPost)
        {
            using (var context = new BlogContext())
            {
                foreach (Post post in listPost)
                {
                    if (context.Posts.Any(x => x.Id == post.Id))
                    {
                        context.Entry(post).State = EntityState.Modified;
                    }
                    else
                    {
                        // Incluindo manualmente o usuário devido falha no EF
                        if (post.User != null)
                        {
                            await _userRepository.AddOrUpdate(post.User);
                            post.User = null;
                        }

                        context.Add(post);
                    }
                }
               
                await context.SaveChangesAsync();
               
            }
        }
    }
}
