using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// From what I have seen so far, Fhir's Id's support a mix of Id types: numbers, guids, ... [A-Za-z0-9\-\.]{1,64}
        /// Ref: https://hl7.org/fhir/datatypes.html#primitive
        /// </summary>
        // TODO: test regex
        [Required(ErrorMessage = "Id is required.")]
        [StringLength(64, ErrorMessage = "Id has a min {2} and max {1} length.", MinimumLength = 1)]
        [RegularExpression("/^[a-zA-Z0-9-_]+$/", ErrorMessage = "Only alphanumeric dash and period characters allowed.")]
        public string Id { get; set; } = default!;
    }
}
