using PDA.IModels;
using System.ComponentModel.DataAnnotations;

namespace PDA.Models
{
    public class DamageContainer : IAudit
    {
        public int ContainerId { get; set; }
        public int DamageId { get; set; }
        public int EmployeeId { get; set; }
        public string? ContainerImage { get; set; }
        public string? Comments { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }

        public ContainerInformation ContainerInformation { get; set; } = null!;
        public Damage Damage { get; set; } = null!;
        
    }

}
