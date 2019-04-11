using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public double? Budget { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProjectStatus ProjectStatus { get; set; }

        public bool Enabled { get; set; }

        [JsonIgnore]
        public ICollection<Movement> Movements { get; set; } = new List<Movement>();
    }
}