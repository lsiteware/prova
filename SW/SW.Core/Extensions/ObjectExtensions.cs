using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SW.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool TryValidate(this object o)
        {
            var vc = new ValidationContext(o);
            var results = new Collection<ValidationResult>();
            return Validator.TryValidateObject(o, vc, results);
        }

        public static ICollection<ValidationResult> ValidationResultsCollection(this object o)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(o, new ValidationContext(o, null, null), validationResults, true);
            return validationResults;
        }
    }
}
