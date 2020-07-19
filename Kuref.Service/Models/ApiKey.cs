using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using AspNetCore.Authentication.ApiKey;

namespace Kuref.Service.Models
{
    public class ApiKey: IApiKey
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string OwnerName { get; set; }

        [Required]
        public bool Enabled { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        [MaxLength(250)]
        public string Key { get; set; }

        [NotMapped]
        public IReadOnlyCollection<Claim> Claims => null;
    }
}
