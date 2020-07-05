using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kuref.Service.Models
{
    public class PhysicalDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manufacter { get; set; }

        [MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public int DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }

        public virtual PhysicalDeviceAssignation PhysicalDeviceAssignation { get; set; }
    }
}
