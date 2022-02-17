using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Models.Entities
{
    public class FaultPrices
    {
        [Key]
        public int FaultId { get; set; }
        public string FaultName { get; set; }
        public decimal FaultPrice { get; set; }
    }
}
