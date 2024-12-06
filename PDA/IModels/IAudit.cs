using System.ComponentModel.DataAnnotations;

namespace PDA.IModels
{
    public interface IAudit
    {
        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string Actions { get; set; }
        public bool IsActive { get; set; }
    }
}
