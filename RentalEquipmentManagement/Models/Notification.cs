using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalEquipmentManagement.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
