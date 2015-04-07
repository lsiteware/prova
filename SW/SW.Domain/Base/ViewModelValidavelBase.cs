using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SW.Core.Extensions;

namespace SW.Domain.Base
{
    public class ViewModelValidavelBase
    {
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
        public virtual ICollection<ValidationResult> ValidationResults()
        {
            return this.ValidationResultsCollection();
        }

        /// <summary>
        /// Listagem de mensagens de erro de validação
        /// </summary>
        public virtual IEnumerable<string> MensagensErro()
        {
            return (from v in ValidationResults()
                    select v.ErrorMessage);
        }
    }
}
