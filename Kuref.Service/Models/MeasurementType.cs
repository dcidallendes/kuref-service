using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuref.Service.Models
{
    public class MeasurementType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string MeasurementUnit { get; set; }

        public IEnumerable<Measurement> Measurements { get; set; }
    }
}
