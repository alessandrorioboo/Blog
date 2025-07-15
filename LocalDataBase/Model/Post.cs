using System.ComponentModel.DataAnnotations;

namespace LocalDataBase.Model
{
    /// <summary>
    /// Classe do Modelo de Postagens
    /// </summary>
    public class Post : BaseModel
    {
        public Post()
        {

        }

        public Post(Post post, User user, List<Comment> comments)
        {
            this.Id = post.Id;
            this.UserId = post.UserId;
            this.User = user;
            this.Title = post.Title;
            this.Body = post.Body;
            this.Comments = comments;
        }
      
        [Required]
        public int UserId { get; set; }
        
        public User? User { get; set; }
        
        [MaxLength(80)]
        public string? Title { get; set; }

        [MaxLength(500)]
        public string? Body { get; set; }

        public List<Comment>? Comments { get; set; }
    }
}
