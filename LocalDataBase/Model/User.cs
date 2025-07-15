using System.ComponentModel.DataAnnotations;

namespace LocalDataBase.Model
{
    public class User : BaseModel
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? UserName { get; set; }

        [MaxLength(255)]
        public string? EMail { get; set; }
    }
}
