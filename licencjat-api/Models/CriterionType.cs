using System.ComponentModel;

namespace licencjat_api.Models
{
    public enum CriterionType
    {        
        [Description("Kreterium typu Tak/Nie")]
        YesNo,
        [Description("Kryterium typu: wprowadź wartosc rzeczywista")]
        DecimalValue
    }
}
