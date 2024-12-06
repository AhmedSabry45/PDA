namespace PDA.Models
{
    public class ContainerDamageReportVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int RotationNumber { get; set; }
        public string ContainerNumber { get; set; }
        public string VesselName { get; set; }
        public string VoyageNumber { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }

        public string MadeOf {  get; set; }

        public string ContainerImage { get; set; }
        public string Material { get; set; }
        public List<int> DamageCodes { get; set; } = new List<int>();
        public string Remarks { get; set; }
        public string ChiefOfficerName { get; set; }

        public string ChiefOfficerSignature { get; set; }

      
    }
}
