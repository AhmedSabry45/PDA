using PDA.IModels;
using System.ComponentModel.DataAnnotations;

namespace PDA.Models
{
   
        public class ContainerInformation :IAudit
    {
            public int Id { get; set; }
            public int CycleId { get; set; }
            public string ContainerNumber { get; set; } = null!;
            public int VesselVoyageId { get; set; }
            public DateTime Date { get; set; }
            public int? RotationNumber { get; set; }
            public string? Size { get; set; }
            public string? Type { get; set; }
            public string? MadeOf { get; set; }
            public string? ContainerImage { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }

        public VesselVoyage VesselVoyage { get; set; } = null!;
            public ICollection<DamageContainer> DamagedContainers { get; set; } = new HashSet<DamageContainer>();
        }
    
}
