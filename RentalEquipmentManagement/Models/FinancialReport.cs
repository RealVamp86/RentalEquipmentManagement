using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalEquipmentManagement.Models
{
    public class FinancialReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Income { get; set; }

        [Required]
        [StringLength(255)]
        public string EquipmentUsage { get; set; }
    }
}
