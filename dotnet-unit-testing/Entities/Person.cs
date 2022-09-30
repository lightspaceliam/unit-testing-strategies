using Entities.Abstract;

namespace Entities
{
    public enum PersonTypes
    {
        Civilian,
        Pilot,
        AirBoss,
        Admiral
    }

    public class Person : EntityBase
    {
        private PersonTypes _type;

        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Type 
        {
            get => _type.ToString();
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Type is required.");
                }
                if(!Enum.TryParse(value, out PersonTypes type))
                    throw new Exception($"{typeof(Person).Name}.Type: {value} is not currently supported.");

                _type = type;
            }
        }
        public DateTime Dob { get; set; } = default!;
    }
}
