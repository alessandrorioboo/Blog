namespace ViewModel.ViewModels
{
    /// <summary>
    /// Classe ViewModel de Comentários
    /// </summary>
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? EMail { get; set; }
        public string? Body { get; set; }
    }
}
