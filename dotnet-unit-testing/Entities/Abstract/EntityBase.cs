using System.ComponentModel.DataAnnotations;

namespace Entities.Abstract
{
    public abstract class EntityBase : IEntity
    {
        /// <summary>
        /// From what I have seen so far, Fhir's Id's support a mix of Id types: numbers, guids, ... [A-Za-z0-9\-\.]{1,64}
        /// Will leave generation & further validation out of scope for now.
        /// Ref: https://hl7.org/fhir/datatypes.html#primitive
        /// </summary>
        [Required(ErrorMessage = "Id is required.")]
        [StringLength(64, ErrorMessage = "Id has a min {2} and max {1} length.", MinimumLength = 1)]
        public string Id { get; set; } = default!;
    }
}
