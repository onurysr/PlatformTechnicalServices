using PlatformTechnicalServices.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformTechnicalServices.Models.Entities
{
    public class FaultRecord
    {
        [Key]
        public int FaultId { get; set; }
        public string UserId { get; set; }
        public string OperatorId { get; set; }
        public string TeknisyenId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public bool AtanmaDurumu { get; set; }
        public DateTime FaultCreateDate { get; set; }
        public DateTime? TechnicianAssignmentDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string? Subject { get; set; }
        public decimal? TotalPrice { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey(nameof(TeknisyenId))]
        public virtual ApplicationUser Teknisyen { get; set; }
        [ForeignKey(nameof(OperatorId))]
        public virtual ApplicationUser Operator { get; set; }

    }
}
