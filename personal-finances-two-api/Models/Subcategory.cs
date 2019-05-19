using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace personal_finances_two_api.Models
{
    public class Subcategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public bool Enabled { get; set; }

        public bool CanEdit { get; set; }

        [JsonIgnore]
        public ICollection<Movement> Movements { get; set; } = new List<Movement>();
    }
}