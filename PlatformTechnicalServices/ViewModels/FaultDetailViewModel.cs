using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.ViewModels
{
    public class FaultDetailViewModel
    {
        public int FaultId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string? TechnicianName { get; set; }
        public bool AssignmentStatus { get; set; }
        public DateTime FaultCreatedDate { get; set; }
        public DateTime? TechnicianAssignmentDate { get; set; }
        public DateTime? CompletionDate { get; set; }

    }
}
