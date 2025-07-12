using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel? User { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public IList<CommentViewModel>? Comments { get; set; }
    }
}
