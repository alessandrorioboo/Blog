namespace ViewModel.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserViewModel? User { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public List<CommentViewModel>? Comments { get; set; }

        public bool HasComments
        {
            get
            {
                return Comments != null && Comments.Count > 0;
            }
        }

        public string CommentsStr
        {
            get
            {
                var qtdComments = Comments != null ? Comments.Count : 0;
                return $"{qtdComments} comentário(s)";
            }
        }
    }
}
