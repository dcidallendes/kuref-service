using System;
using System.ComponentModel.DataAnnotations;

namespace Kuref.Service.Models
{
    public class PhysicalDeviceAssignation
    {
        [Required]
        public int PhysicalDeviceId { get; set; }

        [Required]
        public int StationId { get; set; }

        [Required]
        public int MeasurementTypeId { get; set; }

        public virtual PhysicalDevice PhysicalDevice { get; set; }

        public virtual Station Station { get; set; }

        public virtual MeasurementType MeasurementType { get; set; }
    }
}
