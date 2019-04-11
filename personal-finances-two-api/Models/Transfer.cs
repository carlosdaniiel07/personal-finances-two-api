using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using personal_finances_two_api.Models.Enums;

namespace personal_finances_two_api.Models
{
    public class Transfer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public Account Origin { get; set; }

        [Required]
        [JsonIgnore]
        public int OriginId { get; set; }

        public Account Target { get; set; }

        [Required]
        [JsonIgnore]
        public int TargetId { get; set; }

        [Required]
        public double Value { get; set; }

        public double? Tax { get; set; }

        public DateTime InclusionDate { get; set; }

        public DateTime AccountingDate { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransferStatus TransferStatus { get; set; }

        public bool AutomaticallyLaunch { get; set; }

        public string Observation { get; set; }
    }
}