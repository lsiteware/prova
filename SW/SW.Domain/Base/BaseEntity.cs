using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SW.Core.Extensions;

namespace SW.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        // Verifica se a entidade possui algum erro de validação de preenchimento dos atributos
        public bool IsValid { get { return this.TryValidate(); } }
    }
}
