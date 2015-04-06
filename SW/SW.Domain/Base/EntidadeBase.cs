using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SW.Core.Extensions;

namespace SW.Domain.Base
{
    public class EntidadeBase
    {
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Verifica se a entidade possui algum erro de validação de preenchimento dos atributos
        /// </summary>
        /// <returns>True: Validação ok, False: Erros de validação</returns>
        public virtual bool IsValid()
        {
            return this.TryValidate();
        }

        /// <summary>
        /// Retorna a coleção de erros de validação
        /// </summary>
        /// <returns>Coleção de erros caso existam</returns>
        public virtual ICollection<ValidationResult> ValidationResultsCollection()
        {
            return ValidationResultsCollection();
        }
    }
}
