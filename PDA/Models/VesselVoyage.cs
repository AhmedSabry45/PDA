using PDA.IModels;
using System.ComponentModel.DataAnnotations;

namespace PDA.Models
{
    public class VesselVoyage : IAudit
    {
        public int Id { get; set; }
        public string VesselName { get; set; } = null!;
        public string VesselCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public int? RotationNumber { get; set; }
        public string? ChiefOfficerName { get; set; }
        public string? SupervisorName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }

        public ICollection<VesselLashing> VesselLashings { get; set; } = new HashSet<VesselLashing>();
        public ICollection<ContainerInformation> ContainerInformations { get; set; } = new HashSet<ContainerInformation>();
    }

}
