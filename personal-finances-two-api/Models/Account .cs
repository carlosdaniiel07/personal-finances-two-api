using Newtonsoft.Json;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        public double InitialBalance { get; set; }

        public double Balance { get; set; }

        [JsonIgnore]
        public ICollection<Movement> Movements { get; set; } = new List<Movement>();

        public bool Enabled { get; set; }
    }
}