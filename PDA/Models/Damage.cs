using PDA.IModels;
using System.ComponentModel.DataAnnotations;

namespace PDA.Models
{
    public class Damage : IAudit
    {
        public int DamageId { get; set; }
        public string DamageType { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }

        public ICollection<DamageContainer> DamagedContainers { get; set; } = new HashSet<DamageContainer>();
    }

}
