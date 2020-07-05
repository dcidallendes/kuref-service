using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuref.Service.Models
{
    public class DeviceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual IEnumerable<PhysicalDevice> PhysicalDevices { get; set; }
    }
}
