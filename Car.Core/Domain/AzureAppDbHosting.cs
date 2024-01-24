using System.ComponentModel.DataAnnotations;

namespace Car.Core.Domain
{
    public class AzureAppDbHosting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }


        public string LeadSourse { get; set; }
        [Required]
        public string Email { get; set; }


        public DateTime LeadData { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

    }
}

