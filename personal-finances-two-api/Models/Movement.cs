using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class Movement
    {
        public int Id { get; set; }

        [StringLength(1)]
        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Value { get; set; }

        public double? Increase { get; set; }

        public double? Decrease { get; set; }

        public DateTime InclusionDate { get; set; }

        public DateTime AccountingDate { get; set; }

        public Account Account { get; set; }

        [Required]
        [JsonIgnore]
        public int AccountId { get; set; }

        public Category Category { get; set; }

        [Required]
        [JsonIgnore]
        public int CategoryId { get; set; }

        public Subcategory Subcategory { get; set; }

        [Required]
        [JsonIgnore]
        public int SubcategoryId { get; set; }

        public Project Project { get; set; }

        [JsonIgnore]
        public int? ProjectId { get; set; }

        public Invoice Invoice { get; set; }

        [JsonIgnore]
        public int? InvoiceId { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public MovementStatus MovementStatus { get; set; }

        public string Observation { get; set; }

        public bool CanEdit { get; set; }
        
        public bool AutomaticallyLaunch { get; set; }
    }
}