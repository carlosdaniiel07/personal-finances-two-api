using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace personal_finances_two_api.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(1)]
        public string Type { get; set; }

        public bool Enabled { get; set; }

        public bool CanEdit { get; set; }

        [JsonIgnore]
        public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();

        [JsonIgnore]
        public ICollection<Movement> Movements { get; set; } = new List<Movement>();
    }
}