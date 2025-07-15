using System.ComponentModel.DataAnnotations;

namespace LocalDataBase.Model
{
    /// <summary>
    /// Classe Base dos Modelos do Banco de Dados
    /// </summary>
    public class BaseModel
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
