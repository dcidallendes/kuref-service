using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuref.Service.Models
{
    public class Measurement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int MeasurementTypeId { get; set; }

        [Required]
        public int StationId { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public DateTime RegistrationTime { get; set; }

        [Required]
        public DateTime MeasurementTime { get; set; }

        public virtual MeasurementType MeasurementType { get; set; }

        public virtual Station Station { get; set; }
    }
}
