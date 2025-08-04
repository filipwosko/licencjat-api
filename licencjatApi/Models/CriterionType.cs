using System.ComponentModel;

namespace licencjatApi.Models
{
    public enum CriterionType
    {        
        [Description("Kreterium typu Tak/Nie")]
        YesNo,
        [Description("Kryterium typu: wprowadź wartosc rzeczywista")]
        DecimalValue
    }
}
