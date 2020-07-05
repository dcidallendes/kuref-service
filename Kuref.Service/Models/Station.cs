using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuref.Service.Models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string LocationDescription { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IEnumerable<PhysicalDeviceAssignation> PhysicalDeviceAssignations { get; set; }

        public IEnumerable<Measurement> Measurements { get; set; }
    }
}
