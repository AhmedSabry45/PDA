namespace PDA.Models
{
    
        public class DynamicData
        {
            public List<string> Sizes { get; set; } = new List<string> { "20", "40", "45" };
            public List<string> Types { get; set; } = new List<string> { "Tank", "Empty", "Laden" };
            public List<string> Materials { get; set; } = new List<string> { "Aluminum", "Steel", "Fiberglass" };
            public List<string> DamageCodes { get; set; } = new List<string>
    {
        "B (Bruise)", "C (Cut)", "H (Hole)", "BR (Broken)",
        "M (Missing)", "R (Rust)", "S (Distorted)"
    };
        }

    }

