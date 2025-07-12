using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDataBase.Model
{
    public class Post
    {
        public Post()
        {

        }

        public Post(Post post, User user, IList<Comment> comments)
        {
            this.Id = post.Id;
            this.UserId = post.UserId;
            this.User = user;
            this.Title = post.Title;
            this.Body = post.Body;
            this.Comments = comments;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}
