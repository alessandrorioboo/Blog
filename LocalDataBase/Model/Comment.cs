using System.ComponentModel.DataAnnotations;

namespace LocalDataBase.Model
{
    public class Comment: BaseModel
    {
        [Required]
        public int PostId { get; set; }       
        
        //public Post? Post { get; set; }
        
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? EMail { get; set; }

        [MaxLength(500)]
        public string? Body { get; set; }
    }
}
