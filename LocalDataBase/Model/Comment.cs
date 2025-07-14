namespace LocalDataBase.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string? Name { get; set; }
        public string? EMail { get; set; }
        public string? Body { get; set; }
    }
}
