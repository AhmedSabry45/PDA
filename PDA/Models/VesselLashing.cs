using PDA.IModels;
using System.ComponentModel.DataAnnotations;

namespace PDA.Models
{
    public class VesselLashing : IAudit
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? SupervisorSignature { get; set; }
        public string? ChiefOfficerSignature { get; set; }
        public DateTime? LastContainerTime { get; set; }
        public DateTime? LashingCompletionTime { get; set; }
        public DateTime? LashingVerifiedTime { get; set; }
        public DateTime? LashingCertifiedTime { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }

        public VesselVoyage VesselVoyage { get; set; } = null!;
   
    }

}
